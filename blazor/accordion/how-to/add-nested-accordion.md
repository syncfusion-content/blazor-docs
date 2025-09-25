---
layout: post
title: Add Nested Accordion in Blazor Accordion Component | Syncfusion
description: Learn the straightforward method for implementing nested Accordions within the Syncfusion Blazor Accordion component using the ContentTemplate property, with code examples and best practices.
platform: Blazor
control: Accordion
documentation: ug
---

# Add Nested Accordion in Blazor Accordion Component

The Accordion component supports to render the nested level of Accordion by using the [ContentTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html#Syncfusion_Blazor_Navigations_AccordionItem_ContentTemplate) property.
## Implementing Nested Accordions

To achieve nesting, you simply include a complete `<SfAccordion>` component inside the `<ContentTemplate>` of an `AccordionItem` that belongs to a parent `SfAccordion`. Each nested `SfAccordion` functions independently, allowing for distinct content and structure at each level.

### Example: Multiple Levels of Nesting

This example demonstrates how to create a two-level nested Accordion structure.
```cshtml
@using Syncfusion.Blazor.Navigations

<SfAccordion>
    <AccordionItems>
        <AccordionItem Header="Video">
            <ContentTemplate>
                <!-- First level nested Accordion -->
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
                <!-- First level nested Accordion -->
                <SfAccordion>
                    <AccordionItems>
                        <AccordionItem Header="Music Track1"></AccordionItem>
                        <AccordionItem Header="Music Track2"></AccordionItem>
                        <AccordionItem Header="Music New">
                            <ContentTemplate>
                                 <!-- Second level nested Accordion -->
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
                <!-- First level nested Accordion -->
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
