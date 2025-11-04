---
layout: post
title: Events in Blazor OTP Input Component | Syncfusion
description: Checkout and learn here all about Events with Syncfusion Blazor OTP Input component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: OTP Input
documentation: ug
---

# Events in Blazor OTP Input component

This section describes the OTP Input events that will be triggered when appropriate actions are performed. The following events are available in the OTP Input component.

## Created

The OTP Input component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Created) event when the component rendering is completed.

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

The OTP Input component triggers the [OnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_OnFocus) event when the OTP Input is focused. The [OtpFocusInEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html) passed as an event argument provides the details of the focus event.

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

The OTP Input component triggers the [OnBlur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_OnBlur) event when the OTP Input is focused out. The [OtpFocusOutEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusOutEventArgs.html) passed as an event argument provides the details of the blur event.

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

The OTP Input component triggers the [OnInput](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_OnInput) event when the value of each OTP Input is changed. The [OtpInputEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputEventArgs.html) passed as an event argument provides the details of the each value is changed.

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
