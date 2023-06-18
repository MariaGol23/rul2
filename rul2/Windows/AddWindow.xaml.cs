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
using System.Windows.Shapes;

namespace rul2.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        Product product = new Product();
        Model1 model = new Model1();

        public AddWindow()
        {
            InitializeComponent();
           
            DataContext = product;
            cmbCategory.ItemsSource = CategoryList;
        }

        public string[] CategoryList =
        {
            "Аксессуары",
            "Автозапчасти",
            "Автосервис",
            "СЪемники подшипников",
            "Ручные инструменты",
            "Зарядные устройства"
        };

        private void btnDeleteProduct_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSaveProduct_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (product.ProductCost < 0)
                errors.AppendLine("Стоимость не может быть отрицательной!");
            if (product.MinCount < 0)
                errors.AppendLine("Минимальное количество не может быть отрицательным!");
            if (product.ProductDiscountAmount > product.MaxDiscountAmount)
                errors.AppendLine("Действующая скидка на товар не может быть больше максимальной скидки!");
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            bool checker = false;

            foreach (var item in model.Product.ToList())
                if (product.ProductArticleNumber == item.ProductArticleNumber)
                    checker = true;

            if (!checker)
                model.Product.Add(product);

            try
            {
                model.SaveChanges();
                MessageBox.Show("Информация сохранена", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
               
            }
        }
    }
}
