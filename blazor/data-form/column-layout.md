---
layout: post
title: Column and column span in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to configure column and column span  with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Column layout in DataForm component

This section explains how to arrange DataForm editors in a column-based layout. The [ColumnCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_ColumnCount) property allows us to specify the number of columns into which the DataForm should be divided. 

{% tabs %}
{% highlight razor tabtitle="razor" %}

{% include_relative code-snippet/column-layout/columns-count.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm column layout](images/blazor_dataform_change_form_width.png)

## Configure the column span 

Additionally, by utilizing the [ColumnSpan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_ColumnSpan) attribute of a `FormItem`, we can control the width of the editor, either allowing it to expand to full width or allocating it a portion of the width based on the provided column span.

{% tabs %}
{% highlight razor tabtitle="ColumnSpan" %}

{% include_relative code-snippet/column-layout/column-span.razor %}

{% endhighlight %}
{% endtabs %}

In the following example, the DataForm is divided into six equal columns. Each editor consumes space based on its configured column span, resulting in rows where items align cleanly and wrap to the next row when the remaining columns are insufficient.

![Blazor DataForm demonstrating ColumnSpan across a six-column grid](images/blazor_dataform_column_span.png)


## See Also

* [Adaptive Layout structure](https://blazor.syncfusion.com/demos/data-form/adaptive-layout?theme=fluent)