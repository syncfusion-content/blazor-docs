---
layout: post
title: Keyboard Shortcuts in Blazor Block Editor Component | Syncfusion
description: Checkout and learn here all about Keyboard Shortcuts with Syncfusion Blazor Block Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: BlockEditor
documentation: ug
---

# Keyboard Shortcuts in Blazor Block Editor component

The Block Editor component provides comprehensive keyboard shortcuts to enhance productivity and streamline content creation. These shortcuts are organized into different categories based on their functionality, allowing users to quickly access various features without relying on mouse interactions. The ⌘ symbol represents the Command key on Mac, and ⌥ represents the Option key.

## Content editing and formatting

These keyboard shortcuts allow for quick access to content editing features like bold, italic, and text formatting options.

| Actions | Windows | Mac |
|---------|---------|-----|
| Bold | <kbd>Ctrl</kbd> + <kbd>B</kbd> | <kbd>⌘</kbd> + <kbd>B</kbd> |
| Italic | <kbd>Ctrl</kbd> + <kbd>I</kbd> | <kbd>⌘</kbd> + <kbd>I</kbd> |
| Underline | <kbd>Ctrl</kbd> + <kbd>U</kbd> | <kbd>⌘</kbd> + <kbd>U</kbd> |
| Strikethrough | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>X</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>X</kbd> |
| Insert Link | <kbd>Ctrl</kbd> + <kbd>K</kbd> | <kbd>⌘</kbd> + <kbd>K</kbd> |

## Block creation and management

These shortcuts enable quick creation of different block types and management of existing blocks.

| Actions | Windows | Mac |
|---------|---------|-----|
| Create Paragraph | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>P</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>P</kbd> |
| Create Checklist | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>7</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>7</kbd> |
| Create Bullet List | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>8</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>8</kbd> |
| Create Numbered List | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>9</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>9</kbd> |
| Create Heading 1 | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>1</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>1</kbd> |
| Create Heading 2 | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>2</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>2</kbd> |
| Create Heading 3 | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>3</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>3</kbd> |
| Create Heading 4 | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>4</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>4</kbd> |
| Create Quote | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>Q</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>Q</kbd> |
| Create Code Block | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>K</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>K</kbd> |
| Create Callout | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>C</kbd> |
| Insert Image | <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>/</kbd> | <kbd>⌘</kbd> + <kbd>⌥</kbd> + <kbd>/</kbd> |
| Insert Divider | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>-</kbd> |<kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>-</kbd> |

## Block level actions

These shortcuts provide quick access to block-specific actions like duplication, deletion, indentation, and movement.
[For indent, both ctrl+] and tab are supported. For outdent, both ctrl+[ and shift+tab are supported.]

| Actions | Windows | Mac |
|---------|---------|-----|
| Duplicate Block | <kbd>Ctrl</kbd> + <kbd>D</kbd> | <kbd>⌘</kbd> + <kbd>D</kbd> |
| Delete Block | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>D</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>D</kbd> |
| Move Block Up | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>↑</kbd> |
| Move Block Down | <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>↓</kbd> |
| Increase Indent | <kbd>Ctrl</kbd> + <kbd>]</kbd> or <kbd>Tab</kbd> | <kbd>⌘</kbd> + <kbd>]</kbd> or <kbd>Tab</kbd> |
| Decrease Indent | <kbd>Ctrl</kbd> + <kbd>[</kbd> or <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⌘</kbd> + <kbd>[</kbd> or <kbd>⇧</kbd> + <kbd>Tab</kbd> |

## General editor operations

These shortcuts cover general editor functionality including undo/redo operations and clipboard actions.

| Actions | Windows | Mac |
|---------|---------|-----|
| Undo | <kbd>Ctrl</kbd> + <kbd>Z</kbd> | <kbd>⌘</kbd> + <kbd>Z</kbd> |
| Redo | <kbd>Ctrl</kbd> + <kbd>Y</kbd> | <kbd>⌘</kbd> + <kbd>Y</kbd> |
| Cut | <kbd>Ctrl</kbd> + <kbd>X</kbd> | <kbd>⌘</kbd> + <kbd>X</kbd> |
| Copy | <kbd>Ctrl</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>C</kbd> |
| Paste | <kbd>Ctrl</kbd> + <kbd>V</kbd> | <kbd>⌘</kbd> + <kbd>V</kbd> |
| Print | <kbd>Ctrl</kbd> + <kbd>P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> |

## Customizing keyboard shortcuts

You can customize shortcuts for menu-based actions, such as the `Slash Command Menu`, `Block Action Menu`, and `Context Menu`, by modifying the `Shortcut` property in their respective tag directives.

For other operations, you can customize the keyboard shortcuts by configuring the [KeyConfig](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html#Syncfusion_Blazor_BlockEditor_SfBlockEditor_KeyConfig) property in the [SfBlockEditor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.BlockEditor.SfBlockEditor.html) tag directive when initializing the Block Editor component. This allows you to override default shortcuts or add new ones according to your application's requirements.

In the example below, the shortcut for bold formatting is changed to <kbd>Alt</kbd> + <kbd>B</kbd> and for italic formatting to <kbd>Alt</kbd> + <kbd>I</kbd>.

```cshtml

@using Syncfusion.Blazor.BlockEditor;

<div id="container">
    <SfBlockEditor KeyConfig="@KeyConfig"></SfBlockEditor>
</div>

@code {

    private Dictionary<string, string> KeyConfig = new Dictionary<string, string>
    {
        { "Bold", "alt+b" },
        { "Italic", "alt+i" }
    };

}

```
