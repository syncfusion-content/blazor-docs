public enum Countries
{
    Australia,
    Bermuda,
    Canada
}

public class EditorTypes
{
    [Required(ErrorMessage = "Please enter a value for NumericTextBoxField")]
    public int? NumericTextBoxField { get; set; }

    [Required(ErrorMessage = "Please enter a value for TextBoxField")]
    public string TextBoxField { get; set; }

    [Required(ErrorMessage = "Please enter a value for TextBoxField")]
    public string DisabledTextBoxField { get; set; }

    [Required(ErrorMessage = "Please enter a value for TextAreaField")]
    public string TextAreaField { get; set; }

    [Required(ErrorMessage = "Please select a value for DropDownListField")]
    public Countries DropDownListField { get; set; }

    [Required(ErrorMessage = "Please enter a value for AutoCompleteField")]
    public Countries AutoCompleteField { get; set; }

    [Required(ErrorMessage = "Please select a value for ComboBoxField")]
    public Countries ComboBoxField { get; set; }

    [Required(ErrorMessage = "Please enter a value for PasswordField")]
    public string PasswordField { get; set; }

    [Required(ErrorMessage = "Please select a date for DateTimePickerField")]
    public DateTime? DateTimePickerField { get; set; }

    [Required(ErrorMessage = "Please select a date for DatePickerField")]
    public DateTime? DatePickerField { get; set; }

    [Required(ErrorMessage = "Please select a time for TimePickerField")]
    public DateTime? TimePickerField { get; set; }

    [Required(ErrorMessage = "Please check the CheckBoxField")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "CheckBoxField must be checked")]
    public bool CheckBoxField { get; set; }

    [Required(ErrorMessage = "Please toggle the SwitchField")]
    [Range(typeof(bool), "true", "true", ErrorMessage = "SwitchField must be toggled")]
    public bool SwitchField { get; set; }
}