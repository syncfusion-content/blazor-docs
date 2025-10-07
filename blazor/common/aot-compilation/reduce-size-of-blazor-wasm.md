---
layout: post
title: Reduce size of Blazor WebAssembly Applications - Syncfusion
description: Learn here all about how to reduce Syncfusion Blazor WebAssembly (WASM) App size using trimming and linker configuration. Explore here to more details.
platform: Blazor
control: Common
documentation: ug
---

# Reduce size of Blazor WebAssembly Application

This article explains how to reduce the size of **Blazor WebAssembly (WASM)** applications. Although [Ahead-of-Time (AOT) compilation](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-build-tools-and-aot#ahead-of-time-aot-compilation) improves performance, it also increases app size. To reduce size, enable code trimming options in projects. Trimming removes unused code from the final output, helping lower the bundle size without affecting functionality.

## Configure the Linker for ASP.NET Core Blazor

Blazor WebAssembly uses [Intermediate Language (IL) linking](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-build-tools-and-aot#trim-net-il-after-ahead-of-time-aot-compilation) to trim unused code from the final output during build. This process is only enabled in Release builds and is disabled in Debug by default. To take full advantage of trimming and reduce the size of the published app, publish in Release mode before deployment.

> Always publish your Blazor WebAssembly app using the `Release` configuration to enable trimming and optimize performance.

### Disable Intermediate Language linking (optional)

To manually disable Intermediate Language linking, add the following MSBuild property in your `.csproj` file:

```xml
<PropertyGroup>
  <BlazorWebAssemblyEnableLinking>false</BlazorWebAssemblyEnableLinking>
</PropertyGroup>
```
## Enable trimming

The **PublishTrimmed** property enables code trimming for self-contained publishing. It automatically disables features that are not compatible with trimming and provides warnings about trimming conflicts during build.

To [enable trimming](https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/trimming-options#enable-trimming), add the following to your `.csproj` file:

```xml
<PropertyGroup>
  <PublishTrimmed>true</PublishTrimmed>
</PropertyGroup>
```

## Trim mode

For all assemblies in a Blazor application, trimming is enabled by default starting with the .NET 8 target framework. Trim warnings may occur for apps that previously used `PublishTrimmed=true` and `TrimMode=partial`. If the app compiles without trim warnings, this default behavior should not affect functionality. For more information, refer to the [trim configuration](https://learn.microsoft.com/aspnet/core/blazor/host-and-deploy/configure-trimmer) documentation.

### To Resolve trim warnings

Partial trimming is less aggressive and may be safer for applications that use reflection. To ensure smooth builds, resolve all trim warnings in the application. If needed, make the following change in the `.csproj` file:

```xml
<TrimMode>partial</TrimMode>
```

## Enable Link Trimming 

Control Intermediate Language (IL) trimming on a per-assembly basis by supplying an XML configuration file. This approach allows explicitly preserving assemblies, types, or members that may be trimmed, even if they are not directly referenced in application code.

To [enable Intermediate Language trimming](https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/prepare-libraries-for-trimming#enable-project-specific-trimming) in a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application, update the project file as shown below. This example demonstrates how to configure trimming using the Grid paging feature.

#### How to Enable Intermediate Language Trimming Safely for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Grid

1. Modify your project file (.csproj) to include trimmable assemblies and descriptors:
  ```xml
    <ItemGroup>
      <TrimmableAssembly Include="Syncfusion.Blazor" />
      <TrimmerRootDescriptor Include="SyncfusionRoots.xml" />
      <BlazorLinkerDescriptor Include="LinkerConfig.xml" />
    </ItemGroup>
  ```
2. Create the SyncfusionRoots.xml file in your project root with content like:

  ```xml
  <linker>
    <!-- Preserve methods and types if needed -->
    <assembly fullname="Syncfusion.Blazor.Buttons" />
    <assembly fullname="Syncfusion.Blazor.Core" />
    <assembly fullname="Syncfusion.Blazor.Calendars" />
    <assembly fullname="Syncfusion.Blazor.Data" />
    <assembly fullname="Syncfusion.Blazor.DropDowns" />
    <assembly fullname="Syncfusion.Blazor.Inputs" />
    <assembly fullname="Syncfusion.Blazor.Navigations" />
    <assembly fullname="Syncfusion.Blazor.Spinner" />
    <assembly fullname="Syncfusion.Blazor.Grids" >
      <type fullname="Syncfusion.Blazor.Grids.GridColumn" />
      <type fullname="Syncfusion.Blazor.Grids.GridFilterSettings" />
      <type fullname="Syncfusion.Blazor.Grids.SortColumn" />
      <type fullname="Syncfusion.Blazor.Grids.GridSortSettings" />
      <type fullname="Syncfusion.Blazor.Grids.GridSelectionSettings" />
      <type fullname="Syncfusion.Blazor.Grids.GridEditSettings" />
      <type fullname="Syncfusion.Blazor.Grids.GridTextWrapSettings" />
      <type fullname="Syncfusion.Blazor.Grids.GroupingEventArgs" />
      <type fullname="Syncfusion.Blazor.Grids.GroupedEventArgs" />
      <type fullname="Syncfusion.Blazor.Grids.GridSearchSettings" />
      <type fullname="Syncfusion.Blazor.Grids.GridRowDropSettings" />
    </assembly>
    <assembly fullname="Syncfusion.Blazor.Data">
      <type fullname="Syncfusion.Blazor.Data.ColumnFilter" />
      <type fullname="Syncfusion.Blazor.Data.FilterBehavior" />
      <type fullname="Syncfusion.Blazor.Data.DataUtil" />
      <type fullname="Syncfusion.Blazor.Data.GraphQLAdaptor" />
      <type fullname="Syncfusion.Blazor.Data.GraphQLAdaptorOptions" />
      <type fullname="Syncfusion.Blazor.Data.GraphQLMutation" />
      <type fullname="Syncfusion.Blazor.Data.QueryableOperation" />
      <type fullname="Syncfusion.Blazor.Data.SortDescriptionIndex" />
      <type fullname="Syncfusion.Blazor.Data.SortedColumn" />
      <type fullname="Syncfusion.Blazor.Data.ValueConvert" />
      <type fullname="Syncfusion.Blazor.Data.WhereFilter" />
     </assembly>
  </linker>
  ```
3. Prevent trimming of .NET runtime types. If the app uses reflection, LINQ expressions, or dynamic operations, consider including a LinkerConfig.xml to preserve critical system libraries (optional).

  ```xml
    <ItemGroup>
      <BlazorLinkerDescriptor Include="LinkerConfig.xml" />
    </ItemGroup>
  ```

### Final Evaluation

To evaluate application size, a Blazor WebAssembly test application was configured with Syncfusion<sup style="font-size:70%">&reg;</sup> components, specifically featuring the Blazor Grid with paging enabled.

|   AOT Status          | With Trim            | Without Trim         |
|-----------------------|----------------------|----------------------|
|   Disable             |     23 MB            |    26 MB             |
|   Enable              |     55 MB            |    59 MB             |
