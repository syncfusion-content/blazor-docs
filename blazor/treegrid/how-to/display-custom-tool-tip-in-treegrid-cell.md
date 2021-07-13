# Display Custom Tooltip in Tree Grid cell

You can display custom tooltip in Tree Grid column using [`Column Template`](https://blazor.syncfusion.com/documentation/treegrid/columns/#column-template) feature by rendering the [`SfTooltip`](https://blazor.syncfusion.com/documentation/tooltip/getting-started/) components inside the template.

This is demonstrated in the below sample code we have render the tooltip for **TaskName** column using [`Column Template`](https://blazor.syncfusion.com/documentation/treegrid/columns/#column-template).

{% aspTab template="tree-grid/how-to/custom-tooltip", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

Output be like the below.
![`Final output`](../images/custom-tooltip.PNG)