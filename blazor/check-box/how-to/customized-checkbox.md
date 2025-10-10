---
layout: post
title: Customized CheckBox in Blazor CheckBox Component | Syncfusion
description: Checkout and learn here all about Customized Checkbox in Syncfusion Blazor CheckBox component and more.
platform: Blazor
control: CheckBox
documentation: ug
---

# Customized Checkbox in Blazor CheckBox Component

This topic explains multiple ways to customize the Blazor CheckBox appearance using CSS, including applying theme utility classes through the CssClass parameter, resizing the checkbox, customizing the frame shape, and changing the check icon. For an overview of the component, see CheckBox documentation (https://blazor.syncfusion.com/documentation/checkbox/). For API details, see SfCheckBox API (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox.html).

## Customize checkbox appearance

You can customize the appearance of the CheckBox component using CSS rules. Define custom CSS rules based on the requirement and assign the class name using the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html) property.

The background and border colors of the CheckBox can be adjusted using utility classes to create primary, success, info, warning, and danger styles (for example, e-primary, e-success, e-info, e-warning, and e-danger). These classes style the CheckBox wrapper and reflect hover and focus states.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox @bind-Checked="isPrimaryChecked" Label="Primary" CssClass="e-primary"></SfCheckBox><br />
<SfCheckBox @bind-Checked="isSuccessChecked" Label="Success" CssClass="e-success"></SfCheckBox><br />
<SfCheckBox @bind-Checked="isInfoChecked" Label="Info" CssClass="e-info"></SfCheckBox><br />
<SfCheckBox @bind-Checked="isWarningChecked" Label="Warning" CssClass="e-warning"></SfCheckBox><br />
<SfCheckBox @bind-Checked="isDangerChecked" Label="Danger" CssClass="e-danger"></SfCheckBox>

@code {
    private bool isPrimaryChecked = true;
    private bool isSuccessChecked = true;
    private bool isInfoChecked = true;
    private bool isWarningChecked = true;
    private bool isDangerChecked = true;
}

<style>
    .e-checkbox-wrapper.e-primary:hover .e-frame.e-check { /* csslint allow: adjoining-classes */
        background-color: #e03872;
    }

    .e-checkbox-wrapper.e-success .e-frame.e-check,
    .e-checkbox-wrapper.e-success .e-checkbox:focus + .e-frame.e-check { /* csslint allow: adjoining-classes */
        background-color: #689f38;
    }

    .e-checkbox-wrapper.e-success:hover .e-frame.e-check { /* csslint allow: adjoining-classes */
        background-color: #449d44;
    }

    .e-checkbox-wrapper.e-info .e-frame.e-check,
    .e-checkbox-wrapper.e-info .e-checkbox:focus + .e-frame.e-check { /* csslint allow: adjoining-classes */
        background-color: #2196f3;
    }

    .e-checkbox-wrapper.e-info:hover .e-frame.e-check { /* csslint allow: adjoining-classes */
         background-color: #0b7dda;
    }

    .e-checkbox-wrapper.e-warning .e-frame.e-check,
    .e-checkbox-wrapper.e-warning .e-checkbox:focus + .e-frame.e-check { /* csslint allow: adjoining-classes */
        background-color: #ef6c00;
    }

    .e-checkbox-wrapper.e-warning:hover .e-frame.e-check { /* csslint allow: adjoining-classes */
        background-color: #cc5c00;
    }

    .e-checkbox-wrapper.e-danger .e-frame.e-check,
    .e-checkbox-wrapper.e-danger .e-checkbox:focus + .e-frame.e-check { /* csslint allow: adjoining-classes */
        background-color: #d84315;
    }

    .e-checkbox-wrapper.e-danger:hover .e-frame.e-check { /* csslint allow: adjoining-classes */
        background-color: #ba3912;
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVKshBQrJbnEQzO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customize Blazor CheckBox appearance with theme utility classes](./../images/blazor-checkbox-appearance-customization.png)

## Customize width and height

The height and width of the CheckBox component can be customized by applying CSS rules to the CheckBox wrapper and its inner elements.

The following section explains how to increase the CheckBox size using a custom CSS class. The styles update the .e-frame box, the check icon size, the ripple container for proper interaction effects, and the label line-height for vertical alignment.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox CssClass="e-customsize" Label="Default" @bind-Checked="isChecked"></SfCheckBox>

@code {
    private bool isChecked = true;
}

<style>
        .e-customsize.e-checkbox-wrapper .e-frame {
            height: 30px;
            width: 30px;
            padding: 8px 0;
        }

        .e-customsize.e-checkbox-wrapper .e-check {
            font-size: 20px;
        }

        .e-customsize.e-checkbox-wrapper .e-ripple-container {
            height: 52px;
            top: -11px;
            width: 47px;
        }

        .e-customsize.e-checkbox-wrapper .e-label {
            line-height: 30px;
            font-size: 20px;
        }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtrUWLLGVTFECslm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customize Blazor CheckBox height and width with CSS](./../images/blazor-checkbox-height-width-customization.png)

## Custom frame

Checkbox frame can be customized based on the requirement by adding CSS rules.

In the following example, a to-do list uses a round CheckBox by setting border-radius to 100% via the e-custom class applied through CssClass.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox Label="Buy Groceries" @bind-Checked="isChecked" CssClass="e-custom"></SfCheckBox><br />
<SfCheckBox Label="Pay Rent" @bind-Checked="isRentChecked" CssClass="e-custom"></SfCheckBox><br />
<SfCheckBox Label="Make Dinner" @bind-Checked="isDinnerChecked" CssClass="e-custom"></SfCheckBox><br />
<SfCheckBox Label="Finish To-do List Article" @bind-Checked="isArticleChecked" CssClass="e-custom"></SfCheckBox>

@code {
    private bool isChecked = true;
    private bool isRentChecked = true;
    private bool isDinnerChecked = false;
    private bool isArticleChecked = false;
}

<style>
        .e-custom .e-frame {
            border-radius: 100%;
        }

        .e-checkicon.e-checkbox-wrapper .e-frame.e-check::before {
            content: '\e77d';
        }

        .e-checkicon.e-checkbox-wrapper .e-check {
            font-size: 8.5px;
        }

        .e-checkicon.e-checkbox-wrapper .e-frame.e-check {
            background-color: white;
            border-color: grey;
            color: grey;
        }

        .e-checkicon.e-checkbox-wrapper:hover .e-frame.e-check {
            background-color: white;
            border-color: grey;
            color: grey;
        }

        .e-checkicon.e-checkbox-wrapper .e-checkbox:focus + .e-frame.e-check {
            background-color: white;
            border-color: grey;
            box-shadow: none;
            color: grey;
        }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrgirhGhJYCyqDJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customize Blazor CheckBox frame to rounded shape](./../images/blazor-checkbox-frame-customization.png)

## Custom check icon

Checkbox check icon can be customized by adding CSS rules.

In the following example, the check icon glyph, background, and border colors are customized for default, hover, and focus states by applying the e-checkicon class through CssClass.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox Label="Buy Groceries" @bind-Checked="isChecked" CssClass="e-checkicon"></SfCheckBox><br />
<SfCheckBox Label="Pay Rent"  @bind-Checked="isRentChecked" CssClass="e-checkicon"></SfCheckBox><br />
<SfCheckBox Label="Make Dinner" @bind-Checked="isDinnerChecked" CssClass="e-checkicon"></SfCheckBox><br />
<SfCheckBox Label="Finish To-do List Article" @bind-Checked="isArticleChecked" CssClass="e-checkicon"></SfCheckBox>

@code {
    private bool isChecked = true;
    private bool isRentChecked = true;
    private bool isDinnerChecked = true;
    private bool isArticleChecked = false;
}

<style>
    .e-checkicon.e-checkbox-wrapper .e-frame.e-check::before {
        content: '\e682';
    }
    .e-checkicon.e-checkbox-wrapper .e-check {
        font-size: 12px;
    }
    .e-checkicon.e-checkbox-wrapper .e-frame.e-check,
    .e-checkicon.e-checkbox-wrapper:hover .e-frame.e-check {
        background-color: white;
        border-color: grey;
        color: grey;
    }
    .e-checkicon.e-checkbox-wrapper .e-checkbox:focus + .e-frame.e-check {
        background-color: white;
        border-color: grey;
        box-shadow: none;
        color: grey;
    }
    .e-checkicon.e-checkbox-wrapper .e-ripple-element {
        background: grey;
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBgWrLGrpkSQSUL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customize Blazor CheckBox check icon styles](./../images/blazor-checkbox-check-icon-customization.png)