---
layout: post
title: How to Right Left in Blazor Menu Bar  Component | Syncfusion
description: Checkout and learn about Right Left in Blazor Menu Bar  component of Syncfusion, and more details.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Right-To-Left

Menu Bar component has RTL support. This can be achieved by setting [`EnableRtl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Navigations.SfMenu~EnableRtl.html) as `true`.

The following example illustrates how to enable right-to-left support in Menu Bar component.

```csharp
@using Syncfusion.Blazor.Navigations

<SfMenu TValue="MenuItem" EnableRtl="true">
    <MenuItems>
        <MenuItem Text="File">
            <MenuItems>
                <MenuItem Text="Open"></MenuItem>
                <MenuItem Text="Save"></MenuItem>
                <MenuItem Text="Exit"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Edit">
            <MenuItems>
                <MenuItem Text="Cut"></MenuItem>
                <MenuItem Text="Copy"></MenuItem>
                <MenuItem Text="Paste"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="View">
            <MenuItems>
                <MenuItem Text="Toolbar"></MenuItem>
                <MenuItem Text="Sidebar"></MenuItem>
                <MenuItem Text="Full Screen"></MenuItem>
            </MenuItems>
        </MenuItem>
        <MenuItem Text="Tools">
            <MenuItems>
                <MenuItem Text="Spelling & Grammer"></MenuItem>
                <MenuItem Text="Customize"></MenuItem>
                <MenuItem Text="Options"></MenuItem>
            </MenuItems>
        </MenuItem>
    </MenuItems>
</SfMenu>

```

Output be like

![Menu Sample](./../images/rtl.png)