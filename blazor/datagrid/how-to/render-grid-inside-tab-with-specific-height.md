---
layout: post
title: Blazor Grid Rendered Inside a Tab Using Fixed Height | Syncfusion
description: Learn how to render Blazor Data Grid inside a Tab with specific height, fixed headers, scrollable content, and responsive layout support.
platform: Blazor
control: DataGrid
documentation: ug
---

# Render Blazor Data Grid Inside a Tab with Specific Height

By default, the [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) occupies the full size of its parent element when the Data Grid [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Width) properties are set to 100%. When Data Grid is placed inside the [SfTab](https://blazor.syncfusion.com/documentation/tabs/getting-started-webapp) component, however, it may consider the entire page height and render without a horizontal scrollbar.

To ensure the Data Grid scrolls within the Tab content area (keeping the tab header fixed), override the Tab content height with CSS so the Data Grid receives a well-defined parent height.

> Notes:
> - The parent container of the Tab must have an explicit height or a height resolved by CSS layout.
> - The example uses a fixed wrapper height of `500px`. Change the wrapper height to match the surrounding layout.
> - The flex layout assigns the remaining parent height to the Tab content and avoids a hard-coded tab-header offset.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Grids
@using System.Linq

<div class="tab-grid-container">
    <SfTab ID="GridTab" Height="100%">
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
    .tab-grid-container {
        height: 500px;
    }

    #GridTab.e-tab {
        display: flex;
        flex-direction: column;
    }

    #GridTab.e-tab > .e-content {
        flex: 1 1 auto;
        min-height: 0;
        height: auto;
    }

    #GridTab.e-tab > .e-content .e-item {
        height: 100%;
    }
</style>
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrnNvLRpfJREQrm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}