---
layout: post
title: Serialization in Blazor Diagram Component | Syncfusion
description: Learn here all about how to save and load the diagram elements in Syncfusion Blazor Diagram component and more.
platform: Blazor
control: Diagram Component
documentation: ug
---

# Serialization in Blazor Diagram Component

Serialization is the process of saving and loading the state persistence of the diagram.

## Two-way binding

While saving and loading the diagram, we have to use two-way binding such as @bind for nodes and connectors.

```cshtml
<SfDiagramComponent @ref="@diagram" @bind-Connectors="@connectors" @bind-Nodes="@nodes"></SfDiagramComponent>
```

## Save the diagram as string

While saving the [diagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) is serialized as a string. The [SaveDiagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SaveDiagram) method of the diagram helps to serialize the diagram as a string. The following code illustrates how to save the diagram.

```cshtml
SfDiagramComponent Diagram;
//returns the serialized string of the Diagram
string data = Diagram.SaveDiagram();
```

## Load the diagram from string

The [diagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html) is loaded from the serialized string data by the [LoadDiagram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_LoadDiagram_System_String_) method. The following code illustrates how to load the diagram from serialized string data.

```cshtml
SfDiagramComponent Diagram;
//returns the serialized string of the Diagram
string data = Diagram.SaveDiagram();
//Loads the Diagram from saved data
await Diagram.LoadDiagram(data);
```

## How to save and load the diagram using file stream

The diagram provides support to save and load the diagram using file stream. The below code illustrates how to download the saved diagram as a file.

```cshtml
    SfDiagramComponent diagram;
    private string fileName;
    private string ExtensionType = ".json";

    //Method to save the diagram
    public async Task SaveDiagram()
    {
        fileName = await jsRuntime.InvokeAsync<string>("getDiagramFileName", "");
        await DownloadDiagram(fileName);
    }

    //Method to download the diagram
    public async Task DownloadDiagram(string fileName)
    {
        string data = diagram.SaveDiagram();
        await FileUtil.SaveAs(jsRuntime, data, fileName);
    }

    //Method to load the diagram
    public async Task LoadDiagram()
    {
        diagram.BeginUpdate();
        ExtensionType = ".json";
        await FileUtil.Click(jsRuntime);
        await diagram.EndUpdate();
    }

    public async static Task SaveAs(IJSRuntime js, string data, string fileName)
    {
        await js.InvokeAsync<object>(
        "saveDiagram",
        // Specify IFormatProvider
        Convert.ToString(data), fileName).ConfigureAwait(true);
        // Specify IFormatProvider
    }

    public async static Task Click(IJSRuntime js)
    {
        await js.InvokeAsync<object>(
            "click").ConfigureAwait(true);
    }

    // Js methods to auto download the file
    function getDiagramFileName(dialogName) {
    if (dialogName === 'export')
        return document.getElementById('diagramName').innerHTML.toString();
    if (dialogName === 'save')
        return document.getElementById('diagramName').value.toString();
    else
        return document.getElementById('diagramName').innerHTML.toString();
    }

    function saveDiagram(data, filename) {
    if (window.navigator.msSaveBlob) {
        let blob = new Blob([data], { type: 'data:text/json;charset=utf-8,' });
        window.navigator.msSaveOrOpenBlob(blob, filename + '.json');
    } else {
        let dataStr = 'data:text/json;charset=utf-8,' + encodeURIComponent(data);
        let a = document.createElement('a');
        a.href = dataStr;
        a.download = filename + '.json';
        document.body.appendChild(a);
        a.click();
        a.remove();
    }
    }

    function click() {
    document.getElementById('UploadFiles').click();
    }
```