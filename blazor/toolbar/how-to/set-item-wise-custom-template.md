---
layout: post
title: Set Item-Wise Custom Template in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to set item-wise custom template in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Set Item-Wise Custom Template in Blazor Toolbar Component

The Toolbar supports defining custom content for an item using its `Template` property. The `Template` property accepts either an HTML element or a `RenderFragment`. 

```csharp

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="300">
    <ToolbarItems>
        <ToolbarItem Text="Cut" TooltipText="Cut"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem Text="Paste"></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem>
            <Template>
                <div><input type='checkbox' title="Accept" checked/>
                </div>
            </Template>
        </ToolbarItem>
        <ToolbarItem Text="Undo"></ToolbarItem>
        <ToolbarItem Text="Redo"></ToolbarItem>
        <ToolbarItem>
            <Template>
                <button id="template" class="e-btn">Template</button>
            </Template>
        </ToolbarItem>
    </ToolbarItems>
</SfToolbar>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNBeCZWZqOFgmHpq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Toolbar Item with Custom Template](../images/blazor-toolbar-item-custom-template.png)" %}