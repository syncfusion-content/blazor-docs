---
layout: post
title: Tab key navigation in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to Tab key navigation toolbar item in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Enabling Tab key navigation in Blazor Toolbar Component

The [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) property of a Toolbar item is used to enable tab key navigation for the item. By default, the user can switch between items using the arrow keys, but the `TabIndex` property allows you to switch between items using the Tab and Shift+Tab keys as well.

To use the [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) property, you need to set it for each Toolbar item that you want to enable tab key navigation. The [TabIndex] property should be set to a positive integer value. A value of 0 or a negative value will disable tab key navigation for the item.

For example, to enable tab key navigation for two Toolbar items, you can use the following code:

```csharp

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="600">
    <ToolbarItems>
        <ToolbarItem SuffixIcon="e-icons e-cut" Text="Cut" TabIndex=1 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-copy" Text="Copy" TabIndex=2 ></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

With the above code, the user can switch between the two Toolbar items using the Tab and Shift+Tab keys, in addition to using the arrow keys. The items will be navigated in the order specified by the [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) values.

If you set the  [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) value to 0 for all Toolbar items, tab key navigation will be based on the element order rather than the [TabIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.ToolbarItem.html#Syncfusion_Blazor_Navigations_ToolbarItem_TabIndex) values. For example:

```csharp

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="600">
    <ToolbarItems>
        <ToolbarItem SuffixIcon="e-icons e-cut" Text="Cut" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-copy" Text="Copy" TabIndex=0 ></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

```csharp

@using Syncfusion.Blazor.Navigations

<SfToolbar Width="600">
    <ToolbarItems>
        <ToolbarItem SuffixIcon="e-icons e-cut" Text="Cut" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-copy" Text="Copy" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-paste" Text="Paste" TabIndex=0></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-bold" Text="Bold" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-underline" Text="Underline" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-italic" Text="Italic" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-paint-bucket" Text="Color-Picker" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-list-unordered" Text="Bullets" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-list-ordered" Text="Numbering" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-sort-ascending" Text="Sort A - Z" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-sort-descending" Text="Sort Z - A" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-upload-1" Text="Upload" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-download" Text="Download" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-increase-indent" Text="Text Indent" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-decrease-indent" Text="Text Outdent" TabIndex=0 ></ToolbarItem>
        <ToolbarItem Type="ItemType.Separator"></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-erase" Text="Clear" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-refresh" Text="Reload" TabIndex=0 ></ToolbarItem>
        <ToolbarItem SuffixIcon="e-icons e-export" Text="Export" TabIndex=0 ></ToolbarItem>
    </ToolbarItems>
</SfToolbar>
```

![Blazor Toolbar with TabIndex](../images/blazor-toolbar-item-tabindex.gif)