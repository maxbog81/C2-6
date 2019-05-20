using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    class Employee : INotifyPropertyChanged
    {
        Random r = new Random();
        public ObservableCollection<Employee> ListEmp = new ObservableCollection<Employee>();
        private string name;
        private string dept;
        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public string Dept
        {
            get { return this.dept; }
            set
            {
                if (this.dept != value)
                {
                    this.dept = value;
                    this.NotifyPropertyChanged("Dept");
                }
            }
        }
        public Employee(string name,string dept)
        {
            Name = name;
            Dept = dept;
        }

        public Employee()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// Создание списка сотрудников
        /// </summary>
        public void AddElement()
        {
            for (int i = 0; i < 10; i++)
            {
                ListEmp.Add(new Employee($"Имя_{i}", $"Подразд_{r.Next(100, 103)}"));
            }
        }

        //public override string ToString()
        //{
        //    return Name+" - " +Dept;
        //}
    }
}
