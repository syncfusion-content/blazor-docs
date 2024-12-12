---
layout: post
title: Print and Export for Blazor Sankey Component | Syncfusion
description: Learn how to configure print and export functionalities in the Blazor Sankey component to generate high-quality outputs.
platform: Blazor
control: Sankey
documentation: ug
---

# Blazor Sankey Chart: Printing and Exporting

This guide explains how to print and export the Blazor Sankey using its built-in functionalities. These features allow you to generate high-quality output for presentations, reports, or further analysis.

## Printing the Sankey Chart

The Sankey Chart offers a convenient way to print its contents directly from the browser. The `PrintAsync` method triggers the browser's print dialog, allowing users to select printing options and target printers. Note that the availability and appearance of print options depend on the user's browser and operating system.

```razor
<SfSankey @ref="SankeyChart" Nodes="@Nodes" Links="@Links">
</SfSankey>

<button @onclick="PrintChart">Print Chart</button>

@code {
    private SfSankey SankeyChart;
    public List<SankeyDataNode> Nodes = new(); // Your node data
    public List<SankeyDataLink> Links = new(); // Your link data


    protected override void OnInitialized()
    {
        Nodes = GetSankeyNodes();
        Links = GetSankeyLinks();
        base.OnInitialized();
    }

    private async Task PrintChart()
    {
        await SankeyChart.PrintAsync();
    }


     private List<SankeyDataNode> GetSankeyNodes()
        {
          return new List<SankeyDataNode>()
{
new SankeyDataNode() { Id = "Female", Label = new SankeyDataLabel() { Text = "Female (58%)" } },
// ... other nodes
};
        }

        private List<SankeyDataLink> GetSankeyLinks()
        {
         return new List<SankeyDataLink>()
{
new SankeyDataLink() { SourceId = "Female", TargetId = "Tablet", Value = 12 },
// ... other links
};
        }
}
```

## Exporting the Sankey Chart

The Sankey Chart can be exported to various image formats, including PNG, JPEG, SVG, and PDF. The `ExportAsync` method handles the export process.  You provide the desired file name and format as arguments. The exported image will reflect the current state of the chart, including any customizations or user interactions.

```razor
<SfSankey @ref="SankeyChart" Nodes="@Nodes" Links="@Links">
</SfSankey>

<button @onclick="ExportChart">Export Chart</button>

@code {
    private SfSankey SankeyChart;
    public List<SankeyDataNode> Nodes = new();
    public List<SankeyDataLink> Links = new();

    protected override void OnInitialized()
    {
        Nodes = GetSankeyNodes();
        Links = GetSankeyLinks();
        base.OnInitialized();
    }

    private async Task ExportChart()
    {
        // Export as PNG
        await SankeyChart.ExportAsync(SankeyExportType.PNG, $"Sankey{DateTime.Now.Ticks}",
        Syncfusion.PdfExport.PdfPageOrientation.Portrait, true, false);

    }

       private List<SankeyDataNode> GetSankeyNodes()
        {
          return new List<SankeyDataNode>()
{
new SankeyDataNode() { Id = "Female", Label = new SankeyDataLabel() { Text = "Female (58%)" } },
// ... other nodes
};
        }

        private List<SankeyDataLink> GetSankeyLinks()
        {
         return new List<SankeyDataLink>()
{
new SankeyDataLink() { SourceId = "Female", TargetId = "Tablet", Value = 12 },
// ... other links
};
        }

}
```


## Key Considerations

* **Print Functionality:** The print feature relies on the browser's print capabilities. Ensure users have the necessary printer drivers and browser settings configured.

* **Export Formats:** Choose the appropriate export format based on your needs.  PNG and JPEG are suitable for raster images, while SVG and PDF are vector formats that offer scalability without loss of quality.

* **File Names:** Provide meaningful file names to help users organize and identify exported charts.

* **Event Handling:** The  `PrintCompleted` and `ExportCompleted` events can be used to notify the user or perform actions after the respective operations finish. See the Events section of the Sankey documentation for more details.

