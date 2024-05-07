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
        public ItemViewModel(TodoItemRepository repository)
        {
            this.repository = repository;
        }
    }
}