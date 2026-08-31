---
layout: post
title: Blazor Maps Accessibility | Syncfusion®
description: Learn how Blazor Maps meet WCAG 2.2, Section 508, WAI-ARIA, and screen reader accessibility standards with keyboard navigation support.
platform: Blazor
control: Maps
documentation: ug
---

# Blazor Maps Accessibility

The [Blazor Maps](https://www.syncfusion.com/blazor-components/blazor-map) component adheres to widely adopted accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor Maps component is summarized below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility) | AA |
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

To meet accessibility standards, the Blazor Maps component adheres to [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns. The following WAI-ARIA attributes are used in the Maps component:

| Attributes | Purpose |
| --- | --- |
| `role="region"` | Identifies non-interactive map areas (shapes without selection or highlighting). |
| `role="button"` | Identifies interactive map areas that support selection and highlighting. |
| `aria-label` | Provides accessible names for map elements including geometric shapes, title, subtitle, legend title, legend item labels, and data labels. The announced text is listed in the [Screen reader support](#screen-reader-support) section. |

## Screen reader support

Accessibility in the Blazor Maps component ensures compatibility with screen readers. The following map elements are announced by screen readers such as Narrator (Windows), NVDA, JAWS, and VoiceOver (macOS).

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

All Blazor Maps actions can be controlled using the keyboard. The zoom in, zoom out, reset, and arrow-key panning shortcuts require zooming to be enabled by setting the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html#Syncfusion_Blazor_Maps_MapsZoomSettings_Enable) property of [MapsZoomSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.MapsZoomSettings.html) to **true**. The following key combinations apply to the available UI interactions.

| Windows | Mac | Description |
|-----|-----|----|
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the next focusable element on the map, such as the legend or a shape. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the previous focusable element on the map, such as the legend or a shape. |
| <kbd>+</kbd> | <kbd>+</kbd> | Performs zoom in when zooming is enabled. |
| <kbd>-</kbd> | <kbd>-</kbd> | Performs zoom out when zooming is enabled. |
| <kbd>←</kbd> | <kbd>←</kbd> | When zoomed in, scrolls the map to the left. |
| <kbd>→</kbd> | <kbd>→</kbd> | When zoomed in, scrolls the map to the right. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | When zoomed in, scrolls the map upward. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | When zoomed in, scrolls the map downward. |
| <kbd>R</kbd> | <kbd>R</kbd> | Performs reset when zooming is enabled. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Moves through legend items, and selects the focused shape. |

## Accessibility validation

Accessibility compliance for the Blazor Maps component is validated with the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) tool during automated testing.

The component’s accessibility compliance is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/maps) in a new window to evaluate the component with accessibility tools.
