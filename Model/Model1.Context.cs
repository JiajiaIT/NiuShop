//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class nd20002Entities : DbContext
    {
        public nd20002Entities()
            : base("name=nd20002Entities")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductProperty> ProductProperty { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<ShopCart> ShopCart { get; set; }
        public virtual DbSet<ProductBoard> ProductBoard { get; set; }
        public virtual DbSet<Tokens> Tokens { get; set; }
    }
}
