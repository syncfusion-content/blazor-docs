---
layout: post
title: Stock Events in Blazor Stock Chart  Component | Syncfusion 
description: Learn about Stock Events in Blazor Stock Chart  component of Syncfusion, and more details.
platform: Blazor
control: Stock Chart 
documentation: ug
---

# Stock Events

The stock events are used to mark specific events such as market open and close, highest or lowest price reached, year/quarter start and end on a Chart for a specific date. In this section, **SplineSeries** is used to represent selected data value. One can customize the specific data value using `StockEvents`.

## Date

The [`Date`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartStockEvent.html#Syncfusion_Blazor_Charts_StockChartStockEvent_Date) property is used to display the stock event in the Chart at the specified time. For example, Quarter 1 ends on March 31, 2021, and the stock event date must be set to March 31, 2021. More customization options are available in the immediate sections such as **Text**, **Type**, **Description**, and so on.

## Text

The text acts as a quick and short representation of the stock event, such as **Q1** for Quarter 1 and **High** for highest price over a period; it can be customized separately for each stock event using the [`Text`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartStockEvent.html#Syncfusion_Blazor_Charts_StockChartStockEvent_Text) property.

## Type

The [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.FlagType.html) property can be used to set the background shape of a stock event, with options such as **Circle**, **Square**, **Flag**, **Text**, **Sign**, **Triangle**, **InvertedTriangle**, **ArrowUp**, **ArrowDown**, **ArrowLeft**, and **ArrowRight**.

## Background

The [`Background`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartStockEvent.html#Syncfusion_Blazor_Charts_StockChartStockEvent_Background) property of the stock event is used to customize the color of the background shape, which accepts values in hex and rgba as a valid CSS color string.

## Description

The [`Description`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartStockEvent.html#Syncfusion_Blazor_Charts_StockChartStockEvent_Description) property specifies the content of the stock event tooltip that appears on the Chart when the mouse is moved over the stock event. The description will be displayed as the text of the tooltip. For instance, if [`Text`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartStockEvent.html#Syncfusion_Blazor_Charts_StockChartStockEvent_Text) **Q1** contains a [`Description`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartStockEvent.html#Syncfusion_Blazor_Charts_StockChartStockEvent_Description) as **Quarter 1**, the tooltip will show **Quarter 1**.

{% aspTab template="stock-chart/stockchart-feature/stock-events", sourceFiles="stockEvents.razor" %}

{% endaspTab %}

![Stock Events in Stock Chart](images/stock-events.png)
