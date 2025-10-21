---
layout: post
title: Input Types in Blazor OTP Input Component | Syncfusion
description: Checkout and learn here all about Input Types with Syncfusion Blazor OTP Input component in Blazor Server App and Blazor WebAssembly App.
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

![Blazor OTP input component with number type](images/blazor-otp-number.png)

### Text type

Set the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Type) property to [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputType.html#Syncfusion_Blazor_Inputs_OtpInputType_Text) to allow alphanumeric input. Use this when the OTP may include both letters and numbers.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Value="e3c7" Type="OtpInputType.Text"></SfOtpInput>

```

![Blazor OTP input component with text type](images/blazor-otp-text.png)

### Password type

Set the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Type) property to [Password](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputType.html#Syncfusion_Blazor_Inputs_OtpInputType_Password) to mask entered characters for privacy while typing. The underlying value remains the same; only the display is obscured.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Value="e3c7" Type="OtpInputType.Password"></SfOtpInput>

```

![Blazor OTP input component with password type](images/blazor-otp-password.png)

## Value

Specify the initial OTP value by using the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Value) property. 

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Value="1234"></SfOtpInput>

```

![Blazor OTP input component with value](images/blazor-otp-number.png)