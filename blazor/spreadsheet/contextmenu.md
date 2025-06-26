---
layout: post
title: Context Menu in Blazor Spreadsheet component | Syncfusion
description: Checkout and learn here about the context menu functionality in the Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Context Menu in Blazor Spreadsheet component

The context menu is used to improve user interaction with the Spreadsheet component using the built-in popup menu. It opens when right-clicking on a cell, column header, row header, or sheet tab in the Spreadsheet. The [EnableContextMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_EnableContextMenu) property can be used to enable/disable the context menu.

> The default value for the `EnableContextMenu` property is **true**.

## Cell context menu options

Please find the table below for the default context menu options and their actions.

| Options | Action |
| -- | -- |
| Cut | Cut the selected cells data to the clipboard. The data can be pasted into a different cell location. |
| Copy | Copy the selected cells data to the clipboard for pasting elsewhere. |
| Paste | Paste the data from clipboard to Spreadsheet. |
| Hyperlink | Create a link in the Spreadsheet to navigate to web links or cell reference within the sheet or other sheets in the Spreadsheet. |
| Sort | Perform sorting to the selected range of cells by ascending or descending. |
| Clear Contents | Remove the selected cells data. |
| Filter | Perform filtering to the selected cells based on an active cells value. |

![UI showing context menu options for cell](./images/cell-contextmenu.png)

## Row and column header context menu options

Please find the table below for the default context menu options and their actions.

| Options | Action |
| -- | -- |
| Cut | Cut the selected row/column header data to the clipboard. The data can be pasted into a different cell location. |
| Copy | Copy the selected row/column header data to the clipboard for pasting elsewhere. |
| Paste | Paste the data from the clipboard to Spreadsheet. |
| Insert Rows / Insert Columns | Insert new rows or columns into the worksheet. |

![UI showing context menu options for row header](./images/row-header-contextmenu.png)

![UI showing context menu options for column header](./images/column-header-contextmenu.png)

## Sheet tab context menu options

Please find the table below for the default context menu options and their actions.

| Options | Action |
| -- | -- |
| Insert | Insert a new worksheet after the existing worksheet in the Spreadsheet. |
| Delete | Delete the selected worksheet from the Spreadsheet. |
| Duplicate | Create a copy of the selected worksheet in the Spreadsheet. |
| Rename | Rename the selected worksheet. |
| Protect Sheet / Unprotect Sheet | Protect sheet prevents unwanted changes from others by limiting their ability to edit. Unprotect sheet removes these restrictions. |
| Move Right | Move the selected worksheet to the right of the next sheet. |
| Move Left | Move the selected worksheet to the left of the previous sheet. |
| Hide | Hide the selected worksheet. |

![UI showing context menu options for sheet tab](./images/sheet-tab-contextmenu.png)