---
layout: post
title: Pager with Template in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about how to render a custom element in the Syncfusion Blazor Pager component and much more.
platform: Blazor
control: Pager
documentation: ug
---

# Pager Component with Template

The Pager component provides an option to render a custom element or content in the Pager. This can be achieved by using the `Template` property of the Pager. 

In this following sample, we have rendered two anchor tags for navigating next and previous pages. And the pager info detail is displayed in between those two anchor tags. The anchor tags will be disabled based on the current page number using Pager APIs.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

<div class="control-section"> 
    <SfGrid @ref="Grid" DataSource="@Orders" Query="@QueryData">
        <GridColumns>
            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
            <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
            <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.ShippedDate) HeaderText=" Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        </GridColumns>
    </SfGrid>

    <SfPager @ref="Pager" TotalItemsCount=80 NumericItemsCount=5 PageSize=10 CurrentPage=1 PageSizes=true >
        <Template>
            @{
                var Page = (context as PagerTemplateContext);
                <div class=" e-pagerContainer">
                    <div class="@($" e-navigationStyle {EnablePreviousButton()}")" @onclick="NavigatePreviousPage">
                        <a>Previous</a>
                    </div>
                    <div>
                       <span>Page </span><div><SfDropDownList Width="64px" Value=@(ddlIndex+1)  DataSource=@DropdownDataSource TValue="int" TItem="TemplateDropdown">
                <DropDownListEvents TItem="TemplateDropdown" TValue="int" ValueChange="@ValueChangeHandler" ></DropDownListEvents>
                <DropDownListFieldSettings Value="Paging" ></DropDownListFieldSettings>
                </SfDropDownList></div><span> of <b>@Page.TotalPages</b></span>
                    </div>
                    <div class="@($" e-navigationStyle {EnableNextButton()}")" @onclick="NavigateNextPage">
                        <a>Next</a>
                    </div>
                </div>
            }
        </Template>    
    </SfPager>
</div>

@code
{
    public List<Order> Orders { get; set; }
    public SfGrid<Order> Grid { get; set; }    
    public SfPager Pager { get; set; }
    private bool BackButtonDisabled { get; set; } = true;
    private bool ForwardButtonDisabled { get; set; }
    private Query QueryData = new Syncfusion.Blazor.Data.Query().Skip(0).Take(10);
    public int ddlIndex { get; set; } = 0;

    private async Task ValueChangeHandler(ChangeEventArgs<int, TemplateDropdown> args)
    {
        var currentPage = args.Value -1;
        int skipValue = (currentPage *  Pager.PageSize);
        int takeValue = Pager.PageSize;
        QueryData = new Query().Skip(skipValue).Take(takeValue);
        ddlIndex = currentPage;
        int totalPages = (int)(Math.Ceiling((double)(Pager.TotalItemsCount / Pager.PageSize)));
        if (args.Value == totalPages)
        {
            ForwardButtonDisabled = true;
            BackButtonDisabled = false;
        }
        else if (args.Value == 1)
        {
            ForwardButtonDisabled = false;
            BackButtonDisabled = true;
        }
        else
        {
            ForwardButtonDisabled = false;
            BackButtonDisabled = false;
        }
        await Task.Yield();
        await Grid.Refresh();
        await Pager.GoToPageAsync(args.Value);
    }

    public string EnablePreviousButton()
    {
        string classNames = BackButtonDisabled ? "e-disabled disable-pointer" : "enable-pointer";
        return classNames;
    }

    public string EnableNextButton()
    {
        string classNames = ForwardButtonDisabled ? "e-disabled e-disable disable-pointer" : "enable-pointer";
        return classNames;
    }

    public async Task NavigatePreviousPage()
    {
        ForwardButtonDisabled = ForwardButtonDisabled ? false : ForwardButtonDisabled;
        BackButtonDisabled = Pager.CurrentPage == 2 ? true : false;
        int skipValue = (Pager.CurrentPage * Pager.PageSize) - (Pager.PageSize * 2);
        int takeValue = Pager.PageSize;
        QueryData = new Query().Skip(skipValue).Take(takeValue);
        ddlIndex--;
        await Grid.Refresh();
        await Pager.GoToPreviousPageAsync();
    }

    public async Task NavigateNextPage()
    {
        BackButtonDisabled = BackButtonDisabled ? false : BackButtonDisabled;
        int totalPages = (int)(Math.Ceiling((double)(Pager.TotalItemsCount / Pager.PageSize)));
        ForwardButtonDisabled = Pager.CurrentPage == totalPages - 1 ? true : false;
        int skipValue = (Pager.CurrentPage * Pager.PageSize);
        int takeValue = Pager.PageSize;
        QueryData = new Query().Skip(skipValue).Take(takeValue);
        ddlIndex++;
        await Grid.Refresh();
        await Pager.GoToNextPageAsync();
    }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 80).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShippedDate = DateTime.Now.AddDays(x),
        }).ToList();
       
    }

    public class Order 
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public DateTime? ShippedDate { get; set; }
    }
    public class TemplateDropdown
    {
        public int Paging { get; set; }
    }
    List<TemplateDropdown> DropdownDataSource = new List<TemplateDropdown>
    {
        new TemplateDropdown() { Paging = 1},
        new TemplateDropdown() { Paging = 2},
        new TemplateDropdown() { Paging = 3},
        new TemplateDropdown() { Paging = 4},
        new TemplateDropdown() { Paging = 5},
        new TemplateDropdown() { Paging = 6},
        new TemplateDropdown() { Paging = 7},
        new TemplateDropdown() { Paging = 8}
    };
}

<style>
    .disable-pointer{
        pointer-events: none;
    }
    .enable-pointer{
        pointer-events: auto;
    }
    .disable-hover{
        pointer-events: none;
    }
    .e-navigationStyle {
        padding: 13px 12px 10px 12px;
        text-align: center;
        min-width: 26px;
    }
</style>
```

![Blazor Pager with Template](./images/blazor-pager-with-template.gif)