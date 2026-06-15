---
layout: post
title: Styles and Appearances in Blazor SplitButton Component | Syncfusion
description: Checkout and learn here all about styles and appearances in Syncfusion Blazor SplitButton component and more.
platform: Blazor
control: Split Button
documentation: ug
---

# Styles and Appearances in Blazor SplitButton Component

To modify the SplitButton appearance, override the component's default CSS. The following table lists key CSS classes and their purposes. To scope changes to a specific instance, add a custom class through the `CssClass` property and target that class in styles. A custom theme can also be created using the [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

## CSS classes

| CSS Class | Purpose |
| ----- | ----- |
| `.e-split-btn-wrapper` | Targets the outer wrapper element that contains both the primary button and the dropdown arrow button. |
| `.e-split-btn` | Targets the primary (left) button part of the SplitButton that displays the label. |
| `.e-dropdown-btn` | Targets the secondary dropdown (right) button that contains the caret arrow icon. |
| `.e-btn-icon.e-caret` | Targets the caret/arrow icon inside the dropdown button. |
| `.e-dropdown-popup` | Targets the popup container that appears when the dropdown arrow is clicked. |
| `.e-dropdown-popup ul .e-item` | Targets individual items in the dropdown popup list. |
| `.e-dropdown-popup ul .e-item .e-menu-icon` | Targets the icon displayed inside each popup menu item. |
| `.e-dropdown-popup ul .e-item:hover` | Targets a popup item in its hovered state. |
| `.e-split-btn.e-active` | Targets the primary button when it is in an active/pressed state. |
| `.e-dropdown-btn.e-active` | Targets the dropdown button when the popup is open (active state). |

## Customizing the SplitButton appearance

### Customizing the primary button

The primary button area of the SplitButton is represented by the `.e-split-btn` CSS class. Use this class to change the background color, font, border, padding, and other visual properties of the main button.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste" CssClass="custom-split">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    .custom-split .e-split-btn {
        background-color: #4a90d9;
        color: #ffffff;
        border-color: #357abd;
        font-weight: 600;
        border-radius: 4px 0 0 4px;
    }

    .custom-split .e-split-btn:hover {
        background-color: #357abd;
        border-color: #2a6099;
    }
</style>
```

### Customizing the dropdown arrow button

The dropdown (caret) button is represented by the `.e-dropdown-btn` class. It can be styled independently from the primary button to create a visual distinction between the two parts.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste" CssClass="custom-split">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    .custom-split .e-dropdown-btn {
        background-color: #357abd;
        color: #ffffff;
        border-color: #2a6099;
        border-radius: 0 4px 4px 0;
    }

    .custom-split .e-dropdown-btn:hover {
        background-color: #2a6099;
    }

    .custom-split .e-btn-icon.e-caret {
        font-size: 12px;
        color: #ffffff;
    }
</style>
```

### Customizing the popup and its items

The popup container is represented by `.e-dropdown-popup` and each menu item within it is represented by `.e-dropdown-popup ul .e-item`. These classes are used to change the popup background, item padding, font, and hover styles.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Paste" CssClass="custom-split">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Cut" IconCss="e-icons e-cut"></DropDownMenuItem>
        <DropDownMenuItem Text="Copy" IconCss="e-icons e-copy"></DropDownMenuItem>
        <DropDownMenuItem Text="Paste" IconCss="e-icons e-paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    .custom-split.e-dropdown-popup {
        background-color: #f5f9ff;
        border: 1px solid #c0d8f0;
        border-radius: 4px;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.12);
    }

    .custom-split.e-dropdown-popup ul .e-item {
        color: #333333;
        padding: 8px 16px;
        font-size: 14px;
    }

    .custom-split.e-dropdown-popup ul .e-item:hover {
        background-color: #ddeeff;
        color: #1a5fa8;
    }

    .custom-split.e-dropdown-popup ul .e-item .e-menu-icon {
        color: #4a90d9;
        margin-right: 8px;
        font-size: 16px;
    }
</style>
```

### Customizing with the CssClass property

The `CssClass` property adds a custom CSS class to the SplitButton's root element, which scopes all style overrides to that specific instance without affecting other SplitButton components on the page.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Download" CssClass="success-split">
    <DropDownMenuItems>
        <DropDownMenuItem Text="PDF"></DropDownMenuItem>
        <DropDownMenuItem Text="Excel"></DropDownMenuItem>
        <DropDownMenuItem Text="CSV"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<SfSplitButton Content="Delete" CssClass="danger-split">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Selected items"></DropDownMenuItem>
        <DropDownMenuItem Text="All items"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    /* Success variant */
    .success-split .e-split-btn,
    .success-split .e-dropdown-btn {
        background-color: #28a745;
        color: #ffffff;
        border-color: #1e7e34;
    }

    .success-split .e-split-btn:hover,
    .success-split .e-dropdown-btn:hover {
        background-color: #1e7e34;
    }

    /* Danger variant */
    .danger-split .e-split-btn,
    .danger-split .e-dropdown-btn {
        background-color: #dc3545;
        color: #ffffff;
        border-color: #bd2130;
    }

    .danger-split .e-split-btn:hover,
    .danger-split .e-dropdown-btn:hover {
        background-color: #bd2130;
    }
</style>
```

### Customizing the font

The font family, font size, font weight, and letter spacing of both the button label and popup items can be customized using CSS. Apply changes to `.e-split-btn` for the primary button text, and to `.e-dropdown-popup ul .e-item` for the popup item text.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Export" CssClass="font-split">
    <DropDownMenuItems>
        <DropDownMenuItem Text="PDF"></DropDownMenuItem>
        <DropDownMenuItem Text="Excel"></DropDownMenuItem>
        <DropDownMenuItem Text="CSV"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    /* Font customization for the primary button label */
    .font-split .e-split-btn {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        font-size: 15px;
        font-weight: 700;
        letter-spacing: 0.5px;
        text-transform: uppercase;
    }

    /* Font customization for popup menu items */
    .font-split.e-dropdown-popup ul .e-item {
        font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        font-size: 14px;
        font-weight: 500;
        letter-spacing: 0.3px;
    }

    /* Font style on hover */
    .font-split.e-dropdown-popup ul .e-item:hover {
        font-weight: 700;
    }
</style>
```

### Customizing the width

The width of the SplitButton's primary button part and the dropdown popup can be set using the `min-width` or `width` properties. Target `.e-split-btn` for the primary button width and `.e-dropdown-popup` for the popup width.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfSplitButton Content="Export" CssClass="width-split">
    <DropDownMenuItems>
        <DropDownMenuItem Text="PDF"></DropDownMenuItem>
        <DropDownMenuItem Text="Excel"></DropDownMenuItem>
        <DropDownMenuItem Text="CSV"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>

<style>
    /* Set a fixed width on the primary button */
    .width-split .e-split-btn {
        min-width: 120px;
        text-align: center;
    }

    /* Set a minimum width on the popup container */
    .width-split.e-dropdown-popup {
        min-width: 160px;
    }

    /* Make popup items fill the full popup width */
    .width-split.e-dropdown-popup ul .e-item {
        width: 100%;
        box-sizing: border-box;
        padding: 8px 16px;
    }
</style>
```