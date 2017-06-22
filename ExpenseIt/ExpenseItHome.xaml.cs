using System;
using System.Collections.Generic;
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

namespace ExpenseIt
{
    /// <summary>
    /// Logica di interazione per ExpenseItHome.xaml
    /// </summary>
    public partial class ExpenseItHome : Page
    {
        private ExpenseService _service;

        public ExpenseItHome()
        {
            _service = new ExpenseService();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var reportPage = new ExpenseReportPage(peopleListBox.SelectedItem as Person);
            NavigationService.Navigate(reportPage);
        }

        protected override void OnInitialized(EventArgs e)
        {
            peopleListBox.ItemsSource = _service.GetExpenses();
            base.OnInitialized(e);
        }
    }
}
