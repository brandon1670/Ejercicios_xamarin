using Ejemplo1.Models;
using Ejemplo1.Repositories;
using System;
using System.Windows.Input;
using Xamarin.Forms;
namespace Ejemplo1.ViewModels
{
    public class ItemViewModel : ViewModel
    {
        private readonly TodoItemRepository repository;

        public TodoItem Item { get; set; }


        public ItemViewModel(TodoItemRepository repository)
        {
            this.repository = repository;
            Item = new TodoItem() { Due = DateTime.Now.AddDays(1) };
        }

        public ICommand Save => new Command(async () =>
        {
            await repository.AddOrUpdate(Item);
            await Navigation.PopAsync();
        });


    }
}