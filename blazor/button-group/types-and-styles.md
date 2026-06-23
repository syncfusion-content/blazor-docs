---
layout: post
title: Types and Styles in Blazor ButtonGroup Component | Syncfusion®
description: Checkout and learn here all features about Types and Styles in Blazor ButtonGroup component and more.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Types and Styles in Blazor ButtonGroup Component

This section explains about different types and styles of ButtonGroup.

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

```csharp

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

### CSS Customization Classes

To modify the ButtonGroup appearance, you need to override the default CSS of the ButtonGroup component. Find the list of CSS classes and their corresponding section in ButtonGroup. You can also create your own custom theme for the controls using our [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
| --------- | ---------------- |
| `.e-btn` | To customize the ButtonGroup. |
| `.e-btn:hover` | To customize the ButtonGroup on hover. |
| `.e-btn:focus` | To customize the ButtonGroup on focus. |
| `.e-btn:active` | To customize the ButtonGroup on active. |

The following example demonstrates how to apply a custom styles using CSS classes for various properties like color, background color, font, border, padding, margin, and more:

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup>
    <ButtonGroupButton>Left</ButtonGroupButton>
    <ButtonGroupButton>Center</ButtonGroupButton>
    <ButtonGroupButton>Right</ButtonGroupButton>
</SfButtonGroup>

<style>
    .e-btn {
        /* Color properties */
        color: #ffffff;
        background-color: #007bff;
        border-color: #0056b3;

        /* Border properties */
        border-width: 2px;
        border-style: solid;
        border-radius: 6px;
        outline: none;

        /* Effects */
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.15);
        cursor: pointer;
        transition: all 0.3s ease;
        opacity: 1;
        overflow: hidden;
        z-index: 1;
    }

    /* Hover state styling */
    .e-btn:hover {
        color: #e0e0e0;
        background-color: #0056b3;
        border-color: #004494;
        box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
        transform: translateY(-2px);
        opacity: 0.95;
    }

    /* Focus state styling */
    .e-btn:focus {
        color: #ffffff;
        background-color: #004494;
        border-color: #003366;
        box-shadow: 0 0 0 4px rgba(0, 123, 255, 0.4);
        outline: 2px solid #007bff;
        outline-offset: 2px;
    }

    /* Active state styling */
    .e-btn:active {
        color: #ffffff;
        background-color: #003366;
        border-color: #002244;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.15);
        transform: translateY(0);
    }

</style>

```

## ButtonGroup types

The types of Blazor ButtonGroup are as follows:

* Flat ButtonGroup
* Outline ButtonGroup
* Round ButtonGroup

### Flat ButtonGroup

The Flat ButtonGroup is styled with no background color. To create a flat ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-flat`.

### Outline ButtonGroup

An outline ButtonGroup has a border with transparent background. To create an outline ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-outline`.

### Round ButtonGroup

A round ButtonGroup is shaped like a circle. Usually, it contains an icon representing its action. To create a round ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-round-corner`.

The following example demonstrates the types of Blazor ButtonGroup:

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup CssClass="e-flat">
    <ButtonGroupButton>View</ButtonGroupButton>
    <ButtonGroupButton>Edit</ButtonGroupButton>
    <ButtonGroupButton>Delete</ButtonGroupButton>
</SfButtonGroup>
<SfButtonGroup CssClass="e-outline">
    <ButtonGroupButton CssClass="e-outline">View</ButtonGroupButton>
    <ButtonGroupButton CssClass="e-outline">Edit</ButtonGroupButton>
    <ButtonGroupButton CssClass="e-outline">Delete</ButtonGroupButton>
</SfButtonGroup>
<SfButtonGroup CssClass="e-round-corner">
    <ButtonGroupButton>View</ButtonGroupButton>
    <ButtonGroupButton>Edit</ButtonGroupButton>
    <ButtonGroupButton>Delete</ButtonGroupButton>
</SfButtonGroup>

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhxXHihrnVqqrwi?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Displaying different Type of ButtonGroup Component](./images/blazor-buttongroup-type.webp)" %}

## Icons

### ButtonGroup with font icons

To create ButtonGroup with icons, [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ButtonGroupButton.html#Syncfusion_Blazor_SplitButtons_ButtonGroupButton_IconCss) property of the button component can be used. You can customize the icon's position by using the [IconPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ButtonGroupButton.html#Syncfusion_Blazor_SplitButtons_ButtonGroupButton_IconPosition) property.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVRNxiFhfBAtUDm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "Blazor ButtonGroup with Icon" %}

## ButtonGroup size

The two types of ButtonGroup sizes are default and small. To change the size of the default ButtonGroup to small ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-small`.

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