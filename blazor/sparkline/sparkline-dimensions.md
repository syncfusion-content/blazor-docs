# Sparkline Dimensions

## Size for Container

The size of the Sparkline is determined based on the container size, and the size can be changed inline or via CSS as shown in the following.

```csharp
@using Syncfusion.Blazor.Charts

<div style="width:650px; height:350px;">
    <SfSparkline XName="Year" YName="Population" TValue="PopulationReport" DataSource="PopulationData">
    </SfSparkline>
</div>

@code {
    public class PopulationReport
    {
        public int Year { get; set; }
        public int Population { get; set; }
    };
    public List<PopulationReport> PopulationData = new List<PopulationReport> {
        new  PopulationReport { Year= 2005, Population= 20090440 },
        new  PopulationReport { Year= 2006, Population= 20264080 },
        new  PopulationReport { Year= 2007, Population= 20434180 },
        new  PopulationReport { Year= 2008, Population= 21007310 },
        new  PopulationReport { Year= 2009, Population= 21262640 },
        new  PopulationReport { Year= 2010, Population= 21515750 },
        new  PopulationReport { Year= 2011, Population= 21766710 },
        new  PopulationReport { Year= 2012, Population= 22015580 },
        new  PopulationReport { Year= 2013, Population= 22262500 },
        new  PopulationReport { Year= 2014, Population= 22507620 }
    };
}
```

![Sparkline with container size](./images/SparklineDimension/ContainerSize.png)

## Size for Sparkline

The [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Width) and the [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Height) properties can be used to customize the size of the Sparkline. Both pixel and percentage values are accepted.

### In pixel

The size of Sparkline Charts can be specified in pixels, as shown in the following code.

```csharp
@using Syncfusion.Blazor.Charts

<div style="width:650px; height:350px;">
    <SfSparkline XName="Year" YName="Population" TValue="PopulationReport" DataSource="PopulationData">
    </SfSparkline>
</div>
```

> Refer to the [code block](#size-for-container) to know about the property value of the **PopulationData**.

![Sparkline with size in pixel](./images/SparklineDimension/Inpixel.png)

### In percentage

If the value is expressed as a percentage, the dimension of the Sparkline is determined from its container.

```csharp
@using Syncfusion.Blazor.Charts

<div style="width:700px; height:300px;">
    <SfSparkline XName="Year" YName="Population" TValue="PopulationReport" DataSource="PopulationData" Width="50%" Height="50%">
    </SfSparkline>
</div>
```

> Refer to the [code block](#size-for-container) to know about the property value of **PopulationData**.

![Sparkline with size in percentage](./images/SparklineDimension/Inpercentage.png)
