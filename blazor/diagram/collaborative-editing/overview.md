---
layout: post
title: Collaborative editing in Blazor Diagram Component | Syncfusion
description: Checkout and Learn all about collaborative editing in Syncfusion Blazor Diagram component and many more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Collaborative Editing in Blazor Diagram
Collaborative editing allows multiple users to work on the same diagram simultaneously. All changes are synchronized in real-time, ensuring that collaborators can instantly see updates as they occur. This feature enhances productivity by removing the need to wait for others to finish their edits and promotes seamless teamwork.
By leveraging Redis as the real-time data store, the application ensures fast and reliable communication between clients, making collaborative diagram editing smooth and efficient.

## Prerequisites
Following things are needed to enable collaborative editing in Diagram Component

* SignalR
* Redis

## NuGet packages required

- Blazor Server:
  - Microsoft.AspNetCore.SignalR.Client
  - Syncfusion.Blazor.Diagram
- Collaboration Hub:
  - Microsoft.AspNetCore.SignalR
  - Microsoft.AspNetCore.SignalR.StackExchangeRedis
  - StackExchange.Redis

## SignalR
In collaborative editing, real-time communication is essential for users to see each other’s changes instantly. We use a real-time transport protocol to efficiently send and receive data as edits occur. For this, we utilize SignalR, which supports real-time data exchange between the blazor server and collaboration hub. SignalR ensures that updates are transmitted immediately, allowing seamless collaboration by handling the complexities of connection management and offering reliable communication channels.

To make SignalR work in a distributed environment (with more than one server instance), it needs to be configured with either AspNetCore SignalR Service or a Redis backplane.

## Redis
Redis is used as a temporary data store to manage real-time diagram collaborative editing operations. It helps queue editing actions and resolve conflicts through versioning mechanisms.

All diagram editing operations performed during collaboration are cached in Redis. To prevent excessive memory usage, old versioning data is periodically removed from the Redis cache.

Redis imposes limits on concurrent connections. Select an appropriate Redis configuration based on your expected user load to maintain optimal performance and avoid connection bottlenecks.

