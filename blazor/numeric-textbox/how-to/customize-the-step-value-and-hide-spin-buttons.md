---
layout: post
title: Customize spin buttons in Blazor NumericTextBox | Syncfusion®
description: Configure step increments and hide spin buttons in Blazor Numeric TextBox using Step and ShowSpinButton.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Customize step value and hide spin buttons in Blazor NumericTextBox

Spin buttons allow increasing or decreasing the value with the predefined [Step](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_Step) value. The visibility of the spin buttons can be set using the [ShowSpinButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_ShowSpinButton) property. Use the [Decimals](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_Decimals) property to control the number of digits after the decimal point.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" Value=10 Min=10 Max=100 Step=2 ShowSpinButton=false></SfNumericTextBox>
```

![Hiding Spin Button in Blazor Numeric TextBox](../images/blazor-numerictextbox-hide-spin-button.webp)