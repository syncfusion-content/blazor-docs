---
layout: post
title: Style and Customization in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about Style and Customization in Syncfusion Blazor Mention component and much more.
platform: Blazor
control: Mention
documentation: ug
---

# Style And Customization
 
The **Mention** component provides extensive styling flexibility, allowing you to customize the appearance of the popup and its list items using CSS.  
By applying a custom CSS class, you can override the default styles and align the component with your application’s design requirements.
 
This section explains how to customize the following visual elements:
 
*   Mention popup container
*   Active (focused) list item
*   Hovered list item
*   Clicked (pressed) list item
 
***
 
## Applying a Custom CSS Class
 
To scope the styling changes to a specific Mention component, assign a custom CSS class using the `CssClass` property.
 
```razor
<SfMention CssClass="e-custom" ...>
</SfMention>
```
 
N> All styles demonstrated below are applied only when the `e-custom` class is used.
 
## Customizing the Popup Container
 
The popup container represents the outer shell of the Mention dropdown.  
You can control its border, shape, and shadow by targeting the popup element using the `.e-custom.e-mention.e-popup` selector.
 
```css
/* Styles for the mention popup container with custom appearance */
.e-custom.e-mention.e-popup {
    border: 1px solid #eb3434;
    border-radius: 0;
    box-shadow: 10px 10px 10px rgb(0 0 0 / 12%);
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZLHjJLWfcfFMNUD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
 
**Visual Outcome**
 
*   Adds a custom border around the popup
*   Removes rounded corners for a sharp-edged layout
*   Applies a shadow to visually elevate the popup
 
***
 
## Customizing the Active (Focused) List Item
 
The active list item represents the currently focused option in the popup, typically selected using keyboard navigation or mouse interaction.  
This state can be styled using the `.e-custom .e-dropdownbase .e-list-item.e-active` selector.
 
```css
/* Styles for active list items in the mention dropdown */
.e-custom .e-dropdownbase .e-list-item.e-active {
    background-color: #fd840d;
    color: #fff;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLdtfhifQRBrIIc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Visual Outcome**
 
*   Highlights the focused item with a distinct background color
*   Improves text contrast for better readability
 
***
 
## Customizing the Hover State of List Items
 
The hover state is applied when a user moves the mouse pointer over a list item.  
You can customize both hovered and active‑hovered items using the `.e-hover` and `.e-active.e-hover` combinations.
 
```css
/* Styles for hovered or active-hovered list items */
.e-custom .e-dropdownbase .e-list-item.e-active.e-hover,
.e-custom .e-dropdownbase .e-list-item.e-hover {
    background-color: #fdd20d;
    color: #fff;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDrRXJVCpQxbdRlA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Visual Outcome**
 
*   Provides immediate visual feedback on mouse hover
*   Maintains consistent styling for both hovered and active‑hovered items
 
***
 
## Customizing the Clicked (Pressed) List Item
 
The pressed or clicked state appears when a list item is actively clicked.  
This interaction state can be styled using the `:active` pseudo‑class in combination with active and hover selectors.
 
```css
/* Styles for list items when clicked or in active state */
.e-custom .e-dropdownbase .e-list-item.e-active.e-hover:active,
.e-custom .e-dropdownbase .e-list-item:active {
    background: #cf7600;
    color: greenyellow;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLRjJrMpQwTcocW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Visual Outcome**
 
*   Applies a darker background to indicate a pressed state
*   Differentiates clicked items from hover and focus states
 
***
