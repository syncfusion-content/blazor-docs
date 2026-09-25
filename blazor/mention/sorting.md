---
layout: post
title: Sorting in Blazor Mention | Syncfusion
description: Sort Blazor Mention suggestion lists in ascending, descending, or original order using the SortOrder property.
platform: Blazor
control: Mention
documentation: ug
---

# Sorting in Blazor Mention

The [SfMention](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html) component supports sorting its suggestion list using the [`SortOrder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html#Syncfusion_Blazor_DropDowns_SfDropDownBase_1_SortOrder) property (inherited from [SfDropDownBase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownBase-1.html)).

The [`SortOrder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html) enum determines the order in which suggestion list items are displayed:

SortOrder     | Description
------------  | -------------
  [`Ascending`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html) | The suggestion list items will be sorted in ascending (A→Z) order, alphabetically by the Text field.
  [`Descending`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html) | The suggestion list items will be sorted in descending (Z→A) order, alphabetically by the Text field.
  [`None`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SortOrder.html)      | The suggestion list items will not be sorted and will appear in the same order as provided in the DataSource.

> **Note:**
> - `SortOrder` sorts items based on the Text field specified in [`MentionFieldSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.MentionFieldSettings.html). String values are sorted alphabetically.
> - For remote data, `SortOrder` sorts only the items already fetched (up to `SuggestionCount`). For server-side sorting, configure the sort order on the remote endpoint.
> - When `SortOrder` is `None`, items appear in the same order as in the DataSource.

See the [SfMention API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfMention-1.html) for all available properties.

## Examples

### Descending order
```razor
{% include_relative code-snippet/sorting.razor %}
```
![SfMention suggestion list displaying sports data sorted in descending alphabetical order](./images/blazor-mention-sorting.webp)

### Ascending order
```razor
{% include_relative code-snippet/sorting-ascending.razor %}
```
![SfMention suggestion list displaying sports data sorted in ascending alphabetical order](./images/blazor-mention-sorting-ascending.webp)

### None (default)
```razor
{% include_relative code-snippet/sorting-none.razor %}
```
![SfMention suggestion list displaying sports data in original DataSource order](./images/blazor-mention-sorting-none.webp)

SortOrder     | Description
------------  | -------------
  `Ascending` | The suggestion list items will be sorted in ascending order, from lowest to highest.
  `Descending`| The suggestion list items will be sorted in descending order, from highest to lowest.
  `None`      | The suggestion list items will not be sorted at all and will be displayed in their original order.
  
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrHtlUieBMdciQl?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## See Also

- [Filtering Data](./filtering-data)
- [Working with Data](./working-with-data)
- [Templates](./templates)

