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

By calling `FocusAsync`, the TextArea receives focus so the user can immediately interact with it using the keyboard or other input methods. Ensure the component reference is available (after the initial render) before invoking this method, for example by calling it in a Created/OnAfterRenderAsync handler or checking for null.

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

The [FocusOutAsync method](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_FocusOutAsync) programmatically removes focus (blurs) the TextArea element, ending direct user interaction. This asynchronous method returns a Task and should be awaited when used in an async context. To move focus to another control, explicitly set focus on the target element after blurring.

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

The [GetPersistDataAsync method](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_GetPersistDataAsync) retrieves a serialized representation (typically a JSON string) of the component state to be maintained for persistence. Use this method when persistence is enabled (for example, with EnablePersistence="true") to capture configuration and state for storage and later restoration. As an asynchronous method, it returns a Task<string> and should be awaited in an async context.

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