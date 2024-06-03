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

### Blazor Web App

* For  Blazor Web App, set [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

{% tabs %}

{% highlight c# tabtitle="~/Program.cs" hl_lines="3" %}

using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor(options => { options.EnableRtl = true; });


{% endhighlight %}

{% endtabs %}

### Blazor Server App

* For `.NET 6 or .NET 7` Blazor Server App, set [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

{% tabs %}

{% highlight c# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" %}

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

{% endhighlight %}

{% endtabs %}

### Blazor WebAssembly App

If you're using Blazor WebAssembly App, set [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_EnableRtl) property as `true` using `AddSyncfusionBlazor` service method in `~/Program.cs` file.

{% tabs %}

{% highlight c# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" %}

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

{% endhighlight %}

{% endtabs %}

The above configuration enables the Right-To-Left (RTL) support globally for all the Syncfusion Blazor components. For illustration, the Syncfusion Blazor DataGrid component is displayed with Right-To-Left (RTL).

![Blazor Grid component is rendered from the right to left](images/rtegrid.png)

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

![Blazor component is rendered from the right-to-left](images/righttoleft.png)