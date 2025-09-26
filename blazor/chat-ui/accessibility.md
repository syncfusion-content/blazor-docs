---
layout: post
title: Accessibility in Blazor Chat UI Component | Syncfusion
description: Checkout and learn about Accessibility and Keyboard interaction with Blazor Chat UI component and more details.
platform: Blazor
control: Chat UI
documentation: ug
---

# Accessibility in Blazor Chat UI Component

The Syncfusion Blazor Chat component follows key accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) roles. This commitment ensures that the component is accessible to all users.

The accessibility compliance for the Chat UI component is outlined below:

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Accessibility Checker Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA Attributes

The following ARIA attributes are used in the Blazor Chat UI component to enhance its accessibility:

| Attribute | Purpose |
|---|---|
| `role="button"` | Applied to toolbar items to indicate they are clickable and will trigger an action. |
| `role="toolbar"` | Applied to the container of toolbar action buttons. |
| `aria-label` | Provides a string value that gives an accessible name to interactive elements, such as toolbar buttons. |
| `aria-orientation` | Specifies the orientation of the toolbar (e.g., horizontal). |
| `aria-disabled` | Indicates whether a toolbar item is disabled and not interactive. |
| `aria-multiline` | Applied to the message input box to indicate whether it accepts single or multiple lines of input. |

## Keyboard interaction

The Chat UI component supports the following keyboard shortcuts for improved navigation and interaction.

### General Navigation

| Windows | Mac | Action |
| --- | --- | --- |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item or sends a message when the input is focused. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus forward through the interactive elements. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus backward through the interactive elements. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Scrolls up through the chat history. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Scrolls down through the chat history. |
| <kbd>Ctrl</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> + <kbd>Home</kbd> | Scrolls to the first message in the chat history. |
| <kbd>Ctrl</kbd> + <kbd>End</kbd> | <kbd>⌘</kbd> + <kbd>End</kbd> | Scrolls to the most recent message in the chat history. |

### Toolbar Navigation

| Windows | Mac | Action |
|---|---|---|
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous toolbar item.  |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next toolbar item. |
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Activates the focused toolbar item. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Moves focus to the first toolbar item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Moves focus to the last toolbar item. |

## Ensuring Accessibility

The accessibility of the Blazor Chat UI component is ensured through automated testing using [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools.

## See Also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Components](https://blazor.syncfusion.com/documentation/common/accessibility)
