---
layout: post
title: Optimize Performance in Blazor WASM using AOT Compilation - Syncfusion
description: Check out the documentation for Optimize Performance using AOT Compilation in Blazor WebAssembly in Blazor
platform: Blazor
component: Common
documentation: ug
---

# Optimize Performance in Blazor WebAssembly using AOT Compilation

This article explains how to improve the performance of Blazor WebAssembly (WASM) Apps using **Ahead-of-Time (AOT) compilation**, including apps that use Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

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

> [AOT compilation](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-build-tools-and-aot?view=aspnetcore-9.0#ahead-of-time-aot-compilation) increases the application size but significantly improves load time, interactivity and overall runtime performance in Blazor WebAssembly applications.

---

## Limitations

- **Longer Build Time:** AOT compilation is slower compared to standard builds.
- **Increased Bundle Size:** Final WebAssembly size is larger.
- **Higher Memory Usage:** While AOT improves performance, it may result in slightly higher memory usage at runtime due to native code execution.
- **Reduced Flexibility:** Dynamic features (e.g., reflection) may require additional handling.
- **More Complex Debugging:** Source map support is limited.
- **Slower Iterations:** Any code change needs full rebuild, affecting dev productivity.

---

## Considerations

- **Better Performance:** Native WebAssembly improves execution speed and UI responsiveness.
- **Enhanced Security:** Native code is harder to reverse-engineer than Intermediate Language code.
- **Cross-Platform Consistency:** Consistent behavior across browsers and devices.

---

## Specific Recommendations

To further reduce published output size, [enable linker and trimming](https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trimming-options#enable-trimming) options in your `.csproj`:

```xml
<PublishTrimmed>true</PublishTrimmed>
<InvariantGlobalization>true</InvariantGlobalization>
<BlazorWebAssemblyEnableLinking>true</BlazorWebAssemblyEnableLinking>
```

> **InvariantGlobalization** reduces globalization data. Only use this if your app doesn't rely on specific culture or regional formats.