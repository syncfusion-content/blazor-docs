---
layout: post
title: Server Actions in Blazor In-place Editor Component | Syncfusion
description: Checkout and learn here all about Server Actions in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In Place Editor 
documentation: ug
---

# Server Actions in Blazor In-place Editor Component

When sending the In-place Editor component value to a remote server, the `PrimaryKey` property value is required. Otherwise, the action will not be performed.

If the `SaveURL` property value is empty, data changes will be handled locally. The `OnActionSuccess` event will trigger with `null` as the argument value.

N> The following arguments are passed to the server when the submit actions are performed.

| Arguments  | Explanations                                              |
|------------|-----------------------------------------------------------|
| Value      | For processing edited value, like DB value updating.      |
| PrimaryKey | For value mapping to the server, like selecting DB.       |

Find the following sample server codes for defining models and controller functions to configure processing data.

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

* Server actions successfully done, the `OnActionSuccess` event will be fired with returned server data.

* If the server is not responding, the `OnActionFailure` event will be fired with data, but value not updated in the Editor.

In the following sample, the `OnActionSuccess` event will trigger once the value submitted successfully into the server.

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
                    <SfMultiSelect Placeholder="Select skill" Mode="VisualMode.Box" @bind-Value="@MultiSelectValue" DataSource="@DataSource">
                        <MultiSelectFieldSettings Text="Text" Value="ID"></MultiSelectFieldSettings>
                    </SfMultiSelect>
                </EditorComponent>
                <InPlaceEditorEvents OnActionSuccess="OnSuccess" TValue="string"></InPlaceEditorEvents>
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
    public string[] MultiSelectValue = new string[] { "JavaScript", "jQuery" };

    public string[] DataSource = new string[] { "Android", "JavaScript", "jQuery", "TypeScript", "Angular", "React", "Vue", "Ionic" };

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

    public void OnSuccess(ActionEventArgs<string> args)
    {
        Console.WriteLine("Event is triggered");
    }
}


```
