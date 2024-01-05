---
layout: post
title: HTML Attribute Support in Blazor Button Component | Syncfusion
description: Checkout and learn here all about HTML Attribute Support in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# HTML Attribute Support in Blazor Button Component

You can incorporate additional HTML attributes like disabled, value, name, and others into the SfButton by explicitly specifying them within the [SfButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html) tag. If you configure both the property and equivalent HTML attribute, then the component will consider the property value.

The following example demonstrates how to set type attribute in the [SfButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html).

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="Submit" title="Primary Button" type="submit"></SfButton>

```


![Blazor Button with HTML Attribute](./../images/blazor-button-with-html.png)
