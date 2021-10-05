---
layout: post
title: Getting Started with Blazor DatePicker Component | Syncfusion
description: Checkout and learn about getting started with Blazor DatePicker component of Syncfusion, and more details.
platform: Blazor
control: DatePicker
documentation: ug
---

# Getting Started with Blazor DatePicker Component

This section briefly explains about how to include a [Blazor DatePicker](https://www.syncfusion.com/blazor-components/blazor-datepicker) Component in your Blazor Server-Side and Client-Side application. You can refer to our Getting Started with [Blazor Server-Side DatePicker](../getting-started/blazor-server-side-visual-studio-2019/) and [Blazor WebAssembly DatePicker](../getting-started/blazor-webassembly-visual-studio-2019/) documentation pages for configuration specifications.

To get start quickly with Blazor DatePicker component, you can check on this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=ZN0zSIU59nY"%}

## Importing Syncfusion Blazor component in the application

* Install `Syncfusion.Blazor.Calendars` NuGet package to the application by using the `NuGet Package Manager`.

* You can add the client-side resources through [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) or from [NuGet](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets) package in the  **HEAD** element of the **~/wwwroot/index.html** page.

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
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js"></script>
</head>
```

## Adding DatePicker component to the application

To initialize the DatePicker component add the below code to your `Index.razor` view page which is present under `~/Pages` folder.

The following code shows a basic DatePicker component.

```cshtml
<SfDatePicker TValue="DateTime?" Placeholder='Choose a Date'></SfDatePicker>
```

## Run the application

After the successful compilation of your application, press `F5` to run the application.

The output will be as follows.

![Blazor DatePicker Component](./images/blazor-datepicker-component.png)

## Setting the Value and Min and Max dates

The following example demonstrates how to set the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Value) and [Min](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html) and [Max](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.CalendarBase-1.html#Syncfusion_Blazor_Calendars_CalendarBase_1_Max) dates on initializing the DatePicker. Here, you can select a date within the range from 5th to 27th of this month. `TValue` specifies the type of the DatePicker component.

```cshtml
<SfDatePicker TValue="DateTime?" Value='@DateValue' Min='@MinDate' Max='@MaxDate'></SfDatePicker>

@code {
    public DateTime? DateValue {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,10);
    public DateTime MinDate {get;set;} = new DateTime(DateTime.Now.Year,DateTime.Now.Month,05);
    public DateTime MaxDate {get;set;} = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 27);
}
```

The output will be as follows.

![Settin Minimum and Maximum Dates in Blazor DatePicker](./images/blazor-datepicker-min-max-date.png)

## See Also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](../getting-started/blazor-webassembly-dotnet-cli/)
* [Getting Started with Syncfusion Blazor for Server-side in Visual Studio 2019](../getting-started/blazor-server-side-visual-studio-2019/)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](../getting-started/blazor-server-side-dotnet-cli/)