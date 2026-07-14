---
layout: post
title: Getting Started with Blazor TextBox in Blazor MAUI App | Syncfusion®
description: Check out and learn about the documentation for getting started with Blazor TextBox Component in Blazor MAUI App.
platform: Blazor
component: TextBox
documentation: ug
---

# Getting Started with Blazor TextBox Component in Blazor MAUI App

This guide explains how to include the [Blazor TextBox](https://www.syncfusion.com/blazor-components/blazor-textbox) component in a Blazor MAUI App using both [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/) and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

## Create a new Blazor MAUI App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a Blazor MAUI App using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/dotnet/maui/get-started/first-app?pivots=devices-windows&view=net-maui-9.0&tabs=vswin). For detailed instructions, refer to the [Blazor MAUI App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/maui-blazor-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor MAUI App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new maui-blazor -o MauiBlazorApp
cd MauiBlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor MAUI App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/dotnet/maui/get-started/first-app?pivots=devices-windows&view=net-maui-9.0&tabs=visual-studio-code) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor MAUI App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/maui-blazor-app) documentation.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor MAUI App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new maui-blazor -o MauiBlazorApp
cd MauiBlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Install the required Blazor packages

Install [Syncfusion.Blazor.Inputs](https://www.nuget.org/packages/Syncfusion.Blazor.Inputs/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Inputs` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Inputs -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Inputs -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.Inputs -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add import namespaces

After the packages are installed, open the **~/Components/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Inputs` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Inputs

{% endhighlight %}
{% endtabs %}

## Register the Blazor service

Open the **MauiProgram.cs** file in Blazor MAUI App and register the Blazor service.

{% tabs %}
{% highlight c# tabtitle="MauiProgram.cs" %}

....
using Syncfusion.Blazor;

....

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        ....
        builder.Services.AddSyncfusionBlazor();
        ....
    }
}

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~wwwroot/index.html** file.

{% tabs %}
{% highlight html tabtitle="index.html" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

## Add Blazor TextBox component

Open a Razor file located in the **~/Components/Pages/*.razor** (for example, **Home.razor**) and add the [Blazor MultiSelect Dropdown](https://www.syncfusion.com/blazor-components/blazor-multiselect-dropdown) component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name'></SfTextBox>

{% endhighlight %}
{% endtabs %}

## Run the application on Windows

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor TextBox component will render in your default web browser.

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

![Blazor TextBox Component](./images/blazor-textbox-maui-app.webp)

## Run the application on Android

To run the Blazor TextBox in your Blazor MAUI app on an Android emulator, follow the steps below.

1. Set up and start the Android emulator. For help, see the [Android Device Manager guide](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/device-manager#android-device-manager-on-windows).

2. Run your app using the emulator to view the TextBox.

N> If you face any issues with the Android emulator, check the [Troubleshooting Android Emulator guide](https://learn.microsoft.com/en-us/dotnet/maui/android/emulator/troubleshooting) for solutions.

![Blazor TextBox Component](./images/blazor-textbox.webp)

## Adding icons to the Blazor TextBox

Add an icon to the TextBox component using the [AddIconAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_AddIconAsync_System_String_System_String_System_Collections_Generic_Dictionary_System_String_System_Object__) method. Below is an example of how to implement this in your Blazor application:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Inputs

<div id="sample" style="margin:130px auto;width:300px">
    <SfTextBox @ref=@TextBoxDropDownObj
               Created="@AddDateIcon"
               Placeholder="Enter Date"
               FloatLabelType="@FloatLabelType.Auto">
    </SfTextBox>
</div>


@code {
    SfTextBox TextBoxDropDownObj { get; set; }

    private async void AddDateIcon()
    {
        if (TextBoxDropDownObj != null)
        {
            // Add icon to the TextBox
            await TextBoxDropDownObj.AddIconAsync("append", "e-icons e-date-icon");
        }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor TextBox with icon in .NET MAUI Blazor](./images/blazor-textbox-icons.webp)

## Floating label

The floating label TextBox floats the label above the TextBox after focusing, or filled with value in the TextBox. The floating label TextBox can be created by using the [FloatLabelType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_FloatLabelType) API.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' FloatLabelType='@FloatLabelType.Auto'></SfTextBox>

{% endhighlight %}
{% endtabs %}

![Blazor TextBox with floating label in .NET MAUI Blazor](./images/blazor-textbox-float-label.webp)

## See also

1. [Getting Started with Blazor WebAssembly Standalone App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
2. [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
3. [Native Events in Blazor TextBox Component](https://blazor.syncfusion.com/documentation/textbox/native-events)
4. [Data Binding in Blazor TextBox Component](https://blazor.syncfusion.com/documentation/textbox/data-binding)