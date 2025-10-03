---
layout: post
title: Grouping in Blazor ListView Component | Syncfusion
description: Checkout and learn here all about grouping in Syncfusion Blazor ListView component and much more details.
platform: Blazor
control: Listview
documentation: ug
---

# Grouping in Blazor ListView Component

The ListView component supports grouping its list items based on a specified category. The [`GroupBy`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.ListViewFieldSettings-1.html#Syncfusion_Blazor_Lists_ListViewFieldSettings_1_GroupBy) property in the `ListViewFieldSettings` is used to map the category field from the data table, enabling this grouping functionality, that also supports single-level navigation.

```cshtml
@using Syncfusion.Blazor.Lists
<SfListView DataSource="@DataSource">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text" GroupBy="Type"></ListViewFieldSettings>
</SfListView>

@code {
    public string HeaderTitle = "Listview";

    List<DataModel> DataSource = new List<DataModel>()
{
        new DataModel { Id = "1", Text = "1", Type = "Odd"},
        new DataModel { Id = "2", Text = "2", Type = "Even"},
        new DataModel{ Id = "3", Text = "3", Type = "Odd"},
        new  DataModel{ Id = "4", Text = "4", Type = "Even"},
    };

    public class DataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Type { get; set; }
    }

}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBIsZXCUxpxAKTt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Grouping in Blazor ListView](./images/list/blazor-listview-grouping.png)