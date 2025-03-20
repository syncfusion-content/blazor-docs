---
layout: post
title: Customize HTTP handler | Syncfusion
description: Learn here all about customizing the HTTP handler in the Windows authenticated client application for Blazor FileManager.
platform: Blazor
control: File Manager
documentation: ug
---

# Customize HTTP handler

In secured applications, API operations including file management, image retrieval, uploads, and downloads often require authentication tokens. The Blazor File Manager component provides comprehensive support for adding authorization headers to all requests through various settings and events including [FileManagerUploadSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html), [OnSend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnSend), [BeforeImageLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeImageLoad), and [BeforeDownload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeDownload).

## Understanding the Security Challenge

When working with secured APIs, all operations need proper authentication. There are several challenges:

1. Adding authentication tokens to regular file operations (read, create, delete, etc.)
2. Adding authentication tokens to image requests
3. Adding authentication tokens to download operations
4. Adding authentication tokens to upload operations

## Solution Overview

The Blazor File Manager component offers solutions for all these challenges:

* For regular file operations and uploads: Use the [OnSend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnSend) event to add authentication headers
* For upload operations: Configure [FileManagerUploadSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerUploadSettings.html) with [UploadMode.HttpClient](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.UploadMode.html#Syncfusion_Blazor_FileManager_UploadMode_HttpClient)
* For image operations: Use the [BeforeImageLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeImageLoad) event with [UseImageAsUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.BeforeImageLoadEventArgs-1.html#Syncfusion_Blazor_FileManager_BeforeImageLoadEventArgs_1_UseImageAsUrl) as `false`
* For download operations: Use the [BeforeDownload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeDownload) event with [UseFormPost](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.BeforeDownloadEventArgs-1.html#Syncfusion_Blazor_FileManager_BeforeDownloadEventArgs_1_UseFormPost) as `false`

## Setting Authorization Headers for File Operations and Uploads

For regular file operations (listing files, delete, rename, etc.) and uploads, you can add authorization headers using the [OnSend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnSend) event. To enable HTTP client-based uploads, set the [UploadMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.UploadMode.html#Syncfusion_Blazor_FileManager_UploadMode) to [HttpClient](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.UploadMode.html#Syncfusion_Blazor_FileManager_UploadMode_HttpClient):

```csharp
<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://your-api-endpoint/api/FileManager/FileOperations"
                             UploadUrl="https://your-api-endpoint/api/FileManager/Upload"
                             DownloadUrl="https://your-api-endpoint/api/FileManager/Download"
                             GetImageUrl="https://your-api-endpoint/api/FileManager/GetImage">
    </FileManagerAjaxSettings>
    <FileManagerUploadSettings UploadMode="UploadMode.HttpClient"></FileManagerUploadSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" OnSend="OnBeforeSend"></FileManagerEvents>
</SfFileManager>

@code {
    public void OnBeforeSend(BeforeSendEventArgs args)
    {
        // Add authorization header to all operations including upload
        args.HttpClientInstance.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("scheme", "your-token-here");
    }
}
```

The [OnSend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnSend) event is triggered for various file operations including:
* read - For listing files and folders
* delete - For deleting files and folders
* copy - For copying files and folders
* move - For moving files and folders
* details - For retrieving file or folder details (e.g., size, type, modified date)
* create - For creating new folders.
* search - For searching files and folders
* rename - For renaming files and folders
* upload - For uploading files

## Setting Authorization Headers for Image Operations

For image operations, you'll need to use the [BeforeImageLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeImageLoad) event with the [UseImageAsUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.BeforeImageLoadEventArgs-1.html#Syncfusion_Blazor_FileManager_BeforeImageLoadEventArgs_1_UseImageAsUrl) property:

```csharp
<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent" 
                      BeforeImageLoad="HandleBeforeImageLoad">
    </FileManagerEvents>
</SfFileManager>

@code {
    private void HandleBeforeImageLoad(BeforeImageLoadEventArgs<FileManagerDirectoryContent> args)
    {
        // Switch to HTTP Client-based approach instead of direct URL
        args.UseImageAsUrl = false;
        
        // Add your authorization header
        args.HttpClientInstance.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("scheme", "your-token-here");
    }
}
```

> **Note:** 
> 
> When implementing HTTP Client-based image operations, you'll need to modify your server-side API endpoint to accept the parameters as a request body rather than query parameters:
> 
> ```csharp
> [Route("GetImage")]
> public IActionResult GetImage([FromBody] FileManagerDirectoryContent args)
> {
>     return this.operation.GetImage(args.Path, args.Id, false, null, null);
> }
> ```

## Setting Authorization Headers for Download Operations

For download operations, you can use the [BeforeDownload](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_BeforeDownload) event with the [UseFormPost](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.BeforeDownloadEventArgs-1.html#Syncfusion_Blazor_FileManager_BeforeDownloadEventArgs_1_UseFormPost) property:

```csharp
<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerEvents TValue="FileManagerDirectoryContent" 
                      BeforeDownload="HandleBeforeDownload">
    </FileManagerEvents>
</SfFileManager>

@code {
    public void HandleBeforeDownload(BeforeDownloadEventArgs<FileManagerDirectoryContent> args)
    {
        // Switch to HTTP Client-based approach instead of form post
        args.UseFormPost = false;
        
        // Add your authorization header
        args.HttpClientInstance.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("scheme", "your-token-here");
    }
}
```

> **Note:** 
> 
> For HTTP Client-based download operations, configure your server endpoint to accept request body parameters:
>
> ```csharp
> [Route("Download")]
> public IActionResult Download([FromBody] FileManagerDirectoryContent args)
> {
>     return this.operation.Download(args.Path, args.Names, args.Data);
> }
> ```

## Windows Authentication with JWT in Blazor File Manager

This section explains how to create a Blazor server application with Windows authentication and JWT token handling for the File Manager component.

### Create Windows Authenticated Blazor Server Application

You can create a Blazor server application with Windows authentication using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

![Authentication](../images/customize-http-handler.png)

Include the [Microsoft.AspNetCore.Authentication.JWTBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) package for generating user tokens.

Initialize the File Manager component in the **~/Pages/Index.razor** file using the [Getting Started with Blazor File Manager Component](https://blazor.syncfusion.com/documentation/file-manager/getting-started) documentation.

### Implementing JWT Token Generation and Authorization

To authorize the File Manager component server response, generate a user token in the **onInitialized** method based on the user's authentication state. Then, pass this user token as a header through the File Manager component's HTTP client instance in the component's events.

```csharp

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://localhost:/api/FileManager/FileOperations"
                             UploadUrl="https://localhost:/api/FileManager/Upload"
                             DownloadUrl="https://localhost:/api/FileManager/Download"
                             GetImageUrl="https://localhost:/api/FileManager/GetImage"></FileManagerAjaxSettings>
    <FileManagerUploadSettings UploadMode="UploadMode.HttpClient"></FileManagerUploadSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" 
                       OnSend="OnBeforeSend"
                       BeforeImageLoad="HandleBeforeImageLoad"
                       BeforeDownload="HandleBeforeDownload">
    </FileManagerEvents>
</SfFileManager>
@code {
    [CascadingParameter]
    private Task<AuthenticationState> authenticationStateTask { get; set; }
    public static System.Text.Encoding UTF8 { get; }
    public string response;
    string text = "Testing";
    public string Token;
    public string name;
    public bool isRead = true;
    protected async override Task OnInitializedAsync()
    {
        var authState = await authenticationStateTask;
        var user = authState.User;
        //Generate user token based on the user authenticated state.
        if (user.Identity.IsAuthenticated)
        {
            Token = GenerateToken(user);
        }
    }
    private string GenerateToken(ClaimsPrincipal user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Assign your security key"));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //Assign the user role value of authenticate server response
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray();
        roles = new string[] { "user role" };
        name = user.Identity.Name;
        var claims = new[]
        {
                new Claim(ClaimTypes.NameIdentifier,user.Identity.Name),
                new Claim(ClaimTypes.Role,string.Join(",", roles))
        };
        var token = new JwtSecurityToken("Issuer host link(server)",
        "Audience host link(client)",
        claims,
        expires: DateTime.Now.AddMinutes(15),
        signingCredentials: credentials);
        return new JwtSecurityTokenHandler().WriteToken(token);

    }
    public async Task OnBeforeSend(BeforeSendEventArgs args)
    {
        if (isRead && args.Action == "read")
        {
            //Pass the user token through File Manager HTTP client instance.
            args.HttpClientInstance.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            isRead = false;
        }

        if (args.Action == "Upload")
        {
            args.HttpClientInstance.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
        }
    }
    
    // Handle image operations
    private void HandleBeforeImageLoad(BeforeImageLoadEventArgs<FileManagerDirectoryContent> args)
    {
        // Switch to HTTP Client-based approach 
        args.UseImageAsUrl = false;
        
        // Add JWT token for image requests
        args.HttpClientInstance.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", Token);
    }
    
    // Handle download operations
    private void HandleBeforeDownload(BeforeDownloadEventArgs<FileManagerDirectoryContent> args)
    {
        // Switch to HTTP Client-based approach
        args.UseFormPost = false;
        
        // Add JWT token for download requests
        args.HttpClientInstance.DefaultRequestHeaders.Authorization = 
            new AuthenticationHeaderValue("Bearer", Token);
    }
}

```

## Create service application for File Manager action

Create a new **ASP Core web application** with the required File Manager service models and controller, or clone the required service provider from the [file-system-provider](https://blazor.syncfusion.com/documentation/file-manager/file-system-provider) documentation that contains the available file service provider.

To demonstrate behavior with a physical service provider, include the [Microsoft.AspNetCore.Authentication.JWTBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer), [Microsoft.IdentityModel.Tokens](https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens) and [System.IdentityModel.Tokens.JWT](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt) packages for accessing the authorized token value on the service application.

Open **appsettings.json** and add the following key, issuer, and audience in the server application.

```json

  "Jwt": {
    "Key": "your security key", 
    "Issuer": "Issuer host link(server)", 
    "Audience": "Audience host link(client)"
  },

```

Configure the authentication code details in the service application’s **program.cs** file.

```cshtml

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.UseCors("AllowAllOrigins");
app.UseEndpoints(endPoints =>
{
    endPoints.MapControllers();
});
app.Run();

```

Now it can authorize the File Manager server response based on the authorized role that is assigned by the client application, as shown below.

```cshtml

public class FileManagerController : Controller
    {
        PhysicalFileProvider operation;
        string basePath;
        string root = "wwwroot\\Files";

        public FileManagerController(IWebHostEnvironment hostingEnvironment)
        {
            this.basePath = hostingEnvironment.ContentRootPath;
            //this.basePath = "wwwroot";

            this.operation = new PhysicalFileProvider();
            if (this.basePath.EndsWith("\\"))
                this.operation.RootFolder(this.basePath + this.root);
            else
                this.operation.RootFolder(this.basePath + "\\" + this.root);
        }
        //Validate the requested response using assigned role value
        [Route("FileOperations")]
        [Authorize(Roles = "user role")]
        public object FileOperations([FromBody] FileManagerDirectoryContent args)
        {
            if (args.Action == "delete" || args.Action == "rename")
            {
                if ((args.TargetPath == null) && (args.Path == ""))
                {
                    FileManagerResponse response = new FileManagerResponse();
                    response.Error = new ErrorDetails { Code = "401", Message = "Restricted to modify the root folder." };
                    return this.operation.ToCamelCase(response);
                }
            }
            switch (args.Action)
            {
                case "read":
                    // reads the file(s) or folder(s) from the given path.
                    return this.operation.ToCamelCase(this.operation.GetFiles(args.Path, args.ShowHiddenItems));
                    ...
            }
        }
        
        [Route("Upload")]
        [Authorize(Roles = "user role")]
        public IActionResult Upload()
        {
            FileManagerResponse uploadResponse;
            ...
            return Content("");
        }
        
        [Route("GetImage")]
        [Authorize(Roles = "user role")]
        public IActionResult GetImage([FromBody] FileManagerDirectoryContent args)
        {
            return _fileProvider.GetImage(args.Path, args.Id, false, null, null);
        }
        
        [Route("Download")]
        [Authorize(Roles = "user role")]
        public IActionResult Download([FromBody] FileManagerDirectoryContent args)
        {
            return _fileProvider.Download(args.Path, args.Names, args.Data);
        }

```

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-FileManager-WindowsAuthentication/tree/master).
