---
layout: post
title: Selection and Nesting in Blazor ButtonGroup Component | Syncfusion
description: Checkout and learn here all about Selection and Nesting in Syncfusion Blazor ButtonGroup component and more.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Selection and Nesting in Blazor ButtonGroup Component

## Single selection

ButtonGroup supports single selection type in which only one button can be selected.

The following example illustrates the single selection behavior in ButtonGroup.

```cshtml

@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup Mode="Syncfusion.Blazor.SplitButtons.SelectionMode.Single">
    <ButtonGroupButton>Left</ButtonGroupButton>
    <ButtonGroupButton @bind-Selected="@centerSelected">Center</ButtonGroupButton>
    <ButtonGroupButton>Right</ButtonGroupButton>
</SfButtonGroup>

@code {
    private bool centerSelected = true;
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLUirhrCPItMWBe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ButtonGroup with Single Selection](./images/blazor-buttongroup-single-selection.png)

## Multiple selection

ButtonGroup supports multiple selection type in which multiple button can be selected.

The following example illustrates the multiple selection behavior in ButtonGroup.

```cshtml
@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup Mode="Syncfusion.Blazor.SplitButtons.SelectionMode.Multiple">
    <ButtonGroupButton @bind-Selected="@boldSelected" IconCss="bg-icons e-btngrp-bold">Bold</ButtonGroupButton>
    <ButtonGroupButton @bind-Selected="@italicSelected" IconCss="bg-icons e-btngrp-italic e-icon-left">Italic</ButtonGroupButton>
    <ButtonGroupButton IconCss="bg-icons e-btngrp-underline e-icon-left">Underline</ButtonGroupButton>
</SfButtonGroup>

@code {
    private bool boldSelected = true;
    private bool italicSelected = true;
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hthgiLrLWbohwhqS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ButtonGroup with Multiple Selection](./images/blazor-buttongroup-multiple-selection.png)

## Nesting

Nesting with other components can be possible in ButtonGroup. The following components can be nested in ButtonGroup.
* DropDownButton
* SplitButton

### DropDownButton

In the following example, the DropDownButton component can be added in ButtonGroup tag.

```cshtml
@using Syncfusion.Blazor.SplitButtons

  <SfButtonGroup>
    <ButtonGroupButton CssClass="e-btn e-success">View</ButtonGroupButton>
    <ButtonGroupButton CssClass="e-btn e-success">Edit</ButtonGroupButton>
        <SfDropDownButton Content="Profile">
            <DropDownMenuItems>
                <DropDownMenuItem Text="Dashboard"></DropDownMenuItem>
                <DropDownMenuItem Text="Notifications"></DropDownMenuItem>
                <DropDownMenuItem Text="User Settings"></DropDownMenuItem>
                <DropDownMenuItem Text="Log Out"></DropDownMenuItem>
            </DropDownMenuItems>
        </SfDropDownButton>
</SfButtonGroup>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtrUsLVrClyyBbnb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ButtonGroup with DropDown Button](./images/blazor-buttongroup-with-dropdown.png)

### SplitButton

In the following example, SplitButton component can be added in ButtonGroup tag.

```cshtml
@using Syncfusion.Blazor.SplitButtons

  <SfButtonGroup>
    <ButtonGroupButton CssClass="e-btn e-success">View</ButtonGroupButton>
    <ButtonGroupButton CssClass="e-btn e-success">Edit</ButtonGroupButton>
        <SfSplitButton Content="Paste">
            <DropDownMenuItems>
                <DropDownMenuItem Text="Paste"></DropDownMenuItem>
                <DropDownMenuItem Text="Paste Special"></DropDownMenuItem>
                <DropDownMenuItem Text="Paste as Formula"></DropDownMenuItem>
                <DropDownMenuItem Text="Paste as Hyperlink"></DropDownMenuItem>
            </DropDownMenuItems>
        </SfSplitButton>
</SfButtonGroup>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBgMhVLilSvoAeu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ButtonGroup with SplitButton](./images/blazor-buttongroup-with-splitbutton.png)