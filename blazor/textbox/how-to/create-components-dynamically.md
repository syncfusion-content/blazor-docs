---
layout: post
title: Create Blazor TextBox component dynamically | Syncfusion
description: Learn here all about Create TextBox component dynamically in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Create TextBox component dynamically in Blazor TextBox Component

You can render the TextBox component at runtime in the following ways:

1. Using RenderTreeBuilder

2. Using RenderFragment

## Dynamic rendering using RenderTreeBuilder

The RenderTreeBuilder class will let you create required content or component in dynamic manner at runtime. In the following code example, the TextBox Component has been created at runtime through button click.

```csharp

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

You will get the output as follows.
![renderFragment](../images/renderFragment.png)

## Dynamic rendering using RenderFragment

By using RenderFragment, you can reuse the Templated component in more than one place. You can change the specific fragment value alone without re-rendering the entire component. In the following example,  a single text box has been created and updated the placeholder value at runtime.

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

You will get the output as follows.
![renderFragment](../images/renderFragment.png)