---
layout: post
title: Cell Editing in Blazor Spreadsheet component | Syncfusion
description: Check out and learn here about the cell editing features in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Editing in Blazor Spreadsheet component

The contents of a cell can be edited directly in the cell or by typing in the formula bar. By default, the editing feature is enabled in the Spreadsheet. Use the `AllowEditing` property to enable or disable the editing feature.

## Edit cell

Editing can be started by one of the following ways,

* Double click a cell to start the edit mode.
* Press `F2` key to edit the active cell.
* Use formula bar to perform editing.
* Use `BACKSPACE` or `SPACE` key to clear the cell content and start the edit mode.

## Save cell

If the cell is in editable state, the edited cell can be saved by one of the following ways,

* Perform mouse click on any other cell rather than the current editing cell.

* Press `Enter` or `Tab` keys to save the edited cell content.

## Cancel editing

To cancel the editing without saving the changes, press the `ESCAPE` key. This will remove the editable state and update the unchanged cell content.

The following animation illustrates the basic cell editing operations in the Spreadsheet component including double-clicking a cell to enter edit mode, editing cell values directly, saving edits by pressing Enter, and canceling edits with the Escape key.

![UI showing cell editing Spreadsheet](./images/cell-editing.gif)


