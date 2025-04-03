---
layout: post
title: Add Nested Accordion in Blazor Accordion Component | Syncfusion
description: Checkout and learn here all about how to add Nested Accordion in Syncfusion Blazor Accordion component and more.
platform: Blazor
control: Accordion
documentation: ug
---

# Add Nested Accordion in Blazor Accordion Component

The Accordion component supports to render the nested level of Accordion by using the [ContentTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html#Syncfusion_Blazor_Navigations_AccordionItem_ContentTemplate) property. To render the nested Accordion, define the nested Accordion elements within the `ContentTemplate` property of the parent Accordion.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfAccordion>
    <AccordionItems>
        <AccordionItem Header="Video">
            <ContentTemplate>
                <SfAccordion>
                    <AccordionItems>
                        <AccordionItem Header="Video Track1"></AccordionItem>
                        <AccordionItem Header="Video Track2"></AccordionItem>
                    </AccordionItems>
                </SfAccordion>
            </ContentTemplate>
        </AccordionItem>
        <AccordionItem Header="Music">
            <ContentTemplate>
                <SfAccordion>
                    <AccordionItems>
                        <AccordionItem Header="Music Track1"></AccordionItem>
                        <AccordionItem Header="Music Track2"></AccordionItem>
                        <AccordionItem Header="Music New">
                            <ContentTemplate>
                                <SfAccordion>
                                    <AccordionItems>
                                        <AccordionItem Header="New Track1"></AccordionItem>
                                        <AccordionItem Header="New Track2"></AccordionItem>
                                    </AccordionItems>
                                </SfAccordion>
                            </ContentTemplate>
                        </AccordionItem>
                    </AccordionItems>
                </SfAccordion>
            </ContentTemplate>
        </AccordionItem>
        <AccordionItem Header="Images">
            <ContentTemplate>
                <SfAccordion>
                    <AccordionItems>
                        <AccordionItem Header="Track1"></AccordionItem>
                        <AccordionItem Header="Track2"></AccordionItem>
                    </AccordionItems>
                </SfAccordion>
            </ContentTemplate>
        </AccordionItem>
    </AccordionItems>
</SfAccordion>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrUWLWUAyOkHSnV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Accordion Component with Nested Item](../images/blazor-accordion-with-nested-item.png)
