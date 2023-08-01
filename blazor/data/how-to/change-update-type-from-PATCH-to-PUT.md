---
layout: post
title: change the update type from PATCH to PUT in Blazor DataManager Component | Syncfusion
description: Checkout and learn here all about changing the update type from PATCH to PUT in Syncfusion Blazor DataManager component and more.
platform: Blazor
control: DataManager
documentation: ug
---

<!-- markdownlint-disable MD024 -->

# Change the update type from PATCH to PUT

In ODataV4, the PATCH method is the preferred means of updating data, and it is used for partial updates of data. So, to update the entire data collection we can use PUT method.

By using [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) instance, we can change the default UpdateType request from "PATCH" to "PUT.

Here, in the below sample the update type is changed to PUT inside OnAfterRender method. So, the default **PATCH** request will be changed to **PUT**.

```cshtml
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids


<SfGrid TValue="OrgUnit" AllowPaging="true" AllowFiltering=true AllowGrouping=true Toolbar="@ToolbarItems">
    <GridPageSettings PageSize="50" />
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="Syncfusion.Blazor.Grids.EditMode.Normal" />
    <SfDataManager Url="odata/OrgUnits" @ref="DM" Adaptor="Adaptors.ODataV4Adaptor" Key="Id" />
    <GridColumns>
        <GridColumn Field="@nameof(Organization.Id)" Width=120 IsPrimaryKey="true" />
        <GridColumn Field="@nameof(Organization.ParentId)" Width=100 />
        <GridColumn Field="@nameof(Organization.Summary)" Width=100 />      
    </GridColumns>
</SfGrid>

@code {
    public ODataV4CRUDSample.Shared.OrgUnit Organization;
    SfDataManager DM { get; set; }
    public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Cancel", "Update"};

    protected override void OnAfterRender(bool firstRender)

    {
     base.OnAfterRender(firstRender);

        if (DM != null)
        {
            RemoteOptions Rm = (DM.DataAdaptor as ODataV4Adaptor).Options;
            Rm.UpdateType = HttpMethod.Put;
            (DM.DataAdaptor as ODataV4Adaptor).Options = Rm;
        }
    }
}

```
N> You can find the sample in this GitHub location