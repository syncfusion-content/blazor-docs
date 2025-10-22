---
layout: post
title: Selection and Nesting in Blazor ButtonGroup Component | Syncfusion
description: Checkout and learn here all about Selection and Nesting in Syncfusion Blazor ButtonGroup component and more.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Selection and Nesting in Blazor ButtonGroup Component

The Blazor ButtonGroup component supports two-way binding in both single and multiple selection modes through the `Selected` property of each `ButtonGroupButton`. The `@bind-Selected` directive enables two-way data binding, allowing the selected state of each button to stay synchronized between the UI and backing properties.

## Single selection

ButtonGroup supports a single selection mode in which only one button can be selected at a time.

The following example illustrates the single selection behavior in ButtonGroup.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup Mode="Syncfusion.Blazor.SplitButtons.SelectionMode.Single">
    <ButtonGroupButton @bind-Selected="@FirstSelected">First</ButtonGroupButton>
    <ButtonGroupButton @bind-Selected="@SecondSelected">Second</ButtonGroupButton>
    <ButtonGroupButton @bind-Selected="@ThirdSelected">Third</ButtonGroupButton>
</SfButtonGroup>
@if (FirstSelected)
{
    <div class="alert alert-info">First button is selected</div>
}
@if (SecondSelected)
{
    <div class="text-danger">Second button is selected</div>
}
@if (ThirdSelected)
{
    <div class="alert alert-success">Third button is selected</div>
}
@code{
    bool FirstSelected { get; set; }
    bool SecondSelected { get; set; }
    bool ThirdSelected { get; set; } = true; // you can pre-select buttons
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBzsDVOTbttngcl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ButtonGroup with Single Selection](./images/blazor-buttongroup-single-selection.png)

## Multiple selection

ButtonGroup supports a multiple selection mode in which multiple buttons can be selected.

The following example illustrates the multiple selection behavior in ButtonGroup.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.SplitButtons

<SfButtonGroup Mode="Syncfusion.Blazor.SplitButtons.SelectionMode.Multiple">
    <ButtonGroupButton @bind-Selected="@FirstSelected">First</ButtonGroupButton>
    <ButtonGroupButton @bind-Selected="@SecondSelected">Second</ButtonGroupButton>
    <ButtonGroupButton @bind-Selected="@ThirdSelected">Third</ButtonGroupButton>
</SfButtonGroup>
@if (FirstSelected)
{
    <div class="alert alert-info">First button is selected</div>
}
@if (SecondSelected)
{
    <div class="text-danger">Second button is selected</div>
}
@if (ThirdSelected)
{
    <div class="alert alert-success">Third button is selected</div>
}
@code{
    bool FirstSelected { get; set; }
    bool SecondSelected { get; set; }
    bool ThirdSelected { get; set; } = true; // you can pre-select buttons
}


```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLfitrYfutrvLMs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor ButtonGroup with Multiple Selection](./images/blazor-buttongroup-multiple-selection.png)

## Nesting

Nesting other components inside ButtonGroup is supported. The following components can be nested within ButtonGroup:
* DropDownButton
* SplitButton

### DropDownButton

In the following example, the `DropDownButton` component is added inside the ButtonGroup.

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

In the following example, the `SplitButton` component is added inside the ButtonGroup.

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