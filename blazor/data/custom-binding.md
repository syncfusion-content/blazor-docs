---
layout: post
title: Custom Binding in Blazor DataManager | Syncfusion
description: Learn how to implement custom binding in Syncfusion Blazor DataManager for flexible data operations and CRUD integration with DataGrid.
platform: Blazor
control: DataManager
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Custom Binding in Blazor DataManager Component

Custom binding in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.htm) component provides a mechanism to implement custom logic for data retrieval and manipulation. It allows defining how data operations are executed by creating a [custom adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_CustomAdaptor) that overrides default behavior.

Custom binding is applicable in scenarios where:

* Data originates from sources that do not conform to standard adaptors, such as **REST APIs** or **in-memory collections**.
* Complete control over data operations is required, including applying custom business rules during **CRUD** operations.
* Built-in adaptors do not meet requirements for data transformation or filtering.

The [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) class is an abstract base that defines the interaction between the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component and an external data source. A custom adaptor derived from this class can override its virtual members to implement custom **data retrieval** and **CRUD** operations. These members include both synchronous and asynchronous methods such as **Read**, **Insert**, **Update**, **Remove**, and **BatchUpdate**, providing complete flexibility for integrating any data source while maintaining compatibility with Blazor [DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) and other bound controls.

```csharp
public abstract class DataAdaptor
{
    /// <summary>
    /// Performs data read operation synchronously.
    /// </summary>
    public virtual object Read(DataManagerRequest dataManagerRequest, string key = null)

    /// <summary>
    /// Performs data read operation asynchronously.
    /// </summary>
    public virtual Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)

    /// <summary>
    /// Performs insert operation synchronously.
    /// </summary>
    public virtual object Insert(DataManager dataManager, object data, string key)
    /// <summary>
    /// Performs insert operation asynchronously.
    /// </summary>
    public virtual Task<object> InsertAsync(DataManager dataManager, object data, string key)

    /// <summary>
    /// Performs remove operation synchronously.
    /// </summary>
    public virtual object Remove(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs remove operation asynchronously.
    /// </summary>
    public virtual Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs update operation synchronously.
    /// </summary>
    public virtual object Update(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs update operation asynchronously.
    /// </summary>
    public virtual Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs batch CRUD operations synchronously.
    /// </summary>
    public virtual object BatchUpdate(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)

    /// <summary>
    /// Performs batch CRUD operations asynchronously.
    /// </summary>
    public virtual Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
}
```

## Perform Data Operations

Custom binding enables client-side operations such as **searching**, **sorting**, **filtering**, **paging**, and **aggregation** when using a [CustomAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_CustomAdaptor). These operations are implemented by overriding the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor-1.html#Syncfusion_Blazor_DataAdaptor_1_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor-1.html#Syncfusion_Blazor_DataAdaptor_1_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) abstract class.

The [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object provides details for each operation, including search criteria, sort descriptors, filter conditions, and paging parameters. These can be applied using built-in methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) and [DataUtil](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html) classes:

* [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) – Applies search criteria to the collection.
* [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SortedColumn__) – Sorts the collection based on specified fields.
* [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) – Filters records using conditions.
*  [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Collections_Generic_IEnumerable___0__System_Int32_) – Skips a defined number of records for paging.
* [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Collections_Generic_IEnumerable___0__System_Int32_) – Takes a defined number of records for paging.
* [PerformAggregation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html#Syncfusion_Blazor_Data_DataUtil_PerformAggregation_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_Aggregate__) – Calculates aggregate values such as Sum, Average, Min, and Max for a collection.

> * When the [RequiresCounts](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html#Syncfusion_Blazor_DataManagerRequest_RequiresCounts) property of `DataManagerRequest` is **true**, the return type should be a [DataResult](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataResult.html) object containing:

>   * **Result** – The processed collection.
>   * **Count** – Total number of records.
>   * **Aggregate** (optional) – Aggregate values when aggregation is applied.

> * When `RequiresCounts` is **false**, return only the processed collection.
> * If the `Read` or `ReadAsync` method is not overridden in a custom adaptor, the default read handler processes the reques

## Perform CRUD Operations

Custom binding supports full **CRUD** functionality by overriding methods in the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) abstract class. These methods handle data manipulation for components bound to the `SfDataManager`.

The methods listed below provide signatures for both synchronous and asynchronous operations:

* **Create**

    * [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Insert_Syncfusion_Blazor_DataManager_System_Object_System_String_) / [InsertAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) – Adds new records.

* **Read**

    * [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor-1.html#Syncfusion_Blazor_DataAdaptor_1_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) / [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor-1.html#Syncfusion_Blazor_DataAdaptor_1_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) – Retrieves data from the data source.

* **Update**

    * [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Update_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) / [UpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) – Modifies existing records.

* **Delete**

    * [Remove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Remove_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) / [RemoveAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) – Deletes records.

* **Batch Operations**

    * [BatchUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdate_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) / [BatchUpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) – Handles batch operations for editing scenarios.

Overriding these methods enables custom logic for **creating**, **reading**, **updating**, and **deleting** data while maintaining compatibility with Syncfusion Blazor components such as [DataGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html).

## Implementing Custom Adaptor

Custom binding in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor `DataManager` component can be integrated with the `DataGrid` by creating a custom adaptor that defines data operations and CRUD functionality.

**Steps to implement custom binding and integrate with DataGrid**

1. **Create a custom adaptor**

* Derive a class from the `DataAdaptor` abstract base to implement custom logic for data retrieval and manipulation.

2. **Override required methods**

* For **data operations**, override `Read` or `ReadAsync` to apply **searching**, **sorting**, **filtering**, **paging**, and **aggregation** using the `DataOperations` and `DataUtil` classes.
* For **CRUD operations**, override `Insert`, `Update`, `Remove`, and `BatchUpdate` along with their asynchronous counterparts.

3. **Bind the custom adaptor to DataManager**

* Assign the custom adaptor type to the [AdaptorInstance](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_AdaptorInstance) property of the `SfDataManager` component.

4. **Configure the Grid for CRUD operations**

* Enable editing by setting the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) and [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) properties. Specify the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property as [EditMode.Normal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html#Syncfusion_Blazor_Grids_EditMode_Normal) to allow adding, updating, and deleting records.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" ID="Grid" AllowSorting="true" AllowFiltering="true" AllowPaging="true"
        Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public static List<Order> Orders { get; set; } = new();

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" }[new Random().Next(5)],
            Freight = 2.1 * x
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public double Freight { get; set; }
    }

    public class CustomAdaptor : DataAdaptor
    {
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<Order> dataSource = Orders;

            if (dm.Search?.Count > 0)
                dataSource = DataOperations.PerformSearching(dataSource, dm.Search);

            if (dm.Sorted?.Count > 0)
                dataSource = DataOperations.PerformSorting(dataSource, dm.Sorted);

            if (dm.Where?.Count > 0)
                dataSource = DataOperations.PerformFiltering(dataSource, dm.Where, dm.Where[0].Operator);

            int count = dataSource.Count();

            if (dm.Skip != 0)
                dataSource = DataOperations.PerformSkip(dataSource, dm.Skip);

            if (dm.Take != 0)
                dataSource = DataOperations.PerformTake(dataSource, dm.Take);

            return dm.RequiresCounts ? new DataResult() { Result = dataSource, Count = count } : (object)dataSource;
        }

        public override object Insert(DataManager dm, object value, string key)
        {
            Orders.Insert(0, value as Order);
            return value;
        }

        public override object Remove(DataManager dm, object value, string keyField, string key)
        {
            Orders.Remove(Orders.FirstOrDefault(or => or.OrderID == int.Parse(value.ToString())));
            return value;
        }

        public override object Update(DataManager dm, object value, string keyField, string key)
        {
            var data = Orders.FirstOrDefault(or => or.OrderID == (value as Order).OrderID);
            if (data != null)
            {
                data.CustomerID = (value as Order).CustomerID;
                data.Freight = (value as Order).Freight;
            }
            return value;
        }

        public override object BatchUpdate(DataManager dm, object changed, object added, object deleted, string keyField, string key, int? dropIndex)
        {
            if (changed is IEnumerable<Order> changedRecords)
            {
                foreach (var rec in changedRecords)
                {
                    var existing = Orders.FirstOrDefault(o => o.OrderID == rec.OrderID);
                    if (existing != null)
                        existing.CustomerID = rec.CustomerID;
                }
            }

            if (added is IEnumerable<Order> addedRecords)
            {
                foreach (var rec in addedRecords)
                    Orders.Add(rec);
            }

            if (deleted is IEnumerable<Order> deletedRecords)
            {
                foreach (var rec in deletedRecords)
                    Orders.RemoveAll(o => o.OrderID == rec.OrderID);
            }

            return Orders;
        }

    }
}
```

![Custom Binding in Blazor DataManager](./images/blazor-datamanager-custom-binding.gif)