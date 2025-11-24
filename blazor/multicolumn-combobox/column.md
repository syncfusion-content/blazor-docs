---
layout: post
title: Columns in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about columns in the Syncfusion Blazor MultiColumn ComboBox component and much more details.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Configuring the Columns

## TextWrap for column 

The TextWrap in the Blazor `MultiColumn ComboBox` ensures proper wrapping of text within data content for a particular column. By enabling `EnableTextWrap`, you can manage how text appears when it exceeds the available space.

**Key features**

* **TextWrapElement**: This is an enum(Header,Content ,Both) Defines the element where text wrapping is applied.

* **TextOverflowMode**:This is an enum(Ellipsis ,EllipsisWithTooltip) Defines truncates the cell content when it overflows its area.

The following example enables text wrapping for a particular column in the Blazor MultiColumn ComboBox,ensuring that longer text is properly displayed without overflowing.

{% highlight cshtml %}

{% include_relative code-snippet/column/text-wrap.razor %}

{% endhighlight %}


![Blazor MultiColumn ComboBox with Text Wrap](./images/column/blazor_multicolumncombobox_textwrapcolumn.gif)

## Setting the text align

The MultiColumn ComboBox supports auto-generating columns, which simplifies the process by automatically creating columns based on the data source. Additionally, you can customize the column header text to reflect specific data, adjust the column [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_Width) for optimal display, and set the [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_TextAlign) (left, center, or right) to enhance readability.

{% highlight cshtml %}

{% include_relative code-snippet/column/column-text-align.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVpjYVATVHVEqlS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Text align](./images/column/blazor_multicolumn_combobox_column-text-align.gif)" %}

## Setting the column template

The MultiColumn ComboBox supports [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_Template) within the column, allowing you to define a column template that renders a customized element in each cell.|

In the following sample, defines how to use `Template` inside the column.

{% highlight cshtml %}

{% include_relative code-snippet/column/column-template.razor %}

{% endhighlight %}

## Header template

The [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_HeaderTemplate) of the MultiColumn ComboBox component used to customize the header element of a MultiColumn. With this property, you can render custom HTML elements or Blazor components to the header element. This feature allows you to add more functionality to the header, such as sorting or filtering.

In the following sample, defines how to use `HeaderTemplate`.

{% highlight cshtml %}

{% include_relative code-snippet/column/column-header.razor %}

{% endhighlight %}

![Blazor MultiColumn ComboBox with Column header](./images/column/blazor_multicolumn_combobox_column-header.gif)

## Setting display as checkbox 

The MultiColumn ComboBox component allows you to render boolean values as checkboxes in columns. This can be achieved by using the [DisplayAsCheckBox](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_DisplayAsCheckBox)  property. This property is useful when you have a boolean column in your MultiColumn ComboBox and you want to display the values as checkboxes instead of the default text representation of **true** or **false**.

To enable the rendering of boolean values as checkboxes, you need to set the `DisplayAsCheckBox` property to **true**.

{% highlight cshtml %}

{% include_relative code-snippet/column/column-checkbox.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNhzXOLgTUyFLZUG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with Check Box](./images/column/blazor_multicolumn_combobox_column-checkbox.gif)" %}

## Setting custom attributes

You can customize the appearance of the column headers in MultiColumn ComboBox using the [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_CustomAttributes) property.

You can set the **CustomAttributes** property of the desired column to an object that contains the CSS class custom css. This CSS class will be applied to the header cell of the specified rows in the Multicolumn.

```cshtml
<MultiColumnComboboxColumn Field="Name" Width="200px" CustomAttributes="@(new Dictionary<string, object>() { { "class", "customcss" } })"></MultiColumnComboboxColumn>
```

The following example demonstrates how to customize the appearance of the Multicolumn Combobox columns using custom attributes.

{% highlight cshtml %}

{% include_relative code-snippet/column/column-custom-attributes.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLpZOLApKBUYqMm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor MultiColumn ComboBox with custom attributes](./images/column/blazor_multicolumn_combobox_column-custom-attributes.gif)" %}

## Setting the format

The [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.MultiColumnComboBox.MultiColumnComboboxColumn.html#Syncfusion_Blazor_MultiColumnComboBox_MultiColumnComboboxColumn_Format) property to a column in the SfMultiColumnComboBox, specify a valid format string that matches the data type of the column, such as numeric or date formats. For example, you can apply currency formatting to a price field by using the format "C2".

The following example the Price column uses "C2" to display values in a currency format.

{% highlight cshtml %}

{% include_relative code-snippet/column/format.razor %}

{% endhighlight %}

