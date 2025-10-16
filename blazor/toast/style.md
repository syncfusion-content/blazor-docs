---
layout: post
title: Style and appearance in Blazor Toast Component | Syncfusion
description: Check out and learn here all about style and appearance in Syncfusion Blazor Toast component and more.
platform: Blazor
control: Toast
documentation: ug
---

# Style and Appearance in Blazor Toast Component

This section describes the CSS structure and selectors used to customize the appearance of the Syncfusion Blazor **Toast** component. For theme options and delivery methods, refer to the Blazor [Themes](https://blazor.syncfusion.com/documentation/appearance/themes) and [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) topics. For an overview of the component, see the [Toast documentation](https://blazor.syncfusion.com/documentation/toast/getting-started).

N> Theme styles may override custom styles. Increase selector specificity or scope by container ID/class as needed.

## Customize the Toast title

Use the following CSS to customize the Toast title properties such as color, font size, and weight.

```css
/* Change title color, font size, and weight */
.e-toast-container .e-toast .e-toast-message .e-toast-title {
    color: #1e293b;       /* example: slate-800 */
    font-size: 18px;
    font-weight: 700;
}
```

Preview of the code snippet: The title text within the Toast message renders in a darker color with a larger font size and bold weight.

## Customize the Toast content

Use the following CSS to customize the Toast content properties such as color, font size, and weight.

```css
/* Change content color, font size, and weight */
.e-toast-container .e-toast .e-toast-message .e-toast-content {
    color: #334155;       /* example: slate-700 */
    font-size: 14px;
    font-weight: 400;
}
```

Preview of the code snippet: The content text within the Toast message displays with the specified color and size, providing a readable contrast from the title.

## Customize the Toast icon

Use the following CSS to customize the default Toast icon color. If a theme rule takes precedence, increase selector specificity or scope by a parent container ID/class.

```css
/* Change icon color */
.e-toast-container .e-toast .e-toast-icon {
    color: #0ea5e9;       /* example: sky-500 */
}
```

Preview of the code snippet: The icon displayed at the start of the Toast message adopts the specified accent color.

## Customize the Toast background

Use the following CSS to customize the Toast background color. Ensure sufficient color contrast with foreground text for accessibility.

```css
/* Change background color */
.e-toast-container .e-toast {
    background-color: #f8fafc;     /* example: slate-50 */
}
```

Preview of the code snippet: The Toast surface renders with a light background, while title and content colors continue to follow their respective rules.

## Scope styles to a specific Toast instance

To style a specific instance without affecting all Toasts, scope the selectors using a container or component ID.

```css
/* Scoped styles for a specific Toast instance */
#toast_custom .e-toast .e-toast-message .e-toast-title {
    color: #16a34a;       /* example: green-600 */
}

#toast_custom .e-toast .e-toast-message .e-toast-content {
    color: #14532d;       /* example: green-900 */
}
```

Preview of the code snippet: Only the Toast inside the element with ID toast_custom applies the scoped title and content styles; other Toast instances retain default or global styles.

See also:
- [Appearance and Themes](https://blazor.syncfusion.com/documentation/appearance/themes)
- [Toast Component Overview](https://blazor.syncfusion.com/documentation/toast/getting-started)