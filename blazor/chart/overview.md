---
layout: post
title: Blazor Charts Overview and Features | Syncfusion
description: Learn how to use Blazor Charts for data visualization with 50+ chart types, axes, data binding, legends, tooltips, zooming, and technical indicators.
platform: Blazor
control: Charts
documentation: ug
---

# Overview in Blazor Charts

## Introduction to Syncfusion Blazor Charts

The [Blazor Charts]((https://www.syncfusion.com/blazor-components/blazor-charts)) is a powerful and feature-rich UI component designed for visualizing business and analytical data with high performance and flexibility. It offers a comprehensive set of enterprise-grade capabilities, including support for financial and statistical charting, multiple axes, data-driven visual elements, and seamless integration with local and remote data sources. Built for scalability, it enables developers to create responsive, data-intensive dashboards and reports with ease.

## Common use cases

The Blazor Charts is ideal for a wide range of business scenarios:

| Use Case | Description | Key Features |
|----------|-------------|--------------|
| **Sales & Revenue Dashboards** | Compare revenue across products, regions, and time periods | Combination Charts, Multiple Axis, Data Labels |
| **Financial Analysis** | Track stock prices, volatility, and trading signals | Candle, Hilo, Technical Indicators |
| **Trend Analysis** | Visualize performance trends and forecasts over time | Line, Spline, Trendlines |
| **Statistical Reporting** | Display distributions, quartiles, and outliers | Histogram, Box and Whisker, Error Bar |
| **Comparative Analysis** | Contrast categories and stacked contributions | Column, Bar, Stacking, 100% Stacking |
| **Live Monitoring** | Update charts in real time from streaming data | Live Chart, Data Editing, Events |

## Data connectivity

The Blazor Charts enables multiple data binding approaches, offering flexibility in choosing the right strategy for different application architectures. The chart can work with in-memory collections, connect to remote services, or leverage ORM frameworks for seamless database integration.

**Data Binding Approaches**

- **[List binding](./working-with-data#list-binding)** — Bind charts to local collections, lists, and arrays for fast data access without external dependencies. Ideal for small to medium datasets and rapid prototyping.
- **[Remote data](./working-with-data#remote-data)** — Connect to **web services, REST APIs**, and remote endpoints using DataManager adaptors for scalable applications.
- **[Entity Framework](./working-with-data#entity-framework)** — Bind directly to EF Core DbContext query results for simplified database model binding.

## Chart types

The Blazor Charts supports 50+ chart types for virtually every visualization requirement. Each type supports markers, data labels, tooltips, legends, and empty-point handling:

| Category | Available Types | Best For |
|----------|----------------|----------|
| **Line & Spline** | [Line](./chart-types/line), [Step Line](./chart-types/step-line), [Stacked Line](./chart-types/stacked-line), [100% Stacked Line](./chart-types/stack-line), [Spline](./chart-types/spline) | Continuous trends over time |
| **Area** | [Area](./chart-types/area), [Range Area](./chart-types/range-area), [Range Step Area](./chart-types/range-step-area), [Spline Range Area](./chart-types/spline-range-area), [Stacked Area](./chart-types/stacked-area), [100% Stacked Area](./chart-types/stack-area), [Step Area](./chart-types/step-area), [Spline Area](./chart-types/spline-area) | Volume comparison beneath a line |
| **Column & Bar** | [Column](./chart-types/column), [Range Column](./chart-types/range-column), [Stacked Column](./chart-types/stacked-column), [100% Stacked Column](./chart-types/stack-column), [Bar](./chart-types/bar), [Stacked Bar](./chart-types/stacked-bar), [100% Stacked Bar](./chart-types/stack-bar) | Category magnitude comparison |
| **Distribution & Statistical** | [Scatter](./chart-types/scatter), [Bubble](./chart-types/bubble), [Histogram](./chart-types/histogram), [Box and Whisker](./chart-types/box-whisker), [Error Bar](./chart-types/error-bar), [Waterfall](./chart-types/waterfall), [Pareto](./chart-types/pare-to) | Statistical analysis and contribution |
| **Polar & Radar** | [Polar](./chart-types/polar), [Radar](./chart-types/radar) | Multivariate comparison |
| **Financial** | [Candle](./chart-types/candle), [Hilo](./chart-types/high-low), [High Low Open Close](./chart-types/high-low-open-close) | Stock and market data |
| **Mixed Charts** | [Mixed Chart](./chart-series) | Combining incompatible chart types in one plot |

## Axes

The Blazor Charts offers extensive axis options for precisely mapping data to the plot area:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Category Axis](./category-axis)** | Plot data against provided labels | Simple category comparison |
| **[Numeric Axis](./numeric-axis)** | Plot numeric data with range control | Continuous numeric scales |
| **[DateTime Axis](./date-time-axis)** | Plot date-time values with interval types | Time-series visualization |
| **[Logarithmic Axis](./logarithmic-axis)** | Plot values across exponential ranges | Wide-range scientific data |
| **[Axis Labels](./axis-labels)** | Style and rotate axis labels, handle label intersect | Readable tick labels |
| **[Axis Customization](./axis-customization)** | Axis crossing, titles, tick and grid lines, inversed axis | Precise axis control |
| **[Multiple Axis](./axis-customization#multiple-axis)** | Add multiple axes to one chart | Multi-unit comparison |
| **[Strip Lines](./strip-line)** | Highlight ranges or bands of interest on the axis | Threshold visualization |
| **[Multiple Panes](./multiple-panes)** | Divide the chart into stacked panes | Compact multi-series layouts |

## Data visualization elements

The Blazor Charts provides comprehensive elements for annotating and enhancing data points:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Data Labels](./data-labels)** | Display values on data points with position and format control | Direct value visibility |
| **[Data Label Template](./data-label-template)** | Use custom Blazor templates for data labels | Fully customized labels |
| **[Data Markers](./data-markers)** | Highlight data points with shapes and images | Point identification |
| **[Legend](./legend#enable-legend)** | Explain series and point colors with position control | Series differentiation |
| **[Tooltip](./tool-tip#enable-tooltip)** | Show point details on hover with template support | On-demand information |
| **[Chart Annotations](./chart-annotations)** | Place custom HTML content anywhere in the chart | In-plot contextual content |
| **[Gradient](./gradient)** | Apply linear and radial gradient color fills | Modern visual polish |
| **[Chart Appearance](./chart-appearance)** | Configure titles, margins, background, and themes | Complete visual control |

## User experience & interaction

The Blazor Charts provides a comprehensive, interactive user experience with extensive customization options, flexible interaction modes, and accessibility standards compliance:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Zooming](./zooming#enable-zooming)** | Zoom by pinch, mouse wheel, selection, or toolbar | Precise data inspection |
| **[Crosshair and Trackball](./cross-hair-and-track-ball)** | Track exact values along the axes | Value inspection without clutter |
| **[Selection](./selection)** | Select points, series, or clusters for user actions | Interactive point-level workflows |
| **[Data Editing](./data-editing)** | Drag data points to update underlying values | Interactive what-if scenarios |
| **[Data Sorting](./chart-sorting)** | Sort data points by value or label | Ordered presentation |
| **[Adaptive Layout](./adaptive-layout)** | Automatically arrange elements for any size | Optimal display across devices |

## Advanced analytics

The Blazor Charts includes sophisticated capabilities designed for complex financial and analytical scenarios:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Technical Indicators](./technical-indicators)** | Overlay indicators such as Bollinger Bands, RSI, MACD, and SMA on the chart | Informed trading analysis |
| **[Trendlines](./trend-lines)** | Project linear, exponential, and other trend lines onto series | Forecast direction analysis |

## Print & export

The Blazor Charts provides comprehensive output capabilities for reporting and sharing chart visuals:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Print](./chart-print#print)** | Print the chart with page setup options | On-demand physical output |
| **[Export](./chart-print#export)** | Export the chart to PDF, PNG, JPEG, and SVG | Professional document integration |
| **[Exporting event customization](./chart-print#customizing-the-exported-chart-using-exporting-event)** | Customize the exported chart using the Exporting event | Branded export output |

## Globalization & accessibility

The Blazor Charts is fully accessible and compliant with Web Content Accessibility Guidelines (WCAG) standards:

- **[Globalization](./internationalization#globalization)** — Culture-aware number and date formatting
- **[Localization](./localization)** — Translate the chart UI into different languages
- **[WAI-ARIA attributes](./accessibility#wai-aria-attributes)** — Accessible roles and attributes for the chart UI
- **[Keyboard navigation](./accessibility#keyboard-navigation)** — Complete chart operation via keyboard
- **[Ensuring accessibility](./accessibility#ensuring-accessibility)** — Validation guidance for accessible charts
- **[Advanced Accessibility Configuration](./advanced-accessibility-configuration)** — Deeper accessibility customization options

## System requirements

The Blazor Charts works with:

- **Blazor Version**: .NET 8.0 or higher
- **Hosting Models**: Blazor Server, Blazor WebAssembly, Blazor Web App
- **Browsers**: Chrome, Firefox, Safari, Edge (latest versions)
- **Mobile**: iOS Safari, Android Chrome

## Quick links

**Getting Started:**
- [Blazor Web App Guide](./getting-started-with-web-app)
- [Blazor WebAssembly Guide](./getting-started-wasm)
- [Blazor Server App Guide](./getting-started)
- [Blazor Hybrid MAUI App Guide](./getting-started-with-maui-app)

**Popular Features:**
- [Chart Types](./chart-types/line) — 50+ chart types for any scenario
- [Data Labels](./data-labels) — Value display with templates
- [Legend](./legend) — Series explanation and interactivity
- [Tooltip](./tool-tip) — Rich point information on hover
- [Zooming](./zooming) — Interactive data inspection
- [Print and Export](./chart-print) — PDF, image, and print output

**Resources:**
- [Live Chart Demos](https://blazor.syncfusion.com/demos/chart/overview?theme=fluent2)
- [Blazor Charts Blog Posts](https://www.syncfusion.com/blogs/category/blazor)

## Support & Resources

- **Questions?** Visit the [Syncfusion Support Portal](https://www.syncfusion.com/support)
- **Code Examples?** Browse [Charts Demos](https://www.syncfusion.com/blazor-components/blazor-charts) and samples
- **API Details?** See [Charts API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html)
- **Community?** Join the [Syncfusion Community Forum](https://www.syncfusion.com/forums/blazor-components)
- **What's New?** Check [Release Notes](../Release-Notes)
