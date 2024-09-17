
using ToDoList.Maui.Models;

namespace ToDoList.Maui.Repositories;

public static class ToDoRepository
{
    public static List<ToDo> ToDoList { get; set; } = new List<ToDo>()
{
    new ToDo("Shopping", new DateTime(2021,3,7), new List<Chore>() 
    { 
        new Chore("Go to market", false), 
        new Chore("Buy milk", true) 
    }),
    new ToDo("Work", new DateTime(2021,3,7), new List<Chore>() 
    { 
        new Chore("Assign tasks", true), 
        new Chore("Go to office", false) 
    }),
    new ToDo("Study", new DateTime(2021,3,7), new List<Chore>() 
    { 
        new Chore("Review notes", true), 
        new Chore("Self test", false) 
    })
};
    public static List<ToDo> GetAllToDoLists()=>ToDoList;
    public static ToDo? GetSingleToDoList(Guid id)
    {
        return ToDoList.FirstOrDefault(x => x.Id == id);
    }
    
}