---
layout: post
title: Publish an AOT enabled Blazor Web Assembly application | Syncfusion
description: Check out the documentation for publishing an AOT [Ahead-Of-Time] enabled Blazor Web Assembly application.
platform: Blazor
component: Common
documentation: ug
---

# Publish Blazor WebAssembly AOT enabled application 

This document explains how to publish an AOT enabled Blazor Web Assembly application.

## Steps for publishing an AOT enabled Blazor WebAssembly application

### Step 1: Create a Blazor WebAssembly application

Prepare a Blazor WebAssembly application by referring to the [documentation](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio).

### Step 2: Enable AOT in the application

To enable AOT in the application, set the AOT option to `true`. Add the below code in .csproj page to enable AOT in the application.

```html
    <PropertyGroup>
        <RunAOTCompilation>true</RunAOTCompilation>
    </PropertyGroup>
```

> **Note:** We need to install the required tools for running the AOT-enabled applications. To install the required tools, run the below command at the command prompt
   `dotnet workload install wasm-tools`

### Step 3: Publish the application

To compile the AOT enabled Blazor WebAssembly application, we need to publish the application. For publishing the application with a release configuration that reduces the size of published application, run the following command.

   `dotnet publish -c Release`

## References

[Host and deploy ASP.NET Core Blazor Web Assembly Application](https://docs.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/webassembly?view=aspnetcore-6.0)
