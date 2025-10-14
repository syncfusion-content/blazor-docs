---
layout: post
title: Methods in Blazor TextArea Component | Syncfusion
description: Checkout and learn about the list of all available methods in the Syncfusion Blazor TextArea component.
platform: Blazor
control: TextArea
documentation: ug
---

# Methods in Blazor TextArea Component

This section describes the methods available for interacting with the TextArea component.

## FocusAsync method

The [FocusAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_FocusAsync) method programmatically moves focus to the TextArea element to enable user input. This asynchronous method should be awaited when used in an async context.

By calling the `FocusAsync` method, focus is set to the TextArea so the user can immediately interact with it using the keyboard or other input methods. Ensure the component reference is available (after initial render) before invoking this method.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextArea @ref="textArea" Placeholder="Enter the Address"></SfTextArea>

<button @onclick="AddFocus">Focus Text Area</button>

@code {
    private SfTextArea textArea { get; set; }

    private void AddFocus()
    {
        textArea.FocusAsync();
    }
}
```

## FocusOutAsync method

The [FocusOutAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_FocusOutAsync) method programmatically removes focus from the TextArea element, ending direct user interaction. This asynchronous method should be awaited when used in an async context.
This method is useful when focus needs to move away after completing a task or to shift attention to another element in the application.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextArea @ref="textArea" Placeholder="Enter the Address"></SfTextArea>

<button @onclick="RemoveFocus">Remove Focus Text Area</button>

@code {
    private SfTextArea textArea { get; set; }

    private void RemoveFocus()
    {
        textArea.FocusOutAsync();
    }
}
```

## GetPersistDataAsync method

The [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_GetPersistDataAsync) method retrieves the component state that should be maintained for persistence. It returns a serialized representation (typically a JSON string) of the properties to persist.
Use this method to capture configuration and state for storage and later restoration, such as saving user settings between sessions. As an asynchronous method, it should be awaited when called in an async context.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextArea @ref="textArea" Placeholder="Enter the Address"></SfTextArea>

<button @onclick="GetData">Get Data</button>

@code {
    private SfTextArea textArea { get; set; }

    private void GetData()
    {
        textArea.GetPersistDataAsync();
    }
}
```