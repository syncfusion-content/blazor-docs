---
layout: post
title: Fields in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about the fields in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Fields in Blazor DocumentEditor Component

Document Editor has preservation support for all types of fields in an existing word document without any data loss.

## Adding Fields

You can add a field to the document by using `InsertFieldAsync` method in `EditorModule`.

The following example code illustrates how to insert merge field programmatically by providing the field code and field result.

```csharp
string fieldCode = 'MERGEFIELD  First Name  \\* MERGEFORMAT ';
string fieldResult = '«First Name»';
container.DocumentEditor.Editor.InsertFieldAsync(fieldCode, fieldResult);
```

>Note: Document editor does not validate/process the field code/field result. it simply inserts the field with specified field information.

## Update fields

Document Editor provides support for updating bookmark cross reference field. The following example code illustrates how to update bookmark cross reference field.

```csharp
//Update all the bookmark cross reference field in the document.
container.DocumentEditor.updateFieldsAsync();
```

Bookmark cross reference fields can be updated through UI by using update fields option in `Toolbar`.

![Update bookmark cross reference field.](images/updatefields.png)

The following type of fields are automatically updated in Document Editor.

* NUMPAGES
* SECTION
* PAGE

## Get field info

You can get field code and field result of the current selected field by using `GetFieldInfoAsync` method in the `SelectionModule`.

```csharp
//Gets the field information of the selected field.
FieldInfo fieldInfo = container.DocumentEditor.Selection.GetFieldInfoAsync();
```

>Note: For nested fields, this method returns combined field code and result.

## Set field info

You can modify the field code and field result of the current selected field by using `SetFieldInfoAsync` method in the `EditorModule`.

```csharp
//Gets the field information for the selected field.
FieldInfo fieldInfo = container.DocumentEditor.Selection.GetFieldInfoAsync();

//Modify field code
fieldInfo.Code = 'MERGEFIELD  First Name  \\* MERGEFORMAT ';

//Modify field result
fieldInfo.Result = '«First Name»';

//Modify field code and result of the current selected field.
container.DocumentEditor.Editor.SetFieldInfoAsync(fieldInfo);
```

>Note: For nested field, entire field gets replaced completely with the specified field information.

## See Also

[Mail merge using DocIO](https://help.syncfusion.com/file-formats/docio/working-with-mail-merge)