---
layout: post
title: Collaborative editing in Blazor Diagram Component | Syncfusion
description: Learn how to implement collaborative editing in the Syncfusion Blazor Diagram component using SignalR and Redis.
platform: Blazor
control: Diagram
documentation: ug
---

# Collaborative Editing in Blazor Diagram
Collaborative editing in the Syncfusion Blazor Diagram Component allows multiple users to work on the same diagram simultaneously. All changes are synchronized in real time, so collaborators instantly see updates as they occur. This feature improves productivity and teamwork by eliminating delays.

To achieve this, the system uses:

* `SignalR` for real-time communication between Blazor application and the ASP.NET Core SignalR Hub.
* `Redis` as a temporary data store and backplane for scaling across multiple servers.

## Prerequisites
The following are required to enable collaborative editing in Diagram Component:
* Add the following NuGet packages:
    * Blazor Application:
      * Microsoft.AspNetCore.SignalR.Client
      * Syncfusion.Blazor.Diagram
    * ASP.NET Core SignalR Hub:
      * Microsoft.AspNetCore.SignalR
      * Microsoft.AspNetCore.SignalR.StackExchangeRedis
      * StackExchange.Redis

## How It Works
  1. SignalR Connection
     * SignalR enables real-time communication between the Blazor application and the server hub. Each user joins a SignalR group (room) for a specific diagram session. Updates are broadcast only to users in the same room.

  2. Using Redis for Conflict Resolution
     * Redis ensures that collaborative editing works in a distributed environment by:
         * Storing versioning data for conflict resolution.
         * Periodically cleaning old version data to prevent memory issues.

## Cleanup strategy for Redis

To prevent unbounded memory growth and maintain stable performance, implement one or both of the following:
* Keep only the last K versions
    * Maintain a fixed-size history (e.g., the last 200 updates) and trim older entries after each push.
    * Retains only recent updates needed for conflict checks and recovery.
* Apply TTL (Time-to-Live) to keys
    * Set expiration on Redis keys that store version and history data.
    * Bounds memory usage and automatically cleans up stale sessions.
```csharp
// In IRedisService
Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null);
// In RedisService
public async Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null)
{
    try
    {
        string serializedValue = JsonSerializer.Serialize(value);
        return await _database.StringSetAsync(key, serializedValue, expiry);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error setting key {Key}", key);
        return false;
    }
}

// For example, Applying TTL to the version key
const string versionKey = "diagram:version";
long version = 5;
await _redisService.SetAsync(versionKey, version, TimeSpan.FromHours(1));
```

## Best Practices for Hosting, Transport, and Serialization in Blazor Collaboration

To ensure reliable and efficient collaborative editing, consider the following best practices:
* **1. Hosting**
    * Enable WebSockets on your hosting environment and reverse proxy (e.g., Nginx, IIS, Azure App Service).
    * Configure keep-alives to maintain long-lived connections and prevent timeouts during idle periods.
* **2. Transport**
    * **Preferred:** WebSockets for low-latency, full-duplex communication.
    * **Fallback:** If WebSockets are unavailable, remove SkipNegotiation on the Blazor application to allow SignalR to fall back to ASP.NET Core SignalR Hub-Sent Events (SSE) or Long Polling.
* **3. Serialization**
    * For large payloads, enable MessagePack on both collaboration hub and blazor application projects for efficient binary serialization.
    * Consider sending diffs (incremental changes) instead of full diagram state to reduce bandwidth usage.
