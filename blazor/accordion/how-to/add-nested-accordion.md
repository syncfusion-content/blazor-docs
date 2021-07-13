# Add Nested Accordion

Accordion supports to render the nested level of Accordion by using `ContentTemplate` property. To render the nested Accordion, you can define nested Accordion elements within the `ContentTemplate` property of the parent Accordion.

```csharp
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

Output be like the below.

![Nested Accordion](../images/nested.png)
