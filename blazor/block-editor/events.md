---
layout: post
title: Events in Blazor Block Editor Component | Syncfusion
description: Check out and learn about handling lifecycle events, user interaction events, and content change events with Syncfusion Blazor Block Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Events in Blazor Block Editor Component

The Block Editor component provides a comprehensive set of events to monitor and respond to various user interactions and editor state changes. These events enable implementation of custom behaviors, validation, logging, and integration with other systems.

## Created

The [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_Created) event triggers when the Block Editor component is successfully initialized and ready for use. This event is useful for performing setup operations or initializing additional features after the editor is created.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Created="@OnCreated"></SfBlockEditor>
</div>

@code {
    private void OnCreated()
    {
        // Perform initialization tasks
        // Example: Load user preferences, setup auto-save, etc.
    }
}
```

## BlockChanged

The [BlockChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_BlockChanged) event triggers whenever editor blocks are changed. This includes block additions, deletions, or any structural modifications to the document. The event handler receives details about the changes.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor BlockChanged="@OnBlockChanged"></SfBlockEditor>
</div>

@code {
    private void OnBlockChanged(BlockChangedEventArgs args)
    {
        // Access changed blocks via args
        // Example: Track document changes, trigger auto-save, update word count, etc.
    }
}
```

## SelectionChanged

The [SelectionChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_SelectionChanged) event triggers when the user's text selection changes within the editor. The event arguments contain details about the new selection, which can be useful for updating UI elements or enabling context-specific features.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor SelectionChanged="@OnSelectionChanged"></SfBlockEditor>
</div>

@code {
    private void OnSelectionChanged(SelectionChangedEventArgs args)
    {
        // Access selection details via args
        // Example: Update toolbar state, show formatting options, etc.
    }
}
```

## Focus

The [Focus](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_Focus) event triggers when the editor gains focus. This is useful for updating UI states, showing toolbars, or managing editor interactions.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Focus="@OnFocus"></SfBlockEditor>
</div>

@code {
    private void OnFocus(FocusEventArgs args)
    {
        // Handle focus event
        // Example: Show floating toolbar, highlight editor border, etc.
    }
}
```

## Blur

The [Blur](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_Blur) event triggers when the editor loses focus. This is commonly used for auto-saving content, hiding UI elements that should only be visible when the editor is active, or validating content.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor Blur="@OnBlur"></SfBlockEditor>
</div>

@code {
    private void OnBlur(BlurEventArgs args)
    {
        // Handle blur event
        // Example: Auto-save content, hide toolbars, validate input, etc.
    }
}
```

## PasteCleanupStarting

The [PasteCleanupStarting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_PasteCleanupStarting) event triggers before content is pasted into the editor. This event allows inspection, modification, or cancellation of the paste operation via event arguments.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor PasteCleanupStarting="@OnPasteCleanupStarting"></SfBlockEditor>
</div>

@code {
    private void OnPasteCleanupStarting(PasteCleanupStartingEventArgs args)
    {
        // Inspect or modify pasted content before insertion
        // Example: Strip formatting, sanitize HTML, prevent certain content types, etc.
        // Set args.Cancel = true to prevent paste operation
    }
}
```

## PasteCleanupCompleted

The [PasteCleanupCompleted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_PasteCleanupCompleted) event triggers after content has been successfully pasted into the editor. This is useful for post-processing pasted content or updating related UI elements.

```cshtml
@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor PasteCleanupCompleted="@OnPasteCleanupCompleted"></SfBlockEditor>
</div>

@code {
    private void OnPasteCleanupCompleted(PasteCleanupCompletedEventArgs args)
    {
        // Handle post-paste operations
        // Example: Log paste action, update statistics, trigger content analysis, etc.
    }
}
```
