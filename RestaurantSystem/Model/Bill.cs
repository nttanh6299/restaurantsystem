//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RestaurantSystem.Model
{
	using RestaurantSystem.ViewModel;
	using System;
    using System.Collections.Generic;
    
    public partial class Bill : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bill()
        {
            this.BillInfo = new HashSet<BillInfo>();
        }

		public int Id { get; set; }

		private Nullable<System.DateTime> _TimeIn;
		public Nullable<System.DateTime> TimeIn { get => _TimeIn; set { _TimeIn = value; OnPropertyChanged(); } }

		private Nullable<System.DateTime> _TimeOut;
		public Nullable<System.DateTime> TimeOut { get => _TimeOut; set { _TimeOut = value; OnPropertyChanged(); } }

		private Nullable<double> _TotalPrice;
		public Nullable<double> TotalPrice { get => _TotalPrice; set { _TotalPrice = value; OnPropertyChanged(); } }

		private string _MoreInfo;
		public string MoreInfo { get => _MoreInfo; set { _MoreInfo = value; OnPropertyChanged(); } }

		private Nullable<int> _Status;
		public Nullable<int> Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }

		private Nullable<int> _Discount;
		public Nullable<int> Discount { get => _Discount; set { _Discount = value; OnPropertyChanged(); } }

		private Nullable<int> _IdTable;
		public Nullable<int> IdTable { get => _IdTable; set { _IdTable = value; OnPropertyChanged(); } }

		private string _IdStaff;
		public string IdStaff { get => _IdStaff; set { _IdStaff = value; OnPropertyChanged(); } }

		private TableFood _TableFood;
		public virtual TableFood TableFood { get => _TableFood; set { _TableFood = value; OnPropertyChanged(); } }

		private Staff _Staff;
		public virtual Staff Staff { get => _Staff; set { _Staff = value; OnPropertyChanged(); } }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillInfo> BillInfo { get; set; }
    }
}
