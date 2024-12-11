---
layout: post
title: Title and Subtitle in Blazor Sankey Component | Syncfusion
description: Learn how to set and customize the title and subtitle in the Blazor Sankey component from Syncfusion.
platform: Blazor
control: Sankey
documentation: ug
---

# Title and Subtitle in Blazor Sankey Component

The Syncfusion Blazor Sankey component allows you to add a title and subtitle to your chart, providing context and description for the data visualization. This topic covers how to set and customize the title and subtitle in the Sankey chart.

## Setting the Title and Subtitle

To add a title and subtitle to your Sankey chart, use the `Title` and `SubTitle` properties of the `SfSankey` component.

```razor
<SfSankey Width="600px" Height="400px" 
           Nodes="@Nodes" 
           Links="@Links"
           Title="User Device Usage"
           SubTitle="Distribution by Gender, Device, and Age">
</SfSankey>
```

In this example, "User Device Usage" is set as the title, and "Distribution by Gender, Device, and Age" is set as the subtitle.

## Customizing Title and Subtitle

You can further customize the appearance of the title and subtitle using the `SankeyTitleStyle` and `SankeySubtitleStyle` components.

```razor
<SfSankey Width="600px" Height="400px" 
           Nodes="@Nodes" 
           Links="@Links"
           Title="User Device Usage"
           SubTitle="Distribution by Gender, Device, and Age">
    <SankeyTitleStyle FontSize="16px" FontFamily="Roboto" FontWeight="800"></SankeyTitleStyle>
    <SankeySubtitleStyle FontSize="10px" FontFamily="Roboto" FontWeight="400"></SankeySubtitleStyle>
</SfSankey>
```

## Title Properties

The `Title` property allows you to set a descriptive title for the Sankey chart. Here are some key points about the `Title` property:

- It accepts a string value.
- The default value is an empty string.
- It's recommended to use clear and concise titles that summarize the main purpose or focus of the Sankey chart.
- Adding a title can significantly enhance the overall readability and understanding of the chart, especially in scenarios with complex or diverse data sets.

## Subtitle Properties

The `SubTitle` property lets you provide additional information or context to the Sankey chart title. Key points about the `SubTitle` property include:

- It accepts a string value.
- The default value is an empty string.
- The subtitle is only applicable when the `Title` property is set.
- Use the subtitle to add supplementary information that helps users better understand the chart's context or data source.

## Example

Here's a complete example demonstrating how to set and style the title and subtitle:

```razor
<SfSankey Width="800px" Height="600px" 
           Nodes="@Nodes" 
           Links="@Links"
           Title="@_title"
           SubTitle="@_subTitle">
    <SankeyTitleStyle FontSize="20px" FontFamily="Arial" FontWeight="bold" Color="#333"></SankeyTitleStyle>
    <SankeySubtitleStyle FontSize="14px" FontFamily="Arial" FontWeight="normal" Color="#666"></SankeySubtitleStyle>
</SfSankey>

@code {
    private string _title = "User Device Usage";
    private string _subTitle = "Distribution by Gender, Device, and Age";

    // Nodes and Links initialization code...
}
```

## Key Considerations

- Use meaningful and descriptive titles to give users a quick insight into the data represented in the Sankey chart.
- Keep titles and subtitles concise while providing enough context.
- Use the subtitle to provide additional details or timeframes related to the data.
- Customize the font size, family, weight, and color to ensure the title and subtitle are visually appealing and readable.
- Ensure that the title and subtitle do not overshadow the actual chart data.

By effectively utilizing the title and subtitle features of the Blazor Sankey component, you can create more informative and user-friendly data visualizations that clearly communicate the purpose and context of your Sankey diagrams.