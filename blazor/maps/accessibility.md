---
layout: post
title: Accessibility in Blazor Maps Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Accessibility in Blazor Maps Component

The [Blazor Maps](https://www.syncfusion.com/blazor-components/blazor-map) component follows commonly used accessibility guidelines and standards, such as [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor Maps component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility) | Not Applicable |
| [Color Contrast](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

To meet accessibility standards, the Blazor Maps component follows to the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns. In the Maps component, the following `WAI-ARIA` attributes are used:

| Attributes | Purpose |
| --- | --- |
| `role=region` | It specifies the Maps areas that do not support interactive functions like selection and highlight. |
| `role=button` | It specifies the Maps areas where interactive functions such as selection and highlight are available. |
| `aria-label` | Provides an accessible name for Maps elements such as geometric map shapes, title, subtitle, legend title, legend item labels, data labels, and so on. To learn more, see the next topic. |

## Screen reading in Maps

Accessibility in the Blazor Maps component ensures that all users, regardless of ability or disability, can use screen reading. The following Map elements will be read aloud using screen reading software, such as Narrator for Windows.

| Elements | Description |
| --- | --- |
| Shapes in the layer | Reads the names of the geographical shapes (such as countries, states, and regions) that appear on the Maps. |
| Title | Reads the title content in the Maps. |
| Subtitle | Reads the title below the main title content in the Maps. |
| Legend title | Reads the contents of the legend's title as specified in Maps. |
| Legend item label | Reads the label of a legend item in Maps. |
| Data label | Reads the label specified for the shapes in the Maps layer. |
| Annotation | Reads the content specified in the annotation. |
| Marker template | Reads the content provided in the marker template. |
| Tooltip template | Reads the content provided in the tooltip template. |
| Data label template | Reads the content provided in the data label template. |

## Keyboard Navigation

All the Blazor Maps actions can be controlled via keyboard keys. The applicable key combinations and their relative functionalities are listed below for the appropriate UI features available in the component.

| Windows | Mac | Description|
|-----|-----|----|
|<kbd>Tab</kbd> | <kbd>Tab</kbd> |Moves to the next focusable element on the map, such as the legend or shape.|
|<kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> |Moves to the previous focusable element on the map, such as the legend or shape.|
|<kbd> + </kbd> | <kbd>+</kbd> |When zooming is enabled, zoom in operation can be performed.|
|<kbd> - </kbd> | <kbd>-</kbd> |When zooming is enabled, zoom out operation can be performed.|
|<kbd>←</kbd> | <kbd>←</kbd> |When zoomed in, the map can be scrolled to the left.|
|<kbd>→</kbd> | <kbd>→</kbd> |When zoomed in, the map can be scrolled to the right.|
|<kbd>↑</kbd> | <kbd>↑</kbd> |When zoomed in, the map can be scrolled upward.|
|<kbd>↓</kbd> | <kbd>↓</kbd> |When zoomed in, the map can be scrolled downward.|
|<kbd> R </kbd> | <kbd>R</kbd> |When zooming is enabled, reset operation can be performed.|
|<kbd>Enter</kbd> | <kbd>Enter</kbd> |The page can be navigated to the next and previous states in legend. Similarly, the selection can be made while navigating over the shape.|

## Ensuring accessibility

The Blazor Maps component's accessibility levels are ensured using an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Maps component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/maps) in a new window to evaluate the accessibility of the Maps component with accessibility tools.
