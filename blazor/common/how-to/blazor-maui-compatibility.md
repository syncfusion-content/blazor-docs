# MAUI Compatibility for Blazor Components

This section explains how to render Syncfusion Blazor Controls in MAUI application.

## Steps for creation of MAUI application

1. Choose `Create a new project` from Visual Studio 2022 dashboard.

   ![Create a new project in VS2022](images\maui\create-new-project.png)

2. Select `MAUI Blazor App` from the template, click on the `Next` button.

   ![Create MAUI Blazor App](images\maui\create-maui-blazor-server-project.png)

3. Now, the project configuration window will popup. Click the `Create` button to create a new project with default project configuration.

   ![Create new MAUI Blazor App](images\maui\create-new-maui-blazor-app.png)

## Installing Syncfusion Blazor packages in the MAUI Blazor application

You can use the below standards to install the Syncfusion Blazor library in your MAUI Blazor application.

   ### Using Syncfusion Blazor Individual NuGet packages

   * Right-Click on the project in the `Solution Explorer` and select `Manage NuGet Packages`.

      ![Manage NuGet packages in MAUI Blazor app](images\maui\manage-nuget-packages-maui.png)

   * Search for `Syncfusion.Blazor` keyword in the browser tab and install `Syncfusion.Blazor.Calendars` package with the required version in the application. For available individual NuGet packages, refer the [Individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) section.

      ![Installing Syncfusion Calendars NuGet package](images\maui\maui-blazor-nuget-install.png)
    
    * Once the installation process is completed, Syncfusion Blazor Calendars package will be installed in the MAUI Blazor application.

    * Now add the Syncfusion Blazor Theme to the MAUI Blazor application.

```html
    <head>
        ...
        ...
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    </head>
```
**Warning:** As individual NuGet packages are installed, you have to add Syncfusion.Blazor.Themes static web assets (styles) in the application.

## Adding Syncfusion Component and running MAUI application

1. Open `~/Imports.razor` file and add Syncfusion.Blazor namespace.

```cshtml
    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Calendars
```

2. Now, add Syncfusion services to MAUI Blazor Application. Open `MauiProgram.cs` file and register syncfusion blazor services as below.

```cs
    using Syncfusion.Blazor;

    public static class MauiProgram
    {
        public static Maui CreateMauiApp()
        {
            ...
            builder.Services.AddSyncfusionBlazor();
        }
    }
```

3. Now add Syncfusion Blazor components in any .razor file in ~/pages folder. For example, the calendar component is added in `~/Pages/index.razor` page.

```html
    
    <SfCalendar TValue="DateTime"></SfCalendar>

```

4. After the component is added, run the application.

    ![Syncfusion Blazor Calendar component rendering on MAUI Blazor App](images\maui\syncfusion-calendar-output.png)

If you face the below error while running the application, install [this](https://marketplace.visualstudio.com/items?itemName=ProjectReunion.MicrosoftSingleProjectMSIXPackagingToolsDev17).

   ![Maui runtime error](images\maui\runtime-error-maui.png)

Once installed, you may face the below issue.

   ![Maui Deployment error](images\maui\maui-deployment-error.png)

To resolve the above issue, please go to settings, search for developer mode and enable it. [Settings --> Update and Security --> For developers --> enable developer mode].

   ![Enable developer mode in system settings](images\maui\enable-developer-mode.png)

**Note:** 

If you want to run the application in windows application unload the project, and change the target framework in csproj file as below and reload the project.

```cshtml

    <!--<TargetFrameworks>net6.0-ios;net6.0-android;net6.0-maccatalyst</TargetFrameworks>-->
<TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows')) and '$(MSBuildRuntimeType)' == 'Full'">$(TargetFrameworks);net6.0-windows10.0.19041</TargetFrameworks> 

```
