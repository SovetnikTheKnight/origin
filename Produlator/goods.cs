//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Produlator
{
    using System;
    using System.Collections.Generic;
    
    public partial class goods
    {
        public int goods_id { get; set; }
        public string descr { get; set; }
        public Nullable<int> product_id { get; set; }
        public Nullable<int> shelf_id { get; set; }
        public Nullable<int> product_date_id { get; set; }
    
        public virtual product_date product_date { get; set; }
        public virtual product product { get; set; }
        public virtual shelf shelf { get; set; }
    }
}
