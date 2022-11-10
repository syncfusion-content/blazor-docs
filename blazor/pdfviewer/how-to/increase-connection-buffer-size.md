---
layout: post
title: Increase the connection buffer size in Blazor PDF Viewer | Syncfusion
description: Learn here all about how to increase the connection buffer size in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Increase the connection buffer size in Blazor PDF Viewer Component

The Syncfusion's Blazor PDF Viewer component allows to increase the connection buffer size by adding the below service in program.cs file if the size of the PDFViewer is too large.

```cshtml
builder.Services.AddServerSideBlazor().AddHubOptions(o => { o.MaximumReceiveMessageSize = 102400000; });
```

> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Maximum%20Receive%20Message%20Size/Set%20Buffer%20limit).
