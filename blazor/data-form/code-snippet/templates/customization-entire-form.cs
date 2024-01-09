 public class ProductDetails
    {
        public string Category { get; set; }
        [Required(ErrorMessage = "Please enter the brand.")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Please enter the color.")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Please enter the size.")]
        public string Size { get; set; }
        [Required(ErrorMessage = "Please enter the shipping address.")]
        public string ShippingAddress { get; set; }
        public string BillingAddress { get; set; }
        public string DeliveryInstructions { get; set; }
        [Required(ErrorMessage = "Please enter your contact number.")]
        public string ContactNumber { get; set; }
    }