namespace Ordering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Status
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order_Status()
        {
            OrderWiths = new HashSet<OrderWith>();
        }

        [Key]
        public int OS_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string OS_Status { get; set; }

        [Required]
        [StringLength(500)]
        public string OS_Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderWith> OrderWiths { get; set; }
    }
}
