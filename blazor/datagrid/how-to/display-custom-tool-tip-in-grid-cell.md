---
layout: post
title: Display Custom Tooltip in Blazor DataGrid Cell | Syncfusion
description: Checkout and learn here all about displaying custom tooltip in Syncfusion Blazor DataGrid cell and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Display Custom Tooltip in Blazor DataGrid Cell

You can display a custom tooltip in a Syncfusion Blazor DataGrid cell using the [Column Template](https://blazor.syncfusion.com/documentation/datagrid/columns#column-template) feature. This allows you to embed the [SfTooltip](https://blazor.syncfusion.com/documentation/tooltip/getting-started) within a column and show additional information when hovering over a cell.

In the example below, the tooltip is added to the **FirstName** column by placing the `SfTooltip` inside the `Template` tag. The tooltip displays the cell value and is uniquely keyed using a counter to avoid rendering issues.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor

<SfGrid DataSource="@Employees">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) HeaderText="Employee ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
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
        <GridColumn Field=@nameof(EmployeeData.HireDate) HeaderText="Hire Date" Format="d" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<EmployeeData> Employees { get; set; }
    int Count { get; set; } = 0;
    protected override void OnInitialized()
    {
        Employees = Enumerable.Range(1, 9).Select(x => new EmployeeData()
            {
                EmployeeID = x,
                FirstName = (new string[] { "Nancy", "Andrew", "Janet", "Margaret", "Steven" })[new Random().Next(5)],
                LastName = (new string[] { "Davolio", "Fuller", "Leverling", "Peacock", "Buchanan" })[new Random().Next(5)],
                Title = (new string[] { "Sales Representative", "Vice President, Sales", "Sales Manager","Inside Sales Coordinator" })[new Random().Next(4)],
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
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBSZTLapLOZbbuz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}