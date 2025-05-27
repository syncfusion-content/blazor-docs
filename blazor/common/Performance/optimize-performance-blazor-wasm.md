---
layout: post
title: Optimize Performance in Blazor WebAssembly using AOT Compilation - Syncfusion
description: Check out the documentation for Optimize Performance in Blazor WebAssembly in Blazor
platform: Blazor
component: Common
documentation: ug
---
# Optimize Performance in Blazor WebAssembly using AOT Compilation

This article explains how to improve the performance of **Blazor WebAssembly (WASM)** applications by using **Ahead-of-Time (AOT) compilation**, with a focus on applications that integrate **Syncfusion Blazor components**.

## AOT Compilation Overview

Blazor WebAssembly applications run entirely in the browser via WebAssembly. By default, the app’s .NET assemblies are downloaded and executed using a **Just-In-Time (JIT)** interpreter. However, enabling **AOT compilation** ahead of time converts the .NET Intermediate Language (IL) into native WebAssembly at build time, resulting in significant performance gains.

## Enable AOT Compilation

Follow the steps below to configure AOT compilation for your Blazor WebAssembly application.

### Step 1: Target .NET 8+

Ensure your project targets .NET 8 or later:

```xml
<TargetFramework>net8.0</TargetFramework>
```

### Step 2: Enable AOT in the project file

Update your `.csproj` file with the following:

```xml
<PropertyGroup>
  <RunAOTCompilation>true</RunAOTCompilation>
</PropertyGroup>
```

Use the `dotnet publish` command in **Release** configuration:

```bash
dotnet publish -c Release
```

The compiled app with AOT will be available in:
```
bin/Release/net8.0/publish/wwwroot/
```

> AOT improves speed but increases the WASM size (~1.5–2x). Use Brotli compression and cache headers to mitigate.

---

## Size vs Performance Tradeoff

| Metric                     | Without AOT          | With AOT             |
|----------------------------|----------------------|----------------------|
| Initial Load time          | ~3.90 seconds        | ~3.04 seconds        |
| On Page Refresh            | ~71 ms               | ~61 ms               |
| Bundle size (Brotli)       | ~114 MB              | ~192 MB              |
| Memory usage               | Slightly lower       | Slightly higher      |

AOT compilation increases the app size but improves interactivity and execution speed, especially for **data-heavy Syncfusion components** like DataGrid, Charts, and Scheduler.

## Limitations

  - **Longer Build Time:** The compilation process is significantly slower compared to non-AOT builds.

  - **Increased Bundle Size:** AOT increases the overall application size due to native WebAssembly files.

  - **Reduced Flexibility:** Features relying on reflection or dynamic code may not work without special handling.

  - **More Complex Debugging:** Limited source map support makes AOT code harder to debug.

  - **Slower Iterations:** Any code changes requires a full rebuild, impacting development efficiency.

## Considerations
  - **Better Performance:** Native WebAssembly code improves runtime execution speed and responsiveness.

  - **Optimized Memory Usage:** AOT reduces memory overhead, enabling more efficient resource usage.

  - **Enhanced Security:** Compiled machine code is harder to reverse-engineer than IL code.

  - **Cross-Platform Consistency:** AOT delivers consistent behavior across all supported browsers and devices.

## Specific Recommendations

To reduce the published folder size, enable Linker and Trimming Option in our .csproj file to reduce the unused assemblies.

```
<PublishTrimmed>true</PublishTrimmed>
<InvariantGlobalization>true</InvariantGlobalization>
<BlazorWebAssemblyEnableLinking>true</BlazorWebAssemblyEnableLinking>
```
> **InvariantGlobalization** reduces globalization data size. Use only if your app doesn’t rely on specific culture info.

