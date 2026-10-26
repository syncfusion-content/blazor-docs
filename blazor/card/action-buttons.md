---
layout: post
title: Action Buttons in Blazor Card | Syncfusion®
description: Add action buttons inside the Blazor Card footer using the CardFooter component with a button or anchor element rendered at the card's bottom.
platform: Blazor
control: Card
documentation: ug
---

# Action Buttons in Blazor Card

You can include action buttons within the [Blazor Card](https://www.syncfusion.com/blazor-components/blazor-card) and customize them. An action button is rendered inside a `div` element that uses the `CardFooter` component, followed by a button or anchor tag within the card root element.

To add action buttons, create a `CardFooterContent` component within the card footer element.

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard ID="HugeImage">
    <CardFooter>
        <CardFooterContent>
           Footer Button
        </CardFooterContent>
    </CardFooter>
</SfCard>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBxtbrITsfLJPTc?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Vertical

Action buttons can be combined with a vertical card layout by setting the `Orientation` property.

```cshtml
@using Syncfusion.Blazor.Cards
@using Syncfusion.Blazor.Buttons

<SfCard ID="HugeImage" Orientation="CardOrientation.Vertical">
    <CardImage Image="https://cdn.syncfusion.com/blazor/images/cards/steven.png"/>
    <CardHeader Title="Harrisburg Keith" SubTitle="@CardSubTitle"/>
    <CardContent Content="Hi, I'm creative graphic design for print, new media based in Edenbridge"/>
    <CardFooter>
        <CardFooterContent>
            <SfButton CssClass="e-btn e-outline e-primary">FOLLOW US</SfButton>
        </CardFooterContent>
    </CardFooter>
</SfCard>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhRDvVeJWrwqmQE?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## See also

* [Style and Appearance in Blazor Card](style.md)
* [Header and Content in Blazor Card](header-content.md)
* [Image and Divider in Blazor Card](card-image.md)
* [Horizontal Card in Blazor Card](horizontal.md)