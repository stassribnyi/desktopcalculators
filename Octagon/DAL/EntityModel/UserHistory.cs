//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EntityModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserHistory
    {
        public int History_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public string Expression { get; set; }
    
        public virtual UserMemory UserMemory { get; set; }
    }
}