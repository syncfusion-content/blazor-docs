---
layout: post
title: Protect sheet in Blazor Spreadsheet Component | Syncfusion
description: Checkout and learn here all about protect sheet in Syncfusion Blazor Spreadsheet component and more | Syncfusion.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Protect sheet in Blazor Spreadsheet Component

Sheet protection helps you to prevent the users from modifying the data in the spreadsheet.

## Protect Sheet

Protect sheet feature helps you to prevent the unknown users from accidentally changing, editing, moving, or deleting data in a spreadsheet. And you can also protect the sheet with or without password.

### Protect Settings in Protected Sheet

By default, when a sheet is protected, actions such as selecting cells, formatting, inserting, sorting and filtering are disabled.

To enable specific functionalities while the sheet is protected:

* Open the Protect Sheet dialog from the Review tab.

* In the dialog, navigate to sheet options tab where you’ll find various protection settings.

* Check or uncheck the options based on the actions you want to allow.

* Click OK to apply the protection settings.

The available protectSettings options in spreadsheet are,

| Options | Uses |
|------------------------|---------|
| Select Cells | Used to perform Cell Selection. |
| Format Cells | Used to perform Cell formatting. |
| Format Rows | Used to perform Row formatting. |
| Format Columns | Used to perform Column formatting. |
| Insert Columns | Used to insert new columns. |
| Insert Rows | Used to insert new rows. |
| Insert Hyperlinks | Used to perform Hyperlink Insertions. |
| Sort | Used to perform Sorting. |
| Filter | Used to perform Filtering. |

### User interface

In the active Spreadsheet, the sheet protection can be done by any of the following ways:

* Select the Protect Sheet item in the Ribbon toolbar under the Review Tab, and then select your desired options.

* Right-click the sheet tab, select the Protect Sheet item in the context menu, and then select your desired options.

## Unprotect Sheet

Unprotect sheet is used to enable all the functionalities that are already disabled in a protected spreadsheet.

### User interface

In the active Spreadsheet, the sheet Unprotection can be done by any of the following ways:

* Select the Unprotect Sheet item in the Ribbon toolbar under the Review Tab.

* Right-click the sheet tab, select the Unprotect Sheet item in the context menu.

### Unlock the particular cells in the protected sheet via the UI

To allow editing of specific cells or ranges in a protected spreadsheet:

* Open the Protect Sheet dialog.

* Navigate to the Unlocked Ranges tab.

* Add the desired cell(s) or range(s) that should remain editable even when the sheet is protected.

These specified cells will now be editable while the rest of the sheet remains protected.

## Protect Workbook

Protect workbook feature helps you to protect the workbook so that users cannot insert, delete, rename, hide the sheets in the spreadsheet. You can enable workbook protection with or without a password, depending on your security requirements.

### User interface

In the active Spreadsheet, you can protect the workbook by selecting the Review tab in the Ribbon toolbar and choosing the Protect Workbook item. Then, enter the password and confirm it and click on OK.

## Unprotect Workbook

Unprotect Workbook is used to enable the insert, delete, rename, move, copy, hide or unhide sheets feature in the spreadsheet.

### User interface

In the active Spreadsheet, the workbook can be unprotected using the following method:

* Select the Unprotect Workbook item in the Ribbon toolbar under the Review Tab and provide the valid password in the dialog box.