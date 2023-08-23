namespace Interrapidisimo_test.Web.ViewModels;
public class ToDoItemViewModel
{
  public Guid Id { get; set; }
  public string? Title { get; set; }
  public string? Description { get; set; }
  public bool IsDone { get; private set; }
}
