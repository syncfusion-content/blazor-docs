---
layout: post
title: Types and Styles in Blazor ButtonGroup Component | Syncfusion
description: Checkout and learn here all about Types and Styles in Syncfusion Blazor ButtonGroup component and more.
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrUWrVhsFgtTPNP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ButtonGroup with different Style](./images/blazor-buttongroup-style.png)

N> Predefined ButtonGroup styles provide only the visual indication. So, ButtonGroup content should define the ButtonGroup style for the users of assistive technologies such as screen readers.

## ButtonGroup types

The types of Blazor ButtonGroup are as follows:

* Flat ButtonGroup
* Outline ButtonGroup
* Round ButtonGroup
* Toggle ButtonGroup

### Flat ButtonGroup

The Flat ButtonGroup is styled with no background color. To create a flat ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-flat`.

### Outline ButtonGroup

An outline ButtonGroup has a border with transparent background. To create an outline ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-outline`.

### Round ButtonGroup

A round ButtonGroup is shaped like a circle. Usually, it contains an icon representing its action. To create a round ButtonGroup, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfButtonGroup.html#Syncfusion_Blazor_SplitButtons_SfButtonGroup_CssClass) property to `e-round-corner`.

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

![Displaying different Type of ButtonGroup Component](./images/blazor-buttongroup-type.png)

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
        content: '\e324';
    }
    .e-pause-icon::before {
        content: '\e326';
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjByDhrHzXmJmyeK?appbar=true&editor=true&result=true&errorlist=true&theme=material" %}


![Blazor ButtonGroup with Icon](./images/blazor-buttongroup-icon.png)

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrgirVBMPpAJRYg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


![Changing Blazor ButtonGroup Size](./images/blazor-buttongroup-size.png)