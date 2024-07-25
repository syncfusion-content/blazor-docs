---
layout: post
title: Migration from PDF Viewer to PDF Viewer (NextGen) Control | Syncfusion
description: Learn here all about the features available in the PDF Viewer (NextGen) control over PDF Viewer, its elements, and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Migration from PDF Viewer to PDF Viewer (NextGen)

## Why PDF Viewer to PDF Viewer (NextGen) control

The migration to the PDF Viewer (NextGen) control brings a host of benefits, including improved performance in scrolling, pagination, and printing. These enhancements result in a smoother and more efficient user experience. Additionally, this migration eliminates the need for a Web assembly service dependency, streamlining the system and enhancing maintainability.

* **Enhanced Performance**:
With the PDF Viewer (NextGen) control, users can expect significant improvements in performance. Scrolling through documents, navigating pages, and printing operations are now optimized for efficiency. Users will experience seamless and fluid interactions, ensuring a more productive and satisfying workflow.

* **Elimination of Web Assembly Service Dependency**:
The migration to the PDF Viewer (NextGen) control removes the requirement for a Web assembly service dependency.

* **Unified Package for Multiple Platforms**:
The PDF Viewer (NextGen) control is now available as a unified package for Windows, Mac, and Linux platforms. This means that regardless of their operating system, users can effortlessly install and utilize the package.

### Nuget Package

To initialize the PDF Viewer (NextGen) component, need to add the following project references to your **.csproj** file

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight C# tabtitle=".csproj" hl_lines="4 7" %}

<ItemGroup>

	<!-- If you are using a Web Assembly application, include the following line in the .csproj file -->
	<PackageReference Include="Syncfusion.Blazor.PdfViewer"/>

    <!-- If you are using a Server Assembly application, include the following line in the .csproj file -->
	<!--<PackageReference Include="Syncfusion.Blazor.PdfViewerServer"/>-->
		
</ItemGroup>

{% endhighlight %}
{% endtabs %}
</td>
</tr>
<tr>
<th>PDF Viewer (NextGen)</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight C# tabtitle=".csproj" hl_lines="2" %}

<ItemGroup>
    <PackageReference Include="Syncfusion.Blazor.SfPdfViewer"/>
</ItemGroup>

{% endhighlight %}
{% endtabs %}
</td>
</tr>
</table>

### Script File

To utilize the PDF Viewer (NextGen) component in your project, need to add the corresponding script file to the **Host.cshtml** or **Layout.cshtml** file based on your framework version.

N> The script file is same for `Server application` and `Web assembly application` for PDF Viewer (NextGen) component

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight html tabtitle="(~/Layout.cshtml/Host.cshtml)" hl_lines="5" %}

<head>
    <!-- Syncfusion Blazor PDF Viewer controls theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!-- Syncfusion Blazor PDF Viewer controls scripts -->
    <script src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}
</td>
</tr>
<tr>
<th>PDF Viewer (NextGen)</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight html tabtitle="(~/Layout.cshtml/Host.cshtml)" hl_lines="5" %}

<head>
    <!-- Syncfusion Blazor SfPdfViewer controls theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!-- Syncfusion Blazor SfPdfViewer controls scripts -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}
</td>
</tr>
</table>

### Program.cs

Add the following line to the **Program.cs** file to use the PDF Viewer (NextGen) component

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight C# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="1" %}

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}
</td>
</tr>

<tr>
<th>PDF Viewer (NextGen)</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight C# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="1 4" %}

builder.Services.AddSyncfusionBlazor();

// If you are using a WebAssembly application, include the following line in the Program.cs file
// builder.Services.AddMemoryCache();

{% endhighlight %}
{% endtabs %}
</td>
</tr>
</table>

### Index.razor

To render the PDF Viewer (NextGen) component, add the following code in the **Index.razor** file.

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight C# tabtitle="Index.razor" hl_lines="2 5" %}

@* If you are using a Web Assembly application, include the following line in the Index.razor file*@
<SfPdfViewer DocumentPath="PDF_Succinctly.pdf" ServiceUrl="api/pdfviewer" Height="100%" Width="100%"></SfPdfViewer>

@* If you are using a Server Assembly application, include the following line in the Index.razor file
<SfPdfViewerServer DocumentPath="PDF_Succinctly.pdf" Height="100%" Width="100%"></SfPdfViewerServer>*@

{% endhighlight %}
{% endtabs %}

</td>
</tr>
<tr>
<th>PDF Viewer (NextGen)</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight C# tabtitle="Index.razor" %}

<SfPdfViewer2 DocumentPath="PDF_Succinctly.pdf" Height="100%" Width="100%"></SfPdfViewer2>

{% endhighlight %}
{% endtabs %}
</td>
</tr>
</table>

### Project.cs

When using the PDF Viewer (NextGen) in a WebAssembly application, need to include the following lines in your **.csproj** file to ensure proper functionality and compatibility 

<table>
<tr>
<th>PDF Viewer(NextGen)</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight C# tabtitle="csproj" hl_lines="2 6 7" %}
<ItemGroup>
    <NativeFileReference Include="$(SkiaSharpStaticLibraryPath)\2.0.23\*.a" />
</ItemGroup>

<PropertyGroup>
	<WasmNativeStrip>true</WasmNativeStrip>
	<WasmBuildNative>true</WasmBuildNative>
</PropertyGroup>
{% endhighlight %}
{% endtabs %}
</td>
</tr>
</table>

N> If you are WebAssembly application install [SkiaSharp.NativeAssets.WebAssembly](https://www.nuget.org/packages/SkiaSharp.NativeAssets.WebAssembly) NuGet package.

N> If you encounter issues while attempting to host the application in certain environments, such as Azure app services, install [SkiaSharp.Views.Blazor](https://www.nuget.org/packages/SkiaSharp.Views.Blazor) instead of [SkiaSharp.NativeAssets.WebAssembly](https://www.nuget.org/packages/SkiaSharp.NativeAssets.WebAssembly) Nuget package.

## See also

* [Getting Started with Blazor SfPdfViewer Component in Blazor Server App](./getting-started/server-side-application)

* [Getting Started with Blazor SfPdfViewer Component in Blazor WASM App](./getting-started/web-assembly-application)