---
layout: post
title: Input Types in Blazor OTP Input Component | Syncfusion®
description: Learn about input types in Blazor OTP Input component including Number, Text, and Password types with examples.
platform: Blazor
control: OTP Input
documentation: ug
---

# Input Types in Blazor OTP Input component

## Types

This section explains the available types of the OTP (one-time password) input component, their default behaviors, and appropriate use cases.

### Number type

Set the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Type) property to [Number](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputType.html#Syncfusion_Blazor_Inputs_OtpInputType_Number) to accept only numeric characters. This is ideal for OTP scenarios with digit-only codes. The default `Type` is `Number`.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Value="1234" Type="OtpInputType.Number"></SfOtpInput>

```

![Blazor OTP input component with number type](images/blazor-otp-number.webp)

### Text type

Set the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Type) property to [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputType.html#Syncfusion_Blazor_Inputs_OtpInputType_Text) to allow alphanumeric input. Use this when the OTP may include both letters and numbers.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Value="e3c7" Type="OtpInputType.Text"></SfOtpInput>

```

![Blazor OTP input component with text type](images/blazor-otp-text.webp)

### Password type

Set the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Type) property to [Password](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputType.html#Syncfusion_Blazor_Inputs_OtpInputType_Password) to mask entered characters for privacy while typing. The characters in the input fields are displayed as masked values, while the actual value retrieved from the component remains the unmasked text.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Value="e3c7" Type="OtpInputType.Password"></SfOtpInput>

```

![Blazor OTP input component with password type](images/blazor-otp-password.webp)

## Value

Specify the initial OTP value by using the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Value) property. The component accepts a string whose length should not exceed the configured [Length](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Length); extra characters beyond the length are ignored.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Value="1234"></SfOtpInput>

```

![Blazor OTP input component with value](images/blazor-otp-number.webp)

## See also

* [Appearance in Blazor OTP Input](appearance)
* [Styling modes in Blazor OTP Input](styling-modes)
* [Events in Blazor OTP Input](events)
* [Placeholder in Blazor OTP Input](placeholder)