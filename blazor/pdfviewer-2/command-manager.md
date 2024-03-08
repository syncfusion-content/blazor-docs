---
layout: post
title: Command Manager in Blazor SfPdfViewer Component | Syncfusion
description: Checkout and learn here all about Command Manager in Syncfusion Blazor SfPdfViewer component and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# Command Manager in Blazor SfPdfViewer Component

The Pdfviewer provides support to map or bind command execution with a desired combination of key gestures.
The PdfViewerCommandManager provides support to define custom commands. These custom commands are executed when the specified key gesture is recognized. 

## Command Execution

### Commands: 
Represents a collection of custom keyboard commands along with their corresponding action name. 

### CommandExecuted: 
The CommandExecuted event call back method will invoke when executing the custom command in the PDF viewer. 

## How to create custom command: 

### ActionName: 
Represents the name of the command to be executed 

### Gesture: 
Represents the combination of key and Modifiers in the PDF viewer.

The following code snippet explains how to create custom command.

```cshtml

@using Syncfusion.Blazor.SfPdfViewer

<SfPdfViewer2 Height="100%"
              Width="100%"
              @ref="@pdfViewer"
              DocumentPath="@DocumentPath">
    <PdfViewerEvents CommandExecuted="@CommandExecute"></PdfViewerEvents>
    <PdfViewerCommandManager Commands="@command" ></PdfViewerCommandManager>                
</SfPdfViewer2>

@code {
    // Reference to the Pdf viewer 
    SfPdfViewer2 pdfViewer;
    public string DocumentPath { get; set; } = "wwwroot/Data/PDF_Succinctly.pdf";

    /// <summary> 
    /// Defines the list of custom commands 
    /// </summary> 

    public List<KeyboardCommand> command = new List<KeyboardCommand>() 
    { 
        new KeyboardCommand() 
        { 
            ActionName = "FitToWidth", 
            Gesture = new KeyGesture() { Key = PdfKeys.W, Modifiers = PdfModifierKeys.Shift } 
        }, 
        new KeyboardCommand() 
        { 
            ActionName = "FitToPage", 
            Gesture = new KeyGesture() { Key = PdfKeys.P, Modifiers = PdfModifierKeys.Alt } 
        } 
    }; 

    /// <summary> 
    /// Custom command execution. 
    /// </summary> 

    public void CommandExecute(CommandExecutedEventArgs args) 
    { 
        if(args.Modifiers == PdfModifierKeys.Shift && args.Key == PdfKeys.W) 
        { 
            pdf.FitToWidthAsync(); 
        } 
        else if (args.Modifiers == PdfModifierKeys.Alt && args.Key == PdfKeys.P) 
        { 
            pdf.FitToPageAsync(); 
        }  
    } 
} 

```
## See also

* [Keyboard Accessibility in Syncfusion Blazor PDF Viewer](./accessibility)
