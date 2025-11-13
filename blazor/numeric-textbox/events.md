---
layout: post
title: Events in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about events in Syncfusion Blazor Numeric TextBox component and much more details.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Events in Blazor Numeric TextBox Component

This section lists the events raised by the Numeric TextBox component and when they occur. Events are wired using the nested NumericTextBoxEvents tag inside the SfNumericTextBox.

## Blur

The `Blur` event occurs when the NumericTextBox loses focus.

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

The `Created` event fires after the NumericTextBox component has been initialized and rendered.

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

The `Destroyed` event fires when the NumericTextBox component is disposed.

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

The `Focus` event occurs when the NumericTextBox receives focus.

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

N> Numeric TextBox is limited to these events. Additional events may be added in the future based on user requests. If the event you are looking for is not on the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).