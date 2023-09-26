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

Displaying HTML content in a Grid can be useful in scenarios where you want to display formatted content, such as images, links, or tables, in a tabular format. Grid component allows you to display HTML tags in the Grid header and content. By default, the HTML content is encoded to prevent potential security vulnerabilities. However, you can enable the [DisableHtmlEncode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_DisableHtmlEncode) property by setting the value as false to display HTML tags without encoding. This feature is useful when you want to display HTML content in a grid cell.

In the following example, the [Blazor Toggle Switch](https://www.syncfusion.com/blazor-components/blazor-toggle-switch-button) Button component is added to enable and disable the `DisableHtmlEncode` property. When the switch is toggled, the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html#Syncfusion_Blazor_Buttons_SfSwitch_1_ValueChange) event is triggered and the `DisableHtmlEncode` property of the column is updated accordingly. The [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Refresh) method is called to Refresh the grid and display the updated content.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<label> Enable or disable HTML Encode</label>
<SfSwitch ValueChange="Change" TChecked="bool"></SfSwitch>

<SfGrid @ref="Grid" DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="<span> Customer ID </span>" DisableHtmlEncode="@IsEncode" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public bool IsEncode { get; set; } = true;
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "<span>ANANTR</span>", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                ShipCity = (new string[] { "Seattle", "Tacoma", "Redmond", "Kirkland", "London" })[new Random().Next(5)],
                Freight = 6.2 * x,
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }
    }
    private void Change(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        if(args.Checked)
        {
            IsEncode = false;
        }
        else
        {
            IsEncode = true;
        }
        Grid.Refresh();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhgZbMvAWBCLJJH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The [DisableHtmlEncode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_DisableHtmlEncode)  property disables HTML encoding for the corresponding column in the grid.
> * If the property is set to **true**, any HTML tags in the column’s data will be displayed.
> * If the property is set to **false**, the HTML tags will be removed and displayed as plain text.
> * Disabling HTML encoding can potentially introduce security vulnerabilities, so use caution when enabling this feature.

## Autowrap the grid content

The auto wrap feature allows the cell content in the grid to wrap to the next line when it exceeds the boundary of the specified cell width. The cell content wrapping works based on the position of white space between words. To support the Autowrap functionality in Syncfusion Grid, you should set the appropriate width for the columns. The column width defines the maximum width of a column and helps to wrap the content automatically.

 To enable auto wrap, set the [AllowTextWrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowTextWrap) property to **true**. You can configure the auto wrap mode by setting the [TextWrapSettings.WrapMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) property.

 Grid provides the below three options for configuring:

* **Both** - This is the default value for wrapMode. With this option, both the grid **Header** and **Content** text is wrapped.
* **Header** -  With this option, only the grid header text is wrapped.
* **Content** -  With this option, only the grid content is wrapped.

> * When a column width is not specified, then auto wrap of columns will be adjusted with respect to the DataGrid's width.
> * If a column’s header text contains no white space, the text may not be wrapped.
> *  If the content of a cell contains HTML tags, the Autowrap functionality may not work as expected. In such cases, you can use the [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_HeaderTemplate) and [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Template) features of the column to customize the appearance of the header and cell content.

The following example demonstrates how to set the `AllowTextWrap` property to **true** and specify the wrap mode as **Content** by setting the `TextWrapSettings.WrapMode` property.Also change the `TextWrapSettings.wrapMode` property to **Content**,**Header** and **Both** on changing the dropdown value using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html#Syncfusion_Blazor_Buttons_SfSwitch_1_ValueChange) event of the DropDownList component.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label>Change the wrapmode of auto wrap feature:</label>
<SfDropDownList TValue="WrapMode" TItem="ddlOrder" @bind-Value="@DropVal" DataSource="@LocalData" Width="100px">
    <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
    <DropDownListEvents ValueChange="OnValueChange" TValue="WrapMode" TItem="ddlOrder"></DropDownListEvents>
</SfDropDownList>

<SfGrid @ref="Grid" DataSource="@Orders" GridLines="GridLine.Default" AllowTextWrap="true" Height="315">
    <GridTextWrapSettings WrapMode="@DropVal"></GridTextWrapSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.RollNo) HeaderText="Roll No" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.Name) HeaderText="Name of the inventor" Width="70"></GridColumn>
        <GridColumn Field=@nameof(Order.PatentFamilies) HeaderText="No of patentfamilies" Width="80"></GridColumn>
        <GridColumn Field=@nameof(Order.Country) HeaderText="Country" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.MainFields) HeaderText="Main fields of Invention" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;

    public WrapMode DropVal { get; set; } = WrapMode.Content;

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
    public class ddlOrder
    {
        public string Text { get; set; }
        public WrapMode Value { get; set; }
    }
    List<ddlOrder> LocalData = new List<ddlOrder>
    {
        new ddlOrder() { Text = "Both", Value = WrapMode.Both },
        new ddlOrder() { Text = "Content", Value = WrapMode.Content },
        new ddlOrder() { Text = "Header", Value = WrapMode.Header }
    };
    public void OnValueChange(ChangeEventArgs<WrapMode, ddlOrder> Args)
    {
        DropVal = Args.Value;
        Grid.Refresh();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNBAtuDxfZcysamd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize cell styles

Customizing the grid cell styles allows you to modify the appearance of cells in the Grid control to meet your design requirements. You can customize the font, background color, and other styles of the cells. To customize the cell styles in the grid, you can use grid event, css or property support.

### Using event

To customize the appearance of the grid cell, you can use the [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.QueryCellInfoEventArgs-1.html) event of the grid. This event is triggered when each cell is rendered in the grid, and provides an object that contains information about the cell. You can use this object to modify the styles of the cell.

The following example demonstrates how to add a `QueryCellInfo` event handler to the grid. In the event handler, checked whether the current column is **Freight** field and then applied the appropriate CSS class to the cell based on its value.

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

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS" })[new Random().Next(7)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLgjvivAmfpAZcD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The  [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.QueryCellInfoEventArgs-1.html) event is triggered for every cell of the grid, so it may impact the performance of the grid whether used to modify a large number of cells.

### Using CSS

You can apply styles to the cells using CSS selectors. The Grid provides a class name for each cell element, which you can use to apply styles to that specific cell or cells in a particular column. The `e-rowcell` class is used to style the row cells, and the `e-selectionbackground` class is used to change the background color of the selected row.

```cshtml
<style>
    .e-grid td.e-cellselectionbackground {
        background: #9ac5ee;
        font-style: italic;
    }
</style>
```
The following example demonstrates how to customize the appearance of a specific row in the grid on selection using ```className```.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSelection="true" AllowPaging="true">
    <GridSelectionSettings CellSelectionMode="CellSelectionMode.Box" Mode="SelectionMode.Cell" Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid td.e-cellselectionbackground {
        background: #9ac5ee;
        font-style: italic;
    }
</style>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],                
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Around the Horn", "Berglunds snabbköp", "Blondel père et fils", "Ernst Handel" })[new Random().Next(4)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
       
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVgjFsvqbeONlFV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Using property

To customize the style of grid cells, define [CustomAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnModel.html#Syncfusion_Blazor_Grids_ColumnModel_CustomAttributes)  property to the GridColumn  definition object. The `CustomAttributes` property takes an object with the name-value pair to customize the CSS properties for grid cells. You can also set multiple CSS properties to the custom class using the CustomAttributes property.

```cshtml
<style>
    .custom-css {
        background: #d7f0f4;
        font-style: italic;
        color:navy
    }
</style>
```
Here, setting the CustomAttributes property of the **ShipCity** column to an object that contains the CSS class ‘custom-css’. This CSS class will be applied to all the cells in the **ShipCity** column of the grid.

```cshtml
<GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "custom-css" }})" Width="100"></GridColumn>
```

The following example demonstrates how to customize the appearance of the **OrderID** and **ShipCity** columns using custom attributes.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "custom-css" }})" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" CustomAttributes="@(new Dictionary<string, object>(){ { "class", "custom-css" }})" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name"  Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                ShipCity = (new string[] { "Seattle", "Tacoma", "Redmond", "Kirkland", "London" })[new Random().Next(5)],
                ShipName = (new string[] { "Around the Horn", "Berglunds snabbköp", "Blondel père et fils", "Ernst Handel" })[new Random().Next(4)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
}

<style>
    .custom-css {
        background: #d7f0f4;
        font-style: italic;
        color:navy
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVKDuDnTisVMfBa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Custom attributes can be used to customize any cell in the grid, including header and footer cells.

## Clip mode

The clip mode feature is useful when you have a long text or content in a grid cell, which overflows the cell’s width or height. It provides options to display the overflow content by either truncating it, displaying an ellipsis or displaying an ellipsis with a tooltip. You can enable this feature by setting [Columns.ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) property to one of the below available options.

There are three types of [ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) available:

* **Clip**: Truncates the cell content when it overflows its area.
* **Ellipsis**: Displays ellipsis when the cell content overflows its area.
* **EllipsisWithTooltip**: Displays ellipsis when the cell content overflows its area, also it will display the tooltip while hover on ellipsis is applied. Also it will display the tooltip while hover on ellipsis is applied.

The following example demonstrates, how to set the [ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) property for the **Main Fields of Invention** column .Also change the `ClipMode` property to **Clip**,**Ellipsis** and **EllipsisWithTooltip** on changing the dropdown value using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html#Syncfusion_Blazor_Buttons_SfSwitch_1_ValueChange) event of the DropDownList component

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

 <label > Change the clip mode: </label>
 <SfDropDownList TValue="ClipMode" TItem="DdlClass" DataSource="@DdlData" Width="100px">
      <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
      <DropDownListEvents ValueChange="OnChange" TValue="ClipMode" TItem="DdlClass"></DropDownListEvents>
 </SfDropDownList>

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.Inventor) HeaderText="Name of the inventor" Width="80"></GridColumn>
        <GridColumn Field=@nameof(Order.PatentFamilies) HeaderText="No of patent families" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.Country) HeaderText="Country" Width="80"></GridColumn>
        <GridColumn Field=@nameof(Order.NumberofINPADOCpatents) HeaderText="Number of INPADOC patents" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.MainFields) HeaderText="Main fields of Invention" ClipMode="@ClipVal" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<Order> Grid { get; set; }

    public List<Order> Orders { get; set; }

    public ClipMode ClipVal { get; set; } = ClipMode.Clip;

    public void OnChange(ChangeEventArgs<ClipMode, DdlClass> Args)
    {
        ClipVal = Args.Value;
        Grid.Refresh();
    }

    List<DdlClass> DdlData = new List<DdlClass>
{
        new DdlClass() { Text = "Clip", Value =ClipMode.Clip },
        new DdlClass() { Text = "Ellipsis", Value = ClipMode.Ellipsis},
        new DdlClass() { Text = "Ellipsis With Tooltip", Value = ClipMode.EllipsisWithTooltip }
};
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                Inventor = (new string[] { "Kia Silverb", "Shunpei Yamazaki", "Lowell L. Wood, Jr.", "Paul Lap", "Gurtej Sandhu" })[new Random().Next(5)],
                PatentFamilies = 1000 + x * 5,
                NumberofINPADOCpatents = 9839 + x ,
                Country = (new string[] { "Australia", "Japan", "Canada", "India", "USA" })[new Random().Next(5)],
                MainFields = (new string[] { "Printing, Digital paper, Internet, Electronics,Lab-on-a-chip, MEMS, Mechanical, VLSI", "Various", "Printing, Digital paper, Internet, Electronics, CGI, VLSI", "Automotive, Stainless steel products", "Gaming machines" })[new Random().Next(5)],
            }).ToList();
    }
    public class DdlClass
    {
        public string Text { get; set; }
        public ClipMode Value { get; set; }
    }

    public class Order
    {
        public string Inventor { get; set; }
        public int? PatentFamilies { get; set; }
        public int? NumberofINPADOCpatents { get; set; }
        public string Country { get; set; }
        public string MainFields { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBUNkZdWxzwuxNo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * By default, [Columns.ClipMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ClipMode) value is **Ellipsis**.
> * If you set the **width** property of a column, the clip mode feature will be automatically applied to that column if the content exceeds the specified width.
> * Be careful when using the Clip mode, as it may result in important information being cut off. It is generally recommended to use the Ellipsis or EllipsisWithTooltip modes instead.

## Tooltip

The Syncfusion Grid allows you to display information about the grid columns to the user when they hover over them with the mouse.

### Display custom tooltip for columns

The Grid provides a feature to display custom tooltips for its columns using the [SfTooltip](https://blazor.syncfusion.com/documentation/tooltip/getting-started) component. This allows you to provide additional information about the columns when the user hovers over them.

To enable custom tooltips for columns in the Grid,you can use the [Column Template](https://blazor.syncfusion.com/documentation/datagrid/column-template) feature by rendering the components inside the template

This is demonstrated in the following sample code, where the tooltip for the **FirstName** column is rendered using `Column Template`.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Popups

<SfGrid DataSource="@Employees">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="130">
            <Template>
                @{
                    var employee = (context as EmployeeData);
                    Count++;
                     <SfTooltip @key="@Count" Position="Position.BottomLeft">
                        <ContentTemplate>
                            
                                @employee.FirstName
                            
                        </ContentTemplate>
                        <ChildContent>
                            <span>@employee.FirstName</span>
                        </ChildContent>
                      
                    </SfTooltip>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.HireDate) HeaderText="Hire Date" Format="d" TextAlign="TextAlign.Right" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<EmployeeData> Employees { get; set; }

    int Count { get; set; } = 0;

    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
        {
            EmployeeID = x,
            FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
            LastName = (new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" })[new Random().Next(5)],
            Title = (new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager",
                                    "Inside Sales Coordinator" })[new Random().Next(4)],
            HireDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime? HireDate { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBUXxhczXWCAKzo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Grid lines

The [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GridLines) in a grid are used to separate the cells with horizontal and vertical lines for better readability. You can enable the grid lines by setting the `GridLines`  property to one of the following values:

| Modes | Actions |
|-------|---------|
| Both | Displays both the horizontal and vertical DataGrid lines.|
| None | No DataGrid lines are displayed.|
| Horizontal | Displays the horizontal DataGrid lines only.|
| Vertical | Displays the vertical DataGrid lines only.|
| Default | Displays DataGrid lines based on the theme.|

The following example demonstrates how to set the `GridLines` property based on changing the dropdown value using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html#Syncfusion_Blazor_Buttons_SfSwitch_1_ValueChange) event of the DropDownList component.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<label > Change the grid lines: </label>
<SfDropDownList TValue="GridLine" TItem="DdlClass" DataSource="@DdlData" Width="100px">
   <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
   <DropDownListEvents ValueChange="OnChange" TValue="GridLine" TItem="DdlClass"></DropDownListEvents>
</SfDropDownList>


<SfGrid DataSource="@Orders" GridLines="@GridLineVal" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.Inventor) HeaderText="Name of the inventor" Width="180"></GridColumn>
        <GridColumn Field=@nameof(Order.PatentFamilies) HeaderText="No of patent families" Width="180"></GridColumn>
        <GridColumn Field=@nameof(Order.Country) HeaderText="Country" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.Active) HeaderText="Active" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.MainFields) HeaderText="Main fields of Invention" Width="200"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<Order> Grid { get; set; }

    public List<Order> Orders { get; set; }

    public GridLine GridLineVal { get; set; } = GridLine.Both;

    public void OnChange(ChangeEventArgs<GridLine, DdlClass> Args)
    {
        GridLineVal = Args.Value;
    }

    List<DdlClass> DdlData = new List<DdlClass>
{
        new DdlClass() { Text = "Default", Value =GridLine.Default },
        new DdlClass() { Text = "Horizontal", Value = GridLine.Horizontal},
        new DdlClass() { Text = "Vertical", Value = GridLine.Vertical },
        new DdlClass() { Text = "Both", Value = GridLine.Both },
        new DdlClass() { Text = "None", Value = GridLine.None }
};
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {

                Inventor = (new string[] { "Kia Silverb", "Shunpei Yamazaki", "Lowell L. Wood, Jr.", "Paul Lap", "Gurtej Sandhu" })[new Random().Next(5)],
                PatentFamilies = 1000 + x * 5,
                Active = (new string[] { "1888(b)-1965", "1976-2010", "1998-2016", "1976-2016", "1922(b)-2012" })[new Random().Next(5)],
                Country = (new string[] { "Australia", "Japan", "Canada", "India", "USA" })[new Random().Next(5)],
                MainFields = (new string[] { "Printing, Digital paper, Internet, Electronics,Lab-on-a-chip, MEMS, Mechanical, VLSI", "Various", "Printing, Digital paper, Internet, Electronics, CGI, VLSI", "Automotive, Stainless steel products", "Gaming machines" })[new Random().Next(5)],
            }).ToList();
    }
    public class DdlClass
    {
        public string Text { get; set; }
        public GridLine Value { get; set; }
    }

    public class Order
    {
        public string Inventor { get; set; }
        public int? PatentFamilies { get; set; }
        public string Active { get; set; }
        public string Country { get; set; }
        public string MainFields { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhgjYDHsYMePtHJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> By default, the DataGrid renders with **Default** mode.


> You can refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.