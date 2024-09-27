---
layout: post
title: Resolve the "Unexpected token T in JSON at position 0" | Syncfusion
description: Learn here all about resolve the "Unexpected token T in JSON at position 0" error in the LINUX platform in Syncfusion Blazor PDF Viewer component and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

# Resolve "Unexpected token T in JSON at position 0" error

We suspect that the "Unexpected token T in JSON at position 0" error occurs in the Linux platform due to the missing of the Pdfium.dll in your environment. We have embedded the Pdfium rendering engine in our PDF Viewer, so the Pdfium.dll will be generated on runtime within your project location.

However, we have exposed the **ReferencePath** API to set the pdfium library location path. We can place the pdfium library in project location and refer the project location to the ReferencePath. Find the below code to set the pdfium location inside the wwwroot folder.

```csharp

PdfRenderer.ReferencePath = _hostingEnvironment.WebRootPath + "/";  

```

The following code example shows how to resolve the "Unexpected token T in JSON at position 0" error in the Linux platform

```csharp

public IActionResult Load([FromBody] Dictionary<string, string> jsonObject)
{
    PdfRenderer pdfviewer = new PdfRenderer(_cache);
    PdfRenderer.ReferencePath = _hostingEnvironment.WebRootPath + "/";
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

N> Use the `Syncfusion.EJ2.PdfViewer.AspNet.Core.Linux package` in your application for the Linux environment. Also, ensure whether the library dependencies of lib pdfium. So they are installed properly. If not, execute the following command to install the RUN apt-get update&& apt-get install -y --allow-unauthenticated \ libc6-dev \ libgdiplus \ libx11-dev \ curl \ vim \ supervisor \ pro cps

N> The ReferencePath can only be specified in WebAssembly applications; it cannot be set in server applications because there is no need for service URL dependencies in server applications.For more details about setting the ReferencePath [refer to this link](https://ej2.syncfusion.com/aspnetmvc/documentation/pdfviewer/how-to/resolve-pdfium-issue).
