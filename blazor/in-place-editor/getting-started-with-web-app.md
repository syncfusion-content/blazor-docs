---
layout: post
title: Getting Started with Blazor In-place Editor in WebApp | Syncfusion
description: Checkout and learn about the documentation for getting started with Blazor In-place Editor Component in Blazor Web App.
platform: Blazor
component: In place Editor
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Getting Started with Blazor In-place Editor Component in Web App

This section briefly explains about how to include [Blazor In-place Editor](https://www.syncfusion.com/blazor-components/blazor-in-place-editor) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio Code.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows) while creating a Blazor Web Application.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor InPlaceEditor and Themes NuGet in the Blazor Web App

To add **Blazor In-place Editor** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.InPlaceEditor](https://www.nuget.org/packages/Syncfusion.Blazor.InPlaceEditor/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.InPlaceEditor -Version {{ site.releaseversion }}
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

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor InPlaceEditor and Themes NuGet in the App

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.InPlaceEditor](https://www.nuget.org/packages/Syncfusion.Blazor.InPlaceEditor) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.InPlaceEditor -v {{ site.releaseversion }}
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

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.InPlaceEditor` namespace.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.InPlaceEditor

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
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor In-place Editor component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor In-place Editor component in `.razor` file inside the `Pages` folder. If an interactivity location as `Per page/component` in the web app, define a render mode at top of the component, as follows:

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

{% tabs %}
{% highlight razor %}

<table>
    <tr>
        <td>
            <label class="control-label" style="text-align: left;font-size: 14px;font-weight: 400">
                TextBox
            </label>
        </td>
        <td>
            <SfInPlaceEditor @bind-Value="@TextValue" TValue="string">
                <EditorComponent>
                    <SfTextBox @bind-Value="@TextValue" Placeholder="Enter employee name"></SfTextBox>
                </EditorComponent>
            </SfInPlaceEditor>
        </td>
    </tr>
</table>

@code {
    public string TextValue = "Andrew";
}

{% endhighlight %}
{% endtabs %}

N> The type of component editor must be configured in the 'Type' Editor In-place property. Also, the two-way binding between the In-place Editor and its EditorComponent should be configured. It's used to update the editor component value into the In-place Editor component.

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor In-place Editor component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNhJtMLkzWvWaMvy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor In-place Editor Component](images/blazor-inplace-editor-component.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/InPlaceEditor).

## Render Blazor In-place Editor with popup

The following code explains how to initialize a simple In-place Editor with popup in the Blazor page.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.DropDowns

<table>
    <tr>
        <td>
            <label class="control-label">
                Choose a Country:
            </label>
        </td>
        <td>
            <SfInPlaceEditor Type="Syncfusion.Blazor.InPlaceEditor.InputType.AutoComplete" @bind-Value="@AutoValue" Mode="RenderMode.Popup" TValue="string">
                <EditorComponent>
                    <SfAutoComplete TValue="string" TItem="Countries" @bind-Value="@AutoValue" Placeholder="e.g. Australia" DataSource="@LocalData">
                        <AutoCompleteFieldSettings Value="Name"></AutoCompleteFieldSettings>
                    </SfAutoComplete>
                </EditorComponent>
            </SfInPlaceEditor>
        </td>
    </tr>
</table>

@code {
    public string AutoValue = "Australia";

    public class Countries
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }

    List<Countries> LocalData = new List<Countries> {
        new Countries() { Name = "Australia", Code = "AU" },
        new Countries() { Name = "Bermuda", Code = "BM" },
        new Countries() { Name = "Canada", Code = "CA" },
        new Countries() { Name = "Cameroon", Code = "CM" },
        new Countries() { Name = "Denmark", Code = "DK" }
    };
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhIXOjhAIsuBPDh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor In-place Editor in Inline Mode](./images/blazor-inplace-editor-in-inline-mode.gif)" %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZryjkXLAeqHmuVN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor In-place Editor in Popup Mode](./images/blazor-inplace-editor-in-popup-mode.gif)" %}

## Configuring DropDownList

You can render the Blazor DropDownList by changing the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InPlaceEditor.SfInPlaceEditor-1.html#Syncfusion_Blazor_InPlaceEditor_SfInPlaceEditor_1_Type) property as `DropDownList` and configuring the `DropDownList` component inside the Editor component.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.InPlaceEditor

<SfInPlaceEditor @bind-Value="@DropdownValue" Type="Syncfusion.Blazor.InPlaceEditor.InputType.DropDownList" TValue="string">
    <EditorComponent>
        <SfDropDownList TValue="string" TItem="Games"  @bind-Value="@DropdownValue" Placeholder="Select a game" DataSource="@LocalData">
            <DropDownListFieldSettings Value="ID" Text="Text"></DropDownListFieldSettings>
        </SfDropDownList>
    </EditorComponent>
</SfInPlaceEditor>

@code {
    public string DropdownValue = "Game4";

    public class Games
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    List<Games> LocalData = new List<Games> {
    new Games() { ID= "Game1", Text= "American Football" },
    new Games() { ID= "Game2", Text= "Badminton" },
    new Games() { ID= "Game3", Text= "Basketball" },
    new Games() { ID= "Game4", Text= "Cricket" },
    new Games() { ID= "Game5", Text= "Football" },
    new Games() { ID= "Game6", Text= "Golf" },
    new Games() { ID= "Game7", Text= "Hockey" },
    new Games() { ID= "Game8", Text= "Rugby"},
    new Games() { ID= "Game9", Text= "Snooker" },
    new Games() { ID= "Game10", Text= "Tennis"},
  };
}

{% endhighlight %}
{% endtabs %}

## Integrate DatePicker

You can render the Blazor `DatePicker` by changing the `Type` property as `Date` and configuring the `DatePicker` component inside the Editor component. Also, configure its properties directly in the `Datepicker` component.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.Calendars

<SfInPlaceEditor Type="Syncfusion.Blazor.InPlaceEditor.InputType.Date" TValue="DateTime?" @bind-Value="@DateValue">
    <EditorComponent>
        <SfDatePicker TValue="DateTime?" @bind-Value="@DateValue" Placeholder="Choose a Date"></SfDatePicker>
    </EditorComponent>
</SfInPlaceEditor>

@code {
    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

}

{% endhighlight %}
{% endtabs %}

In the following code, it is configured to render the `DatePicker`, `DropDownList` and `Textbox` components.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.DropDowns

<div id="container" class="control-group">
    <h3> Modify Basic Details </h3>
    <table style="margin: 10px auto;">
        <tr>
            <td>Name</td>
            <td class='left'>
                <SfInPlaceEditor @bind-Value="@TextValue" TValue="string">
                    <EditorComponent>
                        <SfTextBox @bind-Value="@TextValue" Placeholder="Enter your name"></SfTextBox>
                    </EditorComponent>
                </SfInPlaceEditor>
            </td>
        </tr>
        <tr>
            <td>Date of Birth</td>
            <td class='left'>
                <SfInPlaceEditor Type="Syncfusion.Blazor.InPlaceEditor.InputType.Date" TValue="DateTime?" @bind-Value="@DateValue">
                    <EditorComponent>
                        <SfDatePicker TValue="DateTime?" @bind-Value="@DateValue" Placeholder="Select date"></SfDatePicker>
                    </EditorComponent>
                </SfInPlaceEditor>
            </td>
        </tr>
        <tr>
            <td>Gender</td>
            <td class='left'>
                <SfInPlaceEditor @bind-Value="@DropdownValue" Type="Syncfusion.Blazor.InPlaceEditor.InputType.DropDownList"  TValue="string">
                    <EditorComponent>
                        <SfDropDownList Width="90%" TItem="Gender" TValue="string" DataSource="@dropdownData" @bind-Value="@DropdownValue">
                            <DropDownListFieldSettings Text="text" Value="text"></DropDownListFieldSettings>
                        </SfDropDownList>
                    </EditorComponent>
                </SfInPlaceEditor>
            </td>
        </tr>
    </table>
</div>

<style>
    #container {
        text-align: center;
        margin-top: 50px;
    }

        #container table {
            width: 400px;
            margin: auto;
        }

            #container table td {
                height: 70px;
                width: 150px;
            }

            #container table .left {
                text-align: left;
            }
</style>

@code {
    public DateTime? DateValue { get; set; } = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
    public string TextValue = "Andrew";
    public string DropdownValue = "Male";

    public class Gender
    {
        public string value { get; set; }
        public string text { get; set; }
    }
    List<Gender> dropdownData = new List<Gender>()
    {
        new Gender(){ text= "Male" },
        new Gender(){ text= "Female" }
    };
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLpDiBOpBgAmQAj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Integrating DatePicker in Blazor In-place Editor](./images/blazor-inplace-editor-integrate-datepicker.png)" %}

## Submitting data to the server (save)

You can submit editor value to the server by configuring the [SaveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InPlaceEditor.SfInPlaceEditor-1.html#Syncfusion_Blazor_InPlaceEditor_SfInPlaceEditor_1_SaveUrl), [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InPlaceEditor.SfInPlaceEditor-1.html#Syncfusion_Blazor_InPlaceEditor_SfInPlaceEditor_1_Adaptor) and [PrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InPlaceEditor.SfInPlaceEditor-1.html#Syncfusion_Blazor_InPlaceEditor_SfInPlaceEditor_1_PrimaryKey) properties.

| Property   | Usage                                           |
|------------|---------------------------------------------------------|
| **`SaveUrl`**        | Gets the URL for server submit action.        |
| **`Adaptor`**    | Specifies the adaptor type that is used by DataManager to communicate with DataSource.                |
| **`PrimaryKey`** | Defines the unique primary key of editable field which can be used for saving data in the data-base.|

> The `PrimaryKey` property is mandatory. If it is not set, edited data are not sent to the server.

## Refresh Blazor In-place Editor with modified value

The edited data is submitted to the server and you can see the new values getting reflected in the In-place Editor.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.InPlaceEditor

<div id="container">
    <div class="control-group">
        Best Employee of the year:

        <SfInPlaceEditor @ref="InPlaceObj" PrimaryKey="Employee" Name="Employee" Adaptor="Adaptors.UrlAdaptor" SaveUrl="https://ej2services.syncfusion.com/production/web-services/api/Editor/UpdateData" Type="Syncfusion.Blazor.InPlaceEditor.InputType.DropDownList" @bind-Value="@DropdownValue" TValue="string">
            <EditorComponent>
                <SfDropDownList TValue="string" TItem="Employees" Placeholder="Select employee" PopupHeight="200px" DataSource="@LocalData">
                    <DropDownListFieldSettings Value="ID" Text="Text"></DropDownListFieldSettings>
                </SfDropDownList>
            </EditorComponent>
            <InPlaceEditorEvents Created="@OnCreate" OnActionSuccess="@OnSuccess" TValue="string"></InPlaceEditorEvents>
        </SfInPlaceEditor>

    </div>
    <table style="margin:60px auto;width:25%">
        <tr>
            <td style="text-align: left">
                Old Value :
            </td>
            <td id="oldValue" style="text-align: left">
                @PreviousValue
            </td>
        </tr>
        <tr>
            <td style="text-align: left">
                New Value :
            </td>
            <td id="newValue" style="text-align: left">
                @CurrentValue
            </td>
        </tr>
    </table>
</div>

<style>
    .e-inplaceeditor {
        min-width: 200px;
        text-align: left;
    }

    #container .control-group {
        text-align: center;
        margin: 100px auto;
    }
</style>

@code {
    SfInPlaceEditor<string> InPlaceObj;
    public string PreviousValue { get; set; }
    public string DropdownValue = "Andrew";
    public string CurrentValue { get; set; }

    public class Employees
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    List<Employees> LocalData = new List<Employees> {
    new Employees() { ID= "Andrew", Text= "Andrew" },
    new Employees() { ID= "Margaret Hamilit", Text= "Margaret Hamilit" },
    new Employees() { ID= "Fuller", Text= "Fuller" },
    new Employees() { ID= "John Smith", Text= "John Smith" },
    new Employees() { ID= "Victoria", Text= "Victoria" },
    new Employees() { ID= "David", Text= "David" },
    new Employees() { ID= "Johnson", Text= "Johnson" },
    new Employees() { ID= "Rosy", Text= "Rosy"}
  };

    public void OnCreate(Object args)
    {
        this.CurrentValue = this.DropdownValue;
    }

    public void OnSuccess(ActionEventArgs<string> args)
    {
        this.PreviousValue = this.CurrentValue;
        this.CurrentValue = args.Value;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVzXiLafrzKnAQi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Refreshing Blazor In-place Editor Data](./images/blazor-inplace-editor-refresh-data.png)" %}

## See also

1. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
2. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)

