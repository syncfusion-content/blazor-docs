---
layout: post
title: Getting Started with Microsoft Teams App in Visual Studio | Syncfusion
description: Check out the documentation for getting started with Microsoft Teams App using Syncfusion Blazor Components in Visual Studio and much more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Microsoft Teams Application

This section explains how to create and run the first Microsoft Teams application (MSTeams App) with Syncfusion Blazor components.

## Prerequisites

* Visual Studio 2022 [>= 17.3 version] with the required work loads (Visula studio Installer -> Workloads -> ASP.NET and web development -> Select Microsoft Teams development tools from option check list).

* Microsoft Team Application - Enable side loading for testing the application.

* Microsoft Edge or Google Chrome browser with developer tools.

## Create a new Microsoft Team Application with Tab using Visual Studio

1. Launch Visual Studio 2022, and in the start window click **Create a new project**.
2. Search for Microsoft Teams app in Visual Studio template. Select **Microsoft teams App** and click on Next.
![Create Microsoft Teams App](images\MSTeams\create-msteams-app.png)
3. Configure the project with required project name, select the location to save the application and click on Create.
![Configure Microsoft Teams App](images\MSTeams\configure-msteams-app.png)
4. Select the type of Microsoft teams application to create. In this example, **Microsoft application with Tab** is selected.
![Select type of Microsoft Teams Application](images\MSTeams\select-type-msteams-app.png)
5. Wait for the project to be created, and its dependencies to be restored, then the project structure looks like below.
![Microsoft Teams project structure](images\MSTeams\msteams-project-structure.png)

## Build and run the first Microsoft Team Application

1. To configure the project with the Microsoft teams application, right Click on the Project Teams Toolkit Prepare Teams App Dependencies.
![Configure dependecies with MS Teams Application](images\MSTeams\configure-teams-dependencies.png)
2. After configuring successfully, it dsipalys the window with Microsoft 365 Account. If you already have an account Select the available Office 365 account and click on continue. If you dont have account, create a new account and add the newly created account and click on continue.
![Select the MS365 account to SignIn](images\MSTeams\ms365-account-select.png)
3. After successful login. Click on Debug -> Start Debugging or click on F5 to run the application.
4. Once the application is build successfully, prompts the output window with create MyTeamsApp application. Click on Add in the created application
![Newly created teams application](images\MSTeams\new-teams-app.png)
5. On clicking on "Add" the new Microsfot application with personal Tab is created.
![New Teams application with Personal Tab](images\MSTeams\new-app-personal-tab.png)

## Install Syncfusion Blazor Packages in the App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). In order to use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details and [Benefits of using individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages#benefits-of-using-individual-nuget-packages). 

To add Blazor Calendar component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Kanban](https://www.nuget.org/packages/Syncfusion.Blazor.Kanban) and then install it.

## Register Syncfusion Blazor Service

Open `~/Imports.razor` file and add Syncfusion.Blazor namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the Blazor Server App. Here, Syncfusion Blazor Service is registered by setting [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as `true` to load the scripts externally in the [next steps](#add-script-reference). Open the `~/Program.cs` file and register the Syncfusion Blazor service as follows

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" hl_lines="3 10" %}

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

## Add style sheet

Checkout the [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) to refer themes in Blazor application, and to have the expected appearance for Syncfusion Blazor components. Here, the theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/appearance/themes#enable-static-web-assets-usage) topic to use static assets in your project.

To add theme to the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and then install it. Then, the theme style sheet from NuGet can be referred inside the `<head>` of **~/Pages/_Host.cshtml** file as follows,

{% endhighlight %}
{% highlight cshtml tabtitle="~/_Host.cshtml" hl_lines="3" %}

<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}
{% endtabs %}

## Add script reference

Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. In this getting started walk-through, the required scripts are referred using [Static Web Assets](https://sfblazor.azurewebsites.net/staging/documentation/common/adding-script-references#static-web-assets) externally inside the `<head>` of **~/Pages/_Host.cshtml** file as follows.

{% tabs %}
{% highlight cshtml tabtitle="~/_Host.cshtml" hl_lines="4" %}

<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %} 

> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the application. 

## Add Syncfusion Blazor component

Now add Syncfusion Blazor component in any razor file. Here, the Kanban component is added in `Tab.razor` page under the `~/Pages` folder.

{% tabs %}
{% highlight razor tabtitle="~/Tab.razor" %}

@using Syncfusion.Blazor.Kanban
@using System.Collections.ObjectModel;
@using System.ComponentModel;

<div class="col-lg-12 control-section">
    <div class="content-wrapper" id="toast-kanban-observable">
        <div class="row"> 
            <SfKanban KeyField="Status" DataSource="@ObservableData">
                <KanbanColumns>
                    @foreach (ColumnModel item in columnData)
                    {
                        <KanbanColumn HeaderText="@item.HeaderText" KeyField="@item.KeyField" AllowAdding="true" />
                    }
                </KanbanColumns>
                <KanbanCardSettings HeaderField="Id" ContentField="Summary" />
                <KanbanSwimlaneSettings KeyField="Assignee"></KanbanSwimlaneSettings>
            </SfKanban>
        </div>
    </div>
</div>

@code {
    public ObservableCollection<ObservableDatas> ObservableData { get; set; }
    List<ObservableDatas> Tasks = new List<ObservableDatas>();

    private List<ColumnModel> columnData = new List<ColumnModel>() {
        new ColumnModel(){ HeaderText= "To Do", KeyField= new List<string>() { "Open" } },
        new ColumnModel(){ HeaderText= "In Progress", KeyField= new List<string>() { "In Progress" } },
        new ColumnModel(){ HeaderText= "Testing", KeyField= new List<string>() { "Testing" } },
        new ColumnModel(){ HeaderText= "Done", KeyField=new List<string>() { "Close" } }
    };
    
    protected override void OnInitialized()
    {
        Tasks = Enumerable.Range(1, 20).Select(x => new ObservableDatas()
            {
                Id = "Task 1000" + x,
                Status = (new string[] { "Open", "In Progress", "Testing", "Close" })[new Random().Next(4)],
                Summary = (new string[] { "Analyze the new requirements gathered from the customer.", "Improve application performance", "Fix the issues reported in the IE browser.", "Validate new requirements", "Test the application in the IE browser." })[new Random().Next(5)],
                Assignee = (new string[] { "Nancy Davloio", "Andrew Fuller", "Janet Leverling", "Steven walker", "Margaret hamilt", "Michael Suyama", "Robert King" })[new Random().Next(7)],
            }).ToList();
        ObservableData = new ObservableCollection<ObservableDatas>(Tasks);
    }
    
    public class ObservableDatas : INotifyPropertyChanged
    {
        public string Id { get; set; }
        private string status { get; set; }
        public string Status
        {
            get { return status; }
            set
            {
                this.status = value;
                NotifyPropertyChanged("Status");
            }
        }
        public string Summary { get; set; }
        public string Assignee { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

{% endhighlight %}
{% endtabs %} 

![Microsoft Teams Application with Syncfusion Blazor controls](images\MSTeams\output-msteams-syncfusion.png)

> [View the complete Microsoft Teams Application with Blazor Syncfusion Controls on GitHub](https://github.com/SyncfusionExamples/Building-Apps-for-Microsoft-Teams-with-Blazor-using-Syncfusion-Components)
