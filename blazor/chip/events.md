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
| `Created` | The Chip component has finished rendering. | No |
| `OnBeforeClick` | A chip is about to be clicked. | Yes |
| `OnClick` | A chip is clicked. | No |
| `OnDelete` | A chip is about to be removed. | Yes |
| `Deleted` | A chip item is removed from the ChipList. | No |
| `SelectionChanged` | The selection of chips changes. | No |
| `Destroyed` | The Chip component is disposed. | No |

## Created

The `Created` event fires after the Chip component finishes rendering.

| Event Argument | Type | Description |
| -- | -- | -- |
| `args` | `object` | Event arguments provided by the framework. |

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
        // Place the initialization code here
    }
}
```
## Deleted

The `Deleted` event fires after a chip item is removed from the ChipList. To cancel or intercept the deletion, handle `OnDelete` instead.

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

The `Destroyed` event fires when the Chip component is disposed.

| Event Argument | Type | Description |
| -- | -- | -- |
| `args` | `object` | Event arguments provided by the framework. |

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
        // Place the cleanup code here
    }
}
```
## OnBeforeClick

The `OnBeforeClick` event fires before a chip is clicked. The action can be canceled by setting `args.Cancel` to `true`.

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

The `OnClick` event fires when a chip is clicked.

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

The `OnDelete` event fires before a chip is removed. The deletion can be canceled by setting `args.Cancel` to `true`. To handle the action after the chip is removed, the `Deleted` event is used.

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

The `SelectionChanged` event fires when the selected chips are changed.

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

N> The `OnBeforeClick` and `OnDelete` events are cancelable. The `Deleted` event is the post-removal counterpart of `OnDelete` and is not cancelable.

N> Component-level events such as `Created` and `Destroyed` are wired directly on the `SfChip` tag. Chip-item-level events such as `OnBeforeClick`, `OnClick`, `OnDelete`, `Deleted`, and `SelectionChanged` are wired inside the `ChipEvents` child tag.

## See also

* [Getting Started with Blazor Chip](getting-started.md)
* [Types in Blazor Chip](types.md)
* [Customization in Blazor Chip](customization.md)
* [CSS Structure in Blazor Chip](style.md)
* [Accessibility in Blazor Chip](accessibility.md)

