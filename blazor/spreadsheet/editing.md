---
layout: post
title: Cell Editing in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn here about the cell editing features in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Editing in Blazor Spreadsheet component

The contents of a cell can be edited directly within the cell or by typing in the formula bar. By default, the editing feature is enabled in the Spreadsheet. Use the [AllowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_AllowEditing) property to enable or disable the editing feature.

## Edit cell

Editing can be started in one of the following ways,

* Double-click a cell to start edit mode.
* Press the `F2` key to edit the active cell.
* Use the formula bar to perform editing.
* Press `BACKSPACE` or `SPACE` key to clear the cell content and start edit mode.

## Save cell

If the cell is in an editable state, the edited cell can be saved in one of the following ways,

* Click any other cell except the one currently being edited.

* Press the `Enter` or `Tab` key to save the edited cell.

## Cancel editing

To cancel editing without saving changes, press the `ESCAPE` key. This exits the editable state and restores the original cell content.

The following animation illustrates basic cell editing operations in the Spreadsheet component, including double-clicking a cell to enter edit mode, editing values directly, saving changes by pressing `ENTER` key, and canceling edits with the `ESCAPE` key.

![UI showing cell editing](./images/cell-editing.gif)


