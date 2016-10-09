using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace EAutoServicing.Models
{


    //AppUser
    #region AppUser
    [MetadataType(typeof(AppUserMeta))]
    public partial class AppUser
    {
        public bool RememberMe { get; set; }
    }

    public partial class AppUserMeta
    {
        [Required(ErrorMessage = "Please Enter Username")]
        [RegularExpression("^[a-zA-Z0-9]{2,10}$",ErrorMessage="Please use a proper Username")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Plese Select Valid User Role")]
        [Display(Name = "User Role")]
        public int UserRoleId { get; set; }
    }
    #endregion


    //Costumer
    #region Costumer

    [MetadataType(typeof(CostumerMeta))]
    public partial class Costumer
    {

    }
    public partial class CostumerMeta
    {
        [Required(ErrorMessage = "Please Fill the {0} field")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",ErrorMessage="Please Enter first and last name seperated by just a space")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Select Gender")]
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        public string Address { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Please Enter valid Email Adress")]
        [RegularExpression(@"^([\w\.\-_]+)?\w+@[\w-_]+(\.\w+){1,}$",ErrorMessage="Please enter valid e-mail ")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(98|97)\d{8}$",ErrorMessage="Please Enter valid Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
    #endregion
    
    //Employee
    #region Employee

    [MetadataType(typeof(EmployeeMeta))]
    public partial class Employee
    {

    }

    public partial class EmployeeMeta
    {
        [Required(ErrorMessage = "The {0} field is required")]
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$", ErrorMessage = "Please Enter first and last name seperated by just a space")]
        public string Name { get; set; }
        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        public string Address { get; set; }

        [DataType(DataType.PhoneNumber, ErrorMessage = "Please Enter Valid Phone Number")]
        [RegularExpression(@"^(98|97)\d{8}$", ErrorMessage = "Please Enter valid Phone Number")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        
     
        [Display(Name="Date of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DOB { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name="Date Joined")]
        public Nullable<System.DateTime> DateJoined { get; set; }
        [Display(Name="Employee Type")]
        public Nullable<int> EmployeeTypeId { get; set; }
        public string Photo { get; set; }
        public string Remarks { get; set; }
    }
      #endregion

    //ServiceBooking
    #region Servicebooking
    [MetadataType(typeof(ServiceBookingMeta))]
    public partial class ServiceBooking
    {
        
    }
    public partial class ServiceBookingMeta
    {
        [Display(Name="Costumer Name")]
        public int CostumerId { get; set; }
        [Display(Name = "Vehicle Number")]
        public string VehicleNumber { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Serviced Date")]
        public Nullable<System.DateTime> ServicedDate { get; set; }
        [Display(Name = "Serviced By")]
        public int ServicedBy { get; set; }
        [Display(Name = "Next Serviced Date")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> NextServiceDate { get; set; }
    }
#endregion

    //EmployeeType
    [MetadataType(typeof(Employeetypemeta))]
    public partial class Employeetype
    {

    }
    public partial class Employeetypemeta
    {

    }

}
  




 