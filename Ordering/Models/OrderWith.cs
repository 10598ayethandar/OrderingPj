namespace Ordering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderWith")]
    public partial class OrderWith
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderWith()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int O_Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime O_Date { get; set; }

        public int Customer_Id { get; set; }

        public int OrderStatus_Id { get; set; }

        public int Payment_Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Order_Status Order_Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Payment Payment { get; set; }
    }
}
