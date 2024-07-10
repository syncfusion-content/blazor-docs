---
layout: post
title: Methods in Blazor TextArea Component | Syncfusion
description: Checkout and learn about the list of all available methods in the Syncfusion Blazor TextArea component.
platform: Blazor
control: Textarea
documentation: ug
---

# Methods in Blazor TextArea Component

This section outlines the methods available for interacting with the TextArea component.

## FocusAsync method

The [FocusAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_FocusAsync) method in the TextArea, is used to set focus to the textarea element, enabling user interaction.

By calling the `FocusAsync` method, you can programmatically set focus to the TextArea component, allowing users to interact with it via keyboard input or other means.

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

The [FocusOutAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_FocusOutAsync) method in the TextArea component is used to remove focus from the textarea element, ending user interaction.
This method is beneficial for scenarios where user need to programmatically remove focus from the TextArea component, such as after completing a specific task or when navigating to another element in the application.

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

The [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextArea.html#Syncfusion_Blazor_Inputs_SfTextArea_GetPersistDataAsync) method in the TextArea component retrieves the properties that need to be maintained in the persisted state.
This method returns an object containing the properties to be persisted, which can include various configuration options and state information of the TextArea component. 

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