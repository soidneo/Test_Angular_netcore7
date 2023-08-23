using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.Infrastructure.Data;

namespace Interrapidisimo_test.Web.Seeders;
public class SelectedSubjectSeeder
{
  public static void Seed(AppDbContext dbContext)
  {
    if (!dbContext.MateriasSeleccionadas.Any())
    {
      // Obtén todos los estudiantes, materias y profesores de la base de datos
      var students = dbContext.Estudiantes.ToList();
      var subjects = dbContext.Materias.ToList();
      var professors = dbContext.Profesores.ToList();

      var random = new Random();

      foreach (var student in students)
      {
        // Crea una lista de materias y profesores disponibles
        var availableSubjects = new List<Subject>(subjects);
        var availableProfessors = new List<Professor>(professors);

        for (int i = 0; i < 3; i++) // El estudiante selecciona 3 materias
        {
          if (availableSubjects.Count == 0 || availableProfessors.Count == 0)
          {
            break; // No hay más materias o profesores disponibles
          }
          var randomSubjectIndex = random.Next(availableSubjects.Count);
          var selectedSubject = availableSubjects[randomSubjectIndex];
          availableSubjects.RemoveAt(randomSubjectIndex);

          var randomProfessorIndex = random.Next(availableProfessors.Count);
          var selectedProfessor = availableProfessors[randomProfessorIndex];
          availableProfessors.RemoveAt(randomProfessorIndex);

          //dbContext.MateriasSeleccionadas.Add(new SelectedSubject(student.Id, selectedSubject.Id, selectedProfessor.Id));
          student.SelectSubject(selectedSubject.Id, selectedProfessor.Id);
          dbContext.SaveChanges();
          //dbContext.MateriasSeleccionadas.Add(new SelectedSubject(student.Id, selectedSubject.Id, selectedProfessor.Id));
        }
      }

      dbContext.SaveChanges();
    }
  }
}
