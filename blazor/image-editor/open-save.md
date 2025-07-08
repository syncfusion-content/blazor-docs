---
layout: post
title: Open save with Blazor Image Editor Component | Syncfusion
description: Checkout the Open save available in Blazor Image Editor component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Image Editor
documentation: ug
---


# Open and Save in the Blazor Image Editor component

The [Blazor Image Editor](https://www.syncfusion.com/blazor-components/blazor-image-editor) component supports to import an image into the canvas, it must first be converted into a blob object. The Uploader component can be used to facilitate the process of uploading an image from the user interface. Once the image has been uploaded, it can then be converted into a blob and drawn onto the canvas.

## Supported image formats

The Image Editor control supports five common image formats: PNG, JPEG, SVG, WEBP and BMP. These formats allow you to work with a wide range of image files within the Image Editor.

When it comes to saving the edited image, the default file type is set as PNG. This means that when you save the edited image without specifying a different file type, it will be saved as a PNG file. However, it's important to note that the Image Editor typically provides options or methods to specify a different file type if desired. This allows you to save the edited image in formats other than the default PNG, such as JPEG, SVG, and WEBP based on your specific requirements or preferences.

## Open an image

The [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_) method in the Blazor Image Editor component offers the capability to open an image by providing it in different formats. This method accepts various types of arguments, such as a base64-encoded string, raw image data, or a hosted/online URL. You can pass either the file name or the actual image data as an argument to the `OpenAsync` method, and it will load the specified image into the image editor component. This flexibility allows you to work with images from different sources and formats, making it easier to integrate and manipulate images within the Image Editor component.

### Opening local images in the Blazor Image Editor 

Users can easily open local images in the Image Editor. Simply place the image in the same folder as the sample. By specifying the local file name directly in the open method, the image will be loaded seamlessly into the editor.

Note: To load the image in the image editor, the image is placed within the application's "wwwroot" folder.

```cshtml
@using Syncfusion.Blazor.ImageEditor 

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor> 

@code { 
    SfImageEditor ImageEditor; 
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { }; 

    private async void OpenAsync() 
    { 
        await ImageEditor.OpenAsync("nature.png"); 
    } 
}
```

![Blazor Image Editor with Opening an image](./images/blazor-image-editor-open.jpg)

### Open an image from base64 format 

Users can easily open images in the Image Editor using a Base64-encoded string. This method allows you to load images directly from their Base64 representation, ensuring seamless integration and flexibility in your application. Simply pass the Base64 string to the [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_) method, and the image will be loaded into the editor. 

`Note:` You can obtain the Base64 representation of an image from the Image Editor using the [`GetImageDataUrlAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetImageDataUrlAsync_System_Boolean_) method. This process will be explained in the upcoming section.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="SaveAsync">Save Base64</SfButton>
    <SfButton OnClick="OpenBaseAsync">Open Base64</SfButton>
</div>
<SfImageEditor @ref="ImageEditor" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private string base64String;

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async void SaveAsync()
    {
        var imageDataUrl = await ImageEditor.GetImageDataUrlAsync();
        if (!string.IsNullOrEmpty(imageDataUrl))
        {
            int base64Index = imageDataUrl.IndexOf(',') + 1;
            base64String = imageDataUrl.Substring(base64Index);
        }
    }

    private async void OpenBaseAsync()
    {
        await ImageEditor.OpenAsync("data:image/png;base64," + base64String);
    }
}
```

![Blazor Image Editor with Opening an base 64 image](./images/blazor-image-editor-base64-open.jpg)

### Open an image from Blob storage

User can easily open images in the Image Editor from Blob storage. This method allows you to load images directly from Blob storage, ensuring seamless integration and flexibility in your application. Simply retrieve the image Blob from storage and pass it to the [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_) method, and the image will be loaded into the editor. 

`Note:` You can obtain the Blob URL representation of an image from the Image Editor using the [`GetImageDataUrlAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetImageDataUrlAsync_System_Boolean_) method. This process will be explained in the upcoming section. 

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="SaveBlobAsync">Save Blob</SfButton>
    <SfButton OnClick="OpenBlobAsync">Open Blob</SfButton>
</div>
<SfImageEditor @ref="ImageEditor" Height="400">
    <ImageEditorEvents Created="OnImageEditorCreated"></ImageEditorEvents>
</SfImageEditor>

@code {
    private SfImageEditor ImageEditor;
    private string blobUrl;

    private async void OnImageEditorCreated()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async Task SaveBlobAsync()
    {
        var imageDataUrl = await ImageEditor.GetImageDataUrlAsync();
        if (!string.IsNullOrEmpty(imageDataUrl))
        {
            int base64Index = imageDataUrl.IndexOf(',') + 1;
            var base64String = imageDataUrl.Substring(base64Index);
            var bytes = Convert.FromBase64String(base64String);
            var stream = new MemoryStream(bytes);
            blobUrl = "data:image/png;base64," + base64String;
        }
    }

    private async Task OpenBlobAsync()
    {
        if (!string.IsNullOrEmpty(blobUrl))
        {
            await ImageEditor.OpenAsync(blobUrl);
        }
    }
}
```

![Blazor Image Editor with Opening an base 64 image](./images/blazor-image-editor-blob-open.jpg)

### Open an image from File Uploader 

User can easily open images in the Image Editor using a file uploader. This method allows users to upload an image file from their device and load it directly into the editor. Once the image is selected through the file uploader, pass the file to the [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_) method, and the image will be seamlessly loaded into the editor.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.ImageEditor
@using System.IO

<div class="e-img-editor-sample">
    <SfUploader AllowedExtensions=".jpg,.jpeg,.png" @ref="uploader" ShowFileList=false>
        <UploaderEvents ValueChange="@OnImageSelected"></UploaderEvents>
    </SfUploader>
    <SfImageEditor @ref="ImageEditor" Height="350px"></SfImageEditor>
</div>

@code {
    private SfUploader uploader;
    private SfImageEditor ImageEditor;

    private async Task OnImageSelected(UploadChangeEventArgs args)
    {
        if (args.Files?.Count > 0)
        {
            var file = args.Files[0];
            if (file != null)
            {
                using var memoryStream = new MemoryStream();
                await file.File.OpenReadStream(long.MaxValue).CopyToAsync(memoryStream);
                string base64String = Convert.ToBase64String(memoryStream.ToArray());
                string dataUrl = $"data:image/png;base64,{base64String}";
                await ImageEditor.OpenAsync(dataUrl);
            }
        }
    }
}
```

![Blazor Image Editor with File uploader](./images/blazor-image-editor-uploader.jpg)

### Open an image from File Manager 

User can easily open images in the Image Editor using the File Manager. This method allows you to browse and select an image file directly from the File Manager and load it into the editor. Once the image is selected, pass the file to the [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_) method, and the image will be seamlessly loaded into the editor. 

```cshtml
@using Syncfusion.Blazor.FileManager
@using Syncfusion.Blazor.ImageEditor
@inject NavigationManager UriHelper

<div class="control-section">
    <div class="control_wrapper">
        <SfFileManager TValue="FileManagerDirectoryContent" @ref="fileManager" Height="200px">
            <FileManagerEvents TValue="FileManagerDirectoryContent" OnRead="OnReadAsync"
                BeforeImageLoad="BeforeImageLoadAsync" OnFileOpen="OnFileOpenAsync"
                BeforePopupOpen="BeforePopupOpenAsync">
            </FileManagerEvents>
        </SfFileManager>
    </div>
    <SfImageEditor @ref="imageEditor" Height="350px"></SfImageEditor>
</div>
@code {
    private SfImageEditor imageEditor;
    private SfFileManager<FileManagerDirectoryContent> fileManager;
    public FileManagerService FileService = new FileManagerService();
    public async Task OnReadAsync(ReadEventArgs<FileManagerDirectoryContent> args)
    {
        args.Response = await FileService.ReadAsync(args.Path, args.Folder);
    }
    public void BeforeImageLoadAsync(BeforeImageLoadEventArgs<FileManagerDirectoryContent> args)
    {
        string relativePath = $"https://ej2.syncfusion.com/react/demos/src/image-editor/images/{args.FileDetails.Name}";
        args.ImageUrl = UriHelper.ToAbsoluteUri(relativePath).ToString();
    }
    private async Task OnFileOpenAsync(FileOpenEventArgs<FileManagerDirectoryContent> args)
    {
        if (args.FileDetails != null && args.FileDetails.IsFile)
        {
            string relativePath = $"https://ej2.syncfusion.com/react/demos/src/image-editor/images/{args.FileDetails.Name}";
            await imageEditor.OpenAsync(relativePath);
        }
    }
    public void BeforePopupOpenAsync(BeforePopupOpenCloseEventArgs args)
    {
        args.Cancel = true;
    }

    public class FileManagerService
    {
        public List<FileManagerDirectoryContent> Data = new List<FileManagerDirectoryContent>();
        public FileManagerService()
        {
            this.GetData();
        }
        private void GetData()
        {
            Data.Add(new FileManagerDirectoryContent()
            {
                CaseSensitive = false,
                DateCreated = new DateTime(2022, 1, 2),
                DateModified = new DateTime(2022, 2, 3),
                FilterPath = "",
                FilterId = "",
                HasChild = true,
                Id = "0",
                IsFile = false,
                Name = "Pictures",
                ParentId = null,
                ShowHiddenItems = false,
                Size = 1779448,
                Type = "folder"
            });
            Data.Add(new FileManagerDirectoryContent()
            {
                CaseSensitive = false,
                DateCreated = new DateTime(2022, 1, 2),
                DateModified = new DateTime(2022, 2, 3),
                FilterId = "0/",
                FilterPath = "/Pictures/",
                HasChild = false,
                Id = "1",
                IsFile = true,
                Name = "bridge.png",
                ParentId = "0",
                ShowHiddenItems = false,
                Size = 680786,
                Type = ".png",
            });
            Data.Add(new FileManagerDirectoryContent()
            {
                CaseSensitive = false,
                DateCreated = new DateTime(2022, 1, 2),
                DateModified = new DateTime(2022, 2, 3),
                FilterId = "0/",
                FilterPath = "/Pictures/",
                HasChild = false,
                Id = "1",
                IsFile = true,
                Name = "flower.png",
                ParentId = "0",
                ShowHiddenItems = false,
                Size = 680786,
                Type = ".png",
            });
        }

        public async Task<FileManagerResponse<FileManagerDirectoryContent>> ReadAsync(string path,
        List<FileManagerDirectoryContent> fileDetails)
        {
            FileManagerResponse<FileManagerDirectoryContent> response = new FileManagerResponse<FileManagerDirectoryContent>();
            if (path == "/")
            {
                string ParentId = Data
                .Where(x => x.FilterPath == string.Empty)
                .Select(x => x.Id).First();
                response.CWD = Data
                .Where(x => x.FilterPath == string.Empty).First();
                response.Files = Data
                .Where(x => x.ParentId == ParentId).ToList();
            }
            else
            {
                var id = fileDetails.Count > 0 && fileDetails[0] != null ? fileDetails[0].Id : Data
                .Where(x => x.FilterPath == path)
                .Select(x => x.ParentId).First();
                response.CWD = Data
                .Where(x => x.Id == (fileDetails.Count > 0 && fileDetails[0] != null ? fileDetails[0].Id : id)).First();
                response.Files = Data
                .Where(x => x.ParentId == (fileDetails.Count > 0 && fileDetails[0] != null ? fileDetails[0].Id : id)).ToList();
            }
            await Task.Yield();
            return await Task.FromResult(response);
        }
    }
}
```

![Blazor Image Editor with File uploader](./images/blazor-image-editor-file-manager.jpg)

### Open an image from Treeview 

Users can open images in the Syncfusion Image Editor by selecting a node from a tree view. When a user clicks on an image node, the corresponding image is loaded into the editor using the [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_) method. This allows for a seamless image editing experience directly from the TreeView component.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.ImageEditor

@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper

<div class="control-section">
    <div class="control_wrapper">
        <SfTreeView TValue="TreeItem" @ref="treeView" SortOrder="Syncfusion.Blazor.Navigations.SortOrder.Ascending">
            <TreeViewFieldsSettings DataSource="@TreeDataSource" Id="NodeId" Text="NodeText" Expanded="Expanded"
                Child="@("Child")" IconCss="Icon" ImageUrl="ImageUrl"></TreeViewFieldsSettings>
            <TreeViewEvents TValue="TreeItem" NodeSelected="NodeSelected"></TreeViewEvents>
        </SfTreeView>
    </div>
    <SfImageEditor @ref="imageEditor" Height="350px"></SfImageEditor>
</div>

@code {
    private SfImageEditor imageEditor;
    private SfTreeView<TreeItem> treeView;
    private string selectedId;
    List<TreeItem> TreeDataSource = new List<TreeItem>();

    protected override void OnInitialized()
    {
        base.OnInitialized();
        TreeDataSource.Add(new TreeItem
        {
            NodeId = "01",
            NodeText = "Pictures",
            Icon = "folder",
            Expanded = true,
            Child = new List<TreeItem>()
            {
                new TreeItem { NodeId = "01-01", NodeText = "Flower", ImageUrl = "https://ej2.syncfusion.com/react/demos/src/image-editor/images/flower.png" },
                new TreeItem { NodeId = "01-02", NodeText = "Bridge", ImageUrl = "https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png" },
            },
        });
    }

    public async void NodeSelected(NodeSelectEventArgs args)
    {
        List<TreeItem> selectedNodes = treeView.GetTreeData(args.NodeData.Id);
        if (selectedNodes.Count > 0 && selectedNodes[0].ImageUrl != null)
        {
            await imageEditor.OpenAsync(selectedNodes[0].ImageUrl);
        }
    }

    class TreeItem
    {
        public string? NodeId { get; set; }
        public string? NodeText { get; set; }
        public string? Icon { get; set; }
        public string? ImageUrl { get; set; }
        public bool Expanded { get; set; }
        public List<TreeItem> Child { get; set; } = new();
    }
}
```

![Blazor Image Editor with File uploader](./images/blazor-image-editor-treeview.jpg)

### Add watermarks while opening an image 

You can utilize the [`FileOpenEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FileOpenEventArgs.html) event, which triggers once the image is loaded into the image editor. After this event, you can use the [`DrawTextAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_DrawTextAsync_System_Double_System_Double_System_String_System_String_System_Int32_System_Boolean_System_Boolean_System_String_System_Boolean_System_Int32_System_String_System_String_System_Int32_) method to add a watermark. This approach allows the watermark to be automatically drawn on the canvas every time an image is opened in the editor, making it useful for handling copyright-related content.

```cshtml
@using Syncfusion.Blazor.ImageEditor 
<SfImageEditor @ref="ImageEditor" Height="400">
    <ImageEditorEvents Created="OpenAsync" FileOpened="FileOpenedAsync"></ImageEditorEvents>
</SfImageEditor> 

@code { 
    SfImageEditor ImageEditor;

    private async void OpenAsync() 
    { 
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png"); 
    }

    private async void FileOpenedAsync() 
    { 
        ImageDimension Dimension = await ImageEditor.GetImageDimensionAsync();
        await ImageEditor.DrawTextAsync(Dimension.X.Value, Dimension.Y.Value, "Enter\nText", "Arial", 40, false, false, "#80330075");
    }
}
```
![Blazor Image Editor with Adding Watermark](./images/blazor-image-editor-add-watermark.jpeg)

### Opening Images with Custom Width and Height

Users can now open images with specific width and height values using the optional parameters in the [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_) method. This enhancement introduces three optional parameters: `width`, `height`, and `isAspectRatio`These options allow precise control over the image dimensions, with the flexibility to preserve the original aspect ratio if needed. This feature is especially useful when rendering high-resolution images or when fitting images into fixed-size layouts or canvas areas.
 
The following behaviors are supported through these properties:
- Contains behavior: By specifying only one dimension (either `width` or `height`) and enabling `isAspectRatio`, the other dimension is automatically calculated to maintain the image’s original proportions.

- Cover behavior: When both `width` and `height` are specified with `isAspectRatio` set to `true`, the image scales proportionally to fit within the given dimensions while preserving its aspect ratio.

- Stretch or Shrink behavior: Setting `isAspectRatio` to `false` forces the image to strictly follow the specified `width` and `height`, allowing it to stretch or shrink regardless of its original aspect ratio.

The following example showcases how all three behaviors can be achieved using the OpenAsync method.

```cshtml
@using Syncfusion.Blazor.ImageEditor 
@using Syncfusion.Blazor.Buttons

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="330" Width="550">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>
<div style="display: flex; gap: 12px; margin-top: 10px">
    <SfButton CssClass="e-primary" OnClick="ContainsAsync">Fit to Width (Aspect Ratio)</SfButton>
    <SfButton CssClass="e-primary" OnClick="CoverAsync">Cover (Aspect Ratio)</SfButton>
    <SfButton CssClass="e-primary" OnClick="StretchAsync">Stretch / Shrink</SfButton>
</div>
@code {
    SfImageEditor ImageEditor;
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { };

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async void ContainsAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png", true, "", 550, -1, true);
    }
    private async void CoverAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png", true, "", 550, 550, true);
    }
    private async void StretchAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png", true, "", 330, 330, false);
    }
}
```

![Blazor Image Editor with Opening an image](./images/blazor-image-editor-custom-height-width.png)

## Save as image

The [`ExportAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_ExportAsync_System_String_Syncfusion_Blazor_ImageEditor_ImageEditorFileType_System_Double_) method in the Blazor Image Editor component is used to save the modified image as an image, and it accepts a file name and file type as parameters. The file type parameter supports PNG, JPEG, SVG, and WEBP the default file type is PNG. Users are allowed to save an image with a specified file name, file type, and image quality. This enhancement provides more control over the output, ensuring that users can save their work exactly as they need it.

In the following example, the `ExportAsync` method is used in the button click event.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="ExportAsync">Export</SfButton>
</div>
<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor> 

@code { 
    SfImageEditor ImageEditor; 
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { }; 

    private async void OpenAsync() 
    { 
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png"); 
    }

    private async void ExportAsync()
    {
        await ImageEditor.ExportAsync("Syncfusion", ImageEditorFileType.PNG);
    }
}
```

![Blazor Image Editor with Save an image](./images/blazor-image-editor-export.png)

### Save the image as base64 format

To save an image as a base64 format, use the [`GetImageDataUrlAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetImageDataUrlAsync_System_Boolean_) method of the editor to retrieve the image data and convert it into a Data URL, which contains the base64-encoded string. By invoking the [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_) on the Syncfusion<sup style="font-size:70%">&reg;</sup> Image Editor instance, you can load this Data URL into the editor. The resulting base64 string can then be embedded directly in HTML or CSS or transmitted over data channels without requiring an external file.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="SaveAsync">Save Base64</SfButton>
</div>
<SfImageEditor @ref="ImageEditor" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private string base64String;

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async void SaveAsync()
    {
        var imageDataUrl = await ImageEditor.GetImageDataUrlAsync();
        if (!string.IsNullOrEmpty(imageDataUrl))
        {
            int base64Index = imageDataUrl.IndexOf(',') + 1;
            base64String = imageDataUrl.Substring(base64Index);
        }
    }
}
```

![Blazor Image Editor with Base64](./images/blazor-image-editor-base64.jpg)

### Save the image as byte[]

To save an image as a byte array, use the [`GetImageDataAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetImageDataAsync) method of the editor to retrieve a byte array. You can then invoke the [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_) method on the Syncfusion<sup style="font-size:70%">&reg;</sup> Image Editor instance to load this byte array into the editor. The resulting byte array can be stored in a database for data management and maintenance.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="SaveImageAsByteArray">Save Byte[]</SfButton>
    <SfButton OnClick="OpenImage">Open Byte[]</SfButton>
</div>
<SfImageEditor @ref="ImageEditor" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    SfImageEditor ImageEditor;
    private byte[] savedImageData;

    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async Task SaveImageAsByteArray()
    {
        savedImageData = await ImageEditor.GetImageDataAsync();
    }

    private async Task OpenImage()
    {
        if (savedImageData != null)
        {
            string base64String = Convert.ToBase64String(savedImageData);
            base64String = "data:image/png;base64," + base64String;
            await ImageEditor.OpenAsync(base64String);
        }
    }
}
```

![Blazor Image Editor with Byte](./images/blazor-image-editor-byte.jpg)

### Save the image as Blob

To save an image as a blob, use the [`GetImageDataUrlAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetImageDataUrlAsync_System_Boolean_) method of the editor to retrieve the image data and convert it into a blob. You can then invoke the open method on the Syncfusion Image Editor instance to load this byte array into the editor. The resulting byte array can be stored in a database for data management and maintenance. 

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="SaveBlobAsync">Save Blob</SfButton>
</div>
<SfImageEditor @ref="ImageEditor" Height="400">
    <ImageEditorEvents Created="OnImageEditorCreated"></ImageEditorEvents>
</SfImageEditor>

@code {
    private SfImageEditor ImageEditor;
    private string blobUrl;

    private async void OnImageEditorCreated()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }

    private async Task SaveBlobAsync()
    {
        var imageDataUrl = await ImageEditor.GetImageDataUrlAsync();
        if (!string.IsNullOrEmpty(imageDataUrl))
        {
            int base64Index = imageDataUrl.IndexOf(',') + 1;
            var base64String = imageDataUrl.Substring(base64Index);
            var bytes = Convert.FromBase64String(base64String);
            var stream = new MemoryStream(bytes);
            blobUrl = "data:image/png;base64," + base64String;
        }
    }
}
```

![Blazor Image Editor with Opening an base 64 image](./images/blazor-image-editor-blob.jpg)

### Save as image in server

The [`GetImageDataUrlAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetImageDataUrlAsync_System_Boolean_) method in the Blazor Image Editor component is used to gets the current image data url from the Image Editor component

The value returned from this method is used to save the edited image to database as well as open in our image editor using The [`OpenAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_OpenAsync_System_Object_System_Boolean_System_String_)method.

N> Increase the connection buffer size in Blazor Image Editor component

The Syncfusion's Blazor Image Editor component allows to increase the connection buffer size by adding the below service in program.cs file if the size of the image is too large.

```cshtml
builder.Services.AddServerSideBlazor().AddHubOptions(o => { o.MaximumReceiveMessageSize = 102400000; });
```

### Remove default Save button and add custom button to save the image to server 

User can leverage the [`Toolbar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_Toolbar) property to replace the default save button with a custom one. By doing so, you can use the [`GetImageDataUrlAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetImageDataUrlAsync_System_Boolean_) method to retrieve the image data, convert it to base64 format, and then save it to the server. This approach gives you more control over the image-saving process.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom: 15px">
    <SfButton OnClick="SaveImage">Save to Server</SfButton>
</div>

<SfImageEditor @ref="ImageEditor" Height="400px" Width="500px" Toolbar="@customToolbar">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor>

@code {
    private SfImageEditor ImageEditor;
    private string base64String;
    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }
    private List<ImageEditorToolbarItemModel> customToolbar = new List<ImageEditorToolbarItemModel>()
    {
        new ImageEditorToolbarItemModel { Name = "Crop" },
        new ImageEditorToolbarItemModel { Name = "Annotation" },
        new ImageEditorToolbarItemModel { Name = "Filter" },
    };
    private async Task SaveImage()
    {
        var imageDataUrl = await ImageEditor.GetImageDataUrlAsync();
        if (!string.IsNullOrEmpty(imageDataUrl))
        {
            int base64Index = imageDataUrl.IndexOf(',') + 1;
            base64String = imageDataUrl.Substring(base64Index);
        }
    }
}
```

![Blazor Image Editor with Save to server](./images/blazor-image-editor-save-to-server.jpg)

### Prevent default save option and save the image to specific location 

User can make use of the [`Saving`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Saving) event, which triggers just before the image is downloaded, to override the default save option by setting `args.cancel` to true. Afterward, you can utilize the [`GetImageDataUrlAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SfImageEditor.html#Syncfusion_Blazor_ImageEditor_SfImageEditor_GetImageDataUrlAsync_System_Boolean_) method to retrieve the current image data and convert it into a format like `byte[]`, `blob`, or `base64` for further processing. This gives you greater flexibility in handling the image data.

```cshtml
@using Syncfusion.Blazor.ImageEditor
@using System.IO

<div>
    <SfImageEditor @ref="ImageEditor" Height="400px" Width="500px">
        <ImageEditorEvents Created="OpenAsync" Saving="OnBeforeSave"></ImageEditorEvents>
    </SfImageEditor>
</div>

@code {
    private SfImageEditor ImageEditor;
    private async void OpenAsync()
    {
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png");
    }
    private async Task OnBeforeSave(SaveEventArgs args)
    {
        args.Cancel = true;
        var imageData = await ImageEditor.GetImageDataUrlAsync();
        if (!string.IsNullOrEmpty(imageData) && imageData.Contains(","))
        {
            var base64Data = imageData.Split(',')[1];
            byte[] imageBytes = Convert.FromBase64String(base64Data);
        }
    }
}
```

![Blazor Image Editor with Specific location](./images/blazor-image-editor-specific-location.jpg)

## Events to handle Save Actions 

The Image Editor provides several events related to opening and saving images. These events offer detailed control over the image handling process. For comprehensive information about these events, including their triggers and usage, please refer to the dedicated section on open and save support. This section will provide you with the specifics needed to effectively utilize these events in your application. 

### File opened event

The [`FileOpened`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_FileOpened) event is triggered in the Blazor Image Editor component after an image is successfully loaded. It provides the [`FileOpenEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FileOpenEventArgs.html) as the event argument, which contains two specific arguments:

[`FileName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FileOpenEventArgs.html#Syncfusion_Blazor_ImageEditor_FileOpenEventArgs_FileName): This argument is a string that contains the file name of the opened image. It represents the name of the file that was selected or provided when loading the image into the Image Editor.

[`FileType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.FileOpenEventArgs.html#Syncfusion_Blazor_ImageEditor_FileOpenEventArgs_FileType): This argument is a string that contains the type of the opened image. It specifies the format or file type of the image that was loaded, such as PNG, JPEG, SVG, WEBP and BMP. 

By accessing these arguments within the `FileOpened` event handler, you can retrieve information about the loaded image, such as its file name and file type. This can be useful for performing additional actions or implementing logic based on the specific image that was opened in the Image Editor component. 

### Saving event

The [`Saving`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Saving) event is triggered in the Blazor Image Editor component when an image is being saved to the local disk. It provides the [`SaveEventArgs `](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SaveEventArgs.html) as the event argument, which includes the following specific arguments:

[`FileName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SaveEventArgs.html#Syncfusion_Blazor_ImageEditor_SaveEventArgs_FileName): This argument is a string that holds the file name of the saved image. It represents the name of the file that will be used when saving the image to the local disk.

[`FileType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SaveEventArgs.html#Syncfusion_Blazor_ImageEditor_SaveEventArgs_FileType): This argument is a string indicating the type or format of the saved image. It specifies the desired file type in which the image will be saved, such as PNG, JPEG, SVG, and WEBP.

[`Cancel`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.SaveEventArgs.html#Syncfusion_Blazor_ImageEditor_SaveEventArgs_Cancel): This argument is a boolean value that can be set to true in order to cancel the saving action. By default, it is set to false, allowing the saving process to proceed. However, if you want to prevent the saving action from occurring, you can set Cancel to true within the event handler.

By accessing these arguments within the Saving event handler, you can retrieve information about the file name and file type of the image being saved. Additionally, you have the option to cancel the saving action if necessary.

### Created event

The [`Created`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Created) event is triggered once the Blazor Image Editor component is created. This event serves as a notification that the component has been fully initialized and is ready to be used. It provides a convenient opportunity to render the Image Editor with a predefined set of initial settings, including the image, annotations, and transformations.

In the following example, the `Created` event is used to load an image.

```cshtml
@using Syncfusion.Blazor.ImageEditor 

<SfImageEditor @ref="ImageEditor" Toolbar="customToolbarItem" Height="400">
    <ImageEditorEvents Created="OpenAsync"></ImageEditorEvents>
</SfImageEditor> 

@code { 
    SfImageEditor ImageEditor; 
    private List<ImageEditorToolbarItemModel> customToolbarItem = new List<ImageEditorToolbarItemModel>() { }; 

    private async void OpenAsync() 
    { 
        await ImageEditor.OpenAsync("https://ej2.syncfusion.com/react/demos/src/image-editor/images/bridge.png"); 
    } 
}
```

![Blazor Image Editor with Opening an image](./images/blazor-image-editor-open.jpg)

### Destroyed event

The [`Destroyed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ImageEditor.ImageEditorEvents.html#Syncfusion_Blazor_ImageEditor_ImageEditorEvents_Destroyed) event is triggered once the Blazor Image Editor component is destroyed or removed from the application. This event serves as a notification that the component and its associated resources have been successfully cleaned up and are no longer active.
