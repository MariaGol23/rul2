namespace rul2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {

        private static string path = @"C:\Users\HP\Desktop\Для подготовки к пробному ДЭ\Комплексная практическая работа\Сессия 1\Товар_import\";
        private static string pic = @"C:\Users\HP\Desktop\Для подготовки к пробному ДЭ\Комплексная практическая работа\Сессия 1\Товар_import\K830R4.jpg";


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        [StringLength(100)]
        public string ProductArticleNumber { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public string ProductDescription { get; set; }

        [Required]
        public string ProductCategory { get; set; }

        public string ProductImage { get; set; }

        [Required]
        public string ProductManufacturer { get; set; }

        public decimal ProductCost { get; set; }

        public byte? ProductDiscountAmount { get; set; }

        public int ProductQuantityInStock { get; set; }

        public string ProductStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string Unit { get; set; }

        public byte? MaxDiscountAmount { get; set; }

        [StringLength(50)]
        public string Supplier { get; set; }

        public int? CountinPack { get; set; }

        public int? MinCount { get; set; }

        public string GetImage
        {
            get
            {
                if (ProductImage == "" || ProductImage == null)
                    return pic;
                else 
                    return path + ProductImage;
            }
        }
        public string CostWithDiscount
        {
            get
            {
                if (this.MaxDiscountAmount > 0)
                {
                    var costWithDiscount = Convert.ToDouble(ProductCost) - Convert.ToDouble(this.ProductCost) * Convert.ToDouble(this.ProductDiscountAmount / 100.00);
                    return costWithDiscount.ToString();
                }
                return this.ProductCost.ToString();
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
