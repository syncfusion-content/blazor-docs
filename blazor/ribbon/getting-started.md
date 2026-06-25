---
layout: post
title: Getting Started with Blazor Ribbon Component | Syncfusion
description: Checkout and learn about getting started with Blazor Ribbon component in Blazor WebAssembly Application.
platform: Blazor
control: Ribbon
documentation: ug
---

# Getting Started with Blazor Ribbon Component

This guide briefly explains about how to include [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Ribbon](https://www.syncfusion.com/blazor-components/blazor-ribbon) component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor WASM App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

Create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor WASM App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app?tabcontent=visual-studio-code) documentation.

Alternatively, create a WebAssembly application by using the following command in the integrated terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Install the latest version of [.NET SDK](https://dotnet.microsoft.com/en-us/download). If the .NET SDK is already installed, determine the installed version by running the following command in a command prompt (Windows), terminal (macOS), or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor WebAssembly App using .NET CLI

Run the following command to create a new Blazor WebAssembly App in a command prompt (Windows) or terminal (macOS) or command shell (Linux). For detailed instructions, refer to the [Blazor WASM App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app?tabcontent=.net-cli) documentation.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor packages

Install [Syncfusion.Blazor.Ribbon](https://www.nuget.org/packages/Syncfusion.Blazor.Ribbon/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages in your project using the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), or the integrated terminal in Visual Studio Code (`dotnet add package`), or the .NET CLI.

Alternatively, run the following commands in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Ribbon -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

## Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Ribbon` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Ribbon

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **Program.cs** file of your Blazor WebAssembly App.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script references in the **~/index.html** file.

```html

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
....
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in the Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in the Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Ribbon component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Ribbon component in the **~/Pages/Index.razor** file.

### Adding ribbon tab

In Ribbon component, options are organized into tabs for easy access. You can use the [RibbonTabs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonTabs.html) tag directive to group all the tabs and [RibbonTab](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonTab.html) tag directive to define each ribbon tab as shown below:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

<SfRibbon>
    <RibbonTabs>
        <RibbonTab HeaderText="Home"></RibbonTab>
    </RibbonTabs>
</SfRibbon>

{% endhighlight %}
{% endtabs %}

### Adding ribbon group

To define a ribbon group under each tab, you can use the [RibbonGroups](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroups.html) tag directive like below. The [Orientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_Orientation) property of ribbon group defines whether the collection of items inside the group will be rendered column-wise or row-wise.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

<SfRibbon>
    <RibbonTabs>
        <RibbonTab HeaderText="Home">
            <RibbonGroups>
                <RibbonGroup HeaderText="Clipboard" Orientation="Orientation.Row"></RibbonGroup>
            </RibbonGroups>
        </RibbonTab>
    </RibbonTabs>
</SfRibbon>

{% endhighlight %}
{% endtabs %}

### Adding ribbon item

You can use the [RibbonCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonCollection.html) tag directive to define each ribbon collection that contains one or more items. To define each ribbon item, you can use the [RibbonItem](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonItem.html) tag directive with the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_Orientation) property to specify the type of item to be rendered, using the [RibbonItemType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Ribbon.RibbonGroup.html#Syncfusion_Blazor_Ribbon_RibbonGroup_Orientation) such as Button, a DropDown, a ComboBox, and more.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Ribbon;
@using Syncfusion.Blazor.SplitButtons;

<SfRibbon>
    <RibbonTabs>
        <RibbonTab HeaderText="Home">
            <RibbonGroups>
                <RibbonGroup HeaderText="Clipboard">
                    <RibbonCollections>
                        <RibbonCollection>
                            <RibbonItems>
                                <RibbonItem Type=RibbonItemType.SplitButton Disabled=true>
                                    <RibbonSplitButtonSettings Content="Paste" IconCss="e-icons e-paste" Items="@formatItems"></RibbonSplitButtonSettings>
                                </RibbonItem>
                            </RibbonItems>
                        </RibbonCollection>
                        <RibbonCollection>
                            <RibbonItems>
                                <RibbonItem Type=RibbonItemType.Button>
                                    <RibbonButtonSettings Content="Cut" IconCss="e-icons e-cut" ></RibbonButtonSettings>
                                </RibbonItem>
                                <RibbonItem Type=RibbonItemType.Button>
                                    <RibbonButtonSettings Content="Copy" IconCss="e-icons e-copy"></RibbonButtonSettings>
                                </RibbonItem>
                                <RibbonItem Type=RibbonItemType.Button>
                                    <RibbonButtonSettings Content="Format Painter" IconCss="e-icons e-format-painter"></RibbonButtonSettings>
                                </RibbonItem>
                            </RibbonItems>
                        </RibbonCollection>
                    </RibbonCollections>
                </RibbonGroup>
            </RibbonGroups>
        </RibbonTab>
    </RibbonTabs>
</SfRibbon>

@code{
    List<DropDownMenuItem> formatItems = new List<DropDownMenuItem>()
    {
        new DropDownMenuItem{ Text = "Keep Source Format" },
        new DropDownMenuItem{ Text = "Merge Format" },
        new DropDownMenuItem{ Text = "Keep Text Only" }
    };
}

{% endhighlight %}
{% endtabs %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the application. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Ribbon component will be rendered in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZrJCLsRVGKvCOVj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Ribbon Component](./images/getting-started.webp)" %}