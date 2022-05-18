using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace DemoCenter.Maui.DemoModules.CollectionView.Data {
    public class EmployeeTasksRepository {
        public IList<EmployeeTask> EmployeeTasks { get; private set; }

        public EmployeeTasksRepository() {
            IList<EmployeeTask> tasks = LoadTasks();
            UpdateSource(tasks);
            EmployeeTasks = tasks;
        }

        IList<EmployeeTask> LoadTasks() {
            System.Reflection.Assembly assembly = GetType().Assembly;
            Stream stream = assembly.GetManifestResourceStream("EmployeeTasks.json");
            JObject jObject = JObject.Parse(new StreamReader(stream).ReadToEnd());
            List<EmployeeTask> list = jObject["EmployeeTasks"].ToObject<List<EmployeeTask>>().Take(30).ToList();
            return new BindingList<EmployeeTask>(list);
        }

        void UpdateSource(IList<EmployeeTask> tasks) {
            Random random = new Random();
            for (int i = 0; i < tasks.Count; i++) {
                EmployeeTask task = tasks[i];
                task.StartDate = DateTime.Now.AddDays(random.Next(7) + 1);
                task.DueDate = task.StartDate.AddDays(random.Next(3) + 1);
                task.Status = (TaskStatus) (i < 2 ? 0 : i < tasks.Count * 2 / 3 ? 1 : 2);
            }
        }
    }
}
