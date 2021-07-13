# Using dictionary values in Tree Grid data source

You can assign dictionary values in the Tree Grid's data source by accessing them using **KeyValuePair** data type inside the [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Template) property of the [`TreeGridColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumns.html) component

This is demonstrated in the below sample code where **Designation** is defined as Dictionary value and it is accessed inside the template property of the [`TreeGridColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumns.html) using **KeyValuePair** data type. The key value is compared with the **TaskId** column value and based on that the value is displayed,

{% aspTab template="tree-grid/how-to/dictionary-value", sourceFiles="index.razor" %}

{% endaspTab %}

The following image represent the Tree Grid rendered using the above sample code,
![`Dictionary Values`](../images/dictionary-values-treegrid.png)