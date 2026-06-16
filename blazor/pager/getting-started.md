---
layout: post
title: Getting Started with Blazor Pager in Blazor WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor Pager component in Blazor WebAssembly Application.
platform: Blazor
control: Pager
documentation: ug
---

# Getting Started with Blazor Pager in Blazor WASM App

The [Blazor Pager](https://www.syncfusion.com/blazor-components/blazor-pager) component enables navigation through large collections by dividing content into multiple pages. This guide explains how to include [Pager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html) component in a **Blazor WebAssembly App** using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

### Create a new Blazor WASM App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor WebAssembly App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazorwasm -o BlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc), the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazorwasm -o BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

### Install the required Blazor packages

Install [Syncfusion.Blazor.Navigations](https://www.nuget.org/packages/Syncfusion.Blazor.Navigations/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Navigations` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Navigations -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Navigations -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.Navigations -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

### Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Navigations` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

{% endhighlight %}
{% endtabs %}

### Register the Blazor service

Open the **Program.cs** file in Blazor WebAssembly App and register the Blazor service.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~wwwroot/index.html** file.

{% tabs %}
{% highlight html tabtitle="index.html" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in the Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in the Blazor application.

### Add Blazor Pager component

Open a Razor file located in the **~/Pages/*Index.razor** and add the [Blazor Pager](https://www.syncfusion.com/blazor-components/blazor-pager) component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Navigations

<SfPager PageSize="5" NumericItemsCount="4" TotalItemsCount="25">
</SfPager>

{% endhighlight %}
{% endtabs %}

**1. Render ListView component**

Add the [ListView](https://blazor.syncfusion.com/documentation/listview/getting-started) component in the **Pages/Index.razor** file and bind it to a collection:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

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

{% endhighlight %}
{% endtabs %}

**2. Add Pager component**

Add the `Pager` component in the same file (**Pages/Index.razor**) below the **ListView**. Configure the essential properties:

* [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) – defines the number of items displayed per page.
* [NumericItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_NumericItemsCount) – specifies the count of numeric pager buttons.
* [TotalItemsCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_TotalItemsCount) – indicates the total number of records in the data source.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Navigations

<SfPager PageSize=5 NumericItemsCount=4 TotalItemsCount=25>
</SfPager>

{% endhighlight %}
{% endtabs %}

> For additional properties of [Pager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html), refer to the API Reference.

**3. Integrate Pager with ListView**

To enable paging functionality, bind the **ListView** data for the current page by applying **Skip** and **Take** operations on the collection. These operations are based on the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_PageSize) property of the Pager component.

The [ItemClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfPager.html#Syncfusion_Blazor_Navigations_SfPager_ItemClick) event is triggered when a pager item is clicked. This event updates the **Skip** and **Take** values dynamically according to the selected page, ensuring that the correct subset of data is displayed in the ListView.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

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

{% endhighlight %}
{% endtabs %}

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Pager component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjrpjCqNBJBSbqWn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Pager with ListView](./images/blazor-pager-with-list-view.gif)" %}

N> [View Sample on GitHub.](https://github.com/SyncfusionExamples/blazor-pager-component)