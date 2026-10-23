---
layout: post
title: WebMCP Security and Best Practices | Syncfusion Blazor
description: Limit exposed WebMCP tools, confirm data changes, validate arguments, and audit calls before an in-browser agent operates a Blazor component.
platform: Blazor
control: WebMCP
documentation: ug
---

# WebMCP Security and Best Practices

Treat every tool call as input from an untrusted caller. The agent acts on behalf of the user, but its arguments can be wrong, manipulated by page content, or broader than you intended. Keep the exposed surface small and gate anything that changes data.

## Limit what is exposed

* **Leave WebMCP off until needed.** `EnableWebMcp` is `false` by default. Enable it only on components where agent access is wanted.
* **Expose only what is needed.** Disable tools you do not want agents to call, and keep content-returning tools (page text, annotations, range data) off unless the scenario requires them.
* **Name each instance.** When a page has several components, give each `WebMcpSettings` a distinct `Name` so tool names do not collide and agents target the right instance.

## Gate changes to data

* **Separate read tools from write tools.** Read tools are low risk. For a built-in tool that edits, deletes, redacts, protects, or saves, set `ShowConfirmationDialog` to `true` in `OnWebMcpExecute`.
* **Confirm custom tools yourself.** Trigger `OnWebMcpExecute`, and set `Result` only after the user accepts. See [Confirm a custom tool](./tools#confirm-a-custom-tool).
* **Keep built-in side effects out of the event.** For a built-in tool, the event runs before the component dialog. Set `ShowConfirmationDialog` or `Cancel`, and leave the write to the component. Do custom tool work in this event, after the user accepts.

## Validate and authorize

* **Validate arguments.** In `OnWebMcpExecute`, check `Arguments` against what your app allows, and set `Cancel` to `true` for anything out of range or not permitted for the signed-in user.
* **Authorize in the app, not in the prompt.** Role checks belong in the event handler. An agent instruction is not an access control.
* **Write precise descriptions and schemas.** A clear `Description` and a strict `InputSchema` help the agent pick the right tool and send valid arguments.

## Audit and test

* **Log calls.** Record tool name, arguments, and outcome from `OnWebMcpExecute` for auditing.
* **Test on supported browsers.** WebMCP is experimental and its browser API may change, so test with the browser versions you support.

## See also

* [Control tool execution](./tools#control-tool-execution) shows how to cancel a call or ask the user to confirm a built-in tool.
* [Confirm a custom tool](./tools#confirm-a-custom-tool) shows how to ask before a custom tool changes data.
* [WebMCP FAQ](./faq) covers confirmation timing and why a custom tool does not show the built-in dialog.
