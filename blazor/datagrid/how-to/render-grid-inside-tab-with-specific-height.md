---
layout: post
title: Blazor DataGrid Inside the Tab with Specific Height | Syncfusion
description: Learn to render Syncfusion Blazor DataGrid inside a Tab with fixed header and scrollable content using a specific tab height.
platform: Blazor
control: DataGrid
documentation: ug
---

# Blazor DataGrid inside the tab with specific height

By default, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid occupies the full size of its parent element when the Grid [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Width) properties are set to 100%. When placing the same Grid inside the [SfTab](https://blazor.syncfusion.com/documentation/tabs/getting-started-webapp) component, however, it may consider the entire page height and render without a horizontal scrollbar.

To ensure the Grid scrolls within the Tab content area (keeping the tab header fixed), override the Tab content height with CSS so the Grid receives a well-defined parent height.

> Notes:
- The parent container of the Tab must have an explicit height (for example, a fixed pixel height or a flex container with a resolved height).
- The value used to subtract the tab header (36px below) is theme-dependent and may need adjustment based on the chosen theme and device density.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Grids
@using System.Linq

<div style="height:500px">
    <SfTab ID="Ej2Tab" Height="100%">
        <TabItems>
            <TabItem>
                <HeaderTemplate>
                    Grid1
                </HeaderTemplate>
                <ContentTemplate>     
                    <SfGrid DataSource="@Orders" Height="100%" Width="100%">
                        <GridColumns>
                            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
                            <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
                            <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                        </GridColumns>
                    </SfGrid>
                </ContentTemplate>
            </TabItem>
            <TabItem>
                <HeaderTemplate>
                    Grid2
                </HeaderTemplate>
                <ContentTemplate>        
                    <SfGrid DataSource="@Employees" Height="100%" Width="100%">
                        <GridColumns>
                            <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="ID" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
                            <GridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="150"></GridColumn>
                            <GridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="150"></GridColumn>
                            <GridColumn Field=@nameof(EmployeeData.HireDate) HeaderText="Hire Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
                            <GridColumn Field=@nameof(EmployeeData.Role) HeaderText="Position" Width="120"></GridColumn>
                        </GridColumns>
                    </SfGrid>   
                </ContentTemplate>
            </TabItem>
        </TabItems>
    </SfTab>
</div>

@code {
    private static readonly Random random = new Random();

    public List<Order> Orders { get; set; }
    public List<EmployeeData> Employees { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[random.Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();

        Employees = Enumerable.Range(1, 75).Select(x => new EmployeeData()
        {
            EmployeeID = x,
            FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[random.Next(5)],
            LastName = (new string[] { "Davolio", "Fuller", "Leveringg", "Peacock", "Smith" })[random.Next(5)],
            Role = (new string[] { "Sales Representative", "Sales Representative", "Sales Manager", "HR Manager", "Inside Sales Coordinator" })[random.Next(5)],
            HireDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public DateTime? HireDate { get; set; }
    }
}

<style>
    /* Adjust the content area to fill available height below the tab header.
       The 36px subtraction is an example and may differ by theme/density. */
    .e-tab > .e-content {
        height: calc(100% - 36px); /* tab height - tab header height */
    }
    .e-tab > .e-content .e-item {
        height: 100%;
    }
</style>
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtByDTUtUQZxuNwG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}