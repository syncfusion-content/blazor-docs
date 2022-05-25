---
layout: post
title: Image in Blazor RichTextEditor Component | Syncfusion
description: Checkout and learn here all about Image in Syncfusion Blazor RichTextEditor component and much more.
platform: Blazor
control: RichTextEditor
documentation: ug
---

# Image in Blazor RichTextEditor Component

Rich Text Editor allows inserting images from online sources and local computer where you want to insert the image in your content. For inserting the image to the Rich Text Editor, the following list of options have been provided in the [`RichTextEditorImageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html).

| Options | Description |
|----------------|---------|
| AllowedTypes | Specifies the extensions of the image types allowed to insert on bowering and passing the extensions with comma separators. For example, pass AllowedTypes as .jpg and .png.|
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

## Upload Images

Through the `browse` option in the Image dialog, select the image from the local machine and insert into the Rich Text Editor content.

If the path field is not specified in the [`RichTextEditorImageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html), the image will be converted into base64 and blob url for the image will be created then generated url will be set as `src` property of `<img>` tag as below.

The image has been loaded from the local machine and it will be saved in the given location.

```
<img src="blob:http://blazor.syncfusion.com/3ab56a6e-ec0d-490f-85a5-f0aeb0ad8879" >

```

> If you want to insert a lot of tiny images in the editor and don't want a specific physical location for saving images, you can opt to save format as `Base64`.

## Server side action

The selected image can be uploaded to the required destination by using the following controller action. Map controller method name in `SaveUrl` property of [`RichTextEditorImageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html) and provide required destination path through `Path` property.

> The following code block shows saving the image file uploaded to Rich Text Editor using the `Blazor Server App` project. The runnable Blazor Server app demo is available in this [Github](https://github.com/SyncfusionExamples/blazor-richtexteditor-image-upload) repository.

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

## Save Image in Application Path

We can change the path of the image, by creating a folder structure as per our requirement under the folder wwwroot. 

We can’t create a path outside the wwwroot folder since any files including HTML files, CSS files, image files, and JavaScript files that are sent to the user's browser should be stored inside this folder. 
 
{% tabs %}
{% highlight razor tabtitle="~/save-image.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor> 
    <RichTextEditorImageSettings SaveUrl="api/Image/Save" Path="./mnt/momfiles/WEB/NoticeBoard/Image/"></RichTextEditorImageSettings>
</SfRichTextEditor>

{% endhighlight %}
{% endtabs %}

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
                        string targetPath = hostingEnv.ContentRootPath + "\\wwwroot\\mnt\\momfiles\\WEB\\NoticeBoard\\Image";
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

## Image Save Format

By default, the Rich Text Editor inserts the images as [`Blob`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SaveFormat.html#Syncfusion_Blazor_RichTextEditor_SaveFormat_Blob), but we can also change the save format  by setting the [`SaveFormat`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorImageSettings_SaveFormat) property in the [`RichTextEditorImageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html) as "SaveFormat.Base64".

{% tabs %}
{% highlight razor tabtitle="~/save-format.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor> 
    <RichTextEditorImageSettings SaveFormat="SaveFormat.Base64"></RichTextEditorImageSettings> 
</SfRichTextEditor> 

{% endhighlight %}
{% endtabs %}

## Image delete

To remove an image from the Rich Text Editor content, select the image and click "Remove" tool from quick toolbar. It will delete the image from the Rich Text Editor content.

After selecting the image from the local machine, the URL for the image will be generated, from there also you can remove the image from the service location by clicking the cross icon as in the following image.

![Removing Image in Blazor RichTextEditor Content](./images/blazor-richtexteditor-remove-image.png)

## Insert Image from web

To insert an image from online source like Google, Ping, and more, enable images tool on the editor’s toolbar. By default, the images tool opens an image dialog that allows to insert an image from online source.

![Inserting Image in Blazor RichTextEditor Content](./images/blazor-richtexteditor-insert-image.png)

## Dimension

Sets the default width and height of the image when it is inserted in the Rich Text Editor using [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorImageSettings_Width) and [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorImageSettings_Height) of [`RichTextEditorImageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html).

Through the `QuickToolbar` also you can change the width and height using `Change Size` option. After clicking the option, the image size will open as below. In that specify the width and height of the image in pixel.

![Changing Image Dimension in Blazor RichTextEditor](./images/blazor-richtexteditor-image-size.png)

## Caption and Alt Text

Image caption and alternative text can be specified for the inserted image in the Rich Text Editor using the [`RichTextEditorQuickToolbarSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorQuickToolbarSettings.html) options such as Image Caption and Alternative Text.

Through the Alternative Text option, set the alternative text for the image, when the image is not uploaded successfully into the Rich Text Editor.

By clicking the Image Caption, the image will get wrapped in an image element with a caption. Then, you can type caption content inside the Rich Text Editor.

## Display position

Sets the default display for an image when it is inserted in the Rich Text Editor using `Display` field in [`RichTextEditorImageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorQuickToolbarSettings.html).

> It has two possible options: `Inline` and `Break`.

{% tabs %}
{% highlight razor tabtitle="~/display-position.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorImageSettings Display="ImageDisplay.Inline" />
    <p>Rich Text Editor allows to insert images from online source as well as local computer where you want to insert the image in your content.</p>
    <p><b>Get started Quick Toolbar to click on the image</b></p>
    <p>It is possible to add custom style on the selected image inside the Rich Text Editor through quick toolbar.</p>
    <img alt='Logo' style='width: 300px; height: 300px; transform: rotate(0deg);' src='https://blazor.syncfusion.com/demos/images/RichTextEditor/RTEImage-Feather.png' />
</SfRichTextEditor>

{% endhighlight %}
{% endtabs %}

## Image with link

The hyperlink itself can be an image in Rich Text Editor. If the image given as hyperlink, the remove, edit, and open links will be added to the quick toolbar of image as below. For further details about link, refer to the [link documentation](./link).

![Blazor RichTextEditor Image with Link](./images/blazor-richtexteditor-image-link.png)

## Resize

Rich Text Editor has a built-in image inserting support. The resize points will be appearing on each corner of image when focus. So, users can resize the image using mouse points or thumb through the resize points easily. Also, the resize calculation will be done based on aspect ratio.

![Image Resizing in Blazor RichTextEditor](./images/blazor-richtexteditor-image-resize.png)


## Restrict Image Upload Based on Size

By using the Rich text editor's [`OnImageUploading`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_OnImageUploadSuccess) event, you can get the image size before uploading and restrict the image to upload, when the given image size is greater than the allowed size.

In the following, the image size has been validated before uploading and determined whether the image has been uploaded or not.

{% tabs %}
{% highlight razor tabtitle="~/restrict-image.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorImageSettings SaveUrl="https://aspnetmvc.syncfusion.com/services/api/uploadbox/Save" Path="./Images/" />
    <RichTextEditorEvents BeforeUploadImage="@BeforeUploadImage" />
</SfRichTextEditor>

@code {
    private void BeforeUploadImage(ImageUploadingEventArgs args)
    {
        var sizeInBytes = args.FilesData[0].Size;
        var imgSize = 500000;
        if (imgSize < sizeInBytes) {
            args.Cancel = true;
        }
    }
}

{% endhighlight %}
{% endtabs %}


> Note: We can't restrict while uploading an image as a hyperlink in insert image dialog. 
When inserting pictures using the link, RichText does not allow you to limit the size of the image. We were unable to identify the image file size when the image was provided as a link. We created an image element and only assigned an image link to the src attribute in our implementation.


# Rename Images Before Inserting

By using the [`RichTextEditorImageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorImageSettings.html) property, the server handler can be specified to upload and rename the selected image. Then, the [`OnImageUploadSuccess`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_OnImageUploadSuccess) event could be bound, to receive the modified file name from the server and update it in the Rich Text Editor's insert image dialog.

> The runnable Blazor Server app demo is available in this [Github](https://github.com/SyncfusionExamples/blazor-richtexteditor-rename-image) repository.

{% tabs %}
{% highlight razor tabtitle="~/rename.razor" %}

@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor>
    <RichTextEditorImageSettings SaveUrl="[SERVICE_HOSTED_PATH]/api/Image/Rename" Path="./Images/" />
    <RichTextEditorEvents OnImageUploadSuccess="@ImageUploadSuccess" />
</SfRichTextEditor>

@code {
    public string[] header { get; set; }

    private void ImageUploadSuccess(ImageSuccessEventArgs args)
    {
        var headers = args.Response.Headers.ToString();
        header = headers.Split("name: ");
        header = header[1].Split("\r");

        // Update the modified image name to display a image in the editor.
        args.File.Name = header[0];
    }
}

{% endhighlight %}
{% endtabs %}

To configure the server-side handler in the Web API service, refer the below code.

```csharp

using System;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;

namespace RenameImage.Controllers
{
    [ApiController]
    public class ImageController : ControllerBase
    {
        private double x;
        private string imageFileName;
        private readonly IWebHostEnvironment hostingEnv;

        public ImageController(IWebHostEnvironment env)
        {
            this.hostingEnv = env;
        }

        [HttpPost("[action]")]
        [Route("api/Image/Rename")]
        public void Rename(IList<IFormFile> UploadFiles)
        {
            try
            {
                foreach (IFormFile file in UploadFiles)
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

                        imageFileName = filename;
                        string path = hostingEnv.WebRootPath + "\\Images" + $@"\{filename}";

                        // Rename a uploaded image file name
                        while (System.IO.File.Exists(path))
                        {
                            imageFileName = "rteImage" + x + "-" + filename;
                            path = hostingEnv.WebRootPath + "\\Images" + $@"\rteImage{x}-{filename}";
                            x++;
                        }

                        if (!System.IO.File.Exists(path))
                        {
                            using (FileStream fs = System.IO.File.Create(path))
                            {
                                file.CopyTo(fs);
                                fs.Flush();
                                fs.Close();
                            }

                            // Modified file name shared through response header by adding custom header
                            Response.Headers.Add("name", imageFileName);
                            Response.StatusCode = 200;
                            Response.ContentType = "application/json; charset=utf-8";
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

## Upload with Authentication

We can upload the Image in the Azure Blob with Rich Text Editor. Place authentication and image upload logic into SaveUrl specified controller. Finally update and return uploaded image remote Url through response headers. Follows the below steps to authenticate and upload a image from controller.

```csharp

[HttpPost] 
[Route("Save")] 
public async void Save(IList<IFormFile> UploadFiles) 
{ 
    try 
    { 
        foreach (var file in UploadFiles) 
        { 
            /* Azure blob storage related logics start here */ 
            // use your credentials here to authenticate 
            const string accountName = "exampleaccount"; 
            const string key = "examplekey"; 
 
            var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true); 
 
            var blobClient = storageAccount.CreateCloudBlobClient(); 
            var container = blobClient.GetContainerReference("images"); 
            await container.CreateIfNotExistsAsync(); 
            await container.SetPermissionsAsync(new BlobContainerPermissions() 
            { 
                PublicAccess = BlobContainerPublicAccessType.Blob 
            }); 
 
            var blob = container.GetBlockBlobReference("test.jpg"); 
            using (var stream = file.OpenReadStream()) 
            { 
                await blob.UploadFromStreamAsync(stream); 
            } 
            /* Azure blob storage related logics end here */ 
        } 
 
        Response.Clear(); 
 
        // Update the Azure uploaded image url into 'name' header to modify and display a image in RTE like below. 
        Response.Headers.Add("name", "https://blazor.syncfusion.com/documentation/rich-text-editor/images/image-upload.png"); 
        Response.ContentType = "application/json; charset=utf-8"; 
    } 
    catch (Exception e) {} 
} 

```
Configure empty string in the Path API of SfRichTextEditor. To replace azure uploaded remote image Url into editor, we need to configure this in Rich Text Editor.

```cshtml

<SfRichTextEditor ID="default_RTE"> 
    <RichTextEditorImageSettings SaveUrl="api/SampleData/Save" Path=""></RichTextEditorImageSettings> 
</SfRichTextEditor> 

```
Bind [`OnImageUploadSuccess`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorEvents.html#Syncfusion_Blazor_RichTextEditor_RichTextEditorEvents_OnImageUploadSuccess) event and place the below code in the callback as follows

```cshtml

<SfRichTextEditor ID="default_RTE"> 
    <RichTextEditorImageSettings SaveUrl="api/SampleData/Save" Path=""></RichTextEditorImageSettings> 
    <RichTextEditorEvents OnImageUploadSuccess="@OnImageUploadSuccess"></RichTextEditorEvents> 
</SfRichTextEditor> 
 
@code{ 
    string[] header; 
 
    private void OnImageUploadSuccess(ImageSuccessEventArgs args) 
    { 
        var headers = args.Response.Headers.ToString(); 
        header = headers.Split("name: "); 
        header = header[1].Split("\r"); 
        args.File.Name = header[0]; 
    } 
} 
 

```


> You can refer to our [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-wysiwyg-rich-text-editor) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Rich Text Editor](https://blazor.syncfusion.com/demos/rich-text-editor/overview?theme=bootstrap4) example to know how to render and configure the rich text editor tools.

## See Also

* [How to edit the quick toolbar settings](./toolbar/#quick-inline-toolbar)
* [How to use link editing option in the toolbar items](./link/)