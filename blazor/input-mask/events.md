---
layout: post
title: Events in Blazor Input Mask Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor Input Mask component and much more details.
platform: Blazor
control: Input Mask
documentation: ug
---

# Events in Blazor Input Mask Component

This section explains the list of events of the Input Mask component which will be triggered for appropriate Input Mask actions.

## Blur

`Blur` event triggers when the Input Mask component has focus-out.

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

`Created` event triggers when the Input Mask component is created.

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

`Destroyed` event triggers when the Input Mask component is destroyed.

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

`Focus` event triggers when the Input Mask gets focus.

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

`ValueChange` event triggers when the content of Input Mask has changed and gets focus-out.

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

`ValueChanged` event Specifies the callback to trigger when the value changes.

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

N> Input Mask is limited with these events and new events will be added in the future based on the user requests. If the event you are looking for is not on the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).