---
layout: post
title: Form Items in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to configure Form Item and its customization in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Form items in DataForm component

The [FormItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html)  can be utilized to set up various configuration for the editor component, including the unique identifier (id), the type of editor component used, any additional CSS classes to be applied to the editor, and whether the field is to be active (enabled) or inactive (disabled) upon being rendered.The below example showcases the different property usages.


## Configuring the model field and ID

The [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_Field) property is used to map the model field to the corresponding editor component. The [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_ID) property is used to set the unique identifier for the editor component.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/configure-model-ID.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/configure-model-ID.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_configure_model_ID.png)

## Set the placeholder

The [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_Placeholder) property is used to set the placeholder text for the editor component. 
{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/placeholder.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/placeholder.cs %}

{% endhighlight %}
{% endtabs %}

![DataForm Placeholder](./images/blazor_dataform_placeholder.png)

## Change the editor type

The [EditorType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_EditorType) property is used to set the editor type for the corresponding field.We can assign the editor type using the [FormEditorType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html) enumeration.

| Field Type | Supported Editor types |
| ------------ | ----------------------- |
| `string` | [TextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TextBox),[TextArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TextArea),[Password](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_Password)|
| `int` , `float`, `decimal`,`double`,`long` | [NumericTextBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_NumericTextBox) |
| `bool` | [CheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_CheckBox),[Switch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_Switch) |
| `DateTime` | [DatePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DatePicker),[DateTimePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DateTimePicker),[TimePicker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_TimePicker) |
| `enum` | [DropDownList](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_DropDownList),[ComboBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_ComboBox),[AutoComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormEditorType.html#Syncfusion_Blazor_DataForm_FormEditorType_AutoComplete) |
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

![Blazor DataForm Form Item](images/blazor_dataform_formitem.png)


## Disable the editor

The [IsEnabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_IsEnabled) property is used to disable the specific form item.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/disable-form-item.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/disable-form-item.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_formitem_disabled.png)

## Change the label name 

The [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_Label) property is used to set the label text for the editor component , At default `Name` property of the `Display` attribute will be used as label text.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/label-name.razor %}


{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/label-name.cs %}


{% endhighlight %}
{% endtabs %}

![DataForm Placeholder](./images/blazor_dataform_label_text.png)


## Change the appearance of the field editor

The [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_CssClass) property is used to change the appearance of the form item.The added css class will get added to the editor's wrapper component , using that we can customize the appearance of the editor.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-items/appearence-of-form-item.razor %}

{% endhighlight %}
{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-items/appearence-of-form-item.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Item](images/blazor_dataform_formitem_cssclass.png)

## See also

[Customization of specific field editor](https://blazor.syncfusion.com/documentation/data-form/templates#customization-of-specific-field-editor)