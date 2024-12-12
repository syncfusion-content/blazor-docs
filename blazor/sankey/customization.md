---
layout: post
title: Customization for Blazor Sankey Component | Syncfusion
description: Explore various customization options available for enhancing the Blazor Sankey component with background style, layout, and orientation configuration.
platform: Blazor
control: Sankey
documentation: ug
---

# Blazor Sankey Chart: Customization

The Blazor Sankey offers extensive customization options to tailor its appearance and behavior to your specific needs.  This guide covers customizing the background, dimensions, orientation, and right-to-left (RTL) support.

## Setting Background

You can customize the background of the Sankey Chart using the `BackgroundColor` and `BackgroundImage` properties.

### Background Color

The `BackgroundColor` property allows you to set a solid background color for the chart.  You can use any valid CSS color string, including hex codes, named colors, and RGB/RGBA values.

```razor
<SfSankey Nodes=@Nodes Links=@Links BackgroundColor="#f1d4ff"> </SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new(); // Your node data
    public List<SankeyDataLink> Links = new(); // Your link data

    protected override void OnInitialized()
    {
        Nodes = GetSankeyNodes();
        Links = GetSankeyLinks();
        base.OnInitialized();
    }


     private List<SankeyDataNode> GetSankeyNodes()
        {
          return new List<SankeyDataNode>()
{
new SankeyDataNode() { Id = "Female", Label = new SankeyDataLabel() { Text = "Female (58%)" } },
new SankeyDataNode() { Id = "Male", Label = new SankeyDataLabel() { Text = "Male (42%)" } },
// ... other nodes
};
        }

        private List<SankeyDataLink> GetSankeyLinks()
        {
         return new List<SankeyDataLink>()
{
new SankeyDataLink() { SourceId = "Female", TargetId = "Tablet", Value = 12 },
new SankeyDataLink() { SourceId = "Female", TargetId = "Mobile", Value = 14 },
// ... other links
};
        }



}
```

### Background Image

The `BackgroundImage` property lets you set a background image for the chart.  Specify the URL or path to the image file.

```razor
<SfSankey Nodes=@Nodes Links=@Links BackgroundImage="sankey-bck-img.png"></SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new(); // Your node data
    public List<SankeyDataLink> Links = new(); // Your link data
    protected override void OnInitialized()
    {
        Nodes = GetSankeyNodes();
        Links = GetSankeyLinks();
        base.OnInitialized();
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

## Dimensions (Width and Height)

Control the chart's dimensions using the `Width` and `Height` properties. You can specify values in pixels or percentages.

```razor
<SfSankey Nodes=@Nodes Links=@Links Width="800px" Height="600px"></SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new(); // Your node data
    public List<SankeyDataLink> Links = new(); // Your link data
    protected override void OnInitialized()
    {
        Nodes = GetSankeyNodes();
        Links = GetSankeyLinks();
        base.OnInitialized();
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


## Right-to-Left (RTL) Support

Enable RTL support using the `EnableRTL` property.

```razor
<SfSankey Nodes=@Nodes Links=@Links EnableRTL="true"></SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new(); // Your node data
    public List<SankeyDataLink> Links = new(); // Your link data
    protected override void OnInitialized()
    {
        Nodes = GetSankeyNodes();
        Links = GetSankeyLinks();
        base.OnInitialized();
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

## Orientation

The `Orientation` property controls the flow direction of the Sankey diagram. You can set it to `Horizontal` or `Vertical`. The default `Auto` setting automatically chooses the best orientation based on the chart's aspect ratio.


```razor
<SfSankey Nodes=@Nodes Links=@Links Orientation="@Orientation.Vertical"></SfSankey>

@code {
    public List<SankeyDataNode> Nodes = new(); // Your node data
    public List<SankeyDataLink> Links = new(); // Your link data
    protected override void OnInitialized()
    {
        Nodes = GetSankeyNodes();
        Links = GetSankeyLinks();
        base.OnInitialized();
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

## Key Points

* Combining background customizations can create visually appealing charts.
* Using percentage values for `Width` and `Height` makes the chart responsive to different screen sizes.
* `EnableRTL` is crucial for supporting right-to-left languages.