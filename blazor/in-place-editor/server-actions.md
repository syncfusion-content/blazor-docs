---
layout: post
title: Server Actions in Blazor In-place Editor Component | Syncfusion
description: Checkout and learn here all about Server Actions in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In-place Editor 
documentation: ug
---

# Server Actions in Blazor In-place Editor Component

When posting the In-place Editor value to a remote server, the `PrimaryKey` property is required to identify the record on the server. Without a `PrimaryKey`, the save action is not performed.

If the `SaveUrl` property is not set, data changes are handled locally by the component. In this case, the `OnActionSuccess` event still fires, but the event argument value is `null` because no server response is available.

N> The following arguments are sent to the server when a submit action is performed.

| Arguments  | Explanation                                              |
|------------|-----------------------------------------------------------|
| Value      | The edited value used for updating the data store.       |
| PrimaryKey | The unique identifier used to map the edited value to a record. |

Find the following sample server code for defining models and controller functions to configure processing data.

```csharp
public class SubmitModel
{
    public string Name { get; set; }
    public string PrimaryKey { get; set; }
    public string Value { get; set; }
}
```

```csharp

public IEnumerable<SubmitModel> UpdateData([FromBody]SubmitModel value)
{
    // User can process data
    return value;
}

```

- When the server action completes successfully, the `OnActionSuccess` event is triggered with the returned server data.
- If the server request fails (for example, network error or non-success status code), the `OnActionFailure` event is triggered. In this case, the value in the editor is not updated.

In the following sample, the `OnActionSuccess` event is triggered after the value is successfully submitted to the server.

```csharp

@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.InPlaceEditor
@using Syncfusion.Blazor;

<table class="table-section">
    <tr>
        <td class="sample-td"> Enter your name: </td>
        <td class="sample-td">
            <SfInPlaceEditor Type="Syncfusion.Blazor.InPlaceEditor.InputType.MultiSelect" @bind-Value="@MultiSelectValue" SubmitOnEnter="true" Name="Skill" SaveUrl="https://ej2services.syncfusion.com/production/web-services/api/Editor/UpdateData" PrimaryKey="FrameWork" Adaptor="Adaptors.UrlAdaptor" TValue="string[]">
                <EditorComponent>
                    <SfMultiSelect TValue="string[]" TItem="Program" Placeholder="Select skill" Mode="VisualMode.Box" @bind-Value="@MultiSelectValue" DataSource="@Games">
                        <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
                    </SfMultiSelect>
                </EditorComponent>
                <InPlaceEditorEvents OnActionSuccess="@OnSuccess" TValue="string[]"></InPlaceEditorEvents>
            </SfInPlaceEditor>
        </td>
    </tr>
</table>

<style>
    .table-section {
        margin: 0 auto;
    }

    tr td:first-child {
        text-align: right;
        padding-right: 20px;
    }

    .sample-td {
        padding-top: 10px;
        min-width: 230px;
        height: 100px;
    }
</style>

@code {
    public string[] MultiSelectValue = new string[] { "Js", "Jq" };

    public class Program
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    private List<Program> Games = new List<Program>()
    {
        new Program(){ ID= "Ad", Text= "Android" },
        new Program(){ ID= "Js", Text= "JavaScript" },
        new Program(){ ID= "Jq", Text= "jQuery" },
        new Program(){ ID= "Ts", Text= "TypeScript" },
        new Program(){ ID= "Ag", Text= "Angular" },
        new Program(){ ID= "Re", Text= "React" },
        new Program(){ ID= "Vu", Text= "Vue" },
        new Program(){ ID= "Io", Text= "Ionic"}
    };

    public void OnSuccess(ActionEventArgs<string[]> args)
    {
        Console.WriteLine("Event is triggered");
    }
}


```