---
layout: post
title: HTML Attribute Support in Blazor Button Component | Syncfusion
description: Checkout and learn here all about HTML Attribute Support in Syncfusion Blazor Button component and more.
platform: Blazor
control: Button
documentation: ug
---

# HTML Attribute Support in Blazor Button Component

You can add additional HTML attributes such as `type`, `disabled`, `title`, `id`, `name`, and `aria-*` directly on the [SfButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html) tag. These attributes are passed to the underlying native button element. If both a component property and an equivalent HTML attribute are set, the component property value takes precedence.

Common scenarios include:
- Setting the `type` attribute for form behavior (`submit`, `button`, `reset`)
- Adding a `title` attribute for a native tooltip
- Providing `aria-*` attributes for accessibility
- Using `id` and `name` for form integration and testing
- Controlling the disabled state (prefer the `Disabled` property for consistent behavior)

The following example demonstrates setting the `type` attribute on the [SfButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html).

```csharp

@using Syncfusion.Blazor.Buttons

<SfButton Content="Submit" title="Primary Button" type="submit"></SfButton>

```

![Blazor Button with HTML title and type attributes](./../images/blazor-button-with-html.png)