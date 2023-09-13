---
layout: post
title: Customize HTTP handler | Syncfusion
description: Learn here all about customizing the HTTP handler in the Windows authenticated client application for Blazor FileManager.
platform: Blazor
control: File Manager
documentation: ug
---

# Customize HTTP handler

In a Blazor FileManager component, you can customize the HTTP handler to access authenticated server responses. This involves using authentication and passing user tokens through the FileManager component's HTTP client.

## Create client windows authenticated Blazor FileManager application

You can create a Blazor server application with Windows authentication using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

![Authentication](../images/customize-http-handler.png)

Include the [Microsoft.AspNetCore.Authentication.JwtBearer](https://www.nuget.org/packages/Microsoft.AspNetCore.Authentication.JwtBearer) package for generating user tokens.

{% tabs %}

<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="6.0.8" />

{% endtabs %}

Initialize the FileManager component in the **~/Pages/Index.razor** file using the [Getting Started with Blazor FileManager Component](https://blazor.syncfusion.com/documentation/file-manager/getting-started) documentation.

To authorize the FileManager component server response, generate a user token in the **onInitialized** method based on the user's authentication state. Then, pass this user token as a header through the FileManager component's HTTP client instance in the component's [OnSend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.FileManager.FileManagerEvents-1.html#Syncfusion_Blazor_FileManager_FileManagerEvents_1_OnSend) event.

```cshtml

<SfFileManager TValue="FileManagerDirectoryContent">
    <FileManagerAjaxSettings Url="https://localhost:/api/FileManager/FileOperations"
                             UploadUrl="https://localhost:/api/FileManager/Upload"
                             DownloadUrl="https://localhost:/api/FileManager/Download"
                             GetImageUrl="https://localhost:/api/FileManager/GetImage"></FileManagerAjaxSettings>
    <FileManagerEvents TValue="FileManagerDirectoryContent" OnSend="OnBeforeSend"></FileManagerEvents>
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
            //Pass the user token through FileManager HTTP client instance.
            args.HttpClientInstance.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
            isRead = false;
        }
    }
}

```

## Create service application for FileManager action

Create a new **ASP Core web application** with the required FileManager service models and controller, or clone the required service provider from the [file-system-provider](https://blazor.syncfusion.com/documentation/file-manager/file-system-provider) documentation that contains the available file service provider.

To demonstrate behavior with a physical service provider, include the [Microsoft.AspNetCore.Authentication.JwtBearer](), [Microsoft.IdentityModel.Tokens](https://www.nuget.org/packages/Microsoft.IdentityModel.Tokens) and [System.IdentityModel.Tokens.Jwt](https://www.nuget.org/packages/System.IdentityModel.Tokens.Jwt) packages for accessing the authorized token value on the service application.

{% tabs %}

<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="6.0.8" />
<PackageReference Include="Microsoft.IdentityModel.Tokens" Version="6.22.1" />
<PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="6.22.1" />

{% endtabs %}

Open **appsetting.json** and add the following key, issuer, and audience in the server application.

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

Now it can authorize the FileManager server response based on the authorized role that is assigned by the client application, as shown below.

```cshtml

public class FileManagerController : Controller
    {
        PhysicalFileProvider operation;
        string basePath;
        string root = "wwwroot\\Files";

        [Obsolete]
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

```

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-FileManager-WindowsAuthentication/tree/master).
