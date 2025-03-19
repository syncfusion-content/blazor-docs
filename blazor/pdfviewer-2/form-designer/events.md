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
| **FormFieldPropertyChanged** | Triggered when a form field's properties are modified. |
| **IsDesignerModeChanged** | Triggered when the designer mode state changes in the PDF Viewer. |
| **FormFieldsExporting**   | Triggered before form fields are exported, allowing customization of the export process. |
| **FormFieldsImporting**   | Triggered before form fields are imported, allowing validation or modifications. |
| **FormFieldsExported**    | Triggered when form fields are successfully exported. |
| **FormFieldsImported**    | Triggered when form fields are successfully imported. |
| **FormFieldsExportFailed** | Triggered when form fields export operation fails. |
| **FormFieldsImportFailed** | Triggered when form fields import operation fails. |

### FormFieldAdding Event

[FormFieldAdding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldAdding) event is triggered before a form field addition starts in the SfPdfViewer2 component. Developers can use this event to validate or modify the field before it is inserted into the document.

Additionally, the event provides a Cancel property, which can be set to true to prevent the form field from being added to the document conditionally.

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
        args.Cancel = true; // Prevents the form field from being added
        // Additional processing logic
    }
}

```
By setting args.Cancel = true;, developers can conditionally prevent the addition of form fields based on custom logic.

### FormFieldAdded Event

[FormFieldAdded](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldAdded) event is triggered whenever a new form field is added to the PDF document. It allows developers to monitor the addition of form fields and apply default properties or validations.

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

[FormFieldDeleted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldDeleted) event is triggered when a form field is removed from the document. It can be used to ensure proper cleanup and prevent accidental deletions.

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

[FormFieldClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldClick) is triggered when a user clicks on a form field while designer mode is off. This event can be used to display tooltips, highlight fields, or open settings.

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

[FormFieldDoubleClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldDoubleClick) is triggered when a form field is double-clicked. This event is useful for triggering additional actions.

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

[FormFieldSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldSelected) is triggered when a form field is selected. It can be used to show additional options or highlight the selected field.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldSelected="@OnFormFieldSelected"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldSelected(FormFieldSelectedEventArgs args)
    {
        // Access details about the selected form field
        Console.WriteLine($"Form field selected: {args.Field.Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```

### FormFieldUnselected Event

[FormFieldUnselected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldUnselected) is triggered when a selected form field is unselected. This event helps in resetting UI elements or hiding additional options.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldUnselected="@OnFormFieldUnSelected"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldUnSelected(FormFieldUnselectedEventArgs args)
    {
        // Access details about the unselected form field
        Console.WriteLine($"Form field unselected: {args.Field.Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```
### FormFieldResized Event

[FormFieldResized](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldResized) is triggered when a form field is resized. This event is useful for applying constraints on form field sizes or updating layout dynamically.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldResized="@OnFormFieldResized"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldResized(FormFieldResizedEventArgs args)
    {
        // Access details about the resized form field
        Console.WriteLine($"Form field resized: {args.Field.Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```

### ValidateFormFields Event

[ValidateFormFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_ValidateFormFields) is triggered when form fields are validated before submission, saving, or printing the PDF. It helps ensure that required fields are filled correctly. To trigger this event, the [EnableFormFieldsValidation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableFormFieldsValidation) property must be set to true in the SfPdfViewer2 component.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" EnableFormFieldsValidation="true">
    <PdfViewerEvents ValidateFormFields="@OnFormFieldValidated"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldValidated(ValidateFormFieldsArgs args)
    {
        // Access details about the validated form field
        Console.WriteLine($"Form field Validated: {args.Fields[0].Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```

### FormFieldFocusIn Event

[FormFieldFocusIn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldFocusIn) is triggered when focus enters a form field while designer mode is off. It can be used to provide dynamic styling or suggestions.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" EnableFormFieldsValidation="true">
    <PdfViewerEvents FormFieldFocusIn="@OnFormFieldFocusIn"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldFocusIn(FormFieldFocusInEventArgs args)
    {
        // Access details about the focused in form field
        Console.WriteLine($"Form field focused in: {args.Field.Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```

### FormFieldFocusOut Event

[FormFieldFocusOut](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldFocusOut) is triggered when focus leaves a form field while designer mode is off. It is useful for saving data or performing validation.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" EnableFormFieldsValidation="true">
    <PdfViewerEvents FormFieldFocusOut="@OnFormFieldFocusOut"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldFocusOut(FormFieldFocusOutEventArgs args)
    {
        // Access details about the focused out form field
        Console.WriteLine($"Form field focused out: {args.Field.Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```

### FormFieldMouseEnter Event

[FormFieldMouseEnter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldMouseEnter) is triggered when the mouse enters a form field in the PDF Viewer.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldMouseEnter="@OnFormFieldMouseEnter"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldMouseEnter(FormFieldMouseEnterEventArgs args)
    {
        // Access details about the mouse entered form field
        Console.WriteLine($"Form field Mouse entered: {args.Field.Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```

### FormFieldMouseLeave Event

[FormFieldMouseLeave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldMouseLeave) is triggered when the mouse leaves a form field. It is useful for hiding tooltips or resetting styling.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldMouseLeave="@OnFormFieldMouseLeave"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldMouseLeave(FormFieldMouseLeaveEventArgs args)
    {
        // Access details about the mouse leaved form field
        Console.WriteLine($"Form field Mouse leaved: {args.Field.Name}");

        // Implement additional logic, such as logging or UI updates
    }
}
```

### FormFieldPropertyChanged Event

[FormFieldPropertyChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldPropertyChanged) is triggered when a form field properties are modified. This event helps in tracking changes and dynamically updating UI elements.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldPropertyChanged="@OnFormFieldPropertyChanged"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void OnFormFieldPropertyChanged(FormFieldPropertyChangedEventArgs args)
    {
        // Access details about the property changed form field
        Console.WriteLine($"Form field property changed: {args.NewValue}");

        // Implement additional logic, such as logging or UI updates
    }
}
```

### IsDesignerModeChanged Event

[IsDesignerModeChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_IsDesignerModeChanged) is triggered whenever the designer mode is enabled or disabled in the component. It enables developers to implement custom logic in response to the mode change, such as updating UI elements, logging events, or modifying interactions.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

<SfPdfViewer2 Height="100%" Width="100%" DocumentPath="@DocumentPath" IsDesignerModeChanged="IsDesignerModeChanged">
</SfPdfViewer2>

@code {
    private string DocumentPath = "wwwroot/data/events.pdf";

    void IsDesignerModeChanged(bool args)
    {
        // Check the state of Designer mode
        Console.WriteLine($"Designer mode is: {args}");

        // Implement additional logic, such as logging or UI updates
    }
}
```

### FormFieldsExporting Event

[FormFieldsExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldsExporting) is triggered when the form fields export process starts in the component. It allows customization of the export process or data transformation. The export process can be canceled by setting args.Cancel = true.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.SfPdfViewer;

<SfButton OnClick="ExportFields">Export Form Fields</SfButton>
<SfPdfViewer2 @ref="Viewer" Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldsExporting="OnFormFieldsExporting"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    SfPdfViewer2? Viewer;
    private string DocumentPath = "wwwroot/data/events.pdf";
    Stream JSONStream = new MemoryStream();

    void OnFormFieldsExporting(FormFieldsExportEventArgs args)
    {
        Console.WriteLine($"Form fields are being exported");

        args.Cancel = true; // Cancels the export process

        // Implement additional logic, such as logging or UI updates
    }

    private async void ExportFields()
    {
        // Export form fields as JSON Stream
        if (Viewer != null)
        {
            JSONStream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Json);
        }
    }
}
```

### FormFieldsImporting Event

[FormFieldsImporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldsImporting) is triggered when the form fields import process starts in the component. It allows validation or modification of the import process. The import operation can be canceled by setting args.Cancel = true.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.SfPdfViewer;

<SfButton OnClick="ExportFields">Export Form Fields</SfButton>
<SfButton OnClick="ImportFields">Import Form Fields</SfButton>
<SfPdfViewer2 @ref="Viewer" Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldsImporting="OnFormFieldsImporting"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    SfPdfViewer2? Viewer;
    private string DocumentPath = "wwwroot/data/events.pdf";
    Stream JSONStream = new MemoryStream();

    void OnFormFieldsImporting(FormFieldsImportEventArgs args)
    {
        Console.WriteLine($"Form fields are being imported");

        args.Cancel = true; //cancels the import process

        // Implement additional logic, such as logging or UI updates
    }

    private async void ExportFields()
    {
        // Export form fields as JSON Stream
        if (Viewer != null)
        {
            JSONStream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Json);
        }
    }

    private async void ImportFields()
    {
        // Import form fields as JSON Stream
        if (JSONStream != null && Viewer != null)
        {
            // Import JSON data into the viewer
            await Viewer.ImportFormFieldsAsync(JSONStream, FormFieldDataFormat.Json);
        }
    }
}
```

### FormFieldsExported Event

[FormFieldsExported](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldsExported) is triggered when form fields are successfully exported. It allows for further processing or confirmation.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.SfPdfViewer;

<SfButton OnClick="ExportFields">Export Form Fields</SfButton>
<SfPdfViewer2 @ref="Viewer" Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldsExported="OnFormFieldsExported"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    SfPdfViewer2? Viewer;
    private string DocumentPath = "wwwroot/data/events.pdf";
    Stream JSONStream = new MemoryStream();

    void OnFormFieldsExported(FormFieldsExportedEventArgs args)
    {
        Console.WriteLine($"Form fields are exported Successfully");
        // Implement additional logic, such as logging or UI updates
    }

    private async void ExportFields()
    {
        // Export form fields as JSON Stream
        if (Viewer != null)
        {
            JSONStream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Json);
        }
    }
}
```

### FormFieldsImported Event

[FormFieldsImported](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldsImported) is triggered when form fields are successfully imported into the document. This event is useful for mapping imported fields to existing data.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.SfPdfViewer;

<SfButton OnClick="ExportFields">Export Form Fields</SfButton>
<SfButton OnClick="ImportFields">Import Form Fields</SfButton>
<SfPdfViewer2 @ref="Viewer" Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldsImported="OnFormFieldsImported"></PdfViewerEvents>
</SfPdfViewer2>
@code {
    SfPdfViewer2? Viewer;
    private string DocumentPath = "wwwroot/data/events.pdf";
    Stream JSONStream = new MemoryStream();
    void OnFormFieldsImported(FormFieldsImportedEventArgs args)
    {
        Console.WriteLine($"Form fields are imported Successfully");
        // Implement additional logic, such as logging or UI updates
    }
    private async void ExportFields()
    {
        // Export form fields as JSON Stream
        if (Viewer != null)
        {
            JSONStream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Json);
        }
    }
    private async void ImportFields()
    {
        // Import form fields as JSON Stream
        if (JSONStream != null && Viewer != null)
        {
            // Import JSON data into the viewer
            await Viewer.ImportFormFieldsAsync(JSONStream, FormFieldDataFormat.Json);
        }
    }
}
```

### FormFieldsExportFailed Event

[FormFieldsExportFailed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldsExportFailed) is triggered when form fields export operation fails. This event can be used for error handling and debugging.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.SfPdfViewer;

<SfButton OnClick="ExportFields">Export Form Fields</SfButton>
<SfPdfViewer2 @ref="Viewer" Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldsExportFailed="OnFormFieldsExportFailed"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    SfPdfViewer2? Viewer;
    private string DocumentPath = "wwwroot/data/events.pdf";
    Stream JSONStream = new MemoryStream();

    void OnFormFieldsExportFailed(FormFieldsExportFailedEventArgs args)
    {
        Console.WriteLine($"Form field export is failed: {args.ErrorDetails}");
        // Implement additional logic, such as logging or UI updates
    }

    private async void ExportFields()
    {
        // Export form fields as JSON Stream
        if (Viewer != null)
        {
            JSONStream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Json);
        }
    }
}
```

### FormFieldsImportFailed Event

[FormFieldsImportFailed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerEvents.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerEvents_FormFieldsImportFailed) is triggered when form fields import operation fails. It helps in identifying issues and providing fallback mechanisms.

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.SfPdfViewer;

<SfButton OnClick="ExportFields">Export Form Fields</SfButton>
<SfButton OnClick="ImportFields">Import Form Fields</SfButton>
<SfPdfViewer2 @ref="Viewer" Height="100%" Width="100%" DocumentPath="@DocumentPath">
    <PdfViewerEvents FormFieldsImportFailed="OnFormFieldsImportFailed"></PdfViewerEvents>
</SfPdfViewer2>

@code {
    SfPdfViewer2? Viewer;
    private string DocumentPath = "wwwroot/data/events.pdf";
    Stream JSONStream = new MemoryStream();

    void OnFormFieldsImportFailed(FormFieldsImportFailedEventArgs args)
    {
        Console.WriteLine($"Form field Import is failed: {args.ErrorDetails}");
        // Implement additional logic, such as logging or UI updates
    }

    private async void ExportFields()
    {
        // Export form fields as JSON Stream
        if (Viewer != null)
        {
            JSONStream = await Viewer.ExportFormFieldsAsync(FormFieldDataFormat.Json);
        }
    }

    private async void ImportFields()
    {
        // Import form fields as JSON Stream
        if (JSONStream != null && Viewer != null)
        {
            // Import JSON data into the viewer
            await Viewer.ImportFormFieldsAsync(JSONStream, FormFieldDataFormat.Json);
        }
    }
}
```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/blob/master/Form%20Designer/Components/Pages/Events.razor).

## See also

* [Programmatic Support in Form Designer](./create-programmatically)
* [UI Interactions in Form Designer](./ui-interactions)