---
layout: post
title: Accessibility in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# Accessibility in Blazor TreeView Component

The [Blazor TreeView](https://www.syncfusion.com/blazor-components/blazor-treeview) component has been designed keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/treeview/) specifications, and applies WAI-ARIA roles, states, and properties along with `keyboard support`. This component is characterized by complete keyboard interaction support and ARIA accessibility support that makes it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation.

The Blazor TreeView component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor TreeView component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor TreeView component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/treeview/) patterns to meet the accessibility. The following ARIA attributes are used in the TreeView component:

| **Attributes** | **Purpose** |
| --- | --- |
| aria-multiselectable | Indicates whether the TreeView enables multiple selection or not. |
| aria-expanded | Indicates whether the parent node has expanded or not. |
| aria-selected | Indicates the selected node. |
| aria-grabbed | Indicates the selected state on drag-and-drop of node. |
| aria-level | Indicates the level of node in TreeView. |

## Keyboard interaction

The Blazor TreeView component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/treeview/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the TreeView component.

| Windows | Mac | Description |
|------|----|-----|
| <kbd>↑</kbd> | <kbd>↑</kbd> | Goes to the previous node. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Goes to the next node. |
| <kbd>→</kbd> | <kbd>→</kbd> | Expands the current node. |
| <kbd>←</kbd> | <kbd>←</kbd> | Collapses the current node. |
| <kbd>Home</kbd> | <kbd>fn</kbd>+<kbd>←</kbd> | Goes to the first node. |
| <kbd>End</kbd> | <kbd>fn</kbd>+<kbd>→</kbd> | Goes to the last node. |
| <kbd>F2</kbd> | <kbd>F2</kbd> | Edits the focused node. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Focuses out the edit state without saving the edited text. |
| <kbd>Enter</kbd> |<kbd>return</kbd> | Selects the focused node/saves the edited text. |
| <kbd>Space</kbd> | <kbd>space</kbd> | Checks the current node. |
| <kbd>Ctrl + A</kbd> | <kbd>⌘</kbd> + <kbb>A</kbd> | Selects all nodes. |

## Ensuring accessibility

The Blazor TreeView component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the TreeView component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/treeview) in a new window to evaluate the accessibility of the TreeView component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)