---
layout: post
title: Image in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Image in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Image in Blazor RichTextEditor Component

Rich Text Editor allows inserting images from online sources and local computer where you want to insert the image in your content. For inserting the image to the Rich Text Editor, the following list of options have been provided in the `RichTextEditorImageSettings`.

| Options | Description |
|----------------|---------|
| AllowedTypes | Specifies the extensions of the image types allowed to insert on bowering and passing the extensions with List<string>. For example, private List<string> AllowedTypes = new List<string> { ".jpg",".png", ".gif" };|
| Display | Sets the default display for an image when it is inserted into the Rich Text Editor. Possible options are: `Inline` and `Break`.|
| Width | Sets the default width of the image when it is inserted in the Rich Text Editor.|
| Height | Sets the default height of the image when it is inserted in the Rich Text Editor.|
| SaveUrl | Provides URL to map the action result method to save the image.|
| Path | Specifies the location to store the image. It is of string type and it appends to the name of the file or folder where you want to store the image. For example, "api/Images/"|
| EnableResize | Enables resizing for image element.|
| MinWidth | Defines the minimum Width of the image.|
| MaxWidth | Defines the maximum Width of the image.|
| MinHeight | Defines the minimum Height of the image.|
| MaxHeight | Defines the maximum Height of the image.|
| ResizeByPercent | Image resizing should be done by percentage calculation.|

## Upload options

Through the `browse` option in the Image dialog, select the image from the local machine and insert into the Rich Text Editor content.

If the path field is not specified in the `RichTextEditorImageSettings`, the image will be converted into base64 and blob url for the image will be created then generated url will be set as `src` property of `<img>` tag as below.

The image has been loaded from the local machine and it will be saved in the given location.

```
<img src="blob:http://blazor.syncfusion.com/3ab56a6e-ec0d-490f-85a5-f0aeb0ad8879" >

```

N> If you want to insert a lot of tiny images in the editor and don't want a specific physical location for saving images, you can opt to save format as `Base64`.

## Server side action

The selected image can be uploaded to the required destination by using the following controller action. Map controller method name in `SaveUrl` property of `RichTextEditorImageSettings` and provide required destination path through `Path` property.

N> The following code block shows saving the image file uploaded to Rich Text Editor using the `Blazor Server App` project. The runnable Blazor Server app demo is available in this [Github](https://github.com/SyncfusionExamples/blazor-richtexteditor-image-upload) repository.

`Index.razor`

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorImageSettings SaveUrl="api/Image/Save" Path="./Images/" />
</SfRichTextEditor>

```

`ImageController.cs`

```csharp

using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;

namespace ImageUpload.Controllers
{
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment hostingEnv;

        public ImageController(IWebHostEnvironment env)
        {
            this.hostingEnv = env;
        }

        [HttpPost("[action]")]
        [Route("api/Image/Save")]
        public void Save(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (var file in UploadFiles)
                {
                    if (UploadFiles != null)
                    {
                        string targetPath = hostingEnv.ContentRootPath + "\\wwwroot\\Images";
                        string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');

                        // Create a new directory, if it does not exists
                        if (!Directory.Exists(targetPath))
                        {
                            Directory.CreateDirectory(targetPath);
                        }

                        // Name which is used to save the image
                        filename = targetPath + $@"\{filename}";

                        if (!System.IO.File.Exists(filename))
                        {
                            // Upload a image, if the same file name does not exist in the directory
                            using (FileStream fs = System.IO.File.Create(filename))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                            }
                            Response.StatusCode = 200;
                        }
                        else
                        {
                            Response.StatusCode = 204;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Response.Clear();
                Response.ContentType = "application/json; charset=utf-8";
                Response.HttpContext.Features.Get<IHttpResponseFeature>().ReasonPhrase = e.Message;
            }
        }
    }
}

```

![Blazor RichTextEditor with Image](./images/blazor-richtexteditor-with-image.png)

## Image delete

To remove an image from the Rich Text Editor content, select the image and click "Remove" tool from quick toolbar. It will delete the image from the Rich Text Editor content.

After selecting the image from the local machine, the URL for the image will be generated, from there also you can remove the image from the service location by clicking the cross icon as in the following image.

![Removing Image in Blazor RichTextEditor Content](./images/blazor-richtexteditor-remove-image.png)

## Insert from web

To insert an image from online source like Google, Ping, and more, enable images tool on the editor’s toolbar. By default, the images tool opens an image dialog that allows to insert an image from online source.

![Inserting Image in Blazor RichTextEditor Content](./images/blazor-richtexteditor-insert-image.png)

## Dimension

Sets the default width and height of the image when it is inserted in the Rich Text Editor using `Width` and `Height` of `RichTextEditorImageSettings`.

Through the `QuickToolbar` also you can change the width and height using `Change Size` option. After clicking the option, the image size will open as below. In that specify the width and height of the image in pixel.

![Changing Image Dimension in Blazor RichTextEditor](./images/blazor-richtexteditor-image-size.png)

## Caption and Alt Text

Image caption and alternative text can be specified for the inserted image in the Rich Text Editor using the `RichTextEditorQuickToolbarSettings` options such as Image Caption and Alternative Text.

Through the Alternative Text option, set the alternative text for the image, when the image is not uploaded successfully into the Rich Text Editor.

By clicking the Image Caption, the image will get wrapped in an image element with a caption. Then, you can type caption content inside the Rich Text Editor.

## Display position

Sets the default display for an image when it is inserted in the Rich Text Editor using `Display` field in`RichTextEditorImageSettings`.

N> It has two possible options: `Inline` and `Break`.

```cshtml

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorImageSettings Display="ImageDisplay.Inline" />
    <p>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</p>
    <p><b>Get started Quick Toolbar to click on the image</b></p>
    <p>It is possible to add custom style on the selected image inside the Rich Text Editor through quick toolbar.</p>
    <img alt='Logo' style='width: 300px; height: 300px; transform: rotate(0deg);' src='https://blazor.syncfusion.com/demos/images/RichTextEditor/RTEImage-Feather.png' />
</SfRichTextEditor>

```

## Image with link

The hyperlink itself can be an image in Rich Text Editor. If the image given as hyperlink, the remove, edit, and open links will be added to the quick toolbar of image as below. For further details about link, refer to the [link documentation](./link).

![Blazor RichTextEditor Image with Link](./images/blazor-richtexteditor-image-link.png)

## Resize

Rich Text Editor has a built-in image inserting support. The resize points will be appearing on each corner of image when focus. So, users can resize the image using mouse points or thumb through the resize points easily. Also, the resize calculation will be done based on aspect ratio.

![Image Resizing in Blazor RichTextEditor](./images/blazor-richtexteditor-image-resize.png)

N> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap5) example to know how to render and configure the rich text editor tools.

## See Also

* [How to edit the quick toolbar settings](./toolbar#quick-inline-toolbar)
* [How to use link editing option in the toolbar items](./link)