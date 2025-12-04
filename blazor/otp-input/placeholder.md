---
layout: post
title: Placeholder in Blazor OTP Input Component | Syncfusion
description: Checkout and learn here all about Placeholder with Syncfusion Blazor OTP Input component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: OTP Input
documentation: ug
---

# Placeholder in Blazor OTP Input component

The placeholder in OTP Input specifies the text that is shown as a hint or placeholder until the user enters a value in the input field. It acts as a guidance for the users regarding the expected input format or purpose of the input field.

Set the placeholder text by using the [Placeholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Placeholder) property. When a single character is provided, all input fields display the same character.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Placeholder="x"></SfOtpInput>

```

![Blazor OTP Input Component with Placeholder](images/blazor-otp-char.png)

When a placeholder string with multiple characters is provided, characters are assigned to input fields from left to right up to the configured OTP length. If the placeholder string contains more characters than the OTP length, extra characters are ignored; if it contains fewer, only those positions display placeholder characters.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Placeholder="wxyz"></SfOtpInput>

```

![Blazor OTP input component with placeholder as string](images/blazor-otp-string.png)