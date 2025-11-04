---
layout: post
title: Resizing the Image Before Sending to the Server | Syncfusion
description: Learn here all about Resizing the Image Before Sending to the Server in Blazor File Upload Component and more details.
platform: Blazor
control: File Upload
documentation: ug
---

# Resizing the Image Before Sending to the Server

To resize an image before sending the uploaded file to the server, you can utilize an Image instance. The provided code demonstrates how to take an uploaded image, resize it to the desired dimensions, and save it to a specified file path. This ensures that the image is adjusted to fit the required width and height before being stored. For your convenience.


{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs
@inject HttpClient Http

<div class="input-group">
	
	<SfUploader ID="UploadFiles" AllowedExtensions=".jpg, .jpg, .png, .png, .jpeg, .jpeg, .heic, .heic">
     <UploaderEvents ValueChange="@OnChange"></UploaderEvents>
</SfUploader>
</div>

@code {
    List<ImageFile> filesBase64  = new List<ImageFile>();
    public async Task OnChange(UploadChangeEventArgs args)
    {
        filesBase64.Clear();
        var files = args.Files; // get the files selected by the users
        foreach (var file in files)
        {
            var resizedFile  = await file.File.RequestImageFileAsync(file.FileInfo.MimeContentType, 640, 480); // resize the image file
            var formContent = new MultipartFormDataContent
            {
                { new StreamContent(file.File.OpenReadStream(file.File.Size)), "upload", file.File.Name },
                { new StringContent(file.File.ContentType), "content-type" }
            };
            var buf = new byte[resizedFile.Size]; // allocate a buffer to fill with the file's data
            using (var stream = resizedFile.OpenReadStream())
            {
                await stream.ReadAsync(buf); // copy the stream to the buffer
            }
            filesBase64.Add(new ImageFile { base64data = Convert.ToBase64String(buf), contentType =file.File.ContentType, fileName = file.File.Name }); // convert to a base64 string!!
        }
        await Http.PostAsJsonAsync<List<ImageFile>>("/api/SampleData", filesBase64, System.Threading.CancellationToken.None);
    }
    public class ImageFile
    {
        public string base64data { get; set; }
        public string contentType { get; set; }
        public string fileName { get; set; }
    }
   
}

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight cshtml %}

 [HttpPost]
public async Task Post([FromBody] ImageFile[] files)
{
    foreach (var file in files)
    {
        var buf = Convert.FromBase64String(file.base64data);
        await System.IO.File.WriteAllBytesAsync(hostingEnv.ContentRootPath + System.IO.Path.DirectorySeparatorChar + Guid.NewGuid().ToString("N") + "-" + file.fileName, buf);
    }
}

{% endhighlight %}
{% endtabs %}
