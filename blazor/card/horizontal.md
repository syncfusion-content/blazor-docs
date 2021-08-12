---
layout: post
title: Horizontal Card in Blazor Card Component | Syncfusion
description: Checkout and learn here all about Horizontal Card in Syncfusion Blazor Card component and much more.
platform: Blazor
control: Card
documentation: ug
---

# Horizontal Card in Blazor Card Component

By default, all the card elements are aligned vertically one after the other as in the DOM. You can achieve the element to align horizontally as well by using the Orientation property.

## Stacked cards

An horizontally aligned card can push a specific column to align vertically using the `CardStacked` component. This will align the stacked section vertically aligned differentiating from horizontal layout.

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

![Blazor Card Component with Horizontal Orientation](images/blazor-card-with-horizontal-orientation.png)