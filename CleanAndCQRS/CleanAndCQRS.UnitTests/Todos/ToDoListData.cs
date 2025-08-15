using CleanAndCQRS.Domain.Domains.Todos;

namespace CleanAndCQRS.Domain.UnitTests.Todos;

internal class ToDoListData {

    public static string ToDoListEmptyTitle = "";
    public static string ToDoListTitle = "Title";
    public static string ToDoListUpdatedTitle = "UpdatedTitle";

}


internal class TaskData
{
    public static string TaskTitle = "TaskTitle";
    public static string TaskDescription = "TaskDescription";
    public static TaskState TaskState = TaskState.ToDo;


}

