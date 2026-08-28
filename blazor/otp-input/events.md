---
layout: post
title: Events in Blazor OTP Input | Syncfusion
description: Handle Blazor OTP Input events such as Created, OnFocus, OnBlur, and OnInput during user interactions.
platform: Blazor
control: OTP Input
documentation: ug
---

# Events in Blazor OTP Input

This section describes the OTP Input events triggered by user interaction and component lifecycle. The following events are available in the OTP Input component.

## Created

The OTP Input component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_Created) event when component rendering is completed. Use this event to perform initialization tasks such as focusing the first input or loading related data.

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

The OTP Input component triggers the [OnFocus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_OnFocus) event when an OTP input field receives focus. The [OtpFocusInEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html) event argument provides details about the focus-in action, including the [Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html#Syncfusion_Blazor_Inputs_OtpFocusInEventArgs_Index) of the focused field, the [IsInteracted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html#Syncfusion_Blazor_Inputs_OtpFocusInEventArgs_IsInteracted) flag indicating whether the focus was triggered by direct user interaction, and the current complete [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html#Syncfusion_Blazor_Inputs_OtpFocusInEventArgs_Value) of the OTP input component.

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

The OTP Input component triggers the [OnBlur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_OnBlur) event when focus leaves an OTP input field or the component. The [OtpFocusOutEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusOutEventArgs.html) event argument provides details about the blur action. Since `OtpFocusOutEventArgs` inherits from [OtpFocusInEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html), it exposes the same properties: the [Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html#Syncfusion_Blazor_Inputs_OtpFocusInEventArgs_Index) of the field that lost focus, the [IsInteracted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html#Syncfusion_Blazor_Inputs_OtpFocusInEventArgs_IsInteracted) flag indicating whether the blur was triggered by direct user interaction, and the current complete [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpFocusInEventArgs.html#Syncfusion_Blazor_Inputs_OtpFocusInEventArgs_Value) of the OTP input component.

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

The OTP Input component triggers the [OnInput](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfOtpInput.html#Syncfusion_Blazor_Inputs_SfOtpInput_OnInput) event when the value of an individual OTP input field changes. The [OtpInputEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputEventArgs.html) event argument provides details about the change, including the [Index](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputEventArgs.html#Syncfusion_Blazor_Inputs_OtpInputEventArgs_Index) of the field that triggered the change, the [PreviousValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputEventArgs.html#Syncfusion_Blazor_Inputs_OtpInputEventArgs_PreviousValue) of the OTP input component before the change (or `null` if this is the first input), and the current complete [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.OtpInputEventArgs.html#Syncfusion_Blazor_Inputs_OtpInputEventArgs_Value) of the OTP input component after the change.

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

## See also

* [Input types in Blazor OTP Input](input-types)
* [Appearance in Blazor OTP Input](appearance)
* [Accessibility in Blazor OTP Input](accessibility)
* [Placeholder in Blazor OTP Input](placeholder)
* [Separator in Blazor OTP Input](separator)