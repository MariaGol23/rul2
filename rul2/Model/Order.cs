namespace rul2.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            Product = new HashSet<Product>();
        }

        public int OrderID { get; set; }

        [Required]
        public string OrderStatus { get; set; }

        public DateTime OrderDeliveryDate { get; set; }

        public int OrderPickupPoint { get; set; }

        public DateTime OrderDate { get; set; }

        public string ClientFullName { get; set; }

        public int ReceiptCode { get; set; }

        public virtual PickupPoint PickupPoint { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
