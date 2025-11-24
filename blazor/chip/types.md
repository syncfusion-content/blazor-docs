---
layout: post
title: Types in Blazor Chip Component | Syncfusion
description: Checkout and learn here all about Chip Types in Syncfusion Blazor Chip component and much more details.
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

Input Chip holds information in compact form. It converts user input into chips.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipItems>
        <ChipItem Text="Anne" LeadingIconUrl="https://ej2.syncfusion.com/demos/src/chips/images/andrew.png"></ChipItem>
        <ChipItem Text="Janet" LeadingIconUrl="https://ej2.syncfusion.com/demos/src/chips/images/janet.png"></ChipItem>
        <ChipItem Text="Laura" LeadingIconUrl="https://ej2.syncfusion.com/demos/src/chips/images/laura.png"></ChipItem>
        <ChipItem Text="Margaret" LeadingIconUrl="https://ej2.syncfusion.com/demos/src/chips/images/margaret.png"></ChipItem>
    </ChipItems>
</SfChip>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhotaWuJwkKgwBO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Chip with Input Items](./images/blazor-chip-input-items.png)" %}

## Choice Chip

Choice Chip allows you to select a single chip from the set of Chip/ChipItems. It can be enabled by setting the [`Selection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_Selection) property to `Single`.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrgihLQrIIaiZzR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Single Selection in Blazor Chip](./images/blazor-chip-single-selection.gif)" %}

## Filter Chip

Filter Chip allows you to select a multiple chip from the set of Chip/ChipItems. It can be enabled by setting the [`Selection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_Selection) property to `Multiple`.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVUChLGrodMJCaU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Multiple Selection in Blazor Chip](./images/blazor-chip-multiple-selection.gif)" %}

## Action Chip

The Action Chip triggers the event like [`OnClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnClick) or [`OnDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnDelete), which helps to do action based on the event.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLgCrLGBSnHjcxB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Action Chip](./images/blazor-action-chip.gif)" %}

### Deletable Chip

Deletable Chip allows you to delete a chip from Chip/ChipItems. It can be enabled by setting the [`EnableDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_EnableDelete) property to `true`.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rthgCBLwLodvAbRF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
