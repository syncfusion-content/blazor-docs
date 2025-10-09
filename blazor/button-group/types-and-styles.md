---
layout: post
title: Types and Styles in Blazor ButtonGroup Component | Syncfusion
description: Check out and learn all about types and styles in the Syncfusion Blazor ButtonGroup component and more.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Types and Styles in Blazor ButtonGroup Component

This section explains the different types and styles available for the ButtonGroup.

## ButtonGroup styles

The Blazor ButtonGroup provides the following predefined styles, which can be applied using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ButtonGroupButton.html#Syncfusion_Blazor_SplitButtons_ButtonGroupButton_CssClass) property.

| Class | Description |
| -------- | -------- |
| e-primary | Represents a primary action. |
| e-success | Represents a positive or successful action. |
| e-info | Represents an informative action. |
| e-warning | Represents an action that requires caution. |
| e-danger | Represents a negative or destructive action. |
| e-link | Changes the appearance of the button to resemble a hyperlink. |

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrUWrVhsFgtTPNP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ButtonGroup with different styles](./images/blazor-buttongroup-style.png)

N> Predefined ButtonGroup styles provide only visual indication. Ensure that the ButtonGroup content conveys meaning for users of assistive technologies such as screen readers.

## ButtonGroup types

The types of Blazor ButtonGroup are as follows:

* Flat ButtonGroup
* Outline ButtonGroup
* Round ButtonGroup
* Toggle ButtonGroup

### Flat ButtonGroup

The Flat ButtonGroup is styled without a background color. To create a flat ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-flat`.

### Outline ButtonGroup

An outline ButtonGroup has a border with a transparent background. To create an outline ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-outline`.

### Round ButtonGroup

A round ButtonGroup applies rounded corners for a pill-shaped appearance. To create a round ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-round-corner`.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hthKWBVBCPUzgjog?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Displaying different types of ButtonGroup component](./images/blazor-buttongroup-type.png)

## Icons

### ButtonGroup with font icons

To create a ButtonGroup with icons, use the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ButtonGroupButton.html#Syncfusion_Blazor_SplitButtons_ButtonGroupButton_IconCss) property of the button component. Customize the icon position using the [IconPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ButtonGroupButton.html#Syncfusion_Blazor_SplitButtons_ButtonGroupButton_IconPosition) property.

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
        content: '\e324';
    }
    .e-pause-icon::before {
        content: '\e326';
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjByDhrHzXmJmyeK?appbar=true&editor=true&result=true&errorlist=true&theme=material" %}


![Blazor ButtonGroup with icons](./images/blazor-buttongroup-icon.png)

## ButtonGroup size

ButtonGroup supports two sizes: default and small. To change the default size to small, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-small`.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrgirVBMPpAJRYg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


![Changing Blazor ButtonGroup size](./images/blazor-buttongroup-size.png)