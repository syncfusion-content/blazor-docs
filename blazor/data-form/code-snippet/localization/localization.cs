 public class RegistrationDetails
    {

        [Display(ResourceType = typeof(SfResources), Name = "DataForm_FirstName")]
        [Required(ErrorMessageResourceName = "DataForm_FirstName_Error", ErrorMessageResourceType = typeof(SfResources))]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(SfResources), Name = "DataForm_LastName")]
        [Required(ErrorMessageResourceName = "DataForm_LastName_Error", ErrorMessageResourceType = typeof(SfResources))]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(SfResources), Name = "DataForm_Email")]
        [Required(ErrorMessageResourceName = "DataForm_Email_Required_Error", ErrorMessageResourceType = typeof(SfResources))]
        [EmailAddress(ErrorMessageResourceName = "DataForm_Invalid_Email_Error", ErrorMessageResourceType = typeof(SfResources))]
        public string Email { get; set; }
    }
