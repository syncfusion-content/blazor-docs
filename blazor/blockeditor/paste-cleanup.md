---
layout: post
title: Paste Clean-up in Blazor Block Editor Component | Syncfusion
description: Checkout and learn about Paste Clean-up in Syncfusion Blazor Block Editor component and more.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Paste Clean-up in Blazor Block Editor component

The Block Editor component provides robust paste clean-up functionalities to ensure that pasted content integrates seamlessly and maintains styling and structural consistency. This feature helps remove unwanted formatting, scripts, and elements copied from external sources like web pages or word processors.

You can configure the paste behavior using the `BlockEditorPasteCleanup` tag directive, which allows you to define how content is handled when pasted into the editor.

## Configuring allowed styles

The `AllowedStyles` property lets you define which CSS styles are permitted in pasted content. Any style not in this list is stripped out, ensuring that only desired visual attributes are preserved.

By default, the following styles are allowed:

['font-weight', 'font-style', 'text-decoration', 'text-transform'].

In the below example, only `font-weight` and `font-style` styles will be retained from the pasted content. All other inline styles will be removed.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div class="container" style="width: 40px; margin: 50px auto;">
    <SfBlockEditor>
        <BlockEditorPasteCleanup AllowedStyle="@(new string[] { "font-weight", "font-style" })"></BlockEditorPasteCleanup>
    </SfBlockEditor>
</div>

```

## Setting denied tags

The `DeniedTags` property specifies a list of HTML tags to be removed from pasted content. This is useful for stripping potentially problematic elements like `<script>` or `<iframe>` tags. By default, this property is an empty array, so no tags are removed.

In the below example, any `<script>` or `<iframe>` tags found in the pasted content will be removed, preventing unwanted behavior or styling issues.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div class="container" style="width: 40px; margin: 50px auto;">
    <SfBlockEditor>
        <BlockEditorPasteCleanup AllowedStyle="@(new string[] { "font-weight", "font-style" })"></BlockEditorPasteCleanup>
    </SfBlockEditor>
</div>

```

Below example demonstrates the usage of paste settings that allows only specific styles and also removes the specific tags from the pasted content.

```cshtml

@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor @ref="blockEditor" Blocks="@blockData" PasteCleanupCompleted="HandleAfterPaste">
        <BlockEditorPasteCleanup AllowedStyles="@(new string[] { "text-decoration" })"
                                 DeniedTags="@(new string[] { "script", "iframe" })"></BlockEditorPasteCleanup>
    </SfBlockEditor>

    <div id="controls">
        <h4>Test Content to Copy and Paste:</h4>
        <div class="test-content">
            <div id="sampleContent" contenteditable="true">
                <h2 style="color: red; font-weight: bold; font-size: 24px;">Formatted Heading</h2>
                <p style="background-color: yellow; font-style: italic;">
                    This is a <span style="font-weight: bold;">bold paragraph</span> with
                    <span style="color: blue; font-style: italic;">italic text</span> and
                    <span style="text-decoration: underline;">underlined content</span>.
                </p>
                <script>console.log('This script should be removed');</script>
                <iframe src="about:blank" width="100" height="50"></iframe>
                <div style="border: 1px solid black; padding: 10px;">
                    <span style="font-weight: 600;">Heavy text</span> and
                    <span style="color: green; font-size: 18px;">colored text</span>
                </div>
            </div>
        </div>
        <div id="output">@output</div>
    </div>
</div>

@code {
    private SfBlockEditor blockEditor;
    private string output = "";

    private List<BlockModel> blockData = new List<BlockModel>()
    {
        new BlockModel { ID = "demo-block", BlockType = BlockType.Paragraph }
    };

    private BlockEditorPasteCleanup pasteSettings = new BlockEditorPasteCleanup()
        {
            AllowedStyles = new string[] { "text-decoration" },
            DeniedTags = new string[] { "script", "iframe" }
        };

    private void HandleAfterPaste(PasteCleanupCompletedEventArgs args)
    {
        output = $"After Paste Event: Processed content length: {args.Content.Length} characters";
    }

    protected override void OnInitialized()
    {
        output = @"Paste Cleanup Settings Active:
        - Allowed Styles: ['text-decoration']
        - Denied Tags: ['script', 'iframe']

        Copy content from the test area above and paste it into the editor to see the cleanup in action.";
    }
}

<style>
#container {
    margin: 50px;
    gap: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
}

#controls {
    width: 100%;
    margin-top: 20px;
    padding: 20px;
    border: 1px solid #ddd;
    border-radius: 5px;
}

.test-content {
    margin-bottom: 20px;
    padding: 15px;
    border-radius: 4px;
}

#sampleContent {
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 4px;
    background-color: #f8f9fa;
    min-height: 150px;
}

#output {
    margin-top: 15px;
    padding: 10px;
    background-color: #f8f9fa;
    border-radius: 4px;
    min-height: 50px;
    font-family: monospace;
    white-space: pre-wrap;
}
</style>

```

## Disable Keep format

By default, the editor retains the formatting of pasted content (e.g., bold, italics, links). You can disable this by setting the `KeepFormat` property to `false`. When disabled, the editor primarily pastes content as plain text, regardless of the `AllowedStyles` configuration.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div class="container" style="width: 40px; margin: 50px auto;">
    <SfBlockEditor>
        <BlockEditorPasteCleanup KeepFormat=false></BlockEditorPasteCleanup>
    </SfBlockEditor>
</div>

```

## Allowing plain text

To paste content as plain text, stripping all HTML tags and inline styles, set the `PlainText` property to `true` in `BlockEditorPasteCleanup` tag directive. This ensures that only raw text is inserted, which is ideal for maintaining strict content consistency. By default, this property is `false`.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div class="container" style="width: 40px; margin: 50px auto;">
    <SfBlockEditor>
        <BlockEditorPasteCleanup PlainText=false></BlockEditorPasteCleanup>
    </SfBlockEditor>
</div>

```

Below example demonstrates the usage of paste settings that disables the keep format and allows plain text.

```cshtml

@using Syncfusion.Blazor.BlockEditor

<div id="container">
    <SfBlockEditor @ref="blockEditor" Blocks="@blockData" PasteCleanupCompleted="HandleAfterPaste">
        <BlockEditorPasteCleanup PlainText="true" KeepFormat="false"></BlockEditorPasteCleanup>
    </SfBlockEditor>

    <div id="controls">
        <h4>Test Content to Copy and Paste:</h4>
        <div class="test-content">
            <div id="sampleContent" contenteditable="true">
                <h2 style="color: red; font-weight: bold; font-size: 24px;">Formatted Heading</h2>
                <p style="background-color: yellow; font-style: italic;">
                    This is a <span style="font-weight: bold;">bold paragraph</span> with
                    <span style="color: blue; font-style: italic;">italic text</span> and
                    <span style="text-decoration: underline;">underlined content</span>.
                </p>
                <div style="border: 1px solid black; padding: 10px;">
                    <span style="font-weight: 600;">Heavy text</span> and
                    <span style="color: green; font-size: 18px;">colored text</span>
                </div>
            </div>
        </div>
        <div id="output">@output</div>
    </div>
</div>

@code {
    private SfBlockEditor blockEditor;
    private string output = "";

    private List<BlockModel> blockData = new List<BlockModel>()
    {
        new BlockModel { ID = "demo-block", BlockType = BlockType.Paragraph }
    };

    private void HandleAfterPaste(PasteCleanupCompletedEventArgs args)
    {
        output = $"After Paste Event: Processed content length: {args.Content.Length} characters";
    }

    protected override void OnInitialized()
    {
        output = @"Paste Cleanup Settings Active:
        - Keep Format: false
        - Plain Text: true

        Copy content from the test area above and paste it into the editor to see the cleanup in action.";
    }
}

<style>
#container {
    margin: 50px;
    gap: 20px;
    display: flex;
    flex-direction: column;
    align-items: center;
}

#controls {
    width: 100%;
    margin-top: 20px;
    padding: 20px;
    border: 1px solid #ddd;
    border-radius: 5px;
}

.test-content {
    margin-bottom: 20px;
    padding: 15px;
    border-radius: 4px;
}

#sampleContent {
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 4px;
    background-color: #f8f9fa;
    min-height: 150px;
}

#output {
    margin-top: 15px;
    padding: 10px;
    background-color: #f8f9fa;
    border-radius: 4px;
    min-height: 50px;
    font-family: monospace;
    white-space: pre-wrap;
}
</style>

```

### Events

The Block Editor provides events to monitor and interact with the paste action.

|Name|Args|Description|
|---|---|---|
|`PasteCleanupStarting`|PasteCleanupStartingEventArgs|Triggers before the content is pasted into the editor.|
|`PasteCleanupCompleted`|PasteCleanupCompletedEventArgs|Triggers after the content is pasted into the editor.|

Below example demonstrates how to configure above events in the editor.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div class="container" style="width: 40px; margin: 50px auto;">
    <SfBlockEditor PasteCleanupStarting="HandleBeforePaste" PasteCleanupCompleted="HandleAfterPaste">
    </SfBlockEditor>
</div>

@code {
    private void HandleAfterPaste(PasteCleanupCompletedEventArgs args)
    {
        // Your actions here
    }

    private void HandleBeforePaste(PasteCleanupStartingEventArgs args)
    {
        // Your actions here
    }
}

```