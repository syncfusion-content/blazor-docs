---
layout: post
title: Blazor TreeGrid Overview and Features | Syncfusion
description: Learn how to use Blazor TreeGrid for hierarchical data display, tree data binding, CRUD operations, sorting, filtering, paging, and virtualization.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Overview in Blazor TreeGrid

## Introduction to Syncfusion Blazor TreeGrid

The [Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) is a powerful and feature-rich UI component designed for displaying and manipulating hierarchical (tree-structured) data in a tabular format with high performance and flexibility. It offers a comprehensive set of enterprise-grade capabilities, including self-referential and hierarchical data binding, advanced data operations, and extensive row and column customization options. Built for scalability, it enables developers to create responsive, data-intensive applications for parent-child data scenarios such as organizational charts, task trees, and file-system views.

## Common use cases

The Blazor TreeGrid is ideal for a wide range of business scenarios:

| Use Case | Description | Key Features |
|----------|-------------|--------------|
| **Project & Task Management** | Display project breakdown structures with nested tasks and subtasks | Tree Data Binding, Editing, Row Drag and Drop |
| **Organizational Hierarchy** | Render reporting structures with parent-child employee relationships | Self-Referential Data, Selection, Export |
| **File System Explorer** | Navigate folders and files as an expandable tree structure | Hierarchical Data, Virtualization, Context Menu |
| **Financial & Cost Planning** | Build work breakdown and cost-allocation structures with roll-ups | Aggregates, Batch Editing, Export |
| **Manufacturing BOM** | Display multi-level bill-of-material structures with quantity roll-ups | Hierarchical Data, Aggregates, Column Templates |
| **Analytics Dashboards** | Visualize hierarchical KPIs with drill-down exploration | Filtering, Sorting, State Management |

## Data Connectivity

The Blazor TreeGrid enables multiple data binding approaches for rendering parent-child relationships, offering flexibility in choosing the right strategy for different application architectures. The TreeGrid can work with in-memory collections for self-referential or hierarchical records, or connect to remote services for scalable applications.

**Data Binding Approaches**

- **[Self-Referential Data (Flat Data)](./data-binding)** — Bind grids to local record lists where each row references its parent through `IdMapping` and `ParentIdMapping` fields. Ideal for flat database tables with hierarchical semantics.

- **[Hierarchical Data](./data-binding)** — Bind nested object collections where child records are contained within parent objects. Perfect for JSON documents with tree structures.

- **Remote Data Sources** — Connect to **web services, REST APIs**, and remote endpoints with automatic request handling and response parsing.
  - [Remote Data Binding](./data-binding) — REST service integration through `SfDataManager` and adaptors
  - [GraphQL Adaptor](./graphql) — Query modern APIs with optimized payloads
  - [Custom Binding](./custom-binding) — Handle data operations manually when services require custom processing

**Data Connectors**

| Feature | Key Benefit | Best For |
|---------|---------------|----------|
| **[SfDataManager with adaptors](./data-binding)** | Automatic remote operation handling | Web services, REST endpoints |
| **[Custom Binding](./custom-binding)** | Full manual control over data operations | Specialized backends, performance-tuned services |
| **[Entity Framework](./editing/entity-frame-work)** | ORM-based editing with child record handling | ASP.NET backend, relational databases |

> To learn about the adaptors supported by the TreeGrid and all remote data binding scenarios, refer to [Data Binding](./data-binding).

## Data Operations

The Blazor TreeGrid provides comprehensive data manipulation capabilities that enable users to analyze, organize, and understand their hierarchical data efficiently:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Sorting](./sorting)** | Arrange records in ascending or descending order while preserving the parent-child structure | Quick sort by clicking column headers |
| **[Filtering](./filter)** | Apply multi-level conditions across tree data with hierarchy-aware modes | [Filter hierarchy modes](./filter#filter-hierarchy-modes) preserve or filter entire tree branches |
| **[Filter Bar](./filtering/filter-bar)** | Quick filtering with inline text inputs in column headers | Immediate results without dialogs |
| **[Filter Menu](./filtering/filter-menu)** | Advanced filtering with complex conditions and multiple criteria | Powerful expression-based filtering |
| **[Excel-like Filter](./filtering/excel-like-filter)** | Familiar checkbox-based filtering interface from Excel | Multi-select from available values |
| **[Searching](./searching)** | Rapid text-based search across tree data with navigation | [Hierarchical Search](./searching) to locate records anywhere in the tree |
| **[Aggregates](./aggregate)** | Calculate summary values (sum, average, count) on tree data | [Footer aggregate](./aggregate#footer-aggregate) with built-in functions |
| **[Custom Sorting](./sorting#custom-sorting)** | Define custom sort logic beyond standard functions | Specialized business sort rules |

## Large-scale rendering performance

The Blazor TreeGrid is engineered for exceptional performance, enabling smooth operation with deep and wide hierarchical datasets. Advanced rendering techniques ensure responsive user interactions without performance degradation.

| Feature | Benefit | Use Case | Key Benefit |
|---------|---------|----------|--------------|
| **[Row Virtualization](./virtualization#row-virtualization)** | Render only visible rows; load/unload as users scroll | Large trees (10K+ rows) | Smooth scrolling |
| **[Column Virtualization](./virtualization#column-virtualization)** | Render only visible columns; optimize for many-column grids | Wide grids (50+ columns) | Efficient horizontal scrolling |
| **[Managing Records Count](./virtualization#managing-records-count)** | Control additional records loaded per block during virtualization | Deep tree structures | Controlled memory usage |
| **[Paging](./paging)** | Divide the tree data across pages with page options | Browsing large forests | Navigable dataset segments |

## Editing & CRUD Operations

The Blazor TreeGrid enables seamless Create, Read, Update, and Delete (CRUD) operations directly within the grid interface, with full support for adding child rows to any tree node. Data modification occurs inline with immediate visual feedback, improving productivity and reducing context switching.

**Editing Modes**

Multiple editing modes support different workflow scenarios:

| Mode | Description | Best For | Key Benefit |
|------|-------------|----------|-------------|
| **[Cell Editing](./editing/cell-editing)** | Edit cell content directly in the grid | Quick single-cell edits, power users | Direct editing without dialog overhead |
| **[Row Editing](./editing/row-editing)** | Edit an entire row at once | Comprehensive multi-field edits | All fields editable in one action |
| **[Dialog Editing](./editing/dialog-editing)** | Open a dedicated form dialog for editing | Comprehensive multi-field edits with validation | Organized form-based editing with validation |
| **[Batch Editing](./editing/batch-editing)** | Edit multiple records and submit together | Bulk operations, mass updates | Single submission of all changes |
| **[Template Editing](./editing/template-editing)** | Use custom Blazor templates for edit forms | Complex layouts, custom components inside edit dialogs | Flexible, custom-designed edit forms |
| **[Command Column Editing](./editing/command-column-editing)** | Edit, Delete, Save, Cancel buttons in dedicated column | Intuitive interface | One-click actions without keyboard interaction |

**Data Validation**

The Blazor TreeGrid includes built-in [validation with Data Annotations](./editing/column-validation) that enforces business rules using .NET attributes. Validation errors display inline with helpful messages, guiding users to correct data before submission.

**Excel-like interactions**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Clipboard](./clipboard)** | Copy TreeGrid cells and paste them into Excel or text editors | Seamless data transfer to spreadsheets |
| **[AutoFill](./auto-fill-like-excel)** | Drag fill handle to extend or clear values like Excel AutoFill | Spreadsheet-like productivity |

## Columns

The Blazor TreeGrid offers extensive column and layout customization options for creating professional data displays tailored to any device or workflow:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Column Formatting](./column#format)** | Apply predefined or custom formats (currency, dates, percentages, etc.) | Professional number and date display |
| **[Header Template](./column#header-template)** | Customize column headers with icons, tooltips, complex formatting | Professional header design |
| **[Column Resizing](./columns/column-resizing)** | Manually adjust column widths with auto-fit and responsive options | Optimal content visibility |
| **[Column Reordering](./columns/column-reorder)** | Drag column headers to reorder display sequence | User-preferred column arrangement |
| **[Column Spanning](./columns/column-spanning)** | Extend cells across multiple columns for merged display areas | Grouped or summary information |
| **[Column Menu](./columns/column-menu)** | Dropdown menu for visibility, filtering, sorting, autofit | Quick column management |
| **[Column Chooser](./columns/column-chooser)** | Dialog to dynamically show/hide columns | User-controlled visibility |
| **[Column Template](./columns/column-template)** | Custom cell rendering with custom components | Rich data visualization |
| **[Lock Columns](./column#lock-columns)** | Fix columns so they stay visible during horizontal scrolling | Always visible critical information |
| **[Responsive Columns](./column#responsive-columns)** | Hide columns at different resolutions | Optimal display across all devices |
| **[Checkbox Column](./column#checkbox-column)** | Display boolean values as checkboxes | Interactive yes/no selection |
| **[Complex data binding](./column#complex-data-binding)** | Bind nested object properties | Deep object structures |

## Rows

The Blazor TreeGrid provides extensive row-level capabilities that leverage the hierarchical structure of the data:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Row Drag and Drop](./rows/row-drag-and-drop)** | Reorder rows or move a subtree to different parents within the same TreeGrid or another TreeGrid | Reorganize tree structures interactively |
| **[Row Height](./rows/row-height)** | Set custom row height for TreeGrid | Precise layout control |
| **[Row Spanning](./rows/row-spanning)** | Extend cells vertically across multiple rows | Specialized layouts |
| **[Row Template](./rows/row-template)** | Complete row customization with Blazor templates | Unique row presentations |
| **[Detail Template](./rows/detail-template)** | Expandable row sections for additional information | Drill-down exploration |

## User experience & interaction

The Blazor TreeGrid provides a comprehensive, accessible user experience with extensive customization options, flexible interaction modes, and accessibility standards compliance. Every aspect of the TreeGrid interface supports customization to match application design systems and workflow requirements.

**Selection**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Row Selection](./selection)** | Single or multiple row selection modes | Flexible selection workflows |
| **[Cell Selection](./selection#cell-selection)** | Individual cell or range selection with copy-paste | Spreadsheet-like interaction |
| **[Checkbox Selection](./selection#checkbox-selection)** | Checkbox-based selection with select-all option | Bulk operation selection |
| **[Drag Selection](./selection#drag-selection)** | Drag to select a range of rows or cells | Mouse-friendly bulk selection |
| **[Toggle Selection](./selection#toggle-selection)** | Toggle multiple non-adjacent selections without Ctrl key | Touch-friendly multi-selection |

**User interaction**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Toolbar](./toolbar)** | Add customizable toolbars with built-in and custom items | Quick access to actions |
| **[Context Menu](./context-menu)** | Right-click access to TreeGrid actions | Desktop-feel productivity |
| **[Adaptive Layout](./adaptive-layout)** | Automatically adjust layout based on screen space | Optimal display on mobile devices |
| **[State Management](./state-management)** | Save/restore user preferences across sessions | Personalized user experience |

**Templating & Customization**

Templating & Customization allows developers to personalize the TreeGrid's headers, cells, rows, editing experience, and detail views with custom UI and behavior.

| Template Type | Purpose | Key Benefit |
|---------------|---------|--------------|
| **[Header Template](./column#header-template)** | Customize column headers with icons, tooltips, complex formatting | Professional header design |
| **[Column Template](./columns/column-template)** | Custom cell rendering with custom components | Rich data visualization |
| **[Row Template](./rows/row-template)** | Complete row customization for specialized layouts | Unique row presentations |
| **[Detail Template](./rows/detail-template)** | Expandable row sections for additional information | Hierarchical data display |
| **[Globalization](./globalization)** | Culture-aware formatting and right-to-left rendering | Global application support |

**Accessibility & Keyboard Navigation**

The Blazor TreeGrid is fully accessible and compliant with Web Content Accessibility Guidelines (WCAG) standards:

- **[WAI-ARIA](./accessibility#wai-aria)** — Accessible roles and attributes for TreeGrid UI
- **[Keyboard interaction](./accessibility#keyboard-interaction)** — Complete TreeGrid operations via keyboard
  - Tab/Shift+Tab — Navigate between cells
  - Arrow Keys — Move between rows and columns
  - Enter — Edit cells, confirm changes
  - Escape — Cancel editing
  - Ctrl+A — Select all rows
- **[Screen Reader Support](./accessibility)** — Full compatibility with assistive technologies
- **[Semantic HTML](./accessibility)** — Proper ARIA labels and semantic markup

## Export & Reporting

The Blazor TreeGrid provides comprehensive export and reporting capabilities, enabling users to extract, analyze, and distribute hierarchical grid data in professional document formats:

| Format | Key Benefit | Best For |
|--------|---------------|----------|
| **[Excel Export](./excel-export)** | Export to XLSX with tree structure preserved, including indent level | Data analysis, spreadsheet workflows |
| **[PDF Export](./exporting)** | Generate formatted PDF documents with custom layouts | Professional reports, archiving |
| **[Print](./print)** | Printer-ready output with page orientation control | Hard copy reports, on-demand printing |

## Advanced features

The Blazor TreeGrid includes sophisticated capabilities designed for complex enterprise data scenarios. These advanced features enable developers to build powerful, scalable data management solutions that handle demanding business requirements.

| Feature | Purpose | Use Case | Key Benefit |
|---------|---------|----------|-------------|
| **[State Management](./state-management)** | Save/restore user preferences across sessions | Column order, visibility, sort states | Personalized user experience |
| **[Detail Templates](./rows/detail-template)** | Expandable row sections for additional information | Product details, historical data | Drill-down exploration |
| **[Global/Local Formatting](./globalization)** | Consistent or column-specific formatting | Currency, dates, numbers, text | Professional presentation |
| **[Events](./events)** | Event handlers for every user and API action in the TreeGrid | Custom workflows and integrations | Deep integration points |

**Enterprise Patterns**

For specific implementation patterns, refer to feature documentation:

- **Large Enterprises** — Use [State Management](./state-management) and [Row Drag and Drop](./rows/row-drag-and-drop) to reorganize large trees
- **Real-time Systems** — Implement [Custom Binding](./custom-binding) with live data streams
- **Bulk Data Transfer** — Combine [Clipboard](./clipboard) with [Batch Editing](./editing/batch-editing)

## System requirements

The Blazor TreeGrid works with:

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
- [Row Drag and Drop](./rows/row-drag-and-drop) — Reorganize tree structures interactively
- [Filtering & Searching](./filter) — Search and filter capabilities
- [Sorting](./sorting) — Data organization and analysis
- [Editing & CRUD](./editing/edit) — Create, read, update, delete operations
- [Export & Reporting](./excel-export) — Excel, PDF, and print functionality
- [Data Validation](./editing/column-validation) — Built-in and custom validation rules

## Support & Resources

- **Questions?** Visit the [Syncfusion Support Portal](https://www.syncfusion.com/support)
- **Code Examples?** Browse [TreeGrid Demos](https://www.syncfusion.com/blazor-components/blazor-tree-grid) and samples
- **API Details?** See [TreeGrid API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html)
- **Community?** Join the [Syncfusion Community Forum](https://www.syncfusion.com/forums/blazor-components)
- **What's New?** Check [Release Notes](../Release-Notes)
