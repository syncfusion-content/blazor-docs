---
layout: post
title: Events in Blazor Block Editor Component | Syncfusion
description: Checkout and learn about Events with Syncfusion Blazor Block Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Events in Blazor Block Editor Component

The Block Editor component provides a comprehensive set of events that allow you to monitor and respond to various user interactions and editor state changes. These events enable you to implement custom behaviors, validation, logging, and integration with other systems.

## Created

The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_Created) event is triggered when the Block Editor component is successfully initialized and ready for use. This event is useful for performing setup operations or initializing additional features after the editor is created.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor Created="@OnCreated"></SfBlockEditor>
</div>
@code {

    private void OnCreated()
    {
        // Your required actions here
    }
}

```

## BlockChanged

The [BlockChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_BlockChanged) event is triggered whenever the editor blocks are changed. This includes block additions, deletions, or any structural modifications to the document. Its event handler receives details about the changes.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor BlockChanged="@BlockChanged"></SfBlockEditor>
</div>
@code {

    private void BlockChanged(BlockChangedEventArgs args)
    {
        // Your required actions here
    }
}

```

## SelectionChanged

The [SelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_SelectionChanged) event is triggered when the user's text selection changes within the editor. The event arguments contain details about the new selection, which can be useful for updating UI elements.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor SelectionChanged="@SelectionChanged"></SfBlockEditor>
</div>
@code {

    private void SelectionChanged(SelectionChangedEventArgs args)
    {
        // Your required actions here
    }
}

```

## Focus

The [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_Focus) event is triggered when the editor gains focus. This is useful for updating UI states and managing editor interactions.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor Focus="@Focus"></SfBlockEditor>
</div>
@code {

    private void Focus(FocusEventArgs args)
    {
        // Your required actions here
    }
}

```

## Blur

The [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_Blur) event is triggered when the editor loses focus. This is commonly used for auto-saving content or hiding UI elements that should only be visible when the editor is active.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor Blur="@Blur"></SfBlockEditor>
</div>
@code {

    private void Blur(BlurEventArgs args)
    {
        // Your required actions here
    }
}

```

## PasteCleanupStarting

The [PasteCleanupStarting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_PasteCleanupStarting) event is triggered before content is pasted into the editor. This event allows you to inspect, modify, or cancel the paste operation via its event arguments.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor PasteCleanupStarting="@PasteCleanupStarting"></SfBlockEditor>
</div>
@code {

    private void PasteCleanupStarting(PasteCleanupStartingEventArgs args)
    {
        // Your required actions here
    }
}

```

## PasteCleanupCompleted

The [PasteCleanupCompleted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_PasteCleanupCompleted) event is triggered after content has been successfully pasted into the editor. This is useful for post-processing pasted content or updating related UI elements.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor PasteCleanupCompleted="@PasteCleanupCompleted"></SfBlockEditor>
</div>
@code {

    private void PasteCleanupCompleted(PasteCleanupCompletedEventArgs args)
    {
        // Your required actions here
    }
}

```
