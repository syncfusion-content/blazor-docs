---
layout: post
title: WebMCP FAQ for Blazor Components | Syncfusion
description: Troubleshoot missing WebMCP tools, name collisions, confirmation timing, and custom tool handlers in Syncfusion Blazor components.
platform: Blazor
control: WebMCP
documentation: ug
---

# WebMCP FAQ

## Registration and visibility

### Why are no tools registered?

Check that `EnableWebMcp` is `true`, the component is rendered interactively (not static SSR), and the browser is Chromium-based with WebMCP available. Then call `GetWebMcpToolsAsync` to see what the component registered.

### The `EnableWebMcp` flag is set but a tool is missing

The tool may be disabled. Content-returning tools such as PDF Viewer `GetPageText` and Spreadsheet `GetRangeData` are off by default. Add a tool entry with `Enabled="true"`.

### Why do tool names collide on a page with several components?

Tool names are prefixed with the `Name` of the `WebMcpSettings`, falling back to the component `ID`. Give each instance a distinct `Name`.

## Execution and confirmation

### My `OnExecute` handler does not run

Confirm the tool entry uses `Command="Custom"` with a `Name`, `InputSchema`, and `OnExecute`, and that `Cancel` was not set in `OnWebMcpExecute`. If a confirmation dialog is shown, the handler runs only after the user accepts.

### Why does my side effect run before the user confirms?

Work placed inside `OnWebMcpExecute` runs before the confirmation dialog. Keep the event as a gate and move the work into the tool's `OnExecute` handler.

## Customization and support

### Can I rename or replace a built-in tool?

Yes for `Name` and `Description`, and an `OnExecute` handler replaces the built-in handler.

N> Whether a built-in tool's `InputSchema` can be overridden is not yet decided. Treat a custom `InputSchema` on a built-in command as ignored until the API confirms otherwise.

### Is WebMCP production-ready?

The browser API is experimental and Chromium-only. Use it where you control the browser, and keep write tools behind confirmation.

## See also

* [Getting started](./getting-started)
* [Tools](./tools)
* [Security and best practices](./security)
