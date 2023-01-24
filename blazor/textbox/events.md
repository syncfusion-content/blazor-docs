---
layout: post
title: Events in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about Events in Syncfusion Blazor TextBox component and much more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Events in Blazor TextBox Component

This section explains the list of events of the TextBox component which will be triggered for appropriate TextBox actions.

## Blur

`Blur` event triggers when the TextBox has focus-out.

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

`Created` event triggers when the TextBox component is created.

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

`Destroyed` event triggers when the TextBox component is destroyed.

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

`Focus` event triggers when the TextBox gets focus.

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

`Input` event triggers each time when the value of TextBox has changed.

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

`ValueChange` event triggers when the content of TextBox has changed and gets focus-out.

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

`ValueChanged` event specifies the callback to trigger when the value changes.

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

N> TexTBox is limited with these events and new events will be added in the future based on the user requests. If the event you are looking for is not on the list, then request [here](https://www.syncfusion.com/feedback/blazor-components).