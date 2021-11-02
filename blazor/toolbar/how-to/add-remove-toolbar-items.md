---
layout: post
title: Add/Remove Toolbar items in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to add or remove Toolbar items in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Add/Remove Toolbar items in Blazor Toolbar Component

Toolbar items can be added or removed dynamically by iteration of Toolbar Items using conditional **foreach** loop.

In the following demo, initially there are five toolbar as the **ToolbarItems** has five items. On clicking the `Add Item` button, a new item is added to the **ToolbarItems** results in adding sixth toolbar to the Toolbar component. On clicking the `Remove Item`, the first item of the **ToolbarItems** has been removed which results in removing the first toolbar of the Toolbar component.

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

![Adding or Removing Blazor Toolbar Items](../images/blazor-toolbar-add-or-remove-item.gif)