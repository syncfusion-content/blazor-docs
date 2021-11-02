---
layout: post
title: Resolve the "Unexpected token T in JSON at position 0" | Syncfusion
description: Learn here all about resolve the "Unexpected token T in JSON at position 0" error in the LINUX platform in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Resolve the "Unexpected token T in JSON at position 0" error in the LINUX platform

We suspect that the "Unexpected token T in JSON at position 0" error occurs in the LINUX platform due to the missing of the Pdfium.dll in your environment. We have embedded the Pdfium rendering engine in our PDF Viewer, so the Pdfium.dll will be generated on runtime within your project location.

However, we have exposed the **ReferencePath** API to set the pdfium library location path. We can place the pdfium library in project location and refer the project location to the ReferencePath. Please find the below code to set the pdfium location inside the wwwroot folder.

```csharp

PdfRenderer.ReferencePath = _hostingEnvironment.WebRootPath + "\\";  

```

The following code example shows how to resolve the "Unexpected token T in JSON at position 0" error in the LINUX platform

```csharp

public IActionResult Load([FromBody] Dictionary<string, string> jsonObject)
{
    PdfRenderer pdfviewer = new PdfRenderer(_cache);
    PdfRenderer.ReferencePath = _hostingEnvironment.WebRootPath + "\\";
    MemoryStream stream = new MemoryStream();
    object jsonResult = new object();
    if (jsonObject != null && jsonObject.ContainsKey("document"))
    {
        if (bool.Parse(jsonObject["isFileName"]))
        {
            string documentPath = GetDocumentPath(jsonObject["document"]);
            if (!string.IsNullOrEmpty(documentPath))
            {
                byte[] bytes = System.IO.File.ReadAllBytes(documentPath);
                stream = new MemoryStream(bytes);
            }
            else
            {
                return this.Content(jsonObject["document"] + " is not found");
            }
        }
        else
        {
            byte[] bytes = Convert.FromBase64String(jsonObject["document"]);
            stream = new MemoryStream(bytes);
        }
    }
    jsonResult = pdfviewer.Load(stream, jsonObject);
    return Content(JsonConvert.SerializeObject(jsonResult));
}

```

Download the [Pdfium.dll](https://www.syncfusion.com/downloads/support/directtrac/general/ze/Pdfium1515619754).

N> Kindly use the `Syncfusion.EJ2.PdfViewer.AspNet.Core.Linux` package in your application for Linux environment. Also, ensure whether the library dependencies of libpdfium. so they are installed properly. If not, please execute the following command to install the RUN apt-get update\&& apt-get install -y --allow-unauthenticated \ libc6-dev \ libgdiplus \ libx11-dev \ curl \ vim \ supervisor \ procps