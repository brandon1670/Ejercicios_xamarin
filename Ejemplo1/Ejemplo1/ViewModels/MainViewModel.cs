using Ejemplo1.Repositories;
using System.Threading.Tasks;
using System.Windows.Input;
using Ejemplo1.Views;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Ejemplo1;
using Ejemplo1.Models;
using System;

public class MainViewModel : ViewModel
{
    private readonly TodoItemRepository repository;
    public MainViewModel(TodoItemRepository repository)
    {
        repository.OnItemAdded += (sender, item) =>
        Items.Add(CreateTodoItemViewModel(item));
        repository.OnItemUpdated += (sender, item) =>
        Task.Run(async () => await LoadData());

        this.repository = repository;
        Task.Run(() => LoadData());
    }
    private async Task LoadData()
    {
        var items = await repository.GetItems();
        var itemViewModels = items.Select(i =>
        CreateTodoItemViewModel(i));
        Items = new ObservableCollection<TodoItemViewModel>
        (itemViewModels);
    }

    private TodoItemViewModel CreateTodoItemViewModel(TodoItem item)
    {
        var itemViewModel = new TodoItemViewModel(item);
        itemViewModel.ItemStatusChanged += ItemStatusChanged;
        return itemViewModel;
    }

    private void ItemStatusChanged(object sender, EventArgs e)
    {
    }

    public ICommand AddItem => new Command(async () =>
    {
        var itemView = Resolver.Resolve<ItemView>();
        await Navigation.PushAsync(itemView);
    });

    public ObservableCollection<TodoItemViewModel> Items { get; private set; }
}
