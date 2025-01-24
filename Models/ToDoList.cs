using System.Collections.Generic;
using System.Linq;

public class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }

    public Task(int id, string description)
    {
        Id = id;
        Description = description;
        IsCompleted = false;
    }

    public override string ToString()
    {
        return $"{(IsCompleted ? "[X]" : "[ ]")} {Id}: {Description}";
    }
}

public class ToDoList
{
    private List<Task> tasks = new List<Task>();
    private int nextId = 1;

    public List<Task> GetTasks()
    {
        return tasks;
    }

    public void AddTask(string description)
    {
        if (!string.IsNullOrWhiteSpace(description))
        {
            tasks.Add(new Task(nextId++, description));
        }
    }

    public bool RemoveTask(int id)
    {
        return tasks.RemoveAll(t => t.Id == id) > 0;
    }

    public bool MarkCompleted(int id)
    {
        Task task = tasks.FirstOrDefault(t => t.Id == id);
        if (task != null && !task.IsCompleted)
        {
            task.IsCompleted = true;
            return true;
        }
        return false;
    }
}
