---
layout: post
title: Overview of Syncfusion A2UI for Blazor | Syncfusion
description: Learn how Syncfusion A2UI for Blazor connects the A2UI v0.9 protocol with Syncfusion Blazor components to build agent-driven user interfaces.
control: A2UI Overview
platform: Blazor
documentation: ug
domainurl: ##DomainURL##
---

# Syncfusion A2UI Overview

The Syncfusion A2UI for Blazor package bridges the [A2UI v0.9](https://a2ui.org/specification/v0.9-a2ui/) agent-to-UI protocol with Syncfusion's production-grade Blazor component library. It lets an AI agent stream a sequence of structured UI messages, instead of raw HTML or plain text, that the host application renders as fully interactive, data-bound Syncfusion components: **DataGrid**, **Chart**, **Scheduler**, and more.

The package is built on top of the framework-agnostic `Syncfusion.A2UI.Core` runtime and is composed of two NuGet packages that work together:

- **`Syncfusion.A2UI.Core`** — the protocol engine (message processing, surface state, data binding, reactivity). Has **no UI framework dependency** and is shared with the MAUI, WPF, WinForms, and ASP.NET Core A2UI adapters.
- **`Syncfusion.Blazor.A2UI`** — the Blazor renderer. Adds authentic Syncfusion Blazor components on top of the Core engine, plus the 18 A2UI primitives (`Text`, `Row`, `Column`, `Card`, `Tabs`, `Modal`, `Button`, etc.) as HTML-fallback implementations.

In short, the package converts chat-based agent responses into fully functional Blazor user interfaces without requiring manual component development.

N> Syncfusion A2UI for Blazor is currently in **preview (beta)** and will be published on NuGet. The package is feature-complete for the listed components, but the API, catalog ID, and validation schemas may evolve before the first stable release. **Syncfusion.A2UI.Core** and **Syncfusion.Blazor.A2UI** are both at `0.1.0-beta.0`. The **A2UI v0.9 wire format** is stable; minor additive changes (new components, new properties) are expected.

## Prerequisites

Before installing Syncfusion A2UI for Blazor, ensure you have:

- An existing **Blazor Web App** (Server, WebAssembly, or Auto interactive render mode) running on **.NET 8, .NET 9, or .NET 10**. Both packages multi-target the same three TFMs (`net8.0`, `net9.0`, `net10.0`):
  - `Syncfusion.A2UI.Core` — framework-agnostic protocol engine. Supports `net8.0`, `net9.0`, `net10.0`; works in Blazor, MAUI, WPF, WinForms, or ASP.NET Core MVC hosts.
  - `Syncfusion.Blazor.A2UI` — Blazor renderer that depends on `Microsoft.AspNetCore.Components`. Supports `net8.0`, `net9.0`, `net10.0`.
- Syncfusion Blazor components installed for the widget families the agent is expected to render (`Syncfusion.Blazor.Grid`, `Syncfusion.Blazor.Charts`, `Syncfusion.Blazor.Schedule`, etc.). The set of component packages you need is determined by which A2UI adapters you plan to use — see [Supported Components](./supported-components).
- An [A2UI v0.9-compatible agent](https://a2ui.org/specification/v0.9-a2ui/) that emits messages conforming to the four-message lifecycle (`createSurface`, `updateComponents`, `updateDataModel`, `deleteSurface`).
- A registered Syncfusion license key.

## What problem does it solve?

Modern AI agents are expected to do more than return text. A user who asks *"Show me last quarter's sales by region"* expects an interactive chart, not a markdown table. A user who asks *"Schedule a meeting with the design team next Tuesday"* expects a calendar picker, not a confirmation string.

A2UI is an open protocol that uses a lightweight JSON-RPC-based message format. It lets agents describe user interfaces declaratively rather than as raw markup.

The protocol specifies four message types — `createSurface`, `updateComponents`, `updateDataModel`, and `deleteSurface` — and a tree of named components. The host app runs these messages through a `MessageProcessor` to build a `SurfaceModel` and render it.

The package provides the Syncfusion implementation of the rendering layer:

- Ships a catalog of [more than 60 Syncfusion Blazor adapters](./supported-components) — every one is a real Syncfusion widget — plus the 18 A2UI primitives as HTML fall backs.
- Validates every message at runtime against the schemas bundled in `Syncfusion.A2UI.Core`, so malformed agent output is rejected with a clear `A2uiError` instead of failing silently.
- Binds the data and user actions between Syncfusion widgets and the A2UI `DataModel` automatically. Every action dispatched by a Syncfusion adapter is wrapped in the v0.9 envelope `{ "event": { "name": "...", "context": { ... } } }` (see `Syncfusion.Blazor.A2UI.Adapter.EventDispatchHelper`).
- Provides a `<SyncfusionA2UIProvider Surface="..." />` component that mounts the resulting surface with a built-in error boundary.

## Core concepts

Before diving into the end-to-end workflow, here are the terms used throughout this documentation.

- **Agent**: Any AI application that consumes a user prompt and produces A2UI v0.9 messages (for example, a chat backend backed by a hosted LLM).
- **`Syncfusion.A2UI.Core`**: The framework-agnostic runtime. Houses the protocol engine, the wire-format records, the validation schemas, and the `BasicCatalog` (the 18 primitives that every A2UI v0.9 hosting stack is required to ship).
- **`MessageProcessor`**: Lives in `Syncfusion.A2UI.Core.Processing`. Receives A2UI messages, validates each one against the bundled schemas, and incrementally assembles a `SurfaceGroupModel`. The Blazor package re-exports it through DI.
- **`SurfaceModel`**: An in-memory tree representation of every component, widget, and layout decision the agent has emitted for a given UI surface (`surfaceId`). Multiple surfaces can coexist inside one `SurfaceGroupModel`.
- **`Catalog` / `BlazorSyncfusionCatalog`**: A registry that maps A2UI component names (for example, `SyncfusionDataGrid`, `SyncfusionChart`) to concrete renderer implementations. The package ships `Syncfusion.Blazor.A2UI.Catalog.BlazorSyncfusionCatalog` (catalog id `"syncfusion-a2ui-catalog"`) which aggregates the 18 basic schemas plus, when used with `AddA2UIWithSyncfusionComponents`, all Syncfusion-backed schemas in a single catalog.
- **`CatalogRegistry`**: The container that holds one or more `Catalog` instances keyed by id.
- **`DataModel`**: A reactive, signal-based key-value store (in `Syncfusion.A2UI.Core.State`) that backs A2UI bindings. Paths such as `${user.name}` resolve to values stored in the `DataModel` and update the rendered widgets automatically when those values change.
- **`A2uiClientAction` / `OnAction`**: Every user interaction inside a Syncfusion surface is dispatched as an `A2uiClientAction` whose payload matches the v0.9 envelope. The agent receives it through the `actionHandler` passed to the `MessageProcessor` constructor.
- **`<SyncfusionA2UIProvider>`**: A Blazor component (`Syncfusion.Blazor.A2UI.NodeView.SyncfusionA2UIProvider`) that takes a `SurfaceModel` and renders it as interactive Syncfusion components.

## How it works

This loop repeats as long as the surface is active.

1. The user sends a prompt to an A2UI v0.9–compatible agent (any framework, any LLM).
2. The agent emits a stream of A2UI v0.9 messages.
3. The host app passes them to a `MessageProcessor` resolved from DI. With Syncfusion widgets, the processor is registered by `builder.Services.AddA2UIWithSyncfusionComponents()` (singleton scope, combined `Syncfusion.A2UI.Core` + Syncfusion catalog). Plain / Blazor-only hosts can register a scoped processor with `AddA2UI()`.
4. The processor validates each message, mutates the `SurfaceGroupModel`, and raises `OnSurfaceCreated` / `OnSurfaceUpdated` events. The page subscribes to those events and assigns the latest `SurfaceModel` to its `<SyncfusionA2UIProvider/>`.
5. `<SyncfusionA2UIProvider Surface="surface" />` walks the model and renders every component with its Syncfusion adapter.
6. The user interacts with the surface. The matching adapter wraps the interaction in the v0.9 event envelope and dispatches it through `SurfaceGroupModel.OnAction`. The host forwards that payload to the agent as a `message/send` request whose `params.message.parts[0]` is shaped as `{ "data": <action> }`, and the cycle repeats.

## Who is it for?

The package is for teams that want to combine the power of a generative agent with the look, feel, accessibility, and feature depth of Syncfusion:

- **Application builders** adding a conversational, AI-driven layer to an existing Syncfusion-powered product.
- **Internal tooling teams** giving non-developers a natural-language way to explore operational data (grids, charts, schedulers, dashboards).
- **Customer support / CRM teams** that need the agent to show real, interactive forms and reports, not just text suggestions.
- **Anyone shipping Syncfusion Blazor UIs** who wants the same components to be reachable from a chat surface, an MCP server, or an autonomous agent.

Because every adapter renders a real Syncfusion Blazor component, the generated surfaces inherit the accessibility capabilities provided by the underlying widgets, including ARIA roles, keyboard navigation, and high-contrast theme support.

## What you get in the package

- **18 A2UI primitives** rendered as HTML fall backs under the `BlazorSyncfusionCatalog`: `Text`, `Image`, `Icon`, `Video`, `AudioPlayer`, `Card`, `Tabs`, `Modal`, `Row`, `Column`, `List`, `Divider`, `Button`, `TextField`, `CheckBox`, `ChoicePicker`, `Slider`, `DateTimeInput` — these come from `Syncfusion.Blazor.A2UI.Catalog.BasicComponentFactory` and ship in the base Blazor package even when no Syncfusion widgets are registered.
- **`Syncfusion.Blazor.A2UI.SyncfusionComponents.SyncfusionComponentFactory`**: more than 60 Syncfusion Blazor components — `DataGrid`, `TreeGrid`, `Chart`, `3DChart`, `HeatMap`, `Diagram`, `Maps`, `Scheduler`, `GanttChart`, the calendar/date family, the button family, dropdowns, inputs, editors, file/barcode generators, layout/navigation, notifications, and more. The exact list lives on [Supported Components](./supported-components).
- **`<SyncfusionA2UIProvider>`**: A one-line renderer (mount as `<SyncfusionA2UIProvider Surface="mySurface" />`) with a built-in error boundary that turns render errors into a graceful inline message instead of crashing the host app.
- **DI helpers**: `AddA2UIWithSyncfusionComponents()` for the combined basic + Syncfusion catalog.

## Project layout

The package is layered so that the framework-agnostic runtime is always reusable:

| Layer | Namespace | Purpose |
| --- | --- | --- |
| Core | `Syncfusion.A2UI.Core` | Protocol engine, schemas, surface/data models, binding, reactions, errors. |
| Blazor adapter | `Syncfusion.Blazor.A2UI` | `BlazorSyncfusionCatalog`, `BlazorComponentAdapter`, `EventDispatchHelper`, `<SyncfusionA2UIProvider>`, Markdown service. |
| Blazor primitives | `Syncfusion.Blazor.A2UI.Components` | HTML-fallback `.razor` implementations of the 18 basic A2UI schemas. |
| Syncfusion widgets | `Syncfusion.Blazor.A2UI.SyncfusionComponents` | More than 60 Syncfusion Blazor adapters. |

## When to use it and when not to use it

**Use Syncfusion A2UI for Blazor when:**

- You are building (or already have) a Blazor Web App that uses Syncfusion components and want a chat or agent surface in front of it.
- You want the agent to emit *interactive* Syncfusion widgets (grids, charts, schedulers) that the user can manipulate, not just static screenshots or pre-rendered HTML.
- You want runtime validation of every agent message against a bundled schema.
- You need bidirectional data binding so the agent can react to what users do within the surface.
- You are willing to opt in to Syncfusion's licensing and bring in the per-component NuGet package for every family the agent may render.

## Need help?

Two support channels are available while you integrate Syncfusion A2UI for Blazor:

* [Syncfusion Direct-Trac support](https://www.syncfusion.com/support/directtrac/incidents)
* [Syncfusion community forum](https://www.syncfusion.com/forums/)

## See also

* [Getting Started](./getting-started)
* [AI Integration](./ai-integration)
* [Supported Components](./supported-components)
* [A2UI v0.9 protocol](https://a2ui.org/specification/v0.9-a2ui/)
