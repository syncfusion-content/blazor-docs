---
layout: post
title: Rows and Columns count in Blazor TextArea Component | Syncfusion
description: Learn about adjusting the rows and columns of the Syncfusion  Blazor TextArea component and much more.
platform: Blazor
control: TextArea
documentation: ug
---

# Rows and Columns in Blazor TextArea Component

The TextArea size can be tailored for layout and readability using the component properties that map to native textarea behavior. The `rows` value controls the initial visible number of lines (vertical size), and the `columns` value represents the initial visible width in characters per line (approximate, as it depends on font and CSS). These settings affect only the initial visible area; content can still exceed the view and scrollbars may appear based on overflow settings.

* Customize the TextArea component by setting the number of rows with the [RowCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_RowCount) property and the number of columns with the [ColumnCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_ColumnCount) property. These properties allow precise control over the dimensions of the TextArea, ensuring it fits seamlessly within the layout of the application.

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter your comments' RowCount= "3" ColumnCount = '35' ></SfTextArea>
<SfTextArea Placeholder='Enter your comments' RowCount= "5" ColumnCount = '40' ></SfTextArea>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLpNnWUWKSXAMrN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with Row and Column](./images/blazor-textarea-rows-columns.png)" %}