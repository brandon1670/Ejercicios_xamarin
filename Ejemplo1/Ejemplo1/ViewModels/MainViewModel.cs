using Ejemplo1.Repositories;
using System.Threading.Tasks;

public class MainViewModel : ViewModel
{
    private readonly TodoItemRepository repository;
    public MainViewModel(TodoItemRepository repository)
    {
        this.repository = repository;
        Task.Run(() => LoadData());
    }
    private void LoadData()
    {

    }
}
