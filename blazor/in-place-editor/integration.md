---
layout: post
title: Integrate HTML5 Components in Blazor In-place Editor | Syncfusion
description: Integrate custom HTML5 input elements into Blazor In-place Editor using templates and handle values through events.
platform: Blazor
control: Blazor  In-place Editor 
documentation: ug
---

# Integrate HTML5 Components in Blazor In-place Editor

The Blazor  In-place Editor supports integrating custom HTML5 input elements by using the `InPlaceEditorTemplate` child tag. The template content can be defined as follows.

```cshtml
<InPlaceEditorTemplate>
   <input id="date" type="text" />
</InPlaceEditorTemplate>

```

In Template mode, the `Value` property cannot be handled by the Blazor  In-place Editor component. Therefore, before sending a value to the server, you must update the value through the `OnActionSuccess` event; otherwise, an empty string is sent.

In the following template example, the input is bound to a value, and before submitting data to the server, the event argument and `Value` are updated in the `OnActionSuccess` event handler.

```cshtml

@using Syncfusion.Blazor.InPlaceEditor

<div id='container'>
    <span class="content-title"> Select date: </span>
    <SfInPlaceEditor @ref="InplaceditorObj" EmptyText="Value" TValue="string" @bind-Value="@inplaceValue" Mode="RenderMode.Inline" Type="InputType.Template">
        <InPlaceEditorTemplate>
            <input @bind-value="@inplaceValue" id="date" type="text" />
        </InPlaceEditorTemplate>
        <InPlaceEditorEvents TValue="string" OnActionSuccess="OnSuccess"></InPlaceEditorEvents>
    </SfInPlaceEditor>
</div>

<style>
    #container {
        display: flex;
        justify-content: center;
    }

    #InplaceDate {
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
    SfInPlaceEditor<string> InplaceditorObj;

    public string inplaceValue { get; set; } = "syncfusion";

    private void OnSuccess(ActionEventArgs<string> args)
    {
        inplaceValue = args.Value;
    }
}

```


![Integrating an HTML template in Blazor In-place Editor](./images/blazor-inplace-editor-html-template.webp)

## See also

- [Built-in Controls](./controls)