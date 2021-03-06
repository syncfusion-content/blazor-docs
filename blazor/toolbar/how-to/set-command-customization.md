---
layout: post
title: Set command customization in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to set command customization in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Set command customization in Blazor Toolbar Component

The `HtmlAttributes` property of the Toolbar item is used to set the HTML attributes ('ID', 'class', 'style' ,'role') for the commands.

When style attributes are added, if the same attributes were already present, they will be replaced. This is not so in the case of `class` attribute. Classes will be added to the element instead of replacing the existing ones.

Single or multiple CSS classes can be added to the Toolbar commands using the Toolbar item `CssClass` property.

```csharp

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="500">
    <ToolbarItems>
        <ToolbarItem Text="Bold" Type="ItemType.Button" HtmlAttributes="@Item1"></ToolbarItem>
        <ToolbarItem Text="Italic" Type="ItemType.Button"></ToolbarItem>
        <ToolbarItem Type="ItemType.Button" Text="Underline"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Text="Uppercase" CssClass="e-txt-casing"></ToolbarItem>
    </ToolbarItems>
</SfToolbar>

@code {
   Dictionary<string, object> Item1 = new Dictionary<string, object>()
    {
        { "class" , "custom_bold" },
        { "id" , "itemId" }
    };
 }

 <style>
    .custom_bold .e-tbar-btn-text {
        font-weight: 900;
    }

    .e-txt-casing .e-tbar-btn-text {
        font-variant: small-caps;
    }
</style>

```

![Blazor Toolbar with Custom Command](../images/blazor-toolbar-custom-command.png)