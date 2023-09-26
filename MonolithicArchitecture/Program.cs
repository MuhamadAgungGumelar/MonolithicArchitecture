using System;
using System.Collections.Generic;

namespace TaskManagementApp
{
    public class Task // Class Task sebagai Atribut Menu Tugas yang diperlukan
    {
        public int TaskId { get; set; } // Id Tugas
        public string Title { get; set; } // Judul Tugas
        public string Description { get; set; } // Deskripsi Tugas
    }

    public class TaskManager // Class Untuk Layanan Menu Tugas
    {
        private List<Task> tasks = new List<Task>();
        private int nextTaskId = 1;

        public void AddTask(string title, string description) // Fungsi Untuk Menambahkan Tugas
        {
            tasks.Add(new Task { TaskId = nextTaskId++, Title = title, Description = description });
        }

        public void EditTask(int taskId, string title, string description) // Fungsi untuk Mengedit Tugas
        {
            var task = tasks.Find(t => t.TaskId == taskId);
            if (task != null)
            {
                task.Title = title;
                task.Description = description;
            }
        }

        public void DeleteTask(int taskId) // Fungsi untuk Menghapus Tugas
        {
            var task = tasks.Find(t => t.TaskId == taskId);
            if (task != null)
            {
                tasks.Remove(task);
            }
        }

        public List<Task> GetAllTasks() // Fungsi untuk Menampilkan Semua Tugas
        {
            return tasks;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var taskManager = new TaskManager();

            while (true)
            {   //Pembuatan Menu GUI Console supaya lebih interaktif
                Console.WriteLine("Task Management Menu:");
                Console.WriteLine("1. Tambahkan Tugas");
                Console.WriteLine("2. Edit Tugas");
                Console.WriteLine("3. Delete Tugas");
                Console.WriteLine("4. List Semua Tugas");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Masukan Judul Tugas: ");
                        var title = Console.ReadLine();
                        Console.Write("Masukan Deskripsi Tugas: ");
                        var description = Console.ReadLine();
                        taskManager.AddTask(title, description);
                        Console.WriteLine("Tugas Berhasil Ditambahkan.");
                        break;
                    case "2":
                        Console.Write("Masukan Id Tugas Untuk Edit: ");
                        if (int.TryParse(Console.ReadLine(), out int editId))
                        {
                            Console.Write("Masukan Judul Tugas: ");
                            var newTitle = Console.ReadLine();
                            Console.Write("Masukan Deskripsi Tugas: ");
                            var newDescription = Console.ReadLine();
                            taskManager.EditTask(editId, newTitle, newDescription);
                            Console.WriteLine("Tugas Berhasil Diedit.");
                        }
                        else
                        {
                            Console.WriteLine("ID Tugas Tidak Valid.");
                        }
                        break;
                    case "3":
                        Console.Write("Masukan Id Tugas Untuk Delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                        {
                            taskManager.DeleteTask(deleteId);
                            Console.WriteLine("Tugas Berhasil Didelete.");
                        }
                        else
                        {
                            Console.WriteLine("ID Tugas Tidak Valid.");
                        }
                        break;
                    case "4":
                        var tasks = taskManager.GetAllTasks();
                        Console.WriteLine("List of Tasks:");
                        foreach (var task in tasks)
                        {
                            Console.WriteLine($"Task ID: {task.TaskId}, Title: {task.Title}, Description: {task.Description}");
                        }
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}