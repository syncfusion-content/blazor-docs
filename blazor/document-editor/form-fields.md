---
layout: post
title: Form fields in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about Form fields in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Form Fields in Blazor DocumentEditor Component

[`Blazor Word Processor`](https://www.syncfusion.com/blazor-components/blazor-word-processor) component (a.k.a Document Editor) component provide support for inserting Text, CheckBox, DropDown form fields through in-built toolbar.

![Form Fields](images/toolbar-form-fields.png)

## Insert form field

Form fields can be inserted using [`InsertFormFieldAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertFormFieldAsync_Syncfusion_Blazor_DocumentEditor_FormFieldType_) method in editor module.

```csharp
//Insert Text form field
container.DocumentEditor.Editor.InsertFormFieldAsync(FormFieldType.Text);
//Insert Checkbox form field
container.DocumentEditor.Editor.InsertFormFieldAsync(FormFieldType.CheckBox);
//Insert Drop down form field
container.DocumentEditor.Editor.InsertFormFieldAsync(FormFieldType.DropDown);
```

## Get form field names

All the form fields names form current document can be retrieved using `GetFormFieldNamesAsync()`.

```csharp
Task<List<string>> formFieldsNames = container.DocumentEditor.GetFormFieldNamesAsync();
```

## Export form field data

Data of the all the Form fields in the document can be exported using [`ExportFormDataAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_ExportFormDataAsync).

```csharp
Task<List<FormFieldData>> formFieldDatas=container.DocumentEditor.ExportFormDataAsync();
```

## Import form field data

Form fields can be pre-filled with data using [`ImportFormDataAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_ImportFormDataAsync_System_Collections_Generic_List_Syncfusion_Blazor_DocumentEditor_FormFieldData__).

```csharp
FormFieldData textformField = new FormFieldData();
textformField.FieldName = "Text1";
textformField.Value = "Hello World";
FormFieldData checkformField = new FormFieldData();
checkformField.FieldName = "Check1";
checkformField.Value = true;
FormFieldData dropdownformField = new FormFieldData();
dropdownformField.FieldName = "Drop1";
dropdownformField.Value = 1;
   
List<FormFieldData> formData = new List<FormFieldData>();
formData.Add(textformField);
formData.Add(checkformField);
formData.Add(dropdownformField);
//import form field data
container.DocumentEditor.ImportFormDataAsync(formData);
```

## Reset form fields

Reset all the form fields in current document to default value using [`ResetFormFieldsAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.SfDocumentEditor.html#Syncfusion_Blazor_DocumentEditor_SfDocumentEditor_ResetFormFieldsAsync_System_String_).

```csharp
container.DocumentEditor.ResetFormFieldsAsync();
```

## Protect and unprotect document programmatically

Document editor provides an option to protect and unprotect document using [`EnforceProtectionAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_EnforceProtectionAsync_System_String_Syncfusion_Blazor_DocumentEditor_ProtectionType_) and [`StopProtectionAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_StopProtectionAsync_System_String_) API.

The following example code illustrates how to enforce and stop protection in Document editor container.

```csharp
@using Syncfusion.Blazor.DocumentEditor

<button @onclick="protectDocument">Protection</button>
<SfDocumentEditorContainer @ref="container" EnableToolbar=true></SfDocumentEditorContainer>

@code {

    SfDocumentEditorContainer container;
    protected void protectDocument(object args)
    {
        //enforce protection
        container.DocumentEditor.Editor.EnforceProtectionAsync("123", ProtectionType.FormFieldsOnly);
        //stop the document protection
        container.DocumentEditor.Editor.StopProtectionAsync("123");
    }
}
```

>Note: In enforce Protection method, first parameter denotes password and second parameter denotes protection type. Possible values of protection type are `NoProtection |ReadOnly |FormFieldsOnly`. In stop protection method, parameter denotes the password.