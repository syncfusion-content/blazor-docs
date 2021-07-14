---
layout: post
title: Labels in the Blazor Range Selector component | Syncfusion 
description: Learn here all about the labels in Syncfusion Blazor Range Selector (SfRangeNavigator) component and more.
platform: Blazor
control: Range Selector
documentation: ug
---

# Labels in the Blazor Range Selector (SfRangeNavigator)

## Multi-level labels

The multi-level labels for the Range Selector can be enabled by setting the [`EnableGrouping`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_EnableGrouping) property to **true**. This is restricted to the DateTime axis alone.

{% aspTab template="range-navigator/label/multi", sourceFiles="multi.razor" %}

{% endaspTab %}

![Multilevel labels](images/labels/multi.png)

## Grouping

The multi-level labels can be grouped using the [`GroupBy`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_GroupBy) property with the following interval types:

* Auto
* Years
* Quarter
* Months
* Weeks
* Days
* Hours
* Minutes
* Seconds

{% aspTab template="range-navigator/label/group", sourceFiles="group.razor" %}

{% endaspTab %}

![Grouping](images/labels/group.png)

## Smart labels

The [`LabelIntersectAction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelIntersectAction) property is used to avoid overlapping of labels. The following code sample shows the setting of [`LabelIntersectAction`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelIntersectAction) property to **Hide**.

{% aspTab template="range-navigator/label/smart", sourceFiles="smart.razor" %}

{% endaspTab %}

![Smart labels](images/labels/smart.png)

## Position

By default, the labels can be placed outside the Range Selector. It can also be placed inside the Range Selector
using the [`LabelPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_LabelPosition) property.

{% aspTab template="range-navigator/label/position", sourceFiles="position.razor" %}

{% endaspTab %}

![Label positioning](images/labels/position.png)

## Labels Customization

The font size, color, family, etc. can be customized using the [`RangeNavigatorLabelStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorLabelStyle.html) setting.

{% aspTab template="range-navigator/label/custom", sourceFiles="custom.razor" %}

{% endaspTab %}

![Labels Customization](images/labels/custom.png)