---
layout: post
title: Optimize Performance in Blazor WebAssembly using AOT Compilation - Syncfusion
description: Check out the documentation for Optimize Performance in Blazor WebAssembly in Blazor
platform: Blazor
component: Common
documentation: ug
---

# Optimize Performance in Blazor WebAssembly using AOT Compilation

This article explains how to improve the performance of **Blazor WebAssembly (WASM)** applications using **Ahead-of-Time (AOT) compilation**, specifically for applications using **Syncfusion Blazor components**.

## AOT Compilation Overview

Blazor WebAssembly applications run entirely in the browser via WebAssembly. By default, the app’s .NET assemblies are downloaded and executed using a **Just-In-Time (JIT)** interpreter. However, enabling **AOT compilation** ahead of time converts the .NET Intermediate Language (IL) into native WebAssembly at build time, resulting in significant performance gains.

## Enable AOT Compilation

Follow the steps below to configure AOT for your Blazor WASM project.

### Step 1: Target .NET 8+

Ensure your project targets .NET 8 or later:

```xml
<TargetFramework>net8.0</TargetFramework>
```

### Step 2: Enable AOT in your project file

Add the following to your `.csproj` file:

```xml
<PropertyGroup>
  <RunAOTCompilation>true</RunAOTCompilation>
</PropertyGroup>
```

Then publish the project using:

```bash
dotnet publish -c Release
```

The output will be located in:

```bash
bin/Release/net8.0/publish/wwwroot/
```

> AOT improves performance but increases WASM size (~1.5–2×). Use Brotli compression and proper caching to minimize impact.

---

## Size vs Performance Tradeoff

| Metric                     | Without AOT          | With AOT             |
|----------------------------|----------------------|----------------------|
| Initial Load Time          | ~3.90 seconds        | ~3.04 seconds        |
| On Page Refresh            | ~71 ms               | ~61 ms               |
| Bundle Size (Brotli)       | ~114 MB              | ~192 MB              |
| Memory Usage               | Slightly lower       | Slightly higher      |

> AOT increases bundle size but significantly improves runtime speed, particularly useful for **data-heavy Syncfusion components** like DataGrid, Charts, and Scheduler.

---

## Limitations

- **Longer Build Time:** AOT compilation is slower compared to standard builds.
- **Increased Bundle Size:** Final WebAssembly size is larger.
- **Reduced Flexibility:** Dynamic features (e.g., reflection) may require additional handling.
- **More Complex Debugging:** Source map support is limited.
- **Slower Iterations:** Any code change needs full rebuild, affecting dev productivity.

---

## Considerations

- **Better Performance:** Native WebAssembly improves execution speed and UI responsiveness.
- **Optimized Memory Usage:** Lower memory overhead at runtime.
- **Enhanced Security:** Native code is harder to reverse-engineer than IL code.
- **Cross-Platform Consistency:** Consistent behavior across browsers and devices.

---

## Specific Recommendations

To further reduce published output size, enable linker and trimming options in your `.csproj`:

```xml
<PublishTrimmed>true</PublishTrimmed>
<InvariantGlobalization>true</InvariantGlobalization>
<BlazorWebAssemblyEnableLinking>true</BlazorWebAssemblyEnableLinking>
```

> **InvariantGlobalization** reduces globalization data. Only use this if your app doesn't rely on specific culture or regional formats.
