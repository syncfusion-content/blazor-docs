public class CreditCard
{
    [Required(ErrorMessage = "Please enter the name on card")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter the card number")]
    [CreditCard]
    public string CardNumber { get; set; }

    [Required(ErrorMessage = "Please enter cvv number")]
    public string CVV { get; set; }

    [Required(ErrorMessage = "Please select/enter expiry date")]
    public DateTime? ExpiryDate { get; set; }
}