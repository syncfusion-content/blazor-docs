---
layout: post
title: HTML Attribute Support in Blazor Button Component | Syncfusion
description: Checkout and learn here all about HTML Attribute Support in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# HTML Attribute Support in Blazor Button Component

HTML attribute support is given for button using [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html) property.

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="@Content" HtmlAttributes="@submit"></SfButton>

@code {
    public string Content = "Submit";
    private Dictionary<string, object> submit = new Dictionary<string, object>()
     {
        { "type", "submit"}
    };
}

```


![Blazor Button with HTML Attribute](./../images/blazor-button-with-html.png)