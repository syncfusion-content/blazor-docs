---
layout: post
title: Perform read operation in Blazor FileManager Component with Amazon cloud | Syncfusion
description: Checkout and learn here all about read operation of Syncfusion Blazor FileManager component with injected Amazon cloud service and more.
platform: Blazor
control: File Manager
documentation: ug
---

To perform a read operation in Syncfusion Blazor FileManager component with Injected amazon cloud service, 

**Step 1:** Initialize action event

Initialize the [OnRead]() event to the FileManager using the **FileManagerEvents**, which requires the **TValue** to be provided.

This event enable you to access essential item details from the event argument. Subsequently, update the File Manager’s result data by incorporating the data returned from the injected service. Assign this returned data to the Response property.

**Step 2:** Initialize injected service with read operation.

To set up a locally injected physical service, create a new file with the extension `.cs` within the project, include the following GitHub file code in this file, and then proceed to inject the created service into the `program.cs` file.

N> [View FileManagerService.cs in GitHub ](https://github.com/SyncfusionExamples/blazor-filemanager-with-flat-data/blob/master/FileManagerService.cs).

**Program.cs**

{% tabs %}
{% highlight c# %}

using InjectedAmazonService;
using InjectedAmazonService.Data;
using Syncfusion.Blazor;

...
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton<FileManagerAmazonService>();

{% endhighlight %}
{% endtabs %}


**FileManagerAmazonService.cs**

{% tabs %}
{% highlight c# %}

public FileManagerAmazonService()
{
     RegisterAmazonS3("bucket-name", "<--awsAccessKeyId-->", "<--awsSecretAccessKey-->", "bucket-region");
 
}// Register the Amazon client details
public void RegisterAmazonS3(string name, string awsAccessKeyId, string awsSecretAccessKey, string region)
{
     bucketName = name;
     RegionEndpoint bucketRegion = RegionEndpoint.GetBySystemName(region);
     client = new AmazonS3Client(awsAccessKeyId, awsSecretAccessKey, bucketRegion);
     GetBucketList();
}

public async Task<FileManagerResponse<FileManagerDirectoryContent>> GetFiles(string path, bool showHiddenItems, params FileManagerDirectoryContent[] data)
{
    FileManagerDirectoryContent cwd = new FileManagerDirectoryContent();
    List<FileManagerDirectoryContent> files = new List<FileManagerDirectoryContent>();
    List<FileManagerDirectoryContent> filesS3 = new List<FileManagerDirectoryContent>();
    FileManagerResponse<FileManagerDirectoryContent> readResponse = new FileManagerResponse<FileManagerDirectoryContent>();
    await GetBucketList();
    try
    {
        if (path == "/") await ListingObjectsAsync("/", RootName, false); else await ListingObjectsAsync("/", RootName.Replace("/", "") + path, false);
        if (path == "/")
        {
            List<FileManagerDirectoryContent> s = new List<FileManagerDirectoryContent>(); // Use a list instead of an array
            foreach (var y in response.S3Objects.Where(x => x.Key == RootName)) // Use foreach loop to iterate over the filtered S3Objects
            {
                s.Add(await CreateDirectoryContentInstanceAsync(y.Key.ToString().Replace("/", ""), false, "Folder", y.Size, y.LastModified, y.LastModified, checkChild(y.Key), string.Empty)); // Add the result of CreateDirectoryContentInstance to the list
            }
            if (s.Count > 0) cwd = s[0];
        }
        else
        {
            cwd = await CreateDirectoryContentInstanceAsync(path.Split("/")[path.Split("/").Length - 2], false, "Folder", 0, DateTime.Now, DateTime.Now, Task.FromResult(response.CommonPrefixes.Count > 0 ? true : false), path.Substring(0, path.IndexOf(path.Split("/")[path.Split("/").Length - 2])));
        }
    }
    catch (Exception ex) { throw ex; }
    try
    {
        if (response.CommonPrefixes.Count > 0)
        {
            foreach (var prefix in response.CommonPrefixes)
            {
                var file = await CreateDirectoryContentInstanceAsync(getFileName(prefix, path), false, "Folder", 0, DateTime.Now, DateTime.Now, checkChild(prefix), getFilePath(prefix));
                files.Add(file);
            }
        }
    }
    catch (Exception ex) { throw ex; }
    try
    {
        if (path == "/") ListingObjectsAsync("/", RootName, false).Wait(); else ListingObjectsAsync("/", RootName.Replace("/", "") + path, false).Wait();
        if (response.S3Objects.Count > 0)
        {
            foreach (var obj in response.S3Objects.Where(x => x.Key != RootName.Replace("/", "") + path))
            {
                var file = await CreateDirectoryContentInstanceAsync(obj.Key.ToString().Replace(RootName.Replace("/", "") + path, "").Replace("/", ""), true, Path.GetExtension(obj.Key.ToString()), obj.Size, obj.LastModified, obj.LastModified, checkChild(obj.Key), getFilterPath(obj.Key, path));
                filesS3.Add(file);
            }
        }
    }
    catch (Exception ex) { throw ex; }
    if (filesS3.Count != 0) files = files.Union(filesS3).ToList();
    readResponse.CWD = cwd;
    try
    {
        if (cwd.Permission != null && !cwd.Permission.Read)
        {
            readResponse.Files = null;
            accessMessage = cwd.Permission.Message;
            throw new UnauthorizedAccessException("'" + cwd.Name + "' is not accessible. You need permission to perform the read action.");
        }
    }
    catch (Exception e)
    {
        ErrorDetails er = new ErrorDetails();
        er.Message = e.Message.ToString();
        er.Code = er.Message.Contains("is not accessible. You need permission") ? "401" : "417";
        if (er.Code == "401" && !string.IsNullOrEmpty(accessMessage)) { er.Message = accessMessage; }
        readResponse.Error = er;
        await Task.Yield();
        return await Task.FromResult(readResponse);
    }
    readResponse.Files = files;
    await Task.Yield();
    return await Task.FromResult(readResponse);
}
 
private string getFilePath(string pathString)
{
    return pathString.Substring(0, pathString.Length - pathString.Split("/")[pathString.Split("/").Length - 2].Length - 1).Substring(RootName.Length - 1);
}
 
private string getFileName(string fileName, string path)
{
    return fileName.Replace(RootName.Replace("/", "") + path, "").Replace("/", "");
}
 
private async Task<FileManagerDirectoryContent> CreateDirectoryContentInstanceAsync(string name, bool value, string type, long size, DateTime createddate, DateTime modifieddate, Task<bool> child, string filterpath)
{
    FileManagerDirectoryContent tempFile = new FileManagerDirectoryContent();
    tempFile.Name = name;
    tempFile.IsFile = value;
    tempFile.Type = type;
    tempFile.Size = size;
    tempFile.DateCreated = createddate;
    tempFile.DateModified = modifieddate;
    tempFile.HasChild = await child;
    tempFile.FilterPath = filterpath;
    tempFile.Permission = GetPathPermission(filterpath + (value ? name : Path.GetFileNameWithoutExtension(name)), value);
    return tempFile;
}

{% endhighlight %}
{% endtabs %}
**Step 3:** Read

The initial set of files and folders can be retrieved from the required service and mapped to the File Manager through the [OnRead]() event response.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.FileManager
@using InjectedAmazonService.Data
@inject FileManagerAmazonService FileManagerAmazonService

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent" OnRead="OnReadAsync">
    </FileManagerEvents>
</SfFileManager>

@code{

    public async Task OnReadAsync(ReadEventArgs<FileManagerDirectoryContent> args)
    {
        args.Response = await FileManagerAmazonService.GetFiles(args.Path, false, args.Folder.ToArray());
    }
}

{% endhighlight %}
{% endtabs %}


