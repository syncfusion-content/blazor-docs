---
layout: post
title: Header and Content in Blazor Card | Syncfusion®
description: Render header and content sections in the Blazor Card using the CardHeader and CardContent slots to organize title, subtitle, and main body.
platform: Blazor
control: Card
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Header and Content in Blazor Card Component

## Header

The Card can be created with a header that contains a title, a sub-title, and an optional image. To add a header, use the [`CardHeader`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardHeader.html) component. The Card provides the following elements and corresponding CSS classes for building a header.

| Element | Description |
| --- | --- |
| [Caption](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardHeader.html) | Wrapper element that includes the title and sub-title. |
| [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardImage.html) | Includes a header image with the specified dimensions. |

| Parameter | Description |
| --- | --- |
| [`Title`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardHeader.html#Syncfusion_Blazor_Cards_CardHeader_Title) | Main title text within the header. |
| [`SubTitle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardHeader.html#Syncfusion_Blazor_Cards_CardHeader_SubTitle) | A sub-title within the header. |
| [`CardImage`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardImage.html) | To include heading image within the header. |


### Title and Subtitle

To add a header to the Card, use the `CardHeader` component and set the `Title` and `SubTitle` properties.

* Add `Title` Property inside the header caption for adding main title.

* Add `SubTitle` Property inside the header caption element for adding Title.

### Image

The Card header supports an optional image set via the [`ImageUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardHeader.html#Syncfusion_Blazor_Cards_CardHeader_ImageUrl) parameter on [`CardHeader`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardHeader.html). The image is rendered either before or after the caption, depending on the value of the [`ImagePosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.ImagePosition.html) parameter (default: `Before`).

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard ID="HugeImage">
    <CardHeader Title="Laura Callahan" SubTitle="Sales Coordinator and Representative" ImageUrl="images/cards/football.png" />
</SfCard>
<SfCard ID="SecondCard">
    <CardHeader Title="Laura Callahan" SubTitle="Sales Coordinator and Representative" ImageUrl="images/cards/football.png" />
</SfCard>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrRtxiVBYyfeJns?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Content

Content in the Card holds text, images, links, and all possible HTML elements. It renders anywhere inside the Card root element.

* Create a [`CardContent`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.CardContent.html) component.
* Place content `div` element in the Card root element or within any Card inner elements.

```cshtml
@using Syncfusion.Blazor.Cards

<SfCard ID="HugeImage">
    <CardHeader Title="Laura Callahan" SubTitle="Sales Coordinator and Representative" ImageUrl="images/cards/football.png" />
</SfCard>

<SfCard ID="SecondCard">
    <CardContent Content="Laura received a BA in psychology from the University of Washington. She has also completed a course in business French. She reads and writes French."/>
</SfCard>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrdjHsrVEycBMCY?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Image

You can place a raw `<img>` element inside `CardContent` to render an image within the content area. For component-based image rendering, use the `CardImage` component as described in [Image and Divider in Blazor Card](card-image.md).

```cshtml
@using Syncfusion.Blazor.Cards
<SfCard ID="Card">
    <CardHeader Title="Canon 135mm"/>
    <CardContent>
        <div>
            The fastest 135mm telephoto lens in its class. Two UD-glass elements correct secondary spectrum for outstanding sharpness and color.
        </div><br>
        <img src="https://ej2.syncfusion.com/demos/src/card/images/Camera.png" alt="Canon 135mm" height="300px" width="100%" />
    </CardContent>
</SfCard>

<style>
    #Card {
        width: 300px;
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjBnjRsrrunDISPn?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Card Component Content with Image](images/Blazor-Card-Component-Content-with-Image.webp)" %}

## See also

* [Style and Appearance in Blazor Card](style.md)
* [Image and Divider in Blazor Card](card-image.md)
* [Action Buttons in Blazor Card](action-buttons.md)
* [Horizontal Card in Blazor Card](horizontal.md)
* [Card API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Cards.SfCard.html)