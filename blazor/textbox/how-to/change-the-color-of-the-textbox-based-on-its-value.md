---
layout: post
title: How to Change The Color Of The Textbox Based On Its Value in Blazor TextBox Component | Syncfusion
description: Checkout and learn about Change The Color Of The Textbox Based On Its Value in Blazor TextBox component of Syncfusion, and more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Change the color of the TextBox based on its value

You can change the color of the TextBox by validating its value using regular expression in the `Input` event for predicting the numeric values as demonstrated in the following code sample.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder="Enter a Numeric Values" FloatLabelType="@FloatLabelType.Auto" Input="OnInput" CssClass="@CssClass"></SfTextBox>

@code {

    public string CssClass { get; set; }

    public void OnInput(InputEventArgs args)
    {
        if (!System.Text.RegularExpressions.Regex.IsMatch(args.Value, "^[0-9]*$")){
            CssClass = "e-error";
        }
        else {
            CssClass = "e-success";
        }
        this.StateHasChanged();
    }
}
```

The output will be as follows.

![textbox](../images/validation.png)