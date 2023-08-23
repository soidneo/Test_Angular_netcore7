using FastEndpoints;
using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.Core.TestAggregate.Specifications;
using Interrapidisimo_test.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Interrapidisimo_test.Web.Endpoints.StudentEndpoints;

public class RegisterSubject : Endpoint<RegisterSubjectRequest, RegisterSubjectResponse>
{
  private readonly IRepository<Student> _repositoryStudent;
  private readonly IRepository<Professor> _repositoryProfessor;
  private readonly IRepository<Subject> _repositorySubject;
  private readonly IRepository<SelectedSubject> _repositorySelectedSubject;

  public RegisterSubject(IRepository<Student> repositoryStudent,
   IRepository<Professor> repositoryProfessor,
   IRepository<Subject> repositorySubject,
   IRepository<SelectedSubject> repositorySelectedSubject)
  {
    _repositoryStudent = repositoryStudent;
    _repositoryProfessor = repositoryProfessor;
    _repositorySubject = repositorySubject;
    _repositorySelectedSubject = repositorySelectedSubject;
  }

  public override void Configure()
  {
    Post(RegisterSubjectRequest.Route);
    AllowAnonymous();
    Options(x => x
      .WithTags("StudentEndpoints"));
  }

  public override async Task HandleAsync(
      RegisterSubjectRequest request,
      CancellationToken cancellationToken)
  {
    var student = await _repositoryStudent.GetByIdAsync(request.StudentId, cancellationToken);
    if (student == null)
    {
      ThrowError("No se encontró estudiante");
    }
    if (student.RegisteredSubjets >= 3)
    {
      ThrowError("Ya se han registrado tres materias");
    }

    var professor = await _repositoryProfessor.GetByIdAsync(request.ProfessorId, cancellationToken);
    if (professor == null)
    {
      ThrowError("No se encontró profesor");
    }

    var subject = await _repositorySubject.GetByIdAsync(request.SubjectId, cancellationToken);
    if (subject == null)
    {
      ThrowError("No se encontró estudiante");
    }
    try
    {
      var list = await _repositorySelectedSubject.ListAsync(cancellationToken);
      var studentList = list.Where(e => e.StudentId == request.StudentId);
      if (studentList.Count() > 0)
      {
        if (studentList.FirstOrDefault(e => e.ProfessorId == request.ProfessorId) != null)
          ThrowError($"No puede volver a registrarse con {professor.Name}");
        if (studentList.FirstOrDefault(e => e.SubjectId == request.SubjectId) != null)
          ThrowError($"No puede registrar otra vez la materia {professor.Name}");

        student.SelectSubject(request.SubjectId, request.ProfessorId);
        await _repositoryStudent.SaveChangesAsync(cancellationToken);
        var response = new RegisterSubjectResponse(student);
        await SendAsync(response, cancellation: cancellationToken);
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      ThrowError(ex.Message);
    }

  }
}
