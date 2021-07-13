---
layout: post
title: Globalization in Blazor Sparkline Charts Component | Syncfusion 
description: Learn about Globalization in Blazor Sparkline Charts component of Syncfusion, and more details.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

---
title: "Globalization in the Blazor Sparkline component | Syncfusion"

component: "Sparkline"

description: "Learn here all about globalization of Syncfusion Sparkline (SfSparkline) component and more."
---

# Globalization in the Blazor Sparkline (SfSparkline)

Globalization is the process of designing and developing a component that can work in different cultures or locations. In the Sparkline component, the [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_Format) property is used to globalize number, date, and time values. The tooltip in the following code example is globalized to currency format in the deutsch culture.

```csharp
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new double[]{ 300.00, 600.00, 400.21, 100.20, 300.70, 200.04, 500.00 }" Height="200px" Width="350px" Format="C">
    <SparklineTooltipSettings TValue="double" Visible="true"></SparklineTooltipSettings>
</SfSparkline>
```

> Refer [`here`](https://blazor.syncfusion.com/documentation/common/localization/#enable-localization-in-blazor-server-application) to configure localization for the Blazor server application, and [`here`](https://blazor.syncfusion.com/documentation/common/localization/#enable-localization-in-blazor-webassembly-application) for the Blazor web assembly application.

On successful configuration, the Sparkline will be rendered as following.

![Sparkline with globalization and localization](./images/localization/Localization.png)
