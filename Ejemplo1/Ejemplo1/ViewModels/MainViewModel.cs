﻿using Ejemplo1.Repositories;
using System.Threading.Tasks;
using System.Windows.Input;
using Ejemplo1.Views;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Ejemplo1;
using Ejemplo1.Models;
using System;
using Ejemplo1.ViewModels;

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
        if (!ShowAll)
        {
            items = items.Where(x => x.Completed == false).ToList();
        }
        var itemViewModels = items.Select(i =>
        CreateTodoItemViewModel(i));
        Items = new ObservableCollection<TodoItemViewModel>
        (itemViewModels);
    }

    public string FilterText => ShowAll ? "All" : "Active";
    public ICommand ToggleFilter => new Command(async () =>
    {
        ShowAll = !ShowAll;
        await LoadData();
    });

    private TodoItemViewModel CreateTodoItemViewModel(TodoItem item)
    {
        var itemViewModel = new TodoItemViewModel(item);
        itemViewModel.ItemStatusChanged += ItemStatusChanged;
        return itemViewModel;
    }

    private void ItemStatusChanged(object sender, EventArgs e)
    {
        if (sender is TodoItemViewModel item)
        {
            if (!ShowAll && item.Item.Completed)
            {
                Items.Remove(item);
            }
            Task.Run(async () => await
            repository.UpdateItem(item.Item));
        }
    }

    public bool ShowAll { get; set; }


    public ICommand AddItem => new Command(async () =>
    {
        var itemView = Resolver.Resolve<ItemView>();
        await Navigation.PushAsync(itemView);
    });

    public ObservableCollection<TodoItemViewModel> Items { get; private set; }

    public TodoItemViewModel SelectedItem
    {
        get { return null; }
        set 
        {
            Device.BeginInvokeOnMainThread(async () => await NavigateToItem(value));
            RaisePropertyChanged(nameof(SelectedItem));
        }
    }

    private async Task NavigateToItem(TodoItemViewModel item)
    {
        if (item == null)
        {
            return;
        }
        var itemView = Resolver.Resolve<ItemView>();
        var vm = itemView.BindingContext as ItemViewModel;
        vm.Item = item.Item;
        await Navigation.PushAsync(itemView);
    }



}
