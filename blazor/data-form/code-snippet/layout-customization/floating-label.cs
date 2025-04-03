public class EventRegistration
{
    [Required(ErrorMessage = "Please enter your name.")]
    [Display(Name = "First Name")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Please enter your last name.")]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    [Display(Name = "Email ID")]
    public string Email { get; set; }
    [Required(ErrorMessage = "Please enter your phone number.")]
    [Display(Name = "Phone Number")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
    public string PhoneNumber { get; set; }
}