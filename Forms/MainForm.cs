using System;
using System.Windows.Forms;

namespace ToDoApp
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private ToDoList toDoList = new ToDoList();

        private TextBox taskTextBox;
        private Button addButton;
        private Button removeButton;
        private Button markCompletedButton;
        private ListBox taskListBox;

        public MainForm()
        {
            this.Text = "To-Do List App";
            this.Width = 400;
            this.Height = 400;

            taskTextBox = new TextBox { Left = 20, Top = 20, Width = 250 };
            addButton = new Button { Text = "Add Task", Left = 280, Top = 18 };
            removeButton = new Button { Text = "Remove Task", Left = 280, Top = 50 };
            markCompletedButton = new Button { Text = "Mark Completed", Left = 280, Top = 82 };
            taskListBox = new ListBox { Left = 20, Top = 60, Width = 250, Height = 250 };

            addButton.Click += (sender, e) => AddTask();
            removeButton.Click += (sender, e) => RemoveTask();
            markCompletedButton.Click += (sender, e) => MarkTaskCompleted();

            Controls.Add(taskTextBox);
            Controls.Add(addButton);
            Controls.Add(removeButton);
            Controls.Add(markCompletedButton);
            Controls.Add(taskListBox);

            UpdateTaskList();
        }

        private void AddTask()
        {
            if (!string.IsNullOrWhiteSpace(taskTextBox.Text))
            {
                toDoList.AddTask(taskTextBox.Text);
                taskTextBox.Clear();
                UpdateTaskList();
            }
        }

        private void RemoveTask()
        {
            if (taskListBox.SelectedItem != null)
            {
                string selectedItem = taskListBox.SelectedItem.ToString();
                int id = int.Parse(selectedItem.Split(':')[0].Replace("[ ]", "").Replace("[X]", "").Trim());
                toDoList.RemoveTask(id);
                UpdateTaskList();
            }
        }

        private void MarkTaskCompleted()
        {
            if (taskListBox.SelectedItem != null)
            {
                string selectedItem = taskListBox.SelectedItem.ToString();
                int id = int.Parse(selectedItem.Split(':')[0].Replace("[ ]", "").Replace("[X]", "").Trim());
                toDoList.MarkCompleted(id);
                UpdateTaskList();
            }
        }

        private void UpdateTaskList()
        {
            taskListBox.Items.Clear();
            foreach (var task in toDoList.GetTasks())
            {
                taskListBox.Items.Add(task.ToString());
            }
        }
    }
}

