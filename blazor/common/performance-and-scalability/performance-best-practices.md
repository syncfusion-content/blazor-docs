---
layout: post
title: Blazor – Performance Best Practices | Syncfusion
description: Learn practical, validated performance best practices for Syncfusion Blazor components. See how DataGrid and Charts handle large data, with recommended configurations, runnable snippets, and visual guides sourced from official Syncfusion guidance.
platform: Blazor
component: Common
documentation: ug
---

# Performance Best Practices

This guide explains how to build fast and responsive Syncfusion Blazor applications. It focuses on handling large datasets, reducing browser work, and using the right features in DataGrid, Charts, and other controls. The goal is to provide clear, practical instructions you can follow immediately.

![Virtualization overview](../../images/performance/sf-virtualization-overview.png "Virtualization trims the DOM by rendering only the visible window.")

## Overview

This document focuses on keeping UI interactions smooth while working with large data in common Syncfusion Blazor components (DataGrid, Charts, lists). It shows:
- When to use paging vs virtualization.
- How to offload work to the server (SfDataManager / API queries).
- How to reduce DOM and render-tree pressure (lightweight templates, canvas rendering).
- How to measure and fix performance regressions.

Use the examples to validate that virtualization, sizing hints, and server-driven operations are correctly applied.

## Key Principles for Better Performance

1. Reduce what the browser needs to render
   - Render only the items the user can see (virtualization or paging).
   - Bind only the fields you actually need.
   - Delay loading heavy content until the user interacts with it.

2. Move heavy work to the server
   - Perform sorting, filtering, grouping, and paging on the server.
   - Return only the required fields.
   - Use APIs designed for large data (OData, REST with skip and take).

3. Keep your components lightweight
   - Avoid complex row or cell templates.
   - Avoid deep component nesting.
   - Prefer built‑in column types and renderers.

4. Provide layout hints
   - Set explicit Height, RowHeight, and ItemSize values.
   - Set column widths so that virtualization knows the correct visible range.

5. Measure and improve continuously
   - Use browser DevTools and Blazor diagnostics.
   - Test with real production data sizes.

## Blazor Application Level Recommendations

- Prefer Blazor Server when running on devices with limited memory or CPU.
- Call StateHasChanged only where needed. Avoid calling it inside loops.
- Use <Virtualize> for simple lists and enable virtualization in SfGrid.
- Avoid recreating large collections repeatedly. Reuse references when possible.
- Split large UI areas into smaller components to reduce unnecessary rerendering.

## Data handling strategies

Replace broad cross-cutting guidance with concrete data strategies developers can apply.

**Server-driven queries**
  - Use skip/take (or $skip/$top) and return { items, total } so virtualized components size scrollbars without full payloads.
  - Example REST: GET /orders?skip=200&take=50 -> { items:[...], total:83000 }
  - Example OData: /Orders?$skip=200&$top=50&$count=true

**Shape the Payload**
  - Send only the fields needed for the view.
  - Load heavy nested details only when the row or card is expanded.

**Remote Virtual Scrolling**
  - Provide ItemsCount from the server.
  - Return small data slices based on requested ranges.
  - Keep only a small cache window on the client.

**Caching**
  - Cache repeated queries with short expiry times.
  - Clear the cache after an update or edit.

**Aggregation & pre-aggregation**
  - Precompute summaries for charts and grid footers.
  - Fetch detailed data only when the user requests it.

**Throttle / debounce**
  - Debounce typing in filter or search boxes.
  - Throttle scroll events that trigger network calls.

**Payload compression & trimming**
  - Enable GZIP or Brotli on the server.
  - Avoid sending large unnecessary string fields.



## Syncfusion DataGrid (SfGrid) Best Practices

SfGrid includes many performance features. Apply these recommendations and validate against the Syncfusion performance guidance: https://blazor.syncfusion.com/documentation/datagrid/performance

### Virtualization types
- Row virtualization: only visible rows are rendered.
- Column virtualization: only visible columns are rendered (useful for wide tables).
- Both require explicit sizing: Height, RowHeight, and column Widths.

### Remote operations & SfDataManager
- Use SfDataManager to apply server sorting/filtering/grouping/paging to avoid client-side work.
- When using OData or REST adaptors, ensure responses provide the total record count.
- For large datasets, prefer server group/aggregate APIs instead of client grouping.

### Editing & batch operations
- Batch edits reduce UI churn. Send grouped updates to the server instead of per-cell saves.
- For inline editing in virtualized grids, persist edits in a lightweight client cache to avoid re-fetching pages unnecessarily.

### Column/row templates and performance
- Avoid heavy templates per cell. If you must use templates:
  - Keep them minimal (text + small icon).
  - Lazy-load images/components when visible.
  - Use RenderMode.ServerPrerendered or static HTML where possible.

### Column resizing, sorting and reflow
- Predefine column widths to avoid relayout during column operations.
- Avoid reflows by using CSS transforms for visual changes; avoid layout-affecting styles on many cells.

### Server query examples
- REST endpoint pattern
````json
{
  "page": 5,
  "pageSize": 50,
  "sort": [{ "field": "OrderDate", "dir": "desc" }],
  "filter": [{ "field": "CustomerID", "operator": "contains", "value": "ALFKI" }]
}

- Minimal response
{
  "items": [ { "OrderID": 1, "CustomerID":"ALFKI", "OrderDate":"2024-01-01" } ],
  "total": 12500
}

````

### Runnable example: Virtualized grid with remote operations

````razor
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" AllowPaging="true" Height="520px" RowHeight="36">
    <GridVirtualizationSettings EnableRowVirtualization="true"
                                EnableColumnVirtualization="true"
                                ItemsCount="@TotalRecords">
    </GridVirtualizationSettings>

    <GridPageSettings TValue="int" PageSize="50" PageSizes="true"></GridPageSettings>

    <SfDataManager Url="https://sampleapis.syncfusion.com/odata/services/Northwind/Northwind.svc/Orders"
                   Adaptor="Adaptors.ODataAdaptor">
    </SfDataManager>

    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="ID" TextAlign="TextAlign.Center" Width="90"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) Format="C2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) Type="ColumnType.Date" Format="d" Width="140"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private const int TotalRecords = 830; // The service reports the total count.
    public class Order
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public decimal Freight { get; set; }
        public DateTime OrderDate { get; set; }
    }
}

````

## Charts (SfChart)

Large charts require different strategies than grids. Focus on reducing per-point work and limiting DOM nodes.

### Rendering options

- Canvas rendering (EnableCanvasRendering="true"): best for tens of thousands of points. Renders to a bitmap, fewer DOM nodes.
- SVG rendering: better for interactivity per-element but expensive with many points.

### Series & rendering choices

- Use FastLine/FastStepLine for dense time-series.
- Disable markers/data labels (Marker.Visible=false, DataLabel.Visible=false).
- Set AnimationDuration="0" for initial render of big series.

### Data reduction techniques

- Downsample (decimate) data on the client or server before binding.
- Aggregate into buckets (min/max/avg) per pixel or interval for overview charts.
- Load high-resolution points only when the user zooms into a window.

### Interaction & tooltip optimizations

- Use lightweight tooltips (text only), avoid heavy per-point HTML templates.
- Use deferred zooming and selection to reduce frequent re-renders.

### Example: server-assisted viewport fetching

- Client requests data for visible time window: GET /trend?from=2024-01-01&to=2024-01-31
- Server returns points aggregated to ~1 point per pixel for the requested width.
- Runnable example: FastLine tuned for large datasets

### Runnable example: FastLine chart tuned for large datasets

```
@using Syncfusion.Blazor.Charts

<SfChart EnableCanvasRendering="true" Title="Throughput trend">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"
                       EdgeLabelPlacement="EdgeLabelPlacement.Shift"
                       EnableAutoIntervalOnZooming="true">
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis LabelFormat="n0"></ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@_trend"
                     Type="ChartSeriesType.FastLine"
                     XName="Timestamp"
                     YName="Throughput"
                     AnimationDuration="0"
                     Marker="new ChartMarkerSettings { Visible = false }"
                     DataLabel="new ChartDataLabelSettings { Visible = false }">
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartZoomSettings EnableSelectionZooming="true"
                       EnableDeferredZooming="true">
    </ChartZoomSettings>
</SfChart>

@code {
    private readonly List<TrendPoint> _trend = Enumerable.Range(0, 10000)
        .Select(i => new TrendPoint
        {
            Timestamp = DateTime.UtcNow.AddMinutes(i),
            Throughput = 3000 + (int)(20 * Math.Sin(i / 5.0))
        }).ToList();

    private class TrendPoint
    {
        public DateTime Timestamp { get; set; }
        public int Throughput { get; set; }
    }
}

```

### Lists and templates

- Use <Virtualize> and supply ItemSize.
- Lazy-load heavy content (images/components) when items become visible.
- Reuse component types for repeated items.

### Measuring and diagnosing performance

- Browser devtools: CPU profiler, timeline, paint, memory.
- Blazor diagnostics: render/JS interop timings and allocation hotspots.
- Test with production-sized datasets and record frame times.

### Additional actionable patterns

- Cache API results with sensible TTLs.
- Batch UI updates and edits to reduce rebinds.
- Offload heavy computation to server/background services.
- Prefer CSS transforms/opacities for animations.