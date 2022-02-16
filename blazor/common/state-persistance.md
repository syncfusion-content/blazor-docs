---
layout: post
title: State Persistance in Blazor - Syncfusion
description: Check out the documentation for State Persistance support in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# State Persistence

The Syncfusion Blazor library supports persisting a component's state across page refreshes or navigation. To enable this feature, set the `EnablePersistence` property to `true` to the required component. This will store the component's state in the browser’s `localStorage` object on-page `unload` event. For example, persistence has been enabled to the grid component in the following code.

> The state of a component will be retained during navigation or refreshment based on the ID. Make sure to set an ID for the component to store the component's state in the browser.

{% tabs %}
{% highlight razor %}
@using Syncfusion.Blazor.Grids

<SfGrid  ID="grid" EnablePersistence="true" AllowPaging="true" DataSource="@Orders">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) Format="C2" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Orders = Enumerable.Range(1, 25).Select(x => new Order()
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
{% endhighlight %}
{% endtabs %}

## State Persistence Supported Components and Properties

The following table demonstrates the list of Syncfusion Blazor components that are supported with state persistence and describes the list of properties stored in the `localStorage`.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Component Name</b></td>
<td><b>Properties</b></td>
</tr>
<tr>
<td>SfGrid</td>
<td>
<ul>
<li>Columns</li>
<li>GridFilterSettings</li>
<li>GridSortSettings</li>
<li>GridGroupSettings</li>
<li>GridPageSettings</li>
</ul>
</td>
</tr>
<tr>
<td>SfPivotView</td>
<td>
<ul>
<li>DataSourceSettings</li>
<li>GridSettings</li>
<li>ChartSettings</li>
<li>DisplayOptions</li>
</ul>
</td>
</tr>
<tr>
<td>SfTreeGrid</td>
<td>
<ul>
<li>Columns</li>
<li>FilterSettings</li>
<li>PageSettings</li>
<li>SearchSettings</li>
<li>SortSettings</li>
</ul>
</td>
</tr>
<tr>
<td>SfAccordion</td>
<td>
<ul>
<li>ExpandedIndices</li>
</ul>
</td>
</tr>
<tr>
<td>SfTab</td>
<td>
<ul>
<li>SelectedItem</li>
</ul>
</td>
</tr>
<tr>
<td>SfSchedule</td>
<td>
<ul>
<li>CurrentView</li>
<li>SelectedDate</li>
<li>ScrollTop</li>
<li>ScrollLeft</li>
</ul>
</td>
</tr>
<tr>
<td>SfSplitter</td>
<td>
<ul>
<li>Collapsed</li>
<li>Min</li>
<li>Max</li>
<li>Size</li>
</ul>
</td>
</tr>
<tr>
<td>SfDateRangePicker</td>
<td>
<ul>
<li>StartDate</li>
<li>EndDate</li>
</ul>
</td>
</tr>
<tr>
<td>SfUploader</td>
<td>
<ul>
<li>FilesData</li>
</ul>
</td>
</tr>
<tr>
<td>SfTreeView</td>
<td>
<ul>
<li>CheckedNodes</li>
<li>ExpandedNodes</li>
<li>SelectedNodes</li>
</ul>
</td>
</tr>
<tr>
<td>SfDashboardLayout</td>
<td>
<ul>
<li>Panels</li>
</ul>
</td>
</tr>
<tr>
<td>SfFileManager</td>
<td>
<ul>
<li>View</li>
<li>Path</li>
<li>SelectedItems</li>
</ul>
</td>
</tr>
<tr>
<td>SfSidebar</td>
<td>
<ul>
<li>IsOpen</li>
</ul>
</td>
</tr>
<tr>
<td>SfQueryBuilder</td>
<td>
<ul>
<li>Rule</li>
</ul>
</td>
</tr>
<tr>
<td>SfInplaceEditor</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfRichTextEditor</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfAutoComplete</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfCalendar</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfComboBox</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfDatePicker</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfDropDownList</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfMaskedTextBox</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfNumericTextBox</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfTextBox</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfTimePicker</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfMultiSelect</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfDateTimePicker</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
<tr>
<td>SfSlider</td>
<td>
<ul>
<li>Value</li>
</ul>
</td>
</tr>
</table>
<!-- markdownlint-enable MD033 -->