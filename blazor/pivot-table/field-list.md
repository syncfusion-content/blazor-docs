---
layout: post
title: Field List in Blazor Pivot Table Component | Syncfusion 
description: Learn about Field List in Blazor Pivot Table component of Syncfusion, and more details.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Field List

The [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) provides a built-in Field List similar to Microsoft Excel. It allows to add or remove fields and also rearrange them between different axes, including column, row, value, and filter along with sort and filter options dynamically at runtime.

The field list can be displayed in two different formats to interact with pivot table. They are:

* **In-built Field List (Popup)**: To display the field list icon in pivot table UI to invoke the built-in dialog.
* **Stand-alone Field List (Fixed)**: To display the field list in a static position within a web page.

## In-built Field List (Popup)

To enable the field list in pivot table UI, set the [`ShowFieldList`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_ShowFieldList) property in [`SfPivotView`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class to **true**. A small icon will appear on the top left corner of the pivot table and clicking on this icon, field list dialog will appear.

> The field list icon will be displayed at the top right corner of the pivot table, when grouping bar is enabled.

 ```csharp
    @using Syncfusion.Blazor.PivotView

    <SfPivotView TValue="ProductDetails" ShowFieldList="true">
         <PivotViewDataSourceSettings DataSource="@dataSource">
            <PivotViewColumns>
                <PivotViewColumn Name="Year"></PivotViewColumn>
                <PivotViewColumn Name="Quarter"></PivotViewColumn>
            </PivotViewColumns>
            <PivotViewRows>
                <PivotViewRow Name="Country"></PivotViewRow>
                <PivotViewRow Name="Products"></PivotViewRow>
            </PivotViewRows>
            <PivotViewValues>
                <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
                <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
            </PivotViewValues>
            <PivotViewFormatSettings>
                <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
            </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
    </SfPivotView>

    @code{
        public List<ProductDetails> dataSource { get; set; }
        protected override void OnInitialized()
        {
           this.dataSource = ProductDetails.GetProductData().ToList();
           //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
        }
    }

```

<!-- markdownlint-disable MD012 -->
![output](images/gs_fieldlist_icon.png "Field list icon at the top left of the pivot table component")
<br/>
![output](images/gs_fieldlist_dialog.png "Field list dialog for user interaction")


## Stand-alone Field List (Fixed)

The field list can be rendered in a static position, anywhere in web page layout, like a separate component. To do so, you need to set [`RenderMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotFieldList-1.html#Syncfusion_Blazor_PivotView_SfPivotFieldList_1_RenderMode) property to [**Mode.Fixed**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.Mode.html) in [`SfPivotFieldList`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotFieldList-1.html).

> To make field list interact with pivot table, you need to use the [**UpdateViewAsync**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotFieldList-1.html#Syncfusion_Blazor_PivotView_SfPivotFieldList_1_UpdateView_System_Object_) and [**Update**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotFieldList-1.html#Syncfusion_Blazor_PivotView_SfPivotFieldList_1_Update_System_Object_) methods for data source update in both field list and pivot table simultaneously.

```csharp
        <SfPivotView TValue="ProductDetails" ID="pivotview"  @ref="pivotView" Height="530">
            <PivotViewEvents TValue="ProductDetails" EnginePopulated="pivotenginepopulated"></PivotViewEvents>
        </SfPivotView>
        <SfPivotFieldList TValue="ProductDetails" ID="fieldlist" @ref="fieldList" RenderMode="Mode.Fixed" >
            <PivotFieldListDataSourceSettings DataSource="@data" EnableSorting=true>
                <PivotFieldListColumns>
                    <PivotFieldListColumn Name="Year"></PivotFieldListColumn>
                    <PivotFieldListColumn Name="Quarter"></PivotFieldListColumn>
                </PivotFieldListColumns>
                <PivotFieldListRows>
                    <PivotFieldListRow Name="Country"></PivotFieldListRow>
                    <PivotFieldListRow Name="Products"></PivotFieldListRow>
                </PivotFieldListRows>
                <PivotFieldListValues>
                    <PivotFieldListValue Name="Sold" Caption="Unit Sold"></PivotFieldListValue>
                    <PivotFieldListValue Name="Amount" Caption="Sold Amount"></PivotFieldListValue>
                </PivotFieldListValues>
            </PivotFieldListDataSourceSettings>
            <PivotFieldListEvents TValue="ProductDetails" EnginePopulated="enginepopulated"></PivotFieldListEvents>
        </SfPivotFieldList>
        <style>
            #fieldlist {
                width: 42%;
                height: 100%;
                float: right;
            }

            #pivotview {
                width: 57%;
                height: 530px;
                float: left;
            }
        </style>
        @code{
            SfPivotFieldList<ProductDetails> fieldList;
            SfPivotView<ProductDetails> pivotView;
            public List<ProductDetails> data { get; set; }
            protected override void OnInitialized()
            {
                this.data = ProductDetails.GetProductData();
            }

            public void pivotenginepopulated(EnginePopulatedEventArgs args)
            {
                this.fieldList.UpdateAsync(this.pivotView);
            }
            public void enginepopulated(EnginePopulatedEventArgs args)
            {
                this.fieldList.UpdateViewAsync(this.pivotView);
            }
        }

```

![output](images/staticfieldlist.png "Static FieldList")


## Add or remove fields

Using check box besides each field, end user can select or unselect to add or remove fields respectively from the report at runtime.

![output](images/fieldlist_treeview.png)

## Remove specific field(s) from displaying

When a data source is bound to the component, fields will be automatically populated inside the Field List. In such case, user can also restrict specific field(s) from displaying. To do so, set the appropriate field name(s) in [`ExcludeFields`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.DataSourceSettingsModel-1.html#Syncfusion_Blazor_PivotView_DataSourceSettingsModel_1_ExcludeFields) property belonging to [`PivotViewDataSourceSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewDataSourceSettings-1.html) class.

 ```csharp
    @using Syncfusion.Blazor.PivotView

    <SfPivotView TValue="ProductDetails" ShowFieldList="true">
         <PivotViewDataSourceSettings DataSource="@dataSource" ExcludeFields="@(new string[] { "Products", "Amount" })">
            <PivotViewColumns>
                <PivotViewColumn Name="Year"></PivotViewColumn>
                <PivotViewColumn Name="Quarter"></PivotViewColumn>
            </PivotViewColumns>
            <PivotViewRows>
                <PivotViewRow Name="Country"></PivotViewRow>
                <PivotViewRow Name="Products"></PivotViewRow>
            </PivotViewRows>
            <PivotViewValues>
                <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
                <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
            </PivotViewValues>
            <PivotViewFormatSettings>
                <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
            </PivotViewFormatSettings>
        </PivotViewDataSourceSettings>
    </SfPivotView>

    @code{
        public List<ProductDetails> dataSource { get; set; }
        protected override void OnInitialized()
        {
           this.dataSource = ProductDetails.GetProductData().ToList();
           //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
        }
    }

```

![output](images/fieldlist_hide.png)

## Re-arranging fields

In-order to re-arrange, drag any field from the field list and drop it into the column, row, value, or filter axis using the drag-and-drop holder. It helps end user to alter the report at runtime.

![output](images/fieldlist_axes.png)

## Filtering members

Using the filter icon besides each field in row, column and filter axes, members can be either included or excluded at runtime. To know more about member filtering, [`refer`](./filtering) here.

![output](images/fieldlist_filtericon.png "Filter icon besides each field")
<br/>
![output](images/fieldlist_editor.png "Filter dialog to either include or exclude members")
<br/>
![output](images/fieldlist_filteringgrid.png "Resultant pivot table on filtering members")

## Sorting members

Using the sort icon besides each field in row and column axes, members can be arranged either in ascending or descending order at runtime. To know more about member sorting, [`refer`](./sorting) here.

![output](images/fieldlist_sorticon.png "Sort icon besides each field")
<br/>
![output](images/fieldlist_sortgrid.png "Resultant pivot table showing countries in descending order")

## Calculated fields

The calculated field support allows end user to add a new calculated field based on the available fields from the bound data source using basic arithmetic operators. To enable this support in Field List UI, set the [`AllowCalculatedField`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_AllowCalculatedField) property in [`SfPivotView`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class to **true** in pivot table. Now a button will be seen automatically inside the field list UI which will invoke the calculated field dialog on click. To know more about calculated field, [`refer`](./calculated-field) here.

![output](images/gs_calc_button.png "Enabling calculated field in field list UI")
<br/>
![output](images/gs_calc_dialog.png "Creating new calculated field")
<br/>
![output](images/gs_calc_grid.png "New calculated field 'Total Amount' added in pivot table")

## Changing aggregation type of value fields at runtime

End user can perform calculations over a group of values using the aggregation option. The value fields bound to the field list, appears with a dropdown icon, helps to select an appropriate aggregation type at runtime. On selection, the values in the Pivot Table will be changed dynamically. To know more about aggregation, [`refer`](./aggregation) here.

![output](images/aggregation_fl_icon.png "Icon to change aggregation type")
<br/>
<br/>
![output](images/fieldlist_aggregation_avg.png "List of pre-defined aggregation types")
<br/>
![output](images/fieldlist_aggregation_grid.png "Resultant pivot table showing average aggregation type applied in 'Unit Sold' value field")

## Defer layout update

Defer layout update support to update the pivot table only on demand and not during every user action. To enable this support in Field List UI, set the [`AllowDeferLayoutUpdate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_AllowDeferLayoutUpdate) property in [`SfPivotView`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class to **true** in pivot table. Now a check box inside Field List UI will be seen in checked state, allowing pivot table to update only on demand. To know more about defer layout, [`refer`](./defer-layout-update) here.

![output](images/fieldlist_deferupdate.png)

## Show field list using toolbar

It can also be viewed in toolbar by setting [`ShowFieldList`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_ShowFieldList) and [`ShowToolbar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_ShowToolbar) properties in [`SfPivotView`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class to **true**. Also, include the item [**ToolbarItems.FieldList**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.ToolbarItems.html) within the [`Toolbar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_Toolbar) property in [`SfPivotView`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html) class. When toolbar is enabled, field list icon will be automatically added into the toolbar and the icon won't appear on top left corner in the pivot table component.

```csharp
    @using Syncfusion.Blazor.PivotView

    <SfPivotView TValue="ProductDetails" ShowFieldList="true" ShowToolbar="true" Toolbar="@toolbar">
            <PivotViewDataSourceSettings DataSource="@data">
                <PivotViewColumns>
                    <PivotViewColumn Name="Year"></PivotViewColumn>
                    <PivotViewColumn Name="Quarter"></PivotViewColumn>
                </PivotViewColumns>
                <PivotViewRows>
                    <PivotViewRow Name="Country"></PivotViewRow>
                    <PivotViewRow Name="Products"></PivotViewRow>
                </PivotViewRows>
                <PivotViewValues>
                    <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
                    <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
                </PivotViewValues>
                <PivotViewFormatSettings>
                    <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
                </PivotViewFormatSettings>
            </PivotViewDataSourceSettings>
    </SfPivotView>

    @code{
        public List<ToolbarItems> toolbar = new List<ToolbarItems> {
            ToolbarItems.FieldList
        };
        public List<ProductDetails> data { get; set; }
        protected override void OnInitialized()
        {
            this.data = ProductDetails.GetProductData().ToList();
            //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
        }
    }

```

![output](images/fieldlist_toolbar.png)

## Events

### EnginePopulated

The [`EnginePopulated`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldListEvents-1.html#Syncfusion_Blazor_PivotView_PivotFieldListEvents_1_EnginePopulated) event is available in both Pivot Table and Field List.

* The event [`EnginePopulated`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldListEvents-1.html#Syncfusion_Blazor_PivotView_PivotFieldListEvents_1_EnginePopulated) is triggered in field list whenever the report gets modified. The updated report is passed to the pivot table via [`UpdateViewAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotFieldList-1.html#Syncfusion_Blazor_PivotView_SfPivotFieldList_1_UpdateView_System_Object_) method written within this event to refresh the same.

* Likewise, [`EnginePopulated`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_EnginePopulated) event is triggered in pivot table whenever the report gets modified. The updated report is passed to the field list via [`UpdateAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotFieldList-1.html#Syncfusion_Blazor_PivotView_SfPivotFieldList_1_Update_System_Object_) method written within this event to refresh the same.

The event [`EnginePopulated`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldListEvents-1.html#Syncfusion_Blazor_PivotView_PivotFieldListEvents_1_EnginePopulated) is triggered after engine is populated. It has following parameters - [`DataSourceSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.EnginePopulatedEventArgs.html#Syncfusion_Blazor_PivotView_EnginePopulatedEventArgs_DataSourceSettings), [`PivotFieldList`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.EnginePopulatedEventArgs.html#Syncfusion_Blazor_PivotView_EnginePopulatedEventArgs_PivotFieldList) and [`PivotValues`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.EnginePopulatedEventArgs.html#Syncfusion_Blazor_PivotView_EnginePopulatedEventArgs_PivotValues).

> Note: This event is not required for Popup field list since it is a in built one.

```csharp
        <SfPivotView TValue="ProductDetails" ID="pivotview"  @ref="pivotView" Height="530">
            <PivotViewEvents TValue="ProductDetails" EnginePopulated="pivotenginepopulated"></PivotViewEvents>
        </SfPivotView>
        <SfPivotFieldList TValue="ProductDetails" ID="fieldlist" @ref="fieldList" RenderMode="Mode.Fixed" >
            <PivotFieldListDataSourceSettings DataSource="@data" EnableSorting=true>
                <PivotFieldListColumns>
                    <PivotFieldListColumn Name="Year"></PivotFieldListColumn>
                    <PivotFieldListColumn Name="Quarter"></PivotFieldListColumn>
                </PivotFieldListColumns>
                <PivotFieldListRows>
                    <PivotFieldListRow Name="Country"></PivotFieldListRow>
                    <PivotFieldListRow Name="Products"></PivotFieldListRow>
                </PivotFieldListRows>
                <PivotFieldListValues>
                    <PivotFieldListValue Name="Sold" Caption="Unit Sold"></PivotFieldListValue>
                    <PivotFieldListValue Name="Amount" Caption="Sold Amount"></PivotFieldListValue>
                </PivotFieldListValues>
            </PivotFieldListDataSourceSettings>
            <PivotFieldListEvents TValue="ProductDetails" EnginePopulated="enginepopulated"></PivotFieldListEvents>
        </SfPivotFieldList>
        <style>
            #fieldlist {
                width: 42%;
                height: 100%;
                float: right;
            }

            #pivotview {
                width: 57%;
                height: 530px;
                float: left;
            }
        </style>
        @code{
            SfPivotFieldList<ProductDetails> fieldList;
            SfPivotView<ProductDetails> pivotView;
            public List<ProductDetails> data { get; set; }
            protected override void OnInitialized()
            {
                this.data = ProductDetails.GetProductData();
            }

            public void pivotenginepopulated(EnginePopulatedEventArgs args)
            {
                this.fieldList.UpdateAsync(this.pivotView);
            }
            public void enginepopulated(EnginePopulatedEventArgs args)
            {
                this.fieldList.UpdateViewAsync(this.pivotView);
            }
        }

```

### FieldListRefreshed

The event [`FieldListRefreshed`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_FieldListRefreshed) is triggered whenever there is any change done in the field list UI. It has following parameter - [`DataSourceSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FieldListRefreshedEventArgs.html#Syncfusion_Blazor_PivotView_FieldListRefreshedEventArgs_DataSourceSettings) and [`PivotValues`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FieldListRefreshedEventArgs.html#Syncfusion_Blazor_PivotView_FieldListRefreshedEventArgs_PivotValues). It allows user to identify each field list update. This event is applicable only for static field list.

```csharp
    <SfPivotView TValue="ProductDetails" ID="pivotview"  @ref="pivotView" Height="530">
        <PivotViewEvents TValue="ProductDetails" FieldListRefreshed="fieldlistrefresh" EnginePopulated="pivotenginepopulated"></PivotViewEvents>
    </SfPivotView>
    <SfPivotFieldList TValue="ProductDetails" ID="fieldlist" @ref="fieldList" RenderMode="Mode.Fixed" >
        <PivotFieldListDataSourceSettings DataSource="@data" EnableSorting=true>
            <PivotFieldListColumns>
                <PivotFieldListColumn Name="Year"></PivotFieldListColumn>
                <PivotFieldListColumn Name="Quarter"></PivotFieldListColumn>
            </PivotFieldListColumns>
            <PivotFieldListRows>
                <PivotFieldListRow Name="Country"></PivotFieldListRow>
                <PivotFieldListRow Name="Products"></PivotFieldListRow>
            </PivotFieldListRows>
            <PivotFieldListValues>
                <PivotFieldListValue Name="Sold" Caption="Unit Sold"></PivotFieldListValue>
                <PivotFieldListValue Name="Amount" Caption="Sold Amount"></PivotFieldListValue>
            </PivotFieldListValues>
        </PivotFieldListDataSourceSettings>
        <PivotFieldListEvents TValue="ProductDetails" EnginePopulated="enginepopulated"></PivotFieldListEvents>
    </SfPivotFieldList>
    <style>
        #fieldlist {
            width: 42%;
            height: 100%;
            float: right;
        }

        #pivotview {
            width: 57%;
            height: 530px;
            float: left;
        }
    </style>
    @code{
        SfPivotFieldList<ProductDetails> fieldList;
        SfPivotView<ProductDetails> pivotView;
        public List<ProductDetails> data { get; set; }
        protected override void OnInitialized()
        {
            this.data = ProductDetails.GetProductData();
        }

        public void pivotenginepopulated(EnginePopulatedEventArgs args)
        {
            this.fieldList.UpdateAsync(this.pivotView);
        }
        public void enginepopulated(EnginePopulatedEventArgs args)
        {
            this.fieldList.UpdateViewAsync(this.pivotView);
        }
        private void fieldlistrefresh(FieldListRefreshedEventArgs args)
        {
            //args -> Can get the report and engine.
        }
    }

```

### FieldDropped

The event [`FieldDropped`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotFieldListEvents-1.html#Syncfusion_Blazor_PivotView_PivotFieldListEvents_1_FieldDropped) fires whenever a field is dropped in an axis. It has following parameters - [`DroppedAxis`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FieldDroppedEventArgs.html#Syncfusion_Blazor_PivotView_FieldDroppedEventArgs_DroppedAxis), [`DroppedField`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FieldDroppedEventArgs.html#Syncfusion_Blazor_PivotView_FieldDroppedEventArgs_DroppedField) and [`DataSourceSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FieldDroppedEventArgs.html#Syncfusion_Blazor_PivotView_FieldDroppedEventArgs_DataSourceSettings). In this illustration, we have modified the [`DroppedField`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.FieldDroppedEventArgs.html#Syncfusion_Blazor_PivotView_FieldDroppedEventArgs_DroppedField) caption through this event at runtime.

```csharp
    @using Syncfusion.Blazor.PivotView

    <SfPivotView TValue="ProductDetails" ShowFieldList="true">
            <PivotViewDataSourceSettings DataSource="@data">
                <PivotViewColumns>
                    <PivotViewColumn Name="Year"></PivotViewColumn>
                    <PivotViewColumn Name="Quarter"></PivotViewColumn>
                </PivotViewColumns>
                <PivotViewRows>
                    <PivotViewRow Name="Country"></PivotViewRow>
                    <PivotViewRow Name="Products"></PivotViewRow>
                </PivotViewRows>
                <PivotViewValues>
                    <PivotViewValue Name="Sold" Caption="Units Sold"></PivotViewValue>
                    <PivotViewValue Name="Amount" Caption="Sold Amount"></PivotViewValue>
                </PivotViewValues>
                <PivotViewFormatSettings>
                    <PivotViewFormatSetting Name="Amount" Format="C"></PivotViewFormatSetting>
                </PivotViewFormatSettings>
            </PivotViewDataSourceSettings>
            <PivotViewEvents TValue="ProductDetails" FieldDropped="fielddropped"></PivotViewEvents>
    </SfPivotView>

    @code{
        public List<ProductDetails> data { get; set; }
        protected override void OnInitialized()
        {
            this.data = ProductDetails.GetProductData().ToList();
            //Bind the data source collection here. Refer "Assigning sample data to the pivot table" section in getting started for more details.
        }
        public void fielddropped(FieldDroppedEventArgs args)
        {
            args.DroppedField.Caption = args.DroppedField.Name + " --> " + args.DroppedAxis;
        }
    }

```

![output](images/fielddropped_fieldlist.png)

> You can also explore our [Blazor Pivot Table example](https://blazor.syncfusion.com/demos/pivot-table/default-functionalities?theme=bootstrap4) to knows how to render and configure the pivot table.