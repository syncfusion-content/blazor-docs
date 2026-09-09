---
layout: post
title: Popup Settings in Blazor Menu | Syncfusion®
description: Configure the Blazor Menu popup rendering using the AppendTo property to control where the popup appears, ensuring proper display in custom containers.
platform: Blazor
control: Menu
documentation: ug
---

# Popup Settings in Blazor Menu

## Render popup in a custom container

Use the `AppendTo` property to render the Menu popup inside a specific container instead of the default `document.body`. This is useful when the component is placed inside dialogs, side panels, containers with overflow restrictions, or custom stacking contexts.

Specify a valid CSS selector in the `AppendTo` property. When the selector matches an element, the popup is appended to that element. If the selector is null, empty, or no matching element is found, the popup is rendered in the default location.

{% highlight cshtml %}

@using Syncfusion.Blazor.Navigations

<div id="popupHost">
    <SfMenu TValue="MenuItem" AppendTo="@AppendTarget">
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
                    <MenuItem Text="Toolbars"></MenuItem>
                    <MenuItem Text="Zoom"></MenuItem>
                    <MenuItem Text="Full Screen"></MenuItem>
                </MenuItems>
            </MenuItem>
            <MenuItem Text="Tools">
                <MenuItems>
                    <MenuItem Text="Spelling & Grammar"></MenuItem>
                    <MenuItem Text="Customize"></MenuItem>
                    <MenuItem Text="Options"></MenuItem>
                </MenuItems>
            </MenuItem>
            <MenuItem Text="Go"></MenuItem>
            <MenuItem Text="Help"></MenuItem>
        </MenuItems>
    </SfMenu>
</div>

@code {
    private string AppendTarget = "#popupHost";
}

{% endhighlight %}

> The `AppendTo` property accepts a CSS selector such as `#elementId` or `.container`. If the specified element is not found, the popup element will be appended to `document.body`.
