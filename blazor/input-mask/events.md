---
layout: post
title: Events in Blazor Input Mask Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Input Mask component and much more details.
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

`ValueChange` is raised when the input value changes and the component then loses focus (or commits the change). This is typically used to react to completed edits; for two-way binding, see `ValueChanged`.

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

`ValueChanged` is raised whenever the value changes.
```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox ValueChanged="@ValueChangedHandler"></SfMaskedTextBox>

@code {
    private void ValueChangedHandler(String args)
    {
        // Here, you can customize your code.
    }
}
```

N> Input Mask currently includes these events. Additional events may be added based on user requests. If a required event is not listed, submit a feature request in the Syncfusion Blazor feedback portal: https://www.syncfusion.com/feedback/blazor-components