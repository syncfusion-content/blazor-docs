---
layout: post
title: Reduce Size of Blazor WebAssembly Application - Syncfusion
description: Check out the documentation for reduce size of blazor webassembly application in blazor using various techniques
platform: Blazor
component: Common
documentation: ug
---

# Reduce Size of Blazor WebAssembly Application

This article explains how to reduce the size of **Blazor WebAssembly (WASM)** applications. Although [Ahead-of-Time (AOT)](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-build-tools-and-aot?view=aspnetcore-9.0#ahead-of-time-aot-compilation) compilation improves performance, it also increases the app size. To help reduce this, you can enable code trimming options in our projects. Trimming automatically removes unused code from the final output, which helps lower the bundle size without affecting functionality. This is especially helpful when using large projects.

## Configure the Linker for ASP.NET Core Blazor

Blazor WebAssembly uses [Intermediate Language (IL) linking](https://learn.microsoft.com/en-us/aspnet/core/blazor/webassembly-build-tools-and-aot?view=aspnetcore-9.0#trim-net-il-after-ahead-of-time-aot-compilation) to trim unused code from the final output during build. This process is **only enabled in Release builds** and is **disabled in Debug configuration** by default. To take full advantage of trimming and reduce the size of the published application, it is recommended to **build your app in Release mode** before deployment.

> Always publish your Blazor WebAssembly app using the `Release` configuration to enable trimming and optimize performance.

### Disable Intermediate Language Linking (Optional)

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

For all assemblies in a Blazor application, trimming is enabled by default from the.NET 8 target framework. Trim warnings may cause problems for applications that have previously used `PublishTrimmed=true` and `TrimMode=partial`. However, if your application compiles without any trim warnings, this default behavior shouldn't interfere with functionality or cause issues. For more information, refer to the [trim configuration](https://learn.microsoft.com/en-us/aspnet/core/blazor/host-and-deploy/configure-trimmer?view=aspnetcore-9.0) documentation to achieve this.

### To Resolve trim warnings

Partial trimming is less aggressive and may be safer for applications that use reflection. To ensure smooth builds, resolve all trim warnings in our application, make the below changes in our `.csproj` to resolve the trim warnings

```xml
<TrimMode>partial</TrimMode>
```

## Enable Link Trimming 

To control **Intermediate Language (IL)** trimming on a per-assembly basis by supplying an XML configuration file. This approach allows you to explicitly preserve assemblies, types, or members that may be trimmed, even if they are not directly referenced in your application code.

To [enable Intermediate Language trimming](https://learn.microsoft.com/en-us/dotnet/core/deploying/trimming/prepare-libraries-for-trimming#enable-project-specific-trimming) in a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor application, update the project file as shown below. This example demonstrates how to configure trimming using the Grid paging feature.

#### How to Enable Intermediate Language Trimming Safely for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Grid

1. Modify your project file (.csproj) to include Trimmable assemblies and descriptors:
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
3. Prevent Trimming of .NET Core Runtime Types. If your app uses reflection, LINQ expressions, or dynamic operations, consider including a LinkerConfig.xml to preserve critical system libraries. It is completely optional.

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
