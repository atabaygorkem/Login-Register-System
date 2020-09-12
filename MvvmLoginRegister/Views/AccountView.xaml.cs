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
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : UserControl
    {

        public static readonly DependencyProperty SaveCommandProperty =
            DependencyProperty.Register("SaveCommand", typeof(ICommand), typeof(AccountView), new PropertyMetadata(null));

        public ICommand SaveCommand
        {
            get { return (ICommand)GetValue(SaveCommandProperty); }
            set { SetValue(SaveCommandProperty, value); }
        }





        public AccountView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SaveCommand != null)
            {
                string password = pbPassword.Password;
                SaveCommand.Execute(password);
            }
        }
    }
}
