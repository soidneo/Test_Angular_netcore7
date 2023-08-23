using Interrapidisimo_test.Core.TestAggregate;
using Interrapidisimo_test.Core.TestAggregate.Specifications;
using Interrapidisimo_test.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Interrapidisimo_test.Web.Pages.ProjectDetails;
public class IncompleteModel : PageModel
{
  private readonly IRepository<Student> _repository;

  [BindProperty(SupportsGet = true)]
  public Guid ProjectId { get; set; }

  public IncompleteModel(IRepository<Student> repository)
  {
    _repository = repository;
  }

  public async Task OnGetAsync()
  {
    var projectSpec = new StudentByIdSpec(ProjectId);
    var project = await _repository.FirstOrDefaultAsync(projectSpec);
    if (project == null)
    {
      return;
    }

  }
}
