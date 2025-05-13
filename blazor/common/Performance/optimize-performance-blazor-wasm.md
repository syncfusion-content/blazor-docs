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

---

## Size vs Performance Tradeoff

| Metric                     | Without AOT          | With AOT             |
|----------------------------|----------------------|----------------------|
| Startup time               | ~2.5 seconds         | ~1.2 seconds         |
| Syncfusion Grid Load       | ~34 ms               | ~25 ms              |
| Bundle size (Brotli)       | ~192 MB              | ~114 MB              |
| Memory usage               | Slightly lower       | Slightly higher      |

AOT compilation increases the app size but improves interactivity and execution speed, especially for **data-heavy Syncfusion components**.

## Limitations and Considerations

- **Build Time**: AOT increases compile time significantly.
- **WASM Size**: Output size is larger due to native WebAssembly files.
- **Debugging**: Source maps are limited. Use Debug builds for development.
- **Reflection/Trimming**: Use `[DynamicDependency]` or `[PreserveDependency]` for reflection-heavy features.

---

> ⚠️ AOT improves speed but increases the WASM size (~1.5–2x). Use Brotli compression and cache headers to mitigate.

## Specific Recommendations

To reduce the published folder size, enable Linker and Trimming Option in our .csproj file to reduce the unused assemblies.

```
<PublishTrimmed>true</PublishTrimmed>
<InvariantGlobalization>true</InvariantGlobalization>
<BlazorWebAssemblyEnableLinking>true</BlazorWebAssemblyEnableLinking>

```
> **InvariantGlobalization** reduces globalization data size. Use only if your app doesn’t rely on specific culture info.




