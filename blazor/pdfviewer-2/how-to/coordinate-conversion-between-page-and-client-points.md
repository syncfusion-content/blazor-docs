---
layout: post
title: Coordinate Conversion Between Page and Client Points | Syncfusion
description: Learn here all about how to perform coordinate conversion between page and client points into Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Coordinate Conversion Between Page and Client Points.

The PDF viewer provides two essential conversion methods for translating between the document's internal page coordinate system and the client's browser coordinate system:

1. **Converting Page Coordinates to Client Coordinates**

   - `convertPagePointToClientPoint`: Transforms document page coordinates to browser viewport coordinates

   

2. **Converting Client Coordinates to Page Coordinates**

   - `convertClientPointToPagePoint`: Transforms browser viewport coordinates to document page coordinates

## Converting Page Coordinates to Client Coordinates
- **ConvertPagePointToClientPoint**

This method is used to translate a point from the document's page coordinate system to the browser's client (viewport) coordinate system. 

The following code example shows how to convert page coordinates to client coordinates into the blazor component.

**Step 1:** Add a script file to your application and refer it to the head tag.

```cshtml

<head>
    <script src="index.js" type="text/javascript"></script>
</head>

```

**Step 2:** Add the following code to render the JS component in the blazor to the newly added JS file.

```javascript

window.convertPagePointToClientPoint = function (pagePoint) {
    const pagediv = document.getElementsByClassName('e-pv-page-div')[pageIndex];
    const rect = pagediv.getBoundingClientRect();
    return {
        x: pagePoint.x + rect.left,
        y: pagePoint.y + rect.top
    };
};

```

**Step 3:** Add the following code to the blazor component.

```cshtml

<div style="display: flex; height: 100vh; width: 100vw;">
    <div style="width: 40%; height: 100%;">
    </div>
    <div style="width: 60%; height: 100%;">
        <SfPdfViewer2 @ref="SfPdfViewer2"
        DocumentPath="wwwroot/Invoice.pdf"
        Height="100%"
        Width="100%">
            <PdfViewerEvents OnPageClick="OnPageClick"></PdfViewerEvents>
        </SfPdfViewer2>
    </div>
</div>

@inject IJSRuntime JS

@code {
    private SfPdfViewer2 SfPdfViewer2;

    private async void OnPageClick(PageClickEventArgs args)
    {
        Point pagePoint = new Point { x = args.PageX, y = args.PageY };
        Point clientPoint = await JS.InvokeAsync<Point>("convertPagePointToClientPoint", pagePoint);
        Console.WriteLine($"PagePoint to ClientPoint : X: {clientPoint.x} Y: {clientPoint.y} ");
    }
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}

```
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Coordinate%20Conversion%20Between%20Page%20and%20Client%20Points)

## Converting Client Coordinates To Page Coordinates
- **ConvertClientPointToPagePoint** 

This method is used to translate a point from the browser's client (viewport) coordinate system to the document's page coordinate system.

The following code example shows how to convert client coordinates to page coordinates into the blazor component.

**Step 1:** Add a script file to your application and refer it to the head tag.

```cshtml

<head>
    <script src="index.js" type="text/javascript"></script>
</head>

```

**Step 2:** Add the following code to render the JS component in the blazor to the newly added JS file.

```javascript

window.convertClientPointToPagePoint = function (clientPoint) {
    const pagediv = document.getElementsByClassName('e-pv-page-div')[0];
    const rect = pagediv.getBoundingClientRect();
    return {
        x: clientPoint.x - rect.left,
        y: clientPoint.y - rect.top
    };
};

```

**Step 3:** Add the following code to the blazor component.

```cshtml

<div style="display: flex; height: 100vh; width: 100vw;">
    <div style="width: 40%; height: 100%;">
    </div>
    <div @onmousedown=HandleMouseDown style="width: 60%; height: 100%;">
        <SfPdfViewer2 @ref="SfPdfViewer2"
        DocumentPath="wwwroot/Invoice.pdf"
        Height="100%"
        Width="100%">
        </SfPdfViewer2>
    </div>
</div>

@inject IJSRuntime JS

@code {
    private SfPdfViewer2 SfPdfViewer2;
    private int currentClientX;
    private int currentClientY;

    private async void HandleMouseDown(MouseEventArgs e)
    {
        currentClientX = (int)e.ClientX;
        currentClientY = (int)e.ClientY;
        Point clientPoint = new Point { x = currentClientX, y = currentClientY };
        Point pagePoint = await JS.InvokeAsync<Point>("convertClientPointToPagePoint", clientPoint);
        Console.WriteLine($"ClientPoint to PagePoint : X: {pagePoint.x} Y: {pagePoint.y} ");
    }
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }
    }
}
```
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Common/Coordinate%20Conversion%20Between%20Page%20and%20Client%20Points)