---
layout: post
title: Events in Blazor Chip Component | Syncfusion®
description: Explore events in Blazor Chip component including Created, Deleted, Destroyed, OnBeforeClick, OnClick, OnDelete, and SelectionChanged events.
platform: Blazor
control: Chip
documentation: ug
---

# Events in Blazor Chip Component

This section lists the events triggered by the Chip component and their event arguments.

| Event | Triggered when | Cancelable |
| -- | -- | -- |
| [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_Created) | The Chip component has finished rendering. | No |
| [`OnBeforeClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnBeforeClick) | A chip is about to be clicked. | Yes |
| [`OnClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnClick) | A chip is clicked. | No |
| [`OnDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnDelete) | A chip is about to be removed. | Yes |
| [`Deleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_Deleted) | A chip item is removed from the ChipList. | No |
| [`SelectionChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_SelectionChanged) | The selection of chips changes. | No |
| [`Destroyed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_Destroyed) | The Chip component is disposed. | No |

## Created

The [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_Created) event fires after the Chip component finishes rendering.

| Event Argument | Type | Description |
| -- | -- | -- |
| `args` | `object` | Event arguments provided by the framework. |

```cshtml
@using Syncfusion.Blazor.Buttons

<SfChip Selection="SelectionType.Multiple">
<ChipEvents Created="@OnCreated"></ChipEvents>
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
        // Place the initialization code here
    }
}
```
## Deleted

The [`Deleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_Deleted) event fires after a chip item is removed from the ChipList. To cancel or intercept the deletion, handle [`OnDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnDelete) instead.

| Event Argument | Type | Description |
| -- | -- | -- |
| `args` | `ChipDeletedEventArgs` | Contains the deleted chip's `Text`, `Index`, and other item details. |

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
        // Place the post-deletion code here
    }
}
```
## Destroyed

The [`Destroyed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_Destroyed) event fires when the Chip component is disposed.

| Event Argument | Type | Description |
| -- | -- | -- |
| `args` | `object` | Event arguments provided by the framework. |

```cshtml
@using Syncfusion.Blazor.Buttons

@if (isChipVisible)
{
    <SfChip Selection="SelectionType.Multiple">
        <ChipEvents Destroyed="@OnDestroyed"></ChipEvents>
        <ChipItems>
            <ChipItem Text="Small"></ChipItem>
            <ChipItem Text="Medium"></ChipItem>
            <ChipItem Text="Large"></ChipItem>
            <ChipItem Text="Extra Large"></ChipItem>
        </ChipItems>
    </SfChip>
}

<button class="e-control" @onclick="RemoveChip">Destroy Chip</button>

@code {
    private bool isChipVisible = true;

    private void OnDestroyed(object args)
    {
        // Destroyed event is triggered when the Chip component is disposed.
    }

    private void RemoveChip()
    {
        isChipVisible = false;
    }
}
```
## OnBeforeClick

The [`OnBeforeClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnBeforeClick) event fires before a chip is clicked. The action can be canceled by setting `args.Cancel` to `true`.

| Event Argument | Type | Description |
| -- | -- | -- |
| `args` | `ChipEventArgs` | Contains the clicked chip's `Text`, `Index`, and a `Cancel` property. |

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
        // Place the pre-click handling code here
    }
}
```

## OnClick

The [`OnClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnClick) event fires when a chip is clicked.

| Event Argument | Type | Description |
| -- | -- | -- |
| `args` | `ChipEventArgs` | Contains the clicked chip's `Text` and `Index`. |

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
        // Place the click handling code here
    }
}
```
## OnDelete

The [`OnDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnDelete) event fires before a chip is removed. The deletion can be canceled by setting `args.Cancel` to `true`. To handle the action after the chip is removed, the [`Deleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_Deleted) event is used.

| Event Argument | Type | Description |
| -- | -- | -- |
| `args` | `ChipEventArgs` | Contains the chip's `Text`, `Index`, and a `Cancel` property. |

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
        // Place the pre-deletion code here
    }
}
```
## SelectionChanged

The [`SelectionChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_SelectionChanged) event fires when the selected chips are changed.

| Event Argument | Type | Description |
| -- | -- | -- |
| `args` | `SelectionChangedEventArgs` | Provides the chips that were added or removed from the selection. |

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
        // Place the selection-change handling code here
    }
}

N> The [`OnBeforeClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnBeforeClick) and [`OnDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnDelete) events are cancelable. The [`Deleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_Deleted) event is the post-removal counterpart of [`OnDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnDelete) and is not cancelable.

## See also

* [Getting Started with Blazor Chip](getting-started.md)
* [Types in Blazor Chip](types.md)
* [Customization in Blazor Chip](customization.md)
* [CSS Structure in Blazor Chip](style.md)
* [Accessibility in Blazor Chip](accessibility.md)

