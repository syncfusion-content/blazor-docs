---
layout: post
title: HTML Attribute Support in Blazor Button Component | Syncfusion
description: Checkout and learn here all about HTML Attribute Support in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# HTML Attribute Support in Blazor Button Component

You can add the additional [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html) such as disabled, value, name, and more to the element using the HtmlAttributes property. If you configure both the property and equivalent HTML attribute, then the component will consider the property value.

The following example demonstrates how to set attributes in the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html) property in the Button.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="@Content" HtmlAttributes="@submit"></SfButton>

@code {
    public string Content = "Submit";
    private Dictionary<string, object> submit = new Dictionary<string, object>()
     {
        { "type", "submit"},
        { "id", "Submit" }
    };
}

```


![Blazor Button with HTML Attribute](./../images/blazor-button-with-html.png)