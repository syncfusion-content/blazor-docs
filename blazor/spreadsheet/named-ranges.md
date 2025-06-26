---
layout: post
title: Named Ranges in Blazor Spreadsheet Component | Syncfusion
description: Checkout and learn here all about named ranges in Syncfusion Blazor Spreadsheet component and more | Syncfusion.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Named Ranges in Blazor Spreadsheet Component

The Named Ranges feature allows you to define a meaningful name for a specific cell or range of cells, making it easier to reference and manage data throughout the spreadsheet. You can also use named ranges in formulas for calculations, which makes your formulas easier to read, understand, and maintain.

**NOTE: You can only define named ranges for cells or ranges that contain values.**

### User interface.

You can add named ranges to the Spreadsheet in the following ways,

* Select the range of cells, and then enter the name for the selected range in the Name box.

* Select the range of cells, and then click the Manage Name button in the Ribbon toolbar under the Formula Tab.

### Editing or Deleting Named Ranges

You can manage existing named ranges in the Blazor Spreadsheet through the Manage Name dialog. This allows you to update or remove named ranges as needed.

* #### To Edit a Named Range
  Open the Manage Name dialog, select the named range you want to edit, and click the Edit icon. Update the name, range, or scope as needed, then click the Update Range button.
* #### To delete a Named Range
  Open the Manage Name dialog, select the named range you want to delete, and click the Delete icon.

**NOTE: Deleting a named range that is used in formulas may result in formula errors. Ensure that the named range is not in use before deleting it.**