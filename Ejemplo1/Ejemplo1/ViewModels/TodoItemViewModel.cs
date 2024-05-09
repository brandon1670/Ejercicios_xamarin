using Ejemplo1.Models;
using System.Windows.Input;
using Xamarin.Forms;
using System;

public class TodoItemViewModel : ViewModel
{
    public TodoItemViewModel(TodoItem item) => Item = item;
    public event EventHandler ItemStatusChanged;
    public TodoItem Item { get; private set; }
    public string StatusText => Item.Completed ? "Reactivate" :
    "Completed";

    public ICommand ToggleCompleted => new Command((arg) =>
    {
        Item.Completed = !Item.Completed;
        ItemStatusChanged?.Invoke(this, new EventArgs());
    });
}