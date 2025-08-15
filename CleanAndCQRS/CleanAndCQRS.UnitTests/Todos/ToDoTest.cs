using CleanAndCQRS.Domain.Domains.Todos;
using CleanAndCQRS.Domain.Exceptions;
using FluentAssertions;

namespace CleanAndCQRS.Domain.UnitTests.Todos;

public class ToDoTest
{
    [Fact]
    public void Create_ToDo_Should_SetPropertyValues()
    {
        var todo = ToDoList.CreateInstance(ToDoListData.ToDoListTitle);

        todo.Title.Should().Be(ToDoListData.ToDoListTitle);
        todo.Tasks.Should().HaveCount(0);
    }

    [Fact]
    public void Create_ToDo_Should_With_Empty_Title_Throw_TodoListTitleNullException()
    {
     
        Action act = () => ToDoList.CreateInstance(ToDoListData.ToDoListEmptyTitle);

        act.Should().Throw<TodoListTitleNullException>()
                             .WithMessage("Todo list's title cann't be null or empty");

    }

    [Fact]
    public void Create_ToDo_Should_UpdateTitle()
    {
        var todo = ToDoList.CreateInstance(ToDoListData.ToDoListTitle);
        todo.UpdateTitle(ToDoListData.ToDoListUpdatedTitle);
        todo.Title.Should().Be(ToDoListData.ToDoListUpdatedTitle);
 
    }


    [Fact]
    public void Create_ToDo_Task_Should_UpdateTitle()
    {
        var task = ToDoTask.CreateInstance(TaskData.TaskTitle,TaskData.TaskDescription);
 
        task.Title.Should().Be(TaskData.TaskTitle);
        task.Description.Should().Be(TaskData.TaskDescription);
        task.TaskState.Should().Be(TaskData.TaskState);

    }


    [Fact]
    public void Add_Task_To_ToDo_Should_HaveCount_1()
    {
        var todo = ToDoList.CreateInstance(ToDoListData.ToDoListTitle);
        var task = ToDoTask.CreateInstance(TaskData.TaskTitle, TaskData.TaskDescription);

        todo.AddTask(task);

        todo.Tasks.Should().HaveCount(1);
    }


    [Fact]
    public void Add_Duplicate_Task_To_ToDo_Should_Throw_TodoTaskTitleDuplicateException()
    {
        var todo = ToDoList.CreateInstance(ToDoListData.ToDoListTitle);
        var task = ToDoTask.CreateInstance(TaskData.TaskTitle, TaskData.TaskDescription);

        todo.AddTask(task);
        todo.Tasks.Should().HaveCount(1);
        Action act = () => todo.AddTask(task);

        act.Should().Throw<TodoTaskTitleDuplicateException>()
                             .WithMessage("Task title is duplicate");
         
    }




}


