---
layout: post
title: AssistViewSettings Properties in Syncfusion Smart Rich Text Editor
description: AssistViewSettings reference with concise definitions and examples for configuring AI commands, popup sizing, placeholders, prompts, toolbars and history.
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

Sets the maximum height of the AI Assistant popup. Accepts CSS height values or numbers (treated as pixels).

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings PopupMaxHeight="80vh" />
</SfSmartRichTextEditor>
```
---

## PopupWidth
**Type:** `string` | **Default:** `"600"`

Sets the width of the AI Assistant popup. Accepts CSS width values or numbers (treated as pixels).

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings PopupWidth="650px" />
</SfSmartRichTextEditor>
```
---

## Placeholder
**Type:** `string` | **Default:** `"Ask AI to rewrite or generate content."`

Specifies the placeholder text shown in the AI Assistant prompt textarea.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <AssistViewSettings Placeholder="How can I improve this document?" />
</SfSmartRichTextEditor>
```
---

## Prompts
**Type:** `List<AssistViewPrompt>`

Defines a collection of predefined prompts and their corresponding responses. These prompt/response templates can be loaded into the AI Assistant to provide starter prompts or predefined workflows.

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

Defines suggestion prompts displayed in the AI Assistant popup.

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

Defines the maximum number of conversation entries retained in the editor's history. When this limit is exceeded, the oldest entries are automatically removed.

```razor
@using Syncfusion.Blazor.SmartRichTextEditor

<SfSmartRichTextEditor>
    <!-- Store only 5 recent conversations -->
    <AssistViewSettings MaxPromptHistory="5" />
</SfSmartRichTextEditor>
```
---

## BannerTemplate

Specifies the template for the banner in the AI Assistant popup, useful for branding, status, or short instructions.

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

Configures the toolbar in the header section of the AI Assistant interface.

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

Configures the toolbar below of the prompt input area section.
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

Configures the toolbar in the AI response viewer section.

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