---
layout: post
title: Hide expand icon in specific record of Hierarchical Grid | Syncfusion
description: Learn here how to hide the expand icon in hierarchical grid using RowDataBound event when child grid has no records.
platform: Blazor
control: DataGrid
documentation: ug
---

# Hide Expand Icon in Hierarchical Grid When It Has No Child Records

The hierarchical structure in the Syncfusion Blazor DataGrid can be created using the Detail Template feature. In some cases, the child Grid may not contain any records. When expanding such a row, it will result in displaying an empty Grid, which may not be ideal. To handle this, the expand icon can be hidden when no child records exist, providing a cleaner user experience.

This behavior can be achieved by using the [`RowDataBound`](https://blazor.syncfusion.com/documentation/datagrid/events#rowdatabound) event of the Grid. The `RowDataBound` event triggers whenever a row is created in the Grid. Within this event, it is possible to check whether the corresponding child Grid has any data by verifying the current row's record details against the child Grid's data source. Based on the result, a specific CSS class can be added to the row using the `AddClass` method. This class is then used to traverse and hide the expand icon and disable the pointer interactions for that row.

The following example demonstrates how to hide the expand icon when there are no child records. The parent Grid displays employee data, and the detail template renders another Grid that shows orders related to each employee. In the `RowDataBound` event, the code checks if any orders exist for the current employee. If no matching records are found, a CSS class is added to the row, which hides the expand icon and disables its click functionality.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid DataSource="@Employees" Height="315px">
    <GridEvents RowDataBound="RowDataBound" TValue="EmployeeData"></GridEvents>
    <GridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
                <SfGrid DataSource="@Orders" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                    <GridColumns>
                        <GridColumn Field=@nameof(Order.OrderID) HeaderText="First Name" Width="110"> </GridColumn>
                        <GridColumn Field=@nameof(Order.CustomerName) HeaderText="Last Name" Width="110"></GridColumn>
                        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Title" Width="110"></GridColumn>
                    </GridColumns>
                </SfGrid>
            }
        </DetailTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    /*to disbale the mouse actions*/
    .e-detail-disable .e-detailrowcollapse {
        pointer-events: none;
    }
    /*if required hide the icons*/
    .e-detail-disable .e-detailrowcollapse .e-icon-grightarrow {
        visibility: hidden;
    }
</style>


@code{
    public void RowDataBound(RowDataBoundEventArgs<EmployeeData> Args) // will be triggered when row is created
    {
        if (Orders.Where(x => x.EmployeeID == Args.Data.EmployeeID).ToList().Count == 0) // Check condition here whether the detail grid has records.
        {
            Args.Row.AddClass(new string[] { "e-detail-disable" });
        }
    }
    List<EmployeeData> Employees = new List<EmployeeData>
    {
        new EmployeeData() {EmployeeID = 1001, FirstName="Nancy", LastName="Fuller", Title="Sales Representative", Country="USA"},
        new EmployeeData() {EmployeeID = 1002, FirstName="Andrew", LastName="Davolio", Title="Vice President", Country="UK"},
        new EmployeeData() {EmployeeID = 1003, FirstName="Janet", LastName="Leverling", Title="Sales", Country="UK"},
        new EmployeeData() {EmployeeID = 1004, FirstName="Margaret", LastName="Peacock", Title="Sales Manager", Country="UAE"},
        new EmployeeData() {EmployeeID = 1005, FirstName="Steven", LastName="Buchanan", Title="Inside Sales Coordinator", Country="USA"},
        new EmployeeData() {EmployeeID = 1006, FirstName="Smith", LastName="Steven", Title="HR Manager", Country="UAE"},
        new EmployeeData() {EmployeeID = 1007, FirstName="Nancy", LastName="Davalio", Title="HR Manager", Country="UAE"},
        new EmployeeData() {EmployeeID = 1008, FirstName="Steven", LastName="Smith", Title="HR Manager", Country="UAE"},
        new EmployeeData() {EmployeeID = 1009, FirstName="Fuller", LastName="Janet", Title="HR Manager", Country="UAE"},
    };
    List<Order> Orders = new List<Order> {
        new Order() {EmployeeID = 1001, OrderID=001, CustomerName="Nancy", ShipCountry="USA"},
        new Order() {EmployeeID = 1001, OrderID=002, CustomerName="Steven", ShipCountry="UR"},
        new Order() {EmployeeID = 1003, OrderID=005, CustomerName="Nancy", ShipCountry="ITA"},
        new Order() {EmployeeID = 1003, OrderID=006, CustomerName="Nancy", ShipCountry="UK"},
        new Order() {EmployeeID = 1003, OrderID=007, CustomerName="Steven", ShipCountry="GER"},
        new Order() {EmployeeID = 1005, OrderID=009, CustomerName="Fuller", ShipCountry="USA"},
        new Order() {EmployeeID = 1006, OrderID=010, CustomerName="Leverling", ShipCountry="UAE"},
        new Order() {EmployeeID = 1006, OrderID=011, CustomerName="Margaret", ShipCountry="KEN"},
        new Order() {EmployeeID = 1007, OrderID=012, CustomerName="Buchanan", ShipCountry="GER"},
        new Order() {EmployeeID = 1006, OrderID=014, CustomerName="Andrew", ShipCountry="UAE"},
    };
    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
    }
    public class Order
    {
        public int? EmployeeID { get; set; }
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipCountry { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLojTrPKyYFBigV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}