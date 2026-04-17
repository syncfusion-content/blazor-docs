### layout: post
---
title: Style and Appearance in Blazor DataForm Component | Syncfusion
description: Checkout and learn here all about Style and Appearance in Syncfusion Blazor DataForm component and more.
platform: Blazor
control: DataForm
documentation: ug
---

## Style and Appearance in Blazor DataForm Component

The following content provides the exact CSS structure that can be used to modify the DataForm control’s appearance based on the user preference.

### Customizing DataForm container

Use the following CSS to customize the DataForm container.

```css
.e-data-form {
    border: 2px solid #6366f1;
    border-radius: 8px;
    padding: 16px;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLRNJWxUprJdtOR?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor DataForm border](./images/blazor-dataform-border.webp)" %}

### Customizing DataForm label text

Use the following CSS to customize the label text of form fields.

```css
.e-data-form .e-form-label {
    font-weight: 500;
    color: #374151;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLnZTWxURwbFzex?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor DataForm lable](./images/blazor-dataform-lable.webp)" %}

### Customizing DataForm input elements

Use the following CSS to customize input elements inside the DataForm.

```css
.e-data-form .e-input-group.e-control-container {
    border-radius: 6px;
    border-color: #47c80c;
    border-bottom-color: #47c80c !important;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBdtfWngvDdHjkY?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor DataForm input elements](./images/blazor-dataform-inputelements.webp)" %}

### Customizing validation message

Use the following CSS to customize validation message styles.

```css
.e-data-form .validation-message {
    color: #ab1010;
    font-size: 12px;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhnDpiHfhzDDrZt?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor DataForm validation message](./images/blazor-dataform-validation-msg.webp)" %}

### Customizing DataForm action buttons

Use the following CSS to customize action buttons in DataForm.

```css
.e-data-form .e-control.e-btn.e-lib{
    background-color: #6366f1;
    border-color: #6366f1;
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBRZpWHfKgMTRYr?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor DataForm action button](./images/blazor-dataform-action-btn.webp)" %}