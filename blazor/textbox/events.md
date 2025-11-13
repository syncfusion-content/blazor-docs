---
layout: post
title: Events in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor TextBox component and much more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Events in Blazor TextBox Component

This section lists the TextBox events and when they are triggered during user interactions.

## Blur

The `Blur` event triggers when the TextBox loses focus.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Blur="@BlurHandler"></SfTextBox>

@code {
    private void BlurHandler(FocusOutEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Created

The `Created` event triggers after the TextBox component is initialized and rendered.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Created="@CreatedHandler"></SfTextBox>

@code {
    private void CreatedHandler(Object args)
    {
        // Here you can customize your code
    }
}
```

## Destroyed

The `Destroyed` event triggers when the TextBox component is disposed.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Destroyed="@DestroyedHandler"></SfTextBox>

@code {
    private void DestroyedHandler(Object args)
    {
        // Here you can customize your code
    }
}
```

## Focus

The `Focus` event triggers when the TextBox receives focus.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Focus="@FocusHandler"></SfTextBox>

@code {
    private void FocusHandler(FocusInEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Input

The `Input` event triggers every time the TextBox value changes (on each keystroke or input).

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Input="@InputHandler"></SfTextBox>

@code {
    private void InputHandler(InputEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## ValueChange

The `ValueChange` event triggers when the TextBox value is committed (typically on focus out) and has changed since it received focus.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox ValueChange="@ValueChangeHandler"></SfTextBox>

@code {
    private void ValueChangeHandler(ChangedEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## ValueChanged

The `ValueChanged` event is the parameter callback that fires when the `Value` parameter changes. It is commonly used with `@bind-Value` for two-way binding or to react to value updates programmatically.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox ValueChanged="@ValueChangedHandler"></SfTextBox>

@code {
    private void ValueChangedHandler(String args)
    {
        // Here you can customize your code
    }
}
```

N> TextBox is limited with these events and new events will be added in the future based on the user requests. If the event you are looking for is not on the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).