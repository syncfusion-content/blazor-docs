---
layout: post
title: How to Display Custom Tool Tip In Grid Cell in Blazor DataGrid Component | Syncfusion
description: Checkout and learn about Display Custom Tool Tip In Grid Cell in Blazor DataGrid component of Syncfusion, and more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Display Custom Tooltip in DataGrid cell

You can display custom tooltip in Grid column using [`Column Template`](https://blazor.syncfusion.com/documentation/datagrid/columns/#column-template) feature by rendering the [`SfTooltip`](https://blazor.syncfusion.com/documentation/tooltip/getting-started/) components inside the template.

This is demonstrated in the below sample code we have render the tooltip for **FirstName** column using [`Column Template`](https://blazor.syncfusion.com/documentation/datagrid/columns/#column-template).

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
                    <SfTooltip Target="#txt" @key="@Count">
                        <TooltipTemplates>
                            <Content>
                                @employee.FirstName
                            </Content>
                        </TooltipTemplates>
                        <span id="txt">@employee.FirstName</span>
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
