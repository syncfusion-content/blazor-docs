---
layout: post
title: Getting started with Syncfusion Pager Component in Blazor Web App
description: Check out the documentation for getting started with Syncfusion Blazor Pager Components in Blazor Web App.
platform: Blazor
control: Pager
documentation: ug
---

# Getting started with Blazor Pager Component in Blazor Web App

This section briefly explains about how to include `Blazor Pager` component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio Code.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Navigations and Themes NuGet in the App

To add **Blazor Pager** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Navigations -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

You can create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) while creating a Blazor Web Application.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands.

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

N> For more information on creating a **Blazor Web App** with various interactive modes and locations, refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Navigations and Themes NuGet in the App

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Navigations -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

| Interactive Render Mode | Description |
| -- | -- |
| WebAssembly or Auto | Open **~/_Imports.razor** file from the client project.|
| Server | Open **~/_import.razor** file, which is located in the `Components` folder.|

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Navigations` namespace.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, you need to register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in both **~/Program.cs** files of your Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle="Client(~/_Program.cs)" hl_lines="2 5" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

If the **Interactive Render Mode** is set to `Server`, your project will contain a single **~/Program.cs** file. So, you should register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service only in that **~/Program.cs** file.

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Blazor Pager component

Here, the Pager component is integrated with the ListView component. So, the first ListView component is added in the **~Pages/.razor** file. Refer [here](https://blazor.syncfusion.com/documentation/listview/getting-started) to create the Syncfusion<sup style="font-size:70%">&reg;</sup> ListView component.If an interactivity location as `Per page/component` in the web app, define a render mode at the top of the `~Pages/.razor` component, as follows:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly` or `Server`, the render mode is configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Lists

<SfListView DataSource="@ListData" TValue="DataModel">
        <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Name"></ListViewFieldSettings>
</SfListView>

@code {
    List<DataModel> ListData = new List<DataModel>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        ListData.Add(new DataModel { Name = "Nancy, Berlin, France" });
        ListData.Add(new DataModel { Name = "Andrew, Madrid, Germany" });
        ListData.Add(new DataModel { Name = "Janet, London, Brazil" });
        ListData.Add(new DataModel { Name = "Margaret, Marseille, Belgium" });
        ListData.Add(new DataModel { Name = "Steven, Cholchester, Switzerland" });
        ListData.Add(new DataModel { Name = "Laura , Tsawassen, Venezuela" });
        ListData.Add(new DataModel { Name = "Robert, Tacoma, Austria" });
        ListData.Add(new DataModel { Name = "Michael, Redmond, Mexico" });
        ListData.Add(new DataModel { Name = "Albert, Kirkland, USA" });
        ListData.Add(new DataModel { Name = "Nolan, London, Sweden" });
        ListData.Add(new DataModel { Name = "Jennifer, Berlin, Finland" });
        ListData.Add(new DataModel { Name = "Carter, Madrid, Italy" });
        ListData.Add(new DataModel { Name = "Allison, Marseille, Spain" });
        ListData.Add(new DataModel { Name = "John, Tsawassen, UK" });
        ListData.Add(new DataModel { Name = "Susan, Redmond, Ireland" });
        ListData.Add(new DataModel { Name = "Lydia, Cholchester, Portugal" });
        ListData.Add(new DataModel { Name = "Kelsey, London, Canada" });
        ListData.Add(new DataModel { Name = "Jessica, Kirkland, Denmark" });
        ListData.Add(new DataModel { Name = "Robert, Berlin, Austria" });
        ListData.Add(new DataModel { Name = "Shelley, Tacoma, Poland" });
        ListData.Add(new DataModel { Name = "Vanjack, Tsawassen, Norway" });
        ListData.Add(new DataModel { Name = "shelley, Cholchester, Argentina" });
        ListData.Add(new DataModel { Name = "Lydia, Kirkland, Finland" });
        ListData.Add(new DataModel { Name = "Jessica, Madrid, Sweden" });
        ListData.Add(new DataModel { Name = "Nolan, London, UK" });
        ListData.Add(new DataModel { Name = "Jennifer, Redmond, Italy" });
    }
    public class DataModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
```

In the previous sample, the list view items are rendered. The Pager component provides an option to split this list view data set into sectioned pages and view them page by page. So, the Pager component is added in the **~Pages/.razor** file as follows.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfPager PageSize=5 NumericItemsCount=4 TotalItemsCount=25>
</SfPager>

```

Based on the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) property of the pager, the list view items are bound to the current page. In the following code sample, the `PageSize` is defined as "5" so that the first five items from the data source of the list view will be displayed on the current page using the Skip and Take values.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Lists

<div class="col-lg-12 control-section sb-property-border">
    @{
    var listData = ListData.Skip(SkipValue).Take(TakeValue).ToList();
    <SfListView DataSource="@listData" TValue="DataModel" HeaderTitle="Contacts" ShowHeader="true">
        <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Name"></ListViewFieldSettings>
    </SfListView>
    }
    <SfPager PageSize=5 NumericItemsCount=4 TotalItemsCount=25>
    </SfPager>

</div>
@code {
    public int SkipValue;
    public int TakeValue = 5;
    List<DataModel> ListData = new List<DataModel>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        ListData.Add(new DataModel { Name = "Nancy, Berlin, France" });
        ListData.Add(new DataModel { Name = "Andrew, Madrid, Germany" });
        ListData.Add(new DataModel { Name = "Janet, London, Brazil" });
        ListData.Add(new DataModel { Name = "Margaret, Marseille, Belgium" });
        ListData.Add(new DataModel { Name = "Steven, Cholchester, Switzerland" });
        ListData.Add(new DataModel { Name = "Laura , Tsawassen, Venezuela" });
        ListData.Add(new DataModel { Name = "Robert, Tacoma, Austria" });
        ListData.Add(new DataModel { Name = "Michael, Redmond, Mexico" });
        ListData.Add(new DataModel { Name = "Albert, Kirkland, USA" });
        ListData.Add(new DataModel { Name = "Nolan, London, Sweden" });
        ListData.Add(new DataModel { Name = "Jennifer, Berlin, Finland" });
        ListData.Add(new DataModel { Name = "Carter, Madrid, Italy" });
        ListData.Add(new DataModel { Name = "Allison, Marseille, Spain" });
        ListData.Add(new DataModel { Name = "John, Tsawassen, UK" });
        ListData.Add(new DataModel { Name = "Susan, Redmond, Ireland" });
        ListData.Add(new DataModel { Name = "Lydia, Cholchester, Portugal" });
        ListData.Add(new DataModel { Name = "Kelsey, London, Canada" });
        ListData.Add(new DataModel { Name = "Jessica, Kirkland, Denmark" });
        ListData.Add(new DataModel { Name = "Robert, Berlin, Austria" });
        ListData.Add(new DataModel { Name = "Shelley, Tacoma, Poland" });
        ListData.Add(new DataModel { Name = "Vanjack, Tsawassen, Norway" });
        ListData.Add(new DataModel { Name = "shelley, Cholchester, Argentina" });
        ListData.Add(new DataModel { Name = "Lydia, Kirkland, Finland" });
        ListData.Add(new DataModel { Name = "Jessica, Madrid, Sweden" });
        ListData.Add(new DataModel { Name = "Nolan, London, UK" });
        ListData.Add(new DataModel { Name = "Jennifer, Redmond, Italy" });
    }
    public class DataModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}
```

Through the navigation of the pager items, view the items in the list view page by page. This can be achieved by using the `ItemClick` event of the Pager. In the `ItemClick` event of the Pager, the SkipValue and TakeValue are calculated using the `PageSize` property and arguments of the `ItemClick` event (CurrentPage, PreviousPage). Based on these details, view the items in the list view page by page.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Lists

<div class="col-lg-12 control-section sb-property-border">
 @{
    var listData = ListData.Skip(SkipValue).Take(TakeValue).ToList();
    <SfListView @ref="@List" DataSource="@listData" TValue="DataModel" HeaderTitle="Contacts" ShowHeader="true">
        <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Name"></ListViewFieldSettings>
    </SfListView>
}
    <SfPager @ref="@Page" PageSize=5 NumericItemsCount=4 TotalItemsCount=25 ItemClick="Click">
    </SfPager>
</div>
@code {
    SfPager Page;
    public SfListView<DataModel> List { get; set; }
    public int SkipValue;
    public int TakeValue = 5;
    List<DataModel> ListData = new List<DataModel>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        ListData.Add(new DataModel { Name = "Nancy, Berlin, France" });
        ListData.Add(new DataModel { Name = "Andrew, Madrid, Germany" });
        ListData.Add(new DataModel { Name = "Janet, London, Brazil" });
        ListData.Add(new DataModel { Name = "Margaret, Marseille, Belgium" });
        ListData.Add(new DataModel { Name = "Steven, Cholchester, Switzerland" });
        ListData.Add(new DataModel { Name = "Laura , Tsawassen, Venezuela" });
        ListData.Add(new DataModel { Name = "Robert, Tacoma, Austria" });
        ListData.Add(new DataModel { Name = "Michael, Redmond, Mexico" });
        ListData.Add(new DataModel { Name = "Albert, Kirkland, USA" });
        ListData.Add(new DataModel { Name = "Nolan, London, Sweden" });
        ListData.Add(new DataModel { Name = "Jennifer, Berlin, Finland" });
        ListData.Add(new DataModel { Name = "Carter, Madrid, Italy" });
        ListData.Add(new DataModel { Name = "Allison, Marseille, Spain" });
        ListData.Add(new DataModel { Name = "John, Tsawassen, UK" });
        ListData.Add(new DataModel { Name = "Susan, Redmond, Ireland" });
        ListData.Add(new DataModel { Name = "Lydia, Cholchester, Portugal" });
        ListData.Add(new DataModel { Name = "Kelsey, London, Canada" });
        ListData.Add(new DataModel { Name = "Jessica, Kirkland, Denmark" });
        ListData.Add(new DataModel { Name = "Robert, Berlin, Austria" });
        ListData.Add(new DataModel { Name = "Shelley, Tacoma, Poland" });
        ListData.Add(new DataModel { Name = "Vanjack, Tsawassen, Norway" });
        ListData.Add(new DataModel { Name = "shelley, Cholchester, Argentina" });
        ListData.Add(new DataModel { Name = "Lydia, Kirkland, Finland" });
        ListData.Add(new DataModel { Name = "Jessica, Madrid, Sweden" });
        ListData.Add(new DataModel { Name = "Nolan, London, UK" });
        ListData.Add(new DataModel { Name = "Jennifer, Redmond, Italy" });
    }
    public void Click(PagerItemClickEventArgs args)
    {
        SkipValue = (args.CurrentPage * Page.PageSize) - Page.PageSize;
        TakeValue = Page.PageSize;
    }
    public class DataModel
    {
        public string Name { get; set; }
        public string Id { get; set; }
    }
}

```

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjrpjCqNBJBSbqWn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Pager with ListView](./images/blazor-pager-with-list-view.gif)" %}

N> [View Sample in GitHub.](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Pager/BlazorWebApp)