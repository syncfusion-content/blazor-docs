---
layout: post
title: Tables in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about Tables in Syncfusion Blazor DocumentEditor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Tables in Blazor DocumentEditor Component

Tables are an efficient way to present information. Document editor can display and edit the tables. You can select and edit tables through keyboard, mouse, or touch interactions. [Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) exposes a rich set of APIs to perform these operations programmatically.

## Create a table

You can create and insert a table at cursor position by specifying the required number of rows and columns.

Refer to the following sample code.

```csharp
 documentEditor.Editor.InsertTableAsync(3, 3);
```

The maximum size of row and column is limited to 32767 and 63 respectively.

## Insert rows

You can add a row (or several rows) above or below the row at cursor position by using the [`InsertRowAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertRowAsync_System_Boolean_System_Nullable_System_Double__) method. This method accepts the following parameters:

Parameter | Type | Description
----------|------|-------------
above(optional) | boolean | This is optional and if omitted, it takes the value as false and inserts below the row at cursor position.
count(optional) | number | This is optional and if omitted, it takes the value as 1.

Refer to the following sample code.

```csharp
//Inserts a row below the row at cursor position
documentEditor.Editor.InsertRowAsync();
//Inserts a row above the row at cursor position
documentEditor.Editor.InsertRowAsync(false);
//Inserts three rows below the row at cursor position
documentEditor.Editor.InsertRowAsync(true, 3);
```

## Insert columns

You can add a column (or several columns) to the left or right of the column at cursor position by using the [`InsertColumnAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertColumnAsync_System_Boolean_System_Nullable_System_Double__) method. This method accepts the following parameters:

Parameter | Type | Description
----------|------|-------------
left(optional) | boolean| This is optional and if omitted, it takes the value as false and inserts to the right of column at cursor position.
count(optional) | number |  This is optional and if omitted, it takes the value as 1.

Refer to the following sample code.

```csharp
//Insert a column to the right of the column at cursor position.
documentEditor.Editor.InsertColumnAsync();
//Insert a column to the left of the column at cursor position.
documentEditor.Editor.InsertColumnAsync(false);
//Insert two columns to the left of the column at cursor position.
documentEditor.Editor.InsertColumnAsync(false, 2);
```

### Select an entire table

If the cursor position is inside a table, you can select the entire table by using the following sample code.

```csharp
documentEditor.Selection.SelectTableAsync();
```

### Select row

You can select the entire row at cursor position by using the following sample code.

```csharp
documentEditor.Selection.SelectRowAsync();
```

If current selection spans across cells of different rows, all these rows will be selected.

### Select column

You can select the entire column at cursor position by using the following sample code.

```csharp
documentEditor.Selection.SelectColumnAsync();
```

If current selection spans across cells of different columns, all these columns will be selected.

### Select cell

You can select the cell at cursor position by using the following sample code.

```csharp
documentEditor.Selection.SelectCellAsync();
```

## Delete table

Document editor allows you to delete the entire table. You can use the [`DeleteTableAsync()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_DeleteTableAsync) method of editor instance, if selection is in table. Refer to the following sample code.

```csharp
documentEditor.Editor.DeleteTableAsync();
```

## Delete row

Document editor allows you to delete the selected number of rows. You can use the [`DeleteRowAsync()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_DeleteRowAsync) method of editor instance to delete the selected number of rows, if selection is in table. Refer to the following sample code.

```csharp
documentEditor.Editor.DeleteRowAsync();
```

## Delete column

Document editor allows you to delete the selected number of columns. You can use the [`DeleteColumnAsync()`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_DeleteColumnAsync) method of editor instance to delete the selected number of columns, if selection is in table. Refer to the following sample code.

```csharp
documentEditor.Editor.DeleteColumnAsync();
```

## Merge cells

You can merge cells vertically, horizontally, or combination of both to a single cell. To vertically merge the cells, the columns within selection should be even in left and right directions. To horizontally merge the cells, the rows within selection should be even in top and bottom direction.
Refer to the following sample code.

```csharp
documentEditor.Editor.MergeCellsAsync();
```

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) example to know how to render and configure the document editor.
