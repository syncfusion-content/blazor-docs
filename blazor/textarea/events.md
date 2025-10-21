---
layout: post
title: Events in Blazor TextArea Component | Syncfusion
description: Handling events triggered by user interactions or changes of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: TextArea
documentation: ug
---

# Events in Blazor TextArea Component

This topic describes the TextArea events raised during user interaction and component lifecycle. The following events are available: Created, Input, ValueChange, Focus, Blur, and Destroyed.

## Created event

The TextArea triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Created) event after the component is created and initialized. Use this event for one-time initialization or configuration logic. This event does not provide event arguments.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextArea Created="@CreatedHandler"></SfTextArea>

@code {
    private void CreatedHandler()
    {
        // Here you can customize your code
    }
}
```

## Input event

The TextArea triggers the [Input](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Input) event on every keystroke as the user types, reflecting real-time changes to the content. The [TextAreaInputEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.TextAreaInputEventArgs.html) argument provides details about the input event.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextArea Input="@InputHandler"></SfTextArea>

@code {
    private void InputHandler(TextAreaInputEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## ValueChange event

The TextArea triggers the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_ValueChange) event when the content is committed (typically when the component loses focus). Use this event to react to finalized value changes rather than per-keystroke updates. The [TextAreaValueChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.TextAreaValueChangeEventArgs.html) argument provides details about the change.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextArea  ValueChange="@ChangeHandler"></SfTextArea>
@code {
    private void ChangeHandler(TextAreaValueChangeEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Focus event

The TextArea triggers the [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Focus) event when the component gains focus. Use this event to run logic when the user focuses the control. The [TextAreaFocusInEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.TextAreaFocusInEventArgs.html) argument provides details about the focus-in event.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextArea Focus="@FocusHandler"></SfTextArea>

@code {
    private void FocusHandler(TextAreaFocusInEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Blur event

The TextArea triggers the [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Blur) event when focus leaves the component. Use this event to handle actions when focus moves away. The [TextAreaFocusOutEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextAreaFocusOutEventArgs.html) argument provides details about the blur event.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextArea Blur="@BlurHandler"></SfTextArea>

@code {
    private void BlurHandler(TextAreaFocusOutEventArgs args)
    {
        // Here you can customize your code
    }
}
```

## Destroyed event

The TextArea triggers the [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Destroyed) event when the component is disposed. Use this lifecycle event to release resources or perform cleanup. This event does not provide event arguments.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextArea Destroyed="@DestroyedHandler"></SfTextArea>

@code {
    private void DestroyedHandler()
    {
        // Here you can customize your code
    }
}
```