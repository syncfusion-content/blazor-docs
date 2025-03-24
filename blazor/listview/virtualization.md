---
layout: post
title: Virtualization in Blazor ListView Component | Syncfusion
description: Checkout and learn here all about virtualization in Syncfusion Blazor ListView component and much more.
platform: Blazor
control: Listview
documentation: ug
---

# Virtualization in Blazor ListView Component

UI virtualization loads only viewable list items in a view port, which will improve the ListView performance while loading a large number of data.

## Enable UI Virtualization

UI virtualization can be enabled in the ListView by setting the [`EnableVirtualization`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_EnableVirtualization) property to true. It has two types of scrollers as follows:

**Window scroll**: This scroller is used in the ListView by default.

**Container scroll**: This scroller is used, when the height property of the ListView is set.

```cshtml
@using Syncfusion.Blazor.Lists
<SfListView DataSource="@ListData" EnableVirtualization="true">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text"></ListViewFieldSettings>
</SfListView>

@code{
    List<DataModel> ListData = new List<DataModel>();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ListData.Add(new DataModel
        {
            Text = "Nancy",
            Id = "0"
        });
        ListData.Add(new DataModel
        {
            Text = "Andrew",
            Id = "1"
        });
        ListData.Add(new DataModel
        {
            Text = "Janet",
            Id = "2"
        });
        ListData.Add(new DataModel
        {
            Text = "Margaret",
            Id = "3"
        });
        ListData.Add(new DataModel
        {
            Text = "Steven",
            Id = "4"
        });
        ListData.Add(new DataModel
        {
            Text = "Laura",
            Id = "5"
        });
        ListData.Add(new DataModel
        {
            Text = "Robert",
            Id = "6"
        });
        ListData.Add(new DataModel
        {
            Text = "Michael",
            Id = "7"
        });
        ListData.Add(new DataModel
        {
            Text = "Albert",
            Id = "8"
        });
        ListData.Add(new DataModel
        {
            Text = "Nolan",
            Id = "9"
        });

        for (int i = 10; i < 1000; i++)
        {
            int index = new Random().Next(0, 10);
            ListData.Add(new DataModel
            {
                Text = ListData[index].GetType().GetProperty("Text").GetValue(ListData[index], null).ToString(),
                Id = i.ToString()
            });
        }

    }

    public class DataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
    }
}
```

![Virtualization in Blazor ListView](./images/list/blazor-listview-virtualization.png)

## Limitations for virtualization

* When enabling virtualization for ListView, it is important to specify the height in pixels. Percentage values are not accepted.
* If you prefer to use a percentage value, you can render the component within a div container with a specific pixel value set for height (It will be rendered based on the parent container height).
