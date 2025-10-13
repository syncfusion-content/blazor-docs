---
layout: post
title: Accessibility in Blazor Ribbon Component | Syncfusion
description: Checkout and learn about Accessibility in Blazor Ribbon component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Ribbon
documentation: ug
---

# Accessibility in Blazor Ribbon component

The Ribbon component is designed to follow accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) roles.

The accessibility compliance for the Ribbon component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Intermediate"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Intermediate"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Accessibility Checker](https://www.npmjs.com/package/accessibility-checker) Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core](https://www.npmjs.com/package/axe-core) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Ribbon component uses [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/tabs/) patterns to enhance accessibility. The following ARIA attributes are used in the component:

| Attribute | Purpose |
| --- | --- |
| `role=tablist` | Identifies the container element for a set of tabs. |
| `role=tab` | Identifies an interactive element inside a `tablist` that controls the visibility of an associated `tabpanel`. |
| `role=tabpanel` | Identifies the container for the content associated with a `tab`. |
| `role=button` | Identifies a clickable element that triggers a response when activated. |
| `role=menu` | Identifies a container for a set of `menuitem` elements. |
| `role=menuitem` | Identifies a selectable option within a `menu`. |
| `role=combobox` | Identifies an input element that controls a separate popup element, such as a listbox or grid. |
| `role=option` | Identifies a selectable item within a listbox or combobox. |
| `role=gridcell` | Identifies a cell within a `grid` or `treegrid`. |
| `aria-orientation` | Indicates the orientation of an element, such as a `tablist` or `toolbar`. |
| `aria-selected` | Indicates the current selection state of an element within a set, such as a `tab` or `option`. |
| `aria-labelledby` | Associates an element with the element that provides its label. |
| `aria-controls` | Identifies the element whose content is controlled by the current element. |
| `aria-haspopup` | Indicates that the element can trigger a popup and specifies the type of popup. |
| `aria-disabled` | Indicates that the element is visible but not interactive. |
| `aria-expanded` | Indicates whether a collapsible element is currently expanded or collapsed. |
| `aria-label` | Provides an accessible name for an interactive element. |
| `aria-checked` | Indicates the state of a checkable element like a checkbox or menuitemcheckbox. |
| `aria-owns` | Establishes a relationship between elements when the DOM hierarchy cannot represent it. |
| `aria-readonly` | Indicates that an element is not editable but is otherwise interactive. |
| `aria-activedescendant` | Identifies the currently focused descendant of a composite widget. |
| `aria-autocomplete` | Indicates how predictions are presented for a combobox, searchbox, or textbox. |

## Keyboard interaction

The Ribbon component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/tabs/#keyboardinteraction) to support users who rely on assistive technologies (AT) or keyboard navigation. The following keyboard shortcuts are available:

| Windows | Mac | Action |
| --- | --- | --- |
| **Ribbon Tab** | | |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses the first Ribbon tab. If a tab is already focused, it moves focus out of the tab list. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves focus to the next tab. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves focus to the previous tab. |
| <kbd>Enter</kbd> or <kbd>Space</kbd> | <kbd>Enter</kbd> or <kbd>Space</kbd> | Selects the currently focused tab. |
| **Ribbon Items** | | |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigates between items within a Ribbon group. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves focus to the next item. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves focus to the previous item. |
| <kbd>Enter</kbd> or <kbd>Space</kbd> | <kbd>Enter</kbd> or <kbd>Space</kbd> | Activates the focused item. |
| **Ribbon Dropdown/Split Button** | | |
| <kbd>Enter</kbd> or <kbd>Space</kbd> | <kbd>Enter</kbd> or <kbd>Space</kbd> | Opens the dropdown or activates the selected item. |
| <kbd>↓</kbd> / <kbd>↑</kbd> | <kbd>↓</kbd> / <kbd>↑</kbd> | Moves focus between items in the dropdown list. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the dropdown. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the dropdown. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the dropdown. |
| **Ribbon File Menu** | | |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Opens the file menu or activates the selected item. |
| <kbd>↓</kbd> / <kbd>↑</kbd> | <kbd>↓</kbd> / <kbd>↑</kbd> | Moves focus between items in the file menu. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the file menu. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the file menu. |
| **Ribbon ComboBox** | | |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Selects the first item if none is selected, otherwise selects the next item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Selects the previous item. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Scrolls to the next page of items. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Scrolls to the previous page of items. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item and closes the suggestion list. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses the next element on the page. If the suggestion list is open, it closes it first. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Focuses the previous element on the page. If the suggestion list is open, it closes it first. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the suggestion list. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the suggestion list. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the suggestion list, retaining the current selection. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Moves the cursor to the beginning of the input text. |
| <kbd>End</kbd> | <kbd>End</kbd> | Moves the cursor to the end of the input text. |

## Ensuring accessibility

The Ribbon component's accessibility is ensured through automated testing using [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools. These tools help maintain a high level of compliance by automatically detecting potential issues.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
