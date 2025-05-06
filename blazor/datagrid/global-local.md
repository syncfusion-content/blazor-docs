---
layout: post
title: Globalization in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Globalization in Blazor DataGrid 

The Syncfusion Blazor DataGrid  Grid component provides a feature known as Globalization (global and local), which makes the application more accessible and useful for individuals from different regions and language backgrounds. You have the ability to view data in your preferred language and format, resulting in an enhanced overall experience.

## Localization

The Syncfusion Blazor DataGrid  provides a built-in [Localization](https://blazor.syncfusion.com/documentation/common/localization) library, enabling you to customize the text used in the grid to suit different languages or cultural preferences. With this library, you can change static text on various elements, such as **group drop area text** and **pager information text**, to different cultures, such as **Arabic**, **Deutsch**, **French**, and more.

This can be achieved by defining the [locale](https://ej2.syncfusion.com/angular/documentation/api/grid/#locale) property and translation object.

The following list of properties and its values are used in the grid.

**Data Rendering**

Locale key words |Text | Example 
-----|-----|-----
Grid_EmptyRecord | No records to display | ![Locale empty record](images/locale-empty-record.png)
Grid_EmptyDataSourceError | DataSource must not be empty at initial load since columns are generated from dataSource in AutoGenerate Column Grid

**Columns**

Locale key words |Text | Example 
-----|-----|-----
Grid_True | true | ![Locale true](images/locale-true.png)
Grid_False | false | ![Locale false](images/locale-false.png)

**ColumnChooser**

Locale key words |Text | Example 
-----|-----|-----
Grid_Columnchooser | Columns | ![Locale columnchooser](images/locale-column-chooser.png)
Grid_ChooseColumns | Choose Column | ![Locale choose columns](images/locale-choose-columns.png)

**Editing**

Locale key words |Text | Example 
-----|-----|-----
Grid_Add | Add | ![Locale add](images/locale-add.png)
Grid_Edit| Edit | ![Locale edit](images/locale-edit.png)
Grid_Cancel| Cancel | ![Locale cancel](images/locale-cancel.png)
Grid_Update| Update | ![Locale update](images/locale-update.png)
Grid_Delete | Delete | ![Locale delete](images/locale-delete.png)
Grid_Save | Save | ![Locale save](images/locale-save.png)
Grid_EditOperationAlert | No records selected for edit operation | ![Locale edit operation alert](images/locale-edit-operation-alert.png)
Grid_DeleteOperationAlert | No records selected for delete operation | ![Locale delete operation alert](images/locale-delete-operation-alert.png)
Grid_SaveButton | Save | ![Locale save button](images/locale-save-button.png)
Grid_OKButton | OK | ![Locale ok button](images/locale-ok-button.png)
Grid_CancelButton | Cancel | ![Locale cancel button](images/locale-cancel-button.png)
Grid_EditFormTitle | Details of | ![Locale edit form title](images/locale-edit-form-title.png)
Grid_AddFormTitle | Add New Record | ![Locale add form title](images/locale-add-form-title.png)
Grid_BatchSaveConfirm | Are you sure you want to save changes? | ![Locale batch save confirm](images/locale-batch-save-confirm.png)
Grid_BatchSaveLostChanges | Unsaved changes will be lost. Are you sure you want to continue? | ![Locale batch save lost changes](images/locale-batch-save-lost-changes.png)
Grid_ConfirmDelete | Are you sure you want to Delete Record? | ![Locale confirm delete](images/locale-confirm-delete.png)
Grid_CancelEdit | Are you sure you want to Cancel the changes? | ![Locale cancel edit](images/locale-cancel-edit.png)

**Grouping**

Locale key words |Text | Example 
-----|-----|-----
Grid_GroupDropArea | Drag a column header here to group its column | ![Locale group drop area](images/locale-group-drop-area.png)
Grid_UnGroup | Click here to ungroup | ![Locale un group](images/locale-un-group.png)
Grid_GroupDisable | Grouping is disabled for this column | ![Locale group disable](images/locale-group-disable.png)
Grid_Item | item | ![Locale Item](images/locale-item.png)
Grid_Items | items | ![Locale Items](images/locale-items.png)
Grid_UnGroupButton | Click here to ungroup |
Grid_GroupDescription | Press Ctrl space to group | ![Locale group description](images/locale-group-description.png)

**Filtering**

Locale key words |Text | Example 
-----|-----|-----
Grid_InvalidFilterMessage | Invalid Filter Data
Grid_FilterbarTitle | \s filter bar cell | ![Locale filterbar title](images/locale-filterbar-title.png)
Grid_Matchs | No Matches Found | ![Locale matchs](images/locale-matchs.png)
Grid_FilterButton | Filter | ![Locale filter button](images/locale-filter-button.png)
Grid_ClearButton | Clear | ![Locale clear button](images/locale-clear-button.png)
Grid_StartsWith | Starts With | ![Locale starts with](images/locale-starts-with.png)
Grid_EndsWith | Ends With | ![Locale ends with](images/locale-ends-with.png)
Grid_Contains | Contains | ![Locale contains](images/locale-contains.png)
Grid_Equal | Equal | ![Locale equal](images/locale-equal.png)
Grid_NotEqual | Not Equal | ![Locale not equal](images/locale-not-equal.png)
Grid_LessThan | Less Than | ![Locale less than](images/locale-less-than.png)
Grid_LessThanOrEqual | Less Than Or Equal | ![Locale less than or equal](images/locale-less-than-or-equal.png)
Grid_GreaterThan | Greater Than | ![Locale greater than](images/locale-greater-than.png)
Grid_GreaterThanOrEqual | Greater Than Or Equal | ![Locale greater than or equal](images/locale-greater-than-or-equal.png)
Grid_ChooseDate | Choose a Date | ![Locale choose date](images/locale-choose-date.png)
Grid_EnterValue | Enter the value | ![Locale enter value](images/locale-enter-value.png)
Grid_SelectAll | Select All | ![Locale select all](images/locale-select-all.png)
Grid_Blanks | Blanks | ![Locale blanks](images/locale-blanks.png)
Grid_FilterTrue | True | ![Locale filter true](images/locale-filter-true.png)
Grid_FilterFalse | False | ![Locale filter false](images/locale-filter-false.png)
Grid_NoResult | No Matches Found | ![Locale no result](images/locale-no-result.png)
Grid_ClearFilter | Clear Filter | ![Locale clear filter](images/locale-clear-filter.png)
Grid_NumberFilter | Number Filters | ![Locale number filter](images/locale-number-filter.png)
Grid_TextFilter | Text Filters | ![Locale text filter](images/locale-text-filter.png)
Grid_DateFilter | Date Filters | ![Locale date filter](images/locale-date-filter.png)
Grid_DateTimeFilter | DateTime Filters | ![Locale date time filter](images/locale-date-time-filter.png)
Grid_MatchCase | Match Case | ![Locale match case](images/locale-match-case.png)
Grid_Between | Between | ![Locale between](images/locale-between.png)
Grid_CustomFilter | Custom Filter | ![Locale custom filter](images/locale-custom-filter.png)
Grid_CustomFilterPlaceHolder | Enter the value | ![Locale custom filter placeholder](images/locale-custom-filter-placeholder.png)
Grid_CustomFilterDatePlaceHolder | Choose a date | ![Locale custom filter date placeholder](images/locale-custom-filter-date-placeholder.png)
Grid_AND | AND | ![Locale AND](images/locale-AND.png)
Grid_OR | OR | ![Locale OR](images/locale-OR.png)
Grid_ShowRowsWhere | Show rows where: | ![Locale show rows where](images/locale-show-rows-where.png)

**Searching**

Locale key words |Text | Example 
-----|-----|-----
Grid_Search | Search | ![Locale search](images/locale-search.png)
Grid_SearchColumns | search columns

**Toolbar**

Locale key words |Text | Example 
-----|-----|-----
Grid_Print | Print | ![Locale print](images/locale-print.png)
Grid_Pdfexport | PDF Export | ![Locale pdfexport](images/locale-pdfexport.png)
Grid_Excelexport | Excel Export | ![Locale excelexport](images/locale-excelexport.png)
Grid_Csvexport | CSV Export | ![Locale csvexport](images/locale-csvexport.png)

**ColumnMenu**

Locale key words |Text | Example 
-----|-----|-----
Grid_FilterMenu | Filter | ![Locale filter menu](images/locale-filter-menu.png)
Grid_AutoFitAll | Autofit all columns |
Grid_AutoFit | Autofit this column |

**ContextMenu**

Locale key words |Text | Example 
-----|-----|-----
Grid_Copy | Copy | ![Locale copy](images/locale-copy.png)
Grid_Group | Group by this column | ![Locale group](images/locale-group.png)
Grid_Ungroup | Ungroup by this column | ![Locale ungroup](images/locale-ungroup.png)
Grid_autoFitAll | Auto Fit all columns | ![Locale autofit all](images/locale-autofit-all.png)
Grid_autoFit | Auto Fit this column | ![Locale autofit](images/locale-autofit.png)
Grid_Export | Export | ![Locale export](images/locale-export.png)
Grid_FirstPage | First Page | ![Locale first page](images/locale-first-page.png)
Grid_LastPage | Last Page | ![Locale last page](images/locale-last-page.png)
Grid_PreviousPage | Previous Page | ![Locale previous page](images/locale-previous-page.png)
Grid_NextPage | Next Page | ![Locale next page](images/locale-next-page.png)
Grid_SortAscending | Sort Ascending | ![Locale sort ascending](images/locale-sort-ascending.png)
Grid_SortDescending | Sort Descending | ![Locale sort descending](images/locale-sort-descending.png)
Grid_EditRecord | Edit Record | ![Locale edit record](images/locale-edit-record.png)
Grid_DeleteRecord | Delete Record | ![Locale delete record](images/locale-delete-record.png)

### Loading translations for de culture

The Syncfusion<sup style="font-size:70%">&reg;</sup> Angular Grid component provides a built-in Localization library that allows you to load translation objects for different cultures. By using the **load** function of the **L10n** class, you can customize the text content of the Grid to be displayed in different languages. 

This feature allows you to specify translation objects for specific cultures, such as **Deutsch** (German), and display the Grid's content in the desired language.

To work with **JSON** files in your application, you can enable JSON module resolution in TypeScript by adding the **resolveJsonModule** to true to your tsconfig.json file. Additionally, you can enhance module interoperation by setting **esModuleInterop** to true as shown below:

```ts
{
  compilerOptions: {
    resolveJsonModule: true,
    esModuleInterop: true,
  }
}
```

The following example demonstrates how to load a translation object for **Deutsch (de)** culture, by using the **load** function of **L10n** class from the **ej2-base** module and by defining the [locale](https://ej2.syncfusion.com/angular/documentation/api/grid/#locale) to **de-DE**.

## Right to left (RTL)

RTL provides an option to switch the text direction and layout of the DataGrid component from right to left. It improves the user experiences and accessibility for users who use right-to-left languages (Arabic, Farsi, Urdu, etc.). In the following sample, **EnableRtl** property is used to enable RTL in the DataGrid.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSorting="true" EnableRtl="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap5) to understand how to present and manipulate data.