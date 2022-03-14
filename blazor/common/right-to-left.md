---
layout: post
title: Right-To-Left (RTL) support in Blazor components | Syncfusion
description: Check out the documentation to enable the Right-To-Left (RTL) support for Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Right-To-Left Support in Syncfusion Blazor Components

The right-to-left (RTL) support can be enabled for Syncfusion Blazor components by setting `EnableRtl` property to `true`. This will render all the Syncfusion Blazor components in the right-to-left direction.

## Enable RTL for all components

You can enable right to left (RTL) for all Syncfusion components used in the application by setting [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) global option as `true` while adding Syncfusion Blazor service using `AddSyncfusionBlazor()`.

### Blazor Server App

* If you're using `.NET 6` Blazor Server App, set [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

    ```c#
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Syncfusion.Blazor;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    ....
    builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
    var app = builder.Build();
    ....
    ```

* If you're using `.NET 5 or .NET Core 3.1 ` Blazor Server App, set [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) property as `true` using `AddSyncfusionBlazor` service method in `~/Startup.cs` file.

    ```c#
    using Syncfusion.Blazor;
    namespace WebApplication1
    {
        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
            {
                ....
                services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
            }
        }
    }
    ```
    
### Blazor WebAssembly App

If you're using Blazor WebAssembly App, set [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.
    
* For .NET 6 Blazor WebAssembly App

    ```c#
    using Microsoft.AspNetCore.Components;
    using Microsoft.AspNetCore.Components.Web;
    using Syncfusion.Blazor;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    ....
    builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
    var app = builder.Build();
    ....
    ```
    
* For .NET 5 or .NET Core 3.1 Blazor WebAssembly App
    ```c#
    using Syncfusion.Blazor;
    ....
    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args)    ;
        ....

        builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });
        await builder.Build().RunAsync();
    }
    ```

The above configuration enables the Right-To-Left (RTL) support globally for all the Syncfusion Blazor components. For illustration, the Syncfusion Blazor DataGrid component is displayed with Right-To-Left (RTL).

![Blazor Grid component is rendered from the right to left](images/rteGrid.png)

## Enable RTL to individual component

You can enable right to left (RTL) for particular component by setting component's `EnableRtl` property to `true`.

In the below code example, right to left enabled for `SfDropDownList` component by directly setting `EnableRtl` property.

```cshtml

@using Syncfusion.Blazor.DropDowns

<SfDropDownList TValue="string" Placeholder="Select the country" TItem="Countries" DataSource="@CountryList" EnableRtl="true">
    <DropDownListFieldSettings Text="Name" Value="Code"></DropDownListFieldSettings>
</SfDropDownList>

@code {

    SfDropDownList<string, Countries> dropdownObj;

    public class Countries
    {
        public string Name { get; set; }

        public string Code { get; set; }
    }
    List<Countries> CountryList = new List<Countries>
    {
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" }
    };
}

```

![Blazor component is rendered from the right-to-left](images/rightToLeft.png)


