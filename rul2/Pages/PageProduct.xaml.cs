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
    /// Логика взаимодействия для PageProduct.xaml
    /// </summary>
    public partial class PageProduct : Page
    {
        Model1 model1 = new Model1();
        User _user;
        public PageProduct(User user)
        {
            InitializeComponent();
            DataContext = this;
            _user = user;
            UpdateData();
        
        }

        public string[] SortingList { get; set; } =
        {
            "Без сортировки",
            "Стоимость по возрастанию",
            "Стоимость по убыванию"

        };
        public string[] FilterList { get; set; } =
        {
            "Все диапазоны",
            "0%-9,99%",
            "10%-14,99%",
            "15% и более"

        };

        void UpdateData()
        {
            var prod = model1.Product.ToList();

            var res = prod;

            if (CbSort.SelectedIndex == 0)
                res = prod;
            else if (CbSort.SelectedIndex == 1)
                res = prod.OrderBy(p => p.ProductCost).ToList();
            else if (CbSort.SelectedIndex == 2)
                res = prod.OrderByDescending(p => p.ProductCost).ToList();

            if (CbFilt.SelectedIndex == 0)
            { }
            else if (CbFilt.SelectedIndex == 1)
                res = res.Where(p => Convert.ToInt32(p.MaxDiscountAmount) >= 0 && Convert.ToInt32(p.MaxDiscountAmount) < 10).ToList();
            else if (CbFilt.SelectedIndex == 2)
                res = res.Where(p => Convert.ToInt32(p.MaxDiscountAmount) >= 10 && Convert.ToInt32(p.MaxDiscountAmount) < 15).ToList();
            else if (CbFilt.SelectedIndex == 3)
                res = res.Where(p => Convert.ToInt32(p.MaxDiscountAmount) >= 15).ToList();

            if (TbSearch.Text != null || TbSearch.Text != "" || TbSearch.Text != " ")
                res = res.Where(p => p.ProductName.ToLower().Contains(TbSearch.Text.ToLower())).ToList();

            LvProductCard.ItemsSource = res;
            LvProductList.ItemsSource = res;
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void CbFilt_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void CbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            model1.Product.Remove(LvProductList.SelectedItem as Product);
            model1.SaveChanges();
            MessageBox.Show("Запись удалена!");
            UpdateData();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Windows.AddWindow add = new Windows.AddWindow();
            add.ShowDialog();
            UpdateData();
        }
    }
}
