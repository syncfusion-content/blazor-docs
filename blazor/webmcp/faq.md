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

Tool names are prefixed with the `Name` of the `WebMcpSettings`, falling back to the component `ID`. Give each instance a distinct `Name`.

## Execution and confirmation

### My custom tool returns nothing

`WebMcpTool` does not have an `OnExecute` callback. Handle the call in `OnWebMcpExecute`, match `args.Name`, and set `args.Result`. Also confirm the tool entry uses `Command="Custom"` with a `Name` and `InputSchema`, and that `Cancel` was not set. `ShowConfirmationDialog` does not show a dialog for a custom tool. Ask in the event before you set `Result`. See [Confirm a custom tool](./tools#confirm-a-custom-tool).

### Why does my side effect run before the user confirms?

For a built-in tool, work placed inside `OnWebMcpExecute` runs before the component dialog. Use the event to set `ShowConfirmationDialog` or `Cancel`, and leave the write to the component. A custom tool has no second handler, so ask in the event and change data only after the user accepts.

## Customization and support

### Can I rename or replace a built-in tool?

Yes for `Name` and `Description`. There is no per-tool handler to replace the built-in action. Cancel the call in `OnWebMcpExecute`, or register a custom tool and set `Result` yourself.

N> Whether a built-in tool's `InputSchema` can be overridden is not yet decided. Treat a custom `InputSchema` on a built-in command as ignored until the API confirms otherwise.

### Is WebMCP production-ready?

The browser API is experimental and Chromium-only. Use it where you control the browser, and keep write tools behind confirmation.

## See also

* [Getting started](./getting-started)
* [Tools](./tools)
* [Security and best practices](./security)
