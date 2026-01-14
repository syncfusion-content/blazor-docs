---
layout: post
title: Getting started with Syncfusion Pager Component in Blazor Server App
description: Learn how to configure and use the Syncfusion Blazor Pager component in a Blazor Server App for efficient navigation and paging.
platform: Blazor
control: Pager
documentation: ug
---

# Getting Started with Blazor Pager Component in Blazor Server App

This section briefly explains about how to include [Blazor Pager](https://www.syncfusion.com/blazor-components/blazor-pager) component in a Blazor Server App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor Server App** by using the **Blazor Web App** template in Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor Server App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) documentation.

![Blazor Server App Creation Template](images/Blazor-server-app-creation.png)

Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) when creating a Blazor Server App.

![Blazor Server App with Interactive Mode](images/blazor-app-interactive-mode.png)

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Navigations and Themes NuGet in the App

To add the **Blazor Pager** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, run the following commands in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Navigations -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a **Blazor Server App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor Server App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio?tabcontent=visual-studio-code) documentation.

Alternatively, create a Server application by using the following command in the integrated terminal(<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor Server App" %}

dotnet new blazor -o BlazorApp -int Server
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Navigations and Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure in the project root directory where the `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Navigations -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Install the latest version of [.NET SDK](https://dotnet.microsoft.com/en-us/download). If the .NET SDK is already installed, determine the installed version by running the following command in a command prompt (Windows), terminal (macOS), or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Server App using .NET CLI

Run the following command to create a new Blazor Server App in a command prompt (Windows) or terminal (macOS) or command shell (Linux). For detailed instructions, refer to [this Blazor Server App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio?tabcontent=.net-cli) documentation.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp -int Server
cd BlazorApp

{% endhighlight %}
{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Navigations and Themes NuGet in the App

To add the **Blazor Pager** component to the application, run the following commands in a command prompt (Windows), command shell (Linux), or terminal (macOS) to install the [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. See [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) for more details.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Navigations -Version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Add Import Namespaces

Open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Navigations` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of the Blazor Server App.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 10" %}

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
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Pager component in the **~/Components/Pages/Home.razor** file. If the interactivity location is set to `Per page/component`, define a render mode at the top of the `Home.razor` page.

N> If an Interactivity Location is set to `Global` and the **Render Mode** is set to `Server`, the render mode is configured in the `App.razor` file by default.

```
@* desired render mode define here *@
@rendermode InteractiveServer
```

**1. Render ListView Component**

Add the [ListView](https://blazor.syncfusion.com/documentation/listview/getting-started) component in the **Pages/Home.razor** file and bind it to a collection:

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

Add the [Pager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html) component in the same file (**Pages/Index.razor**) below the **ListView**. Configure the essential properties:

* [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) – defines the number of items displayed per page.
* [NumericItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_NumericItemsCount) – specifies the count of numeric pager buttons.
* [TotalItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_TotalItemsCount) – indicates the total number of records in the data source.

{% tabs %}
{% highlight razor %}

@rendermode InteractiveAuto
@using Syncfusion.Blazor.Navigations

<SfPager PageSize="5" NumericItemsCount="4" TotalItemsCount="25"></SfPager>

{% endhighlight %}
{% endtabs %}

> For additional properties of [Pager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html), refer to the API Reference.

**3. Integrate ListView with Pager**

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

N> [View Sample on GitHub.](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Pager)