public class EventRegistration
{
    [Required(ErrorMessage = "Please enter your name.")]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your email address.")]
    [Display(Name = "Email ID")]
    public string Email { get; set; }
}
