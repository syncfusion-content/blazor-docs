---
layout: post
title: Create Blazor TextBox component dynamically | Syncfusion
description: Learn here all about how to create TextBox component dynamically in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Create TextBox component dynamically in Blazor TextBox Component

The TextBox component can be rendered at runtime in the following ways:

1. Using RenderTreeBuilder

2. Using RenderFragment

## Dynamic rendering using RenderTreeBuilder

The RenderTreeBuilder class will let to create required content or component in dynamic manner at runtime. In the following code example, the TextBox Component has been created at runtime through button click.

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

By using RenderFragment, the templated component can be reused in more than one place. The specific fragment value alone can be changed without re-rendering the entire component. In the following example, a single text box has been created and updated the placeholder value at runtime.

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

![Blazor TextBox with Render Fragment](../images/blazor-textbox-render-fragment.png)