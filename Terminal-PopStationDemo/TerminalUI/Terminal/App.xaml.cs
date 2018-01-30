using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Terminal.ViewModel;

namespace Terminal
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindowViewModel vm = new MainWindowViewModel();
            MainWindow view = new MainWindow(vm);
            view.DataContext = vm;
            view.Show();
        }
    }
}
