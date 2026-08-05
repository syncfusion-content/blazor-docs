---
layout: post
title: Types in Blazor Chip Component | Syncfusion®
description: Checkout and learn here all the features about Chip Types in Blazor Chip component and much more details.
platform: Blazor
control: Chip
documentation: ug
---

# Types in Blazor Chip Component

The Chip control has the following types.

* Input Chip
* Choice Chip
* Filter Chip
* Action Chip

## Input Chip

Input chips hold information in a compact form. They are typically used to display entities (such as contacts) with an avatar or icon and a label. The [`LeadingIconCss`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipItem.html#Syncfusion_Blazor_Buttons_ChipItem_LeadingIconCss) property renders an icon for each chip.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipItems>
        <ChipItem Text="Anne" LeadingIconCss="anne"></ChipItem>
        <ChipItem Text="Janet" LeadingIconCss="janet"></ChipItem>
        <ChipItem Text="Laura" LeadingIconCss="laura"></ChipItem>
        <ChipItem Text="Margaret" LeadingIconCss="margaret"></ChipItem>
    </ChipItems>
</SfChip>


<style>
    .e-chip .anne {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/anne.png')
    }

    .e-chip .janet {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/janet.png')
    }

    .e-chip .laura {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/laura.png')
    }

    .e-chip .margaret {
        background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/margaret.png')
    }
</style>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVdXRsRfzhKbzVH?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Chip with Input Items](./images/blazor-chip-input-items.webp)" %}

## Choice Chip

Choice chips allow a single chip to be selected from the set of `ChipItems`. The behavior is enabled by setting the [`Selection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_Selection) property to `SelectionType.Single`. Clicking the selected chip again deselects it.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip Selection="SelectionType.Single">
    <ChipItems>
        <ChipItem Text="Small"></ChipItem>
        <ChipItem Text="Medium"></ChipItem>
        <ChipItem Text="Large"></ChipItem>
        <ChipItem Text="Extra Large"></ChipItem>
    </ChipItems>
</SfChip>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDrHtxCHfTrRPhGu?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Single Selection in Blazor Chip](./images/blazor-chip-single-selection.webp)" %}

## Filter Chip

Filter chips allow multiple chips to be selected from the set of `ChipItems`. The behavior is enabled by setting the [`Selection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_Selection) property to `SelectionType.Multiple`.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip Selection="SelectionType.Multiple">
    <ChipItems>
        <ChipItem Text="Chai"></ChipItem>
        <ChipItem Text="Chang"></ChipItem>
        <ChipItem Text="Aniseed Syrup"></ChipItem>
        <ChipItem Text="Ikura"></ChipItem>
    </ChipItems>
</SfChip>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBdNRMdffVaXBNI?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Multiple Selection in Blazor Chip](./images/blazor-chip-multiple-selection.webp)" %}

## Action Chip

Action chips trigger the [`OnClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnClick) or [`OnDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnDelete) event so the application can handle chip interactions. The [`ChipEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEventArgs.html) provided to the handler exposes the clicked chip's `Text` (the chip label) and [`Index`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEventArgs.html#Syncfusion_Blazor_Buttons_ChipEventArgs_Index) (its position in the [`ChipItems`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipItem.html) collection).

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipEvents OnClick="@OnClick"></ChipEvents>
    <ChipItems>
        <ChipItem Text="Sent a text"></ChipItem>
        <ChipItem Text="Set a remainder"></ChipItem>
        <ChipItem Text="Read my emails"></ChipItem>
        <ChipItem Text="Set alarm"></ChipItem>
    </ChipItems>
</SfChip>

<div>@ChipText</div>

@code
{
    public string ChipText = "";
    private void OnClick(Syncfusion.Blazor.Buttons.ChipEventArgs args)
    {
        ChipText = args.Text;
        this.StateHasChanged();
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVRXnWRJzgVMAhV?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Action Chip](./images/blazor-action-chip.gif)" %}

## Deletable Chip

Deletable chips allow a chip to be removed from the set of `ChipItems` by clicking the delete (X) icon. The behavior is enabled by setting the [`EnableDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_EnableDelete) property to `true` on the `SfChip` component. To intercept or react to deletion, the [`OnDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnDelete) and [`Deleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_Deleted) events are handled.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip EnableDelete="true">
    <ChipItems>
        <ChipItem Text="Sent a text"></ChipItem>
        <ChipItem Text="Set a remainder"></ChipItem>
        <ChipItem Text="Read my emails"></ChipItem>
        <ChipItem Text="Set alarm"></ChipItem>
    </ChipItems>
</SfChip>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhnZHsRpTARlVRs?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}
