---
layout: post
title: Customization in the Blazor Range Selector component | Syncfusion
description: Learn here all about customization of the Syncfusion Blazor Range Selector (SfRangeNavigator) component and more.
platform: Blazor
control: Range Selector
documentation: ug
---

# Customization in the Blazor Range Selector (SfRangeNavigator)

## Navigator Appearance

The Range Selector can be customized by using the [`RangeNavigatorStyleSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorStyleSettings.html). The [`SelectedRegionColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorStyleSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorStyleSettings_SelectedRegionColor) property is used to specify the color for the selected region, whereas the [`UnselectedRegionColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorStyleSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorStyleSettings_UnselectedRegionColor) property is used to specify the color for the unselected region.

{% aspTab template="range-navigator/custom/appearance", sourceFiles="appearance.razor" %}

{% endaspTab %}

![Range Selector appearance](images/custom/appearance.png)

## Thumb

The [`RangeNavigatorThumbSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html) allows to customize the border, fill color, size, and type of thumb using the [`RangeNavigatorThumbBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbBorder.html), [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorThumbSettings_Fill), [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorThumbSettings_Height), [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorThumbSettings_Width), and [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorThumbSettings.html#Syncfusion_Blazor_Charts_RangeNavigatorThumbSettings_Type) properties. Thumbs can be of two shapes: **Circle** and **Rectangle**.

{% aspTab template="range-navigator/custom/thumb", sourceFiles="thumb.razor" %}

{% endaspTab %}

![Thumb](images/custom/thumb.png)

## Border

Using the [`RangeNavigatorBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorBorder.html), the [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorBorder.html#Syncfusion_Blazor_Charts_RangeNavigatorBorder_Widthhttps://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Width) and the [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Color) of the Range Selector border can be customized.

{% aspTab template="range-navigator/custom/border", sourceFiles="border.razor" %}

{% endaspTab %}

![Range Selector Border](images/custom/border.png)

## Snapping

The [`AllowSnapping`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.RangeNavigatorModel.html#Syncfusion_Blazor_Charts_RangeNavigatorModel_AllowSnapping) property toggles the placement of the slider exactly to the left or right at the nearest interval.

{% aspTab template="range-navigator/custom/snap", sourceFiles="snap.razor" %}

{% endaspTab %}

## Animation

Animation for the Range Selector is enabled by default. The speed of the animation can be controlled using the [`AnimationDuration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_AnimationDuration) property. The default value of the [`AnimationDuration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfRangeNavigator.html#Syncfusion_Blazor_Charts_SfRangeNavigator_AnimationDuration) property is **500** milliseconds.

{% aspTab template="range-navigator/custom/animation", sourceFiles="animation.razor" %}

{% endaspTab %}

## See Also

* [Grid and Tick Lines](./grid-tick/)
* [Labels](./labels/)