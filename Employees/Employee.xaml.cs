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
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Page, INotifyPropertyChanged
    {
        Department Depart = new Department();
        public Employee()
        {
            InitializeComponent();
            DataContext = this;
            ListEmp = new ObservableCollection<Employee>();
            AddElement();
            //EmpView.ItemsSource = ListEmp;           
            //EmpCombo.ItemsSource = ListEmp;
            DeptCombo.ItemsSource = Depart.ListDept;
            DeptComboFiltr.ItemsSource = Depart.ListDept;
        }

        public Employee(string empname, string dept)
        {
            EmpName = empname;
            Dept = dept;
        }

        Random r = new Random();
        public ObservableCollection<Employee> ListEmp { get; set; }
        //public ObservableCollection<Employee> ListEmp = new ObservableCollection<Employee>();
        private string empname;
        public string EmpName
        {
            get { return this.empname; }
            set
            {
                if (this.empname != value)
                {
                    this.empname = value;
                    this.NotifyPropertyChanged("EmpName");
                }
            }
        }
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
            for (int i = 0; i < 1000; i++)
            {
                ListEmp.Add(new Employee($"Имя_{i + 1}", $"Подразделение_{r.Next(1, Depart.DeptCount)}"));
            }
        }

        /// <summary>
        /// Добавление сотрудника. Чтобы добавить надо ввести вручную сотрудника в первое поле и выбрать подразделение во 2м поле.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpbtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string emp = EmpCombo.Text;
            string dept = DeptCombo.Text;
            ListEmp.Add(new Employee(emp, dept));
        }

        /// <summary>
        /// Удаление выбранного в списке сотрудника.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void EmpbtnDel_Click(object sender, RoutedEventArgs e)
        {
            if (EmpView.SelectedItem != null)
                ListEmp.Remove(EmpView.SelectedItem as Employee);

        }

        /// <summary>
        /// Изменение выбранной строки сотрудника по введеным данным в поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpbtnChg_Click(object sender, RoutedEventArgs e)
        {
            string emp = EmpCombo.Text;
            string dept = DeptCombo.Text;

            if (EmpView.SelectedItem != null && (emp != null || dept != null))
            {
                (EmpView.SelectedItem as Employee).EmpName = emp;
                (EmpView.SelectedItem as Employee).Dept = dept;
            }

        }

        private void DeptViewBut_Click(object sender, RoutedEventArgs e)
        {
            Department DepartmentPage = new Department();
            this.NavigationService.Navigate(DepartmentPage);
        }

        private void DeptComboFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeptComboFiltr.SelectedIndex > -1)
                EmpView.ItemsSource = ListEmp.Where(w => w.Dept == (DeptComboFiltr.SelectedValue as Department)?.Dept);
            else
                EmpView.ItemsSource = ListEmp;
        }
    }
}
