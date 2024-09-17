---
layout: post
title: Cell in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about the Cell in the Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Cell in Blazor DataGrid Component

## Displaying the HTML content

The HTML tags can be displayed in the DataGrid header and content by enabling the [DisableHtmlEncode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_DisableHtmlEncode) property.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="<span> Order ID </span>" DisableHtmlEncode="false" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="<span> Customer ID </span>" DisableHtmlEncode="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "<span>ANANTR</span>", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCity = (new string[] { "Seattle", "Tacoma", "Redmond", "Kirkland", "London" })[new Random().Next(5)],
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipCity { get; set; }
    }
}
```

The following screenshot represents a DataGrid displaying the HTML content.

![Displaying HTML Content in Blazor DataGrid](./images/blazor-datagrid-with-html-content.png)

## Customize cell styles

The appearance of cells can be customized by using the [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.QueryCellInfoEventArgs-1.html) event. The [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.QueryCellInfoEventArgs-1.html) event triggers for every cell. In that event handler, you can get [QueryCellInfoEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.QueryCellInfoEventArgs-1.html) that contains the details of the cell.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSelection="false" EnableHover="false" Height="315">
    <GridEvents QueryCellInfo="CustomizeCell" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
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
            ShipCity = (new string[] { "Seattle", "Tacoma", "Redmond", "Kirkland", "London" })[new Random().Next(5)],
            OrderDate = DateTime.Now.AddDays(-x),
            Freight = 6.2 * x,
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
    }

    public void CustomizeCell(QueryCellInfoEventArgs<Order> args)
    {
        if (args.Column.Field == "Freight")
        {
            if (args.Data.Freight < 30)
            {
                args.Cell.AddClass(new string[] { "below-30" });
            }
            else if (args.Data.Freight < 80)
            {
                args.Cell.AddClass(new string[] { "below-80" });
            }
            else
            {
                args.Cell.AddClass(new string[] { "above-80" });
            }
        }
    }
}

<style>
    .below-30 {
        background-color: orangered;
    }

    .below-80 {
        background-color: yellow;
    }

    .above-80 {
        background-color: greenyellow
    }
</style>
```

The following screenshot represents a DataGrid with customized cell styles.

![Customizing Cell Styles in Blazor DataGrid](./images/blazor-datagrid-cell-style-customization.png)

## Auto wrap

The auto wrap allows the cell content of the DataGrid to wrap to the next line when it exceeds the boundary of the cell width. The Cell Content wrapping works based on the position of white space between words. To enable auto wrap, set the [AllowTextWrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowTextWrap) property to `true`. You can configure the auto wrap mode by setting the [TextWrapSettings.WrapMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) property.

There are three types of [WrapMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTextWrapSettings.html#Syncfusion_Blazor_Grids_GridTextWrapSettings_WrapMode). They are:

* **Both**: **Both** value is set by default. Auto wrap will be enabled for both the content and the header.
* **Header**: Auto wrap will be enabled only for the header.
* **Content**: Auto wrap will be enabled only for the content.

N> When a column width is not specified, then auto wrap of columns will be adjusted with respect to the DataGrid's width.

In the following example, the [TextWrapSettings.WrapMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTextWrapSettings.html#Syncfusion_Blazor_Grids_GridTextWrapSettings_WrapMode) is set to **Content**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" GridLines="GridLine.Default" AllowTextWrap="true" Height="315">
    <GridTextWrapSettings WrapMode="WrapMode.Content"></GridTextWrapSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.RollNo) HeaderText="Roll No" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.Name) HeaderText="Name of the inventor" Width="70"></GridColumn>
        <GridColumn Field=@nameof(Order.PatentFamilies) HeaderText="No of patentfamilies" Width="80"></GridColumn>
        <GridColumn Field=@nameof(Order.Country) HeaderText="Country" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.MainFields) HeaderText="Main fields of Invention" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            RollNo = 1000 + x,
            Name = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            PatentFamilies = 1000 + x * 5,
            Country = (new string[] { "Australia", "Japan", "Canada", "India", "USA" })[new Random().Next(5)],
            MainFields = (new string[] { "Printing, Digital paper, Internet, Electronics,Lab-on-a-chip, MEMS, Mechanical, VLSI", "Various", "Printing, Digital paper, Internet, Electronics, CGI, VLSI", "Automotive, Stainless steel products", "Gaming machines" })[new Random().Next(5)],
        }).ToList();
    }

    public class Order
    {
        public int? RollNo { get; set; }
        public string Name { get; set; }
        public int? PatentFamilies { get; set; }
        public string Country { get; set; }
        public string MainFields { get; set; }
    }
}
```

The following screenshot represents a DataGrid with auto wrap.

![Blazor DataGrid with AutoWrap](./images/blazor-datagrid-autowrap.png)

## Custom attributes

You can customize the DataGrid cells by adding a CSS class to the [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_CustomAttributes) property of the column.

In the following example, the cells of the **OrderID** and **ShipCity** columns are customized.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "e-attr" }})" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "e-attr" }})" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="100"></GridColumn>
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
            ShipCity = (new string[] { "Seattle", "Tacoma", "Redmond", "Kirkland", "London" })[new Random().Next(5)],
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipCity { get; set; }
    }
}

<style>
    .e-attr {
        background: #d7f0f4;
    }
</style>
```

## DataGrid lines

The [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GridLines) have option to display cell border and it can be defined by the [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GridLines) property.

The available modes of DataGrid lines are:

| Modes | Actions |
|-------|---------|
| Both | Displays both the horizontal and vertical DataGrid lines.|
| None | No DataGrid lines are displayed.|
| Horizontal | Displays the horizontal DataGrid lines only.|
| Vertical | Displays the vertical DataGrid lines only.|
| Default | Displays DataGrid lines based on the theme.|

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" GridLines="GridLine.Both" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="100"></GridColumn>
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
            ShipCity = (new string[] { "Seattle", "Tacoma", "Redmond", "Kirkland", "London" })[new Random().Next(5)],
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
```

N>By default, the DataGrid renders with **Default** mode.

## Clip mode

The clip mode provides options to display its overflow cell content and it can be defined by the [Columns.ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) property.

There are three types of [ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode). They are:

* **Clip**: Truncates the cell content when it overflows its area.
* **Ellipsis**: Displays ellipsis when the cell content overflows its area.
* **EllipsisWithTooltip**: Displays ellipsis when the cell content overflows its area, also it will display the tooltip while hover on ellipsis is applied.

N> By default, [Columns.ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) value is **Ellipsis**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.RollNo) HeaderText="Roll No" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.Name) HeaderText="Name of the inventor" ClipMode="ClipMode.Clip" Width="70"></GridColumn>
        <GridColumn Field=@nameof(Order.PatentFamilies) HeaderText="No of patent families" ClipMode="ClipMode.Ellipsis" Width="80"></GridColumn>
        <GridColumn Field=@nameof(Order.Country) HeaderText="Country" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.MainFields) HeaderText="Main fields of Invention" ClipMode="ClipMode.EllipsisWithTooltip" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            RollNo = 1000 + x,
            Name = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            PatentFamilies = 1000 + x * 5,
            Country = (new string[] { "Australia", "Japan", "Canada", "India", "USA" })[new Random().Next(5)],
            MainFields = (new string[] { "Printing, Digital paper, Internet, Electronics,Lab-on-a-chip, MEMS, Mechanical, VLSI", "Various", "Printing, Digital paper, Internet, Electronics, CGI, VLSI", "Automotive, Stainless steel products", "Gaming machines" })[new Random().Next(5)],
        }).ToList();
    }

    public class Order
    {
        public int? RollNo { get; set; }
        public string Name { get; set; }
        public int? PatentFamilies { get; set; }
        public string Country { get; set; }
        public string MainFields { get; set; }
    }
}
```

The following screenshot represents a clip mode in DataGrid

![Clip Mode in Blazor DataGrid](./images/blazor-datagrid-clip-mode.png)

N> You can refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.

##  To display the tooltip when using DataGrid inside the Dialog Component

When rendering the DataGrid within a Dialog component, the tooltip appears beyond the dialog popup. To fix the tooltip positioning, add the following CSS code in your application.

```css
<style>
    .e-tooltip-wrap {
        z-index: 1002;
    }
</style>
```