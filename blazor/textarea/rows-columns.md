---
layout: post
title: Rows and Columns count in Blazor TextArea Component | Syncfusion
description: Learn about adjusting the rows and columns of the Syncfusion  Blazor TextArea component and much more.
platform: Blazor
control: Textarea
documentation: ug
---

# Rows and Columns in Blazor TextArea Component

Two essential attributes, `rows` and `columns`, play a pivotal role in customizing the TextArea's appearance and layout.
The `rows`attribute determines the initial visible number of lines within the TextArea, controlling its vertical size. Conversely, the `columns` attribute specifies the visible width of the TextArea in characters per line, determining its initial width.


* You can customize the TextArea component by setting the number of rows using the [RowCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_RowCount) property and the number of columns using the [ColumnCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_ColumnCount) property. These properties allow precise control over the dimensions of the TextArea, ensuring it fits seamlessly within the layout of the application.

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter your comments' RowCount= "3" ColumnCount = '35' ></SfTextArea>
<SfTextArea Placeholder='Enter your comments' RowCount= "5" ColumnCount = '40' ></SfTextArea>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLpNnWUWKSXAMrN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with Row and Column](./images/blazor-textarea-rows-columns.png)" %}