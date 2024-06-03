---
layout: post
title: Customization in Blazor Range Selector Component | Syncfusion
description: Checkout and learn here all about customization in Syncfusion Blazor Range Selector component and more.
platform: Blazor
control: Range Selector
documentation: ug
---

# Customization in Blazor Range Selector Component

## Navigator Appearance

The Range Selector can be customized by using the [RangeNavigatorStyleSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorStyleSettings.html). The [SelectedRegionColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorStyleSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorStyleSettings_SelectedRegionColor) property is used to specify the color for the selected region, whereas the [UnselectedRegionColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorStyleSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorStyleSettings_UnselectedRegionColor) property is used to specify the color for the unselected region.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value">
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
    <RangeNavigatorStyleSettings UnselectedRegionColor="skyblue" SelectedRegionColor="pink"></RangeNavigatorStyleSettings>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Area" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code{
    public class StockDetails
    {
        public double Date { get; set; }
        public double Close { get; set; }
    }
    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails {  Date = 12, Close = 28 },
        new StockDetails {  Date = 34, Close = 44 },
        new StockDetails {  Date = 45, Close = 48 },
        new StockDetails {  Date = 56, Close = 50 },
        new StockDetails {  Date = 67, Close = 66 },
        new StockDetails {  Date = 78, Close = 78 },
        new StockDetails {  Date = 89, Close = 84 },
    };
    public int[] Value = new int[] { 45, 78 };
}

```

![Customizing Blazor RangeNavigator Appearance](images/custom/blazor-rangenavigator-custom-appearance.png)

## Thumb

The [RangeNavigatorThumbSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html) allows to customize the border, fill color, size, and type of thumb using the [RangeNavigatorThumbBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbBorder.html), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorThumbSettings_Fill), [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorThumbSettings_Height), [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorThumbSettings_Width), and [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorThumbSettings_Type) properties. Thumbs can be of two shapes: **Circle** and **Rectangle**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value">
    <RangeNavigatorStyleSettings>
        <RangeNavigatorThumbSettings Type="ThumbType.Rectangle" Fill="pink">
            <RangeNavigatorThumbBorder Width="2" Color="red"></RangeNavigatorThumbBorder>
        </RangeNavigatorThumbSettings>
    </RangeNavigatorStyleSettings>
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Area" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code{

    public class StockDetails
    {
        public double Date { get; set; }
        public double Close { get; set; }
    }

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails {  Date = 12, Close = 28 },
        new StockDetails {  Date = 34, Close = 44 },
        new StockDetails {  Date = 45, Close = 48 },
        new StockDetails {  Date = 56, Close = 50 },
        new StockDetails {  Date = 67, Close = 66 },
        new StockDetails {  Date = 78, Close = 78 },
        new StockDetails {  Date = 89, Close = 84 },
    };

    public int[] Value = new int[] { 45, 78 };
}

```

![Blazor RangeNavigator with Thumb](images/custom/blazor-rangenavigator-thumb.png)

## Border

Using the [RangeNavigatorBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorBorder.html), the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderModel.html#Syncfusion_Blazor_Charts_BorderModel_Width) and the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderModel.html#Syncfusion_Blazor_Charts_BorderModel_Color) of the Range Selector border can be customized.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value">
    <RangeNavigatorBorder Width="4" Color="Green"></RangeNavigatorBorder>
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Area" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code{
    public class StockDetails
    {
        public double Date { get; set; }
        public double Close { get; set; }
    }
    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails {  Date = 12, Close = 28 },
        new StockDetails {  Date = 34, Close = 44 },
        new StockDetails {  Date = 45, Close = 48 },
        new StockDetails {  Date = 56, Close = 50 },
        new StockDetails {  Date = 67, Close = 66 },
        new StockDetails {  Date = 78, Close = 78 },
        new StockDetails {  Date = 89, Close = 84 },
    };
    public int[] Value = new int[] { 45, 78 };
}

```

![Blazor RangeNavigator with Border](images/custom/blazor-rangenavigator-with-border.png)

## Snapping

The [AllowSnapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_AllowSnapping) property toggles the placement of the slider exactly to the left or right at the nearest interval.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" AllowSnapping="true">
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Area" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code{
    public class StockDetails
    {
        public double Date { get; set; }
        public double Close { get; set; }
    }

    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails {  Date = 12, Close = 28 },
        new StockDetails {  Date = 34, Close = 44 },
        new StockDetails {  Date = 45, Close = 48 },
        new StockDetails {  Date = 56, Close = 50 },
        new StockDetails {  Date = 67, Close = 66 },
        new StockDetails {  Date = 78, Close = 78 },
        new StockDetails {  Date = 89, Close = 84 },
    };
    public int[] Value = new int[] { 45, 78 };
}

```

## Animation

Animation for the Range Selector is enabled by default. The speed of the animation can be controlled using the [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_AnimationDuration) property. The default value of the [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_AnimationDuration) property is **500** milliseconds.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" AnimationDuration="3000">
    <RangeNavigatorRangeTooltipSettings Enable="true"></RangeNavigatorRangeTooltipSettings>
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Area" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code{
    public class StockDetails
    {
        public double Date { get; set; }
        public double Close { get; set; }
    }
    public List<StockDetails> StockInfo = new List<StockDetails> {
        new StockDetails {  Date = 12, Close = 28 },
        new StockDetails {  Date = 34, Close = 44 },
        new StockDetails {  Date = 45, Close = 48 },
        new StockDetails {  Date = 56, Close = 50 },
        new StockDetails {  Date = 67, Close = 66 },
        new StockDetails {  Date = 78, Close = 78 },
        new StockDetails {  Date = 89, Close = 84 },
    };
    public int[] Value = new int[] { 45, 78 };
}

```

## See Also

* [Grid and Tick Lines](./grid-tick/)
* [Labels](./labels/)