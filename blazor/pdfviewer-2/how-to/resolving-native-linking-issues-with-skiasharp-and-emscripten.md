---
layout: post
title: Resolving Native Linking Issues with SkiaSharp and Emscripten | Syncfusion
description: Learn here all about how to resolve native linking issues with SkiaSharp and Emscripten 3.1.56 issue in Blazor sample.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Resolving Native Linking Issues with SkiaSharp and Emscripten

If you encounter loading issues or errors when using SkiaSharp in Blazor WebAssembly or WebApp projects, particularly in setups involving Emscripten 3.1.56, a workaround involves modifying your project file. This issue arises from specific native linking configurations, which may cause conflicts or improper behavior during runtime.

To address these issues, add the following code to your .csproj file:

```csharp
<Target Name="RuntimeIssue109289_Workaround" AfterTargets="_BrowserWasmWriteRspForLinking"> 
	<ItemGroup> 
		<_WasmLinkStepArgs Remove="@(_EmccLinkStepArgs)" /> 
		<_EmccLinkStepArgs Remove="&quot;%(_WasmNativeFileForLinking.Identity)&quot;" /> 
		<_WasmLinkDependencies Remove="@(_WasmNativeFileForLinking)" /> 
		<_SkiaSharpToReorder Include="@(_WasmNativeFileForLinking)" Condition="$([System.String]::Copy('%(FullPath)').Contains('libSkiaSharp.a'))" /> 
		<_WasmNativeFileForLinking Remove="@(_SkiaSharpToReorder)" /> 
		<_WasmNativeFileForLinking Include="@(_SkiaSharpToReorder)" /> 
		<_EmccLinkStepArgs Include="&quot;%(_WasmNativeFileForLinking.Identity)&quot;" /> 
		<_WasmLinkDependencies Include="@(_WasmNativeFileForLinking)" /> 
		<_WasmLinkStepArgs Include="@(_EmccLinkStepArgs)" /> 
	</ItemGroup> 
</Target>
```
 * <b>Purpose:</b> This code block restructures the linking process to mitigate issues arising from SkiaSharp's native library (libSkiaSharp.a) inclusion.
 * <b>Conditions:</b> The workaround is conditioned to only affect files related to SkiaSharp, preserving other components' integrity.

## Additional Resources
For further insights and updates on this issue, please refer to the following resources:

  * [Native Linking Problem with SkiaSharp and Emscripten](https://github.com/dotnet/runtime/issues/109289)
  * [ZipArchive is not functioning in Blazor WebAssembly when using System.IO.Compression.ZipArchive and SkiaSharp v3.118.0-preview.1.2 in .NET 9.0](https://github.com/mono/SkiaSharp/issues/3067)
  * [SkiaSharp Enhancements and Fixes for .NET 9 Blazor](https://github.com/mono/SkiaSharp/pull/3064)