---
layout: post
title: Create Blazor TextBox component dynamically | Syncfusion
description: Learn here all about how to create TextBox component dynamically in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Create TextBox component dynamically in Blazor TextBox Component

The Blazor TextBox can be rendered at runtime in two common ways:
1. Using RenderTreeBuilder (imperative component construction)
2. Using RenderFragment (declarative fragment reuse)

## Dynamic rendering using RenderTreeBuilder

Use `RenderTreeBuilder` to construct a component tree programmatically. In the following example, a TextBox component is created at runtime when a button is clicked and rendered into a placeholder fragment.

```cshtml

@using Microsoft.AspNetCore.Components;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.Inputs;

    <div id="component-container">
        @DynamicRender
    </div>

<SfButton ID="dynamic-button" Content="Render TextBox" @onclick="RenderComponent"></SfButton>

@code {
    private RenderFragment DynamicRender { get; set; }  

    private RenderFragment CreateComponent() => builder =>
    {
        builder.OpenComponent(0, typeof(SfTextBox));
        builder.AddAttribute(1, "Placeholder", "Enter your text");
        builder.CloseComponent();
    };

    private void RenderComponent()
    {
        DynamicRender = CreateComponent();
    }
}

```

![Blazor TextBox with Render TreeBuilder](../images/blazor-textbox-render-fragment.png)

## Dynamic rendering using RenderFragment

Use a `RenderFragment` when you want to reuse a templated block and update parameters without reconstructing the component tree. In the next example, a single TextBox is created and its placeholder is updated at runtime.

```csharp

@using Microsoft.AspNetCore.Components;
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.Inputs;

<SfButton ID="dynamic-button" Content="Render TextBox" @onclick="ChangeAttribute"></SfButton>

<div id="component-container">
    @DynamicFragment
</div>

@code {
    private string dynamicContent = "Type here";

    protected override void OnInitialized()
    {
        DynamicFragment = builder =>
        {
            builder.OpenComponent(0, typeof(SfTextBox));
            builder.AddAttribute(1, "Placeholder", dynamicContent);
            builder.CloseComponent();
        };
    }

    private void ChangeAttribute()
    {
        dynamicContent = "Enter your text";
    }

    private Microsoft.AspNetCore.Components.RenderFragment DynamicFragment;
}

```


![Blazor TextBox updated with RenderFragment](../images/blazor-textbox-render-fragment.png)