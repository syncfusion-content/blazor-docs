---
layout: post
title: Form Items in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to configure Form Item and its customization in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Configuring Form Item in DataForm Component

The [FormItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html)  can be utilized to set up various configuration for the editor component, including the unique identifier (id), the type of editor component used, any additional CSS classes to be applied to the editor, and whether the field is to be active (enabled) or inactive (disabled) upon being rendered.The below example showcases the different property usages.


## Configuring the model field and ID

The [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_Field) property is used to map the model field to the corresponding editor component. The [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_ID) property is used to set the unique identifier for the editor component.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm"
            Model="@EventRegistrationModel">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(EventRegistration.Name)" ID="firstname"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Email)" ID="email"></FormItem>
    </FormItems>
</SfDataForm>
   

@code {
    private EventRegistration EventRegistrationModel = new EventRegistration();
}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}
public class EventRegistration
{
    [Required(ErrorMessage = "Please enter your name.")]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your email address.")]
    [Display(Name = "Email ID")]
    public string Email { get; set; }
}
{% endhighlight %}
{% endtabs %}

## Configuring placeholder and label

The [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_Placeholder) property is used to set the placeholder text for the editor component. The [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_Label) property is used to set the label text for the editor component , At default `Name` property of the `Display` attribute will be used as label text.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm"
            Width="50%"
            Model="@EventRegistrationModel">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(EventRegistration.Name)" Placeholder="e.g. Andrew Fuller" LabelText="Name as per your ID"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Email)" Placeholder="e.g. someone@example.com" LabelText="Email address"></FormItem>
    </FormItems>
</SfDataForm>


@code {
    private EventRegistration EventRegistrationModel = new EventRegistration();
}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}
public class EventRegistration
{
    [Required(ErrorMessage = "Please enter your name.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your email address.")]
    public string Email { get; set; }
}
{% endhighlight %}
{% endtabs %}

![DataForm Placeholder](./images/blazor_dataform_placeholder.png)

## Configuring the editor type

The [EditorType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_EditorType) property is used to set the editor type for the corresponding field.We can assign the editor type using the [FormEditorType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html) enumeration.

| Field Type | Supported Editor types |
| ------------ | ----------------------- |
| `string` | [TextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TextBox),
[TextArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TextArea),
[Password](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_Password)|
| `int` , `float`, `decimal`,`double`,`long` | [NumericTextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_NumericTextBox) |
| `bool` | [CheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_CheckBox),
[Switch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_Switch) |
| `DateTime` | [DatePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DatePicker),
[DateTimePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DateTimePicker),
[TimePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TimePicker) |
| `enum` | [DropDownList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DropDownList),
[ComboBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_ComboBox),
[AutoComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_AutoComplete) |
| `DateOnly` | [DatePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DatePicker) |
| `TimeOnly` | [TimePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TimePicker) |

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations


<SfDataForm ID="MyForm"
            Model="@EditorTypeModel"
            Width="50%"
            AutoComplete="on">

    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>

    <FormItems>
        <FormItem Field="@nameof(EditorTypeModel.NumericTextBoxField)" ID="numeric-textbox" Placeholder="Enter the value" LabelText="Numeric TextBox Editor"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.TextBoxField)" ID="textbox" Placeholder="Enter the value" LabelText="TextBox Editor"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.DisabledTextBoxField)" ID="diabled" IsEnabled="false" Placeholder="Enter the value" LabelText="TextBox Editor"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.TextAreaField)" CssClass="e-warning" LabelText="TextArea Editor" Placeholder="Enter the value" EditorType="FormEditorType.TextArea"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.DropDownListField)" LabelText="DropDownList Editor" CssClass="e-warning" Placeholder="Select the value" EditorType="FormEditorType.DropDownList"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.AutoCompleteField)" LabelText="AutoComplete Editor" Placeholder="Select the value" EditorType="FormEditorType.AutoComplete"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.ComboBoxField)" LabelText="ComboBox Editor" Placeholder="Select the value" EditorType="FormEditorType.ComboBox"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.PasswordField)" LabelText="Password Editor" Placeholder="Enter the value" EditorType="FormEditorType.Password"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.DateTimePickerField)" LabelText="DateTimePicker Editor" Placeholder="Enter the value" EditorType="FormEditorType.DateTimePicker"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.DatePickerField)" LabelText="DatePicker Editor" Placeholder="Enter the value" EditorType="FormEditorType.DatePicker"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.TimePickerField)" LabelText="TimePicker Editor" Placeholder="Enter the value" EditorType="FormEditorType.TimePicker"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.CheckBoxField)" LabelText="Checkbox Editor"></FormItem>
        <FormItem Field="@nameof(EditorTypeModel.SwitchField)" LabelText="Switch Editor" EditorType="FormEditorType.Switch"></FormItem>
    </FormItems>
</SfDataForm>


@code {
    private EditorTypes EditorTypeModel = new EditorTypes();
}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}
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
{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_formitem.png)

## Disable the form item

The [IsEnabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_IsEnabled) property is used to disable the specific form item.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm"
            Model="@EventRegistrationModel">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(EventRegistration.ID)" IsEnabled="false"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Name)"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Email)"></FormItem>
    </FormItems>
</SfDataForm>


@code {
    private EventRegistration EventRegistrationModel = new EventRegistration()
        {
            ID = "1001"
        };
}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}
public class EventRegistration
{
    public string ID { get; set; }
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
}
{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_formitem_disabled.png)

## Change the appearance of the form item

The [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_CssClass) property is used to change the appearance of the form item.The added css class will get added to the editor's wrapper component , using that we can customize the appearance of the editor.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}


{% tabs %}
{% highlight razor tabtitle="Razor"  %}
@using Syncfusion.Blazor.DataForm
@using System.ComponentModel.DataAnnotations

<SfDataForm ID="MyForm"
            Model="@EventRegistrationModel">
    <FormValidator>
        <DataAnnotationsValidator></DataAnnotationsValidator>
    </FormValidator>
    <FormItems>
        <FormItem Field="@nameof(EventRegistration.Name)" CssClass="e-warning"></FormItem>
        <FormItem Field="@nameof(EventRegistration.Email)"></FormItem>
    </FormItems>
    </SfDataForm>

@code {

    private EventRegistration EventRegistrationModel = new EventRegistration();
}

{% endhighlight %}
{% highlight C# tabtitle="C#"  %}
public class EventRegistration
{
    [Required(ErrorMessage = "Please enter your name.")]
    [Display(Name = "Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your email address.")]
    [Display(Name = "Email address")]
    public string Email { get; set; }
}
{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_formitem_cssclass.png)

## See Also

[Customization of specific field editor](https://blazor.syncfusion.com/documentation/data-form/templates#customization-of-specific-field-editor)