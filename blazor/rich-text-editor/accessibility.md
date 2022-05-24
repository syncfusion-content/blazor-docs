---
layout: post
title: Accessibility in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor RichTextEditor component and more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Accessibility in Blazor RichTextEditor Component

The Rich Text Editor component has been designed, keeping in mind the WAI-ARIA specifications, and applies the WAI-ARIA roles, states, and properties. This component is characterized by complete ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

## ARIA attributes

The toolbar of Rich Text Editor, assigned the role of Toolbar and has the following list of ARIA attributes:

| **Roles and Attributes** | **Functionalities** |
| --- | --- |
| role="toolbar" | This attribute added to the toolbar element describes the actual role of the element. |
| aria-orientation | Indicates the toolbar orientation. Default value is horizontal. |
| aria-haspopup | Indicates the popup mode of the toolbar. The default value is false. When popup mode is enabled, attribute value has to be changed to true. |
| aria-disabled | Indicates the disabled state of the toolbar. |

For further details of toolbar ARIA attributes, refer to the accessibility of [Toolbar](../toolbar/accessibility) documentation.

The Rich Text Editor element is assigned the role of application.

| **Roles and Attributes** | **Functionalities** |
| --- | --- |
| role="application" | This attribute added to the Rich Text Editor element describes the actual role of the element. |
| aria-disabled | Indicates the disabled state of the Rich Text Editor. |

{% tabs %}
{% highlight razor tabtitle="~/aria-attribute.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor ShowCharCount="true">
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

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/aria-attribute.razor %}

{% endhighlight %}

![Accessibility in Blazor RichTextEditor](./images/blazor-richtexteditor-accessibility.png)


## Keyboard Support

The editor has full keyboard accessibility that includes shortcuts to open and other actions with toolbar items, drop-down lists, and dialogs.

## HTML Editor Shortcuts

You can use the following key shortcuts when the Rich Text Editor renders with `HTML` editMode.

| Actions | Keyboard shortcuts |
|----------------|---------|
| Toolbar focus | <kbd>ALT</kbd> + <kbd>F10</kbd> |
| Insert link | <kbd>CTRL</kbd> + <kbd>K</kbd> |
| Insert image | <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>I</kbd> |
| Insert table | <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>E</kbd> |
| Undo | <kbd>CTRL</kbd> + <kbd>Z</kbd> |
| Redo | <kbd>CTRL</kbd> + <kbd>Y</kbd> |
| Copy | <kbd>CTRL</kbd> + <kbd>C</kbd> |
| Cut | <kbd>CTRL</kbd> + <kbd>X</kbd> |
| Paste| <kbd>CTRL</kbd> + <kbd>V</kbd> |
| Bold| <kbd>CTRL</kbd> + <kbd>B</kbd> |
| Italic| <kbd>CTRL</kbd> + <kbd>I</kbd> |
| Underline| <kbd>CTRL</kbd> + <kbd>U</kbd> |
| Strikethrough| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>S</kbd> |
| Uppercase| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>U</kbd> |
| Lowercase| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>L</kbd> |
| Superscript| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>=</kbd> |
| Subscript| <kbd>CTRL</kbd> + <kbd>=</kbd> |
| Indents| <kbd>CTRL</kbd> + <kbd>]</kbd> |
| Outdents| <kbd>CTRL</kbd> + <kbd>[</kbd> |
| HTML source | <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>H</kbd> |
| Full screen| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>F</kbd> |
| Exit Full screen| <kbd>Esc</kbd> |
| Justify center| <kbd>CTRL</kbd> + <kbd>E</kbd> |
| Justify full | <kbd>CTRL</kbd> + <kbd>`J</kbd> |
| Justify left | <kbd>CTRL</kbd> + <kbd>L</kbd> |
| Justify right | <kbd>CTRL</kbd> + <kbd>R</kbd> |
| Clear format | <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>R</kbd> |
| Ordered list | <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>O</kbd> |
| Unordered list | <kbd>CTRL</kbd> + <kbd>ALT</kbd> + <kbd>O</kbd> |

## Markdown Editor Shortcuts

You can use the following key shortcuts when the Rich Text Editor renders with `Markdown` editMode.

| Actions | Keyboard shortcuts |
|----------------|---------|
| Toolbar focus| <kbd>ALT</kbd> + <kbd>F10</kbd> |
| Insert link| <kbd>CTRL</kbd> + <kbd>K</kbd> |
| Insert image| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>I</kbd> |
| Insert table| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>E</kbd> |
| Undo| <kbd>CTRL</kbd> + <kbd>Z</kbd> |
| Redo| <kbd>CTRL</kbd> + <kbd>Y</kbd> |
| Copy| <kbd>CTRL</kbd> + <kbd>C</kbd> |
| Cut| <kbd>CTRL</kbd> + <kbd>X</kbd> |
| Paste| <kbd>CTRL</kbd> + <kbd>V</kbd> |
| Bold| <kbd>CTRL</kbd> + <kbd>B</kbd> |
| Italic| <kbd>CTRL</kbd> + <kbd>i</kbd> |
| Strikethrough| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>S</kbd> |
| Uppercase| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>U</kbd> |
| Lowercase| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>L</kbd> |
| Superscript| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>=</kbd> |
| Subscript| <kbd>CTRL</kbd> + <kbd>=</kbd> |
| Full screen| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>F</kbd> |
| Exit Full screen| <kbd>Esc</kbd> |
| Ordered list| <kbd>CTRL</kbd> + <kbd>SHIFT</kbd> + <kbd>O</kbd> |
| Unordered list| <kbd>CTRL</kbd> + <kbd>ALT</kbd> + <kbd>O</kbd> |

{% tabs %}
{% highlight razor tabtitle="~/markdown-shortcuts.razor" %}

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

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/markdown-shortcuts.razor %}

{% endhighlight %}

![Blazor RichTextEditor with Key Configuration](./images/blazor-richtexteditor-key-configuration.png)

## Custom Key Configuration

Customize the key config for the keyboard interaction of Rich Text Editor, using the `KeyConfigure` property.

In the following code block, customize the bold and italic, toolbar actions with `ctrl+1`, `ctrl+2` respectively.

{% tabs %}
{% highlight razor tabtitle="~/custom-key-config.razor" %}

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

{% endhighlight %}
{% endtabs %}

{% highlight cshtml %}

{% include_relative code-snippet/custom-key-config.razor %}

{% endhighlight %}

> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to knows how to render and configure the rich text editor tools.

## See Also

* [Globalization](./globalization/)
* [Accessibility](./accessibility/)