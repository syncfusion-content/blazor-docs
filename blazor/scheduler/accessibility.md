---
layout: post
title: Accessibility in Blazor Scheduler Component | Syncfusion
description: Describes how the Syncfusion Blazor Scheduler control has been built keeping web accessibility in mind, thus allowing to interact with assistive technologies.
platform: Blazor
control: Scheduler
documentation: ug
---

# Accessibility in Blazor Scheduler Component

Accessibility is achieved in the Scheduler component through WAI-ARIA standard and keyboard navigation. The Scheduler features can be effectively accessed through assistive technologies such as screen readers.

## WAI-ARIA

WAI-ARIA (Accessibility Initiative – Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with Ajax, HTML, JavaScript, and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components.

The following ARIA attributes are used in the Scheduler:

| Property | Functionalities |
|-------|---------|
| role="main" | This attribute added to the Scheduler element describes the actual role of the element and denote it as a main and unique content. |
| role="button" | This attribute is assigned to the appointments of Scheduler, to denote it as a clickable element. |
| role="grid" | This role is added to the scheduler in content table element and describes the table that contains collection of rows. |
| aria-disabled | It indicates the disabled state of the Scheduler. |
| aria-selected | It indicates the currently selected cell of the Scheduler. |
| aria-live | It indicates a string value that labels the Scheduler element. |
| aria-label | This attribute is assigned to the Scheduler parent element and its default value is Scheduler's current date. On every time, the date is navigated, this attribute is updated with appropriate current date values. It is also assigned to other scheduler UI elements such as previous and next date navigation buttons depicting its purpose, div element displaying date range in the header bar and appointment elements. |
| aria-readonly | This attribute is assigned to the appointments of Scheduler and defaults to `false`, which indicates that the appointments are editable by default. When it's value changes to `true`, it denotes that the appointments are in a not editable state. |
| aria-grabbed | This attribute is assigned to the appointments of Scheduler and defaults to `true`, which indicates that the appointments are allowed to move over the Scheduler. When it's value changes to `false`, it indicates that the drag and drop of appointments are not allowed. |
| aria-atomic | This attribute is assigned to the date range element displayed on the Scheduler header bar, to indicate that when date change takes place, the entire live region (Scheduler) should be updated to the user. It is set to `true`. |
| aria-live="assertive" | This attribute is assigned to the date range element displayed on the Scheduler header bar, to indicate that it updates the date values frequently on every time the user navigates back and forth between the dates. The value `assertive` means that the newly modified date changes has a high priority, and your screen reader *should* notify you immediately regarding this.
| aria-labelledby | It indicates editor dialog title to the user through assistive technologies. |
| aria-describedby | It indicates editor dialog content description to the user through assistive technologies. |

## Keyboard navigation

All the Scheduler actions can be controlled via keyboard keys and is availed by using `AllowKeyboardInteraction` property which is set to `true` by default. The applicable key combinations and its relative functionalities are listed below.

Interaction Keys |Description
-----|-----
<kbd>Alt</kbd> + <kbd>J</kbd> |Focuses the Scheduler [Provided from application end].
<kbd>Tab</kbd> |Focuses the first or active item on the scheduler header bar and then moves the focus to the next available event elements. If no events present, then focus moves out of the component.
<kbd>Shift</kbd> + <kbd>Tab</kbd> |Reverse focusing of the Tab functionality. Inverse focusing of event elements from the last one and then moves onto the first or active item on Scheduler header bar and then moves out of the component.
<kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>Arrow</kbd> (keys) |Focuses the event element and then moves the focus to the next available event elements between the resources.
<kbd>Escape</kbd> |Closes any of the popup that are in open state.
<kbd>Arrow</kbd> |To move onto the next available cells in either of the needed directions (left, right, top and right)
<kbd>Shift</kbd> + <kbd>Arrow</kbd> |For multiple cell selection on either direction.
<kbd>Delete</kbd> |Deletes one or more selected events.
<kbd>Ctrl</kbd> + <kbd>Click</kbd> on events |To select multiple events.
<kbd>Alt</kbd> + <kbd>Number</kbd> (from 1 to 6) |To switch between the views on Scheduler.
<kbd>Ctrl</kbd> + <kbd>Left Arrow</kbd> |To navigate to the previous date period.
<kbd>Ctrl</kbd> + <kbd>Right Arrow</kbd> |To navigate to the next date period.
<kbd>Left</kbd> or <kbd>Right Arrow</kbd> |On pressing any of these keys when focus is currently on the Scheduler header bar, moves the focus to the previous or next items in the header bar.
<kbd>Space</kbd> or <kbd>Enter</kbd> |It activates any of the focused items.
<kbd>Page Up</kbd> & <kbd>Page Down</kbd> |To scroll through the work cells area.
<kbd>Home</kbd> |To move the selection to the first cell of Scheduler.
<kbd>F12</kbd> |To have the inline option for both cells and events.
