namespace Ordering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            OrderWiths = new HashSet<OrderWith>();
        }

        [Key]
        public int C_Id { get; set; }

        [Required]
        [StringLength(50)]
        public string C_Name { get; set; }

        public int Phone_no { get; set; }

        
        [StringLength(50)]
        [Required(ErrorMessage = "User email is required")]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect Email format")]
        public string Email { get; set; }

        [Required]
        [StringLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(8)]
        [DataType(DataType.Password)]
        public string Confirm_Password { get; set; }

        [Required]
        [StringLength(20)]
        public string House_no { get; set; }

        [Required]
        [StringLength(30)]
        public string Street { get; set; }

        [Required]
        [StringLength(30)]
        public string Quarter { get; set; }

        [Required]
        [StringLength(30)]
        public string Township { get; set; }

        [Required]
        [StringLength(30)]
        public string Division { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderWith> OrderWiths { get; set; }
    }
}
