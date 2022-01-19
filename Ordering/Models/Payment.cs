namespace Ordering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Payment")]
    public partial class Payment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payment()
        {
            OrderWiths = new HashSet<OrderWith>();
        }

        [Key]
        public int Pay_Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Pay_Method { get; set; }

        public int Pay_Status { get; set; }

        public int? Pay_Bank { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderWith> OrderWiths { get; set; }

        public virtual Payment_Status Payment_Status { get; set; }
    }
}
