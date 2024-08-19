---
layout: post
title: Insert an image in Blazor DocumentEditor | Syncfusion
description: Learn here all about how to Insert an image from the Syncfusion Blazor Document Editor component and much more.
platform: Blazor
control: DocumentEditor
documentation: ug
---

# Insert an image in ##Platform_Name## Document editor

In this article, we are going to see how to insert an image in DocumentEditor.

Document Editor supports common raster format images like PNG, BMP, JPEG, SVG and GIF. You can insert image with base64 string, browse an image file and insert or online image in the document using the [`InsertImageAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DocumentEditor.EditorModule.html#Syncfusion_Blazor_DocumentEditor_EditorModule_InsertImageAsync_System_String_System_Nullable_System_Double__System_Nullable_System_Double__) method. 

## Insert an image from a base64 string

The following example code illustrates how to insert an image with base64 string.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@using System.IO
@using System.Net
@using System.Text.Json

<SfDocumentEditor @ref="documentEditor" Height="590px" EnableEditor=true EnableSelection=true IsReadOnly=false >
    <DocumentEditorEvents Created="OnLoad"></DocumentEditorEvents>
</SfDocumentEditor>

@code {
    SfDocumentEditor documentEditor;

    public void OnLoad(object args)
    {
        // Base64 string representing an image in PNG format
        string image = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAKAAAAAkCAMAAAA5MMHRAAAAM1BMVEUAAAA9PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT09PT0S9NMEAAAAEHRSTlMAgEC/MO8QYCDfn4/PUK9wCi7XYAAAAmFJREFUWMPVl92anCAMQBNAftXJ+z9tNwGirnasn23HPRfKiIlHMOLA7/Eens08PtswEw0OnkugL4YAT2Wiygs+DlIFTWtYAHADNTJ8gFNBn6jz+Uo5FBypMUT4NHvBVsPCA+r4WBBe0n5CFR8ICmEgQngAx4JSyZ+v4GPBH7MYP4RgK8G1RgHbkGF8zXYBLuCypIU3FEl5fYqpoUuKAhdINS28wXLKW4Je/S4LOj4/2fBvBQPvRlQuCHK6Au8JiHhLUDpnWBONMX3veSu4Vb8QDb/p81ejB3gOEPMOgOMt4yfElyTZpTwXxN399L2RrTAUYF6JKtqBPcBIAOBAHZ1iX0hIE8AqJV4cwWNBpdQV/EQwkKKCftRDQX0Y/MNnMFkhozsU/OqSK/j2FW4Zg5m7EM1GUJTGjEIXzByVUZLEnjLxhTdzHr1Ovmnsqjh/E9RfRX6N609w04ZgJzh+q+LIfq6Nf9bz57YHgxUTsRJgVbMu0ZpwIKhX9zL8p4JUDOO7YNDbGojS5gInU7y9gZmPzO8ERelEMFNnCE1QMumAXhdUAvfdFNysTPEvC5ozQcfP0Ikg+EnnA6vRSz+M0z3BooLuWFAu4I4EnZ6iLIKOC7v/1Z2vClpFqqVIloSIdiuov4aCjApqQK5TbCplEZStnYy8wqergrRhiFJqwl5w/cZdBP0mwNKCq4Lr5zLDLcHkQNMdCYK3O0EN2AkWXepc0kM7wbP3ICqymGtEnWJuigTHRmkEFOohowGVCAE7Zv01MxVrZ4z9ZN3fgMvwkf9Z3FIyCZ6IIWWCJ6KC4//x+wW4X1lUibNfbQAAAABJRU5ErkJggg==";
        //Insert image.
        documentEditor.Editor.InsertImageAsync(image,200,200);

    }
}
```

## Browse and insert an image in document editor

The following example code illustrates how to browse and insert an image.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@using Syncfusion.Blazor.Inputs
@using System.IO

<InputFile OnChange="onInsertImage" accept="image/*" />
<SfDocumentEditor @ref="editor" EnableEditor=true EnableSelection=true IsReadOnly=false EnableImageResizer=true ></SfDocumentEditor>

@code {
    SfDocumentEditor editor;

    public async Task onInsertImage(InputFileChangeEventArgs action)
    {
        var file = action.File;
        if (file != null)
        {
            using var memoryStream = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(memoryStream);
            byte[] fileBytes = memoryStream.ToArray();
            string base64String = Convert.ToBase64String(fileBytes);
            string mimeType = file.ContentType;
            string base64 = $"data:{mimeType};base64,{base64String}";
            await editor.Editor.InsertImageAsync(base64,null,null);
        }
    }
}
```

## Insert an image from a URL

The following example code illustrates how to insert an image from a URL.

```csharp
@using Syncfusion.Blazor.DocumentEditor
@using System.IO
@using System.Net
@using System.Text.Json

<SfDocumentEditor @ref="documentEditor" Height="590px" EnableEditor=true EnableSelection=true IsReadOnly=false >
    <DocumentEditorEvents Created="OnLoad"></DocumentEditorEvents>
</SfDocumentEditor>

@code {
    SfDocumentEditor documentEditor;

    public void OnLoad(object args)
    {
        //Insert image.
        documentEditor.Editor.InsertImageAsync("https://cdn.syncfusion.com/content/images/Logo/Logo_Black_72dpi_without.png", 200, 200, "Syncfusion");

    }
}
```