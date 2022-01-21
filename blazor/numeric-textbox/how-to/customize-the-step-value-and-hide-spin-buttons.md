---
layout: post
title: Customize spin buttons in Blazor NumericTextBox Component | Syncfusion
description: Learn here all about how to customize the step value and hide spin buttons in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Customize step value and hide spin buttons in Blazor NumericTextBox

The spin buttons allows to increase or decrease the value with the predefined [Step](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_Step) value. The visibility of spin buttons can be set using the [ShowSpinButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_ShowSpinButton) property.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" Value=10 Min=10 Max=100 Step=2 ShowSpinButton=false></SfNumericTextBox>
```

![Hiding Spin Button in Blazor NumericTextBox](../images/blazor-numerictextbox-hide-spin-button.png)