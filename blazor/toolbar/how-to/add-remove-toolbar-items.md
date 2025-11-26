---
layout: post
title: Add/Remove Toolbar Items in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to add or remove Toolbar items in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Add/Remove Toolbar Items in Blazor Toolbar Component

Toolbar items can be added or removed dynamically by updating the underlying data collection, which is then iterated to render the Toolbar component.

In the following demo, the `ToolbarItems` collection initially contains five items, resulting in five toolbar items being rendered. Clicking the `Add Item` button adds a new item to the `ToolbarItems` collection, which then renders as a sixth toolbar item in the Toolbar component. Clicking the `Remove Item` button removes the first item from the `ToolbarItems` collection, consequently removing the first toolbar item from the Toolbar component.

```csharp

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="AddItemClick" Content="Add Item"></SfButton>
<SfButton @onclick="RemoveItemClick" Content="Remove Item"></SfButton>
<br />
<br />

<SfToolbar>
    <ToolbarItems>
        @foreach (ToolbarData Item in ToolbarItems)
        {
            <ToolbarItem PrefixIcon=@(Item.PrefixIcon) Text=@(Item.Text) TooltipText=@(Item.TooltipText)></ToolbarItem>
        }
    </ToolbarItems>
</SfToolbar>

@code {
    public class ToolbarData
    {
        public string PrefixIcon { get; set; }
        public string Text { get; set; }
        public string TooltipText { get; set; }
    }
    List<ToolbarData> ToolbarItems = new List<ToolbarData>()
    {
        new ToolbarData
        {
        PrefixIcon = "e-icons e-cut",
        Text = "Cut",
        TooltipText = "Cut"
        },
        new ToolbarData
        {
        PrefixIcon = "e-icons e-copy",
        Text = "Copy",
        TooltipText = "Copy"
        },
        new ToolbarData
        {
        PrefixIcon = "e-icons e-paste",
        Text = "Paste",
        TooltipText = "Paste"
        },
        new ToolbarData
        {
        PrefixIcon = "e-icons e-bold",
        Text = "Bold",
        TooltipText = "Bold"
        },
        new ToolbarData
        {
        PrefixIcon = "e-icons e-underline",
        Text = "Underline",
        TooltipText = "Underline"
        }
    };
    void AddItemClick()
    {
        ToolbarItems.Add(new ToolbarData
        {
            PrefixIcon = "e-icons e-italic",
            Text = "Italic",
            TooltipText = "Italic"
        });
    }
    void RemoveItemClick()
    {
        if (ToolbarItems.Count > 0)
        {
            ToolbarItems.RemoveAt(0);
        }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDheWZitquTDHMDs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Adding or Removing Blazor Toolbar Items](../images/blazor-toolbar-add-or-remove-item.gif)" %}