---
layout: post
title: Column and column span in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to configure column and column span  with Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Column layout in DataForm component

This segment provides guidance on dividing the form field editors inside the DataForm component into a column-based layout. The [ColumnCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.SfDataForm.html#Syncfusion_Blazor_DataForm_SfDataForm_ColumnCount) property allows us to specify the number of columns into which the DataForm should be divided. 

{% tabs %}
{% highlight razor tabtitle="razor" %}

{% include_relative code-snippet/column-layout/columns-count.razor %}

{% endhighlight %}
{% endtabs %}

![Blazor DataForm Column Layout](images/blazor_dataform_change_form_width.png)

## Configure the column span 

Additionally, by utilizing the [ColumnSpan](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataForm.FormItem.html#Syncfusion_Blazor_DataForm_FormItem_ColumnSpan) attribute of a `FormItem`, we can control the width of the editor, either allowing it to expand to full width or allocating it a portion of the width based on the provided column span.

{% tabs %}
{% highlight razor tabtitle="ColumnSpan" %}

{% include_relative code-snippet/column-layout/column-span.razor %}

{% endhighlight %}
{% endtabs %}

In the provided example, the layout of the DataForm is segmented into six equal columns, with the editor fields distributed accordingly, depending on the column span allocated to each one.

![Blazor DataForm Column Layout](images/blazor_dataform_column_span.png)


## See Also

* [Adaptive Layout structure](https://blazor.syncfusion.com/demos/data-form/adaptive-layout?theme=fluent)