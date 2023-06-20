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
    * Thumbnail page view
    * Bookmark panel
    * Hyperlink navigation
    * Table of content navigation
* Core interactions
    * Zooming and panning
    * Text searching
    * Text selection and copy
* Print PDF file.
* Annotate PDF with different types of annotations such as,
    * Highlight, underline, and strikeout annotation
    * Shape annotation: Rectangle, circle, polygon, line, and arrow.
    * Stamp annotation: Built-in and custom stamp
    * Measurement annotation
    * Free text annotation
    * Add a comment or note for all type of annotations
* FormFilling
* Handwritten Signature

N> Syncfusion provides same SfPdfViewer component for Blazor Server and Blazor WebAssembly applications.

N> You can refer to the [Blazor SfPdfViewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) feature tour page for its groundbreaking feature representations. You can also explore the [Blazor SfPdfViewer example](https://blazor.syncfusion.com/demos/pdf-viewer-2/default-functionalities?theme=fluent) to understand how to explain core features of PDF Viewer.
