---
layout: post
title: RTL in Blazor Range Selector Component | Syncfusion
description: Checkout and learn here all about RTL in Syncfusion Blazor Range Selector component and much more details.
platform: Blazor
control: Range Selector
documentation: ug
---

# RTL in Blazor Range Selector Component

The Range Selector supports right-to-left (RTL), which can be enabled with the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_EnableRtl) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfRangeNavigator Value="@Value" ValueType="RangeValueType.DateTime" LabelFormat="MMM-yy" EnableRtl="true">
    <RangeNavigatorSeriesCollection>
        <RangeNavigatorSeries DataSource="@StockInfo" XName="Date" Type="RangeNavigatorType.Area" YName="Close">
        </RangeNavigatorSeries>
    </RangeNavigatorSeriesCollection>
</SfRangeNavigator>

@code {
    public class StockDetails
    {
        public DateTime Date { get; set; }
        public double Close { get; set; }
    }

    public DateTime[] Value = new DateTime[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };

    public List<StockDetails> StockInfo = new List<StockDetails>
    {
        new StockDetails { Date = new DateTime(2005, 01, 01), Close = 21,   },
        new StockDetails { Date = new DateTime(2006, 01, 01), Close = 24, },
        new StockDetails { Date = new DateTime(2007, 01, 01), Close = 36,   },
        new StockDetails { Date = new DateTime(2008, 01, 01), Close = 38,   },
        new StockDetails { Date= new DateTime(2009, 01, 01), Close = 54,   },
        new StockDetails { Date = new DateTime(2010, 01, 01), Close = 57,   },
        new StockDetails { Date = new DateTime(2011, 01, 01), Close = 70,   }
    };
}
```

![Right to Left in Blazor RangeNavigator](images/common/blazor-rangenavigator-rght-to-left.png)