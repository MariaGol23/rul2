using rul2.Model;
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

namespace rul2.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuth.xaml
    /// </summary>
    public partial class PageAuth : Page
    {
        Model.Model1 Model1 = new Model.Model1();
        public PageAuth()
        {
            InitializeComponent();



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = TbLogin.Text.Trim();
            string password = TbPass.Text.Trim();

            User user = Model1.User.Where(p => p.UserLogin == login && p.UserPassword == password).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show("Вы вошли под: " + user.Role.RoleName.ToString());
                LoadPage(user.Role.RoleName, user);
            } else
            {
                MessageBox.Show("Неверный логин или пароль!");

            }




        }

        void LoadPage(string role, User user)
        {
            switch (role)
            {
                case "Клиент":
                    NavigationService.Navigate(new PageProduct(user));
                    break;
                case "Менеджер":
                    NavigationService.Navigate(new PageProduct(user));
                    break;
                case "Администратор":
                    NavigationService.Navigate(new PageProduct(user));
                    break;
            }
        }
    }
}
