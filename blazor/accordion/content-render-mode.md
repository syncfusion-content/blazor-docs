---
layout: post
title: Content Render Mode in Blazor Accordion Component | Syncfusion®
description: Check out and learn about the content render mode options in the Blazor Accordion component, including the LoadOnDemand property.
platform: Blazor
control: Accordion
documentation: ug
---

# Content Render Mode in Blazor Accordion Component

The [Blazor Accordion](https://www.syncfusion.com/blazor-components/blazor-accordion) lets you render all [AccordionItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html) contents at initial load and keep them in the DOM. To enable this behavior, set the [LoadOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAccordion.html#Syncfusion_Blazor_Navigations_SfAccordion_LoadOnDemand) property of the [SfAccordion](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAccordion.html) to `false`.

> The default value of the `LoadOnDemand` property is `true`. When `true`, each item's content is rendered the first time the panel is expanded and is removed from the DOM when the panel is collapsed.

## Available properties

| Property | Type | Default | Description |
| -- | -- | -- | -- |
| `LoadOnDemand` | `bool` | `true` | When `true`, content is rendered on demand (lazy) and removed from the DOM when the panel collapses. When `false`, every item's content is rendered up front and kept in the DOM. |



* The Accordion requires an interactive Blazor render mode. Ensure the parent component or the app uses `InteractiveServer`, `InteractiveWebAssembly`, or `InteractiveAuto` render mode. `StaticSSR` will not allow client-side expand/collapse to function.

## Example: render all panel contents on initial load

```cshtml
@using Syncfusion.Blazor.Navigations

<SfAccordion LoadOnDemand="false">
    <AccordionItems>
        <AccordionItem Header="Margaret Peacock" Content="Margaret Peacock was born on 01 December 1990. She now lives at Coventry House Miner Rd., London, UK. Margaret holds the position of Sales Coordinator in our WA department (Seattle, USA). She joined our company on 01 May 2010."></AccordionItem>
        <AccordionItem Header="Laura Callahan" Content="Laura Callahan was born on 06 November 1990. She now lives at Edgeham Hollow Winchester Way, London, UK. Laura holds the position of Sales Coordinator in our WA department (Seattle, USA). She joined our company on 01 May 2010."></AccordionItem>
        <AccordionItem Header="Albert Dodsworth" Content="Albert Dodsworth was born on 19 October 1989. He now lives at 4726 - 11th Ave. N.E., Seattle, USA. Albert holds the position of Sales Representative in our WA department (Seattle, USA). He joined our company on 01 May 2009."></AccordionItem>
    </AccordionItems>
</SfAccordion>
```

With `LoadOnDemand="false"`, opening the browser's DevTools and inspecting the DOM shows every panel's content element present in the document regardless of the expanded state. With `LoadOnDemand="true"` (the default), only the expanded panel's content is present until that item is expanded for the first time.

## Related settings

| Property | Purpose |
| -- | -- |
| [`LoadOnDemand`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAccordion.html#Syncfusion_Blazor_Navigations_SfAccordion_LoadOnDemand) | Controls whether each panel's content is rendered only on demand (default) or all at once on initial load. |
| [`ExpandMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAccordion.html) | Sets single or multiple expand behavior. |
| [`ExpandedIndices`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAccordion.html) | One-way binds the indices of currently expanded items. |
| `Expanded` / `ExpandedChanged` (on `AccordionItem`) | Two-way binds the expanded state of a single item. |

`LoadOnDemand` does not control animation duration or the expand mode; it only controls when the panel's content is created in the DOM.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLdZdCssPiTKIXB?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## See also

* [Getting Started with Blazor Accordion](https://blazor.syncfusion.com/documentation/accordion/getting-started)
* [Accessibility in Blazor Accordion](https://blazor.syncfusion.com/documentation/accordion/accessibility)
* [Animations in Blazor Accordion](https://blazor.syncfusion.com/documentation/accordion/animations)
* [SfAccordion API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAccordion.html)
* [AccordionItem API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html)
