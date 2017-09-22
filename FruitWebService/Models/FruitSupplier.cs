namespace FruitWebService.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FruitSupplier")]
    public partial class FruitSupplier
    {

        public FruitSupplier()
        {

        }

        public FruitSupplier(int Fruit, int Supplier)
        {
            this.Fruit = Fruit;
            this.Supplier = Supplier;
        }

        public int Fruit { get; set; }

        public int Supplier { get; set; }

        public int id { get; set; }

        public virtual Fruit Fruit1 { get; set; }

        public virtual Supplier Supplier1 { get; set; }
    }
}
