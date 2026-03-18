---
layout: post
title: AssistViewSettings Properties | Syncfusion Blazor Smart Rich Text Editor
description: Quick reference for AI Assistant properties with simple definitions and code examples.
platform: Blazor
control: Smart Rich Text Editor
documentation: ug
---

# AssistViewSettings Properties

## Commands
**Type:** `List<AICommands>`

Predefined AI actions displayed in the Smart Action dropdown.
Use the `Commands` property to configure each `AICommands` entry, including its display text, prompt template, and any nested options. By default, the AI Assistant prompt includes contextual information from the editor, such as the selected text or the entire document content.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings Commands="@MyCommands" />
</SfSmartRichTextEditor>

@code {
    private List<AICommands> MyCommands = new()
    {
        new AICommands { Text = "Shorten", Prompt = "Make this shorter" },
        new AICommands { Text = "Expand", Prompt = "Add more details" },
        new AICommands
        {
            Text = "Translate",
            Prompt = "Translate the text",
            Items = new List<AICommands>
            {
                new AICommands { Text = "To French", Prompt = "Translate to French" },
                new AICommands { Text = "To Spanish", Prompt = "Translate to Spanish" }
            }
        }
    };
}
```
---

## PopupMaxHeight
**Type:** `string` | **Default:** `"400"`
Maximum height for the AI Assistant popup. Accepts CSS units (e.g., `800px`, `80vh`, `100%`) or numeric values (treated as pixels).
Sets the maximum height of the AI Assistant popup. Accepts CSS values like "800px", "80vh", "100%".

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings PopupMaxHeight="80vh" />
</SfSmartRichTextEditor>
```
---

## PopupWidth
**Type:** `string` | **Default:** `"600"`
Width of the AI Assistant popup. Accepts CSS units (px, %, vw) or numeric values (converted to pixels); use `auto` for responsive sizing.
Sets the width of the AI Assistant popup. Accepts CSS values or numeric values.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings PopupWidth="650px" />
</SfSmartRichTextEditor>
```
---

## Placeholder
**Type:** `string` | **Default:** `"Ask AI to rewrite or generate content."`
Hint text shown inside the AI prompt input to guide users on what they can ask the assistant.
Sets the placeholder text in the AI prompt input field.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings Placeholder="How can I improve this document?" />
</SfSmartRichTextEditor>
```
---

## Prompts
**Type:** `List<AssistViewPrompt>`
A collection of predefined prompt/response templates that can be loaded into the assistant to provide starters or canned workflows.
Predefined prompt-response pairs to preload in the AI Assistant.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat

<SfSmartRichTextEditor>
    <AssistViewSettings Prompts="@TemplatePrompts" />
</SfSmartRichTextEditor>

@code {
    private List<AssistViewPrompt> TemplatePrompts = new()
    {
        new AssistViewPrompt
        {
            Prompt = "Draft a professional email",
            Response = @"Subject: Hello Team Dear Team, I hope this message finds you well. Best regards"
        },
        new AssistViewPrompt
        {
            Prompt = "Create API documentation",
            Response = @"### GET /users Retrieves a list of users. **Request** GET /api/users **Response** ```json { ""users"": [] } ```"
        }
    };
}
```
---

## Suggestions
**Type:** `List<string>`
Short suggestion chips presented to users for one-tap prompts (e.g., "Fix grammar", "Make shorter").
Quick-start suggestion chips shown in the AI Assistant.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings Suggestions="@QuickSuggestions" />
</SfSmartRichTextEditor>

@code {
    private List<string> QuickSuggestions = new()
    {
        "Make shorter",
        "Improve clarity",
        "Fix grammar",
        "Add examples",
        "More formal",
        "Simplify"
    };
}
```
---

## MaxPromptHistory
**Type:** `int` | **Default:** `20`
Maximum number of conversation entries to retain; oldest entries are removed when the limit is exceeded.
Maximum number of saved conversations. Oldest entries are removed when exceeded.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <!-- Store only 5 recent conversations -->
    <AssistViewSettings MaxPromptHistory="5" />
</SfSmartRichTextEditor>
```
---

## BannerTemplate
**Type:** `RenderFragment?`
RenderFragment used to render a custom banner at the top of the assistant, useful for branding, status, or short instructions.
Custom template for the banner at the top of the AI Assistant sidebar.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings>
        <BannerTemplate>
            <div style="padding: 16px; background: linear-gradient(135deg, #667eea 0%, #764ba2 100%); color: white;">
                <h3 style="margin: 0;">Smart AI Assistant</h3>
                <span style="font-size: 12px;">Real-time AI assistance</span>
            </div>
        </BannerTemplate>
    </AssistViewSettings>
</SfSmartRichTextEditor>
```
---

## HeaderToolbarSettings
**Type:** `RenderFragment?`
RenderFragment that defines toolbar items in the assistant header (close, settings, etc.).
Toolbar configuration for the header of the AI Assistant sidebar.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Navigations

<SfSmartRichTextEditor>
    <AssistViewSettings>
        <HeaderToolbarSettings>
            <AssistViewToolbarItem Type="ItemType.Spacer" />
            <AssistViewToolbarItem Text="Close" IconCss="e-icons e-close" />
            <AssistViewToolbarItem Text="AI Commands" />
        </HeaderToolbarSettings>
    </AssistViewSettings>
</SfSmartRichTextEditor>
```
---

## PromptToolbarSettings
**Type:** `RenderFragment?`
RenderFragment for toolbar items shown below the prompt input (edit, copy, save, etc.).
Toolbar configuration below the prompt input area.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Navigations

<SfSmartRichTextEditor>
    <AssistViewSettings>
        <PromptToolbarSettings>
            <PromptToolbarItem Text="Edit" IconCss="e-icons e-assist-edit" Tooltip="Edit prompt" />
            <PromptToolbarItem Text="Copy" IconCss="e-icons e-assist-copy" Tooltip="Copy to clipboard" />
            <PromptToolbarItem Type="ItemType.Separator" />
            <PromptToolbarItem Text="Save" IconCss="e-icons e-save" />
        </PromptToolbarSettings>
    </AssistViewSettings>
</SfSmartRichTextEditor>
```
---

## ResponseToolbarSettings
**Type:** `RenderFragment?`
RenderFragment for actions associated with AI responses (regenerate, copy, insert, feedback buttons).
Toolbar configuration for AI response actions.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor
@using Syncfusion.Blazor.InteractiveChat
@using Syncfusion.Blazor.Navigations

<SfSmartRichTextEditor>
    <AssistViewSettings>
        <ResponseToolbarSettings>
            <ResponseToolbarItem Text="Regenerate" IconCss="e-icons e-refresh" />
            <ResponseToolbarItem Text="Copy" IconCss="e-icons e-copy" />
            <ResponseToolbarItem Type="ItemType.Separator" />
            <ResponseToolbarItem Text="Insert" IconCss="e-icons e-check" />
            <ResponseToolbarItem>
                <Template>
                    <button onclick="alert('Feedback saved')">👍 Helpful</button>
                </Template>
            </ResponseToolbarItem>
        </ResponseToolbarSettings>
    </AssistViewSettings>
</SfSmartRichTextEditor>
```
---

## See Also

* [Methods](method.md)
* [Appearance](appearance.md)
* [Events](events.md)