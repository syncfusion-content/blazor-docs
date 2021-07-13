# Text Markup Annotation

The PDF Viewer control provides the options to add, edit, and delete text markup annotations such as highlight, underline, and strikethrough annotations in the PDF document.

![Alt text](./images/text_markup_annotation.png)

## Highlight a text

There are two ways to highlight a text in the PDF document:

1. Using the context menu
    * Select a text in the PDF document and right-click it.
    * Select **Highlight** option in the context menu that appears.

![Alt text](./images/highlight_context.png)

<!-- markdownlint-disable MD029 -->
2. Using the annotation toolbar
    * Click the **Edit Annotation** button in the PDF Viewer toolbar. A toolbar appears below it.
    * Select the **Highlight** button in the annotation toolbar. It enables the highlight mode.
    * Select the text and the highlight annotation will be added.
    * You can also select the text and apply the highlight annotation using the **Highlight** button.

![Alt text](./images/highlight_button.png)

In the pan mode, if the highlight mode is entered, the PDF Viewer control will switch to text select mode to enable the text selection for highlighting the text.

Refer to the following code snippet to switch to highlight mode.

```html
    <!--Element to set text markup annotation mode-->
    <button id="set">Highlight</button>
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
        document.getElementById('set').addEventListener('click', function() {
            pdfViewer.annotation.setAnnotationMode('Highlight');
        });
    }
```

Refer to the following code snippet to switch back to normal mode from highlight mode.

```html
    <!--Element to set text markup annotation mode-->
    <button id="set">Highlight</button>
    <!--Element to set normal mode-->
    <button id="setNone">Normal Mode</button>
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
        document.getElementById('set').addEventListener('click', function() {
            pdfViewer.annotation.setAnnotationMode('Highlight');
        });

        document.getElementById(‘setNone’).addEventListener('click', function() {
            pdfViewer.annotation.setAnnotationMode('None');
        });
    }
```

## Underline a text

There are two ways to underline a text in the PDF document:

1. Using the context menu
    * Select a text in the PDF document and right-click it.
    * Select **Underline** option in the context menu that appears.

![Alt text](./images/underline_context.png)

<!-- markdownlint-disable MD029 -->
2. Using the annotation toolbar
    * Click the **Edit Annotation** button in the PDF Viewer toolbar. A toolbar appears below it.
    * Select the **Underline** button in the annotation toolbar. It enables the underline mode.
    * Select the text and the underline annotation will be added.
    * You can also select the text and apply the underline annotation using the **Underline** button.

![Alt text](./images/underline_button.png)

In the pan mode, if the underline mode is entered, the PDF Viewer control will switch to text select mode to enable the text selection for underlining the text.

Refer to the following code snippet to switch to underline mode.

```html
    <!--Element to set text markup annotation mode-->
    <button id="set">Underline</button>
    <div style="width:100%;height:600px">
        <EjsPdfViewer id='pdfviewer' documentPath='PDF_Succinctly.pdf' documentLoad="@documentLoad"
         serviceUrl='https://ej2services.syncfusion.com/production/web-services/api/pdfviewer' style='height: 640px;width: 100%' />
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
        document.getElementById('set').addEventListener('click', function() {
            pdfViewer.annotation.setAnnotationMode('Underline');
        });
    }
```

Refer to the following code snippet to switch back to normal mode from underline mode.

```html
    <!--Element to set text markup annotation mode-->
    <button id="set">Underline</button>
    <!--Element to set normal mode-->
    <button id="setNone">Normal Mode</button>
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
        document.getElementById('set').addEventListener('click', function() {
            pdfViewer.annotation.setAnnotationMode('Underline');
        });

        document.getElementById(‘setNone’).addEventListener('click', function() {
            pdfViewer.annotation.setAnnotationMode('None');
        });
    }
```

## Strikethrough a text

There are two ways to strikethrough a text in the PDF document:

1. Using the context menu
    * Select a text in the PDF document and right-click it.
    * Select **Strikethrough** option in the context menu that appears.

![Alt text](./images/strikethrough_context.png)

<!-- markdownlint-disable MD029 -->
2. Using the annotation toolbar
    * Click the **Edit Annotation** button in the PDF Viewer toolbar. A toolbar appears below it.
    * Select the **Strikethrough** button in the annotation toolbar. It enables the strikethrough mode.
    * Select the text and the strikethrough annotation will be added.
    * You can also select the text and apply the strikethrough annotation using the **Strikethrough** button.

![Alt text](./images/strikethrough_button.png)

In the pan mode, if the strikethrough mode is entered, the PDF Viewer control will switch to text select mode to enable the text selection for striking through the text.

Refer to the following code snippet to switch to strikethrough mode.

```html
    <!--Element to set text markup annotation mode-->
    <button id="set">Strikethrough</button>
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
        document.getElementById('set').addEventListener('click', function() {
            pdfViewer.annotation.setAnnotationMode('Strikethrough');
        });
    }
```

Refer to the following code snippet to switch back to normal mode from underline mode.

```html
    <!--Element to set text markup annotation mode-->
    <button id="set">Strikethrough</button>
    <!--Element to set normal mode-->
    <button id="setNone">Normal Mode</button>
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
        document.getElementById('set').addEventListener('click', function() {
            pdfViewer.annotation.setAnnotationMode('Strikethrough');
        });

        document.getElementById(‘setNone’).addEventListener('click', function() {
            pdfViewer.annotation.setAnnotationMode('None');
        });
    }
```

## Deleting a text markup annotation

The selected annotation can be deleted by the following ways:

1. Using Delete key
    * Select the annotation to be deleted.
    * Click the Delete key in the keyboard. The selected annotation will be deleted.

2. Using the annotation toolbar
    * Select the annotation to be deleted.
    * Click the **Delete Annotation** button in the annotation toolbar. The selected annotation will be deleted.

![Alt text](./images/delete_button.png)

## Editing the properties of the text markup annotation

The color and the opacity of the text markup annotation can be edited using the Edit Color tool and the Edit Opacity tool in the annotation toolbar.

### Editing color

The color of the annotation can be edited using the color palette provided in the Edit Color tool.

![Alt text](./images/edit_color.png)

### Editing opacity

The opacity of the annotation can be edited using the range slider provided in the Edit Opacity tool.

![Alt text](./images/edit_opacity.png)

## Setting default properties during control initialization

The properties of the text markup annotation can be set before creating the control using highlightSettings, underlineSettings, and strikethroughSettings.

>After editing the default color and opacity using the Edit Color tool and Edit Opacity tool, they will be changed to the selected values.

Refer to the following code snippet to set the default annotation settings.

```html
    <div style="width:100%;height:600px">
        <EjsPdfViewer id="pdfviewer" documentPath="PDF_Succinctly.pdf" serviceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer" style="height: 640px;width: 100%"
          highlightSettings="@HighlightSettings" underlineSettings="@UnderlineSettings" strikethroughSettings="@StrikethroughSettings" />
    </div>
    @functions {
        public object HighlightSettings = new Syncfusion.EJ2.RazorComponents.PdfViewer.PdfViewerHighlightSettings{ Author="Guest User",Subject="Important",Color="#ff0000",Opacity=0.9,ModifiedDate="" };
        public object UnderlineSettings = new Syncfusion.EJ2.RazorComponents.PdfViewer.PdfViewerUnderlineSettings{Author="Guest User",Subject="Points to be remembered",Color="#00ffff",Opacity=0.9,ModifiedDate=""};
        public object StrikethroughSettings = new Syncfusion.EJ2.RazorComponents.PdfViewer.PdfViewerStrikethroughSettings {Author="Guest User",Subject="Not Important",Color="#ff00ff",Opacity=0.9,ModifiedDate=""};
    }
```

## Performing undo and redo

The PDF Viewer performs undo and redo for the changes made in the PDF document. In text markup annotation, undo and redo actions are provided for:

* Inclusion of the text markup annotations.
* Deletion of the text markup annotations.
* Change of either color or opacity of the text markup annotations.

Undo and redo actions can be done by the following ways:

1. Using keyboard shortcuts:
    After performing a text markup annotation action, you can undo it by using Ctrl + Z shortcut and redo by using Ctrl + Y shortcut.
2. Using toolbar:
    Undo and redo can be done using the **Undo** tool and **Redo** tool provided in the toolbar.

Refer to the following code snippet for calling undo and redo actions from the client-side.

```html
    <!--Element to call undo-->
    <button id="undo">Undo</button>
    <!--Element to call redo-->
    <button id="redo">Redo</button>
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
        document.getElementById('undo').addEventListener('click', function() {
            pdfViewer.undo();
        });

        document.getElementById(‘redo’).addEventListener('click', function() {
            pdfViewer.redo();
        });
    }
```

## Saving the text markup annotation

When you click the download tool in the toolbar, the text markup annotations will be saved in the PDF document. This action will not affect the original document.

## Printing the text markup annotation

When the print tool is selected in the toolbar, the PDF document will be printed along with the text markup annotations added to the pages. This action will not affect the original document.

## Disabling text markup annotation

The PDF Viewer control provides an option to disable the text markup annotation feature. The code snippet for disabling the feature is as follows.

```html
    <div style="width:100%;height:600px">
        <EjsPdfViewer id="pdfviewer" documentPath="PDF_Succinctly.pdf" enableTextMarkupAnnotation="false"
         serviceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer" style="height: 640px;width: 100%" />
    </div>
```

## See also

* [Toolbar items](./toolbar)
* [Feature Modules](./feature-module)