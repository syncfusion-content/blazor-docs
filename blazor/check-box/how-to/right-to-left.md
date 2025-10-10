---
layout: post
title: Right-To-Left in Blazor CheckBox Component | Syncfusion
description: Checkout and learn here all about Right-To-Left in Syncfusion Blazor CheckBox component and much more.
platform: Blazor
control: CheckBox
documentation: ug
---

# Right-To-Left in Blazor CheckBox Component

The CheckBox component supports right-to-left (RTL) layouts, which reverse content flow and align the checkbox and label for languages such as Arabic, Hebrew, and Persian. Enable RTL by setting [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html) to `true` on the SfCheckBox component. EnableRtl applies at the component level and can override page-level direction. RTL can also be enabled globally by setting dir="rtl" on a container or the html element. For more information, see the CheckBox overview (https://blazor.syncfusion.com/documentation/checkbox/) and the SfCheckBox API (https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox.html).

The following example illustrates how to enable right-to-left support in CheckBox component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox Label="Default" @bind-Checked="isChecked" EnableRtl="true"></SfCheckBox>

@code {
    private bool isChecked = true;
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htVgiLhmVyZvKJzz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor CheckBox with right-to-left (RTL) layout enabled](./../images/blazor-checkbox-right-to-left.png)