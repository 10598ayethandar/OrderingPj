namespace Ordering
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Food")]
    public partial class Food
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Food()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        public int Food_id { get; set; }

        [Required]
        [StringLength(50)]
        public string Food_name { get; set; }

        public int Food_CateId { get; set; }

        [Required]
        [StringLength(200)]
        public string Food_ImagePath { get; set; }

        public int Price { get; set; }

        public int Quantity { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
