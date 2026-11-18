---
layout: post
title: Blazor Query Builder Overview and Features | Syncfusion
description: Learn how to use Blazor Query Builder to create and manage filters with rules and groups, templates, import-export and locked queries.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Blazor Query Builder Documentation Overview

## Introduction to Syncfusion Blazor Query Builder

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) is a powerful and feature-rich UI component designed for creating and editing filter conditions at runtime with high performance and flexibility. It offers a comprehensive set of enterprise-grade capabilities, including nested groups with AND/OR connectors, a rich set of operators through rule editing, value templates, and seamless import and export of queries across JSON, SQL, and MongoDB formats. Built for scalability, it enables developers to create responsive, data filtering experiences for reports, search interfaces, and dynamic query applications with ease.

## Common use cases

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) is ideal for a wide range of business scenarios:

| Use Case | Description | Key Features |
|----------|-------------|--------------|
| **Advanced Search Interfaces** | Let users build complex search conditions without writing code | Filtering, Operators, Templates |
| **Report Filtering** | Filter datasets for reports and dashboards at runtime | Filtering, Import and Export |
| **Rule Engine Configuration** | Build business rule editors for workflow conditions | Nested Groups, Clone Group/Rule |
| **Query Migration & Sharing** | Move queries between UI and database representations | Importing and Exporting |
| **Data Exploration Tools** | Explore and slice enterprise data interactively | Data Binding, Drag and Drop |
| **Restricted Rule Editing** | Prevent users from changing critical conditions | Lock Group/Rule |

## Data connectivity

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) enables multiple data binding approaches, offering flexibility in choosing the right strategy for different application architectures. The Query Builder can work with in-memory collections for defining columns, or connect to remote services so users can build conditions against real data.

**Data Binding Approaches**

- **[List Binding](./data-binding#list-binding)** - Bind the Query Builder to local collections to auto-generate columns and enable condition evaluation on the bound data.
- **[Remote Data](./data-binding#remote-data)** - Connect to **web services, REST APIs**, OData, and Web API endpoints for scalable applications.
- **[Complex Data Binding](./data-binding#complex-data-binding)** - Bind nested and complex object structures with mapped fields.

**Column Configuration**

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Auto generation](./columns-binding#auto-generation)** | Generate columns automatically from the bound data source | Rapid setup |
| **[Labels](./columns-binding#labels)** | Display friendly names for fields | Readable conditions |
| **[Operators](./columns-binding#operators)** | Control which operators are available per column | Tailored filtering logic |
| **[Step](./columns-binding#step)** | Set increment steps for numeric value editors | Precise numeric input |
| **[Format](./columns-binding#format)** | Apply formats to date and number columns | Consistent value display |
| **[Validations](./columns-binding#validations)** | Enforce required and range rules on values | Correct data entry |

## Rules & groups

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) provides comprehensive capabilities for composing conditions as rules and nested groups:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Filtering](./filtering)** | Apply built-in and value filtering to the bound data | Immediate result feedback |
| **[Separate Connector](./separate-connector)** | Render vertically stacked AND/OR connectors between rules | Distinct group connectors |
| **[Lock Group/Rule](./lock-group-rule)** | Disable editing of individual rules or entire groups while keeping them in evaluation | Protected critical conditions |
| **[Clone Group/Rule](./clone-group-rule)** | Duplicate existing rules or groups | Fast condition reuse |
| **[Drag and Drop](./drag-and-drop)** | Rearrange rules and groups by dragging | Visual query structuring |

## Templates

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) offers extensive customization options for tailoring the editing experience:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Value Template](./templates#value-template)** | Replace value editors with custom Blazor components | Custom value input |
| **[Column Template](./templates#column-template)** | Customize the field column rendering | Branded field selectors |
| **[Header Template](./templates#header-template)** | Add custom content to the group header | Rich group headers |

## Importing & exporting

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) provides comprehensive interoperability for moving queries between the UI and other formats:

| Feature | Purpose | Key Benefit |
|---------|---------|-------------|
| **[Importing from JSON Object](./import-export#importing-from-json-object)** | Load rules from JSON | Integration with saved filters |
| **[Importing from SQL Query](./import-export#importing-from-sql-query)** | Parse SQL WHERE clauses into rules | Database interop |
| **[Importing from MongoDB Query](./import-export#importing-from-mongodb-query)** | Parse MongoDB query documents into rules | NoSQL interop |
| **[Exporting to JSON Object](./import-export#exporting-to-json-object)** | Serialize the current rules to JSON | Persisted filters |
| **[Exporting to SQL Query](./import-export#exporting-to-sql-query)** | Produce SQL WHERE clauses from rules | Direct database use |
| **[Exporting to MongoDB Query](./import-export#exporting-to-mongodb-query)** | Produce MongoDB query documents from rules | NoSQL pipeline use |

## Globalization & accessibility

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) is fully accessible and compliant with Web Content Accessibility Guidelines (WCAG) standards:

- **[Localization](./localization)** - Translate the UI into different languages
- **[Right to Left](./how-to/right-to-left)** - RTL rendering for RTL languages
- **[WAI-ARIA attributes](./accessibility#wai-aria-attributes)** - Accessible roles and attributes for the Query Builder UI
- **[Keyboard interaction](./accessibility#keyboard-interaction)** - Complete component operation via keyboard
  - **Tab / Shift+Tab** - Move focus between fields, operators, values, and action buttons
- **[Ensuring accessibility](./accessibility#ensuring-accessibility)** - axe-core with Playwright validation guidance

## Advanced features

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) includes sophisticated capabilities designed for complex enterprise scenarios:

| Feature | Purpose | Use Case | Key Benefit |
|---------|---------|----------|-------------|
| **[Events](./events)** | Handle rule change, value change, and drag-and-drop events | Custom workflows and integrations | Deep integration points |
| **[Style and Appearance](./style-and-appearance)** | Customize background, containers, connectors, and buttons | Themed query builders | Complete visual control |
| **[Change Display Mode](./how-to/change-display-mode)** | Switch between horizontal and vertical layouts | Space-constrained layouts | Flexible orientation |
| **[Readonly](./how-to/read-only)** | Render a non-editable view of the conditions | Review and sharing scenarios | Safe display mode |
| **[Restrict the Groups](./how-to/restrict-group)** | Limit the number of nested groups | Controlled complexity | Guarded query structure |
| **[Show Not Operator](./how-to/enable-not)** | Enable the NOT condition between rules | Negated conditions | Advanced logic support |

## System requirements

The [Blazor Query Builder](https://www.syncfusion.com/blazor-components/blazor-query-builder) works with:

- **Blazor Version**: .NET 8.0 or higher
- **Hosting Models**: Blazor Server, Blazor WebAssembly, Blazor Web App
- **Browsers**: Chrome, Firefox, Safari, Edge (latest versions)
- **Mobile**: iOS Safari, Android Chrome

## Quick links

**Getting Started:**
- [Blazor Web App Guide](./getting-started-webapp)
- [Blazor Server App Guide](./getting-started-with-server-app)
- [Blazor WebAssembly Guide](./getting-started)

**Popular Features:**
- [Filtering](./filtering) - Apply conditions to bound data
- [Templates](./templates) - Custom value and column editors
- [Importing and Exporting](./import-export) - JSON, SQL, and MongoDB interoperability
- [Lock Group/Rule](./lock-group-rule) - Protect conditions from editing
- [Drag and Drop](./drag-and-drop) - Rearrange rules visually
- [Data Binding](./data-binding) - Local, remote, and complex data sources

## Support & Resources

- **Questions?** Visit the [Syncfusion Support Portal](https://www.syncfusion.com/support)
- **Code Examples?** Browse [Query Builder Demos](https://www.syncfusion.com/blazor-components/blazor-query-builder) and samples
- **API Details?** See [Query Builder API Reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.QueryBuilder.SfQueryBuilder-1.html)
- **Community?** Join the [Syncfusion Community Forum](https://www.syncfusion.com/forums/blazor-components)
- **What's New?** Check [Release Notes](../Release-Notes)