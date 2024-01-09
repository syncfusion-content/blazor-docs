public enum Country
{
    UnitedStates,
    Bermuda,
    Australia,
    Finland,
    France,
    Denmark,
    Cameroon,
    Canada
}

public class EmployeeDetails
{
    [Editable(false)]
    [Display(Name = "Please enter the employee ID")]
    public int EmployeeId { get; set; }
    [Required(ErrorMessage = "Please enter the first name.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Please enter the last name.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Please enter the department.")]
    [Display(Name = "Department")]
    public string Department { get; set; }
    [Editable(false)]
    public string ReportingPerson { get; set; }
    [Editable(false)]
    public string ManagerName { get; set; }
    [Editable(false)]
    public string Designation { get; set; }
    [Required(ErrorMessage = "Please enter the date of birth.")]
    [Display(Name = "Date Of Birth")]
    public DateTime? DateOfBirth { get; set; }
    [Required(ErrorMessage = "Please enter your personal mail address.")]
    public string PersonalMailId { get; set; }
    [Required(ErrorMessage = "Please enter your address line.")]
    public string AddressLine { get; set; }
    [Required(ErrorMessage = "Please enter your blood group.")]
    public string BloodGroup { get; set; }
    [Required(ErrorMessage = "Please choose the country.")]
    public Country Country { get; set; }
}