---
layout: post
title: Integrate HTML5 Components in Blazor In-place Editor | Syncfusion
description: Learn here all about Integrate HTML5 Components in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In-place Editor 
documentation: ug
---

# Integrate HTML5 Components in Blazor In-place Editor Component

The In-place Editor supports integrating custom HTML5 input elements by using the `InPlaceEditorTemplate` property. The Template property can be given as follows.

```cshtml
<InPlaceEditorTemplate>
   <input id="date" type="text" />
</InPlaceEditorTemplate>

```

In Template mode, the `Value` property cannot be handled by the In-place Editor component. So, before sending a value to the server, you need to modify the `OnActionSuccess` event, otherwise, an empty string will be passed.

In the following template example, the input is bound and, before submitting data to the server, the event argument and `Value` are updated in the `OnActionSuccess` event handler.

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


![Integrating an HTML template in Blazor In-place Editor](./images/blazor-inplace-editor-html-template.png)

## See Also

* [Built-in Controls](./controls)