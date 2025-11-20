---
layout: post
title: Set Items Customization in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to set Items customization in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Set Items Customization in Blazor Toolbar Component

The `HtmlAttributes` property of a Toolbar item sets HTML attributes (such as `id`, `class`, `style`, and `role`) for its associated elements.

When `style` attributes are added, if existing `style` attributes are present, the new ones will replace them. This behavior differs for the `class` attribute; new classes are added to the element without replacing existing ones.

Single or multiple CSS classes can be applied to Toolbar items using the `ToolbarItem`'s `CssClass` property.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLeWXiDguQHpcdp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Toolbar with Custom Items](../images/blazor-toolbar-custom-command.png)" %}