---
layout: post
title: Set the disabled state in Blazor Button Component | Syncfusion
description: Checkout and learn here all about setting the disabled state in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# Set the Disabled State in Blazor Button Component

Button component can be enabled/disabled by giving [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_Disabled) property. To disable Button component, the `Disabled` property can be set as `true`.

The following example demonstrates Button in `Disabled` state.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton Disabled="@disable" @ref="ButtonObj">Disabled</SfButton>
<SfButton OnClick="click">Enable</SfButton>

@code{
    SfButton ButtonObj;
    private Boolean disable = true;
    public void click()
    {
        disable = false;
    }
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBqiBVhMGkwXmsI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Disable State in Blazor Button](./../images/blazor-button-disable-state.png)