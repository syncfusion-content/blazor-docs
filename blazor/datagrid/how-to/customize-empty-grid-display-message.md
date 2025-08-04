---
layout: post
title: Customize the empty record template in Blazor DataGrid | Syncfusion
description: Learn here all about customize the empty record template in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# Customize the empty record template in Blazor DataGrid

The empty record template feature in the Syncfusion Blazor DataGrid allows you to use custom content such as images, text, or other components, when the Grid doesn't contain any records to display. This feature replaces the default message of 'No records to display' typically shown in the Grid.

To activate this feature, set the [EmptyRecordTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTemplates.html#Syncfusion_Blazor_Grids_GridTemplates_EmptyRecordTemplate) feature of the Grid. The `EmptyRecordTemplate` feature expects the HTML element or a function that returns the HTML element.

The following example demonstrates how an image and text can be rendered as a template to indicate that the Grid has no data to display:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data
@using System.ComponentModel.DataAnnotations

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Toolbar="ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.Grids.EditMode.Normal"></GridEditSettings>
    <GridPageSettings PageCount="5"></GridPageSettings>
    <GridTemplates>
        <EmptyRecordTemplate>
            <div class="emptyRecordTemplate text-center">
                <img src="@ImageUrl" class="e-emptyRecord" alt="No record" />
                <span>There is no data available to display at the moment.</span>
            </div>
        </EmptyRecordTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="140" ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules{ Required=true, Number=true})" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="140" ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules{ Required=true})"></GridColumn>
<GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Width="140" Format="C2" EditType="EditType.NumericEdit" ValidationRules="@(new Syncfusion.Blazor.Grids.ValidationRules{ Required=true, Number=true})" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Width="120" EditType="EditType.DateTimePickerEdit" Format="M/d/yyyy hh:mm tt" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150" EditType="EditType.DropDownEdit" ></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; } = new();
    public string ImageUrl = "data:image/svg+xml;base64,PHN2ZyB3...."; 
    public List<string> ToolbarItems = new() { "Add", "Edit", "Delete", "Update", "Cancel" };
}

{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();

    public OrderDetails(int orderId, string customerId, string shipCity, string shipName, double freight, DateTime orderDate, string shipCountry)
    {
        this.OrderID = orderId;
        this.CustomerID = customerId;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.Freight = freight;
        this.OrderDate = orderDate;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier", 32.38, new DateTime(2024, 1, 5), "France"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten", 11.61, new DateTime(2024, 1, 7), "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", 65.83, new DateTime(2024, 1, 10), "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock", 41.34, new DateTime(2024, 1, 12), "France"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices", 51.30, new DateTime(2024, 1, 14), "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", 58.17, new DateTime(2024, 1, 16), "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese", 22.98, new DateTime(2024, 1, 18), "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt", 148.33, new DateTime(2024, 1, 20), "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora", 13.97, new DateTime(2024, 1, 22), "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos", 81.91, new DateTime(2024, 1, 24), "Venezuela"));
        }
        return order;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtVojzBpJtpAwxhe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}