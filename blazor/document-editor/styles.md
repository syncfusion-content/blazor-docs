---
layout: post
title: Working with Styles in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about working with styles in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Working with Styles in Blazor DocumentEditor Component

Styles are useful for applying a set of formatting consistently throughout the document. In document editor, styles are created and added to a document programmatically or via the built-in Styles dialog.

## Styles definition overview

A Style in document editor should have the following properties:

* **name**: Name of the style. All styles in a document have a unique name, which is used as an identifier when applying the style.
* **type**: Specifies the document elements that the style will target. For example, paragraph or character.
* **next**: Specifies that the current style inherits the style set to this property. This is how hierarchical styles are defined.
* **link**: Provides a relation between the paragraph and character style.
* **characterFormat**: Specifies the properties of paragraph and character style.
* **paragraphFormat**: Specifies the properties of paragraph style.
* **basedOn**: Specifies that the current style inherits the style set to this property. This is how hierarchical styles are defined. It can be optional.

N> The style type should match the inherited style type. For example, it is not possible to have a character style inherit a paragraph style.

## Default style

The default style for span and paragraph properties is normal. It internally inherits the default style of the document loaded or document editor component.

## Style hierarchy

Each style initially checks its local value for the property that is being evaluated and turns to the style it is based on. If no local value is found, it turns to its default style. Style inheritance of different styles are listed as follows,

### Character style

Character styles are based only on other character styles. The inheritance is: Character properties are inherited from the base character style.

### Paragraph style

Paragraph styles are based on other paragraph styles or on linked styles. When a paragraph style is based on another paragraph style, the inheritance of the properties is as follows:
* Paragraph properties are inherited from the base paragraph style.
* Span properties are inherited from the base paragraph style.

When a paragraph style is based on a linked style, the inheritance of the properties is as follows:
* Paragraph properties are inherited from the paragraph style part in its base linked style.
* Span properties are inherited from the span style part in its base linked style.

### Linked style

Linked styles are composite styles and their components are paragraph and character styles with link between them. To apply paragraph properties, take the properties from the linked paragraph style. Similarly, to apply character properties, take the properties from linked character style. Linked styles are based on other linked styles or on paragraph styles.

When a linked style is based on a paragraph style, the hierarchy of the properties is as follows:

* Paragraph properties are inherited from the ‘basedOn’ paragraph style.
* Character properties are inherited from the ‘basedOn’ paragraph style.

When a linked style is based on another linked style, the hierarchy of the properties is as follows:

* Paragraph properties are inherited from the paragraph style part in its base linked style.
* Span properties are inherited from the span style part in its base linked style.

## Defining new styles

New Styles are defined and added to the style collection of the document. In this way, they will be discovered by the default UI and applied to the parts of a document.

## Defining a character style

The following example shows how to programmatically create a character style.

```cshtml
@using Syncfusion.Blazor.DocumentEditor;
<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    protected async void OnLoad(object args)
    {
        string styleJson = "{\"type\":\"Character\",\"name\":\"New CharacterStyle\",\"basedOn\":\"Default Paragraph Font\",\"characterFormat\":{\"fontSize\":16.0,\"fontFamily\":\"Calibri Light\",\"fontColor\":\"#2F5496\",\"bold\":true,\"italic\":true,\"underline\":\"Single\"}}";
        await container.DocumentEditor.Editor.CreateStyleAsync(styleJson);
        await container.DocumentEditor.Editor.ApplyStyleAsync("New CharacterStyle");
    }
}
```

## Defining a paragraph style

The following example shows how to programmatically create a paragraph style.

```cshtml
@using Syncfusion.Blazor.DocumentEditor;
<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    protected async void OnLoad(object args)
    {
        string styleJson = "{\"type\":\"Paragraph\",\"name\":\"New ParagraphStyle\",\"basedOn\":\"Normal\",\"characterFormat\":{\"fontSize\":16.0,\"fontFamily\":\"Calibri Light\",\"fontColor\":\"#2F5496\",\"bold\":true,\"italic\":true,\"underline\":\"Single\"},\"paragraphFormat\":{\"leftIndent\":0.0,\"rightIndent\":0.0,\"firstLineIndent\":0.0,\"beforeSpacing\":12.0,\"afterSpacing\":0.0,\"lineSpacing\":1.0791666507720947,\"lineSpacingType\":\"Multiple\",\"textAlignment\":\"Left\",\"outlineLevel\":\"Level1\"}}";
        await container.DocumentEditor.Editor.CreateStyleAsync(styleJson);
        await container.DocumentEditor.Editor.ApplyStyleAsync("New ParagraphStyle");
    }
}
```

## Defining a linked style

The following example shows how to programmatically create linked style.

```cshtml
@using Syncfusion.Blazor.DocumentEditor;

<SfDocumentEditorContainer @ref="container" EnableToolbar=true>
    <DocumentEditorContainerEvents Created="OnLoad"></DocumentEditorContainerEvents>
</SfDocumentEditorContainer>

@code {
    SfDocumentEditorContainer container;
    protected async void OnLoad(object args)
    {
        string styleJson = "{\"type\": \"Paragraph\",\"name\":\"New Linked\",\"basedOn\":\"Normal\",\"next\":\"Normal\",\"link\":\"New Linked Char\",\"characterFormat\":{\"fontSize\":16.0,\"fontFamily\":\"Calibri Light\",\"fontColor\":\"#2F5496\"},\"paragraphFormat\":{\"leftIndent\": 0.0,\"rightIndent\":0.0,\"firstLineIndent\":0.0,\"beforeSpacing\":12.0,\"afterSpacing\":0.0,\"lineSpacing\":1.0791666507720947,\"lineSpacingType\":\"Multiple\",\"textAlignment\":\"Left\",\"outlineLevel\":\"Level1\"}}";
        await container.DocumentEditor.Editor.CreateStyleAsync(styleJson);
        await container.DocumentEditor.Editor.ApplyStyleAsync("New Linked");
    }
}
```

## Applying a style

The styles are applied using the **applyStyle** method of **editorModule**, the parameter should be passed is the **Name** of the Style.

The styles of the **Character** type is applied to the currently selected part of the document. If there is no selection, the values that will be applied to the word at caret position. The styles of **Paragraph** type follow the same logic and are applied to all paragraphs in the selection or the current paragraph.

When there is no selection, styles of **Linked** type will change the values of the paragraph, and apply both the Paragraph and Character properties. When there is selection, Linked Style changes only the character properties of the selected text.

For example, the following line will apply the "New Linked" to the current paragraph.

```csharp
await container.DocumentEditor.Editor.ApplyStyleAsync("New Linked");
//Clear direct formatting and apply the specified style.
await container.DocumentEditor.Editor.ApplyStyleAsync("New Linked", true);
```

## Get Styles

You can get the styles in the document using the below code snippet.

```ts
//Get paragraph styles
object paragraphStyles = await container.DocumentEditor.GetStylesAsync(StyleType.Paragraph);
//Get character styles
object characterStyles = await container.DocumentEditor.GetStylesAsync(StyleType.Character);
```

You can refer to our [Blazor Word Processor](https://www.syncfusion.com/blazor-components/blazor-word-processor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Word Processor example](https://blazor.syncfusion.com/demos/document-editor/default-functionalities) to know how to render and configure the document editor.