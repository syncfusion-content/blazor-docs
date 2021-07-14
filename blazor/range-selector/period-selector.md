---
layout: post
title: Period selector in the Blazor Range Selector component | Syncfusion "
description: Learn here all about period selector feature of Syncfusion Blazor Range Selector (SfRangeNavigator) component and more.
platform: Blazor
control: Range Selector
documentation: ug
---

# Period selector in the Blazor Range Selector (SfRangeNavigator)

The period selector allows to choose a time range with specific periods.

## Periods

An array of objects that allows the users to specify pre-defined time intervals. The [`Interval`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorPeriod.html#Syncfusion_Blazor_Charts_RangeNavigatorPeriod_Interval) property specifies the count value of the button, the [`Selected`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorPeriod.html#Syncfusion_Blazor_Charts_RangeNavigatorPeriod_Selected) property allows the users to select the period button initially, and the [`Text`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorPeriod.html#Syncfusion_Blazor_Charts_RangeNavigatorPeriod_Text) property specifies the text to be displayed on the button. The [`IntervalType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorPeriod.html#Syncfusion_Blazor_Charts_RangeNavigatorPeriod_IntervalType) property allows the users to customize the interval type, and it supports the following types:

* Auto
* Years
* Quarter
* Months
* Weeks
* Days
* Hours
* Minutes
* Seconds

{% aspTab template="range-navigator/period/periods", sourceFiles="periods.razor" %}

{% endaspTab %}

![Periods](images/period-selector/periods.png)

## Position

The [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorPeriodSelectorSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorPeriodSelectorSettings_Position) property allows the users to position the period selector at the **Top** or **Bottom**.

{% aspTab template="range-navigator/period/position", sourceFiles="position.razor" %}

{% endaspTab %}

![Positioning](images/period-selector/position.png)

## Height

The [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorPeriodSelectorSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorPeriodSelectorSettings_Height) property allows the users to specify the height of the period selector. The default value of the height property is **43px**.

{% aspTab template="range-navigator/period/height", sourceFiles="height.razor" %}

{% endaspTab %}

![Height](images/period-selector/height.png)

## Visibility

The [`DisableRangeSelector`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_DisableRangeSelector) property allows the users to display only the period selector and not the Range Selector.

{% aspTab template="range-navigator/period/visible", sourceFiles="visible.razor" %}

{% endaspTab %}

## See Also

* [Disable Range Selector](./light-weight/)