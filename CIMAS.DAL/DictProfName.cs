//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace CIMAS.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DictProfName
    {
        public DictProfName()
        {
            this.DictProfClasses = new HashSet<DictProfClass>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<DictProfClass> DictProfClasses { get; set; }
    }
}