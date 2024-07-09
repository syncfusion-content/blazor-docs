---
layout: post
title: Events in Blazor TextArea Component | Syncfusion
description: Handling events triggered by user interactions or changes of the Syncfusion Blazor Textarea component and much more.
platform: Blazor
control: Textarea
documentation: ug
---

# Events in Blazor TextArea Component

This section describes the TextArea events that will be triggered when appropriate actions are performed. The following events are available in the TextArea component.

## Created event

The TextArea component triggers the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Created) event when the TextArea component is created. This event provides users with an opportunity to perform actions immediately after the TextArea has been created and initialized.

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

The TextArea component triggers the [Input](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Input) each time when the value of TextArea has changed. This event provides users with an opportunity to perform actions in response to real-time changes in the TextArea's content.
The [TextAreaInputEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.TextAreaInputEventArgs.html) passed as an event argument provides the details about the input event in the TextArea.

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

The TextArea component triggers the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_ValueChange) event when the content of TextArea has changed and gets focus-out. This event provides users with an opportunity to execute specific actions in response to changes made by the user.
The [TextAreaValueChangeEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.TextAreaValueChangeEventArgs.html) passed as an event argument provides the details about the changes in the TextArea's value.

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

The TextArea component triggers the [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Focus ) when the TextArea gains focus. This event allows developers to execute specific actions when the user interacts with the TextArea by focusing on it.
The [TextAreaFocusInEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.TextAreaFocusInEventArgs.html) passed as an argument provides details about the focus event in the TextArea.

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

The TextArea component triggers the [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Blur) when the TextArea loses focus. This event allows users to execute specific actions when the user interacts with the TextArea by moving focus away from it.
The [TextAreaFocusOutEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.TextAreaFocusOutEventArgs.html) passed as an argument provides details about the blur event in the TextArea.

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

The TextArea component triggers the [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_Destroyed) when the TextArea component is destroyed.

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