public class EventRegistration
{
    [Required(ErrorMessage = "Please enter your name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your email address.")]
    public string Email { get; set; }
}