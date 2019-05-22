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
            DataContext = this;
            ListDept = new ObservableCollection<Department>();
            AddElement();
            //DeptView.ItemsSource = ListDept;
            //DepartCombo.ItemsSource = ListDept;

        }

        public Department(string dept)
        {
            Dept = dept;
        }
        public ObservableCollection<Department> ListDept { get; set; }
        //public ObservableCollection<Department> ListDept = new ObservableCollection<Department>();
        public int DeptCount { get; set; } = 100;
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
            for (int i = 0; i < DeptCount; i++)
            {
                ListDept.Add(new Department($"Подразделение_{i + 1}"));
            }

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

        private void DeptComboFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeptComboFiltr.SelectedIndex > -1)
                DeptView.ItemsSource = ListDept.Where(w => w.Dept == (DeptComboFiltr.SelectedValue as Department)?.Dept);
            else
                DeptView.ItemsSource = ListDept;
        }
    }
}
