---
layout: post
title: Increase the connection buffer size in Blazor SfPdfViewer Component | Syncfusion
description: Learn here all about how to increase the connection buffer size in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Increase the connection buffer size in Blazor SfPdfViewer Component

The Syncfusion's Blazor SfPdfViewer component allows to increase the connection buffer size by adding the below service in program.cs file if the size of the SfPdfViewer is too large.

```cshtml
builder.Services.AddServerSideBlazor().AddHubOptions(o => { o.MaximumReceiveMessageSize = 102400000; });
```

[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Load%20larger%20document%20without%20error-SfPdfViewer).
