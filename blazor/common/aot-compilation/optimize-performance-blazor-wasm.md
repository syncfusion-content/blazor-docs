---
layout: post
title: Optimize Blazor WASM performance with AOT compilation - Syncfusion
description: Enable AOT compilation in Blazor WebAssembly to improve performance, understand trade-offs, and review size versus performance considerations and more details.
platform: Blazor
control: Common
documentation: ug
---

# Optimize Blazor WebAssembly performance with AOT compilation

This article explains how to improve the performance of Blazor WebAssembly (WASM) Apps using **Ahead-of-Time (AOT) compilation**, including apps that use Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

## AOT Compilation Overview

Blazor WebAssembly Apps run entirely in the browser via WebAssembly. By default, the app’s .NET assemblies are downloaded and executed using a **Just-In-Time (JIT)** interpreter. Enabling AOT compilation converts .NET Intermediate Language (IL) into native WebAssembly at build time, which can provide significant performance gains.

## Enable AOT Compilation

Follow these steps to configure AOT for a Blazor WebAssembly App.

**Prerequisites:** Target .NET 8 or later and publish in Release configuration.

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

{% tabs %}
{% highlight c# tabtitle="Blazor publish App" %}

dotnet publish -c Release

{% endhighlight %}
{% endtabs %}

The output will be located in:

{% tabs %}
{% highlight c# tabtitle="Blazor publish App Location" %}

bin/Release/net8.0/publish/wwwroot/

{% endhighlight %}
{% endtabs %}

> AOT improves performance but increases WASM size (~1.5–2×). Use Brotli compression and proper caching to minimize impact.

---

## Size vs Performance Tradeoff
The following sample metrics compare performance and size for Blazor WebAssembly with and without AOT, using a Syncfusion<sup style="font-size:70%">&reg;</sup> Grid with paging enabled.

| Metric                     | Without AOT          | With AOT             |
|----------------------------|----------------------|----------------------|
| Initial Load Time          | ~3.90 seconds        | ~3.04 seconds        |
| On Page Refresh            | ~71 ms               | ~61 ms               |
| Bundle Size (Brotli)       | ~114 MB              | ~192 MB              |
| Memory Usage               | Slightly lower       | Slightly higher      |

> [AOT compilation](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-build-tools-and-aot#ahead-of-time-aot-compilation) increases app size but can significantly improve load time, interactivity, and overall runtime performance in Blazor WebAssembly apps.

---

## Limitations

- **Longer build time:** compared to standard builds.
- **Increased bundle size:** Final WebAssembly size is larger.
- **Higher memory usage:** While AOT improves performance, it may result in slightly higher memory usage at runtime due to native code execution.
- **Reduced flexibility:** Dynamic features (e.g., reflection) may require additional handling.
- **More complex debugging:** Source map support is limited.
- **Slower iterations:** Any code change needs full rebuild, affecting dev productivity.

---

## Considerations

- **Better performance:** Native WebAssembly improves execution speed and UI responsiveness.
- **Enhanced security:** Native code is harder to reverse-engineer than Intermediate Language code.
- **Cross-platform consistency:** Consistent behavior across browsers and devices.

---

## Specific Recommendations

To further reduce published output size, [enable linker and trimming](https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trimming-options#enable-trimming) options in the `.csproj`.

```xml
<PublishTrimmed>true</PublishTrimmed>
<InvariantGlobalization>true</InvariantGlobalization>
<BlazorWebAssemblyEnableLinking>true</BlazorWebAssemblyEnableLinking>
```

> **InvariantGlobalization** reduces globalization data. Only use this if your app doesn't rely on specific culture or regional formats.