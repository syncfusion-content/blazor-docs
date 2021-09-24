---
layout: post
title: CDN Resources | Blazor | Syncfusion
description: Learn here about that how to getting the information about CDN Resources for Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# CDN Resources

This section provides information about available CDN Resources for Syncfusion Blazor Components and how it is to be used in Blazor Application.

We can use themes and scripts from CDN resources instead of using those themes and styles from Packages's static assets by set `IgnoreScriptIsolation` as true in `AddSyncfusionBlazor` service in `~/Startup.cs` file for Blazor Server app or `~/Program.cs` file for Blazor WebAssembly app.

## Types

* Version based CDN.
* Global CDN.

### Version based CDN

It will contains the latest release contents(Themes and Scripts) for Syncfusion Blazor Components.

    ```html
    <head>
        ....
        ....
        <link href="https://cdn.syncfusion.com/blazor/{{version}}/styles/{{Themes}}.css" rel="stylesheet" />
        <script src="https://cdn.syncfusion.com/blazor/{{version}}/syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>
    ```

> Note: PdfViewer and DocumentEditor has as a separate CDN Scripts resources.

To add CDN script reference for PdfViewer.

    ```html
    <head>
        ....
        ....
        <link href="https://cdn.syncfusion.com/blazor/{{version}}/styles/{{Themes}}.css" rel="stylesheet" />
        <script src="https://cdn.syncfusion.com/blazor/{{version}}/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
    </head>
    ```
To add version CDN script reference for DocumentEditor.

    ```html
    <head>
        ....
        ....
        <link href="https://cdn.syncfusion.com/blazor/{{version}}/styles/{{Themes}}.css" rel="stylesheet" />
        <script src="https://cdn.syncfusion.com/blazor/{{version}}/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
    </head>
    ```


### Global CDN

It will contains the latest release contents(Themes and Scripts) for Syncfusion Blazor Components.

    ```html
    <head>
        ....
        ....
        <link href="https://cdn.syncfusion.com/blazor/styles/{{Themes}}.css" rel="stylesheet" />
        <script src="https://cdn.syncfusion.com/blazor/syncfusion-blazor.min.js" type="text/javascript"></script>
    </head>
    ```

> Note: PdfViewer and DocumentEditor has as a separate CDN Scripts resources.

To add CDN script reference for PdfViewer.

    ```html
    <head>
        ....
        ....
        <link href="https://cdn.syncfusion.com/blazor/styles/{{Themes}}.css" rel="stylesheet" />
        <script src="https://cdn.syncfusion.com/blazor/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
    </head>
    ```
To add CDN script reference for DocumentEditor.

    ```html
    <head>
        ....
        ....
        <link href="https://cdn.syncfusion.com/blazor/styles/{{Themes}}.css" rel="stylesheet" />
        <script src="https://cdn.syncfusion.com/blazor/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
    </head>
    ```

Also, we can use the [Blazor Custom Resource Generator](https://blazor.syncfusion.com/crg) (CRG) web tool, generate the required components scripts and styles. Refer [here for how to generate the component wise scripts manually](../custom-resource-generator/)