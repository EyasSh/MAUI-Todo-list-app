using System.ComponentModel;
using Newtonsoft.Json;
using ToDoList.Maui.Models;
using ToDoList.Maui.Repositories;
namespace ToDoList.Maui.Views;

public partial class ListTitles : ContentPage, INotifyPropertyChanged
{
    private List<ToDo> listOfToDo;

    public ListTitles()
    {
        InitializeComponent();
        //Binds the class Context to XAML file
        BindingContext = this;
       
        listOfToDo=ToDoRepository.GetAllToDoLists();
        ToDoList.ItemsSource = listOfToDo;
        
        
    }

    private void ToDoList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //Logic before the item is deselected
        //TODO: Include Navigation to the actual todo list and populate it with the tasks and name
        /*
        *Important to check for nullability in case of tapping Reasons
        *1. ItemSelected is triggered when a change happens in the list.
        *2. Since the item tapped nullifies the selected item when a value is selected for a long time
        * it will call this method again. causing an unexpected ping pong behavior
        */
        if(ToDoList is not null &&ToDoList.SelectedItem != null )
        {
           string nameOfToDoList = (ToDoList.SelectedItem as ToDo)?.ListName ?? "Error with the To Do list's name";
           
            
        }
        

       
    }
    /// <summary>
    /// Tapped Event That navigates to the TaskList page of a Certain ToDo
    /// </summary>
    /// <param name="sender"> The Item in the List that sends the request</param>
    /// <param name="e"> The ItemTappedEventArgs</param>
    private async void ToDoList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
       
        // Serialize the dictionary to a JSON string using your converter
        var TaskPage= new TaskList(((ToDo)ToDoList.SelectedItem).Id,((ToDo)ToDoList.SelectedItem).ListName,((ToDo)ToDoList.SelectedItem).Tasks);
       
       
        ToDoList.SelectedItem=null;
        // Disable further taps until navigation completes
        ToDoList.IsEnabled = false;
        await Navigation.PushAsync(TaskPage);
        ToDoList.IsEnabled = true;
    }
}


