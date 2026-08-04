---
layout: post
title: Selection and Nesting in Blazor ButtonGroup Component | Syncfusion®
description: Checkout and learn here all features about Selection and Nesting in Blazor ButtonGroup component and more.
platform: Blazor
control: ButtonGroup
documentation: ug
---

# Selection and Nesting in Blazor Button Group Component

The Blazor Button Group component provides two-way binding support in both single and multiple selection modes through the [`Selected`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.ButtonGroupButton.html#Syncfusion_Blazor_SplitButtons_ButtonGroupButton_Selected) property of `ButtonGroupButton`. The `@bind-Selected` directive enables two-way data binding, allowing the state of each button (selected or not) to synchronize between the UI and the backing properties. To disable selection entirely, set `Mode="SelectionMode.None"` (the default).

## Pre-selecting buttons

One or more buttons can be pre-selected by initializing the bound property to `true` in the `@code` block. In single selection mode, only one button can be pre-selected; in multiple selection mode, multiple buttons can be pre-selected.

## Single selection

The Button Group supports a single selection type in which only one button can be selected at a time. The following example illustrates the single selection behavior in the Button Group.

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
    bool ThirdSelected { get; set; } = true; // pre-select the Third button
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrxXxMrBHIUsMVJ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor ButtonGroup with Single Selection](./images/blazor-buttongroup-single-selection.webp)" %}

## Multiple selection

The Button Group supports a multiple selection type in which multiple buttons can be selected at the same time. The following example illustrates the multiple selection behavior in the Button Group.

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
    bool ThirdSelected { get; set; } = true; // pre-select the Third button
}


```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrdXnMrrdnbElhh?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor ButtonGroup with Multiple Selection](./images/blazor-buttongroup-multiple-selection.webp)" %}

## Nesting

Other components can be nested inside a Button Group. The following components can be nested in a Button Group:
* [DropDownButton](https://blazor.syncfusion.com/documentation/drop-down-menu/getting-started-with-web-app)
* [SplitButton](https://blazor.syncfusion.com/documentation/split-button/getting-started)

To make the nested components visually match the surrounding buttons, the same `CssClass` (for example, `e-btn e-success`) should be applied to the nested component, as shown in the following examples.

### DropDownButton

In the following example, the `DropDownButton` component is added inside the `SfButtonGroup` tag.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDrnDxCLhHwqCfKF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor ButtonGroup with DropDown Button](./images/blazor-buttongroup-with-dropdown.webp)" %}

### SplitButton

In the following example, the `SplitButton` component is added inside the `SfButtonGroup` tag.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLdXRiVLRwlWzov?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor ButtonGroup with SplitButton](./images/blazor-buttongroup-with-splitbutton.webp)" %}