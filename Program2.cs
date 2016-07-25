using System;

namespace program2
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Person Andrzej = new Person();
			Andrzej.AddTask(new Task("zadanie1"), 0);
			Andrzej.AddTask(new Task("zadanie2"), 1);
			Andrzej.AddTask(new Task("zadanie3"), 2);

			Andrzej.AddTask(new Task("zadanie4"), 3);
			Andrzej.tasks[3].Complete();
			Andrzej.AddTask(new Task("zadanie5"), 4);
			Andrzej.tasks[4].Complete();
			Andrzej.AddTask(new Task("zadanie6"), 5);
			Andrzej.tasks[5].Complete();
			Andrzej.DisplayTasks();
			Console.ReadKey();
		}
	}
	class Person
	{
		public Task[] tasks = new Task[6];

		public void AddTask(Task task, int taskNumber)
		{
			tasks[taskNumber] = task;
		}
		public void DisplayTasks()
		{
			foreach (Task number in tasks)
			{
				if (number.IsCompleted() == true)
					Console.WriteLine(number.DisplayName());

			}
		}
	}
	class Task
	{
		string name;
		bool completed;

		public Task(string taskName)
		{
			name = taskName;
			completed = false;
		}

		public string DisplayName()
		{
			return name;
		}

		public bool IsCompleted()
		{
			return completed;
		}

		public void Complete()
		{
			completed = true;
		}
	}

}