---
layout: post
title: Overview of the Form Designer in SfPdfViewer for Blazor | Syncfusion
description: Learn about the Form Designer feature in SfPdfViewer for Blazor. Discover how to create, edit, and manage interactive form fields within PDF documents.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Form Designer Overview

The Form Designer in SfPdfViewer enables seamless creation, editing, and management of interactive form fields. It supports dynamic module injection, allowing the designer to be added or removed while updating relevant UI elements. Various form fields, including **Text Box**, **Password**, **Radio Button**, **Check Box**, **Dropdown**, **List Box**, **Signature Field** and **Button**, can be added with custom naming, grouping, and data consistency across pages.

Fields retain properties when downloaded or reloaded, even for large documents. Operations like cut, copy, paste, zoom, and resize function smoothly while maintaining data integrity. Additional features include read-only and required field modes, validation, extensive customization, undo/redo, and form submission controls.

# Supported Form Fields

SfPdfViewer supports a range of interactive form fields for structured and dynamic data collection:

> 1. Textbox 
> 2. Password  
> 3. Check Box
> 4. Radio Button
> 5. List Box
> 6. Drop Down
> 7. Signature Field
> 8. Button Field

These fields ensure seamless interaction, customization, and data consistency, enabling the creation of well-structured and user-friendly PDF forms.

# Form Field Management

The SfPdfViewer enables efficient form field management by supporting opening, saving, and printing PDFs while maintaining field integrity.

# Open the PDF Documents with Interactive Form Fields

SfPdfViewer enables smooth loading of PDFs with interactive form fields, preserving their properties and data. This ensures seamless modifications, validations, and data retention, even in large documents. A saved PDF with form fields can be opened using the Open icon in the toolbar. Refer to the GIF below for details.

![Open PDF Document with Exsiting Form Fileds](form-designer-images/Open_PDF_Document_With_Exsiting_Form_Fileds.gif)

# Saving Form Fields in a PDF Document

SfPdfViewer saves form fields within the PDF without modifying the original file. Selecting the Download icon preserves all field data and properties for future use. Refer to the GIF below for details.

![Download_PDF_Document_With_Form_Fileds](form-designer-images/Download_PDF_Document_With_Form_Fileds.gif)

# Printing Form Fields

SfPdfViewer allows printing PDF documents along with form fields without altering the original file. Selecting the Print icon ensures that all added fields are included in the print output.

To control the **Visibility** of form fields in print mode, the **VisibilityMode** enum provides the following options:

> 1. Visible – The form field is always visible in both the viewer and the printed document.
> 2. Hidden – The form field remains completely hidden in both the viewer and print mode.
> 3. VisibleNotPrintable – The form field appears in the viewer but is excluded from printing.
> 4. HiddenPrintable – The form field is hidden in the viewer but appears in the printed document.

This flexibility ensures precise control over which form fields are displayed or printed as needed. Refer to the GIF below for further details.


Here's an example code snippet demonstrating how to set the VisibilityMode for form fields in SfPdfViewer:

