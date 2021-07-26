---
layout: post
title: Grouping in Blazor Listview Component | Syncfusion 
description: Learn about Grouping in Blazor Listview component of Syncfusion, and more details.
platform: Blazor
control: Listview
documentation: ug
---

# Grouping

The ListView supports to wrap the nested element into a group based on the category. The category of each list item can be mapped with GroupBy field in the data table, that also supports single-level navigation.

In the following sample, The cars are grouped based on its category by using the GroupBy field in ListViewFieldSettings.

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

![ListView - Grouping](./images/list/grouping-simple.png)
