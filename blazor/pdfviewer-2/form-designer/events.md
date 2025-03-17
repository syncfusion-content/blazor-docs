---
layout: post
title: Form Designer events in SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about events in form Designer in Syncfusion Blazor SfPdfViewer component and much more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Form Designer Events in Blazor PDF Viewer
The Blazor PDF Viewer provides built-in support for handling form field-related events through the Form Designer feature. These events allow developers to track and customize the behavior of form fields, such as adding, removing, selecting, resizing, and modifying properties.

## Event List
Below are the key events provided by the Form Designer to handle form field interactions in the PDF Viewer.

| Event Name                | Description |
|---------------------------|-------------|
| **FormFieldAdding**       | Triggered before a new form field is added, allowing validation or modifications before insertion. |
| **FormFieldAdded**        | Triggered when a form field is added to the PDF document. |
| **FormFieldDeleted**      | Triggered when a form field is removed from the document. |
| **FormFieldClick**        | Triggered when a user clicks on a form field while designer mode is off. |
| **FormFieldDoubleClick**  | Triggered when a form field is double-clicked. |
| **FormFieldSelected**     | Triggered when a form field is selected. |
| **FormFieldUnselected**   | Triggered when a form field is unselected. |
| **FormFieldResized**      | Triggered when a form field is resized. |
| **ValidateFormFields**    | Triggered when form fields are validated. |
| **FormFieldFocusIn**      | Triggered when focus enters a form field. |
| **FormFieldFocusOut**     | Triggered when focus leaves a form field. |
| **FormFieldMouseEnter**   | Triggered when the mouse hovers over a form field. |
| **FormFieldMouseLeave**   | Triggered when the mouse leaves a form field. |
| **FormFieldsExporting**   | Triggered before form fields are exported, allowing customization of the export process. |
| **FormFieldsImporting**   | Triggered before form fields are imported, allowing validation or modifications. |
| **FormFieldsExported**    | Triggered when form fields are successfully exported. |
| **FormFieldsImported**    | Triggered when form fields are successfully imported. |
| **FormFieldsExportFailed** | Triggered when form fields export operation fails. |
| **FormFieldsImportFailed** | Triggered when form fields import operation fails. |
| **FormFieldPropertyChanged** | Triggered when a form field's properties are modified. |
| **IsDesignerModeChanged** | Triggered when the designer mode state changes in the PDF Viewer. |

### FormFieldAdding Event

This event is triggered before a form field addition starts in the SfPdfViewer2 component. Developers can use this event to validate or modify the field before it is inserted into the document.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldAdding="@OnFormFieldAdding"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";
    void OnFormFieldAdding(FormFieldAddEventArgs args)
    {
        // Access details about the adding form field
        Console.WriteLine($"Form Field being added: {args.Field.Name}");
        // Additional processing logic
    }
}

```

### FormFieldAdded Event

This event is triggered whenever a new form field is added to the PDF document. It allows developers to monitor the addition of form fields and apply default properties or validations.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldAdded="@OnFormFieldAdded"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";
    void OnFormFieldAdded(FormFieldAddedEventArgs args)
    {
        // Access details about the added form field
        Console.WriteLine($"Form Field added: {args.Field.Name}");
        // Additional processing logic
    }
}
```

### FormFieldDeleted Event

This event occurs when a form field is removed from the document. It can be used to ensure proper cleanup and prevent accidental deletions.
```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldDeleted="@OnFormFieldDeleted"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldDeleted(FormFieldDeletedEventArgs args)
    {
        // Access details about the deleted form field
        Console.WriteLine($"Form field deleted: {args.Field.Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```
### FormFieldClick Event

Triggered when a user clicks on a form field while designer mode is off. This event can be used to display tooltips, highlight fields, or open settings.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldClick="@OnFormFieldClicked"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";
    void OnFormFieldClicked(FormFieldClickArgs args)
    {
        // Access details about the clicked form field
        Console.WriteLine($"Form Field clicked: {args.FormField.Name}");
        // Additional processing logic
    }
}
```
### FormFieldDoubleClick Event

Occurs when a form field is double-clicked. This event is useful for opening detailed property editors or triggering additional actions.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldDoubleClick="@OnFormFieldDoubleClicked"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldDoubleClicked(FormFieldDoubleClickEventArgs args)
    {
        // Access details about the double clicked form field
        Console.WriteLine($"Form field double clicked: {args.Field.Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```
### FormFieldSelected Event

This event is triggered when a form field is selected. It can be used to show additional options or highlight the selected field.

```cshtml

```

### FormFieldUnselected Event

Triggered when a selected form field is unselected. This event helps in resetting UI elements or hiding additional options.

```cshtml

```
### FormFieldResized Event

Fires when a form field is resized. This event is useful for applying constraints on form field sizes or updating layout dynamically.

```cshtml

```

### ValidateFormFields Event

Occurs when form fields are validated before submission. This event can be used to check for required fields and input correctness.

```cshtml

```

### FormFieldFocusIn Event

Triggered when focus enters a form field. It can be used to provide dynamic styling or suggestions.

```cshtml

```

### FormFieldFocusOut Event

Occurs when focus leaves a form field. This event is useful for saving data or performing validation.

```cshtml

```

### FormFieldMouseEnter Event

The FormFieldMouseEnter event triggers when the mouse enters a form field in the PDF Viewer.

```cshtml

```

### FormFieldMouseLeave Event

Occurs when the mouse leaves a form field. This event is useful for hiding tooltips or resetting styling.

```cshtml

```

### FormFieldsExporting Event

Triggered before form fields are exported. It allows customization of the export process or data transformation.

```cshtml

```

### FormFieldsImporting Event

Triggered before form fields are imported into the document. This event allows validation or modification of the import process.

```cshtml

```

### FormFieldsExported Event

Triggered when form fields are successfully exported. It allows for further processing or confirmation.

```cshtml

```

### FormFieldsImported Event

Occurs when form fields are successfully imported into the document. This event is useful for mapping imported fields to existing data.

```cshtml

```

### FormFieldsExportFailed Event

Fired when form fields export operation fails. This event can be used for error handling and debugging.

```cshtml

```

### FormFieldsImportFailed Event

Triggered when form fields import operation fails. It helps in identifying issues and providing fallback mechanisms.

```cshtml

```

### FormFieldPropertyChanged Event

Fires when a form field's properties are modified. This event helps in tracking changes and dynamically updating UI elements.

```cshtml

```

### IsDesignerModeChanged Event

This event occurs whenever the designer mode is enabled or disabled in the SfPdfViewer2 component. It enables developers to implement custom logic in response to the mode change, such as updating UI elements, logging events, or modifying interactions.

```cshtml

```
