---
layout: post
title: How to Customize The Textbox Background Color And Text Color in Blazor TextBox Component | Syncfusion
description: Checkout and learn about Customize The Textbox Background Color And Text Color in Blazor TextBox component of Syncfusion, and more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Customize the textbox background-color and text-color

You can customize the text box styles such as background-color, text-color and border-color by overriding its default styles.

```csharp
@using Syncfusion.Blazor.Inputs

<div class="@(TextClass)">
    <div class="e-input-in-wrap">
        <input class="e-input" type="text" Placeholder="Enter Date" Value="John" @onfocus="@Focus" @onblur="@Blur" />
        <span class="e-input-group-icon e-input-date"></span>
    </div>
</div>

@code {
    public string FocusClass { get; set; } = " e-input-focus";
    public string TextClass { get; set; } = "e-input-group";
    public void Focus(FocusEventArgs args)
    {
        this.TextClass = this.TextClass + FocusClass;
        StateHasChanged();
    }

    public void Blur(FocusEventArgs args)
    {
        if (this.TextClass.Contains(FocusClass))
        {
            this.TextClass = this.TextClass.Replace(FocusClass, "");
        }
        StateHasChanged();
    }
}
<style>
    .e-input-group {
        background: yellow;
        color: red;
    }
</style>
```

The output will be as follows.

![textbox](../images/back_customization.png)
