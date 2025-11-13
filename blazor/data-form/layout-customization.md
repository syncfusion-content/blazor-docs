---
layout: post
title: Layout customization in Blazor DataForm component | Syncfusion
description: Checkout and learn here about layout customization such button and label positioning and validation message display with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Layout customization

This section explains how to position buttons and labels in the DataForm component, customize button areas, and display validation messages. It also describes how to enable floating labels and adjust the overall form width.

## Button alignment

The DataForm component can align form buttons horizontally within the form container by using the [ButtonsAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html) property. The `ButtonsAlignment` options are:

- Center: centers the buttons within the container
- Left: left-aligns the buttons
- Right: right-aligns the buttons
- Stretch: stretches buttons to fill the available width

| FormButtonsAlignment | Snapshot |
| ------------ | ----------------------- |
|[FormButtonsAlignment.Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html#Syncfusion_Blazor_DataForm_FormButtonsAlignment_Center)|![DataForm with buttons aligned to the center](images/blazor_dataform_button_alignment_center.png)|
|[FormButtonsAlignment.Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html#Syncfusion_Blazor_DataForm_FormButtonsAlignment_Left)|![DataForm with buttons aligned to the left](images/blazor_dataform_button_alignment_left.png)|
|[FormButtonsAlignment.Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html#Syncfusion_Blazor_DataForm_FormButtonsAlignment_Right)|![DataForm with buttons aligned to the right](images/blazor_dataform_button_alignment_right.png)|
|[FormButtonsAlignment.Stretch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtonsAlignment.html#Syncfusion_Blazor_DataForm_FormButtonsAlignment_Stretch)|![DataForm with buttons stretched to full width](images/blazor_dataform_button_alignment_stretch.png)|

The following example shows how to use the `ButtonsAlignment` property in the DataForm component.

{% tabs %}
{% highlight razor tabtitle="ButtonsAlignment"  %}

{% include_relative code-snippet/layout-customization/buttons-alignment.razor %}

{% endhighlight %}
{% endtabs %}

## Add additional buttons and customization

Add custom buttons or other elements by using the [FormButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormButtons.html) `RenderFragment` within the DataForm component.

In the following example, an additional button is added to reset input fields by handling the [OnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_OnClick) event of the [SfButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_OnClick).

{% tabs %}
{% highlight razor tabtitle="ButtonsAlignment"  %}

{% include_relative code-snippet/layout-customization/additional-buttons.razor %}

{% endhighlight %}
{% endtabs %}

![DataForm with default submit buttons and a custom reset button](images/blazor_dataform_formbuttons.png)

## Label position

The DataForm component aligns labels either at the top or to the left of the field editors using the [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_LabelPosition) property. The available options are shown below.

| LabelPosition | Snapshot |
| ------------ | ----------------------- |
|[FormLabelPosition.Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormLabelPosition.html#Syncfusion_Blazor_DataForm_FormLabelPosition_Top)|![DataForm with labels positioned above editors](images/blazor_dataform_label_position_top.png)|
|[FormLabelPosition.Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormLabelPosition.html#Syncfusion_Blazor_DataForm_FormLabelPosition_Left)|![DataForm with labels positioned to the left of editors](images/blazor_dataform_label_position_left.png)|
|When no specific value is provided, the layout defaults to `FormLabelPosition.Top`. For boolean editors such as [SfCheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html) and [SfSwitch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html), labels are positioned to the right of the control.|![DataForm default label positioning and boolean editor label placement](images/blazor_dataform_default_label_position.png)|

The following example demonstrates how to configure the `LabelPosition` in the DataForm component.

{% tabs %}
{% highlight razor tabtitle="Label Position"  %}

{% include_relative code-snippet/layout-customization/label-position.razor %}

{% endhighlight %}
{% endtabs %}

## Floating label 

Enable floating labels to move the label to the top of the input when focused by setting [EnableFloatingLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_EnableFloatingLabel) to true. The following code example and GIF demonstrate floating label behavior.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/layout-customization/floating-label.razor %}

{% endhighlight %}

{% highlight csharp tabtitle="C#" %}

{% include_relative code-snippet/layout-customization/floating-label.cs %}

{% endhighlight %}

{% endtabs %}

![Blazor DataForm floating label behavior when focusing inputs](images/blazor_dataform_floating_label.gif)

N> The floating label feature applies only when [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_LabelPosition) is set to [FormLabelPosition.Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormLabelPosition.html#Syncfusion_Blazor_DataForm_FormLabelPosition_Top).

## Change the form width 

Customize the width of the form container by using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_Width) property.

{% tabs %}
{% highlight razor tabtitle="Width"  %}

{% include_relative code-snippet/templates/change-form-width.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm with custom form width applied](images/blazor_dataform_change_form_width.png)