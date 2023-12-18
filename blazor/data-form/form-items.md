 ---
layout: post
title: Form Items in Blazor DataForm Component | Syncfusion
description: Checkout and learn about Form items in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# FormItem

The [FormItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html)  can be utilized to set up various configuration for the editor component, including the unique identifier (id), the type of editor component used, any additional CSS classes to be applied to the editor, and whether the field is to be active (enabled) or inactive (disabled) upon being rendered.The below example showcases the different property usages.

{% tabs %}
{% highlight razor tabtitle="FormItem" hl_lines="3 10" %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations
@using Microsoft.AspNetCore.Components.Forms
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Calendars;
@using Syncfusion.Blazor.Popups

<SfDataForm ID="MyForm"
            Model="@EditorTypeModel"
            Width="50%"
            AutoComplete="on">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormItem Field="@nameof(EditorTypeModel.TextBoxField)" ID="textbox" Placeholder="Enter the value" LabelText="TextBox Editor" ></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.DisabledTextBoxField)" ID="diabled" IsEnabled="false" Placeholder="Enter the value" LabelText="TextBox Editor"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.TextAreaField)" CssClass="e-warning" LabelText="TextArea Editor" Placeholder="Enter the value" EditorType="FormEditorType.TextArea"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.DropDownListField)" LabelText="DropDownList Editor" CssClass="e-warning" Placeholder="Select the value" EditorType="FormEditorType.DropDownList"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.AutoCompleteField)" LabelText="AutoComplete Editor" Placeholder="Select the value" EditorType="FormEditorType.AutoComplete"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.ComboBoxField)" LabelText="ComboBox Editor" Placeholder="Select the value" EditorType="FormEditorType.ComboBox"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.PasswordField)" LabelText="Password Editor" Placeholder="Enter the value" EditorType="FormEditorType.Password"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.DateTimePickerField)" LabelText="DateTimePicker Editor" Placeholder="Enter the value" EditorType="FormEditorType.DateTimePicker"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.DatePickerField)" LabelText="DatePicker Editor" Placeholder="Enter the value" EditorType="FormEditorType.DatePicker"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.TimePickerField)" LabelText="TimePicker Editor" Placeholder="Enter the value" EditorType="FormEditorType.TimePicker"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.CheckBoxField)" LabelText="Checkbox Editor" ></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.SwitchField)" LabelText="Switch Editor" EditorType="FormEditorType.Switch"></FormItem>
    </FormItems>

    <FormButtons>
        <SfButton>Submit</SfButton>
    </FormButtons>

</SfDataForm>


@code {

    public enum Countries
    {
        Autralia,
        Bermuda,
        Canada
    }

    public class EditorTypes
    {
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

    private EditorTypes EditorTypeModel = new EditorTypes();
}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_formitem.png)
