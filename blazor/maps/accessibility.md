---
layout: post
title: Accessibility in Blazor Maps Component | Syncfusion
description: Check out and learn here all about accessibility in the Syncfusion Blazor Maps component and much more details.
platform: Blazor
control: Maps
documentation: ug
---

# Accessibility in Blazor Maps Component

The [Blazor Maps](https://www.syncfusion.com/blazor-components/blazor-map) component adheres to widely adopted accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor Maps component is summarized below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility) | Not Applicable |
| [Color Contrast](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

To meet accessibility standards, the Blazor Maps component adheres to [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns. The following `WAI-ARIA` attributes are used in the Maps component:

| Attributes | Purpose |
| --- | --- |
| `role=region` | Identifies map areas that do not support interactive functions such as selection and highlighting. |
| `role=button` | Identifies map areas where interactive functions such as selection and highlighting are available. |
| `aria-label` | Provides accessible names for map elements including geometric shapes, title, subtitle, legend title, legend item labels, and data labels. See the next section for details. |

## Screen reading in Maps

Accessibility in the Blazor Maps component ensures compatibility with screen readers. The following map elements are announced by screen readers such as Narrator on Windows.

| Elements | Description |
| --- | --- |
| Shapes in the layer | Announces the names of the geographical shapes (such as countries, states, and regions) displayed on the map. |
| Title | Announces the map title. |
| Subtitle | Announces the subtitle that appears below the main title. |
| Legend title | Announces the legend title as configured in the map. |
| Legend item label | Announces the label of each legend item. |
| Data label | Announces the label specified for shapes in the map layer. |
| Annotation | Announces the content defined in the annotation. |
| Marker template | Announces the content provided in the marker template. |
| Tooltip template | Announces the content provided in the tooltip template. |
| Data label template | Announces the content provided in the data label template. |

## Keyboard Navigation

All Blazor Maps actions can be controlled using the keyboard. The following key combinations apply to the available UI interactions.

| Windows | Mac | Description|
|-----|-----|----|
|<kbd>Tab</kbd> | <kbd>Tab</kbd> |Moves focus to the next focusable element on the map, such as the legend or a shape.|
|<kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> |Moves focus to the previous focusable element on the map, such as the legend or a shape.|
|<kbd> + </kbd> | <kbd>+</kbd> |Performs zoom in when zooming is enabled.|
|<kbd> - </kbd> | <kbd>-</kbd> |Performs zoom out when zooming is enabled.|
|<kbd>←</kbd> | <kbd>←</kbd> |When zoomed in, scrolls the map to the left.|
|<kbd>→</kbd> | <kbd>→</kbd> |When zoomed in, scrolls the map to the right.|
|<kbd>↑</kbd> | <kbd>↑</kbd> |When zoomed in, scrolls the map upward.|
|<kbd>↓</kbd> | <kbd>↓</kbd> |When zoomed in, scrolls the map downward.|
|<kbd> R </kbd> | <kbd>R</kbd> |Performs reset when zooming is enabled.|
|<kbd>Enter</kbd> | <kbd>Enter</kbd> |Navigates through legend items and confirms selection when focusing a shape.|

## Ensuring accessibility

Accessibility compliance for the Blazor Maps component is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) during automated testing.

The component’s accessibility compliance is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/maps) in a new window to evaluate the component with accessibility tools.
