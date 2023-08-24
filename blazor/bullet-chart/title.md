---
layout: post
title: Title and Subtitle in Blazor Bullet Chart Component | Syncfusion
description: Checkout and learn here all about Title and Subtitle in Syncfusion Blazor Bullet Chart component and much more.
platform: Blazor
control: Bullet Chart 
documentation: ug
---

# Title and Subtitle in Blazor Bullet Chart Component

## Title

The title of the [Blazor Bullet Chart](https://www.syncfusion.com/blazor-components/blazor-bullet-chart) displays the information about the data plotted by specifying it in the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Title) property.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartRangeCollection>
        <BulletChartRange End=35> </BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
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
        new ChartData { FieldValue = 55, TargetValue = 75 }
    };
}
```

![Blazor Bullet Chart with Title](images/blazor-bullet-chart-with-title.png)

## Subtitle

To show additional information about the data plotted, the Bullet Chart can also be given a subtitle using the [Subtitle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_Subtitle) property.

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="150px" Subtitle="(in dollars $)" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartRangeCollection>
        <BulletChartRange End=35> </BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> Refer to the [code block](#title) to know about the property value of the **BulletChartData**.

![Blazor Bullet Chart with Subtitle](images/blazor-bullet-chart-subtitle.png)

## Title and subtitle position

The title and the subtitle positions can be customized using the [TitlePosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfBulletChart-1.html#Syncfusion_Blazor_Charts_SfBulletChart_1_TitlePosition) property. Possible positions are [Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextPosition.html#Syncfusion_Blazor_Charts_TextPosition_Left), [Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextPosition.html#Syncfusion_Blazor_Charts_TextPosition_Right), [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextPosition.html#Syncfusion_Blazor_Charts_TextPosition_Top) and [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextPosition.html#Syncfusion_Blazor_Charts_TextPosition_Bottom).

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" TitlePosition="TextPosition.Left" Height="100px" Subtitle="(in dollars $)" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartRangeCollection>
        <BulletChartRange End=35> </BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

<SfBulletChart DataSource="@BulletChartData" TitlePosition="TextPosition.Right" Height="100px" Subtitle="(in dollars $)" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartRangeCollection>
        <BulletChartRange End=35> </BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

<SfBulletChart DataSource="@BulletChartData" TitlePosition="TextPosition.Top" Height="150px" Subtitle="(in dollars $)" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartRangeCollection>
        <BulletChartRange End=35> </BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>

<SfBulletChart DataSource="@BulletChartData" TitlePosition="TextPosition.Bottom" Height="150px" Subtitle="(in dollars $)" Title="Sales Rate" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartRangeCollection>
        <BulletChartRange End=35> </BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> Refer to the [code block](#title) to know about the property value of the **BulletChartData**.

![Changing Title and Subtitle Position in Blazor Bullet Chart](images/blazor-bullet-chart-title-positions.png)

## Title and subtitle customization

The title and the subtitle - color, opacity, font size, font family, font weight, and font style can be customized using the [BulletChartTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartTitleStyle.html) and the [BulletChartSubTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartSubTitleStyle.html) settings. The [MaximumTitleWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartCommonFont.html#Syncfusion_Blazor_Charts_BulletChartCommonFont_MaximumTitleWidth) property determines the maximum width of the text, and the [TextOverflow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartCommonFont.html#Syncfusion_Blazor_Charts_BulletChartCommonFont_TextOverflow) property is used to [Wrap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextOverflow.html#Syncfusion_Blazor_Charts_TextOverflow_Wrap) or [Trim](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextOverflow.html#Syncfusion_Blazor_Charts_TextOverflow_Trim) the title and the subtitle when the text size exceeds the [MaximumTitleWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartCommonFont.html#Syncfusion_Blazor_Charts_BulletChartCommonFont_MaximumTitleWidth). The default value of the [TextOverflow](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BulletChartCommonFont.html#Syncfusion_Blazor_Charts_BulletChartCommonFont_TextOverflow) is [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.TextOverflow.html#Syncfusion_Blazor_Charts_TextOverflow_None).

```cshtml
@using Syncfusion.Blazor.Charts

<SfBulletChart DataSource="@BulletChartData" Height="150px" Title="Sales Rate" Subtitle="(in dollars $)" ValueField="FieldValue" TargetField="TargetValue" Minimum="0" Maximum="100" Interval="20">
    <BulletChartTitleStyle Color="red" Opacity="1" Size="15px"></BulletChartTitleStyle>
    <BulletChartSubTitleStyle Color="red" Opacity="0.5" Size="13px" FontStyle="italic" MaximumTitleWidth="70" TextOverflow="TextOverflow.Trim"></BulletChartSubTitleStyle>
    <BulletChartRangeCollection>
        <BulletChartRange End=35> </BulletChartRange>
        <BulletChartRange End=50></BulletChartRange>
        <BulletChartRange End=100></BulletChartRange>
    </BulletChartRangeCollection>
</SfBulletChart>
```

N> Refer to the [code block](#title) to know about the property value of the **BulletChartData**.

![Customizing Title and Subtitle in Blazor Bullet Chart](images/blazor-bullet-chart-title-customization.png)