---
layout: post
title: Migration from PDF Viewer to PDF Viewer (NextGen) control | Syncfusion
description: This section explains the features available in the PDF Viewer (NextGen) control over PDF Viewer.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Migration from PDF Viewer to PDF Viewer (NextGen)

## Why PDF Viewer to PDF Viewer (NextGen) control

* Migration to PDF Viewer (NextGen) control offers enhanced performance in scrolling, pagination, and printing. These operations will now be smoother and more efficient, providing a better user experience.

* Eliminates the need for a Web assembly service dependency. This consolidation reduces complexity and improves maintainability.
SfPdfViewer control is now available as a unified package for Windows, Mac, and Linux platforms. This means that users can easily 

* Install and use the software regardless of their operating system. The unified package simplifies distribution and deployment, making it more convenient for users to access and utilize the software on different platforms.

### Nuget Package

To initialize the PDF Viewer (NextGen) component, need to add the following project references to your project

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight C# tabtitle=".csproj" hl_lines="2" %}

<ItemGroup>
    <PackageReference Include="Syncfusion.Blazor.PdfViewer"/>
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

To utilize the PDF Viewer (NextGen) component in your project, need to add the corresponding script file to the *Host.cshtml* or *Layout.cshtml* file based on your framework version.

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

Add the following line to the *Program.cs* file to use the PDF Viewer (NextGen) component

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
builder.Services.AddMemoryCache();

{% endhighlight %}
{% endtabs %}
</td>
</tr>
</table>

### Index.razor

To render the PDF Viewer (NextGen) component, add the following code in the *Index.razor* file.

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<tr>
<td>
{% tabs %}
{% highlight C# tabtitle="Index.razor" %}

<SfPdfViewer DocumentPath="PDF_Succinctly.pdf" ServiceUrl="api/pdfviewer" Height="100%" Width="100%"></SfPdfViewer>

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

When using the PDF Viewer (NextGen) in a WebAssembly application, need to include the following lines in your .csproj file to ensure proper functionality and compatibility 

<table>
<tr>
<th>PDF Viewer(NextGen)</th>
</tr>
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
</table>