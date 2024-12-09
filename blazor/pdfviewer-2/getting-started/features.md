---
layout: post
title: Overview of Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn about overview of the Syncfusion Blazor SfPdfViewer component and much more details.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Overview of Blazor SfPdfViewer Component

The new Blazor SfPdfViewer component allows users to view, edit, print, and download PDF files without the web service dependency in Blazor applications. It is designed to be fast and responsive and comes with the same feature set as the previous PDF Viewer. It is easy to use and can be integrated into both Blazor Server and WASM applications with minimal effort.

The Blazor SfPdfViewer component shares the same key features as the [Blazor PDF Viewer component](https://blazor.syncfusion.com/documentation/pdfviewer/getting-started/features), but this new component has some advantages over the old component.

## Performance Improvement

We have enhanced the performance in rendering, scrolling, zooming, panning, and printing.  

## Elimination of Service Dependency

The old PDF viewer component required a separate [Service URL](https://blazor.syncfusion.com/documentation/pdfviewer/getting-started/web-assembly-application) to load the document. However, in the [NextGen PDF Viewer](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/web-assembly-application), we have eliminated the need for a service URL. Now, the document can be loaded offline without making a service call. 

## Common Package

In the previous component, we had different packages for different operating systems such as [Windows](https://www.nuget.org/packages/Syncfusion.Blazor.PdfViewerServer.Windows), [Linux](https://www.nuget.org/packages/Syncfusion.Blazor.PdfViewerServer.Linux), and [OSX](https://www.nuget.org/packages/Syncfusion.Blazor.PdfViewerServer.OSX). In the [NextGen](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer) version, we have introduced common packages that work across all environments. 

## Reduced Server Calls

The old PDF viewer component required numerous C# calls to retrieve document information such as text on the page, hyperlinks, and page images. In the NextGen PDF Viewer, we have shifted these functionalities to the client side, resulting in improved performance. 

## Some of the key features are listed below

* Accurate and reliable rendering of PDF pages.
* Provides easy page navigation with,
    * [Thumbnail page view](https://blazor.syncfusion.com/documentation/pdfviewer-2/navigation#page-thumbnail-navigation)
    * [Bookmark panel](https://blazor.syncfusion.com/documentation/pdfviewer-2/navigation#bookmark-navigation)
    * [Hyperlink navigation](https://blazor.syncfusion.com/documentation/pdfviewer-2/navigation#hyperlink-navigation)
    * [Table of content navigation](https://blazor.syncfusion.com/documentation/pdfviewer-2/navigation#table-of-content-navigation)
* Core interactions
    * [Zooming](https://blazor.syncfusion.com/documentation/pdfviewer-2/magnification) and [panning](https://blazor.syncfusion.com/documentation/pdfviewer-2/interaction#panning-mode)
    * [Text searching](https://blazor.syncfusion.com/documentation/pdfviewer-2/text-search)
    * Text selection and copy
* [Print](https://blazor.syncfusion.com/documentation/pdfviewer-2/print) PDF file.
* Annotate PDF with different types of annotations such as,
    * [Highlight](https://blazor.syncfusion.com/documentation/pdfviewer-2/annotation/text-markup-annotation#highlight-a-text), [underline](https://blazor.syncfusion.com/documentation/pdfviewer-2/annotation/text-markup-annotation#underline-a-text), and [strikeout](https://blazor.syncfusion.com/documentation/pdfviewer-2/annotation/text-markup-annotation#strikethrough-a-text) annotation
    * [Shape annotation](https://blazor.syncfusion.com/documentation/pdfviewer-2/annotation/shape-annotation): Rectangle, circle, polygon, line, and arrow.
    * [Stamp annotation](https://blazor.syncfusion.com/documentation/pdfviewer-2/annotation/stamp-annotation): Built-in and custom stamp
    * [Measurement annotation](https://blazor.syncfusion.com/documentation/pdfviewer-2/annotation/measurement-annotation)
    * [Free text annotation](https://blazor.syncfusion.com/documentation/pdfviewer-2/annotation/free-text-annotation)
    * Add a [comment](https://blazor.syncfusion.com/documentation/pdfviewer-2/annotation/comments) or [note](https://blazor.syncfusion.com/documentation/pdfviewer-2/annotation/sticky-notes-annotation) for all type of annotations
* [FormFilling](https://blazor.syncfusion.com/documentation/pdfviewer-2/form-filling)
* [Handwritten Signature](https://blazor.syncfusion.com/documentation/pdfviewer-2/hand-written-signature)

### Supported Features: Desktop vs Mobile

The table below provides a list of supported and non-supported features on both desktop and mobile devices.

|Feature|Desktop|Mobile Devices|
|--|--|--|	
|Keyboard interaction|	Yes|	No|
|Opening file different origin|	Yes|	Yes|
|Saving a file to a different origin|	Yes	|Yes|
|Toolbar|	Yes	|No|
|Mobile toolbar|	No	|Yes|
|Navigation toolbar|	Yes	|No|
|Page Navigation|	Yes|	No|
|Magnification|	Yes|	Yes|
|Text search|	Yes|	Yes|
|Text selection|	Yes|	No|
|Pan mode|	Yes|	Yes|
|Hand Written Signature|	Yes|	Yes|
|Annotation rendering|	Yes|	Yes|
|Annotation interaction|	Yes|	Yes|
|Annotation property editing|	Yes|	No|
|Add annotation through touch|	Yes|	No|
|Import/export annotation|	Yes|	Yes|
|From fields rendering|	Yes|	Yes|

N> Enable desktop mode on mobile devices using the [EnableDesktopMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_EnableDesktopMode) property to view the toolbar as in desktop.

N> Syncfusion<sup style="font-size:70%">&reg;</sup> provides the SfPdfViewer component for both Blazor Server and Blazor WebAssembly applications.
<br />For both **Blazor WebAssembly App** and **Blazor Server App** use [SfPdfViewer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PdfViewer.SfPdfViewer.html) component in Syncfusion.Blazor.SfPdfViewer NuGet package. This component will not requires server-side processing to render the PDF files through web service.
<br/>* For Windows, Linux and Mac (OSX) uses the sample Nuget [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer)

N> You can refer to the [Blazor SfPdfViewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor SfPdfViewer example](https://blazor.syncfusion.com/demos/pdf-viewer-2/default-functionalities?theme=fluent) to understand how to explain core features of PDF Viewer.
