---
layout: post
title: Customize the Background & Text Color in Blazor TextBox | Syncfusion
description: Learn here all about customizing the TextBox Background Color and Text Color in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Customize background and text color in Blazor TextBox component

Customize the TextBox appearance (background color, text color, and borders) by overriding its default CSS classes. The following example uses the `e-input-group` container to apply a custom background and text color. It also toggles the focus state class to reflect focus styling.

```cshtml
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

![Blazor TextBox with Custom Background and Text Color](../images/blazor-textbox-custom-style.png)