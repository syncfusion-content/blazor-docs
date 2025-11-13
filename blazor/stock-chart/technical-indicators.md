---
layout: post
title: Technical Indicators in Blazor Stock Chart Component | Syncfusion
description: Check out and learn about technical indicators available in the Syncfusion Blazor Stock Chart component.
platform: Blazor
control: Stock Chart 
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Technical Indicators in Blazor Stock Chart Component

A technical indicator is a mathematical calculation based on historical price, volume, or open interest information that aims to forecast financial market direction.

Stock Chart supports 10 types of technical indicators: `Accumulation Distribution`, `ATR`, `EMA`, `SMA`, `TMA`, `Momentum`, `MACD`, `RSI`, `Stochastic`, and `Bollinger Band`. Use the indicator dropdown to add or remove the required indicator types.

## Accumulation Distribution

Accumulation Distribution combines price and volume to show potential money flow into or out of a stock. To render an Accumulation Distribution indicator, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `AccumulationDistribution`. To calculate the signal line, the [Volume](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Volume) field must be included in the `DataSource`.

## Average True Range (ATR)

ATR measures stock volatility by comparing the current value with the previous value. To render an Average True Range (ATR) indicator, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `Atr`.

## Exponential Moving Average (EMA)

Moving average indicators are used to define the direction of the trend. To render an EMA indicator, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `Ema`.

## Momentum

Momentum shows the speed at which the stock price is changing. To render a Momentum indicator, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `Momentum`. The Momentum indicator is represented by two lines (`upperLine`, `signalLine`). In the Momentum indicator, the `upperBand` value is always rendered at 100.

## Moving Average Convergence Divergence (MACD)

MACD is based on the difference between two EMAs. To render a MACD indicator, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `Macd`. The MACD indicator is represented by the MACD line, signal line, and MACD histogram. The histogram highlights the difference between the MACD line and the signal line.

## Relative Strength Index (RSI)

RSI shows how strongly a stock is moving in its current direction. To render an RSI indicator, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `Rsi`. The RSI indicator is represented by three lines (`upperBand`, `lowerBand`, `signalLine`). The `upperBand` and `lowerBand` values are customized by the [OverBought](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_OverBought) and [OverSold](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_OverSold) properties, and the `signalLine` is calculated using the RSI formula.

## Simple Moving Average (SMA)

Moving average indicators are used to define the direction of the trend. To render an SMA indicator, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `Sma`.

## Stochastic

Stochastic indicates how a stock compares to its previous state. To render a Stochastic indicator, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `Stochastic`. The Stochastic indicator is represented by four lines (`upperLine`, `lowerLine`, `periodLine`, `signalLine`). The `upperBand` and `lowerBand` values are customized by the [OverBought](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_OverBought) and [OverSold](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_OverSold) properties, and the `periodLine` and `signalLine` are rendered based on the stochastic formula.

## Triangular Moving Average (TMA)

Moving average indicators are used to define the direction of the trend. To render a TMA indicator, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `Tma`.

## Bollinger Band

<!-- markdownlint-disable MD034 -->

A Stock Chart overlay that shows the upper and lower limits of normal price movements based on the standard deviation of prices. To render a Bollinger Band, set the indicator [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_Type) to `BollingerBand`. The Bollinger Band is represented by three lines (`upperLine`, `lowerLine`, `signalLine`), and the default [StandardDeviations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartIndicator.html#Syncfusion_Blazor_Charts_StockChartIndicator_StandardDeviation) value is 2.
