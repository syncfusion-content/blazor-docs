---
layout: post
title: Protect sheet in Blazor Spreadsheet Component | Syncfusion
description: Checkout and learn here all about protect sheet in Syncfusion Blazor Spreadsheet component and more | Syncfusion.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Protect sheet in Blazor Spreadsheet Component

Sheet protection helps to prevent modification of data in the spreadsheet.

## Protect Sheet

The Protect Sheet feature restricts accidental changes such as editing, moving, or deleting data. Protection can be applied with or without a password.

### Protect Settings in Protected Sheet

By default, when a sheet is protected, actions such as selecting cells, formatting, inserting, sorting and filtering are disabled.

To enable specific functionalities while the sheet is protected:

* Open the Protect Sheet dialog from the Review tab.

* In the dialog, go to the Sheet Options tab to view protection settings.

* Check or uncheck the options.

* Click OK to apply the protection settings.

The available protection settings in spreadsheet are,

| Options | Description |
|------------------------|---------|
| Select Cells | Allows cell selection. |
| Format Cells | Allows cell formatting. |
| Format Rows | Allows row formatting. |
| Format Columns | Allows column formatting. |
| Insert Columns | Allows inserting new columns. |
| Insert Rows | Allows inserting new rows. |
| Insert Hyperlinks | Allows adding hyperlinks. |
| Sort | Allows sorting data. |
| Filter | Allows filtering data. |

### User interface

In the active Spreadsheet, the sheet protection can be done by any of the following ways:

* Select Protect Sheet from the Review tab in the Ribbon toolbar and choose the desired options.

* Right-click the sheet tab, select Protect Sheet from the context menu, and choose the desired options.

## Unprotect Sheet

The Unprotect Sheet feature restores access to all actions that were restricted by protection.

### User interface

In the active Spreadsheet, the sheet Unprotection can be done by any of the following ways:

* Select Unprotect Sheet from the Review tab in the Ribbon toolbar.

* Right-click the sheet tab and select Unprotect Sheet from the context menu.

### Unlock the particular cells in the protected sheet via the UI

To allow editing of specific cells or ranges in a protected spreadsheet:

* Open the Protect Sheet dialog.

* Navigate to the Unlocked Ranges tab.

* Add the desired cell(s) or range(s) that should remain editable even when the sheet is protected.

These specified cells will now be editable while the rest of the sheet remains protected.

## Protect Workbook

The Protect Workbook feature prevents structural changes such as inserting, deleting, renaming, or hiding sheets. Protection can be applied with or without a password.

### User interface

To protect the workbook:

* Go to the Review tab in the Ribbon toolbar.

* Select Protect Workbook, enter and confirm the password, then click OK.

## Unprotect Workbook

The Unprotect Workbook feature allows structural changes like inserting, deleting, renaming, moving, copying, hiding, or unhiding sheets.

### User interface

To unprotect the workbook:

* Select Unprotect Workbook from the Review tab in the Ribbon toolbar.

* Enter the correct password in the dialog box, then click OK.