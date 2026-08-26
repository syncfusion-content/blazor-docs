---
layout: post
title: Data Binding in Blazor In-place Editor | Syncfusion
description: Bind local or remote data to editor components inside Blazor In-place Editor using arrays or DataManager.
platform: Blazor
control: Blazor  In-place Editor 
documentation: ug
---

# Data Binding in Blazor In-place Editor

The editor components load data either from local data sources or remote data services using the `DataSource` property, and the data type can be an array or a `DataManager`. The `DataManager` also supports different data services such as OData, OData V4, and Web API, as well as data formats such as XML, JSON, and JSONP, with the help of `DataManager` adaptors.

## Local

To bind local data to the editor components, assign an array of objects or strings to the `DataSource` property. The local data source can also be provided as an instance of the `DataManager`.

```csharp

@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.InPlaceEditor

<div id="container">
    <span class="content-title"> Select customer name: </span>
    <SfInPlaceEditor @bind-Value="@DropDownValue" Type="Syncfusion.Blazor.InPlaceEditor.InputType.DropDownList" TValue="string">
        <EditorComponent>
            <SfDropDownList TItem="string" TValue="string" Placeholder="Select a customer" @bind-Value="@DropDownValue" DataSource="@DataManager">
            </SfDropDownList>
        </EditorComponent>
    </SfInPlaceEditor>
</div>

<style>
    #container {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 80px;
    }

    #element {
        width: 150px;
    }

    .content-title {
        font-weight: 500;
        margin-right: 20px;
        display: flex;
        align-items: center;
    }
</style>

@code {
    public string DropDownValue = "Maria Anders";
    public static string[] DataManager = new string[] { "Maria Anders", "Ana Trujillo", "Antonio Moreno", "Thomas Hardy", "Chiristina Berglund", "Hanna Moos" };

}

```


![Data Binding in Blazor In-place Editor](./images/blazor-inplace-editor-data-binding.webp)