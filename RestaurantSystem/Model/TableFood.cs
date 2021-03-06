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
    
    public partial class TableFood : BaseViewModel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TableFood()
        {
            this.Bill = new HashSet<Bill>();
        }
    
        public int Id { get; set; }

		private string _Name;
		public string Name { get => _Name; set { _Name = value; OnPropertyChanged(); } }

		private Nullable<int> _IdRegion;
		public Nullable<int> IdRegion { get => _IdRegion; set { _IdRegion = value; OnPropertyChanged(); } }

		private string _Status;
		public string Status { get => _Status; set { _Status = value; OnPropertyChanged(); } }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bill> Bill { get; set; }

		private Region _Region;
		public virtual Region Region { get => _Region; set { _Region = value; OnPropertyChanged(); } }
    }
}
