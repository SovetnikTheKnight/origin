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
    
    public partial class account
    {
        public int account_id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public Nullable<int> access_level_id { get; set; }
    
        public virtual access_level access_level { get; set; }
    }
}
