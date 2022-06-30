---
layout: post
title: Getting Started with Blazor Pager Component | Syncfusion
description: Checkout and learn about getting started with Blazor Pager component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Pager
documentation: ug
---

# Getting Started with Blazor Pager Component

This section briefly explains about how to include Blazor Pager component in your Blazor Server App and Blazor WebAssembly App using Visual Studio.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create **Blazor Server App** or **Blazor WebAssembly App** using Visual Studio in one of the following ways:

* [Create a Project using Microsoft Templates](https://docs.microsoft.com/en-us/aspnet/core/blazor/tooling?pivots=windows)

* [Create a Project using Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/vs2019-extensions/create-project)

## Install Syncfusion Blazor NuGet in the App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). To use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details.

To add Blazor Pager component in the app, open the NuGet package manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), search for [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and then install it.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the Syncfusion.Blazor namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the Blazor Server App or Blazor WebAssembly App. Here, Syncfusion Blazor Service is registered by setting [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html?&_ga=2.80827295.945255991.1647838461-1223836246.1561029397#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as true to load the scripts externally in the [next steps](#add-script-reference).

> From 2022 Vol1 (20.1) version - The default value of `IgnoreScriptIsolation` is changed to `true`, so, you don’t have to set the `IgnoreScriptIsolation` property explicitly to refer to scripts externally.

### Blazor Server App

* For **.NET 6** app, open the **~/Program.cs** file and register the Syncfusion Blazor Service.

* For **.NET 5 and .NET 3.X** app, open the **~/Startup.cs** file and register the Syncfusion Blazor Service.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="1 12" %}

using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            builder.Services.AddSyncfusionBlazor();
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

### Blazor WebAssembly App

Open **~/Program.cs** file and register the Syncfusion Blazor Service in the client web app.

{% tabs %}
{% highlight C# tabtitle=".NET 6 (~/Program.cs)" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Program.cs)" hl_lines="1 10" %}

using Syncfusion.Blazor;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}

{% endhighlight %}
{% endtabs %}

## Add Style Sheet

Checkout the [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) to refer themes in Blazor application, and to have the expected appearance for Syncfusion Blazor components. Here, the theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/appearance/themes#enable-static-web-assets-usage) topic to use static assets in your project.

To add a theme to the app, open the NuGet package manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), search for [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and then install it. Then, the theme style sheet from NuGet can be referred to as follows:

### Blazor Server App

* For .NET 6 app, add the Syncfusion bootstrap5 theme in the `<head>` of the **~/Pages/_Layout.cshtml** file.

* For .NET 5 and .NET 3.X app, add the Syncfusion bootstrap5 theme in the `<head>` of the **~/Pages/_Host.cshtml** file.

{% tabs %}
{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}

{% highlight cshtml tabtitle=".NET 5 and .NET 3.X (~/_Host.cshtml)" %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}
{% endtabs %}

### Blazor WebAssembly App

For Blazor WebAssembly App, refer the theme style sheet from NuGet in the `<head>` of **wwwroot/index.html** file in the client web app.

{% tabs %}
{% highlight cshtml tabtitle="~/index.html" %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}
{% endtabs %}

## Add script reference

Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. In this getting started walk-through, the required scripts are referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) externally inside the `<head>` as follows. Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/common/adding-script-references#enable-static-web-assets-usage) topic to use static assets in your project.

### Blazor Server App

* For **.NET 6** app, refer script in the `<head>` of the **~/Pages/_Layout.cshtml** file.

* For **.NET 5 and .NET 3.X** app, refer script in the `<head>` of the **~/Pages/_Host.cshtml** file.

{% tabs %}
{% highlight cshtml tabtitle=".NET 6 (~/_Layout.cshtml)" hl_lines="4" %}

<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!--Use below script reference if you are using Syncfusion.Blazor Single NuGet-->
    <!--<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>-->
</head>

{% endhighlight %}

{% highlight cshtml tabtitle=".NET 5 and .NET 3.X (~/_Host.cshtml)" hl_lines="4" %}

<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!--Use below script reference if you are using Syncfusion.Blazor Single NuGet-->
    <!--<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>-->
</head>

{% endhighlight %}
{% endtabs %}

### Blazor WebAssembly App

For Blazor WebAssembly App, refer script in the `<head>` of the **~/index.html** file.

{% tabs %}
{% highlight html tabtitle="~/index.html" hl_lines="4" %}

<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!--Use below script reference if you are using Syncfusion.Blazor Single NuGet-->
    <!--<script  src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"  type="text/javascript"></script>-->
</head>

{% endhighlight %}
{% endtabs %}

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application.

## Add Blazor Pager component

* Open **~/_Imports.razor** file or any other page under the `~/Pages` folder where the component is to be added and import the **Syncfusion.Blazor.Navigations** namespace.

{% tabs %}
{% highlight razor tabtitle="~/Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

{% endhighlight %}
{% endtabs %}

* Now, add the Syncfusion Blazor Pager component in razor file. Here, the Pager component is added in the **~/Pages/Index.razor** file under the **~/Pages** folder.

In the following sample, Pager component is integrated with ListView component. Pager provides an option to splits the list view data set into sectioned pages and view them into page by page. Here, navigation can be done with built-in numeric elements and buttons that can also be customized with the help of Pager API's.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Lists

<div class="col-lg-12 control-section sb-property-border">
    @{
    var listData = ListData.Skip(SkipValue).Take(TakeValue).ToList();
    <SfListView @ref="@List" DataSource="@listData" TValue="DataModel"  CssClass="e-list-template ui-list" HeaderTitle="Contacts" Height="355px" ShowHeader="true">
        <ListViewTemplates TValue="DataModel">
            <Template>
                <div class='e-list-wrapper e-list-avatar'>
                    @if (context.ImgSrc != string.Empty)
                    {
                        <img id='showUI' class='e-avatar e-avatar-circle' src=@context.ImgSrc/>
                    }
                    <span class='e-list-content'>@context.Name</span>
                </div>
            </Template>
        </ListViewTemplates>
        <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Name"></ListViewFieldSettings>
    </SfListView>
    }
    <div class="pager-container">
        <SfPager @ref="@Page" PageSize=5 NumericItemsCount=2 TotalItemsCount=25 Click="Click">
        </SfPager>
    </div>
</div>
@code {
    SfPager Page;
    public SfListView<DataModel> List { get; set; }
    public int pageSize { get; set; } 
    public int SkipValue ;
    public int TakeValue = 5;
    List<DataModel> ListData = new List<DataModel>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        ListData.Add(new DataModel { Name = "Nancy, Berlin, France",  ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/1.png" });
        ListData.Add(new DataModel { Name = "Andrew, Madrid, Germany", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/3.png" });
        ListData.Add(new DataModel { Name = "Janet, London, Brazil", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/4.png" });
        ListData.Add(new DataModel { Name = "Margaret, Marseille, Belgium",  ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/2.png" });
        ListData.Add(new DataModel { Name = "Steven, Cholchester, Switzerland", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/5.png" });
        ListData.Add(new DataModel { Name = "Laura , Tsawassen, Venezuela",ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/6.png" });
        ListData.Add(new DataModel { Name = "Robert, Tacoma, Austria", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/7.png" });
        ListData.Add(new DataModel { Name = "Michael, Redmond, Mexico", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/8.png" });
        ListData.Add(new DataModel { Name = "Albert, Kirkland, USA", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/9.png" });
        ListData.Add(new DataModel { Name = "Nolan, London, Sweden",ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/1.png" });
        ListData.Add(new DataModel { Name = "Jennifer, Berlin, Finland", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/3.png" });
        ListData.Add(new DataModel { Name = "Carter, Madrid, Italy", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/2.png" });
        ListData.Add(new DataModel { Name = "Allison, Marseille, Spain", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/4.png" });
        ListData.Add(new DataModel { Name = "John, Tsawassen, UK", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/5.png" });
        ListData.Add(new DataModel { Name = "Susan, Redmond, Ireland" ,ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/7.png" });
        ListData.Add(new DataModel { Name = "Lydia, Cholchester, Portugal", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/6.png" });
        ListData.Add(new DataModel { Name = "Kelsey, London, Canada", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/9.png" });
        ListData.Add(new DataModel { Name = "Jessica, Kirkland, Denmark", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/8.png" });
        ListData.Add(new DataModel { Name = "Robert, Berlin, Austria", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/5.png" });
        ListData.Add(new DataModel { Name = "Shelley, Tacoma, Poland", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/3.png" });
        ListData.Add(new DataModel { Name = "Vanjack, Tsawassen, Norway", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/1.png" });
        ListData.Add(new DataModel { Name = "shelley, Cholchester, Argentina", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/8.png" });
        ListData.Add(new DataModel { Name = "Lydia, Kirkland, Finland", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/7.png" });
        ListData.Add(new DataModel { Name = "Jessica, Madrid, Sweden", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/4.png" });
        ListData.Add(new DataModel { Name = "Nolan, London, UK", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/9.png" });
        ListData.Add(new DataModel { Name = "Jennifer, Redmond, Italy", ImgSrc = "https://ej2.syncfusion.com/demos/src/grid/images/2.png" });
    }
    public void Click(PageClickEventArgs args)
    {
        SkipValue = (args.CurrentPage * Page.PageSize) - Page.PageSize;
        TakeValue = Page.PageSize;
    }
    public class DataModel
    {
        public string Name { get; set; }
        public string ImgSrc { get; set; }
        public string Id { get; set; }
    }
}
<style>
    /* ListView template customization */
    .ui-list.e-listview {
        margin: auto;
        max-width: 460px;
        line-height: initial;
        border: 1px solid lightgray;
    }
    .ui-list.e-listview .e-list-header {
        height: 50px
    }
    .ui-list.e-listview .e-list-header .e-text {
        line-height: 18px;
        padding-left: 10px;
    }
    .ui-list.e-listview #showUI {
        display: flex;
    }
    .ui-list.e-listview .e-list-item {
        padding: 3px 0;
    }
    .highcontrast .ui-list.e-listview .e-list-item.e-active {
        background: #ffd939;
        color: #000000;
    }
    .pager-container {
        margin: 0 auto 2em;
        max-width: 460px;
    }
</style>

```

![Blazor Pager with ListView](./images/blazor-pager-with-list-view.png)