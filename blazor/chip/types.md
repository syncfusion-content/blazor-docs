---
layout: post
title: Types in Blazor Chips Component | Syncfusion
description: Checkout and learn here all about Chips Types in Syncfusion Blazor Chips component and much more details.
platform: Blazor
control: Chips
documentation: ug
---

# Types in Blazor Chips Component

The Chips component has the following types.

* Input Chips
* Choice Chips
* Filter Chips
* Action Chips

## Input Chips

Input Chips holds information in compact form. It converts user input into chips.

```cshtml
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipItems>
        <ChipItem Text="Anne" LeadingIconUrl="./anne.png"></ChipItem>
        <ChipItem Text="Janet" LeadingIconUrl="./janet.png"></ChipItem>
        <ChipItem Text="Laura" LeadingIconUrl="./laura.png"></ChipItem>
        <ChipItem Text="Margaret" LeadingIconUrl="./margaret.png"></ChipItem>
    </ChipItems>
</SfChip>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLAWVrmVySxGUhD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Chips with Input Items](./images/blazor-chip-input-items.png)

## Choice Chips

Choice Chips allows you to select a single Chips from the set of Chips/ChipItems. It can be enabled by setting the [`Selection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_Selection) property to `Single`.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrgihLQrIIaiZzR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Single Selection in Blazor Chips](./images/blazor-chip-single-selection.gif)

## Filter Chips

Filter Chips allows you to select a multiple Chips from the set of Chips/ChipItems. It can be enabled by setting the [`Selection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_Selection) property to `Multiple`.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVUChLGrodMJCaU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


![Multiple Selection in Blazor Chips](./images/blazor-chip-multiple-selection.gif)

## Action Chips

The Action Chips triggers the event like [`OnClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnClick) or [`OnDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.ChipEvents.html#Syncfusion_Blazor_Buttons_ChipEvents_OnDelete), which helps to do action based on the event.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLgCrLGBSnHjcxB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


![Blazor Action Chips](./images/blazor-action-chip.gif)

### Deletable Chips

Deletable Chips allows you to delete a Chips from Chips/ChipItems. It can be enabled by setting the [`EnableDelete`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfChip.html#Syncfusion_Blazor_Buttons_SfChip_EnableDelete) property to `true`.

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
