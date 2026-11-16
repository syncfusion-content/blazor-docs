---
layout: post
title: WebMCP FAQ for Blazor Components | Syncfusion
description: Troubleshoot missing WebMCP tools, name collisions, confirmation timing, and custom tool results in Syncfusion Blazor components.
platform: Blazor
control: WebMCP
documentation: ug
---

# WebMCP Frequently Asked Questions

## Registration and visibility

### Why are no tools registered?

Check that `EnableWebMcp` is `true`, the component is rendered interactively (not static SSR), and the browser is Chromium-based with WebMCP available. Then call `GetWebMcpToolsAsync` to see what the component registered.

### The `EnableWebMcp` flag is set but a tool is missing

The tool may be disabled. Content-returning tools such as PDF Viewer `GetPageText` and Spreadsheet `GetRangeData` are off by default. Add a tool entry with `Enabled="true"`.

### Why do tool names collide on a page with several components?

Tool names are `{Prefix}_{Tool}`. The prefix is the `Name` of the `WebMcpSettings`, or the component `ID` when `Name` is empty. Use PascalCase for that name. With `Name="Orders"`, the built-in `SetCellValue` tool is registered as `Orders_SetCellValue`. Give each instance a distinct `Name`. See [Configure tools](./tools#configure-tools).

## Execution and confirmation

### My custom tool returns nothing

Trigger `OnWebMcpExecute`, match `args.Name`, and set `args.Result`. Also confirm the tool entry uses `Command="Custom"` with a `Name` and an object `InputSchema`, and that `Cancel` was not set. See [Confirm a custom tool](./tools#confirm-a-custom-tool).

### Why does my side effect run before the user confirms?

For a built-in tool, work placed inside `OnWebMcpExecute` runs before the component dialog. Use the event to set `ShowConfirmationDialog` or `Cancel`, and leave the write to the component. For a custom tool, trigger `OnWebMcpExecute` and change data only after the user accepts.

## Customization and support

### Can I rename or replace a built-in tool?

Yes for `Name` and `Description`. There is no per-tool handler to replace the built-in action. Cancel the call in `OnWebMcpExecute`, or register a custom tool and set `Result` yourself. `InputSchema` on a built-in command is ignored. The component keeps its built-in schema. Set `InputSchema` only on a custom tool.

### Is WebMCP production-ready?

The browser API is experimental and Chromium-only. Use it where you control the browser, and keep write tools behind confirmation.

## See also

* [Getting started with WebMCP](./getting-started) shows the setup to check when tools do not appear.
* [Configure WebMCP tools](./tools) covers custom tools, confirmation, and the registered name format.
* [Security and best practices](./security) explains how to limit tools and confirm changes to data.
