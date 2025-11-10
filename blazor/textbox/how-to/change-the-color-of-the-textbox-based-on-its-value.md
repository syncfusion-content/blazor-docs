---
layout: post
title: Change the Color of the Blazor TextBox based on its Value | Syncfusion
description: Learn here all about how to change the color of the text based on its value in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Change the Color of the Text Based on its Value in Blazor TextBox

The color of the TextBox can be changed by validating its value using regular expression in the `Input` event for predicting the numeric values as demonstrated in the following code sample.

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

![Changing Validation Text Color in Blazor TextBox](../images/blazor-textbox-validation-text-color.png)