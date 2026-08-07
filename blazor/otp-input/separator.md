---
layout: post
title: Separator in Blazor OTP Input Component | Syncfusion®
description: Learn how to use separator in Blazor OTP Input component to visually distinguish adjacent input fields.
platform: Blazor
control: OTP Input
documentation: ug
---

# Separator in Blazor OTP Input component

The separator in the OTP input component is the character or string rendered between adjacent input fields to visually distinguish them. Configure the separator using the [Separator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Separator) property. The separator is display-only and is not included in the OTP value.

## Single character separator

A single character can be used as a separator to visually group input fields, for example `/`, `-`, or `|`.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Separator="/"></SfOtpInput>

```

![Blazor OTP Input Component with Separator](images/blazor-otp-separator.webp)

## Multi-character separator

A string of multiple characters can also be used as a separator. Since the [Separator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Separator) property accepts a `string`, you can use any combination of characters, such as symbols, arrows, or repeated characters.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Separator="••"></SfOtpInput>

```

![Blazor OTP Input Component with Multi-Character Separator](images/blazor-otp-separator-multi.webp)

## See also

* [Appearance in Blazor OTP Input](appearance)
* [Input types in Blazor OTP Input](input-types)
* [Events in Blazor OTP Input](events)
