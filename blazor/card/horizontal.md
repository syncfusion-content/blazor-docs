---
layout: post
title: Horizontal Card in Blazor Card | Syncfusion®
description: Switch the Blazor Card layout from vertical to horizontal by setting the Orientation property to CardOrientation.Horizontal on SfCard.
platform: Blazor
control: Card
documentation: ug
---

# Horizontal Card in Blazor Card

The [Blazor Card](https://www.syncfusion.com/blazor-components/blazor-card) component lays out its child elements vertically by default. You can switch the layout to horizontal by setting the [`Orientation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.SfCard.html#Syncfusion_Blazor_Cards_SfCard_Orientation) property to [`CardOrientation.Horizontal`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardOrientation.html) on the [`SfCard`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.SfCard.html).

## Stacked cards

Within a horizontal card, you can group a set of child elements into a vertical column by wrapping them in the [`CardStacked`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardStacked.html) component. This is useful when one section of the card should remain vertical (for example, a header stacked above the content) while the rest of the card is horizontal.

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard Orientation="CardOrientation.Horizontal" ID="Trimmer">
    <CardStacked>
        <CardHeader Title="Philips Trimmer" />
        <CardContent Content="Philips trimmers are designed to last longer than 4 ordinary trimmers and DuraPower Technology which optimizes power." />
    </CardStacked>
    <img src="//ej2.syncfusion.com/demos/src/card/images/Trimmer.png">
</SfCard>
<style>
    .e-card-image {
            background: url('./sample.jpg');
            height: 160px;;
    }

    .e-card {
        width: 300px;
        margin: auto;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrntdCVhklogiNY?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Card Component with Horizontal Orientation](images/blazor-card-with-horizontal-orientation.webp)" %}

## See also

* [Virtually load cards by scrolling](https://www.syncfusion.com/forums/153966/list-of-cards-in-a-grid-from-a-enumerable-list)
* [Getting Started with Blazor Card](getting-started.md)
* [Style and Appearance in Blazor Card](style.md)
* [Header and Content in Blazor Card](header-content.md)
* [Image and Divider in Blazor Card](card-image.md)
* [Action Buttons in Blazor Card](action-buttons.md)
* [SfCard API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.SfCard.html)