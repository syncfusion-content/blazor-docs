---
layout: post
title: Headers and Footers in Blazor DocumentEditor Component | Syncfusion
description: Checkout and learn here all about Headers and Footers in Syncfusion Blazor DocumentEditor component and more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Headers and Footers in Blazor DocumentEditor Component

[Blazor Document Editor](https://www.syncfusion.com/blazor-components/blazor-word-processor) supports headers and footers in its document. Each section in the document can have the following types of headers and footers:

* First page: Used only on the first page of the section.
* Even pages: Used on all even numbered pages in the section.
* Default: Used on all pages of the section, where first or even pages are not applicable or not specified.

You can define this by setting format properties of the corresponding section using the following sample code.

```csharp
//Defines whether different header footer is required for first page of the section
await container.DocumentEditor.Selection.SectionFormat.SetDifferentFirstPageAsync(true);
//Defines whether different header footer is required for odd and even pages in the section
await container.DocumentEditor.Selection.SectionFormat.SetDifferentOddAndEvenPagesAsync(true);
```

## Go to header footer region

Double click in header or footer region to move the selection into it. You can also do this by using the following code.

```csharp
await container.DocumentEditor.Selection.GoToHeaderAsync();

await container.DocumentEditor.Selection.GoToFooterAsync();
```

## Header and footer distance

You can define the distance of header region content from the top of the page. Refer to the following sample code.

```csharp
await container.DocumentEditor.Selection.SectionFormat.SetHeaderDistanceAsync(36);
```

Same way, you can define the distance of footer region content from the bottom of the page. Refer to the following sample code.

```csharp
await container.DocumentEditor.Selection.SectionFormat.SetFooterDistanceAsync(36);
```

## Close header footer region

Move the selection to the document body from header or footer region by double clicking or tapping the document area. You can also perform this by using the following sample code.

```csharp
await container.DocumentEditor.Selection.CloseHeaderFooterAsync();
```

You can also explore our [Blazor Word Processor](https://blazor.syncfusion.com/demos/document-editor/default-functionalities?theme=bootstrap5) example to know how to render and configure the document editor.
