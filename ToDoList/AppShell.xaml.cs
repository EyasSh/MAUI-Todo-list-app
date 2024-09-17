
using ToDoList.Maui.Views;

namespace ToDoList;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
		Routing.RegisterRoute(nameof(ListTitles), typeof(ListTitles));
		Routing.RegisterRoute(nameof(TaskList), typeof(TaskList));
	}
}
