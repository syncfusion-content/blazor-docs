---
layout: post
title: Horizontal Card in Blazor Card Component | Syncfusion
description: Checkout and learn here all about Horizontal Card in Syncfusion Blazor Card component and much more.
platform: Blazor
control: Card
documentation: ug
---

# Horizontal Layout in Blazor Card Component

By default, elements within the Blazor Card component are aligned vertically, appearing one after another in the Document Object Model (DOM) flow. To arrange card elements horizontally, the [`Orientation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.SfCard.html#Syncfusion_Blazor_Cards_SfCard_Orientation) property can be used.

## Stacked Cards

In a horizontally aligned card, the [`CardStacked`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardStacked.html) component can be used to group elements and maintain vertical stacking. This component acts as a container that aligns its child elements vertically, even within the horizontal layout of the parent `SfCard`.

The following example demonstrates a horizontal card where the image is displayed alongside a `CardStacked` section containing the header and content, which remain vertically aligned:

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBUMVVVrHJeVdaS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Card Component with Horizontal Orientation](images/blazor-card-with-horizontal-orientation.png)

## See Also

* [Virtually load cards by scrolling](https://www.syncfusion.com/forums/153966/list-of-cards-in-a-grid-from-a-enumerable-list)