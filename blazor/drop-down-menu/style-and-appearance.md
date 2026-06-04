---
layout: post
title: Styles and Appearances in Blazor Dropdown Menu Component | Syncfusion
description: Checkout and learn here all about Styles and Appearances in Syncfusion Blazor Dropdown Menu component and more.
platform: Blazor
control: Dropdown Menu
documentation: ug
---

# Styles and Appearances in Blazor Dropdown Menu Component

To modify the appearance of the DropDownButton, override the component’s default CSS. The following CSS classes target the button and popup elements in different states. Custom styles can be added to the application’s stylesheet. Alternatively, create a custom theme using [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=bootstrap5).

## CSS Classes for Customization

| CSS class | Purpose |
|-----|-----|
| .e-dropdown-btn | Customize the dropdown button. |
| .e-dropdown-btn:hover | Customize the dropdown button on hover. |
| .e-dropdown-btn.e-active | Customize the dropdown button in the active state. |
| .e-dropdown-popup | Customize the dropdown popup. |
| .e-dropdown-popup ul .e-item:hover | Customize popup items on hover. |
| .e-dropdown-popup ul .e-item:active | Customize popup items in the active state. |

## Disable a Dropdown Menu

The Dropdown Menu component can be disabled by setting the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfDropDownButton.html#Syncfusion_Blazor_SplitButtons_SfDropDownButton_Disabled) property. When the Disabled property is set to `true`, the dropdown button becomes non-interactive, preventing users from opening the menu or performing any actions. This is useful in scenarios where you need to temporarily disable certain UI elements based on application state or user permissions.

The disabled state provides visual feedback to users that the button is not available for interaction. When disabled, the button typically displays reduced opacity or a grayed-out appearance, making it clear that the action cannot be performed.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton Disabled="true" Content="Message">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Edit"></DropDownMenuItem>
        <DropDownMenuItem Text="Delete"></DropDownMenuItem>
        <DropDownMenuItem Text="Mark as Read"></DropDownMenuItem>
        <DropDownMenuItem Text="Like Message"></DropDownMenuItem>
    </DropDownMenuItems>
</SfDropDownButton>
```

![Disabled state of Blazor DropDownMenu](./../images/blazor-dropdownmenu-in-disable-state.webp)

## Create Dropdown Menu with Rounded Corner

Dropdown Menu with rounded corner can be achieved by adding the `border-radius` CSS property to the button element. The rounded corner design can enhance the visual appearance of your dropdown menu and align it with modern UI design patterns. This styling approach provides a polished and contemporary look to your application.

In the following example, the `e-round-corner` class sets a `5px` `border-radius`, which is applied to the DropDownButton via the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfDropDownButton.html#Syncfusion_Blazor_SplitButtons_SfDropDownButton_CssClass) property. Adjust the radius value as needed to align with your design system and brand guidelines. You can also apply similar styling to `.e-dropdown-popup` if you want the menu panel to share the same rounded appearance for a consistent visual experience.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton CssClass="e-round-corner" Content="Clipboard">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Edit"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfDropDownButton>

<style>
    .e-round-corner {
        border-radius: 5px;
    }
</style>
```

![Blazor DropDownMenu with Rounded Corner](./../images/blazor-dropdownmenu-with-rounded-corner.webp)