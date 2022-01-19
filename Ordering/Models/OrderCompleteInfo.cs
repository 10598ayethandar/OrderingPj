namespace Ordering.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderCompleteInfo")]
    public partial class OrderCompleteInfo
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Order_No { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string Customer_Name { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string Food_name { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(200)]
        public string Food_ImagePath { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Price { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "date")]
        public DateTime Order_Date { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(20)]
        public string Pay_Method { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(100)]
        public string PayS_Status { get; set; }
    }
}
