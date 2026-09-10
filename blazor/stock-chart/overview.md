---
layout: post
title: Blazor Stock Chart Overview and Features | Syncfusion
description: Learn how to use Blazor Stock Chart for financial data visualization with candle and hilo series, period selector, range selector, technical indicators, and stock events.
platform: Blazor
control: Stock Chart
documentation: ug
---

# Overview in Blazor Stock Chart

## Introduction to Syncfusion Blazor Stock Chart

The [Blazor Stock Chart]((https://www.syncfusion.com/blazor-components/blazor-stock-chart)) is a powerful and feature-rich UI component designed for visualizing stock market and financial time-series data with high performance and flexibility. It offers a comprehensive set of enterprise-grade capabilities, including candle, hilo, and OHLC financial series types, a built-in period selector and range selector for quick time-span navigation, technical indicators, and annotation of market-moving events. Built for scalability, it enables developers to create responsive, data-intensive financial dashboards for stock trading, portfolio tracking, and market analysis applications.

## Common use cases

The Blazor Stock Chart is ideal for a wide range of business scenarios:

| Use Case | Description | Key Features |
|----------|-------------|--------------|
| **Stock Price Tracking** | Track daily, weekly, and monthly open, high, low, and close prices | Candle Series, Period Selector, Zooming |
| **Trading Analysis** | Identify trends, momentum, and reversal signals on price charts | Technical Indicators, Trendlines, Crosshair |
| **Market Event Annotation** | Mark earnings, splits, and dividend dates on the timeline | Stock Events |
| **Portfolio Dashboards** | Compare multiple instruments in compact, stacked views | Series Types, Legend, Gradient |
| **Historical Research** | Explore long price histories by selecting ranges interactively | Range Selector, Panning, Zooming |
| **Reporting & Sharing** | Export chart views into documents and presentations | Export, Print |

## Data connectivity

The Blazor Stock Chart enables multiple data binding approaches, offering flexibility in choosing the right strategy for different application architectures. The stock chart can work with in-memory collections, connect to remote services, or leverage ORM frameworks for seamless database integration.

**Data Binding Approaches**

- **[List binding](./working-with-data#list-binding)** — Bind charts to local collections of OHLC (open, high, low, close) records for fast data access without external dependencies. Ideal for small to medium datasets and rapid prototyping.
- **[Remote Data](./working-with-data#remote-data)** — Connect to **web services, REST APIs**, and remote endpoints using DataManager adaptors for scalable applications.
- **[Observable collection](./working-with-data#observable-collection)** — Automatically reflect added and removed data points without manual refresh.
- **[Entity Framework](./working-with-data#entity-framework)** — Bind directly to EF Core DbContext query results for simplified database model binding.
- **[Handling No Data](./working-with-data#handling-no-data)** — Display a meaningful message when the data source is empty.

## Series types

The Stock Chart supports six financial series types, switchable at runtime through the built-in series selector:

| Series Type | Description | Best For |
|------------|-------------|----------|
| **Candle** | Open and close prices as a filled body with high-low wicks | Traditional price action reading |
| **[Hollow Candle](./series-types)** | Candle variant where bullish candles render hollow | Highlighting upward momentum |
| **[Hilo](./series-types)** | High-low bars without open and close detail | Minimal, compact price view |
| **[HiloOpenClose](./series-types)** | High-low bars with open and close tick marks | OHLC detail with compact body |
| **[Line](./series-types)** | Close prices connected by line segments | Clear closing trend |
| **[Spline](./series-types)** | Close prices connected by smooth curves | Smoothed trend visualization |

## Axes & navigation

The Blazor Stock Chart offers specialized axes and built-in navigation elements tailored for financial time-series exploration:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[DateTime Axis](./axis-types#datetime-axis)** | Plot date-time values with interval types | Time-series visualization |
| **[DateTimeCategory Axis](./axis-types#datetimecategory-axis)** | Plot date-time values without interval breaks such as non-trading days | Gap-free trading calendars |
| **[Logarithmic Axis](./axis-types#logarithmic-axis)** | Plot values across exponential ranges | Wide-range price movements |
| **[Axis Customization](./axis-customization)** | Style axis labels, grid lines, and crossing behavior | Precise axis control |
| **[Period Selector](./period-selector#periods)** | Predefined time-span buttons such as 1M, 3M, and 1Y | One-click time navigation |
| **[Range Selector](./range-selector#selecting-range)** | Drag handles on a mini overview chart to select the visible range | Precise interactive range control |
| **[Zooming](./zooming#enable-zooming)** | Zoom by pinch, mouse wheel, selection, or toolbar | Precise data inspection |
| **[Panning](./panning)** | Drag the visible range across the timeline after zooming | Smooth timeline navigation |

## Data visualization elements

The Blazor Stock Chart provides comprehensive elements for annotating and enhancing financial charts:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Tooltip](./tool-tip#default-tooltip)** | Show OHLC details on hover with format support | On-demand price information |
| **[Crosshair](./cross-hair)** | Track exact values along the axes with axis tooltips | Value inspection without clutter |
| **[Last Data Label](./last-data-label)** | Highlight the most recent data point of each series | Latest price visibility |
| **[Legend](./legend#enable-legend)** | Explain series colors with position and alignment options | Series differentiation |
| **[Stock Events](./stock-events)** | Annotate earnings, splits, and market news on the timeline | Market context markers |
| **[Appearance](./appearance)** | Configure titles, margins, background, and themes | Complete visual control |
| **[Gradient](./gradient#linear-gradient)** | Apply gradient color fills to series | Modern visual polish |
| **[Stock Chart Dimensions](./chart-dimensions)** | Control chart width and height | Predictable layout integration |

## Advanced analytics

The Blazor Stock Chart includes sophisticated capabilities designed for complex financial analysis scenarios:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Technical Indicators](./technical-indicators)** | Overlay indicators such as Accumulation Distribution, ATR, EMA, and Momentum | Informed trading analysis |
| **[Trendlines](./trend-lines)** | Project linear, logarithmic, and exponential trend lines onto series | Trend and forecast analysis |

## Print & export

The Blazor Stock Chart provides comprehensive output capabilities for reporting and sharing chart visuals:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Print and Export](./export-print)** | Print the chart and export it to PDF, image, and Excel documents | Professional document integration |
| **[Customize the exported chart using the Exporting event](./export-print#customize-the-exported-chart-using-the-exporting-event)** | Modify the exported output | Branded export documents |

## Accessibility

The Blazor Stock Chart is fully accessible and compliant with Web Content Accessibility Guidelines (WCAG) standards:

- **[WAI-ARIA attributes](./accessibility#wai-aria-attributes)** — Accessible roles and attributes for the stock chart UI
- **[Keyboard interaction](./accessibility#keyboard-interaction)** — Complete chart operation via keyboard
- **[Ensuring accessibility](./accessibility#ensuring-accessibility)** — Validation guidance for accessible charts

## System requirements

The Blazor Stock Chart works with:

- **Blazor Version**: .NET 8.0 or higher
- **Hosting Models**: Blazor Server, Blazor WebAssembly, Blazor Web App
- **Browsers**: Chrome, Firefox, Safari, Edge (latest versions)
- **Mobile**: iOS Safari, Android Chrome

## Quick links

**Getting Started:**
- [Blazor Web App Guide](./getting-started-webapp)
- [Blazor WebAssembly Guide](./getting-started)

**Popular Features:**
- [Series Types](./series-types) — Candle, Hilo, OHLC, and line series
- [Period Selector](./period-selector) — Predefined time-span navigation
- [Range Selector](./range-selector) — Interactive range selection on an overview chart
- [Technical Indicators](./technical-indicators) — Trading signal overlays
- [Stock Events](./stock-events) — Market event annotation
- [Print and Export](./export-print) — PDF, image, and Excel output

## Support & Resources

- **Questions?** Visit the [Syncfusion Support Portal](https://www.syncfusion.com/support)
- **Code Examples?** Browse [Stock Chart Demos](https://www.syncfusion.com/blazor-components/blazor-stock-chart) and samples
- **API Details?** See [Stock Chart API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfStockChart.html)
- **Community?** Join the [Syncfusion Community Forum](https://www.syncfusion.com/forums/blazor-components)
- **What's New?** Check [Release Notes](../Release-Notes)
