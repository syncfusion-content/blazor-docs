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
<a href="https://blazor.syncfusion.com/accessibility/combobox" target="_blank">Demo</a>
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
<tr>
<td>
Dashboard
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

</td>
<td>

</td>
<td>

</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/dashboardlayout" target="_blank">Demo</a>
</td>
<td>
<a href="../dashboard-layout/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Grid
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
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/datagrid" target="_blank">Demo</a>
</td>
<td>
<a href="../datagrid/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
DatePicker
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
<a href="https://blazor.syncfusion.com/accessibility/datepicker" target="_blank">Demo</a>
</td>
<td>
<a href="../datepicker/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
DateRangePicker
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
<a href="https://blazor.syncfusion.com/accessibility/daterangepicker" target="_blank">Demo</a>
</td>
<td>
<a href="../daterangepicker/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Datetime Picker
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
<a href="https://blazor.syncfusion.com/accessibility/datetimepicker" target="_blank">Demo</a>
</td>
<td>
<a href="../datetime-picker/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Diagram
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
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate">
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
<a href="https://blazor.syncfusion.com/accessibility/diagram" target="_blank">Demo</a>
</td>
<td>
<a href="../diagram/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Dialog
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/dialog" target="_blank">Demo</a>
</td>
<td>
<a href="../dialog/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
DocumentEditor
</td>
<td>
<img src=https://cdn.syncfusion.com/content/images/documentation/partial.png alt="Intermediate">
</td>
<td>
<img src=https://cdn.syncfusion.com/content/images/documentation/partial.png alt="Intermediate">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No">
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
<img src=https://cdn.syncfusion.com/content/images/documentation/partial.png alt="Intermediate">
</td>
<td>
<img src=https://cdn.syncfusion.com/content/images/documentation/partial.png alt="Intermediate">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/dialog" target="_blank">Demo</a>
</td>
<td>
<a href="../document-editor/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Dropdown Menu
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/dropdown-button" target="_blank">Demo</a>
</td>
<td>
<a href="../drop-down-menu/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
DropDown List
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/dropdownlist" target="_blank">Demo</a>
</td>
<td>
<a href="../dropdown-list/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Dropdown Tree
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
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
<a href="https://blazor.syncfusion.com/accessibility/dropdowntree" target="_blank">Demo</a>
</td>
<td>
<a href="../dropdown-tree/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
FileManager
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/filemanager" target="_blank">Demo</a>
</td>
<td>
<a href="../file-manager/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
File Upload
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/uploader" target="_blank">Demo</a>
</td>
<td>
<a href="../file-upload/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Gantt Chart
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/gantt-chart" target="_blank">Demo</a>
</td>
<td>
<a href="../gantt-chart/accessibility.md" target="_blank">Documentation</a>
</td>
<tr>
<td>
HeatMap Chart
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
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

</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/heatmap" target="_blank">Demo</a>
</td>
<td>
<a href="../heatmap-chart/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
</tr>
<tr>
<td>
In-place editor
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/inplace-editor" target="_blank">Demo</a>
</td>
<td>
<a href="../in-place-editor/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Image Editor
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/image-editor" target="_blank">Demo</a>
</td>
<td>
<a href="../image-editor/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Input Mask
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/maskedtextbox" target="_blank">Demo</a>
</td>
<td>
<a href="../input-mask/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Kanban
</td>
<td>
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/kanban" target="_blank">Demo</a>
</td>
<td>
<a href="../kanban/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Linear Gauge
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
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
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/lineargauge" target="_blank">Demo</a>
</td>
<td>
<a href="../linear-gauge/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ListBox
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/listbox" target="_blank">Demo</a>
</td>
<td>
<a href="../listbox/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ListView
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
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
<a href="https://blazor.syncfusion.com/accessibility/listview" target="_blank">Demo</a>
</td>
<td>
<a href="../listview/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Maps
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/maps" target="_blank">Demo</a>
</td>
<td>
<a href="../maps/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Mention
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/mention" target="_blank">Demo</a>
</td>
<td>
<a href="../mention/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Menu Bar
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/menu" target="_blank">Demo</a>
</td>
<td>
<a href="../menu-bar/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
MultiSelect Dropdown
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/multiselect" target="_blank">Demo</a>
</td>
<td>
<a href="../multiselect-dropdown/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Numeric TextBox
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/numerictextbox" target="_blank">Demo</a>
</td>
<td>
<a href="../numeric-textbox/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Pager
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/pager" target="_blank">Demo</a>
</td>
<td>
<a href="../pager/accessibility.md" target="_blank">Documentation</a>
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/pdfviewer" target="_blank">Demo</a>
</td>
<td>
<a href="../pdfviewer-2/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Pivot Table
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
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
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/pivot-table" target="_blank">Demo</a>
</td>
<td>
<a href="../pivot-table/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ProgressBar
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/progress-bar" target="_blank">Demo</a>
</td>
<td>
<a href="../progress-bar/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
ProgressButton
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/progress-button" target="_blank">Demo</a>
</td>
<td>
<a href="../progress-button/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Query Builder
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/querybuilder" target="_blank">Demo</a>
</td>
<td>
<a href="../query-builder/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
RadioButton
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/radio-button" target="_blank">Demo</a>
</td>
<td>
<a href="../radio-button/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Range Selector
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/range-selector" target="_blank">Demo</a>
</td>
<td>
<a href="../range-selector/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Range Slider
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/slider" target="_blank">Demo</a>
</td>
<td>
<a href="../range-slider/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Rating
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/rating" target="_blank">Demo</a>
</td>
<td>
<a href="../rating/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Rich Text Editor
</td>
<td>
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/rich-text-editor" target="_blank">Demo</a>
</td>
<td>
<a href="../rich-text-editor/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Scheduler
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/schedule" target="_blank">Demo</a>
</td>
<td>
<a href="../scheduler/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Sidebar
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/sidebar" target="_blank">Demo</a>
</td>
<td>
<a href="../sidebar/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Signature
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/signature" target="_blank">Demo</a>
</td>
<td>
<a href="../signature/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Skeleton
</td>
<td>
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
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/skeleton" target="_blank">Demo</a>
</td>
<td>
<a href="../skeleton/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Smith Chart
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/smith-chart" target="_blank">Demo</a>
</td>
<td>
<a href="../smith-chart/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Sparkline
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/sparkline" target="_blank">Demo</a>
</td>
<td>
<a href="../sparkline/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
SpeedDial
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/speeddial" target="_blank">Demo</a>
</td>
<td>
<a href="../speeddial/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
SplitButton
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/split-button" target="_blank">Demo</a>
</td>
<td>
<a href="../split-button/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Splitter
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/splitter" target="_blank">Demo</a>
</td>
<td>
<a href="../splitter/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Stepper
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/stepper" target="_blank">Demo</a>
</td>
<td>
<a href="../stepper/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Stock Chart
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/stock-chart" target="_blank">Demo</a>
</td>
<td>
<a href="../stock-chart/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Tabs
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/tab" target="_blank">Demo</a>
</td>
<td>
<a href="../tabs/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TextBox
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/textbox" target="_blank">Demo</a>
</td>
<td>
<a href="../textbox/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Timeline
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/timeline" target="_blank">Demo</a>
</td>
<td>
<a href="../timeline/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TimePicker
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/timepicker" target="_blank">Demo</a>
</td>
<td>
<a href="../timepicker/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Toast
</td>
<td>
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No">
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/toast" target="_blank">Demo</a>
</td>
<td>
<a href="../toast/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Toggle Switch Button
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/switch" target="_blank">Demo</a>
</td>
<td>
<a href="../toggle-switch-button/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Toolbar
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/toolbar" target="_blank">Demo</a>
</td>
<td>
<a href="../toolbar/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
Tooltip
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/tooltip" target="_blank">Demo</a>
</td>
<td>
<a href="../tooltip/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TreeGrid
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/treegrid" target="_blank">Demo</a>
</td>
<td>
<a href="../treegrid/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TreeMap
</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial">
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

</td>
<td>
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/treemap" target="_blank">Demo</a>
</td>
<td>
<a href="../treemap/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
TreeView
</td>
<td>
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
<a href="https://blazor.syncfusion.com/accessibility/treeview" target="_blank">Demo</a>
</td>
<td>
<a href="../treeview/accessibility.md" target="_blank">Documentation</a>
</td>
</tr>
<tr>
<td>
PDF Viewer
</td>
<td>
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
<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">
</td>
<td>
<a href="https://blazor.syncfusion.com/accessibility/pdfviewer" target="_blank">Demo</a>
</td>
<td>
<a href="../pdfviewer/accessibility.md" target="_blank">Documentation</a>
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

## Ignored Accessibility Rules

The following table outlines the accessibility rules that are intentionally ignored for certain components in our product. These rules have been evaluated and deemed non-critical for our specific use cases.

<table>
<tr>
<td><b>Component</b></td>
<td><b>Ignored Rules</b></td>
</tr>
<tr>
<td>Datagrid, Treegrid, Gantt-Chart</td>
<td>empty-table-header, scrollable-region-focusable, label, aria-required-children, aria-prohibited-attr, color-contrast</td>
</tr>
<tr>
<td>Datepicker, Daterangepicker, Timepicker, Multiselect, Diagram, Button, Button-Group, Dropdown-Button, Split-Button, Progress-Button, Circulargauge, Lineargauge, Treemap, Heatmap, Maps, Chips, Dashboardlayout, Dropdowntree, Listview, Chart, Accumulation-Chart, Bullet-Chart, Stock-Chart, Range-Selector, Sparkline, Smith-Chart, Progress-Bar, Querybuilder, Autocomplete, Combobox, Dropdownlist, Barcodegenerator, Toolbar, Rich-Text-Editor, Document-Editor, Stepper</td>
<td>color-contrast</td>
</tr>
<tr>
<td>Filemanager</td>
<td>color-contrast, aria-required-children, empty-table-header</td>
</tr>
<tr>
<td>Pivot-Table</td>
<td>empty-table-header, scrollable-region-focusable, color-contrast, aria-required-children, region</td>
</tr>
</table>
