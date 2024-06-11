---
layout: post
title: Maximum Length in Blazor TextArea Component | Syncfusion
description: Limiting the maximum number of characters of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: Textarea
documentation: ug
---

# Maximum Length in Blazor TextArea Component

You can enforce a maximum length limit for the text input in the TextArea using the [maxLength](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_MaxLength) property. This property allows to define the maximum number of characters that users can input into the TextArea.


* By setting the `MaxLength` property, you can control the length of text input, preventing users from exceeding a specified character limit.

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='First Name' MaxLength="20" FloatLabelType='@FloatLabelType.Auto'></SfTextArea>

{% endhighlight %}
{% endtabs %}

When the user reaches the specified limit, the TextArea prevents further input, ensuring compliance with the defined character limit. This feature helps maintain data integrity and provides users with clear feedback on the allowed input length.