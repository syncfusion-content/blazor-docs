---
layout: post
title: Events in Blazor Input Mask Component | Syncfusion®
description: Checkout and learn here all the features and Events in Blazor Input Mask component and much more details.
platform: Blazor
control: Input Mask
documentation: ug
---

# Events in Blazor Input Mask Component

This section lists the events available in the Blazor Input Mask (MaskedTextBox) component and when they are raised. Use these events to react to focus changes, value updates, and lifecycle moments. For reference, see the SfMaskedTextBox API.

## Blur

`Blur` is raised when the component loses focus. See Blur event and MaskBlurEventArgs in the API for details.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Blur="@BlurHandler"></SfMaskedTextBox>

@code {
    private void BlurHandler(MaskBlurEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## Created

`Created` is raised after the component has been initialized and rendered for the first time.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Created="@CreatedHandler"></SfMaskedTextBox>

@code {
    private void CreatedHandler(Object args)
    {
        // Here, you can customize your code.
    }
}
```

## Destroyed

`Destroyed` is raised when the component is disposed.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Destroyed="@DestroyedHandler"></SfMaskedTextBox>

@code {
    private void DestroyedHandler(Object args)
    {
        // Here, you can customize your code.
    }
}
```

## Focus

`Focus` is raised when the component receives focus. See Focus event and MaskFocusEventArgs in the API.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Focus="@FocusHandler"></SfMaskedTextBox>

@code {
    private void FocusHandler(MaskFocusEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## ValueChange

`ValueChange` is raised whenever the value of the MaskedTextBox changes. Use this event to react to value updates after a user edit. For two-way binding, see `ValueChanged`.

| Event Argument | Property | Description |
| --- | --- | --- |
| `MaskChangeEventArgs` | `Value` | Gets the current value of the MaskedTextBox. |
| `MaskChangeEventArgs` | `IsInteraction` | Indicates whether the change is triggered by user interaction. |

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox ValueChange="@ValueChangeHandler"></SfMaskedTextBox>

@code {
    private void ValueChangeHandler(MaskChangeEventArgs args)
    {
        // Here, you can customize your code.
    }
}
```

## ValueChanged

`ValueChanged` is the `EventCallback<string>` used for two-way binding. It is raised whenever the value changes, and is typically used with the `@bind-Value` directive. Prefer `ValueChange` if you need the `MaskChangeEventArgs` payload.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox ValueChanged="@ValueChangedHandler"></SfMaskedTextBox>

@code {
    private async Task ValueChangedHandler(string args)
    {
        // Here, you can customize your code.
    }
}
```

> The Input Mask component currently includes these events. If a required event is not listed, submit a feature request in the Blazor feedback portal: [https://www.syncfusion.com/feedback/blazor-components](https://www.syncfusion.com/feedback/blazor-components).

## See also

* [SfMaskedTextBox API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfMaskedTextBox.html)