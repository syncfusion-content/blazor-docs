---
layout: post
title: Accessibility with ADA compliance in Syncfusion Blazor components
description: The Syncfusion Blazor UI components are compliant with section 508, ADA, WAI-ARIA, WCAG, and keyboard accessibility standards.
platform: Blazor
component: Common
documentation: ug
---

# Accessibility with ADA Compliance in Syncfusion Blazor Components

All the Syncfusion Blazor components follow the WAI-ARIA accessibility standard by default. This enables you to build accessible web applications, which are fully navigable by users with disabilities.

## Accessibility overview

Accessibility in components refers to the practice of designing and building user interface elements in a way that makes them accessible to users with disabilities. This can include a variety of things, such as making sure that text is high-contrast and easy to read, providing alternative text for images, and designing controls and interactions that can be used with a keyboard or assistive technology.

## Accessibility standards

The component is said to be accessible when it is constructed in accordance with certain standards that are required to make it accessible.

The accessibility of the components consists of the following standards and aspects:

[ADA](https://www.ada.gov/) - A law to ensure that people with disabilities have the same opportunities and access as people without disabilities.

[WCAG 2.2](https://www.w3.org/WAI/standards-guidelines/wcag/) - The Web Content Accessibility Guidelines (WCAG) provide guidelines developed by the World Wide Web Consortium (W3C) to ensure web content is accessible to people with disabilities. WCAG 2.2 establishes a framework of accessibility principles and their associated success criteria. The level of accessibility conformance achieved by a web application is determined by the extent to which it meets these success criteria, categorized into three levels: A, AA, and AAA.

[Section 508](https://www.section508.gov/) - It is a set of guidelines for making electronic and information technology (EIT) accessible to people with disabilities. These standards apply to federal agencies in the United States, and they are based on the Web Content Accessibility Guidelines (WCAG).

[WAI-ARIA](https://www.w3.org/WAI/ARIA/) - WAI-ARIA stands for “Web Accessibility Initiative - Accessible Rich Internet Applications.” It is a set of technical specifications and guidelines developed by the World Wide Web Consortium (W3C) as part of the Web Accessibility Initiative (WAI). WAI-ARIA is designed to enhance the accessibility of dynamic web content, particularly web applications and rich internet applications (RIAs), for people with disabilities. WAI-ARIA provides a set of roles, states, and properties that can be added to HTML elements to provide additional context and information about the purpose and behavior of those elements. This can help assistive technologies better understand and interpret web content and interact with web applications.

[Keyboard navigation](https://www.w3.org/TR/WCAG22/#keyboard-accessible) - It refers to the ability to use a keyboard to interact with and navigate through a user interface. It is an important aspect of web accessibility, as it allows people who cannot use a mouse or other pointing device to access and use web content and applications.

Syncfusion Blazor components adhere to these established standards.

## Accessibility compliance

The accessibility support provided by Syncfusion Blazor components is based on a collection of methodologies for adhering to and [applying recognized standards and technical specifications](#accessibility-standards) to ensure an intuitive experience for people with disabilities.

There are several methodologies of accessibility validation that can be performed on the Syncfusion Blazor components, such as:

The [WAI-ARIA patterns](https://www.w3.org/WAI/ARIA/apg/patterns/) are followed by the Syncfusion Blazor components to enable appreciable accessibility.

Each Blazor component is subjected to manual testing with a screen reader and also automated test cases to ensure the component’s required attributes.

Attributes are allocated and updated correctly during interaction as well. Each component has been assigned a distinct `Role` attribute and its own set of ARIA attributes defined by the [WCAG 2.2](https://www.w3.org/TR/WCAG22/) specification.

In addition to the methodologies mentioned above, Syncfusion Blazor components are constructed to support the following accessibility aspects.

### Screen reader support

A screen reader allows people who are blind or visually impaired to use a computer by reading aloud the text that is displayed on the screen. Syncfusion Blazor components followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/) standards to work properly in the screen readers such as [Narrator](https://support.microsoft.com/en-us/windows/complete-guide-to-narrator-e4397a0d-ef4f-b386-d8ae-c172f109bdb1) for Windows and [Embedded VoiceOver](https://support.apple.com/en-in/guide/voiceover/vo2706/mac) for MAC.

### Right-To-Left support

Right-to-Left (RTL) support allows applications to effectively communicate with users who use languages that are written from right to left, such as Arabic, Hebrew, etc. Syncfusion Blazor components support the Right-to-Left feature. Refer to the [Right-to-Left documentation](https://blazor.syncfusion.com/documentation/common/right-to-left) to learn more about this support.

### Color contrast

Syncfusion Blazor components come equipped with [predefined themes](https://blazor.syncfusion.com/documentation/appearance/themes) that guarantee the presence of satisfactory color contrast, benefiting individuals with visual impairments.

### Mobile device support

Syncfusion Blazor components are more user-friendly and accessible to individuals using mobile devices, including those with disabilities. These are designed to be responsive, adaptable to various screen sizes and orientations, and touch-friendly.

### Keyboard navigation support

Syncfusion Blazor components support keyboard navigation, allowing users who rely on alternate methods to effortlessly navigate and interact with the component.

## Ensuring accessibility

Ensuring the accessibility of Syncfusion Blazor components is crucial for making the product inclusive and user-friendly for individuals with disabilities. This process involves various types of accessibility testing, including:

* **Automated testing**: The Syncfusion Blazor component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

* **Manual testing**: This type of testing involves manually evaluating the Syncfusion Blazor components. During manual accessibility testing, testers will ensure accessibility using the screen readers such as [Narrator](https://support.microsoft.com/en-us/windows/complete-guide-to-narrator-e4397a0d-ef4f-b386-d8ae-c172f109bdb1) for Windows and [Embedded VoiceOver](https://support.apple.com/en-in/guide/voiceover/vo2706/mac) for MAC.

Syncfusion Blazor components will keep improving when there is anything required. It also involves client feedback to make the component more accessible.

## Accessibility support for specific components

Consult the component-specific documents below for detailed information about how Syncfusion Blazor components ensure compliance with accessibility standards, encompassing Section 508, WAI-ARIA, WCAG 2.2, keyboard navigation, and more.

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
<b>Axe-core Accessibility Validation</b>
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

</td>
<td>

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
<a href="../accordion/accessibility.md" target="_blank">Documentation</a>
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/accumulation-chart" target="_blank">Demo</a>
</td>
<td>
<a href="../accumulation-chart/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
AppBar
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

</td>
<td>

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
<a href="../appbar/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
AutoComplete
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
<a href="../autocomplete/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Breadcrumb
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/breadcrumb" target="_blank">Demo</a>
</td>
<td>
<a href="../breadcrumb/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Bullet Chart
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/bullet-chart" target="_blank">Demo</a>
</td>
<td>
<a href="../bullet-chart/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Button
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/button" target="_blank">Demo</a>
</td>
<td>
<a href="../button/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Button Group
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/button-group" target="_blank">Demo</a>
</td>
<td>
<a href="../button-group/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Calendar
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
<a href="../calendar/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Carousel
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

</td>
<td>
    
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
<a href="../carousel/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Chart
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/chart" target="_blank">Demo</a>
</td>
<td>
<a href="../chart/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
CheckBox
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/checkbox" target="_blank">Demo</a>
</td>
<td>
<a href="../check-box/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Blazor Chip
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

</td>
<td>

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
<a href="../chip/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Circular Gauge
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/circulargauge" target="_blank">Demo</a>
</td>
<td>
<a href="../circular-gauge/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Color Picker
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/color-picker" target="_blank">Demo</a>
</td>
<td>
<a href="../color-picker/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ComboBox
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="[https://blazor.syncfusion.com/accessibility/color-picker](https://blazor.syncfusion.com/accessibility/combobox)" target="_blank">Demo</a>
</td>
<td>
<a href="../combobox/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ContextMenu
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/context-menu" target="_blank">Demo</a>
</td>
<td>
<a href="../context-menu/accessibility.md" target="_blank">Documentation</a>
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

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>
