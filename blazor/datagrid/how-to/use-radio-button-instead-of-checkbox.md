---
layout: post
title: Use radio button instead of checkbox in Blazor DataGrid | Syncfusion
description: Learn here all about how to use radio button instead of checkbox in single selection mode in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# How to use radio button instead of checkbox for row selection of Grid

By default, the Syncfusion DataGrid provides checkboxes to allow multiple row selection. If there is a need to allow only one row to be selected at a time, a radio button can be used instead of checkboxes. This can be achieved by using the column template feature to render a radio button in each row. The radio button can be linked to a unique value from the data source, such as the primary key field.

When a radio button is selected, the [valueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html#Syncfusion_Blazor_Buttons_SfRadioButton_1_ValueChange) event is triggered. In this event, the row index is retrieved based on the selected value using the Grid’s [GetRowIndexByPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetRowIndexByPrimaryKeyAsync_System_Object_) method. The corresponding row is then selected using the [selectRow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsAsync_System_Double___) method. To make sure that the selection happens only through the radio button and not by clicking on the row, the [CheckboxOnly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_CheckboxOnly) property can be enabled in the Grid’s selection settings.

With this setup, the Grid will display a radio button for each row, and selecting a radio button will select and highlight the corresponding row.

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
                    <SfRadioButton @ref="RadioButtonInstance" Name="RadioBtn "Value="@PrimaryVal.CustomerID" ValueChange="ValueChange" TChecked="string"></SfRadioButton>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name"  IsPrimaryKey="true" >
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
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjhStfhbAvgdQqQU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}