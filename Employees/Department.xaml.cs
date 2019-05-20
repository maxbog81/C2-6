using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Employees
{
    /// <summary>
    /// Логика взаимодействия для Department.xaml
    /// </summary>
    public partial class Department : Page, INotifyPropertyChanged
    {
        public Department()
        {
            InitializeComponent();
            AddElement();
            DeptView.ItemsSource = ListDept;
            DepartCombo.ItemsSource = ListDept;

        }

        public Department(string dept)
        {
            Dept = dept;
        }

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

        /// <summary>
        /// Добавление подразделения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeptbtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string dept = DepartCombo.Text;
            ListDept.Add(new Department(dept));
        }
        /// <summary>
        /// Удаление подразделения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeptbtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (DeptView.SelectedItem != null)
                ListDept.Remove(DeptView.SelectedItem as Department);

        }

        /// <summary>
        /// Изменение подразделения
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeptbtnChg_Click(object sender, RoutedEventArgs e)
        {
            string dept = DepartCombo.Text;

            if (DeptView.SelectedItem != null && dept != null)
            {
                (DeptView.SelectedItem as Department).Dept = dept;
            }

        }
    }
}
