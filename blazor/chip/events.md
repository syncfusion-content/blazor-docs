---
layout: post
title: Events in Blazor Chip Component | Syncfusion
description: Explore events in Syncfusion Blazor Chip component including Created, Deleted, Destroyed, OnBeforeClick, OnClick, OnDelete, and SelectionChanged events.
platform: Blazor
control: Chip
documentation: ug
---

# Events in Blazor Chip Component

This section explains the list of events of the Chip component which will be triggered for appropriate Chip actions.

## Created

The `Created` event triggers when the Chip component rendering is completed.

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

The `Deleted` event triggers when a chip item is deleted.

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

The `Destroyed` event triggers when the Chip component is disposed.

```cshtml
@using Syncfusion.Blazor.Buttons

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

The `OnBeforeClick` event triggers before a chip is clicked.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfChip Selection="SelectionType.Multiple">
    <ChipItems>
      <ChipItem Text="Small"></ChipItem>
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

The `OnClick` event triggers when a chip is clicked.

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

The `OnDelete` event triggers before removing the chip.

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

The `SelectionChanged` event triggers when the selected chips are changed.

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

@code {
    private void OnSelectionChanged(SelectionChangedEventArgs args)
    {
        // Write your code here
    }
}
```


