---
layout: post
title: Styles and Appearances in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about Styles and Appearances in Syncfusion Blazor QueryBuilder component and more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Styles and Appearances in Blazor QueryBuilder Component

Customize the appearance of the Query Builder by overriding the component’s default CSS. The following table lists commonly used CSS selectors and the corresponding UI areas they affect. For consistent theming across applications, consider generating a custom theme with [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
| ----- | ----- |
| .e-query-builder .e-btn-group input + label.e-btn | Customize the condition button in the Query Builder. | 
| .e-query-builder .e-btn-group input:checked + label.e-btn | Customize the selected condition button in the Query Builder. |
| .e-query-builder .e-group-body .e-rule-container | Customize the Query Builder rule container. |
| .e-query-builder .e-group-action .e-btn | Customize the Query Builder Add Group/Add Condition buttons. |
| .e-query-builder .e-removerule.e-btn.e-round | Customize the Query Builder delete button. |
| .e-query-builder .e-rule-list > ::after, .e-query-builder .e-rule-list > ::before | Customize the Query Builder group joining line. |
| .e-query-builder .e-rule-container.e-joined-rule | Customize the Query Builder condition joining line. |

## Background Customization

The outermost wrapper rendered by `QueryBuilder` carries the `.e-query-builder` class. Override its `background`, `border` and `border-radius` to control the overall surface of the component.

```css
.e-query-builder {
    background-color: #f5f7fb;
    border: 1px solid #c3cad6;
    border-radius: 10px;
}
```

## Group Container Customization

Every group (the root group and any nested groups) is wrapped in a `.e-group-container`. The container holds both the header (AND/OR + actions) and the body (rules). Use `.e-query-builder .e-group-container` to change its background, border and rounding; for nested groups, qualify the selector with a descendant `.e-group-container`.

```css
.e-query-builder .e-group-container {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    border-radius: 6px;
}
```

## Group Header Customization

The header strip that contains the AND/OR toggle and the add / lock-group buttons uses `.e-group-header`. Override its background and padding to visually separate the header from the rules area, and add a bottom border to draw a divider.

```css
.e-query-builder .e-group-header {
    background-color: #eef2f7;
    border-bottom: 1px solid #d6dce5;
    padding: 8px 12px;
}
```

## Group Body Customization

The rules region below the header uses `.e-group-body .e-rule-container`. Adjust its background and inner padding to control the breathing room around the rule rows.

```css
.e-query-builder .e-group-body, 
.e-query-builder .e-rule-container {
    background-color: beige;
    padding: 12px 16px;
}
```

## AND / OR Button Group Customization

The connector toggle is a Syncfusion button group. The two visible buttons are the labels `.e-btngroup-and-lbl` and `.e-btngroup-or-lbl`; the active label is selected via the `:checked + label` sibling selector against the hidden radios `.e-btngroup-and` / `.e-btngroup-or`. Use these to style the unselected, hover and selected states.

```css
.e-query-builder .e-group-header .e-btn.e-btngroup-and-lbl,
.e-query-builder .e-group-header .e-btn.e-btngroup-or-lbl {
    background-color: #d9d9d9;
    border: none;
    color: #2c547b;
}

.e-query-builder .e-group-header .e-btn.e-btngroup-and-lbl:hover,
.e-query-builder .e-group-header .e-btn.e-btngroup-or-lbl:hover {
    background-color: #fff2c6;
    color: #ff0707;
}

.e-query-builder .e-group-header .e-btngroup-and:checked + .e-btngroup-and-lbl,
.e-query-builder .e-group-header .e-btngroup-or:checked + .e-btngroup-or-lbl {
    background-color: #6cfd0d;
    border-color: #6cfd0d;
    color: #f30041;
}
```

## Add Button & Lock Group Button Customization

The right-hand action area of the group header hosts the "Add Group/Condition" dropdown button (`.e-add-btn`) and the "Lock Group" button (`.e-lock-grp-btn`). Both render as round icon buttons; override their background, border and the embedded `.e-icons` color to restyle them.

```css
.e-query-builder .e-group-header .e-add-btn,
.e-query-builder .e-group-header .e-lock-grp-btn {
    background-color: #0d6efd;
    border: 1px solid #0035ff;
    color: #ffffff;
}

.e-query-builder .e-group-header .e-add-btn:hover,
.e-query-builder .e-group-header .e-lock-grp-btn:hover {
    background-color: beige;
    border-color: transparent;
    box-shadow: 0px 0px 5px chocolate;
}

.e-query-builder .e-group-header .e-add-btn .e-icons,
.e-query-builder .e-group-header .e-lock-grp-btn .e-icons {
    color: #0035ff;
}

.e-query-builder .e-group-header .e-add-btn .e-icons:hover {
    color: orangered;
}
```

## Rule Container Customization

Each rule row is wrapped in `.e-rule-container`. Override its background, border and radius to give every rule a distinct card-like appearance. The default theme also adds the modifier class `.e-horizontal-mode` or `.e-vertical-mode` &mdash; chain it to scope the override to a specific layout.

```css
.e-query-builder .e-rule-container {
    background-color: darkorange;
    border: 5px solid chocolate;
    border-radius: 5px;
    padding: 10px;
}

.e-query-builder .e-rule-container.e-horizontal-mode {
    background-color: antiquewhite;
}
```

## Rule Action Buttons Customization

Each rule's right-hand action group sits inside `.e-rule-value-delete` and contains three round icon buttons: clone (`.e-clone-rule`), lock (`.e-lock-rule`) and delete (`.e-rule-delete`, also marked `.e-removerule`). Style them individually or together.

```css
.e-query-builder .e-rule-value-delete .e-clone-rule,
.e-query-builder .e-rule-value-delete .e-lock-rule,
.e-query-builder .e-rule-value-delete .e-rule-delete {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    color: #495057;
}

.e-query-builder .e-rule-value-delete .e-clone-rule:hover,
.e-query-builder .e-rule-value-delete .e-lock-rule:hover {
    background-color: #eef2f7;
    color: #0d6efd;
}

.e-query-builder .e-rule-value-delete .e-rule-delete:hover,
.e-query-builder .e-rule-value-delete .e-removerule:hover {
    background-color: #fdecec;
    border-color: #dc3545;
    color: #dc3545;
}
```

## Connector Lines Between Rules

The dotted L-shaped lines that link sibling rules are drawn with the `::before` and `::after` pseudo-elements of the children of `.e-rule-list`. Override their `border-color`, `border-style` and `border-width` to restyle the connectors; the first child's `::before` and the last child's `::after` are hidden by default to keep the chain clean.

```css
.e-query-builder .e-rule-list > ::before,
.e-query-builder .e-rule-list > ::after {
    border-color: #0d6efd;
    border-style: dashed;
}

.e-query-builder .e-rule-list > ::before {
    border-width: 0 0 2px 2px;
}

.e-query-builder .e-rule-list > ::after {
    border-width: 0 0 0 2px;
}

.e-query-builder .e-rule-list > :first-child::before,
.e-query-builder .e-rule-list > :last-child::after {
    display: none;
}
```

## Horizontal vs Vertical Mode Tweaks

The Query Builder switches between two layouts by toggling `.e-horizontal-mode` and `.e-vertical-mode` on each `.e-rule-container`. Use the modifier class to apply layout-specific spacing &mdash; for example a wider value column in horizontal mode and a right-aligned delete button in vertical mode.

```css
.e-query-builder .e-rule-container.e-horizontal-mode .e-rule-value {
    width: 240px;
}

.e-query-builder .e-rule-container.e-horizontal-mode .e-rule-value-delete {
    margin-left: 8px;
}

.e-query-builder .e-rule-container.e-vertical-mode .e-rule-value-delete {
    display: block;
    text-align: right;
    margin-top: 8px;
}

.e-query-builder .e-rule-container.e-vertical-mode .e-rule-delete {
    margin-bottom: 12px;
}
```