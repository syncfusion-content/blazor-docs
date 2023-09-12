---
layout: post
title: HTTP handler customization in FileManager Windows authenticated application | Syncfusion
description: Learn here all about customizing HTTP hanlder in Blazor windows authenticated client FileManager application.
platform: Blazor
control: File Manager
documentation: ug
---

# HTTP handler customization in FileManager Windows authenticated application

This documentation provides step-by-step instructions on customizing the HTTP handler to access authenticated responses from the server in a Blazor FileManager application. This process is specifically tailored to use Windows authentication and involves passing generated user tokens from the client application through the FileManager component's HTTP client instance.

## Create client windows Authenticated Blazor FileManager application:

Create a Blazor server application with Windows authentication, like in the below screenshot.

**Screenshot:**

![Authentication](../images/http-handler-customization-in-windows-authenticated-client-filemanager-application.png)

Implement the Syncfusion FileManager component using the [Getting Started with Blazor FileManager Component](https://blazor.syncfusion.com/documentation/file-manager/getting-started) documentation.

Additionally, include the below-mentioned package for generating user tokens.

{% tabs %}
{% highlight C# tabtitle=".csproj" %}

<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="6.0.8" />

{% endhighlight %}
{% endtabs %}

To authorize the FileManager component server response, create the user token with the user **Role** based on the user authentication in the client application and pass it as a header through the FileManager HTTP client instance.

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

**Create server application for FileManager response:**

Create a new ASP Core web application with the required FileManager service models and controller, or clone the required service provider from the [file-system-provider](https://blazor.syncfusion.com/documentation/file-manager/file-system-provider) documentation that contains the available file service provider.

To demonstrate behavior with a physical service provider, include the below-mentioned package for accessing the authorized token value on the server.

{% tabs %}
{% highlight C# tabtitle=".csproj" %}

<PackageReference Include="Microsoft.AspNetCore.Authentication.JwtBearer" Version="6.0.8" />
<PackageReference Include="Microsoft.IdentityModel.Tokens" Version="6.22.1" />
<PackageReference Include="System.IdentityModel.Tokens.Jwt" Version="6.22.1" />

{% endhighlight %}
{% endtabs %}

Open **appsetting.json** and add the following key, issuer, and audience in the server application.

```json

  "Jwt": {
    "Key": "your security key", 
    "Issuer": "Issuer host link(server)", 
    "Audience": "Audience host link(client)"
  },

```

Configure the authentication code details in the server application’s **program.cs** file.

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

Now it can authorize the server response based on the authorized role that is assigned by the client application, as shown below.

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

[GitHub sample](https://github.com/SyncfusionExamples/Blazor-FileManager-WindowsAuthentication/tree/master)
