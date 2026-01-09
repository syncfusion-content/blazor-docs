---
layout: post
title: Collaborative Editing in Syncfusion Blazor Diagram | Syncfusion
description: Checkout and learn to set up real-time collaborative editing in Syncfusion Blazor Diagram using SignalR and Redis.
platform: Blazor
control: Diagram
documentation: ug
---

# Collaborative editing in Blazor diagram

Collaborative editing enables multiple users to edit diagrams simultaneously in real-time, providing a seamless collaborative experience in Blazor applications.

## Purpose

Collaborative editing in diagram control allows multiple users to edit and review diagrams in real time, ensuring accuracy, consistency, and faster updates. It streamlines teamwork by reducing delays, improving communication through comments, and maintaining data integrity with version tracking.

## Configuration

* Use `SignalR` for real-time communication between the Blazor app and an ASP.NET Core SignalR hub
* Use `Redis` as a temporary data store to manage updates and version state
* Basic setup:
    * Configure an ASP.NET Core SignalR hub. [Refer link](./collaborative-editing-hub)
    * Connect the Blazor app to the hub. [Refer link](./blazor-app-collaborative-editing)

## Limitations

* Default deployment
    * By default, a single server instance works without additional setup. For multi-instance (scale-out) deployments, configure a `SignalR` backplane (e.g., Redis) and use a shared `Redis` store so all nodes share group messages and version state consistently.
* View-only interactions
    * Zoom and pan are local to each user and are not synchronized, so collaborators may view different areas of the diagram.
* Unsupported synchronized settings
    * Changes to `PageSettings`, `ContextMenu`, `DiagramHistoryManager`, `SnapSettings`, `Rulers`, `UmlSequenceDiagram`, `Layout`, and `ScrollSettings` are not propagated to other users and apply only locally.

>**Note:** 
Collaboration applies to actions that raise the [HistoryChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_HistoryChanged) event.

## Sample code

A complete working example is available in the [Syncfusion Blazor Collaborative Editing GitHub repository](https://github.com/syncfusion/blazor-showcase-diagram-collaborative-editing)