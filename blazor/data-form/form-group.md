---
layout: post
title: Form Groups in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about the single and multiple form group configuration  with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Form group in DataForm component

In the DataForm, the [FormGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html) feature organizes `FormItem` and `FormAutoGenerateItems` under a descriptive group label with an optional identifier, and supports a column-based layout within each group.

## Configure the group name and ID 

The following example shows how to configure a `FormGroup` within the DataForm using the [GroupName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html#Syncfusion_Blazor_DataForm_FormGroup_LabelText) and [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html#Syncfusion_Blazor_DataForm_FormGroup_ID) properties. The group name labels the group section, and the ID uniquely identifies the group in the form.

{% tabs %}
{% highlight razor tabtitle="Form group" %}

{% include_relative code-snippet/form-group/form-group.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm showing a single form group with label and items](images/blazor_dataform_single_formgroup.png)

## Column layout for the group

The DataForm can arrange multiple form groups across columns using the form-level [ColumnCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_ColumnCount) property. Set this value to split the overall layout into the specified number of columns and place groups accordingly.

{% tabs %}
{% highlight razor tabtitle="Razor" %}

{% include_relative code-snippet/form-group/multiple-form-group.razor %}

{% endhighlight %}
{% highlight C# tabtitle="C#" %}

{% include_relative code-snippet/form-group/multiple-form-group.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Form Group](images/blazor_dataform_multiple_formgroup.png)

## Configure the column spacing 

This section explains how to divide the collection of [FormGroups](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html) and organize subdivisions within a `FormGroup` using [ColumnsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html#Syncfusion_Blazor_DataForm_FormGroup_ColumnCount) and [ColumnSpacing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html#Syncfusion_Blazor_DataForm_FormGroup_ColumnSpacing). Use a suitable column count within each group and adjust spacing to achieve a clear, balanced layout.

{% tabs %}
{% highlight razor tabtitle="Razor" %}

{% include_relative code-snippet/form-group/column-layout.razor %}

{% endhighlight %}
{% highlight C# tabtitle="C#" %}

{% include_relative code-snippet/form-group/column-layout.razor %}

{% endhighlight %}
{% endtabs %}

In the example, the DataForm contains two groups. The first group uses six internal columns and distributes its fields by their column spans. The second group uses two internal columns and arranges its fields accordingly.

![Blazor DataForm form group column layout with per-group column counts and spacing](images/blazor_dataform_formgroup_column_layout.png)

## Change the appearance of the form group

Customize the appearance of a form group using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormGroup.html#Syncfusion_Blazor_DataForm_FormGroup_CssClass) property of the `FormGroup`. The following example demonstrates changing the background color and adding padding to the form group wrapper.

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/form-group/change-appearance-form-group.razor %}

{% endhighlight %}

{% highlight C# tabtitle="C#"  %}

{% include_relative code-snippet/form-group/change-appearance-form-group.cs %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm form group customized with background color and padding](images/blazor_dataform_formgroup_customization.png)