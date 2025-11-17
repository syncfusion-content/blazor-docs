---
layout: post
title: Events in Blazor Chip Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Chip component and much more details.
platform: Blazor
control: Chip
documentation: ug
---

# Events in Blazor Chip Component

This section explains the list of events of the Chip component which will be triggered for appropriate Chip actions.

## Created

`Created` event triggers when the Chip component rendering is completed.


```cshtml
@using Syncfusion.Blazor.Buttons

<SfChip Selection="SelectionType.Multiple" Created="@OnCreated">
    <ChipItems>
        <ChipItem Text="Small"></ChipItem>
        <ChipItem Text="Medium"></ChipItem>
        <ChipItem Text="Large"></ChipItem>
        <ChipItem Text="Extra Large"></ChipItem>
    </ChipItems>
</SfChip>

@code {
    private void OnCreated(object args)
    {
        // Write your code here
    }
}
```
## Deleted

`Deleted`event triggers when a chip item is deleted.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfChip Selection="SelectionType.Multiple" EnableDelete="true">
    <ChipItems>
        <ChipItem Text="Small"></ChipItem>
        <ChipItem Text="Medium"></ChipItem>
        <ChipItem Text="Large"></ChipItem>
        <ChipItem Text="Extra Large"></ChipItem>
    </ChipItems>
    <ChipEvents Deleted="@OnDeleted"></ChipEvents>
</SfChip>

@code {
    private void OnDeleted(ChipDeletedEventArgs args)
    {
        // Write your code here
    }
}
```
## Destroyed

`Destroyed` event triggers when the Chip component is disposed.

```cshtml


using Syncfusion.Blazor.Buttons

<SfChip Selection="SelectionType.Multiple" Destroyed="@OnDestroyed">
    <ChipItems>
        <ChipItem Text="Small"></ChipItem>
        <ChipItem Text="Medium"></ChipItem>
        <ChipItem Text="Large"></ChipItem>
        <ChipItem Text="Extra Large"></ChipItem>
    </ChipItems>
</SfChip>

@code {
    private void OnDestroyed(object args)
    {
        // Write your code here
    }
}
```
## OnBeforeClick

`OnBeforeClick` event triggers before a chip is clicked.

```cshtml


@using Syncfusion.Blazor.Buttons

<SfChip Selection="SelectionType.Multiple">
    <ChipItems>
       ChipItem Text="Small"></ChipItem>
        <ChipItem Text="Medium"></ChipItem>
        <ChipItem Text="Large"></ChipItem>
        <ChipItem Text="Extra Large"></ChipItem>
    </ChipItems>
    <ChipEvents OnBeforeClick="@OnBeforeChipClick"></ChipEvents>
</SfChip>

@code {
    private void OnBeforeChipClick(ChipEventArgs args)
    {
        // Write your code here
    }
}
```

## OnClick

`OnClick` event triggers when a chip is clicked.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfChip Selection="SelectionType.Multiple">
    <ChipItems>
        <ChipItem Text="Small"></ChipItem>
        <ChipItem Text="Medium"></ChipItem>
        <ChipItem Text="Large"></ChipItem>
        <ChipItem Text="Extra Large"></ChipItem>
    </ChipItems>
    <ChipEvents OnClick="@OnChipClick"></ChipEvents>
</SfChip>

@code {
    private void OnChipClick(ChipEventArgs args)
    {
        // Write your code here
    }
}
```
## OnDelete

`OnDelete` event triggers before removing the chip.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfChip Selection="SelectionType.Multiple" EnableDelete="true">
    <ChipItems>
        <ChipItem Text="Small"></ChipItem>
        <ChipItem Text="Medium"></ChipItem>
        <ChipItem Text="Large"></ChipItem>
        <ChipItem Text="Extra Large"></ChipItem>
    </ChipItems>
    <ChipEvents OnDelete="@OnChipDelete"></ChipEvents>
</SfChip>

@code {
    private void OnChipDelete(ChipEventArgs args)
    {
        // Write your code here
    }
}

```
## SelectionChanged

`SelectionChanged` event triggers when the selected chips are changed.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfChip Selection="SelectionType.Multiple">
    <ChipItems>
        <ChipItem Text="Small"></ChipItem>
        <ChipItem Text="Medium"></ChipItem>
        <ChipItem Text="Large"></ChipItem>
        <ChipItem Text="Extra Large"></ChipItem>
    </ChipItems>
    <ChipEvents SelectionChanged="@OnSelectionChanged"></ChipEvents>
</SfChip>

@ {
    private void OnSelectionChanged(SelectionChangedEventArgs args)
    {
        // Write your code here
    }
}

```


