---
layout: post
title: Events in Blazor Block Editor Component | Syncfusion
description: Checkout and learn about Events with Blazor Block Editor component in Blazor WebAssembly App.
platform: Blazor
control: Block Editor
documentation: ug
---

# Events in Blazor Block Editor Component

The Block Editor component provides a comprehensive set of events that allow you to monitor and respond to various user interactions and editor state changes. These events enable you to implement custom behaviors, validation, logging, and integration with other systems.

## Created

The `Created` event is triggered when the Block Editor component is successfully initialized and ready for use. This event is useful for performing setup operations or initializing additional features after the editor is created.

```cshtml

@using Syncfusion.Blazor.Block Editor;

<div id="container">
    <SfBlock Editor ID="blockeditor" Created="@OnCreated">
    </SfBlock Editor>
</div>
@code {

    private void OnCreated()
    {
        // Your required actions here
    }
}

```

## BlockChanged

The `BlockChanged` event is triggered whenever the editor blocks are changed. This includes block additions, deletions, or any structural modifications to the document. Its event handler receives details about the changes.

```cshtml

@using Syncfusion.Blazor.Block Editor;

<div id="container">
    <SfBlock Editor ID="blockeditor" BlockChanged="@BlockChanged">
    </SfBlock Editor>
</div>
@code {

    private void BlockChanged(BlockChangedEventArgs args)
    {
        // Your required actions here
    }
}

```

## SelectionChanged

The `SelectionChanged` event is triggered when the user's text selection changes within the editor. The event arguments contain details about the new selection, which can be useful for updating UI elements.

```cshtml

@using Syncfusion.Blazor.Block Editor;

<div id="container">
    <SfBlock Editor ID="blockeditor" SelectionChanged="@SelectionChanged">
    </SfBlock Editor>
</div>
@code {

    private void SelectionChanged(SelectionChangedEventArgs args)
    {
        // Your required actions here
    }
}

```

## Focus

The `Focus` event is triggered when the editor gains focus. This is useful for updating UI states and managing editor interactions.

```cshtml

@using Syncfusion.Blazor.Block Editor;

<div id="container">
    <SfBlock Editor ID="blockeditor" Focus="@Focus">
    </SfBlock Editor>
</div>
@code {

    private void Focus(FocusEventArgs args)
    {
        // Your required actions here
    }
}

```

## Blur

The `Blur` event is triggered when the editor loses focus. This is commonly used for auto-saving content or hiding UI elements that should only be visible when the editor is active.

```cshtml

@using Syncfusion.Blazor.Block Editor;

<div id="container">
    <SfBlock Editor ID="blockeditor" Blur="@Blur">
    </SfBlock Editor>
</div>
@code {

    private void Blur(BlurEventArgs args)
    {
        // Your required actions here
    }
}

```

## PasteCleanupStarting

The `PasteCleanupStarting` event is triggered before content is pasted into the editor. This event allows you to inspect, modify, or cancel the paste operation via its event arguments.

```cshtml

@using Syncfusion.Blazor.Block Editor;

<div id="container">
    <SfBlock Editor ID="blockeditor" PasteCleanupStarting="@PasteCleanupStarting">
    </SfBlock Editor>
</div>
@code {

    private void PasteCleanupStarting(PasteCleanupStartingEventArgs args)
    {
        // Your required actions here
    }
}

```

## PasteCleanupCompleted

The `PasteCleanupCompleted` event is triggered after content has been successfully pasted into the editor. This is useful for post-processing pasted content or updating related UI elements.

```cshtml

@using Syncfusion.Blazor.Block Editor;

<div id="container">
    <SfBlock Editor ID="blockeditor" PasteCleanupCompleted="@PasteCleanupCompleted">
    </SfBlock Editor>
</div>
@code {

    private void PasteCleanupCompleted(PasteCleanupCompletedEventArgs args)
    {
        // Your required actions here
    }
}

```
