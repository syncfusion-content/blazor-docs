---
layout: post
title: Action Buttons in Blazor Card Component | Syncfusion
description: Checkout and learn here all about Action Buttons in the Syncfusion Blazor Card component and much more.
platform: Blazor
control: Card
documentation: ug
---

# Action Buttons in Blazor Card Component

You can include action buttons within the Card and customize them. Action button is a `div` element with `CardFooter` component followed by button tag or anchor tag within the card root element.

For adding action buttons, you can create a  `CardFooterContent` component within the card action element.

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard ID="HugeImage">
    <CardFooter>
        <CardFooterContent>
        </CardFooterContent>
    </CardFooter>
</SfCard>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBgMrBLhHADhaVd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Vertical

By default, action buttons are aligned horizontally. They can also be aligned vertically by adding the `Orientation` property.

```cshtml
@using Syncfusion.Blazor.Cards
@using Syncfusion.Blazor.Buttons

<SfCard ID="HugeImage" Orientation="CardOrientation.Vertical">
    <CardImage Image="images/cards/steven.png"/>
    <CardHeader Title="Harrisburg Keith" SubTitle="@CardSubTitle"/>
    <CardContent Content="Hi, I'm creative graphic design for print, new media based in Edenbridge"/>
    <CardFooter>
        <CardFooterContent>
            <SfButton CssClass="e-btn e-outline e-primary">FOLLOW US</SfButton>
        </CardFooterContent>
    </CardFooter>
</SfCard>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZVUWVrhVdfXSDrA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}