---
layout: post
title: Getting Started with Blazor Pager Component | Syncfusion
description: Checkout and learn about getting started with Blazor Pager component in Blazor WebAssembly Application.
platform: Blazor
control: Pager
documentation: ug
---

# Getting Started with Blazor Pager Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component enables navigation through large collections by dividing content into multiple pages. This guide explains how to integrate the [Pager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html) component in a **Blazor WebAssembly** application using [Visual Studio](https://visualstudio.microsoft.com/vs/) or **Visual Studio Code**.

{% youtube
"youtube:https://www.youtube.com/watch?v=Nfg8b_bbIfI" %}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

A **Blazor WebAssembly App** can be created using **Visual Studio** with the built-in [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

1. Open **Visual Studio 2022** (v17.8 or later).
2. Select **Create a new project**.
3. Choose **Blazor WebAssembly Standalone App** from the list of templates and click **Next**.
4. Configure the **project name**, **location**, and **solution settings**, then click **Next**.
5. Select the **target framework** as **.NET 8.0 or later** (choose the latest installed version available on the system).
6. Click **Create** to generate the project.

N> For detailed steps, refer to [Microsoft Blazor tooling documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet Packages

To integrate the Blazor Pager component, install the required NuGet packages in the **Blazor WebAssembly** project:

1. Open **NuGet Package Manager** in Visual Studio:

    *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.

2. Search and install the following packages:

    - [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

3. For projects using **WebAssembly** or **Auto** interactive render modes, ensure these packages are installed in the **Client** project.

4. Alternatively, use the **Package Manager Console**:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Navigations -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For a complete list of packages, refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

A **Blazor WebAssembly App** can be created using **Visual Studio Code** with the built-in [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

1. Open **Visual Studio Code**.
2. Open the **integrated terminal** (**Ctrl + `**).
3. Run the following commands to create a new **Blazor WebAssembly** project:

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

4. Open the **project folder** in **Visual Studio Code**.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet Packages in Visual Studio Code

1. Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
2. Ensure the terminal is in the project root directory where the **.csproj** file is located.
3. Run the following commands to install the required NuGet packages:
    - [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Navigations -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For a complete list of packages, refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Import the required namespaces in the **_Imports.razor** file:

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

{% endhighlight %}
{% endtabs %}

Next, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **Program.cs** file:

{% tabs %}
{% highlight C# tabtitle="~/Program.cs" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script files are provided through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-asset) in the NuGet packages. Include these references in the **<head>** section of the **~/wwwroot/index.html** file:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

N>
* Refer to [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) for various methods to reference themes in a Blazor application:

    * [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets)
    * [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference)
    * [Custom Resource Generator (CRG)](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)

* For script reference options, see [Adding Script References](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## Add Blazor Pager component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component can be integrated with other components to provide page navigation for large datasets. This example demonstrates integrating the [Pager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html) with the [ListView](https://blazor.syncfusion.com/documentation/listview/getting-started) component.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfPager PageSize="5" NumericItemsCount="4" TotalItemsCount="25">
</SfPager>
```

**1. Render ListView Component**

Add the [ListView](https://blazor.syncfusion.com/documentation/listview/getting-started) component in the **Pages/Index.razor** file and bind it to a collection:

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

**2. Add Pager component**

Add the `Pager` component in the same file (**Pages/Index.razor**) below the **ListView**. Configure the essential properties:

* [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) – defines the number of items displayed per page.
* [NumericItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_NumericItemsCount) – specifies the count of numeric pager buttons.
* [TotalItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_TotalItemsCount) – indicates the total number of records in the data source.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfPager PageSize=5 NumericItemsCount=4 TotalItemsCount=25>
</SfPager>
```

> For additional properties of [Pager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html), refer to the API Reference.

**3. Integrate Pager with ListView**

To enable paging functionality, bind the **ListView** data for the current page by applying **Skip** and **Take** operations on the collection. These operations are based on the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) property of the Pager component.

The [ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_ItemClick) event is triggered when a pager item is clicked. This event updates the **Skip** and **Take** values dynamically according to the selected page, ensuring that the correct subset of data is displayed in the ListView.

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

**4. Run the Application**

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The **Pager** component will render and enable navigation through the collection.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjrpjCqNBJBSbqWn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Pager with ListView](./images/blazor-pager-with-list-view.gif)" %}

N> [View Sample on GitHub.](https://github.com/SyncfusionExamples/blazor-pager-component)
