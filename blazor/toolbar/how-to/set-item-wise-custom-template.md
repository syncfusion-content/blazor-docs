---
layout: post
title: How to set item-wise custom template in Blazor Toolbar | Syncfusion
description: Render custom content per Blazor Toolbar item using the Template property with HTML or RenderFragment.
platform: Blazor
control: Toolbar
documentation: ug
---

# How to set item-wise custom template in Blazor Toolbar

The Blazor Toolbar supports defining custom content for an item using its [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_Template) property, which accepts either an HTML element or a `RenderFragment`.

```cshtml

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLxNcZBpQytmGsS?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Toolbar Item with Custom Template](../images/blazor-toolbar-item-custom-template.webp)" %}