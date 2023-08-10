---
layout: post
title: Content Render Mode in Blazor Accordion Component | Syncfusion
description: Checkout and learn here all about Content Render Mode in Syncfusion Blazor Accordion component and more.
platform: Blazor
control: Accordion
documentation: ug
---

# Content Render Mode in Blazor Accordion Component

[Blazor Accordion](https://www.syncfusion.com/blazor-components/blazor-accordion) provides support to render the content of all [AccordionItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html) at initial load which will be maintained in DOM. For that, disable the [LoadOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAccordion.html#Syncfusion_Blazor_Navigations_SfAccordion_LoadOnDemand) property to load all the contents.

N> The default value of the property `LoadOnDemand` is true.

```cshtml

@using Syncfusion.Blazor.Navigations

<SfAccordion LoadOnDemand="false">
    <AccordionItems>
        <AccordionItem Header="Margeret Peacock" Content="Margeret Peacock was born on Saturday , 01 December 1990. Now lives at Coventry House Miner Rd., London,UK. Margeret Peacock holds a position of Sales Coordinator in our WA department, (Seattle USA). Joined our company on Saturday , 01 May 2010"></AccordionItem>
        <AccordionItem Header="Laura Callahan" Content="Laura Callahan was born on Tuesday , 06 November 1990. Now lives at Edgeham Hollow Winchester Way, London,UK. Laura Callahan holds a position of Sales Coordinator in our WA department, (Seattle USA). Joined our company on Saturday , 01 May 2010"></AccordionItem>
        <AccordionItem Header="Albert Dodsworth" Content="Albert Dodsworth was born on Thursday , 19 October 1989. Now lives at 4726 - 11th Ave. N.E., Seattle,USA.Albert Dodsworth holds a position of Sales Representative in our WA department, (Seattle USA). Joined our company on Friday , 01 May 2009"></AccordionItem>
    </AccordionItems>
</SfAccordion>

```
