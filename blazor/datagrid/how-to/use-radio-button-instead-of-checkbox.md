---
layout: post
title: Use Radio Button Instead of Checkbox in Blazor DataGrid | Syncfusion
description: Learn how to use radio buttons for single-row selection in Syncfusion Blazor DataGrid using templates and ValueChange event.
platform: Blazor
control: DataGrid
documentation: ug
---

# How to use radio button instead of checkbox in Blazor DataGrid

By default, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides checkbox selection for multiple row selection. When only one row should be selectable at a time, a radio button can be used instead of checkbox selection. This is achieved by using the [Column Template](https://blazor.syncfusion.com/documentation/datagrid/column-template) feature to render an [SfRadioButton](https://blazor.syncfusion.com/documentation/radio-button/getting-started-webapp) in each row. Assign the same radio group name for all rows so only one radio button can be selected at a time, and bind each radio button to a unique value from the data source (typically the primary key field).

Steps to configure row selection using radio buttons:

* When a radio button is selected, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html#Syncfusion_Blazor_Buttons_SfRadioButton_1_ValueChange) event is triggered.
* In the `ValueChange` event, retrieve the row index using [GetRowIndexByPrimaryKeyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetRowIndexByPrimaryKeyAsync_System_Object_) based on the selected unique value. Ensure the unique value corresponds to the Grid’s primary key column.
* Select the corresponding row using [SelectRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowAsync_System_Double_) (or the appropriate selection method).
* To prevent selection by clicking on the row itself, enable the [CheckboxOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_CheckboxOnly) property. This ensures selection occurs only through the radio button interaction.

The following example demonstrates how to handle row selection in the Grid using radio buttons:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid @ref="GridInstance" DataSource="@Orders" AllowSelection="true" AllowPaging="true" TValue="Order">
    <GridSelectionSettings CheckboxOnly="true"></GridSelectionSettings>
    <GridColumns>
        <GridColumn>
             <Template>
                @{
                    var PrimaryVal = (context as Order);
                    <SfRadioButton @ref="RadioButtonInstance" Name="RadioBtn" Value="@PrimaryVal.CustomerID" ValueChange="ValueChange" TChecked="string"></SfRadioButton>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name"  IsPrimaryKey="true">
        </GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="Syncfusion.Blazor.Grids.ColumnType.Date"></GridColumn>
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
        if (GridInstance != null)
        {
            var index = await GridInstance.GetRowIndexByPrimaryKeyAsync(args.Value); // Fetch the row index based on the unique value of RadioButton.
            await GridInstance.SelectRowAsync(index); // Select the corresponding Grid row.
        }
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLSDOVfUiyKZUmQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

