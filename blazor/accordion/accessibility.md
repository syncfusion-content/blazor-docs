---
layout: post
title: Accessibility in Blazor Accordion Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Accordion component and much more.
platform: Blazor
control: Accordion
documentation: ug
---

# Accessibility in Blazor Accordion Component

The [Blazor Accordion](https://www.syncfusion.com/blazor-components/blazor-accordion) component has been designed keeping in mind the [WAI-ARIA](https://www.w3.org/TR/wai-aria-practices/) specifications, by applying the prompt WAI-ARIA roles, states and properties along with the keyboard support. Thus, making it usable for people who use assistive WAI-ARIA Accessibility supports that is achieved through the attributes like `aria-disabled`, `aria-expanded`, `aria-selected` and `aria-hidden`. It helps to provides information about the elements in a document for assistive technology. The component implements the keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/TR/wai-aria-practices/) and tested in major screen readers.

## ARIA attributes

| Property             | Functionality |
|----------------------|---------------|
| role                 | **Button:** indicates that the element can be used to toggle the visibility of the associated content section.This attribute is added to all the Accordion header elements describing the actual role of the element. <br> **Region:** It is users navigate and find specific information within a larger document. accordion panel allows them to easily access different sections of the document by clicking on the headings within the accordion.This attribute is added to all the Accordion panel elements describing the actual role of the element.  |
| aria-disabled        | It indicates the disabled state of the Accordion and its items.  |
| aria-expanded        | It indicates the expand state of the Accordion Item. Default value of this attribute is `false`. If an item is expanded, the attribute value changes to ‘true’. |
| aria-selected        | It indicates the Selection state of the Accordion Item. Default value of this attribute is `false`. If an item is expanded, the attribute value changes to ‘true’.  |
| aria-hidden          | It indicates the content visible state of the Accordion Item. Default value of this attribute is `true`. If an item content is visible, the attribute value changes to `false`. |
| aria-labelledby      | Attribute is set to content (panel) and it points to the corresponding Accordion header.|
| aria-controls        | Attribute is set to the header and it points to the corresponding Accordion content.  |

## Keyboard interaction

Keyboard navigation is enabled by default. The possible keys are:

| Key           | Description       |
|---------------|-------------------|
| <kbd>Space or Enter</kbd>    | When the focus is on the Accordion header, clicking on the focused element makes the element to expand and collapse. |
| <kbd>Down Arrow</kbd>   | Focus the next Accordion header. |
| <kbd>Up Arrow</kbd>         | Focus the previous Accordion header. |
| <kbd>Home</kbd>           | Focus the first Accordion header. |
| <kbd>End</kbd>   | Focus the last Accordion header. |