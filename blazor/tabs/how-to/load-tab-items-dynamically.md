---
layout: post
title: How to Load Tab Items Dynamically in Blazor Tabs Component | Syncfusion
description: Checkout and learn about Load Tab Items Dynamically in Blazor Tabs component of Syncfusion, and more details.
platform: Blazor
control: Tabs
documentation: ug
---

# Load Tab items dynamically

Tabs can be added dynamically by list of items and index value to the `AddTab` method.

In the following code example, the tab item has been added in which content is passed as `ContentTemplate` using `RenderFragment`.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="OnAddItem" Content="Add Tab"></SfButton>
<SfTab @ref="TabObj">
    <TabItems>
        <TabItem>
            <HeaderTemplate>Grid</HeaderTemplate>
            <ContentTemplate>
                <SfGrid DataSource="@Orders">
                </SfGrid>
            </ContentTemplate>
        </TabItem>
    </TabItems>
</SfTab>

@code{
    SfTab TabObj;
    List<TabItem> TabData;
    public RenderFragment ScheduleContent = builder =>
    {
    builder.AddContent(1, @<SfSchedule TValue=object></SfSchedule>);
    };
    public void OnAddItem()
    {
        TabData = new List<TabItem>()
    {
            new TabItem() { Header = new TabHeader() { Text = "Schedule" }, ContentTemplate = @ScheduleContent }
        };
        TabObj.AddTab(TabData, 0);
    }
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```
