---
layout: post
title: Code Block in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Code Block in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Code Block in Blazor Rich Text Editor Component

The Code Block feature in the Rich Text Editor, enabling users to insert and format code snippets effectively. It covers configuring supported languages, integrating syntax highlighters, editing tips, and enabling tab-based indentation, making it ideal for technical documentation, tutorials, and code-heavy content. While live code block highlighting is not supported during editing, syntax highlighting can be applied when content is displayed on the frontend.

## Inserting a code block

The Code Block feature allows users to embed formatted code snippets within the Rich Text Editor. To insert a code block:

- **Using the Toolbar**: Click the **CodeBlock** button in the editor’s toolbar, typically represented by a code icon.
- **Using the Shortcut**: Press `Ctrl+Shift+B` (or `Cmd+Shift+B` on macOS) to insert a code block at the cursor’s position.
- A dropdown menu appears, allowing selection of the programming language for the code block, such as **JavaScript**, **Python**, **HTML**, or others configured in the system.

The code block is rendered with a monospaced font and preserved indentation for readability. Language selection applies syntax-specific formatting and prepares the block for syntax highlighting when displayed on the frontend.

## Configuring code block languages

The Code Block feature supports customizable programming languages via the `RichTextEditorCodeBlockSettings` property, specifically the `Languages` and `DefaultLanguage` options. The `Languages` property accepts an array of objects defining available languages, while `DefaultLanguage` sets the default language for new code blocks. This allows developers to customize the editor for project-specific languages.

Below is an example of how to configure the `RichTextEditorCodeBlockSettings` using the Rich Text Editor:

```cshtml

@using Syncfusion.Blazor.RichTextEditor
<SfRichTextEditor ID="code-block">
    <RichTextEditorCodeBlockSettings Languages="languages" DefaultLanguage="plaintext"></RichTextEditorCodeBlockSettings>
    <RichTextEditorToolbarSettings Items="Tools"></RichTextEditorToolbarSettings>
</SfRichTextEditor>
@code {
    private List<CodeBlockLanguageModel> languages = new List<CodeBlockLanguageModel>
         {
             new CodeBlockLanguageModel { Label = "HTML", Language = "html" },
             new CodeBlockLanguageModel { Label = "JavaScript", Language = "javascript" },
             new CodeBlockLanguageModel { Label = "CSS", Language = "css" },
             new CodeBlockLanguageModel { Label = "Plain Text", Language = "plaintext" }
         };
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CodeBlock },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough },
        new ToolbarItemModel() { Command = ToolbarCommand.InlineCode },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable },
        new ToolbarItemModel() { Command = ToolbarCommand.Blockquote },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.BulletFormatList },
        new ToolbarItemModel() { Command = ToolbarCommand.NumberFormatList },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Outdent },
        new ToolbarItemModel() { Command = ToolbarCommand.Indent },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor },
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor },
        new ToolbarItemModel() { Command = ToolbarCommand.FontName },
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.LowerCase },
        new ToolbarItemModel() { Command = ToolbarCommand.UpperCase },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
    };
}

```

In this example:

* The **Languages** array defines four supported languages: JavaScript, Python, HTML, and CSS.
* The **DefaultLanguage** is set to **javascript**, so new code blocks default to JavaScript.
* Each language object specifies a **Language** (for internal use, e.g., syntax highlighting) and a **Label** (displayed in the dropdown).

## Integrating syntax highlighters

To enhance code block readability, integrate a third-party syntax highlighter like [Prism.js](https://prismjs.com/) or [Highlight.js](https://highlightjs.org/), which supports numerous languages and customizable themes. Although live code block highlighting (real-time syntax highlighting during editing) is not possible in the Rich Text Editor, The highlighter can apply color-coded formatting to code blocks when the content is displayed on the frontend, such as in blog posts, website content, or preview mode. This ensures a polished presentation for end users.

## Tips for editing around code blocks

Editing content around code blocks requires care to preserve code integrity and maintain clean formatting. Follow these tips for a smooth editing experience:
* **Inserting Text Before a Code Block**: Place the cursor at the start of the code block’s first line and press `Enter` to create an empty line above. Press Enter again to start a new paragraph for text.
* **Inserting Text After a Code Block**: Place the cursor at the end of the code block’s last line and press `Enter` three times to exit the code block and create a new paragraph below.
* **Preserving Formatting When Pasting**: Paste code into a code block using `Ctrl+Shift+V` (or `Cmd+Shift+V` on macOS) to avoid external formatting (e.g., fonts or colors) and maintain the monospaced style.
* **Changing Languages**: When switching the language of a code block via the dropdown, verify that the code aligns with the new language for accurate syntax highlighting in the rendered output.
* **Previewing Content**: Since live syntax highlighting is not available during editing, use the editor’s preview mode to verify how code blocks render with syntax highlighting before publishing.

## Enabling tab-based line indentation in code blocks

The Code Block feature supports tab-based indentation to align code properly, crucial for languages like Python where indentation is syntactically significant. The Rich Text Editor does not provide a specific property to configure the indentation character, but indentation can be enabled using the editor’s default behavior for the Tab key, toolbar commands, or custom event handling.

To enable tab-based indentation:

* **Using the Tab Key**: Pressing `Tab` within a code block typically inserts a tab character (\t) or spaces (usually four, depending on the editor’s default configuration). Use `Shift+Tab` to outdent selected lines.
* **Toolbar Commands**: Include the `Indent` and `Outdent` buttons in the toolbar to increase or decrease indentation.
