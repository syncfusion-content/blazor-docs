---
layout: post
title: Getting Started with Blazor Bullet Chart Component | Syncfusion
description: Checkout and learn about getting started with Blazor Bullet Chart component of Syncfusion, and more details.
platform: Blazor
control: Bullet Chart 
documentation: ug
---

# Getting Started with Blazor Bullet Chart Component

This section briefly explains how to include a Bullet Chart component in the Blazor server-side application. Refer to [Getting Started with Syncfusion Blazor for server-side in Visual Studio 2019](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/) page for introduction and configuring common specifications.

## Importing Syncfusion Blazor Bullet Chart component in the application

1. Install **Syncfusion.Blazor** NuGet package to the application by using the **NuGet Package Manager**.

2. Add the client-side resources through CDN or from NuGet package in the **HEAD** element of the **~/Pages/_Host.cshtml** page.

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    <!---CDN--->
    @*<link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css" rel="stylesheet" />*@
</head>
```

> For Internet Explorer 11, kindly refer to the polyfills. Refer to the [documentation](https://blazor.syncfusion.com/documentation/common/how-to/render-blazor-server-app-in-ie/) for more information.

 ```html
<head>
    <link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css" rel="stylesheet" />
    <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
</head>
```

## Adding component package to the application

Open the **~/_Imports.razor** file and include the **Syncfusion.Blazor.Charts** namespace.

```cshtml
@using Syncfusion.Blazor.Charts
```

## Adding SyncfusionBlazor service in Startup.cs

Open the **Startup.cs** file and add services required by Syncfusion components using **services.AddSyncfusionBlazor()** method. Add this method in the **ConfigureServices** function as follows.

```csharp
using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....
        public void ConfigureServices(IServiceCollection services)
        {
            ....
            ....
            services.AddSyncfusionBlazor();
        }
    }
}
```

> To enable the custom client-side source loading from CRG or CDN, please refer to the section about [custom resources in Blazor application](https://blazor.syncfusion.com/documentation/common/custom-resource-generator/#how-to-use-custom-resources-in-the-blazor-application).

## Adding Bullet Chart component

To initialize the Bullet Chart component, add the below code to the **Index.razor** view page under **~/Pages** folder. In a new application, if **Index.razor** page has any default content template, then those content can be completely removed, and following code can be added.

```cshtml
@page "/"

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50">
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };
}
```

On successful compilation of the application, the Syncfusion Blazor Bullet Chart component will render in the web browser as follows.

![Blazor Bullet Chart Component](images/blazor-bullet-chart-component.png)

## Adding Title

Add a title by using the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Title) property in the Bullet Chart, to provide quick information to the user about the data plotted in the component.

```cshtml
@page "/"

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };
}
```

![Blazor Bullet Chart with Title](images/blazor-bullet-chart-title.png)

## Adding Ranges

Add ranges by using the [BulletChartRangeCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartRangeCollection.html) to measure the qualitative state by observing the distance between each range.

```cshtml
@page "/"

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
    <BulletChartRangeCollection>
        <BulletChartRange End=150> </BulletChartRange>
        <BulletChartRange End=250></BulletChartRange>
        <BulletChartRange End=300></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };
}
```

![Adding Range in Blazor Bullet Chart](images/blazor-bullet-chart-ranges.png)

## Adding Tooltip

Use the tooltip to show the measured values by setting the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartTooltip-1.html#Syncfusion_Blazor_Charts_BulletChartTooltip_1_Enable) property to **true** in the [BulletChartTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartTooltip-1.html).

```cshtml
@page "/"

<SfBulletChart DataSource="@BulletChartData" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="300" Interval="50" Title="Revenue">
    <BulletChartTooltip TValue="ChartData" Enable="true"></BulletChartTooltip>
    <BulletChartRangeCollection>
        <BulletChartRange End=150> </BulletChartRange>
        <BulletChartRange End=250></BulletChartRange>
        <BulletChartRange End=300></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

@code{
    public class ChartData
    {
        public double FieldValue { get; set; }
        public double TargetValue { get; set; }
    }
    public List<ChartData> BulletChartData = new List<ChartData>
    {
        new ChartData { FieldValue = 270, TargetValue = 250 }
    };
}
```

![Blazor Bullet Chart displays ToolTip](images/blazor-bullet-chart-tooltip.png)
