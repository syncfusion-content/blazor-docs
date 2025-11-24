---
layout: post
title: Label and Size in Blazor CheckBox Component | Syncfusion
description: Checkout and learn here all about Label and Size in Syncfusion Blazor CheckBox component and much more.
platform: Blazor
control: Checkbox
documentation: ug
---

# Label and Size in Blazor CheckBox Component

This section explains the different sizes and labels.

## Label

The [Blazor Checkbox](https://www.syncfusion.com/blazor-components/blazor-checkbox) caption can be defined by using the [Label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html#Syncfusion_Blazor_Buttons_SfCheckBox_1_Label) property. This reduces the manual addition of label for Checkbox. You can customize the label position before or after the Checkbox through the [LabelPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html#Syncfusion_Blazor_Buttons_SfCheckBox_1_LabelPosition) property.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox Label="Left Side Label" LabelPosition="LabelPosition.Before" @bind-Checked="isLeftChecked"></SfCheckBox><br />
<SfCheckBox Label="Right Side Label" LabelPosition="LabelPosition.After" @bind-Checked="isRightChecked"></SfCheckBox>

@code {
    private bool isLeftChecked = true;
    private bool isRightChecked = true;
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLgMVBmLTwBGRID?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor CheckBox with Label](./images/blazor-checkbox-label.png)" %}

## Size

The different Checkbox sizes available are default and small. To reduce the size of default Checkbox to small, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html) property to `e-small`.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox @bind-Checked="isSmallChecked" Label="Small" CssClass="e-small"></SfCheckBox><br />
<SfCheckBox @bind-Checked="isDefaultChecked" Label="Default"></SfCheckBox>

@code {
    private bool isSmallChecked = true;
     private bool isDefaultChecked = true;
}

<style>
    .e-checkbox-wrapper {
        margin-top: 18px;
    }
</style>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLAiVVQVzGyDwWz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor CheckBox Size](./images/blazor-checkbox-size.png)" %}

## See also

* [Checkbox customization](./how-to/customized-checkbox)