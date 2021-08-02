---
layout: post
title: Getting Started with Blazor Datetime Picker Component | Syncfusion
description: Checkout and learn about getting started with Blazor Datetime Picker component of Syncfusion, and more details.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Getting Started with Blazor Datetime Picker Component

This section briefly explains about how to include a [Blazor DateTimePicker](https://www.syncfusion.com/blazor-components/blazor-datetime-picker) Component in your Blazor Server-Side and Client-Side application. You can refer to our Getting Started with [Blazor Server-Side DateTimePicker](../getting-started/blazor-server-side-visual-studio-2019/) and [Blazor WebAssembly DateTimePicker](../getting-started/blazor-webassembly-visual-studio-2019/) documentation pages for configuration specifications.

To get start quickly with Blazor DateTimePicker component, you can check on this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=BzcHdhd4o8I"%}

## Importing Syncfusion Blazor component in the application

* Install `Syncfusion.Blazor.Calendars` NuGet package to the application by using the `NuGet Package Manager`.

> Please ensure to check the `Include prerelease` option for our Beta release.

* You can add the client-side resources through CDN or from NuGet package in the  **HEAD** element of the **~/wwwroot/index.html** page.

 ```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    <!-- <link href="https://cdn.syncfusion.com/blazor/{{version}}/styles/{{theme}}.css" rel="stylesheet" /> -->
</head>
```

> For Internet Explorer 11 kindly refer the polyfills. Refer the [documentation](https://ej2.syncfusion.com/blazor/documentation/common/how-to/render-blazor-server-app-in-ie/) for more information.

 ```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
</head>
```

## Adding component package to the application

Open `~/_Imports.razor` file and import the `Syncfusion.Blazor.Calendars` package.

```cshtml
@using Syncfusion.Blazor.Calendars
```

## Add SyncfusionBlazor service in Program.cs

Open the **Program.cs** file and add services required by Syncfusion components using  **builder.Services.AddSyncfusionBlazor()** method.

```csharp
using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            ....
            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}
```

> To enable custom client side resource loading from CRG or CDN. You need to disable resource loading by `AddSyncfusionBlazor(true)` and load the scripts in the **HEAD** element of the **~/wwwroot/index.html** page.

 ```html
<head>
    <script src="https://cdn.syncfusion.com/blazor/{:version:}/syncfusion-blazor.min.js"></script>
</head>
```

## Adding DateTimePicker component to the application

To initialize the DateTimePicker component add the below code to your `Index.razor` view page which is present under `~/Pages` folder.

The following code shows a basic DateTimePicker component.

```cshtml
<SfDateTimePicker TValue="DateTime?" Placeholder='Select a date and time'></SfDateTimePicker>
```

## Run the application

After successful compilation of your application, press `F5` to run the application.

The output will be as follows.

![DateTimePicker](./images/default.png)

## Setting the Value, Min and Max

The minimum and maximum date time can be defined with the help of [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Min) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html#Syncfusion_Blazor_Calendars_SfDateTimePicker_1_Max) properties.

The following code demonstrates how to set the `Min` and `Max` on initializing the DateTimePicker. `TValue` specifies the type of the DatePicker component.

```cshtml
<SfDateTimePicker TValue="DateTime?" Value="@DateValue" Min="@MinDate" Max="@MaxDate"></SfDateTimePicker>

@code{
    public DateTime? DateValue {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,10);
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,05);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27);
}
```

The output will be as follows.

![DateTimePicker](./images/min_max.png)

## See Also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](../getting-started/blazor-webassembly-dotnet-cli/)
* [Getting Started with Syncfusion Blazor for Server-side in Visual Studio 2019](../getting-started/blazor-server-side-visual-studio-2019/)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](../getting-started/blazor-server-side-dotnet-cli/)