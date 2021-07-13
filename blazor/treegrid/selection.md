# Selection

Selection provides an option to highlight a row or a cell. It can be done through simple mouse down or arrow keys. To disable selection in the Tree Grid, set the [`AllowSelection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~AllowSelection.html) to false.

The tree grid supports two types of selection that can be set by using the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings~Type.html) property in [`TreeGridSelectionSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html). They are:

* **Single**: The Single value is set by default, and it only allows selection of a single row or a cell.

* **Multiple**: Allows you to select multiple rows or cells.
To perform the multi-selection, press and hold CTRL key and click the desired rows or cells. To select range of rows or cells, press and hold the SHIFT key and click the rows or cells.

{% aspTab template="tree-grid/selection/select", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

## Selection mode

The tree grid supports three types of selection mode that can be set by using
the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings~Mode.html) property of [`TreeGridSelectionSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html). They are:

* **Row**: The Row value is set by default, and allows you to select only rows.
* **Cell**: Allows you to select only cells.
* **Both**: Allows you to select rows and cells at the same time.

{% aspTab template="tree-grid/selection/selectmode", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following output is displayed as a result of the above code example.

![Selection Mode](images/selectionmode.png)

## Cell selection

Cell selection can be done through simple mouse down or arrow keys (up, down, left, and right).

The tree grid supports two types of cell selection mode that can be set by using
the [`CellSelectionMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings~CellSelectionMode.html) property of [`TreeGridSelectionSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html). They are:

* **Flow**: The Flow value is set by default. The range of cells are selected between the start index and end index that includes in between cells of rows.
* **Box**: Range of cells are selected from the start and end column indexes that includes in between cells of rows within the range.

{% aspTab template="tree-grid/selection/cellselection", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following output is displayed as a result of the above code example.

![Cell Selection](images/selectmultiple.png)

> Cell selection requires the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings~Mode.html) to be **Cell** or **Both**, and
**Type** should be **Multiple**.

## Checkbox selection

Checkbox selection provides an option to select multiple tree grid records with help of checkbox in each row.

To render the checkbox in each tree grid row, you need to use checkbox column with type as **checkbox** using the column [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn~Type.html) property.

{% aspTab template="tree-grid/selection/checkbox", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following output is displayed as a result of the above code example.

![Checkbox Selection](images/checkbox.png)

> * By default, selection is allowed by clicking a tree grid row or checkbox in that row. To allow selection only through checkbox, you can set the
[`CheckboxOnly`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings~CheckboxOnly.html) property of [`TreeGridSelectionSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html) to true.
> * Selection can be persisted in all the operations using the [`PersistSelection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings~PersistSelection.html) property of [`TreeGridSelectionSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html).
For persisting selection on the tree grid, any one of the columns should be defined as a primary key using the [`IsPrimaryKey`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn~IsPrimaryKey.html) property of [`TreeGridColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn.html).

### Checkbox selection Mode

In checkbox selection, selection can also be done by clicking on rows. This selection provides two types of Checkbox Selection mode which can be set by using the following API,
[`CheckboxMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings~CheckboxMode.html) in [`TreeGridSelectionSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings.html). The modes are;

* **Default**: This is the default value of the checkboxMode. In this mode, user can select multiple rows by clicking rows one by one.
* **ResetOnRowClick**: In ResetOnRowClick mode, when user clicks on a row it will reset previously selected row. Also you can perform multiple-selection in this mode by press
and hold CTRL key and click the desired rows. To select range of rows, press and hold the SHIFT key and click the rows.

{% aspTab template="tree-grid/selection/checkbox-mode", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following output is displayed as a result of the above code example.

![Initial Select](images/checkbox-mode.gif)

## Toggle Selection

The Toggle selection allows to perform selection and unselection of the particular row or cell. To enable toggle selection, set [`EnableToggle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings~EnableToggle.html) property of TreeGridSelectionSettings as true. If you click on the selected row or cell then it will be unselected and vice versa.

{% aspTab template="tree-grid/selection/Toggleselection", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following output is displayed as a result of the above code example.

![Toggle Select](images/Toggleselect.gif)

>If multi selection is enabled, then first click on any selected row (without pressing Ctrl key), it will clear the multi selection and in second click on the same row, it will be unselected.

## Select row at initial rendering

To select a row at initial rendering, set the [SelectedRowIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~SelectedRowIndex.html) value.

{% aspTab template="tree-grid/selection/initialselect", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following output is displayed as a result of the above code example.

![Initial Select](images/initialselect.png)

## Get selected row indexes

You can get the selected row indexes by using the GetSelectedRowIndexes method.

{% aspTab template="tree-grid/selection/selectrowindex", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

## Touch interaction

When you tap a tree grid row on touchscreen device, the tapped row is selected.
It also shows a popup ![Multi Row selection](images/selection.jpg)  for multi-row selection.
To select multiple rows or cells, tap the popup![Multi Row or Cells](images/mselection.jpg)  and then tap the desired rows or cells.

> Multi-selection requires the selection [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridSelectionSettings~Type.html) to be **Multiple**.

The following screenshot represents a tree grid touch selection in the device.

<!-- markdownlint-disable MD033 -->
<img src="../images/touch-selection.png" alt="Touch interaction" style="width:320px;height: 620px">
<!-- markdownlint-enable MD033 -->
