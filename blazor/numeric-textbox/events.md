---
layout: post
title: Events in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Numeric TextBox component and much more details.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Events in Blazor Numeric TextBox Component

This section explains the list of events of the Numeric TextBox component which will be triggered for appropriate Numeric TextBox actions.

## Blur

`Blur` event triggers when the NumericTextBox got focus out.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?">
    <NumericTextBoxEvents TValue="int?" Blur="@BlurHandler"></NumericTextBoxEvents>
</SfNumericTextBox>

@code {
    private void BlurHandler(NumericBlurEventArgs<int?> args)
    {
        // Here you can customize your code
    }
}
```

## Created

`Created` event triggers when the NumericTextBox component is created.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?">
    <NumericTextBoxEvents TValue="int?" Created="@CreatedHandler"></NumericTextBoxEvents>
</SfNumericTextBox>

@code {
    private void CreatedHandler(Object args)
    {
        // Here you can customize your code
    }
}
```

## Destroyed

`Destroyed` event triggers when the NumericTextBox component is destroyed.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?">
    <NumericTextBoxEvents TValue="int?" Destroyed="@DestroyedHandler"></NumericTextBoxEvents>
</SfNumericTextBox>

@code {
    private void DestroyedHandler(Object args)
    {
        // Here you can customize your code
    }
}
```

## Focus 

`Focus` event triggers when the NumericTextBox got focus in.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?">
    <NumericTextBoxEvents TValue="int?" Focus="@FocusHandler"></NumericTextBoxEvents>
</SfNumericTextBox>

@code {
    private void FocusHandler(NumericFocusEventArgs<int?> args)
    {
        // Here you can customize your code
    }
}
```

## ValueChange

The `ValueChange` event triggers when the value changes or the component loses focus.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?">
    <NumericTextBoxEvents TValue="int?" ValueChange="@ValueChangeHandler"></NumericTextBoxEvents>
</SfNumericTextBox>

@code {
    private void ValueChangeHandler(ChangeEventArgs<int?> args)
    {
        // Here you can customize your code
    }
}
```

N> Numeric TextBox is limited with these events and new events will be added in the future based on the user requests. If the event you are looking for is not on the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).
