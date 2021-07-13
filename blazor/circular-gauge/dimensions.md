---
layout: post
title: Dimensions in Blazor Circular Gauge Component | Syncfusion 
description: Learn about Dimensions in Blazor Circular Gauge component of Syncfusion, and more details.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Circular Gauge Dimensions

## Size for Circular Gauge

You can set size for the Circular Gauge directly using the [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Width) and [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Height) properties.

### In pixel

You can set the size of the Circular Gauge in pixel as demonstrated below.

```csharp
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Width= "200px" Height= "200px"></SfCircularGauge>
```

![Circular Gauge size in pixel](./images/percentage.png)

### In percentage

By setting value in percentage, gauge gets its dimension with respect to its container. For example, when
the height is ‘50%’, gauge is rendered to half of the container height.

```csharp
@using Syncfusion.Blazor.CircularGauge

<div style="height:450px; width:450px">
    <SfCircularGauge Width="50%" Height="50%"></SfCircularGauge>
</div>
```

![Circular Gauge size in percentage](./images/percentage.png)

>Note: When you do not specify the size, it takes `450`  pixels as the height and takes window size as its width.