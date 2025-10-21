---
layout: post
title: Style and appearance in Blazor File Upload Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor File Upload component and more.
platform: Blazor
control: File Upload
documentation: ug
---

# Style and appearance in Blazor File Upload Component

The following examples show the CSS selector structure used to customize the File Upload component’s appearance based on user preference. Add these rules after the theme stylesheet so overrides take effect. For scoped styling, wrap the uploader with a custom parent class and prefix selectors to avoid global changes.

## Customizing the appearance of File Upload container element

Use the following CSS to customize the overall File Upload container (control wrapper) size. Adjust width and height to fit the desired layout.

```css
/* To specify height */
.e-upload.e-control-wrapper, .e-bigger.e-small .e-upload.e-control-wrapper {
        height: 300px;
        width: 300px;
}
```

## Customizing the File Upload browse button

Use the following CSS to customize the browse and action buttons (font, size, and colors). Consider adding hover and focus styles that meet contrast requirements for accessibility.

```css
/* To specify font size and color */
.e-upload .e-file-select-wrap .e-btn, .e-upload .e-upload-actions .e-btn, .e-bigger.e-small .e-upload .e-file-select-wrap .e-btn, .e-bigger.e-small .e-upload .e-upload-actions .e-btn {
        font-family: cursive;
        height: 40px;
        background-color: aquamarine;
        color: coral;
}
```

## Customizing the File Upload content

Use the following CSS to customize the drop area text (content) inside the uploader, including font size and color.

```css
/* To specify font size and color */
.e-upload .e-file-select-wrap .e-file-drop, .e-bigger.e-small .e-upload .e-file-select-wrap .e-file-drop {
        font-size: 20px;
        color: aqua;
}
```

## Customizing the uploaded file container in File Upload

Use the following CSS to customize the appearance of the uploaded file list container (for example, background color). To target specific states (success, error, in-progress), add additional selectors as needed.

```css
/* To specify background color */
.e-upload .e-upload-files .e-upload-file-list {
        background-color: beige;
}
```