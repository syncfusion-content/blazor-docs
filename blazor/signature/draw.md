---
layout: post
title: Draw with Blazor Signature Component | Syncfusion
description: Checkout and learn about getting started with Blazor Signature component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: Signature
documentation: ug
---

# Draw a Signature in Blazor Signature component

## Draw

The signature control draws the text as signature using the [`DrawAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSignature.html#Syncfusion_Blazor_Inputs_SfSignature_DrawAsync_System_String_System_String_System_Int32_) method with different font families like Arial, Serif, with different font sizes.

```cshtml
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.DropDowns

<SfSignature @ref="signature"></SfSignature>
 
<SfTextBox CssClass="e-outline" @ref="text" Placeholder='Enter the text'></SfTextBox>
<SfDropDownList TItem="fontFields" TValue="string" PopupHeight="200px" @bind-Value="@Value" DataSource="@font">
    <DropDownListFieldSettings Text="Text" Value="Text" />
</SfDropDownList>
<SfDropDownList TItem="sizeFields" TValue="int" PopupHeight="200px" @bind-Value="@size" DataSource="@sizes">
    <DropDownListFieldSettings Text="Text" Value="Text" />
</SfDropDownList>
<SfButton @onclick="onDraw">DRAW</SfButton>
    
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
    private void onDraw()
    {
        signature.DrawAsync(text.Value, Value, size);
    }
}
```

![Blazor Signature Component](./images/blazor-signature-draw.png)