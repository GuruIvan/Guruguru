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
using MahApps.Metro.Controls;
using WPF_Prepare.ViewModels;

namespace WPF_Prepare
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //DataContext = new ViewModel1();
        }

        public void Add_Click(object sender, RoutedEventArgs e)
        {
           ((ViewModel1)DataContext).OpenFile();
        }
        public void Delete_Click(object sender, RoutedEventArgs e)
        {
            //((ViewModel1)DataContext).DeleteCar();
        }

        private void btn_next_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
