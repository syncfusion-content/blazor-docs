---
layout: post
title: Use radio button instead of checkbox in Blazor DataGrid | Syncfusion
description: Learn here all about how to use radio button instead of checkbox in single selection mode in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# How to Use Radio Button Instead of Checkbox in a Grid Selection

Checkbox selection provides an option to select datagrid records with the help of a checkbox in each row. Instead, you can render the radio button for selecting the Grid row. This can be achieved by using the column template feature of the Grid.

In the following sample, the **SfRadioButton** component is rendered in the Grid column. In the [valueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html#Syncfusion_Blazor_Buttons_SfRadioButton_1_ValueChange) event of the [SfRadioButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html), you can select the row using the [selectRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsAsync_System_Double___) method of the Grid based on the row index fetched from the PrimaryKey column value of the Grid. To prevent selection in the Grid by clicking the row, the [CheckboxOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_CheckboxOnly) property is enabled.

```csharp
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid @ref="GridInstance" DataSource="@Orders" AllowSelection="true" AllowPaging="true" TValue="Order">
    <GridSelectionSettings CheckboxOnly="true"></GridSelectionSettings>
    <GridColumns>
        <GridColumn>
            <Template>
                @{
                    var PrimaryVal = (context as Order);
                    <SfRadioButton @ref="RadioButtonInstance"  Name="RadioBtn "Value="@PrimaryVal.CustomerID" ValueChange="ValueChange" TChecked="string"></SfRadioButton>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name"  IsPrimaryKey="true" >
        </GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    SfRadioButton<string> RadioButtonInstance;
    SfGrid<Order> GridInstance;

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 4).Select(x => new Order()
        {
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[x],
             ShipCity = (new string[] { "Berlin", "Madrid", "Cholchester", "Marseille", "Tsawassen" })[new Random().Next(5)],
              Freight = 2.1 * x,
               OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    public async void ValueChange(ChangeArgs<string> args)
    {
        var index = await GridInstance.GetRowIndexByPrimaryKey(args.Value); // Fetch the row index based on the unique value of RadioButton.
        GridInstance.SelectRow(index); // Select the corresponding Grid row.
    }
    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
    }
}

```