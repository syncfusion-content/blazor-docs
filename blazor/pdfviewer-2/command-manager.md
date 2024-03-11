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

The [PdfViewerCommandManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.html) provides support to define custom commands. These custom commands are executed when the specified key gesture is recognized. 

## Command Execution
To execute custom commands, simply provide a list of keyboard shortcuts along with the corresponding actions. These actions will be triggered when the specified keyboard shortcuts are pressed.

* [Commands](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.html): 
Represents the list of custom keyboard shortcuts along with the name of the action will be executed in PDF viewer

* [CommandExecuted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.html): 
When you use the keyboard shortcut, it triggers the execution of this method, which carries out the specified action within the PDF viewer.

## How to create custom command: 
You can create custom keyboard commands by specifying the name of the action and the corresponding keyboard combination within the PDF viewer.

* [ActionName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.html): Specifies the name of the action to be executed upon pressing the keyboard shortcuts within the PDF viewer.

* [Gesture](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.html): 
Specifies the combination of [keys](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.html) and [modifiers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.html), including Control, Shift, Alt or Meta key, within the PDF viewer.

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
[View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Load%20and%20Save/Load%20a%20PDF%20document%20using%20created%20event-SfPdfViewer)

## See also

* [Keyboard Accessibility in Syncfusion Blazor PDF Viewer](./accessibility)
