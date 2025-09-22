---
layout: post
title: File Upload Customization in Blazor File Upload Component | Syncfusion
description: Learn how to customize the appearance of the Syncfusion Blazor File Upload component using custom CSS style.
platform: Blazor
control: File Upload
documentation: ug
---

# File Uploader Customization in Blazor

The following content provides the exact CSS structure that can be used to modify the control’s appearance based on the user preference.

## CssClass Property

The File Upload component allows you to add a custom CSS class to its wrapper element using the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfUploader.html#Syncfusion_Blazor_Inputs_SfUploader_CssClass) property. This approach helps scope customizations and prevents unintended global style changes.

```csharp
@using Syncfusion.Blazor.Inputs

<SfUploader CssClass="e-custom-uploader"></SfUploader>
```

By using the `e-custom-uploader` class, you can target specific elements within the File Upload component.

## Customizing the Container

To modify the container element of the File Upload, use the following CSS selector.

```css
/* To specify a custom height and width */
.e-upload.e-control-wrapper {
    height: 300px;
    width: 300px;
}
```

## Customizing the Browse Button

To customize the browse button, use the CSS selector below.

```css
/* To specify font styles, background, and color */
.e-upload .e-file-select-wrap .e-btn {
    font-family: 'cursive';
    height: 40px;
    background-color: aquamarine;
    color: coral;
}
```

## Customizing the Content Area

The drop area content can be customized using the following CSS.

```css
/* To specify font size and color */
.e-upload .e-file-select-wrap .e-file-drop {
    font-size: 20px;
    color: aqua;
}
```

## Customizing the File List

To change the appearance of the uploaded file list container, apply the following styles.

```css
/* To specify a background color */
.e-upload .e-upload-files .e-upload-file-list {
    background-color: beige;
}
```

## Customizing the Progress Bar

You can customize the progress bar and its text using the CSS selectors below.

```css
/* To specify the background color of the progress bar */
.e-upload .e-upload-files .e-upload-progress-wrap .e-upload-progress-bar {
    background: green;
}

/* To specify the color of the progress bar text */
.e-upload .e-upload-files .e-upload-progress-wrap .e-progress-bar-text {
    color: #288928;
    font-weight: bold;
}
```

## See Also

* [How to create a responsive, full-height file uploader](https://support.syncfusion.com/kb/article/21232/how-to-create-a-responsive-full-height-file-uploader-in-blazor)
* [How to customize button text](https://support.syncfusion.com/kb/article/17457/customizing-button-text-in-blazor-file-upload-component)
* [How to center the Clear and Upload buttons](https://support.syncfusion.com/kb/article/17534/how-to-center-the-clear-and-upload-buttons-in-blazor-file-upload)
* [How to customize the tooltip for the browse button](https://support.syncfusion.com/kb/article/16150/how-to-customize-tooltip-for-browse-button-in-blazor-file-upload)
