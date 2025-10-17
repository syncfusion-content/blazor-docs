---
layout: post
title: Form Items in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to configure Form Item and its customization in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Form items in DataForm component

The [FormItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html) configures the editor for a specific model field. It supports setting a unique identifier (ID), selecting the editor type, applying CSS classes, specifying placeholder and label text, and enabling or disabling the field. The following sections demonstrate common property usage:
- Field: map the model property to an editor
- ID: assign a unique identifier
- Placeholder: set hint text inside the editor
- EditorType: choose the editor control
- IsEnabled: enable or disable the form item
- Label/LabelText: set the editor’s label text
- CssClass: apply custom styles to the editor wrapper

## Configuring the model field and ID

The [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_Field) property maps the model field to the corresponding editor. The [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_ID) property sets a unique identifier for the editor component.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/configure-model-ID.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/configure-model-ID.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm form item showing mapped field and custom ID](images/blazor_dataform_configure_model_ID.png)

## Set the placeholder

The [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_Placeholder) property sets the placeholder text for the editor.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/placeholder.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/placeholder.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm form item with placeholder text in the editor](./images/blazor_dataform_placeholder.png)

## Change the editor type

The [EditorType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_EditorType) property selects the editor used for the field. Set the value from the [FormEditorType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html) enumeration to override the default editor inferred from the field type.

| Field Type | Supported editor types |
| ------------ | ----------------------- |
| `string` | [TextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TextBox), [TextArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TextArea), [Password](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_Password) |
| `int`, `float`, `decimal`, `double`, `long` | [NumericTextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_NumericTextBox) |
| `bool` | [CheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_CheckBox), [Switch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_Switch) |
| `DateTime` | [DatePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DatePicker), [DateTimePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DateTimePicker), [TimePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TimePicker) |
| `enum` | [DropDownList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DropDownList), [ComboBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_ComboBox), [AutoComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_AutoComplete) |
| `DateOnly` | [DatePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DatePicker) |
| `TimeOnly` | [TimePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TimePicker) |

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/configure-editor-type.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/configure-editor-type.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm form items rendered with different editor types](images/blazor_dataform_formitem.png)

## Disable a form item

The [IsEnabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_IsEnabled) property disables a specific form item.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/disable-form-item.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/disable-form-item.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm form item in a disabled state](images/blazor_dataform_formitem_disabled.png)

## Change the label text 

Set the label using the [LabelText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_LabelText) property. When not set, the label is derived from data annotations on the bound model property, giving priority to DisplayAttribute.ShortName and then DisplayAttribute.Name.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/label-name.razor %}


{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/label-name.cs %}


{% endhighlight %}
{% endtabs %}

![Blazor DataForm form item with customized label text](./images/blazor_dataform_label_text.png)


## Change the appearance of the field editor

Use the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_CssClass) property to apply a custom CSS class to the editor wrapper and customize the appearance.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/appearence-of-form-item.razor %}

{% endhighlight %}
{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/appearence-of-form-item.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm form item styled using a custom CSS class](images/blazor_dataform_formitem_cssclass.png)

## See also

- [Customization of specific field editor](https://blazor.syncfusion.com/documentation/data-form/templates#customization-of-specific-field-editor)