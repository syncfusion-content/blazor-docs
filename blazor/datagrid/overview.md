---
layout: post
title: Blazor DataGrid Component | Syncfusion®
description: Learn about Syncfusion Blazor DataGrid component featuring advanced data operations, seamless CRUD operations, virtualization, and extensive customization.
platform: Blazor
control: DataGrid
documentation: ug
---

# Overview of Syncfusion Blazor DataGrid Component

## What is Syncfusion Blazor DataGrid?

The Syncfusion Blazor DataGrid is an enterprise-grade data management component for building responsive, data-intensive applications. It combines high-performance data visualization, seamless CRUD operations, and extensive customization to handle everything from simple data tables to complex, multi-million row dashboards. Built for Blazor WebAssembly and Server, it enables developers to create professional data management interfaces with minimal code.

## Quick Start

Quick setup guides for installing and configuring the Blazor DataGrid in Blazor applications.

- [Getting Started with Blazor Web App](./getting-started-with-web-app.md) -  Step-by-step guide for integrating the DataGrid into a Blazor Web App project with both interactive server and WebAssembly rendering scenarios.
- [Getting Started with Blazor Web Assembly App](./getting-started.md) - Complete instructions for Blazor WebAssembly projects, including package installation, namespace registration, and initial data binding setup.

Both guides include:
- NuGet package installation steps
- Required namespace imports
- Basic DataGrid configuration
- Sample data binding examples
- Running and testing your first DataGrid

## Blazor Grid Video Tutorial

A step-by-step video walkthrough demonstrating the Syncfusion Blazor DataGrid features, setup process, and common implementation scenarios.

{% youtube
"youtube:https://www.youtube.com/watch?v=hjPGxApA5W8" %}

## Data Connectivity

The Blazor DataGrid provides comprehensive data binding and connectivity options to integrate data from various sources into its interface, enabling dynamic and interactive Grid views. It supports multiple data binding approaches including RESTful JSON data services through [`SfDataManager`](https://blazor.syncfusion.com/documentation/data/getting-started-with-web-app) and IEnumerable binding through the DataSource property, which can be assigned to a `SfDataManager` instance or list of business objects. Seamless integration with popular databases, ORMs, and cloud services enables connecting to virtually any data source and building flexible, scalable applications.

- [In-Memory Data](./data-binding/local-data) - Bind grids to local collections and lists for fast data access without external dependencies. Ideal for small to medium datasets and rapid prototyping.
- [Data Binding from Remote Sources](./data-binding/remote-data) - Connect to web services, REST APIs, and remote endpoints with automatic request handling and response parsing. Perfect for scalable applications with large or frequently updated datasets.
- [Multiple Data Source Adaptors](./connecting-to-adaptors/url-adaptor) -  Supports connecting grids to various data source types through specialized adaptor interfaces, enabling flexible integration with different backend services and data formats.
- **ORM integration** - Seamless integration with popular Object-Relational Mapping frameworks eliminates custom data mapping code and enables LINQ-based queries.
   - [Entity Framework](./connecting-to-orm/entityframework) - Direct integration with EF Core for simplified database model binding.
   - [Dapper](./connecting-to-orm/dapper) - Lightweight ORM support for direct SQL control with minimal overhead.
- **Backend integrations** - Enterprise-grade integrations for live data synchronization and advanced operations.
   - [SignalR](./connecting-to-backends/signalr) - Real-time data updates across multiple users and browser instances.
   - [ElasticSearch](./connecting-to-backends/elasticsearch) - Full-text search and powerful aggregation capabilities for large-scale datasets.

### Supported Data Sources

**Relational Databases**
- [Microsoft SQL Server](./connecting-to-database/microsoft-sql-server) -  Connects grids to SQL Server databases using standard ADO.NET connections and Entity Framework, supporting full CRUD operations and server-side data processing.
- [MySQL Server](./connecting-to-database/mysql-server) - Integrates grids with MySQL databases through connection strings and ORM frameworks, enabling cross-platform database connectivity.
- [SQLite Server](./connecting-to-database/sqlite-server) - Connects grids to SQLite embedded databases, ideal for local storage, mobile applications, and lightweight scenarios requiring no server infrastructure.
- [PostgreSQL Server](./connecting-to-database/postgresql-server) - Integrates grids with PostgreSQL databases through native connectors, supporting advanced relational features and large-scale data management.
 
**NoSQL & Cloud**
- [MongoDB Server](./connecting-to-database/mongodb-server) - Connects grids to MongoDB collections for document-based storage, supporting flexible schemas and horizontal scalability for unstructured data.
- [Firebase](./connecting-to-database/firebase-firestore) - Integrates grids with Firebase Firestore for cloud-based real-time database synchronization, enabling mobile and web applications with automatic data persistence.
 
**Query Languages & Adaptors**
- [GraphQL Adaptor](./connecting-to-adaptors/graphql-adaptor) - Connects grids to GraphQL APIs for flexible data queries, enabling clients to request only required fields and optimize network payload.
- [Web API Adaptor](./connecting-to-adaptors/web-api-adaptor) - Connects grids to ASP.NET Web API endpoints using HTTP requests, supporting RESTful service integration and custom business logic layer.
- [OData V4 Adaptor](./connecting-to-adaptors/odatav4-adaptor) - Integrates grids with OData V4 services for standardized query syntax, enabling filter, sort, and paging operations at the service level.
- [URL Adaptor](./connecting-to-adaptors/url-adaptor) - Connects grids directly to HTTP endpoints returning JSON data, supporting simple URL-based data loading from any public or internal web service.
- [Custom Adaptor](./connecting-to-adaptors/custom-adaptor) - Allows defining custom data adapters for specific backend implementations, enabling complete control over data fetching, filtering, and formatting logic.

### Data Operations

The Blazor DataGrid supports all fundamental data operations:

- [Sorting](./sorting) - Arranges data in ascending or descending order based on specified columns, enhancing data analysis and simplifying the identification of trends and patterns.
- [Filtering](./filtering) - Displays only relevant records based on specified criteria, streamlining data visibility and reducing the time required to locate specific information.
   - [Filter Bar](./filter-bar) - Provides inline text input fields in column headers for quick and intuitive filtering without opening additional dialogs.
   - [Filter Menu](./filter-menu) - Offers advanced filtering options through a dedicated menu interface, allowing complex filter conditions and multiple criteria combinations.
   - [Excel Like Filter](./excel-like-filter) - Delivers a familiar filtering experience similar to Microsoft Excel, displaying checkboxes for values and enabling rapid multi-select filtering operations.
- [Searching](./searching) - Enables rapid location of records by searching across all or specified columns, supporting partial matches and text-based queries for faster data discovery.
- [Grouping](./grouping) - Organizes data into logical categories based on specified column values, facilitating better data comprehension and enabling hierarchical data analysis.
- [Aggregates](./aggregates) - Calculates summary values such as sum, average, minimum, and maximum across selected data, providing quick insights without manual calculations.
   - [Footer Aggregate](./footer-aggregate) - Displays calculated summary values in the grid footer, presenting overall statistics for all visible records.
   - [Group Caption Aggregate](./group-and-caption-aggregate) - Shows calculated summary values within group headers, providing aggregated data for each grouped category.
   - [Custom Aggregate](./custom-aggregate) - Allows definition of custom calculation logic beyond standard functions, enabling specialized data summarization requirements.
   - [Reactive Aggregate](./reactive-aggregate) - Automatically recalculates and updates summary values in real-time when data changes, maintaining current aggregate information without manual refresh.

## Editing & CRUD

The Blazor DataGrid provides powerful options for dynamically inserting, deleting, and updating records, enabling seamless CRUD (Create, Read, Update, and Delete) operations directly within the Grid. To enable editing functionality, configure the `AllowEditing`, `AllowAdding`, and `AllowDeleting` properties within **GridEditSettings** to **true**, and set the primary key column using `Columns.IsPrimaryKey` to identify records uniquely.

- [Editing](./editing) - Provides multiple editing modes and approaches to modify grid records, supporting inline cell editing, dialog-based forms, batch operations, and custom templates to accommodate different data entry workflows.
  - [Inline Editing](./in-line-editing) - Enables direct editing of cell content within the grid without opening separate forms or dialogs, allowing users to modify data efficiently within the same view.
  - [Dialog Editing](./dialog-editing) - Opens a dedicated dialog window for editing record details, providing a structured form interface with validation and all fields visible at once.
  - [Batch Editing](./batch-editing) - Allows editing multiple records simultaneously within the grid, with changes batched together and submitted in a single operation for improved efficiency.
  - [Template Editing](./template-editing) - Provides custom HTML templates for editing operations, enabling flexible form layouts and specialized input controls tailored to specific data requirements.
- [Built-in validation with Data Annotations](./column-validation#data-annotation) - Enforces validation rules using .NET data annotation attributes on model properties, automatically displaying validation error messages during edit operations.

## Columns & Layout

The Blazor DataGrid offers rich column customization capabilities that enhance data presentation and user interaction. Columns can be formatted, resized, reordered, and frozen to provide flexible layouts that adapt to various data viewing needs and responsive design requirements.

- [Column Formatting](./columns.md) - Applies predefined or custom formatting patterns to column data, displaying values as currency, dates, percentages, or custom text formats while preserving underlying data types.
- [Column Resizing](./column-resizing.md) - Allows manual adjustment of column widths by dragging column borders, supporting auto-fit to content, width constraints, and responsive sizing across different screen sizes.
- [Column Reordering](./column-reorder.md) - Enables reordering columns through drag-and-drop column headers, customizing display sequence according to preferences without modifying underlying data structure. 
- [Frozen Columns](./frozen-column) - Keeps specified columns visible and fixed while scrolling horizontally through other columns, ensuring key information remains accessible during navigation.
- [Column Spanning](./column-spanning) - Allows cells to extend across multiple columns, creating merged column areas for displaying grouped or summary information within the grid.
- [Column Menu](./column-menu) (visibility, filtering, sorting, grouping, autofit) - Provides a dropdown menu for each column header with options to control visibility, apply filtering, enable sorting, configure grouping, and auto-fit column widths.
- [Column chooser](./column-chooser) - Displays a dialog allowing users to show or hide columns dynamically, managing grid display without modifying underlying data or structure.
- [Adaptive responsive layout](./adaptive-layout) - Automatically adjusts column widths, visibility, and layout based on available screen space, ensuring optimal display across devices from mobile to desktop.

## Performance & Scale

The Blazor DataGrid is designed for exceptional performance and scalability, handling large datasets efficiently without compromising user experience. Advanced virtualization techniques, lazy-loading capabilities, and WebAssembly optimizations ensure smooth interactions even with thousands of rows and complex operations.

- [Paging](./paging) - Divides large datasets into manageable pages, enabling efficient navigation and reducing initial load time while maintaining optimal application performance.
- [Row Virtualization](./virtual-scrolling#row-virtualization) - Renders only visible rows in the viewport, maintaining smooth scrolling with large set of records.
- [Column Virtualization](./virtual-scrolling#column-virtualization) - Renders only visible columns in the viewport, optimizing performance when grids contain many columns by loading columns dynamically during horizontal scrolling.
- [Lazy-load Grouping](./lazy-load-grouping) - Loads grouped data on-demand to reduce initial memory usage.
- [Infinite Scrolling](./infinite-scrolling) - Continuously loads additional records as users scroll towards the end of the grid, providing seamless navigation through unlimited datasets without pagination.
- [Overscan support for smooth scrolling](./virtual-scrolling#render-buffered-data-using-overscan-count) - Pre-renders additional rows beyond the visible viewport, ensuring smooth scrolling transitions and eliminating lag during rapid scrolling interactions.
- [Optimized performance for WebAssembly](./webassembly-performance) -  Provides performance guidelines for using the Blazor DataGrid efficiently in Blazor WebAssembly applications.

## User Experience

The Blazor DataGrid delivers a comprehensive user experience with extensive customization options and accessibility features. Rich templating support, flexible selection modes, intuitive interactions, and full keyboard navigation make the grid accessible to all users while maintaining high levels of personalization.

- Extensive templating
   - [Header Template](./column-headers#header-template) - Customizes column header content with HTML markup, allowing icons, tooltips, and complex formatting beyond standard text headers.
   - [Column Template](./column-template) - Replaces default cell rendering with custom HTML templates, enabling rich formatting, conditional styling, and embedded components within cells.
   - [Row Template](./row-template) - Replaces entire row rendering with custom templates, providing complete control over row appearance, layout, and interactive elements.
   - [Edit Template](./template-editing) - Defines custom form templates for edit operations, enabling specialized input controls, validation messages, and structured data entry layouts.
   - [Detail Template](./detail-template) - Creates expandable row sections displaying additional record information, enabling hierarchical data views and drill-down functionality.
- [Selection](./selection) - Provides flexible selection modes for highlighting rows and cells within the grid, supporting various selection approaches including click-based selection, checkbox columns, and cell ranges to accommodate different interaction patterns.
   - [Row Selection](./row-selection) - Enables highlighting and selection of entire rows through clicks, supporting single or multiple row selection modes.
   - [Checkbox Selection](./checkbox-selection) - Provides checkbox columns for selecting rows, with options for selecting all rows at once and visual indicators for selected state.
   - [Cell Selection](./cell-selection) - Allows selection of individual cells or cell ranges, supporting copy-paste operations and cell-level interaction patterns.
   - [Persist Selection](./selection#persist-selection) - Retains row or cell selections across data operations such as sorting, filtering, and paging, maintaining user context during interactions.
- [Row Drag and Drop](./row-drag-and-drop) - Enables reordering rows by dragging and dropping, allowing users to customize row sequences and rearrange data visually.
- [Context Menu](./context-menu) - Displays right-click menus with row or cell operations, providing quick access to common actions without toolbar navigation.
- [Customizable toolbar](./custom-toolbar) - Allows adding, removing, or repositioning toolbar buttons and controls, enabling personalized action layouts for common operations.
- Loading indicators
- [Column Reordering](./column-reorder) - Permits users to reorder columns by dragging column headers, customizing column arrangement according to workflow preferences.
- [Accessibility](./accessibility) (WCAG compliant) -  Implements Web Content Accessibility Guidelines standards, ensuring full keyboard navigation, screen reader support, and semantic HTML structure.
- [Keyboard Interaction](./accessibility#keyboard-interaction) -  Enables complete grid operation through keyboard shortcuts, supporting Tab navigation, arrow keys, Enter for actions, and screen reader compatibility.

## Export & Reporting

The Blazor DataGrid supports multiple export formats and reporting capabilities, enabling users to extract and share grid data in various document formats. Excel and PDF export functionality with customizable templates provides flexible options for generating professional reports and data analysis.

- [Excel Export](./excel-exporting) -  Exports grid data to Microsoft Excel format with customizable templates, enabling spreadsheet analysis, formatting, and sharing of grid information.
- [PDF Export](./pdf-export) -  Exports grid data to PDF documents with configurable layouts and styling, generating portable formatted reports suitable for distribution and archiving.
- [Print](./print) -  Generates printer-ready output of grid data with customizable print settings, page orientation, and styling options for document output.

## Advanced Features

The Blazor DataGrid includes advanced capabilities designed for complex data scenarios and enterprise-level applications. From sophisticated state management and hierarchical data relationships to AI-driven interactions and custom formatting, these features enable developers to build powerful, feature-rich data management solutions.

- [State management](./state-management) -  Saves and loads grid configuration settings including column order, visibility, sorting state, and filter preferences, restoring user customizations across sessions.
- [Hierarchical grids](./detail-template#creating-custom-componenthierarchical-datagrid) -  Displays master-detail relationships within the grid structure, enabling expandable rows that reveal related child data and nested grids.
- [Row spanning](./row-spanning) -  Extends row cells vertically across multiple rows, creating visual groupings and combining related records within a unified row structure.
- [Detail Templates](./detail-template) -  Creates expandable row sections displaying additional record information, enabling hierarchical data views and drill-down functionality.
- [Foreign key Columns](./foreignkey-column) -  Displays related data from external tables or collections within columns, automatically resolving and formatting foreign key references for readability.
- [Global and local formatting](./global-local) -  Applies consistent number, date, and text formatting globally across the grid or configures formatting specific to individual columns and cells.


