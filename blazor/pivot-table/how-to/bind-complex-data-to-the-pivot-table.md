---
layout: post
title: Convert complex data and assign it to the Blazor | Syncfusion
description: Learn here all about how to convert complex data to flat data and assign it to the Syncfusion Blazor Pivot Table component and more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Convert complex data to flat data and assign it to the Pivot Table

The Pivot Table component requires flat data for binding. Complex data, such as nested objects or hierarchical structures, must be converted into a flat structure before it can be assigned to the Pivot Table using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_DataSource) property within [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html).

In the example below, the `ConvertToFlatData` function transforms complex data with nested objects (e.g., `ShipDetails`) into flat data using `ExpandoObject`. The converted data is then assigned to the Pivot Table using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html#Syncfusion_Blazor_PivotView_PivotViewDataSourceSettings_1_DataSource) property. Field names are mapped to rows, columns, and values under [PivotViewDataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) to display the data effectively.

```cshtml
@using Syncfusion.Blazor.PivotView
@using System.Dynamic

<SfPivotView TValue="ExpandoObject">
    <PivotViewDataSourceSettings DataSource="@Orders">
        <PivotViewColumns>
            <PivotViewColumn Name="OrderID"></PivotViewColumn>
            <PivotViewColumn Name="ShipName"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="CustomerID"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="OrderDate"></PivotViewValue>
            <PivotViewValue Name="Freight" Type="SummaryTypes.Max"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
</SfPivotView>

@code {
    public List<ExpandoObject> Orders { get; set; } = new List<ExpandoObject>();
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select((x) =>
        {
            dynamic d = new ExpandoObject();
            d.OrderID = 1000 + x;
            d.CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)];
            d.Freight = (new double[] { 2, 1, 4, 5, 3 })[new Random().Next(5)] * x;
            d.OrderDate = (new DateTime[] { new DateTime(2010, 11, 5), new DateTime(2018, 10, 3), new DateTime(1995, 9, 9), new DateTime(2012, 8, 2), new DateTime(2015, 4, 11) })[new Random().Next(5)];
            d.ShipCountry = (new string[] { "USA", "UK" })[new Random().Next(2)];
            d.Verified = (new bool[] { true, false })[new Random().Next(2)];
            d.ShipDetails = new ExpandoObject();
            d.ShipDetails.ShipName = (new string[] { "ALTEN-I", "BONTER", "GITOR", "MELON", "CRUISE" })[new Random().Next(5)];
            d.ShipDetails.ShipId = 25000 + x;
            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
        Orders = ConvertToFlatData(Orders);
    }

    public List<ExpandoObject> ConvertToFlatData(List<ExpandoObject> Data)
    {
        List<ExpandoObject> flatData = new List<ExpandoObject>();        
        foreach (var item in Data)
        {
            dynamic obj = new ExpandoObject();
            foreach (var child in item)
            {
                if (child.Value.ToString() == "System.Dynamic.ExpandoObject")
                {
                    var dynamicObj = (IDictionary<string, object>)child.Value;
                    foreach (var New in dynamicObj)
                    {
                        var field = New.Key;
                        var fieldvalue = dynamicObj[field];
                        ((IDictionary<String, Object>)obj).Add(field, fieldvalue);
                    }
                }
                else
                {
                    var field = child.Key;
                    var dynamicObj = (IDictionary<string, object>)item;
                    var fieldvalue = dynamicObj[field];
                    ((IDictionary<String, Object>)obj).Add(field, fieldvalue);
                }
            }
            flatData.Add(obj);
        }
        return flatData;
    }
}

```

![Convert complex data to flat data and bind it to the Blazor Pivot Table](images/blazor-pivottable-complex-expando-data-binding.png)
