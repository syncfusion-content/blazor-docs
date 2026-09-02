---
layout: post
title: Events in Blazor TextBox | Syncfusion
description: Handle Blazor TextBox events including Blur, Focus, Input, ValueChange, and Created event types for custom interactions.
platform: Blazor
control: TextBox
documentation: ug
---

# Events in Blazor TextBox

This section lists the Blazor TextBox events and when they are triggered during user interactions.

## Blur

The [`Blur`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Blur) event triggers when the Blazor TextBox loses focus. The event argument is [`BlurEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.BlurEventArgs.html).

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Blur="@BlurHandler"></SfTextBox>

@code {
    private void BlurHandler(BlurEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Created

The [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Created) event triggers after the Blazor TextBox component is initialized and rendered.

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

The [`Destroyed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Destroyed) event triggers when the Blazor TextBox component is disposed.

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

The [`Focus`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Focus) event triggers when the Blazor TextBox receives focus. The event argument is [`FocusEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.FocusEventArgs.html).

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

The [`Input`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Input) event triggers every time the Blazor TextBox value changes (on each keystroke or input).

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

The [`ValueChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_ValueChange) event triggers when the Blazor TextBox value is committed (typically on focus out) and has changed since it received focus. The event argument is [`ChangedEventArgs<TValue>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.ChangeEventArgs-1.html), which exposes the previous and current values through its `PreviousValue` and `Value` properties.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox ValueChange="@ValueChangeHandler"></SfTextBox>

@code {
    private void ValueChangeHandler(ChangedEventArgs<string> args)
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
    private void ValueChangedHandler(string value)
    {
        // Here you can customize your code
    }
}
```

N> The Blazor TextBox is limited with these events and new events will be added in the future based on the user requests. If the event you are looking for is not on the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).