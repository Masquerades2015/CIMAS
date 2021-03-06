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
    
    public partial class DictSemester
    {
        public DictSemester()
        {
            this.DepartmentIfoes = new HashSet<DepartmentIfo>();
            this.OptionalCourseIfoes = new HashSet<OptionalCourseIfo>();
            this.RequiredCourseIfoes = new HashSet<RequiredCourseIfo>();
            this.StuGradeIfoes = new HashSet<StuGradeIfo>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> StartDay { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
    
        public virtual ICollection<DepartmentIfo> DepartmentIfoes { get; set; }
        public virtual ICollection<OptionalCourseIfo> OptionalCourseIfoes { get; set; }
        public virtual ICollection<RequiredCourseIfo> RequiredCourseIfoes { get; set; }
        public virtual ICollection<StuGradeIfo> StuGradeIfoes { get; set; }
    }
}
