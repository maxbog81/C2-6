using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson6
{
    class Department : INotifyPropertyChanged
    {        
        public ObservableCollection<Department> ListDept = new ObservableCollection<Department>();
        private string dept;
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
        public Department(string dept)
        {
            Dept = dept;
        }

        public Department()
        {
        }

        public void AddElement()
        {
            ListDept.Add(new Department($"Подразд_100"));
            ListDept.Add(new Department($"Подразд_101"));
            ListDept.Add(new Department($"Подразд_102"));
            ListDept.Add(new Department($"Подразд_103"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        //public override string ToString()
        //{
        //    return Dept;
        //}
    }
}
