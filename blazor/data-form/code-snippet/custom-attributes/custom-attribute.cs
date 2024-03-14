 public class ZipCodes
 {
     public int? Code { get; set; }
     public string City { get; set; }
 }
 
 private List<ZipCodes> ZipData = new List<ZipCodes>()
 {
     new ZipCodes(){ Code=90210 , City="Beverly Hills, 90210 (California)"  },
     new ZipCodes(){ Code=94558, City="Napa Valley, 94558 (California)"  },
     new ZipCodes(){ Code=33139, City="South Beach, 33139 (Florida)"  },
     new ZipCodes(){ Code=10019, City="Manhattan, 10019 (New York)"  },
     new ZipCodes(){ Code=94043, City="Silicon Valley, 94043 (California)"  },
  };

 public class PaymentDetailsModel
 {
     [Required(ErrorMessage = "Please enter your payment amount.")]
     [Display(Name = "Payable Amount", Prompt = "Currency format")]
     [Range(1, 10000000)]
     [DataFormDisplayOptions(ColumnSpan = 6)]
     public double PaymentAmount { get; set; }

     [Required(ErrorMessage = "Please enter your name.")]
     [Display(Name = "Name on card", Prompt = "Enter the name on the card")]
     [DataFormDisplayOptions(ColumnSpan = 6)]
     public string NameOnCard { get; set; }

     [Required(ErrorMessage = "Please enter your card number.")]
     [Display(Name = "Card Number", Prompt = "Enter the card number")]
     [DataFormDisplayOptions(ColumnSpan = 6)]
     public string CardNumber { get; set; }

     [Required(ErrorMessage = "Please enter card expiry date.")]
     [Display(Name = "Expiry Date", Prompt = "MM/YY")]
     [DataFormDisplayOptions(ColumnSpan = 2)]
     public DateTime? ExpiryDate { get; set; }

     [Required(ErrorMessage = "Please enter security code.")]
     [Display(Name = "Security Code", Prompt = "e.g. 123")]
     [DataFormDisplayOptions(ColumnSpan = 2)]
     public string SecurityCode { get; set; }

     [Required(ErrorMessage = "Please enter your zip code.")]
     [Display(Name = "Zip code", Prompt = "Enter Zip code")]
     [DataFormDisplayOptions(ColumnSpan = 2)]
     public int? ZipCode { get; set; }

     [Required(ErrorMessage = "Please enter your shipping address.")]
     [Display(Name = "Shipping Address", Prompt = "Flat number , Apartment ,Suite etc.")]
     [DataFormDisplayOptions(ColumnSpan = 3)]
     [DataType(DataType.MultilineText)]
     public string ShippingAddress { get; set; }

     [Display(Name = "Billing Address", Prompt = "The billing address.")]
     [DataFormDisplayOptions(ColumnSpan = 3)]
     [DataType(DataType.MultilineText)]
     public string BillingAddress { get; set; }

     [Required(ErrorMessage = "Please agree with the terms.")]
     [Display(Name = "Accept terms and conditions", Prompt = "Please agree with the terms.")]
     [DataFormDisplayOptions(ColumnSpan = 6)]
     [Range(typeof(bool), "true", "true", ErrorMessage = "Please agree with the terms.")]
     public bool AcceptTerms { get; set; }
 }