---
layout: post
title: Columns in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about columns in the Syncfusion Blazor MultiColumn ComboBox component and much more details.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Configuring the Columns

## Setting the Text Align

The MultiColumn ComboBox supports auto-generating columns, which simplifies the process by automatically creating columns based on the data source. Additionally, you can customize the column header text to reflect specific data, adjust the column [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_Width) for optimal display, and set the [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_TextAlign) (left, center, or right) to enhance readability.

{% highlight cshtml %}

{% include_relative code-snippet/column/column-text-align.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthptYsEgssKVDPs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Data Binding](./images/blazor-multicolumncombobox-columns.png)" %}

## Setting the Template

The MultiColumn ComboBox supports [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_Template) within the column, allowing you to define a column template that renders a customized element in each cell.

## Header template

The [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_HeaderTemplate) of the MultiColumn ComboBox component used to customize the header element of a MultiColumn. With this property, you can render custom HTML elements or Blazor components to the header element. This feature allows you to add more functionality to the header, such as sorting or filtering.

In the following sample, defines how to use `Template` and `HeaderTemplate`.

{% highlight cshtml %}

{% include_relative code-snippet/column/column-header.razor %}

{% endhighlight %}

## Setting Display As CheckBox 

The MultiColumn ComboBox component allows you to render boolean values as checkboxes in columns. This can be achieved by using the [DisplayAsCheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_DisplayAsCheckBox)  property. This property is useful when you have a boolean column in your MultiColumn ComboBox and you want to display the values as checkboxes instead of the default text representation of **true** or **false**.

To enable the rendering of boolean values as checkboxes, you need to set the `DisplayAsCheckBox` property to **true**.

{% highlight cshtml %}

{% include_relative code-snippet/column/column-checkbox.razor %}

{% endhighlight %}

## Setting custom attributes

You can customize the appearance of the column headers in MultiColumn ComboBox using the [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_CustomAttributes) property.

You can set the **CustomAttributes** property of the desired column to an object that contains the CSS class **customcss**. This CSS class will be applied to the header cell of the specified rows in the Multicolumn.

```cshtml
<MultiColumnComboboxColumn Field="Name" Width="200px" CustomAttributes="@(new Dictionary<string, object>() { { "class", "customcss" } })"></MultiColumnComboboxColumn>
```

The following example demonstrates how to customize the appearance of the Multicolumn Combobox columns using custom attributes.

{% highlight cshtml %}

{% include_relative code-snippet/column/column-custom-attributes.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLqCMNiLfcCJPPZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


