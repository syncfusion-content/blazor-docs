---
layout: post
title: Blazor Maps Overview and Features | Syncfusion
description: Learn how to use Blazor Maps to visualize geographical data with shape and bubble layers, color mapping, markers, legends, zooming, and online map providers.
platform: Blazor
control: Maps
documentation: ug
---

# Overview in Blazor Maps

## Introduction to Syncfusion Blazor Maps

The [Blazor Maps]((https://www.syncfusion.com/blazor-components/blazor-maps)) is a powerful and feature-rich UI component designed for visualizing geographical data in an interactive and customizable map view. It offers a comprehensive set of enterprise-grade capabilities, including shape (geometry) rendering from GeoJSON, data-driven color mapping, bubbles, markers, and legends, along with seamless integration of online map providers. Built for scalability, it enables developers to create responsive, location-aware applications for business scenarios such as demographic analysis, sales dashboards, logistics tracking, and weather monitoring.

## Common use cases

The Blazor Maps is ideal for a wide range of business scenarios:

| Use Case | Description | Key Features |
|----------|-------------|--------------|
| **Demographic & Sales Analysis** | Visualize population, revenue, or performance figures per country or region | Color Mapping, Legend, Tooltip |
| **Election Results** | Display winning parties or voting percentages across constituencies | Color Mapping, Data Labels, Annotations |
| **Logistics & Fleet Tracking** | Show distribution routes, warehouses, and vehicle locations | Markers, Navigation Lines, Zooming |
| **Weather & Environment** | Render temperature, rainfall, or pollution levels as proportional bubbles | Bubble, Color Mapping, Legend |
| **Field Service & Branch Locator** | Help users find offices, stores, or service centers near them | Markers, Marker Clustering, Selection |
| **Travel & Tourism** | Highlight destinations, attractions, and planned itineraries | Markers, Navigation Lines, Annotations |

## Data sources & connectivity

The Blazor Maps enables multiple ways to load and bind geographical and business data, offering flexibility in choosing the right strategy for different application architectures. The Maps can render shapes from GeoJSON or shapefile data, bind business data to those shapes, or display online tile maps from popular providers.

**Shape Data**

- **[Populate Data](./populate-data)** — Load GeoJSON shape data and bind business data to shapes using `ShapeDataPath` and `ShapePropertyPath` for automatic matching.
- **[Geometry types](./populate-data#geometry-types)** — Render `Geometry` (polygon) and `LineString` (line) shapes in the same or separate layers.
- **[Fetching data from JSON file](./populate-data#fetching-data-from-json-file)** — Load map data from local or remote JSON files in Blazor Server and WebAssembly apps.
- **[Shapefile](./shapefile)** — Convert ESRI shapefiles to GeoJSON for rendering static geographic boundaries.

**Layer Types**

| Layer Type | Purpose | Key Benefit |
|------------|---------|-------------|
| **[Shape Layer](./layers)** | Render geographic boundaries from GeoJSON data | Data-driven thematic maps |
| **[Tile / Provider Layer](./providers/openstreetmap)** | Display online tile maps from map providers | Real-world street and satellite imagery |
| **[Bing Maps](./providers/bing-maps) / [Google Maps](./providers/google-maps) tiles** | Integrate commercial provider tiles | Familiar, detailed map imagery |
| **[Other Maps](./providers/other-maps)** | Load tile maps from other online providers such as TomTom and MapBox | Provider flexibility |

**Layer Organization**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Multilayer](./layers#multilayer)** | Render multiple geographic layers on top of each other | Subcontinent plus country-level views |
| **[Sublayer](./layers#sublayer)** | Layer a detailed shape inside a base shape layer | Drill-down visualization |
| **[Displaying different layer in the view](./layers#displaying-different-layer-in-the-view)** | Switch between layers on zoom level | Progressive disclosure of detail |
| **[Rendering custom shapes](./layers#rendering-custom-shapes)** | Render building, stadium, or indoor layouts as geometries | Floor plans and custom boundaries |

**Online Map Providers**

| Provider | Key Benefit | Best For |
|----------|--------------|----------|
| **[OpenStreetMap](./providers/openstreetmap)** | Free, community-maintained world map | General-purpose mapping |
| **[Google Maps](./providers/google-maps)** | High-quality street and satellite tiles | Consumer-facing applications |
| **[Azure Maps](./providers/azure-maps)** | Enterprise-grade geospatial services | Azure-based enterprise apps |
| **[Bing Maps](./providers/bing-maps)** | Reliable tile imagery with key-based access | Legacy and enterprise integrations |
| **[Other Maps](./providers/other-maps)** | Support for other tile providers | Specialized imagery requirements |

## Shape & data visualization

The Blazor Maps provides comprehensive data visualization capabilities that enable users to analyze, organize, and understand their geographical data efficiently:

**Color Mapping**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Range Color Mapping](./color-mapping#range-color-mapping)** | Color shapes by value ranges such as population density | Intuitive thematic gradients |
| **[Equal Color Mapping](./color-mapping#equal-color-mapping)** | Assign a unique color per equal value such as winner party | Categorical comparisons |
| **[Desaturation Color Mapping](./color-mapping#desaturation-color-mapping)** | Vary color intensity by value | Subtle value emphasis |
| **[Multiple colors for a single shape](./color-mapping#multiple-colors-for-a-single-shape)** | Split a shape among multiple colors | Coalition or split-level data |

**Data Elements**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Data Labels](./data-labels)** | Display shape names and values on the map | In-context information |
| **[Bubble](./bubble)** | Render proportional circles sized by underlying values | Comparative magnitude analysis |
| **[Legend](./legend)** | Explain shape, bubble, and marker color categories | Quick value decoding |
| **[Interactive Legend](./legend#interactive-mode)** | Toggle data ranges visibility by legend interaction | User-controlled filtering |

**Markers & Overlays**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Adding marker](./markers#adding-marker)** | Pin locations by latitude and longitude | Location identification |
| **[Adding marker template](./markers#adding-marker-template)** | Use custom Blazor templates for markers | Fully customizable point visuals |
| **[Multiple marker groups](./markers#multiple-marker-groups)** | Categorize markers into distinct groups | Layered location categories |
| **[Marker clustering](./markers#marker-clustering)** | Group nearby markers into clusters at lower zoom levels | Readable dense point data |
| **[Reposition markers using drag and drop](./markers#repositioning-the-marker-using-drag-and-drop)** | Drag markers to adjust positions | Interactive editing |
| **[Tooltip for marker](./markers#tooltip-for-marker)** | Show details on marker hover | On-demand information |
| **[Polygon](./polygon)** | Draw multi-point shapes such as service areas on the map | Custom region overlay |
| **[Navigation Lines](./navigation-line)** | Connect locations with straight or curved direction lines | Route visualization |
| **[Annotations](./annotations)** | Place custom HTML content at coordinates or pixel positions | Rich in-map content |

## Appearance & customization

The Blazor Maps offers extensive layout and styling options for creating professional, on-brand map views:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Setting the size for Maps](./customization#setting-the-size-for-maps)** | Control map width and height | Predictable layout integration |
| **[Maps title](./customization#maps-title)** | Add and style a descriptive map title | Contextual storytelling |
| **[Setting theme](./customization#setting-theme)** | Apply built-in themes such as Material or Fluent | Consistent app theming |
| **[Customizing the shapes](./customization#customizing-the-shapes)** | Style shape fill, border, and dash arrays | Editorial control over geometry |
| **[Setting color to the shapes from the data source](./customization#setting-color-to-the-shapes-from-the-data-source)** | Drive shape colors from bound data values | Data-driven styling |
| **[Projection type](./customization#projection-type)** | Switch between Mercator, Equirectangular, and other projections | Accurate geospatial representation |

## User experience & interaction

The Blazor Maps provides a comprehensive, interactive user experience with zooming, selection, highlighting, and tooltip capabilities that make geographical exploration intuitive:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Zooming](./user-interactions#zooming)** | Zoom by toolbar, pinch, mouse wheel, double-click, or selection | Precise region focus |
| **[Selection](./user-interactions#selection)** | Select shapes, markers, bubbles, or polygons | Region-level user actions |
| **[Highlight](./user-interactions#highlight)** | Emphasize shapes, markers, bubbles, or polygons on hover | Visual feedback |
| **[Tooltip](./user-interactions#tooltip)** | Show additional details on shape or bubble hover | On-demand information without clutter |

## Print & export

The Blazor Maps provides output capabilities for reporting and sharing analytical map views:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Print](./print-and-export#print)** | Print the map with page orientation options | On-demand physical output |
| **[Image Export](./print-and-export#image-export)** | Export the map as PNG, JPEG, or SVG images | Slide decks and documentation |
| **[PDF Export](./print-and-export#pdf-export)** | Export the map as a PDF document | Professional reporting |

## Advanced features

The Blazor Maps includes sophisticated capabilities designed for complex enterprise scenarios. These advanced features help you persist state, respond to interactions, and serve maps under strict security policies.

| Feature | Purpose | Use Case | Key Benefit |
|---------|---------|----------|-------------|
| **[State Persistence](./state-persistence)** | Save and restore the map state across sessions | Zoom, center, and selection retention | Personalized user experience |
| **[Globalization](./internationalization#globalization)** | Format data values using different cultures | Multi-region applications | Localized number and date display |
| **[Localization](./localization)** | Translate the UI into different languages | Global user bases | Native-language experience |
| **[Events](./maps-event)** | Handle rendering, interaction, and completion events | Custom workflows and integrations | Deep integration points |
| **[Methods](./maps-method)** | Programmatically zoom, pan, select, and export | Dynamic, code-driven control | Automation-friendly API |
| **[Content Security Policy](./content-security-policy)** | Configure CSP rules for tile and GeoJSON requests | Security-restricted environments | Compliant enterprise deployment |

**Accessibility**

The Blazor Maps is fully accessible and compliant with Web Content Accessibility Guidelines (WCAG) standards:

- **[WAI-ARIA attributes](./accessibility#wai-aria-attributes)** — Accessible roles and attributes for the Maps UI
- **[Screen reading in Maps](./accessibility#screen-reading-in-maps)** — Full compatibility with assistive technologies
- **[Keyboard Navigation](./accessibility#keyboard-navigation)** — Complete map operation via keyboard
  - Tab / Shift+Tab — Navigate between map areas
  - Arrow Keys — Drag/pan the map in four directions
  - Plus (+) and Minus (-) — Zoom in and zoom out
- **[Ensuring accessibility](./accessibility#ensuring-accessibility)** — Validation guidance for accessible maps

## System requirements

The Blazor Maps works with:

- **Blazor Version**: .NET 8.0 or higher
- **Hosting Models**: Blazor Server, Blazor WebAssembly, Blazor Web App
- **Browsers**: Chrome, Firefox, Safari, Edge (latest versions)
- **Mobile**: iOS Safari, Android Chrome

## Quick links

**Getting Started:**
- [Blazor Web App Guide](./getting-started-webapp)
- [Blazor WebAssembly Guide](./getting-started)
- [Blazor Server App Guide](./getting-started-with-server-app)
- [Blazor Hybrid MAUI App Guide](./getting-started-with-maui-app)

**Popular Features:**
- [Color Mapping](./color-mapping) — Thematic shape coloring by value
- [Bubble](./bubble) — Proportional symbol visualization
- [Markers](./markers) — Location visualization and clustering
- [Layers](./layers) — Multilayer and sublayer rendering
- [User Interactions](./user-interactions) — Zooming, selection, highlight, and tooltip
- [Print and Export](./print-and-export) — Print, image, and PDF output

## Support & Resources

- **Questions?** Visit the [Syncfusion Support Portal](https://www.syncfusion.com/support)
- **Code Examples?** Browse [Maps Demos](https://www.syncfusion.com/blazor-components/blazor-maps) and samples
- **API Details?** See [Maps API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html)
- **Community?** Join the [Syncfusion Community Forum](https://www.syncfusion.com/forums/blazor-components)
- **What's New?** Check [Release Notes](../Release-Notes)
