---
layout: post
title: Virtualization in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Virtualization in Syncfusion Blazor AutoComplete component and much more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Virtualization in Blazor AutoComplete Component

The AutoComplete component includes a virtual scrolling feature designed to enhance UI performance, particularly for handling large datasets. By enabling the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_EnableVirtualization) option, the AutoComplete intelligently manages data rendering, ensuring only a subset of items is initially loaded when the component is rendered. As you interact with the dropdown, additional items are dynamically loaded as you scroll, creating a smooth and efficient user experience.

This feature is applicable to both local and remote data scenarios, providing flexibility in its implementation. For instance, consider a case where the AutoComplete is bound to a dataset containing 150 items. Upon opening the dropdown, only a few items are loaded initially, based on the height of the popup. As you scroll through the list, additional items are fetched and loaded on-demand, allowing you to effortlessly explore the complete dataset.

## Local data

{% highlight cshtml %}

{% include_relative code-snippet/virtualization/local-data.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhqsLsJUSqMNRqD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete with virtualization](./images/blazor_autocomplete_virtualization.gif)" %}

## Remote data

{% highlight cshtml %}

{% include_relative code-snippet/virtualization/remote-data.razor %}

{% endhighlight %}

![Blazor AutoComplete with virtualization](./images/blazor_autocomplete_remote-data-virtualization.gif)

## Grouping with Virtualization

The AutoComplete component supports grouping with Virtualization. It allows you to organize elements into groups based on different categories. Each item in the list can be classified using the [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_GroupBy) field in the data table. After grouping, virtualization works similarly to local data binding, providing a seamless user experience. When the data source is bound to remote data, an initial request is made to retrieve all data for the purpose of grouping. Subsequently, the grouped data works in the same way as local data binding virtualization, enhancing performance and responsiveness.

The following sample shows the example for Grouping with Virtualization.

```cshtml

@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Data

<SfAutoComplete TValue="string" TItem="Record" Placeholder="e.g. Item 1" DataSource="@Records" Query="@LocalDataQuery" PopupHeight="130px" EnableVirtualization="true" ShowPopupButton="true">
        <AutoCompleteFieldSettings Value="Text" GroupBy="Group"/>
</SfAutoComplete>

@code{
    public Query LocalDataQuery = new Query().Take(6);
    public class Record 
    { 
        public string ID { get; set; } 
        public string Text { get; set; } 
        public string Group { get; set; }
    } 
    public List<Record> Records { get; set; }
    protected override void OnInitialized()
    {
        var random = new Random();
        this.Records = Enumerable.Range(1, 150).Select(i => new Record()
            {
                ID = i.ToString(),
                Text = "Item " + i,
                Group = GetRandomGroup(random)
            }).ToList();
    }
    private string GetRandomGroup(Random random)
    {
        switch (random.Next(1, 5))
        {
            case 1:
                return "Group A";
            case 2:
                return "Group B";
            case 3:
                return "Group C";
            case 4:
                return "Group D";
            default:
                return string.Empty;
        }
    }
}
```

## Keyboard interaction

Users can navigate through the scrollable content using keyboard keys. This feature loads the next or next set of items based on the key inputs in the popup.

| Key | Action |
|-----|-----|
| `ArrowDown` | Loads the next virtual list item if the focus is present in last item of the current page. |
| `ArrowUp` | Loads the previous virtual list item if the focus is present in first item of the current page. |
| `PageDown` | Loads the next page and focus the last item in it. |
| `PageUp` | Loads the previous page and focus the first item in it. |
