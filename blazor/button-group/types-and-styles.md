---
layout: post
title: Types and Styles in Blazor ButtonGroup Component | Syncfusion®
description: Checkout and learn here all features about Types and Styles in Blazor ButtonGroup component and more.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Types and Styles in Blazor Button Group Component

This section explains the different types and styles available for the Button Group component.

## ButtonGroup styles

The Blazor ButtonGroup has the following predefined styles that can be defined using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ButtonGroupButton.html#Syncfusion_Blazor_SplitButtons_ButtonGroupButton_CssClass) property.

| Class | Description |
| -------- | -------- |
| e-primary | Used to represent a primary action. |
| e-success | Used to represent a positive action. |
| e-info |  Used to represent an informative action. |
| e-warning | Used to represent an action with caution. |
| e-danger | Used to represent a negative action. |
| e-link |  Changes the appearance of the Button like a hyperlink. |

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup>
    <ButtonGroupButton CssClass="e-primary">View</ButtonGroupButton>
    <ButtonGroupButton CssClass="e-success">Edit</ButtonGroupButton>
    <ButtonGroupButton CssClass="e-info">Delete</ButtonGroupButton>
</SfButtonGroup>
 <SfButtonGroup>
    <ButtonGroupButton CssClass="e-link">View</ButtonGroupButton>
    <ButtonGroupButton CssClass="e-warning">Edit</ButtonGroupButton>
    <ButtonGroupButton CssClass="e-danger">Delete</ButtonGroupButton>
</SfButtonGroup>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrHNdiBhdsGvJpD?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor ButtonGroup with different Style](./images/blazor-buttongroup-style.webp)" %}

N> Predefined ButtonGroup styles provide only the visual indication. So, ButtonGroup content should define the ButtonGroup style for the users of assistive technologies such as screen readers.

## ButtonGroup types

The types of Blazor ButtonGroup are as follows:

* Flat ButtonGroup
* Outline ButtonGroup
* Round ButtonGroup
* Toggle ButtonGroup

### Flat ButtonGroup

The Flat Button Group is styled with no background color. To create a flat Button Group, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-flat`.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup CssClass="e-flat">
    <ButtonGroupButton>View</ButtonGroupButton>
    <ButtonGroupButton>Edit</ButtonGroupButton>
    <ButtonGroupButton>Delete</ButtonGroupButton>
</SfButtonGroup>
```

### Outline ButtonGroup

An outline Button Group has a border with a transparent background. To create an outline Button Group, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-outline`.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup CssClass="e-outline">
    <ButtonGroupButton>View</ButtonGroupButton>
    <ButtonGroupButton>Edit</ButtonGroupButton>
    <ButtonGroupButton>Delete</ButtonGroupButton>
</SfButtonGroup>
```

### Round ButtonGroup

A round Button Group is styled with rounded corners. It is commonly used to contain an icon that represents its action. To create a round Button Group, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-round-corner`.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup CssClass="e-round-corner">
    <ButtonGroupButton>View</ButtonGroupButton>
    <ButtonGroupButton>Edit</ButtonGroupButton>
    <ButtonGroupButton>Delete</ButtonGroupButton>
</SfButtonGroup>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhxXHihrnVqqrwi?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Displaying different Type of ButtonGroup Component](./images/blazor-buttongroup-type.webp)" %}

## Icons

### ButtonGroup with font icons

Use the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ButtonGroupButton.html#Syncfusion_Blazor_SplitButtons_ButtonGroupButton_IconCss) property to add an icon to a button. Customize the icon position by using the [IconPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ButtonGroupButton.html#Syncfusion_Blazor_SplitButtons_ButtonGroupButton_IconPosition) property. The available values are `IconPosition.Left` (default) and `IconPosition.Right`.

```cshtml
@using Syncfusion.Blazor.SplitButtons
@using Syncfusion.Blazor.Buttons

<SfButtonGroup Mode="SelectionMode.Single">
    <ButtonGroupButton IconCss="e-icons e-play-icon" IconPosition="IconPosition.Right">PLAY</ButtonGroupButton>
    <ButtonGroupButton IconCss="e-icons e-pause-icon">PAUSE</ButtonGroupButton>
    <ButtonGroupButton>Delete</ButtonGroupButton>
</SfButtonGroup>

<style>
    .e-play-icon::before {
        content: '\e70c';
    }
    .e-pause-icon::before {
        content: '\e77b';
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVRNxiFhfBAtUDm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor ButtonGroup with Icon](./images/blazor-buttongroup-icon.webp)" %}

## ButtonGroup size

The Button Group supports the following size options, applied using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property:

| Size | CSS Class | Description |
| --- | --- | --- |
| Default | _(none)_ | Renders the standard-sized Button Group. |
| Small | `e-small` | Renders a smaller-sized Button Group. |

The following example shows the default and small Button Group rendered side by side.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup CssClass="e-small">
    <ButtonGroupButton>View</ButtonGroupButton>
    <ButtonGroupButton>Edit</ButtonGroupButton>
    <ButtonGroupButton>Delete</ButtonGroupButton>
</SfButtonGroup>
 <SfButtonGroup>
    <ButtonGroupButton>View</ButtonGroupButton>
    <ButtonGroupButton>Edit</ButtonGroupButton>
    <ButtonGroupButton>Delete</ButtonGroupButton>
</SfButtonGroup>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhHXdsVVHJjdneu?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor ButtonGroup Size](./images/blazor-buttongroup-size.webp)" %}

## See also

* [Getting Started with Blazor Button Group](getting-started.md)
* [Selection and Nesting in Blazor Button Group](selection-and-nesting.md)
* [Styles and Appearances in Blazor Button Group](style-and-appearance.md)
* [Native Events in Blazor Button Group](native-event.md)
* [Accessibility in Blazor Button Group](accessibility.md)