using System.Collections.Immutable;

namespace ToDoList.Maui.Models;
public class ToDo
{
    public Guid Id { get; init; }=Guid.NewGuid();
    public string ListName { get; set; }="Default";
    public List<Chore> Tasks { get; set; }
    public DateTime ListToDoUntil { get; set; }

    public ToDo()
    {
        Tasks = new List<Chore>();
    }

    public ToDo(string listName, DateTime listToDoUntil, List<Chore> tasks)
    {
        ListName = listName;
        ListToDoUntil = listToDoUntil;
        Tasks = tasks;
    }
}
   public class Chore
    {
        public Guid ChoreId { get; init; }=Guid.NewGuid();
        public string Duty { get; set; }="Default";
        public bool IsDone { get; set; } = false;
        

        public Chore() { }

        public Chore(string duty, bool isDone)
        {
            Duty = duty;
            IsDone = isDone;
            
        }
    }
