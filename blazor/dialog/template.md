---
layout: post
title: Templates in Blazor Dialog Component | Syncfusion
description: Checkout and learn here all about Templates in Syncfusion Blazor Dialog component and much more details.
platform: Blazor
control: Dialog
documentation: ug
---

# Templates in Blazor Dialog Component

The [Blazor Dialog](https://www.syncfusion.com/blazor-components/blazor-modal-dialog) component provides comprehensive template support for header, content, and footer sections. This feature enables developers to create highly customized dialog experiences by incorporating custom HTML content, interactive components, and dynamic data binding within each section.

Templates offer flexibility to transform standard dialogs into rich, interactive user interfaces that can include forms, multimedia content, custom styling, and complex layouts tailored to specific application requirements.

To get started quickly with templates in Blazor Dialog Component, you can check the video below.

{% youtube "https://www.youtube.com/watch?v=K5o9JWbgjvQ" %}

## Header Template

The Dialog header content can be customized through the `Header` property within the `DialogTemplates` section. This property accepts both plain text and HTML content, allowing for rich header designs including icons, images, user information, and custom styling.

## Content Template

The Dialog content area supports extensive customization through the `Content` property within the `DialogTemplates` section. This section can accommodate any HTML content, including forms, media elements, data grids, charts, and other Blazor components.

## Footer Template

The Dialog footer can be customized using either built-in `DialogButton` components or custom HTML through the `FooterTemplate` property. These approaches are mutually exclusive and cannot be used simultaneously within the same dialog instance.

N> The `DialogButton` and `FooterTemplate` properties cannot be used together. Choose the approach that best fits the dialog's functional requirements.


{% previewsample "https://blazorplayground.syncfusion.com/embed/LXheXvMrAnOYVzla?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5"  %}

![Blazor Dialog Component with customized header featuring user avatar and footer template with input controls](./images/blazor-dialog-header-footer-template.png)

## See also

* [How to add an icon to dialog buttons](./how-to/add-an-icons-to-dialog-buttons)
* [How to customize the dialog appearance](./how-to/customize-the-dialog-appearance)