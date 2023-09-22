---
layout: post
title: Globalization in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Globalization in Blazor DataGrid Component

## Localization

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component has options for customizing default text content localization, allowing you to change static text in features like group drop area and pager information to different languages (e.g., Arabic, Deutsch, French) by specifying the locale and translation object. Refer to the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

The following list of properties and its values are used in the grid.

Name |Value
-----|-----
Grid_EmptyRecord | No records to display
Grid_True | true
Grid_False | false
Grid_InvalidFilterMessage | Invalid Filter Data
Grid_GroupDropArea | Drag a column header here to group its column
Grid_UnGroupButton | Click here to ungroup
Grid_GroupDisable | Grouping is disabled for this column
Grid_FilterbarTitle | \'s filter bar cell
Grid_EmptyDataSourceError | DataSource must not be empty at initial load since columns are generated from dataSource in AutoGenerate Column Grid
Grid_Add | Add
Grid_Edit | Edit
Grid_Cancel | Cancel
Grid_Update | Update
Grid_Delete | Delete
Grid_Print | Print
Grid_Pdfexport | PDF Export
Grid_Excelexport | Excel Export
Grid_Wordexport | Word Export
Grid_Csvexport | CSV Export
Grid_Search | Search
Grid_Columnchooser | Columns
Grid_Save | Save
Grid_Item | item
Grid_Items | items
Grid_EditOperationAlert | No records selected for edit operation
Grid_DeleteOperationAlert | No records selected for delete operation
Grid_SaveButton | Save
Grid_OKButton | OK
Grid_CancelButton | Cancel
Grid_EditFormTitle | Details of
Grid_AddFormTitle | Add New Record
Grid_BatchSaveConfirm | Are you sure you want to save changes?
Grid_BatchSaveLostChanges | Unsaved changes will be lost. Are you sure you want to continue?
Grid_ConfirmDelete | Are you sure you want to delete record?
Grid_CancelEdit | Are you sure you want to cancel the changes?
Grid_ChooseColumns | Choose Column
Grid_SearchColumns | search columns
Grid_Matchs | No Matches Found
Grid_FilterButton | Filter
Grid_ClearButton | Clear
Grid_StartsWith | Starts With
Grid_EndsWith | Ends With
Grid_Contains | Contains
Grid_Equal | Equal
Grid_NotEqual | Not Equal
Grid_LessThan | Less Than
Grid_LessThanOrEqual | Less Than Or Equal
Grid_GreaterThan | Greater Than
Grid_GreaterThanOrEqual | Greater Than Or Equal
Grid_ChooseDate | Choose a Date
Grid_EnterValue | Enter the value
Grid_Copy | Copy
Grid_Group | Group by this column
Grid_Ungroup | Ungroup by this column
Grid_AutoFitAll | Autofit all columns
Grid_AutoFit | Autofit this column
Grid_Export | Export
Grid_FirstPage | First Page
Grid_LastPage | Last Page
Grid_PreviousPage | Previous Page
Grid_NextPage | Next Page
Grid_SortAscending | Sort Ascending
Grid_SortDescending | Sort Descending
Grid_EditRecord | Edit Record
Grid_DeleteRecord | Delete Record
Grid_FilterMenu | Filter
Grid_SelectAll | Select All
Grid_Blanks | Blanks
Grid_FilterTrue | True
Grid_FilterFalse | False
Grid_NoResult | No Matches Found
Grid_ClearFilter | Clear Filter
Grid_NumberFilter | Number Filters
Grid_TextFilter | Text Filters
Grid_DateFilter | Date Filters
Grid_ChooseTime | Choose a Time
Grid_TimeFilter | Time Filters
Grid_DateTimeFilter | DateTime Filters
Grid_MatchCase | Match Case
Grid_Between | Between
Grid_CustomFilter | Custom Filter
Grid_CustomFilterPlaceHolder | Enter the value
Grid_CustomFilterDatePlaceHolder | Choose a date
Grid_AND | AND
Grid_OR | OR
Grid_ShowRowsWhere | Show rows where:
Grid_RowSelectionCheckBoxARIA | Row checkbox
Grid_FilterMenuIconARIA | Filter Icon
Grid_ColumnMenuIconARIA | Column Menu Icon
Grid_GroupButtonARIA | Group Button
Grid_UnGroupButtonARIA | Ungroup Button
Grid_ColumnHeaderARIA | Column Header
Grid_FilterCheckboxARIA | Filter checkbox
Grid_HeaderSelectionCheckBoxARIA | Header checkbox
Grid_Ascending | Ascending
Grid_Descending | Descending
Grid_None | None
Grid_Sort | Sort
Grid_TemplateColumnARIA | is template cell
Grid_FilterDescription | Press Alt Down to open filter Menu
Grid_SortDescription | Press Enter to sort
Grid_ColumnMenuDescription | Press Alt Down to open Column Menu
Grid_GroupDescription | Press Ctrl space to group
Grid_GroupCaption | is group caption cell
Grid_ColumnHeaderUndefinedARIA | column header undefined
Grid_CommandColumnARIA | Is Command Column
Grid_GroupedSortIcon | sort the grouped column
Grid_EmptyColumnHeaderUndefinedARIA | empty Column Header undefined
Grid_Close | close
Grid_FilterOperator | Filter Operator
Grid_FilterValue | Filter Value

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

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.