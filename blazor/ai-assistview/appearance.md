---
layout: post
title: Appearance in Blazor AI AssistView Component | Syncfusion
description: Checkout and learn here all about Appearance with Syncfusion Blazor AI AssistView component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Appearance in Blazor AI AssistView component

## Setting width

You can use the `Width` property to set the width of the AI AssistView.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px;">
    <SfAIAssistView Width="650px" PromptRequested="@PromptRequest"></SfAIAssistView>
</div>

@code {
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = defaultResponse;
    }
}

```

![Blazor AI AssistView Width](./images/ai-assistview-width.png)

## Setting height

You can use the `Height` property to set the height of the AI AssistView.

> By default, the component `Width` & `Height` will be inherited based on the parent dimensions.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 450px; width: 650px;">
    <SfAIAssistView Height="350px" PromptRequested="@PromptRequest"></SfAIAssistView>
</div>

@code {
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = defaultResponse;
    }
}

```

![Blazor AI AssistView Height](./images/ai-assistview-height.png)

## CssClass

You can customize the appearance of the AI AssistView component by using the `CssClass` property.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView CssClass="e-custom" PromptRequested="@PromptRequest"></SfAIAssistView>
</div>

@code {
    private async Task PromptRequest(AssistViewPromptRequestedEventArgs args)
    {
        await Task.Delay(1000);
        var defaultResponse = "For real-time prompt processing, connect the AI AssistView component to your preferred AI service, such as OpenAI or Azure Cognitive Services. Ensure you obtain the necessary API credentials to authenticate and enable seamless integration.";
        args.Response = defaultResponse;
    }
}
<style>
    .e-aiassistview.e-custom {
        border-color: #e0e0e0;
        background-color: #f4f4f4;
        box-shadow: 3px 3px 10px 0px rgba(0, 0, 0, 0.2);
    }

    .e-aiassistview.e-custom .e-view-header .e-toolbar, .e-aiassistview.e-custom .e-view-header .e-toolbar-items {
        background: #d5d5d5;
    }

    .e-aiassistview.e-custom .e-view-content .e-input-group {
        border: 3px solid #e0e0e0;
    }
</style>

```

![Blazor AI AssistView Custom Class](./images/ai-assistview-custom-class.png)
