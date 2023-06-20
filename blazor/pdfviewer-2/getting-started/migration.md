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

To initialize the `PDF Viewer` component, need to add the **Syncfusion.Blazor.PdfViewerServer.Windows** project references in the *csproj* file of your project

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<td>
{% tabs %}
{% highlight html tabtitle="csproj" hl_lines="2" %}

Syncfusion.Blazor.PdfViewer
Syncfusion.Blazor.PdfViewerServer

{% endhighlight %}
{% highlight html tabtitle="csproj" hl_lines="2" %}

<ItemGroup>
    <PackageReference Include="Syncfusion.Blazor.PdfViewerServer.Windows"/>
</ItemGroup>

{% endhighlight %}
{% endtabs %}

</td>
</table>

N> Need to add the **Syncfusion.Blazor.PdfViewer** for `Web assembly application` and **Syncfusion.Blazor.PdfViewerServer** for `Server assembly application`.

To initialize the `SfPdfViewer` component, need to add the **Syncfusion.Blazor.SfPdfViewer** project references in the *csproj* file of your project

<table>
<tr>
<th>PDF Viewer (NextGen)</th>
</tr>
<td>
{% tabs %}
{% highlight html tabtitle="csproj" hl_lines="1" %}

Syncfusion.Blazor.SfPdfViewer

{% endhighlight %}
{% highlight html tabtitle="csproj" hl_lines="2" %}

<ItemGroup>
    <PackageReference Include="Syncfusion.Blazor.PdfViewerServer.Windows"/>
</ItemGroup>

{% endhighlight %}
{% endtabs %}

</td>
</table>

### Script File

To utilize the `PDF Viewer` component in your project, need to add the corresponding script file to the *Host.cshtml* or *Layout.cshtml* file based on your framework version.

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<td>

{% tabs %}
{% highlight html tabtitle=".NET 6 (~/Layout.cshtml)" hl_lines="5" %}

<head>
    <!-- Syncfusion Blazor PDF Viewer controls theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
<!-- Syncfusion Blazor PDF Viewer controls scripts -->
    <script src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% highlight html tabtitle=".NET 7 (~/Host.cshtml)" hl_lines="5" %}

<head>
    <!-- Syncfusion Blazor PDF Viewer controls theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
<!-- Syncfusion Blazor PDF Viewer controls scripts -->
    <script src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

</td>
</table>

N> The script file is same for `Server application` and `Web assembly application` for PDF Viewer component

To utilize the `SfPdfViewer` component in your project, you need to add the corresponding script file to the *Host.cshtml* or *Layout.cshtml* file based on your framework version.

<table>
<tr>
<th>PDF Viewer (NextGen)</th>
</tr>
<td>

{% tabs %}
{% highlight html tabtitle=".NET 6 (~/Layout.cshtml)" hl_lines="5" %}

<head>
    <!-- Syncfusion Blazor SfPdfViewer controls theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!-- Syncfusion Blazor SfPdfViewer controls scripts -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% highlight html tabtitle=".NET 7 (~/Host.cshtml)" hl_lines="5" %}

<head>
    <!-- Syncfusion Blazor SfPdfViewer controls theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!-- Syncfusion Blazor SfPdfViewer controls scripts -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</head>


{% endhighlight %}
{% endtabs %}

</td>
</table>

N> The script file is same for `Server application` and `Web assembly application` for SfPdfViewer component

### Program.cs

In `PDF Viewer` component have to add the following lines in the *program.cs* file to use the PDF Viewer component in a Blazor project

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<td>

{% tabs %}
{% highlight html tabtitle=".NET 6 & .NET 7 (~/Program.cs)" %}

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

</td>
</table>

In `SfPdfViewer` component have to add the following lines in the *program.cs* file to use the SfPdfViewer component in a Blazor project

<table>
<tr>
<th>PDF Viewer (NextGen)</th>
</tr>
<td>

{% tabs %}
{% highlight html tabtitle=".NET 6 & .NET 7 (~/Program.cs)" %}

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

</td>
</table>

### Imports.razor

In `PDF Viewer` component have to add the following lines in the *Imports.razor*

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<td>
{% tabs %}
{% highlight html tabtitle="Imports.razor" %}

@using Syncfusion.Blazor.PdfViewerServer

{% endhighlight %}
{% endtabs %}

</td>
</table>

In `SfPdfViewer` component have to add the following lines in the *Imports.razor*

<table>
<tr>
<th>PDF Viewer (NextGen)</th>
</tr>
<td>
{% tabs %}
{% highlight html tabtitle="Imports.razor" %}

@using Syncfusion.Blazor.SfPdfViewer

{% endhighlight %}
{% endtabs %}

</td>
</table>

### Index.razor

In the *Index.razor* file, you can use the following code to render the `PDF Viewer` components

<table>
<tr>
<th>PDF Viewer</th>
</tr>
<td>

{% tabs %}
{% highlight html tabtitle="Index.razor(Server application)" %}

<SfPdfViewerServer DocumentPath="PDF_Succinctly.pdf" Height="100%" Width="100%"></></SfPdfViewerServer>

{% endhighlight %}
{% highlight html tabtitle="Index.razor(Web assembly application)" %}


<SfPdfViewer DocumentPath="PDF_Succinctly.pdf" ServiceUrl="api/pdfviewer" Height="100%" Width="100%"></SfPdfViewer>


{% endhighlight %}
{% endtabs %}

</td>
</table>

In the *Index.razor* file, you can use the following code to render the `SfPdfViewer` components:

<table>
<tr>
<th>PDF Viewer(NextGen)</th>
</tr>
<td>

{% tabs %}
{% highlight html tabtitle="Index.razor" %}

<SfPdfViewer2 DocumentPath="PDF_Succinctly.pdf" Height="100%" Width="100%"></SfPdfViewer2

{% endhighlight %}
{% endtabs %}

</td>
</table>

### Project.cs

In `SfPdfViewer` if we are using the Web assembly application need to add the below lines in the *.csproj* file 

<table>
<tr>
<th>PDF Viewer(NextGen)</th>
</tr>
<td>

{% tabs %}
{% highlight html tabtitle="csproj" %}

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