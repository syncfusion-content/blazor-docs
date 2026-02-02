---
layout: post
title: Accessibility in Syncfusion Blazor components
description: Syncfusion Blazor components support WCAG 2.2, Section 508, WAI-ARIA, ADA, and keyboard accessibility standards.
platform: Blazor
control: Common
documentation: ug
---

# Accessibility in Syncfusion® Blazor components

All Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components follow WAI-ARIA by default, enabling accessible web applications that are fully navigable with assistive technologies.

## Accessibility overview

Accessibility in components refers to designing and building user interface elements so that users with disabilities can perceive, operate, and understand them. Examples include sufficient color contrast, alternative text for images, and keyboard-operable controls and interactions.

## Accessibility standards

A component is accessible when it is implemented in accordance with recognized accessibility standards.

The accessibility of the components consists of the following standards and aspects:

[ADA](https://www.ada.gov/) - A law to ensure that people with disabilities have the same opportunities and access as people without disabilities.

[WCAG 2.2](https://www.w3.org/WAI/standards-guidelines/wcag/) - Guidelines from the W3C to ensure web content is accessible to people with disabilities, organized by success criteria at levels A, AA, and AAA.

[Section 508](https://www.section508.gov/) - U.S. federal standards for making electronic and information technology accessible, aligned with WCAG.

[WAI-ARIA](https://www.w3.org/WAI/ARIA/) - Roles, states, and properties that enhance accessibility of dynamic web content and applications for assistive technologies.

[Keyboard navigation](https://www.w3.org/TR/WCAG22/#keyboard-accessible) - The ability to use a keyboard to interact with and navigate a user interface.

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components adhere to these established standards.

## Accessibility compliance

Accessibility support in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components is based on adhering to and [applying recognized standards and technical specifications](#accessibility-standards) to ensure an intuitive experience for people with disabilities.

There are several methodologies of accessibility validation that can be performed on the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components, such as:

The [WAI-ARIA patterns](https://www.w3.org/WAI/ARIA/apg/patterns/) are followed by the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components to enable appreciable accessibility.

Each Blazor component is evaluated with manual screen reader testing and automated tests to ensure required attributes and behaviors are present.

Attributes are assigned and updated correctly during interaction. Each component has an appropriate `role` and ARIA attributes defined by the [WCAG 2.2](https://www.w3.org/TR/WCAG22/) specification.

In addition to the methodologies mentioned above, Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are constructed to support the following accessibility aspects.

### Screen reader support

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components follow [WAI-ARIA](https://www.w3.org/WAI/ARIA/) to work properly with screen readers such as [Narrator](https://support.microsoft.com/windows/complete-guide-to-narrator-e4397a0d-ef4f-b386-d8ae-c172f109bdb1) for Windows and [VoiceOver](https://support.apple.com/guide/voiceover/vo2706/mac) for macOS.

### Right-to-left support

Right-to-Left (RTL) support allows applications to effectively communicate with users who use languages that are written from right to left, such as Arabic, Hebrew, etc. Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components support the Right-to-Left feature. Refer to the [Right-to-Left documentation](https://blazor.syncfusion.com/documentation/common/right-to-left) to learn more about this support.

### Color contrast

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components include [predefined themes](https://blazor.syncfusion.com/documentation/appearance/themes) that provide sufficient color contrast to benefit users with visual impairments.

### Mobile device support

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are more user-friendly and accessible to individuals using mobile devices, including those with disabilities. These are designed to be responsive, adaptable to various screen sizes and orientations, and touch-friendly.

### Keyboard navigation support

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components support keyboard navigation, allowing users who rely on alternate methods to effortlessly navigate and interact with the component.

## Ensuring accessibility

Ensuring the accessibility of Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components is crucial for making the product inclusive and user-friendly for individuals with disabilities. This process involves various types of accessibility testing, including:

* **Automated testing**: Accessibility is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

* **Manual testing**: Manual evaluation using screen readers such as [Narrator](https://support.microsoft.com/windows/complete-guide-to-narrator-e4397a0d-ef4f-b386-d8ae-c172f109bdb1) for Windows and [VoiceOver](https://support.apple.com/guide/voiceover/vo2706/mac) for macOS.

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components continually improve based on standards updates and user feedback to enhance accessibility.

## Accessibility support for specific components

Consult the component-specific documents below for details on how Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components ensure compliance with accessibility standards, including Section 508, WAI-ARIA, WCAG 2.2, keyboard navigation, and more. The table uses the legend shown below.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td>
<b>Components</b>
</td>
<td>
<b>WCAG 2.2</b>
</td>
<td>
<b>Section 508</b>
</td>
<td>
<b>Screen Reader</b>
</td>
<td>
<b>Right-To-Left</b>
</td>
<td>
<b>Color Contrast</b>
</td>
<td>
<b>Mobile Device</b>
</td>
<td>
<b>Keyboard Navigation</b>
</td>  
<td>
<b>Accessibility Example</b>
</td>
<td>
<b>Accessibility Documentation</b>
</td>
</tr>
<tr>
<td>
Accordion 
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/accordion" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/accordion/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Accumulation Chart
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/accumulation-chart" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/accumulation-chart/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
AppBar
</td>
<td>
NA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/appbar" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/appbar/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
AI AssistView
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/ai-assistview" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/ai-assistview/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
AutoComplete
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/autocomplete" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/autocomplete/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Breadcrumb
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/breadcrumb" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/breadcrumb/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Bullet Chart
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/bullet-chart" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/bullet-chart/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Button
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/button" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/button/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Button Group
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/button-group" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/button-group/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Calendar
</td>
<td>
AA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/calendar" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/calendar/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Carousel
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> 
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/carousel" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/carousel/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Chart
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/chart" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/chart/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Chat UI
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/chat-ui" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/chat-ui/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
CheckBox
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/checkbox" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/check-box/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Chip
</td>
<td>
AA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/chips" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/chip/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Circular Gauge
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/circulargauge" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/circular-gauge/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Color Picker
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/color-picker" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/color-picker/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ComboBox
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/combobox" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/combobox/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ContextMenu
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/context-menu" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/context-menu/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Dashboard
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/dashboardlayout" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/dashboard-layout/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Grid
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/datagrid" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/datagrid/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
DatePicker
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/datepicker" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/datepicker/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
DateRangePicker
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/daterangepicker" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/daterangepicker/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Datetime Picker
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/datetimepicker" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/datetime-picker/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Diagram
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/diagram" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/diagram/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Dialog
</td>
<td>
AA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/dialog" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/dialog/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
DocumentEditor
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/document-editor" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/document-editor/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Dropdown Menu
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/dropdown-button" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/drop-down-menu/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
DropDown List
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/dropdownlist" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/dropdown-list/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Dropdown Tree
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/dropdowntree" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/dropdown-tree/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
FileManager
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/filemanager" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/file-manager/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
File Upload
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/uploader" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/file-upload/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Gantt Chart
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/gantt-chart" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/gantt-chart/accessibility" target="_blank">Documentation</a>
</td>
<tr>
<td>
HeatMap Chart
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/heatmap" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/heatmap-chart/accessibility" target="_blank">Documentation</a>
</td>
</tr>
</tr>
<tr>
<td>
In-place editor
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/inplace-editor" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/in-place-editor/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Image Editor
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/image-editor" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/image-editor/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Input Mask
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/maskedtextbox" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/input-mask/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Kanban
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/kanban" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/kanban/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Linear Gauge
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/lineargauge" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/linear-gauge/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ListBox
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/listbox" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/listbox/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ListView
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/listview" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/listview/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Maps
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/maps" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/maps/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Mention
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/mention" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/mention/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Menu Bar
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/menu" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/menu-bar/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
MultiSelect Dropdown
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/multiselect" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/multiselect-dropdown/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Numeric TextBox
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/numerictextbox" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/numeric-textbox/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Pager
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/pager" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/pager/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
SfPdfViewer
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/sfpdfviewer" target="_blank">Demo</a>
</td>
<td>
<a href="https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Pivot Table
</td>
<td>
AA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/pivot-table" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/pivot-table/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ProgressBar
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/progress-bar" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/progress-bar/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ProgressButton
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/progress-button" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/progress-button/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Query Builder
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/querybuilder" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/query-builder/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
RadioButton
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/radio-button" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/radio-button/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Range Selector
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/range-selector" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/range-selector/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Range Slider
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/slider" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/range-slider/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Rating
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/rating" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/rating/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Rich Text Editor
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/rich-text-editor" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/rich-text-editor/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Scheduler
</td>
<td>
AA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/schedule" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/scheduler/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Sidebar
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/sidebar" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/sidebar/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Signature
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/signature" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/signature/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Skeleton
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/skeleton" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/skeleton/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Smith Chart
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/smith-chart" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/smith-chart/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Sparkline
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/sparkline" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/sparkline/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
SpeedDial
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/speeddial" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/speeddial/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
SplitButton
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/split-button" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/split-button/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Splitter
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/splitter" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/splitter/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Stepper
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/stepper" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/stepper/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Stock Chart
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/stock-chart" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/stock-chart/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Tabs
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/tab" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/tabs/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TextBox
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/textbox" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/textbox/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Timeline
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/timeline" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/timeline/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TimePicker
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/timepicker" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/timepicker/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Toast
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/toast" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/toast/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Toggle Switch Button
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/switch" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/toggle-switch-button/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Toolbar
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/toolbar" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/toolbar/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Tooltip
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/tooltip" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/tooltip/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TreeGrid
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/treegrid" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/treegrid/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TreeMap
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
N/A
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/treemap" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/treemap/accessibility" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TreeView
</td>
<td>
AAA
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/treeview" target="_blank">Demo</a>
</td>
<td>
<a href="https://blazor.syncfusion.com/documentation/treeview/accessibility" target="_blank">Documentation</a>
</td>
</tr>
</table>

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

