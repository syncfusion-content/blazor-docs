---
layout: post
title: Set the disabled state in Blazor Button Component | Syncfusion®
description: Checkout and learn here all about setting the disabled state in Blazor Button component and much more.
platform: Blazor
control: Button
documentation: ug
---

# Set the Disabled State in Blazor Button Component

The Blazor Button component can be enabled or disabled by setting the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_Disabled) property. To disable the Button component, set the `Disabled` property to `true`. The property is rendered as the standard HTML `disabled` attribute on the underlying button element.

The following example demonstrates a Button in the disabled state and a second Button that enables it on click.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfButton Disabled="@disable" @ref="ButtonObj">Disabled</SfButton>
<SfButton OnClick="click">Enable</SfButton>

@code {
    SfButton ButtonObj;
    private bool disable = true;
    public void click()
    {
        disable = false;
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBxjdCLhTjMClpL?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Disable State in Blazor Button](./../images/blazor-button-disable-state.webp)" %}

## See also

* [Create a Block Button in Blazor Button](create-a-block-button.md)
* [Styles and Appearances in Blazor Button](../style-and-appearance.md)
* [Blazor Button API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html)