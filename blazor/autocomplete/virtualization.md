---
layout: post
title: Virtualization in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Virtualization in Syncfusion Blazor AutoComplete component and much more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Virtualization in Blazor AutoComplete Component

The AutoComplete component includes a virtual scrolling feature designed to enhance UI performance when handling large data sets. By enabling the [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html#Syncfusion_Blazor_DropDowns_SfDropDownList_2_EnableVirtualization) option, the component renders only a window of items initially and loads additional items on demand as scroll, providing a smooth and efficient experience.

This feature applies to both local and remote data sources. For example, when the AutoComplete is bound to 150 items, only the items that fit within the popup height are rendered when the dropdown opens. As scroll through the list, more items are fetched and rendered incrementally, enabling efficient exploration of the entire data set.

N> Virtualization accuracy depends on consistent item heights. Using templates that significantly change item height may affect the calculation of rendered items. The number of initially rendered items is based on the configured PopupHeight.

## Local data

{% highlight cshtml %}

{% include_relative code-snippet/virtualization/local-data.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhqsLsJUSqMNRqD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor AutoComplete with virtualization](./images/blazor_autocomplete_virtualization.gif)" %}

## Remote data

{% highlight cshtml %}

{% include_relative code-snippet/virtualization/remote-data.razor %}

{% endhighlight %}

![Blazor AutoComplete demonstrating virtualization with remote data](./images/blazor_autocomplete_remote-data-virtualization.gif)

## Grouping with Virtualization

The AutoComplete component supports grouping with Virtualization. It allows elements to be organized into categories. Each item in the list can be classified using the [GroupBy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.AutoCompleteFieldSettings.html#Syncfusion_Blazor_DropDowns_AutoCompleteFieldSettings_GroupBy) field in the data source. After grouping, virtualization behaves similarly to local data binding, providing a seamless user experience. When the data source is remote, an initial request retrieves the data required for grouping. Subsequently, grouped data is handled like local data binding with virtualization, improving performance and responsiveness.

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

Users can navigate through the scrollable content using the keyboard. The component loads the next or previous set of items based on the key inputs within the popup.

| Key | Action |
|-----|-----|
| `ArrowDown` | Loads the next virtual list item when focus is on the last item of the current page. |
| `ArrowUp` | Loads the previous virtual list item when focus is on the first item of the current page. |
| `PageDown` | Loads the next page and moves focus to its last item. |
| `PageUp` | Loads the previous page and moves focus to its first item. |