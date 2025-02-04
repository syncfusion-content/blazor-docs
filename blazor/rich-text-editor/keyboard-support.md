---
layout: post
title: Keyboard support in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Keyboard support in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Keyboard support in Blazor RichTextEditor Component

The editor has full keyboard accessibility that includes shortcuts to open and other actions with toolbar items, drop-down lists, and dialogs.

## HTML editor shortcut keys

You can use the following key shortcuts when the Rich Text Editor renders with `HTML` [EditorMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EditorMode).

### Toolbar

The toolbar shortcuts allow quick navigation and interaction with the toolbar elements, including focusing, moving between tools, and executing actions like closing menus and dialogs.

| Actions | Windows | Mac |
|----------------|---------| --------- |
| Focus on toolbar | <kbd>Alt</kbd> + <kbd>F10</kbd> | <kbd>⌥</kbd> + <kbd>F10</kbd> |
| Move to the next tool | <kbd>→</kbd> | <kbd>→</kbd>, <kbd>⌘</kbd> + <kbd>F</kbd>  |
| Move to the previous tool | 	<kbd>←</kbd> | <kbd>←</kbd>, <kbd>⌘</kbd> + <kbd>F</kbd> |
| Close dropdowns/menu and dialogs | <kbd>Esc</kbd> | <kbd>Esc</kbd> |
| Execute the currently focused tool action | <kbd>Enter</kbd>, <kbd>Space</kbd> | <kbd>Enter</kbd>, <kbd>Space</kbd> |

### Content editing and formatting

These keyboard shortcuts allow for quick access to content editing features like bold, italic, and text selection.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Select all content | <kbd>Ctrl</kbd> + <kbd>A</kbd> | <kbd>⌘</kbd> + <kbd>A</kbd> |
| Insert a hard line break (a new paragraph) | <kbd>Enter</kbd> | <kbd>Enter</kbd> |
| Insert a soft line break (without starting a new paragraph) | <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> |
| Make text bold | <kbd>Ctrl</kbd> + <kbd>B</kbd> | <kbd>⌘</kbd> + <kbd>B</kbd> |
| Italicize text | <kbd>Ctrl</kbd> + <kbd>I</kbd> | <kbd>⌘</kbd> + <kbd>I</kbd> |
| Apply strikethrough | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>S</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>S</kbd> |
| Insert inline code | <kbd>Ctrl</kbd> + <kbd>`</kbd> | <kbd>⌘</kbd> + <kbd>`</kbd> |
| Create link | <kbd>Ctrl</kbd> + <kbd>K</kbd> | <kbd>⌘</kbd> + <kbd>K</kbd> |
| Copy format painter | <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>C</kbd> | <kbd>⌥</kbd> + <kbd>⌘</kbd> + <kbd>C</kbd> |
| Paste format painter | <kbd>Alt</kbd> + <kbd>Shift</kbd> + <kbd>V</kbd> |  <kbd>⌥</kbd> + <kbd>⌘</kbd> + <kbd>V</kbd> |
| Clear the copy format painter | <kbd>Esc</kbd> | <kbd>Esc</kbd> |
| Tab space (when [EnableTabKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EnableTabKey) is enabled) | <kbd>Tab</kbd> | <kbd>Tab</kbd> |

### Inserting

These shortcuts enable you to quickly insert tables, images, audio, and videos into your content.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Open the insert table dialog | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>E</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>E</kbd> |
| Open the insert image dialog | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>I</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>I</kbd> |
| Open the insert audio dialog | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>A</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>A</kbd> |
| Open the insert video dialog | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>V</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>V</kbd> |

### Table cell 

These shortcuts assist in navigating between table cells and managing table rows easily.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Move the selection to the next cell | <kbd>Tab</kbd>  |  <kbd>Tab</kbd> |
| Move the selection to the previous cell | <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> |
| Insert a new table row (when in the last cell) | <kbd>Tab</kbd>  | <kbd>Tab</kbd>  |
| Navigate through the table (using arrow keys) | <kbd>↑</kbd> , <kbd>→</kbd> , <kbd>↓</kbd> , <kbd>←</kbd> | <kbd>↑</kbd> , <kbd>→</kbd> , <kbd>↓</kbd> , <kbd>←</kbd> |

### Text manipulation

These shortcuts allow you to manipulate text, such as changing case or applying superscript/subscript formatting.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Convert text to uppercase | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>U</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>U</kbd> |
| Convert text to lowercase | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>L</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>L</kbd> |
| Apply superscript | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>=</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>=</kbd> |
| Apply subscript | <kbd>Ctrl</kbd> + <kbd>=</kbd> | <kbd>⌘</kbd> + <kbd>=</kbd> |

### Alignment and formatting

These shortcuts help you quickly adjust text alignment and formatting, such as left, center, or right justification.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Align text to the center | <kbd>Ctrl</kbd> + <kbd>E</kbd> | <kbd>⌘</kbd> + <kbd>E</kbd> |
| Justify text | <kbd>Ctrl</kbd> + <kbd>J</kbd> | <kbd>⌘</kbd> + <kbd>J</kbd> |
| Align text to the left | <kbd>Ctrl</kbd> + <kbd>L</kbd> | <kbd>⌘</kbd> + <kbd>L</kbd> |
| Align text to the right | <kbd>Ctrl</kbd> + <kbd>R</kbd> | <kbd>⌘</kbd> + <kbd>R</kbd> | 

### List and indentation

These shortcuts help with creating and adjusting ordered and unordered lists, and modifying indentations.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Increase indent | <kbd>Ctrl</kbd> + <kbd>]</kbd> | <kbd>⌘</kbd> + <kbd>]</kbd> |
| Decrease indent | <kbd>Ctrl</kbd> + <kbd>[</kbd> | <kbd>⌘</kbd> + <kbd>[</kbd> |
| Create an ordered list | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>O</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>O</kbd> |
| Create an unordered list | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>O</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>O</kbd> |

### Clipboard operations

These shortcuts streamline copying, cutting, pasting, and pasting content as plain text.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Copy the selected content  | <kbd>Ctrl</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>C</kbd> |
| Cut the selected content | <kbd>Ctrl</kbd> + <kbd>X</kbd> | <kbd>⌘</kbd> + <kbd>X</kbd> |
| Paste the copied or cut content | <kbd>Ctrl</kbd> + <kbd>V</kbd> | <kbd>⌘</kbd> + <kbd>V</kbd> |
| Paste content as plain text | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>V</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>V</kbd> |

### Undo & redo

These shortcuts allow you to quickly undo and redo changes to your content.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Undo | <kbd>Ctrl</kbd> + <kbd>Z</kbd> | <kbd>⌘</kbd> + <kbd>Z</kbd> |
| Redo | <kbd>Ctrl</kbd> + <kbd>Y</kbd> | <kbd>⌘</kbd> + <kbd>Y</kbd> |

### Other actions

These miscellaneous shortcuts help with actions like toggling fullscreen, clearing formatting, and accessing the HTML source.

| Actions | PC | Mac | 
|----------------|---------| --------- |
| View HTML source | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>H</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>H</kbd> |
| Toggle fullscreen mode | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>F</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>F</kbd> |
| Exit Fullscreen | <kbd>Esc</kbd> | <kbd>Esc</kbd> |
| Clear all formatting | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>R</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>R</kbd> |

## Markdown editor shortcut keys

You can use the following key shortcuts when the Rich Text Editor renders with `Markdown` [EditorMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_EditorMode).

### Toolbar

These shortcuts provide quick access to toolbar functions for managing menus and dialogs.

| Actions | Windows | Mac | 
|----------------|---------| ---------|
| Focus on toolbar | <kbd>Alt</kbd> + <kbd>F10</kbd> | <kbd>⌥</kbd> + <kbd>F10</kbd> |
| Close dropdowns/menu and dialogs | <kbd>Esc</kbd> | <kbd>Esc</kbd> |

### Content editing and formatting

These shortcuts help in efficiently editing and formatting text content.

| Actions | Windows | Mac | 
|----------------|---------| ---------|
| Select all content | <kbd>Ctrl</kbd> + <kbd>A</kbd> | <kbd>⌘</kbd> + <kbd>A</kbd> |
| Insert a hard line break (a new paragraph) | <kbd>Enter</kbd> | <kbd>Enter</kbd> |
| Make text bold | <kbd>Ctrl</kbd> + <kbd>B</kbd> | <kbd>⌘</kbd> + <kbd>B</kbd> |
| Italicize text | <kbd>Ctrl</kbd> + <kbd>I</kbd> | <kbd>⌘</kbd> + <kbd>I</kbd> |
| Apply strikethrough | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>S</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>S</kbd> |

### Inserting

These shortcuts allow for the quick insertion of tables, links, and images.

| Actions | Windows | Mac | 
|----------------|---------| ---------|
| Open the insert table dialog | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>E</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>E</kbd> |
| Create link | <kbd>Ctrl</kbd> + <kbd>K</kbd> | <kbd>⌘</kbd> + <kbd>K</kbd> |
| Open the insert image dialog | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>I</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>I</kbd> |

### Text manipulation

These shortcuts help in modifying text case and applying superscript or subscript.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Convert text to uppercase | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>U</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>U</kbd> |
| Convert text to lowercase | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>L</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>L</kbd> |
| Apply superscript | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>=</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>=</kbd> |
| Apply subscript | <kbd>Ctrl</kbd> + <kbd>=</kbd> | <kbd>⌘</kbd> + <kbd>=</kbd> |

### Lists

These shortcuts enable the creation of ordered and unordered lists.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Create an ordered list | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>O</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>O</kbd> |
| Create an unordered list | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>O</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>O</kbd> |

### Clipboard operations

These shortcuts facilitate copying, cutting, and pasting content.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Copy the selected content  | <kbd>Ctrl</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>C</kbd> |
| Cut the selected content | <kbd>Ctrl</kbd> + <kbd>X</kbd> | <kbd>⌘</kbd> + <kbd>X</kbd> |
| Paste the copied or cut content | <kbd>Ctrl</kbd> + <kbd>V</kbd> | <kbd>⌘</kbd> + <kbd>V</kbd> |

### Undo & redo

These shortcuts allow for undoing and redoing recent changes.

| Actions | Windows | Mac | 
|----------------|---------| ---------|
| Undo | <kbd>Ctrl</kbd> + <kbd>Z</kbd> | <kbd>⌘</kbd> + <kbd>Z</kbd> |
| Redo | <kbd>Ctrl</kbd> + <kbd>Y</kbd> | <kbd>⌘</kbd> + <kbd>Y</kbd> |

### Other actions

These shortcuts provide additional functionalities like fullscreen mode.

| Actions | Windows | Mac | 
|----------------|---------| --------- |
| Toggle fullscreen mode | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>F</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>F</kbd> |

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor EditorMode="EditorMode.Markdown">
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
    <p><b> Key features:</b></p>
    <ul>
    <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
    <li><p> Capable of handling markdown editing.</p></li>
    <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
    <li><p> Provides a fully customizable toolbar.</p></li><li><p> Provides HTML view to edit the source directly for developers.</p></li>
    <li><p> Supports third - party library integration.</p></li>
    <li><p> Allows preview of modified content before saving it.</p></li>
    </ul>
</SfRichTextEditor>

```

![Blazor RichTextEditor with Key Configuration](./images/blazor-richtexteditor-key-configuration.png)

## Custom key config

Customize the key config for the keyboard interaction of Rich Text Editor, using the `KeyConfigure` property.

In the following code block, customize the bold and italic, toolbar actions with `ctrl+1`, `ctrl+2` respectively.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor KeyConfigure="@KeyConfig">
    <p>The Rich Text Editor component is WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content. Users can format their content using standard toolbar commands.</p>
    <p><b> Key features:</b></p>
    <ul>
    <li><p> Provides <b>IFRAME</b> and <b>DIV</b> modes </p></li>
    <li><p> Capable of handling markdown editing.</p></li>
    <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
    <li><p> Provides a fully customizable toolbar.</p></li>
    <li><p> Provides HTML view to edit the source directly for developers.</p></li>
    <li><p> Supports third - party library integration.</p></li>
    <li><p> Allows preview of modified content before saving it.</p></li>
    </ul>
</SfRichTextEditor>

@code {
    private ShortcutKeys KeyConfig = new ShortcutKeys()
    {
        Bold = "ctrl+1",
        Italic = "ctrl+2"
    };
}

```

N> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) example to know how to render and configure the rich text editor tools.

## See also

* [Globalization](./globalization)
* [Accessibility](./accessibility)
