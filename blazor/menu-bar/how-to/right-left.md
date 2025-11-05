---
layout: post
title: Right to Left in Blazor Menu Bar Component | Syncfusion
description: Checkout and learn here all about right to left in Syncfusion Blazor Menu Bar component and much more.
platform: Blazor
control: Menu Bar 
documentation: ug
---

# Right to Left in Blazor Menu Bar Component

Menu Bar component has RTL support. This can be achieved by setting [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Navigations.SfMenu~EnableRtl.html) as `true`.

The following example illustrates how to enable right-to-left support in Menu Bar component.

```cshtml
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

![Right to Left in Blazor MenuBar](./../images/blazor-menubar-right-to-left.png)