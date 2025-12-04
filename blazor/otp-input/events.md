---
layout: post
title: Events in Blazor OTP Input Component | Syncfusion
description: Checkout and learn here all about Events with Syncfusion Blazor OTP Input component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: OTP Input
documentation: ug
---

# Events in Blazor OTP Input component

This section describes the OTP Input events triggered by user interaction and component lifecycle. The following events are available in the OTP Input component.

## Created

The OTP Input component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Created) event when component rendering is completed.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput Created="Created"></SfOtpInput>

@code{
    public void Created()
    {
        // Here, you can customize your code.
    }
}

```

## OnFocus

The OTP Input component triggers the [OnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_OnFocus) event when an OTP input field receives focus. The [OtpFocusInEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html) event argument provides details about the focus-in action, such as the focused input.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput OnFocus="OnFocus"></SfOtpInput>

@code{
    public void OnFocus(OtpFocusInEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnBlur

The OTP Input component triggers the [OnBlur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_OnBlur) event when focus leaves an OTP input field or the component. The [OtpFocusOutEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusOutEventArgs.html) event argument provides details about the blur action, such as the input that lost focus.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput OnBlur="OnBlur"></SfOtpInput>

@code{
    public void OnBlur(OtpFocusOutEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```

## OnInput

The OTP Input component triggers the [OnInput](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_OnInput) event when the value of an individual OTP input field changes. The [OtpInputEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputEventArgs.html) event argument provides details about the change, such as the input index and the current value.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfOtpInput OnInput="OnInput"></SfOtpInput>

@code{
    public void OnInput(OtpInputEventArgs args)
    {
        // Here, you can customize your code.
    }
}

```