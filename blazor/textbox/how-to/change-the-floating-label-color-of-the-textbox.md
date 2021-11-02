---
layout: post
title: Floating Label Color of Blazor TextBox Component | Syncfusion
description: Learn here all about changing the floating label color of the Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Change the Floating Label Color of the Blazor TextBox Component

The floating label color of the TextBox can be changed for both `success` and `warning` validation states by applying the following CSS styles.

```cshtml
@using Syncfusion.Blazor.Inputs

    <div class="e-float-input @(TextClass) e-success">
        <input type="text" @onfocus="@Focus" @onblur="@Blur" required />
        <span class="e-float-line"></span>
        <label class="e-float-text">Success</label>
    </div>
    <div class="e-float-input @(FloatTextClass) e-warning">
        <input type="text" @onfocus="@FlaotFocus" @onblur="@FloatBlur" required />
        <span class="e-float-line"></span>
        <label class="e-float-text">Warning</label>
    </div>

@code {
    public string FocusClass { get; set; } = " e-input-focus";
    public string TextClass { get; set; } = "e-input-group";
    public string FloatTextClass { get; set; } = "e-input-group";
    public void Focus(FocusEventArgs args)
    {
        this.TextClass = this.TextClass + FocusClass;
        StateHasChanged();
    }

    public void FlaotFocus(FocusEventArgs args)
    {
        this.FloatTextClass = this.FloatTextClass + FocusClass;
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

    public void FloatBlur(FocusEventArgs args)
    {
        if (this.FloatTextClass.Contains(FocusClass))
        {
            this.FloatTextClass = this.FloatTextClass.Replace(FocusClass, "");
        }
        StateHasChanged();
    }
}

<style>
    .e-float-input.e-success label.e-float-text,
    .e-float-input.e-success input:focus ~ label.e-float-text,
    .e-float-input.e-success input:valid ~ label.e-float-text {
        color: #22b24b;
    }

    /* For Warning state */
    .e-float-input.e-warning label.e-float-text,
    .e-float-input.e-warning input:focus ~ label.e-float-text,
    .e-float-input.e-warning input:valid ~ label.e-float-text {
        color: #ffca1c;
    }
</style>
```

![Changing Float Label Color in Blazor TextBox](../images/blazor-textbox-custom-float-label-color.png)