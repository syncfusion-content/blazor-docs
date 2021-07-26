---
layout: post
title: How to Right To Left in Blazor Radio Button Component | Syncfusion
description: Checkout and learn about Right To Left in Blazor Radio Button component of Syncfusion, and more details.
platform: Blazor
control: Radio Button
documentation: ug
---

# Right-To-Left

Radio Button component has RTL support. This can be achieved by setting [`EnableRtl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfRadioButton-1.html) as `true`.

The following example illustrates how to enable right-to-left support in Radio Button component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Default" EnableRtl="true" Value="Default" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked = "Default";
}

```

Output be like

![Radio Button Sample](./../images/rb-rtl.png)