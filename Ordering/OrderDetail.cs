namespace Ordering
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        public int OD_Id { get; set; }

        public int Order_Id { get; set; }

        public int Food_Id { get; set; }

        public int Quantity { get; set; }

        public virtual Food Food { get; set; }

        public virtual OrderWith OrderWith { get; set; }
    }
}
