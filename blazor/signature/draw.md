---
layout: post
title: Draw with Blazor Signature Component | Syncfusion
description: Checkout how to draw the text as a signature with Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# Draw a Signature in Blazor Signature component

## Draw

The text can be drawn as [Blazor Signature](https://www.syncfusion.com/blazor-components/blazor-signature) using the [`DrawAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_DrawAsync_System_String_System_String_System_Int32_) method with different font families like Arial, Serif, with different font sizes. This method accepts signature text, font family, font size as its parameters. The default font family is "Arial" and the default font size is "30".

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<div>
    <div class="e-sign-heading">
        <div class="e-header-item">
            <SfTextBox CssClass="e-outline" @ref="text" Placeholder='Enter the text'></SfTextBox>
        </div>
        <div class="e-header-item">
           <SfDropDownList TItem="fontFields" TValue="string" PopupHeight="200px" @bind-Value="@Value" DataSource="@font">
                <DropDownListFieldSettings Text="Text" Value="Text" />
            </SfDropDownList>
        </div>
        <div class="e-header-item">
            <SfDropDownList TItem="sizeFields" TValue="int" PopupHeight="200px" @bind-Value="@size" DataSource="@sizes">
                <DropDownListFieldSettings Text="Text" Value="Text" />
            </SfDropDownList>
        </div>
        <span class="e-btn-options">
            <SfButton IsPrimary="true" @onclick="OnDraw">Draw</SfButton>
        </span>
    </div>
    <div class='e-sign-content'>
        <SfSignature @ref="signature" style="width: 400px; height: 300px;"></SfSignature>
    </div>
</div>


@code{
    private SfSignature signature;
    private SfTextBox text;
    public string Value = "Arial";
    public int size = 20;
    public class fontFields
    {
        public string Text { get; set; }
    }
    private List<fontFields> font = new List<fontFields>()
    {
        new fontFields(){ Text= "Arial" },
        new fontFields(){ Text= "Serif" },
        new fontFields(){ Text= "Sans-serif" },
        new fontFields(){ Text= "Cursive" },
        new fontFields(){ Text= "Fantasy" },
     };
    public class sizeFields
    {
        public int Text { get; set; }
    }
    private List<sizeFields> sizes = new List<sizeFields>()
    {
        new sizeFields(){ Text= 20 },
        new sizeFields(){ Text= 30 },
        new sizeFields(){ Text= 40 },
        new sizeFields(){ Text= 50 }
     };
    private async void OnDraw()
    {
        await signature.DrawAsync(text.Value, Value, size);
    }
}

<style>
    .e-sign-content,
    .e-sign-heading {
        width: 400px;
    }

    #signdescription {
        font-size: 14px;
        padding-bottom: 10px;
    }

    .e-btn-options {
        float: right;
        margin: 0px 0px 10px;
    }

    .e-header-item {
        padding-bottom: 10px;
    }
</style>
```

![Blazor Signature Component](./images/blazor-signature-draw.png)