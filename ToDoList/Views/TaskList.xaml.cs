using System.ComponentModel;
using System.Diagnostics;
using ToDoList.Maui.Models;
using ToDoList.Maui.Repositories;
using Newtonsoft.Json;
using Microsoft.Maui.Controls;
namespace ToDoList.Maui.Views;
partial class TaskList : ContentPage,INotifyPropertyChanged
{
    private ToDo toDo;
    
    List<Chore> toDoTasks;
   public Guid Id{ get; set; }
   public string Name { get; set; }="Default";
    public List<Chore> ToDoTasks
    {
        get
        {
            return toDoTasks;
        }
    }
     public string ToDoTasksJson
    {
        set
        {
            // Deserialize JSON string to Dictionary using Newtonsoft.Json
            if (!string.IsNullOrEmpty(value))
            {
                try
                {
                    toDoTasks = JsonConvert.DeserializeObject<List<Chore>>(Uri.UnescapeDataString(value));
                    // Bind to your ListView or UI elements
                    Tasks.ItemsSource = toDoTasks;
                }
                catch (JsonException)
                {
                    // Handle JSON parse errors
                    Debug.WriteLine("Failed to deserialize Tasks");
                }
            }
        }
    }
    public TaskList()
    {
         InitializeComponent();
        BindingContext = this;
        Tasks.ItemsSource = ToDoTasks;
    }
    public TaskList(Guid id,string name,List<Chore> tasks)
    {
        InitializeComponent();
          // Assigning the passed parameters to the respective fields
        Id = id;
        Name = name;
        toDoTasks = tasks;
        BindingContext = this;
        Tasks.ItemsSource = ToDoTasks;
        
    }
    private void Task_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if(Tasks is not null && Tasks.SelectedItem is not null)
        {
            
        }
    }
    private void Task_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Tasks.SelectedItem=null;
    }

    private void AddTaskBtn_Clicked(object sender, EventArgs e)
    {
    }
    protected override bool OnBackButtonPressed()
    {
        // Perform any custom behavior here if necessary

        // Navigate back to the previous page in the navigation stack
        Navigation.PopAsync();

        // Return 'true' to indicate that we've handled the back button press
        return true;
    }


}