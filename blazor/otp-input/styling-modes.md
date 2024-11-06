---
layout: post
title: Styling Modes in Blazor OTP Input Component | Syncfusion
description: Checkout and learn here all about Styling Modes with Syncfusion Blazor OTP Input component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: OTP Input
documentation: ug
---

# Styling Modes in Blazor OTP Input component

Styling modes specify the style variants for the input fields in the OTP Input component. These modes allows you to customize the appearance of the OTP Input fields.

## Outline mode

You can use the outline style by setting the [StylingMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_StylingMode) property to [Outlined](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputStyle.html#Syncfusion_Blazor_Inputs_OtpInputStyle_Outlined). The default styling mode is `Outlined`.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput StylingMode="OtpInputStyle.Outlined"></SfOtpInput>

```

![Blazor OTP Input Component with Outline Mode](images/blazor-otp-outlined.png)

## Filled mode

You can use the filled style by setting the [StylingMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_StylingMode) property to [Filled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputStyle.html#Syncfusion_Blazor_Inputs_OtpInputStyle_Filled).

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput StylingMode="OtpInputStyle.Filled"></SfOtpInput>

```

![Blazor OTP Input Component with Filled Mode](images/blazor-otp-filled.png)

## Underline mode

You can use the underline style by setting the [StylingMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_StylingMode) property to [Underlined](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputStyle.html#Syncfusion_Blazor_Inputs_OtpInputStyle_Underlined).

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput StylingMode="OtpInputStyle.Underlined"></SfOtpInput>

```

![Blazor OTP Input Component with Underlined Mode](images/blazor-otp-underlined.png)
