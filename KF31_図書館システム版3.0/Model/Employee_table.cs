//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはテンプレートから生成されました。
//
//     このファイルを手動で変更すると、アプリケーションで予期しない動作が発生する可能性があります。
//     このファイルに対する手動の変更は、コードが再生成されると上書きされます。
// </auto-generated>
//------------------------------------------------------------------------------

namespace KF31_図書館システム版3._0.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee_table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee_table()
        {
            this.Lend_table = new HashSet<Lend_table>();
            this.StockIn_Detail_table = new HashSet<StockIn_Detail_table>();
            this.StockOut_Detail_table = new HashSet<StockOut_Detail_table>();
        }
    
        public string EmployID { get; set; }
        public string possitionID { get; set; }
        public string Em_userName { get; set; }
        public string Em_password { get; set; }
        public Nullable<System.DateTime> Em_Birthday { get; set; }
        public Nullable<System.DateTime> Em_Hiredate { get; set; }
        public string Em_Address { get; set; }
        public string Em_Email { get; set; }
        public string Em_DisplayName { get; set; }
        public string Em_BarCode { get; set; }
        public Nullable<System.DateTime> Em_Lastlogin { get; set; }
        public Nullable<int> Em_flag { get; set; }
    
        public virtual Possition_table Possition_table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Lend_table> Lend_table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockIn_Detail_table> StockIn_Detail_table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockOut_Detail_table> StockOut_Detail_table { get; set; }
    }
}
