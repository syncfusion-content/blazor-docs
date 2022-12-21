---
layout: post
title: Tab key navigation Toolbar item in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about how to Tab key navigation toolbar item in Syncfusion Blazor Toolbar component and more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Tab key navigation Toolbar item in Blazor Toolbar Component

The `TabIndex` property of the Toolbar item is used to Tab key navigation when positive values assigned to items , it allows to switch focus to the next/previous taps items with Tab/ShiftTab keys.

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