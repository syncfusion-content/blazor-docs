---
layout: post
title: Maximum Length in Blazor TextArea Component | Syncfusion
description: Limiting the maximum number of characters of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: TextArea
documentation: ug
---

# Maximum Length in Blazor TextArea Component

Use the [MaxLength property](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_MaxLength) to enforce a maximum character limit in the TextArea. This defines the highest number of characters the user can enter, helping control input length and maintain data quality.

{% tabs %}
{% highlight razor %}

<SfTextArea Placeholder='Enter the Address' MaxLength="20" FloatLabelType='FloatLabelType.Auto'></SfTextArea>

{% endhighlight %}
{% endtabs %}

When the limit is reached, the TextArea prevents further input from typing or pasting. Newline characters count toward the limit. For robust validation, also validate on the server or with model attributes (for example, MaxLength or StringLength). The Input event fires as the user types until the limit is reached, and ValueChange occurs on blur when the value is committed.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthpDRsUCffyeOfE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TextArea with MaxLength](./images/blazor-textarea-maxlength.png)" %}