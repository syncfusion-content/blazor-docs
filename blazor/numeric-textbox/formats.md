---
layout: post
title: Number Formats in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about number formats in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Number Formats in Blazor Numeric TextBox Component

You can format the value of NumericTextBox using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.NumericTextBoxModel-1.html#Syncfusion_Blazor_Inputs_NumericTextBoxModel_1_Format) property. The value will be displayed in the specified format when the component is in focused out state. The format string supports both the standard numeric format string and custom numeric format string.

## Standard formats

From the standard numeric format, you can use the numeric related format specifiers such as `n`,`p`, and `c` in the NumericTextBox component. By using these format specifiers, you can achieve the percentage and currency textbox behavior also.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox Value=0.5 Min=0 Max=1 Step=0.01 Format="p2" Placeholder="Percentage format" FloatLabelType="@FloatLabelType.Auto"></SfNumericTextBox>
<SfNumericTextBox TValue="int?" Value=10 Format="c2" Placeholder="Currency format" FloatLabelType="@FloatLabelType.Auto"></SfNumericTextBox>
```

![Blazor NumericTextBox with Standard Format](./images/blazor-numerictextbox-standard-format.png)

## Custom formats

From the custom numeric format string, you can provide any custom format by combining one or more custom specifiers.

The following examples demonstrate format the value by using currency format string `#` and `0`.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" Value=10 Format="###.##" Placeholder="Custom format string #" FloatLabelType="@FloatLabelType.Always"></SfNumericTextBox>
<SfNumericTextBox TValue="int?" Value=10 Format="000.00" Placeholder="Custom format string 0" FloatLabelType="@FloatLabelType.Always"></SfNumericTextBox>
```

![Blazor NumericTextBox with Custom Format](./images/blazor-numerictextbox-custom-format.png)