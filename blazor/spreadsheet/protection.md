---
layout: post
title: Protect Sheet in Blazor Spreadsheet Component | Syncfusion
description: Checkout and learn here all about protect sheet and workbook in Syncfusion Blazor Spreadsheet component and more.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Protect Sheet and Workbook in Blazor Spreadsheet component

The Syncfusion Blazor Spreadsheet component offers protection features to secure data by restricting unauthorized modifications. Sheet protection prevents changes to cell content, while workbook protection safeguards the workbook's structure, such as preventing the addition, deletion, duplication, hiding, moving, or renaming of sheets.

## Protect sheet

The **Protect Sheet** support restricts modifications to a sheet’s content, such as editing or deleting data. Protection can be applied with or without a password, based on the desired security level.

### Enable sheet protection

Sheet protection can be enabled through the user interface in the active sheet using one of the following methods:

* Select **Protect Sheet** from the **Review** tab in the Ribbon toolbar and choose the desired options.

![Protected Sheet Dialog](./images/protect-sheet.gif)

* Right-click the sheet tab context menu option, select **Protect Sheet** from the context menu, and choose the desired options.

![Protected Sheet - Context menu](./images/protect-sheet-contextmenu.png)

The dialog allows setting an optional password and selecting permitted actions for the protected sheet.

### Unlock specific cells or ranges

Specific cells or ranges in a protected sheet can be unlocked to allow editing while maintaining restrictions on the rest of the sheet. This feature supports scenarios where selective data editing is required.

To unlock specific cells or ranges in a protected sheet, follow these steps:

* Open the **Protect Sheet** dialog from the **Review** tab or the sheet tab context menu.

* Navigate to the **Unlock Range** tab in the dialog.

* Select the desired cells or ranges that should remain editable.

* Confirm the settings and apply protection to the sheet.

![Unlocked Ranges - Protected Sheet UI](./images/unlocked-range.gif)

To edit existing unlocked ranges:

* In the **Protect Sheet** dialog, under the **Unlock Range** tab, view the unlocked ranges list, which shows all ranges currently set as editable in the protected sheet.

* Position the cursor over a range to reveal the **edit** icon.

* Click the **edit** icon, modify the range name or cells (e.g., change "A1:A10" to "A1:A100").

* Click **Update Range** button to save the changes.

![Edit Unlocked Ranges - Protected Sheet UI](./images/edit-unlocked-range.png)

To delete an existing unlocked range:

* In the unlocked ranges list, position the cursor over the range to reveal the **delete** icon.

* Click the **delete** icon to remove the range. Once removed, the range becomes protected and cannot be edited, aligning with the sheet’s protection restrictions.

![Delete Unlocked Ranges - Protected Sheet UI](./images/delete-unlocked-range.png)

**Allowed actions in protected sheets**

When a sheet is protected, the following operations are permitted only for unlocked cells or ranges:

* **Clipboard actions** :
  * **Cut** operations are not permitted for either locked or unlocked cells in a protected sheet to prevent unintended data removal. 
  * **Copy** operations are permitted for both locked and unlocked cells. 
  * **Paste** operations are permitted only in unlocked cells to prevent unintended modifications to protected areas. For example, copying a value from a locked cell and pasting it into an unlocked cell is supported, but pasting into a locked cell is prohibited.

* **Autofill actions**: **Autofill** is permitted only for unlocked cells, ensuring protected data remains unchanged.

* **Cell editing**: Editing a cell content, such as typing new values or modifying existing data, is permitted only in unlocked cells.

* **Formula bar editing**:  Editing cell content via the formula bar, including entering or modifying formulas, inserting formulas using the insert function, or editing text or values, is allowed only in unlocked cells.

* **Clear actions**: **Clear All** and **Clear Contents** are allowed only for unlocked cells, preserving protected data.

These restrictions ensure that only designated unlocked areas can be modified, providing precise control over editable content in a protected sheet. If clipboard actions, autofill actions, cell editing, or formula bar editing are attempted on locked cells, a warning popup appears to indicate the action is restricted.

![Protect Sheet Warning- Protected Sheet UI](./images/protect-sheet-warning.png)

### Protection settings in a protected sheet

By default, a protected sheet restricts actions like formatting, inserting, sorting, and filtering. Specific actions can be enabled through protection settings.

To enable specific functionalities while the sheet is protected:

* Open the **Protect Sheet** dialog from the **Review** tab.

* Navigate to the **Sheet Options** tab to view available protection settings.

* Select or deselect the desired options to allow or restrict specific actions.

* Click **OK** to apply the protection settings.

![Protection Settings Dialog](./images/sheet-options.png)

The available protection settings include:

* **Select Locked Cells**: Allows clicking on locked cells. This option cannot be turned on alone. Enabling it automatically turns on the **Select Unlocked Cells** option

* **Select Unlocked Cells**: Allows selection of unlocked cells in the protected sheet, enabling focus only on editable areas.

* **Format Cells**: Allows changing fonts, colors, or styles. When this option enabled, the **Home** tab in the **Ribbon** displays options like Bold, Italic, Font Size, and Fill Color for both locked and unlocked cells. Additionally, the **Clear Formats** option enables in the **Ribbon** for unlocked cells only.

![Format Cells - Protected Sheet UI](./images/format-cells.png)

* **Format Rows**: Allows formatting of rows, such as adjusting row height. When this option is enabled, the row resize cursor becomes active for both locked and unlocked cells.

![Format Rows - Protected Sheet UI](./images/format-rows.png)

* **Format Columns**: Allows formatting of columns, such as adjusting column width. When this option is enabled, the column resize cursor becomes active for both locked and unlocked cells.

![Format Columns - Protected Sheet UI](./images/format-columns.png)

* **Insert Columns**: Allows adding new columns in the protected sheet. When this option is enabled, right-clicking a single column header or a range of selected column headers displays the **Insert Column** option in the context menu. This applies to both locked and unlocked cells.

![Insert Columns - Protected Sheet UI](./images/insert-columns.png)

* **Insert Rows**: Allows adding new rows in the protected sheet. When this option is enabled,  right-clicking a single row header or a range of selected row headers displays the **Insert Row** option in the context menu. This applies to both locked and unlocked cells.

![Insert Rows - Protected Sheet UI](./images/insert-rows.png)

* **Insert Hyperlinks**:  Allows adding hyperlinks to unlocked cells in the protected sheet. When this option is enabled, the **Insert** tab in the **Ribbon** displays the **Link** option, and the **Hyperlink** option becomes available in the context menu. Additionally, the **Clear Hyperlink** option appears in the Ribbon for unlocked cells only.

![Insert Hyperlink - Protected Sheet UI](./images/insert-hyperlink.png)

For locked cells, the **Link** and **Hyperlink** options in the Ribbon and context menu are disabled, preventing hyperlink addition.

![Insert Hyperlink Disabled- Protected Sheet UI](./images/insert-hyperlink-disabled.png)

* **Sort**: Allows sorting data in unlocked ranges within the protected sheet. When this option is enabled, the **Home** tab in the **Ribbon** displays the **Sort** option, and the **Sort** option also appears in the context menu.

![Sort Contextmenu- Protected Sheet UI](./images/sort-contextmenu.png)
![Sort Ribbon- Protected Sheet UI](./images/sort-ribbon.png)

For locked cells, a warning popup appears if sorting is attempted, indicating the action is not allowed.

![Protect Sheet Warning- Protected Sheet UI](./images/protect-sheet-warning.png)

* **Filter**: Allows applying filters to data in unlocked ranges within the protected sheet. When this option is enabled, the **Home** tab in the **Ribbon** displays the **Filter** option, and the **Filter** option also appears in the context menu.

![Filter Contextmenu- Protected Sheet UI](./images/filter-contextmenu.png)
![Filter Ribbon- Protected Sheet UI](./images/filter-ribbon.png)

For locked cells, a warning popup appears if filtering is attempted, indicating the action is not allowed.

![Protect Sheet Warning- Protected Sheet UI](./images/protect-sheet-warning.png)

## Unprotect Sheet

The **Unprotect Sheet** support removes restrictions on actions previously limited by sheet protection, enabling full interaction, including editing, formatting, inserting, and deleting content.

### Unprotecting sheets via UI

To unprotect a sheet, follow one of these methods:

* Select **Unprotect Sheet** from the **Review** tab in the Ribbon toolbar.

* Right-click the sheet tab context menu option and select **Unprotect Sheet** from the context menu, and enter the password if prompted.

If a password was set during protection, the correct password must be entered to unprotect the sheet. If no password was set, the sheet can be unprotected directly without entering a password.

![Unprotected Sheet Dialog](./images/unprotect-sheet.png)

## Protect Workbook

The **Protect Workbook** support prevents structural modifications within a workbook, such as inserting, deleting, renaming, duplicating, hiding, moving, or copying sheets. Protection can be applied with or without a password, depending on the required security level. 
When the workbook is protected, context menu options in the sheet tab related to structural changes are disabled to prevent modifications.

![Protected Workbook Contextmenu](./images/protect-workbook-contextmenu.png)

### Protecting workbooks via UI

To protect the workbook, follow these steps:

* Navigate to the **Review** tab in the Ribbon toolbar.

* Select **Protect Workbook**, enter and confirm the desired password, and then click **OK** to apply the protection.

![Protected Workbook Dialog](./images/protect-workbook.gif)

## Unprotect Workbook

The **Unprotect Workbook** support restores the ability to perform structural modifications, enabling actions such as inserting, deleting, renaming, moving, copying, hiding, or unhiding sheets.

### Unprotecting workbooks via UI

To unprotect the workbook, follow these steps:

* Select **Unprotect Workbook** from the **Review** tab in the Ribbon toolbar.

* If a password was set during protection, enter the correct password in the dialog box, then click **OK** to unprotect the workbook. If no password was set, the workbook can be unprotected directly without entering a password.

![Unprotected Workbook Dialog](./images/unprotect-workbook.png)