---
layout: post
title: How to Customize The Step Value And Hide Spin Buttons in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn about Customize The Step Value And Hide Spin Buttons in Blazor Numeric TextBox component of Syncfusion, and more details.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Customize the step value and hide spin buttons

The spin buttons allows you to increase or decrease the value with the predefined [Step](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_Step)
value. The visibility of spin buttons can be set using the [ShowSpinButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html#Syncfusion_Blazor_Inputs_SfNumericTextBox_1_ShowSpinButton) property.

```csharp
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" Value=10 Min=10 Max=100 Step=2 ShowSpinButton=false></SfNumericTextBox>
```

The output will be as follows.

![NumericTextBox Sample](../images/icon_disable.png)
