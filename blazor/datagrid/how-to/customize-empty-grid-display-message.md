---
layout: post
title: Blazor Grid Customize Empty Record Template | Syncfusion
description: Learn how to customize the EmptyRecordTemplate in Blazor Data Grid to display custom messages or content when no records are available.
platform: Blazor
control: DataGrid
documentation: ug
---

# Customize Empty Record Template in Blazor Data Grid

When the Data Grid's `DataSource` contains no records, the [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) renders the content defined in `EmptyRecordTemplate`. The `EmptyRecordTemplate` replaces the default “No records to display” message. Without an `EmptyRecordTemplate` definition, the Data Grid displays the default message.

Define `EmptyRecordTemplate` within [GridTemplates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTemplates.html#Syncfusion_Blazor_Grids_GridTemplates) to add custom content. Razor markup and components can be used inside the template.

The sample binds the Data Grid to an empty `Orders` collection, so the custom empty-record template is displayed when the Data Grid loads. When records are added, the Data Grid displays the data instead of the template. If all records are deleted, the Data Grid becomes empty again and the custom empty-record template is displayed.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

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
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150" EditType="EditType.DropDownEdit"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; } = new();
    public string ImageUrl = "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iNDQiIGhlaWdodD0iNDQiIHZpZXdCb3g9IjAgMCA0NCA0NCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPGcgY2xpcC1wYXRoPSJ1cmwoI2NsaXAwXzE5OTZfMjQxKSI+CjxyZWN0IHg9Ii0xLjAyNDkiIHk9IjguNTcwNTYiIHdpZHRoPSIzNy4wMTU2IiBoZWlnaHQ9IjM3Ljc2MjMiIHJ4PSI3IiB0cmFuc2Zvcm09InJvdGF0ZSgtMTUgLTEuMDI0OSA4LjU3MDU2KSIgZmlsbD0iI0VGRjNGOSIvPgo8cGF0aCBkPSJNMzcuODIzMSA3LjUxMTIzTDM4LjE4MDMgOC4wNzI1NEwzOC43NDE2IDguNDI5NzdMMzguMTgwMyA4Ljc4N0wzNy44MjMxIDkuMzQ4MzFMMzcuNDY1OSA4Ljc4N0wzNi45MDQ1IDguNDI5NzdMMzcuNDY1OSA4LjA3MjU0TDM3LjgyMzEgNy41MTEyM1oiIHN0cm9rZT0iIzY1RkE4NiIgc3Ryb2tlLXdpZHRoPSIwLjQ1OTI3IiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+CjxwYXRoIGQ9Ik0xMC40OTY0IDM4LjA1MjdWMzkuODg5OE05LjU3Nzg4IDM4Ljk3MTNIMTEuNDE1IiBzdHJva2U9IiM1RjdCRjgiIHN0cm9rZS13aWR0aD0iMC40NTkyNyIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIi8+CjxwYXRoIGQ9Ik04IDExQzggOS4zNDMxNCA5LjM0MzE1IDggMTEgOEgzMEMzMS42NTY5IDggMzMgOS4zNDMxNSAzMyAxMVYzMC4wMDAxQzMzIDMxLjY1NjkgMzEuNjU2OCAzMy4wMDAxIDMwIDMzLjAwMDFMMTEgMzIuOTk5OUM5LjM0MzEzIDMyLjk5OTkgOCAzMS42NTY4IDggMjkuOTk5OVYxMVoiIGZpbGw9IndoaXRlIiBzdHJva2U9IiNBM0IyQzgiIHN0cm9rZS13aWR0aD0iMiIgc3Ryb2tlLWxpbmVqb2luPSJyb3VuZCIvPgo8Y2lyY2xlIGN4PSI0LjEzMzM4IiBjeT0iMzAuMzkzMiIgcj0iMC45MTg1NCIgc3Ryb2tlPSIjRUY1ODU4IiBzdHJva2Utd2lkdGg9IjAuNDU5MjciLz4KPHBhdGggZD0iTTkgMTVIMzIiIHN0cm9rZT0iI0EzQjJDOCIgc3Ryb2tlLXdpZHRoPSIyIiBzdHJva2UtbGluZWNhcD0icm91bmQiLz4KPGNpcmNsZSBjeD0iMjgiIGN5PSIyOCIgcj0iOSIgZmlsbD0id2hpdGUiIHN0cm9rZT0iIzRDNTY2NiIgc3Ryb2tlLXdpZHRoPSIyIi8+CjxwYXRoIGQ9Ik0yOCAyM1YyOCIgc3Ryb2tlPSIjNEM1NjY2IiBzdHJva2Utd2lkdGg9IjIiIHN0cm9rZS1saW5lY2FwPSJyb3VuZCIvPgo8Y2lyY2xlIGN4PSIyOCIgY3k9IjMyIiByPSIxLjUiIGZpbGw9IiM0QzU2NjYiLz4KPC9nPgo8ZGVmcz4KPGNsaXBQYXRoIGlkPSJjbGlwMF8xOTk2XzI0MSI+CjxyZWN0IHdpZHRoPSI0NCIgaGVpZ2h0PSI0NCIgZmlsbD0id2hpdGUiLz4KPC9jbGlwUGF0aD4KPC9kZWZzPgo8L3N2Zz4K";
    public List<string> ToolbarItems = new() { "Add", "Edit", "Delete", "Update", "Cancel" };
}

{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public OrderDetails()
    {
    }

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLRtQjCWufxUGkx?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}