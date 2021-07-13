# Built-in toolbar

The PDF Viewer comes with a powerful built-in toolbar to execute important actions such as page navigation, text search,view mode,download,print,bookmark, and thumbnails.

The following table shows built-in toolbar items and its actions:-

| Option | Description |
|---|---|
| OpenOption | This option provides an action to load the PDF documents to the PDF Viewer.|
| PageNavigationTool | This option provides an action to navigate the pages in the PDF Viewer. It contains GoToFirstPage,GoToLastPage,GotoPage,GoToNext, and GoToLast tools.|
| MagnificationTool |This option provides an action to magnify the pages either with predefined or user defined zoom factors in the PDF Viewer. Contains ZoomIn, ZoomOut, Zoom, FitPage and FitWidth tools|
| PanTool | This option provides an action for panning the pages in the PDF Viewer.|
| SelectionTool | This option provides an action to enable/disable the text selection in the PDF Viewer.|
| SearchOption | This option provides an action to search a word in the PDF documents.|
| PrintOption | This option provides an action to print the PDF document being loaded in the PDF Viewer.|
| DownloadOption |This Download option provides an action to download the PDF document that has been loaded in the PDF Viewer.|
| UndoRedoTool | This tool provides options to undo and redo the annotation actions performed in the PDF Viewer.|
| AnnotationEditTool | This tool provides options to enable or disable the edit mode of annotation in the PDF Viewer.|

## Show/Hide the default toolbar

The PDF Viewer has an option to show or hide the complete default toolbar. You can achieve this by using following two ways.,

* **Show/Hide toolbar using enableToolbar API as in the following code snippet**

```html
    <div style="width:100%;height:600px">
        <EjsPdfViewer id="pdfviewer" documentPath="PDF_Succinctly.pdf" enableToolbar="false"
         serviceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer" style="height: 640px;width: 100%" />
    </div>
    @functions{
    }
```

* **Show/Hide toolbar using showToolbar as in the following code snippet**

```html
    <button id="showtoolbarItemBtn">ShowToolbar</button>
    <div style="width:100%;height:600px">
        <EjsPdfViewer id="pdfviewer" documentPath="PDF_Succinctly.pdf" documentLoad="@documentLoad"
         serviceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer" style="height: 640px;width: 100%" />
    </div>
    @functions{
    protected async void documentLoad(object args)
    {
    await JsRuntime.InvokeAsync<bool>
    ("documentLoaded");
    }
    }
```

```javascript
    function documentLoaded() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        document.getElementById('showtoolbarItemBtn').addEventListener('click', function() {
            pdfViewer.toolbar.showToolbar(false);
        });
    }
```

## Show/Hide the default toolbaritem

The PDF Viewer has an option to show or hide these grouped items in the default toolbar.

* **Show/Hide toolbaritem using toolbarSettings as in the following code snippet.**

```html
    <div style="width:100%;height:600px">
        <EjsPdfViewer id="pdfviewer" documentPath="PDF_Succinctly.pdf" toolbarSettings="@ToolbarSettings"
         serviceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer" style="height: 640px;width: 100%" />
    </div>
    @functions{
        public object ToolbarSettings = new Syncfusion.EJ2.RazorComponents.PdfViewer.PdfViewerToolbarSettings{ ShowTooltip = true };
    }
```

* **Show/Hide toolbaritem using showToolbaritem as in the following code snippet**

```html
    <button id="showtoolbarItemBtn">ShowToolbarItem</button>
    <div style="width:100%;height:600px">
        <EjsPdfViewer id="pdfviewer" documentPath="PDF_Succinctly.pdf" documentLoad="@documentLoad"
         serviceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer" style="height: 640px;width: 100%" />
    </div>
    @functions{
    protected async void documentLoad(object args)
    {
    await JsRuntime.InvokeAsync<bool>
    ("documentLoaded");
    }
    }
```

```javascript
    function documentLoaded() {
        var pdfViewer = document.getElementById('pdfviewer').ej2_instances[0];
        document.getElementById('showtoolbarItemBtn').addEventListener('click', function() {
            pdfViewer.toolbar.ShowToolbarItem(["OpenOption"],false);
        });
    }
```

## See also

* [Toolbar customization](./how-to/customization)
* [Feature Modules](./feature-module)