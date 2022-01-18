---
layout: post
title: Printing in Blazor Diagram Component | Syncfusion
description: Checkout and learn here all about Printing in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Printing in Blazor Diagram Component

Diagram provides support to print the content displayed in the diagram page using the [PrintAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_PrintAsync_Syncfusion_Blazor_Diagram_DiagramPrintSettings) method.

## Page setup

Some of the print options cannot be configured through JavaScript code. So the layout, paper size, and margin options have to customized using the browser page setup dialog. Please refer to the following links to know more about the browser page setup:

* [Chrome](https://support.google.com/chrome/answer/1069693?hl=en&visit_id=1-636335333734668335-3165046395&rd=1)
* [Firefox](https://support.mozilla.org/en-US/kb/how-print-web-pages-firefox)
* [Safari](https://www.mintprintables.com/print-tips/adjust-margins-osx/)
* [IE](http://www.helpteaching.com/help/print/index.htm)

## Printing Options

The diagram can be customized while printing using the following properties of the [DiagramPrintSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramPrintSettings.html) class. 

| Name | Description|
|-------- | -------- |
| Region | Sets the region of the diagram to be printed. |
| Margin | Sets the margin of the page to be printed/exported.|
| FitToPage | Prints the diagram into single or multiple pages. |
| PageWidth | Sets the page width of the diagram while printing the diagram into multiple pages. |
| PageHeight| Sets the page height of the diagram while printing the diagram into multiple pages.|
| Orientation | Sets the orientation of the page. |

These properties behaves as same as the properties in the `DiagramExportSettings` class. For more details, [refer](../export/Exporting options) 

The following code example illustrates how to print the region occupied by the diagram elements.

```cshtml
@using Syncfusion.Blazor.Diagram

<input type="button" value="Print" @onclick="@OnPrint" />
<SfDiagramComponent Height="600px" @ref="@diagram">
  <PageSettings MultiplePage="true" Width="@width" Height="@height" Orientation="@orientation" ShowPageBreaks="@showPageBreak">
     <PageMargin Left="@left" Right="@right" Top="@top" Bottom="@bottom"></PageMargin>
  </PageSettings>
</SfDiagramComponent>

@code{
     SfDiagramComponent diagram;
     double left = 10;
     double top = 10;
     double right = 10;
     double bottom = 10;
     double width = 410;
     double height = 550;
     bool multiplePage = true;
     bool showPageBreak = true;
     DiagramPrintExportRegion region = DiagramPrintExportRegion.PageSettings;
     PageOrientation orientation = PageOrientation.Portrait;
     
     private void OnPrint()
     {
        DiagramPrintSettings print = new DiagramPrintSettings();
        print.PageWidth = width;
        print.PageHeight = height;
        print.Region = region;
        print.FitToPage = multiplePage;
        print.Orientation = orientation;
        print.Margin = new Margin() { Left = left, Top = top, Right = right, Bottom = bottom };
        await diagram.PrintAsync(print);
     }
}
```