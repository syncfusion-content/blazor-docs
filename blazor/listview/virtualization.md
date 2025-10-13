---
layout: post
title: Virtualization in Blazor ListView Component | Syncfusion
description: Checkout and learn here all about virtualization in Syncfusion Blazor ListView component and much more.
platform: Blazor
control: Listview
documentation: ug
---

# Virtualization in Blazor ListView Component

UI virtualization significantly improves ListView performance when loading and displaying large numbers of data items. It achieves this by rendering only the list items currently visible within the user's viewport, rather than rendering the entire dataset.

## Enable UI Virtualization

UI virtualization is enabled in the ListView by setting the [`EnableVirtualization`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Lists.SfListView-1.html#Syncfusion_Blazor_Lists_SfListView_1_EnableVirtualization) property to `true`. It has two types of scrollers as follows:

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZheCjjsUxRvLQZl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Virtualization in Blazor ListView](./images/list/blazor-listview-virtualization.png)

## Limitations for Virtualization

* When enabling virtualization for ListView, it is important to specify the height in pixels. Percentage values are not accepted.
* If a percentage height is preferred, the component can be rendered within a `div` container that has a specific pixel value set for its height. The ListView will then render based on the parent container's defined height.
