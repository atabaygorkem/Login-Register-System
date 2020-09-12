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

namespace MvvmLoginRegister.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {

        public static readonly DependencyProperty UpdateViewCommandProperty =
    DependencyProperty.Register("UpdateViewCommand", typeof(ICommand), typeof(HomeView), new PropertyMetadata(null));

        public ICommand UpdateViewCommand
        {
            get { return (ICommand)GetValue(UpdateViewCommandProperty); }
            set { SetValue(UpdateViewCommandProperty, value); }
        }





        public HomeView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (UpdateViewCommand != null)
            {
                string password = pbPassword.Password;
                UpdateViewCommand.Execute(password);
            }
        }

    }
}
