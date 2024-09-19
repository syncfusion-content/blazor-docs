---
layout: post
title: Custom views in Blazor AI AssistView Component | Syncfusion
description: Checkout and learn here all about Custom views with Syncfusion Blazor AI AssistView component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Custom views in Blazor AI AssistView component

## Adding custom views

The Blazor AI AssistView allows you to add different views available for user interaction.

#### Setting view type

You can set the type of view by using the [AssistView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.AssistView.html) and [CustomView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.CustomView.html) tag directive.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView PromptRequested="@PromptRequest">
        <AssistViews>
            <AssistView></AssistView>
            <CustomView Header="Response">
                <ViewTemplate>
                    <div class="view-container"><h5>Response view content</h5></div>
                </ViewTemplate>
            </CustomView>
        </AssistViews>
    </SfAIAssistView>
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

![Blazor AI AssistView Types](./images/ai-assistview-type.png)

### Setting name

You can use the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.AssistView.html#Syncfusion_Blazor_InteractiveChat_AssistView_Header) property to specifies the header name of the `Assist` or `Custom` views in the AI AssistView.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView PromptRequested="@PromptRequest">
        <AssistViews>
            <AssistView Header="Prompt"></AssistView>
            <CustomView Header="Response">
                <ViewTemplate>
                    <div class="view-container"><h5>Response view content</h5></div>
                </ViewTemplate>
            </CustomView>
        </AssistViews>
    </SfAIAssistView>
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

![Blazor AI AssistView type Header](./images/ai-assistview-type-header.png)

### Setting iconCss

You can customize the view icons by using the [IconCss](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.AssistView.html#Syncfusion_Blazor_InteractiveChat_AssistView_IconCss) property. By default the `e-assistview-icon` class is added as built-in header icon for the AI AssistView.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView PromptRequested="@PromptRequest">
        <AssistViews>
            <AssistView Header="Prompt" IconCss="e-assistview-icon"></AssistView>
            <CustomView Header="Response" IconCss="e-comment-show">
                <ViewTemplate>
                    <div class="view-container"><h5>Response view content</h5></div>
                </ViewTemplate>
            </CustomView>
        </AssistViews>
    </SfAIAssistView>
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

![Blazor AI AssistView type IconCss](./images/ai-assistview-type-icon.png)

### Setting view template 

You can use the [ViewTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.AssistView.html#Syncfusion_Blazor_InteractiveChat_AssistView_ViewTemplate) tag directive to add the view content of the multiple views added in the AI AssistView.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="width: max(50%, 500px); margin: 30px auto;">
    <SfAIAssistView>
        <AssistViews>
            <AssistView Header="Prompt">
                <ViewTemplate>
                    <div class="view-container"><h5>Prompt view content</h5></div>
                </ViewTemplate>
            </AssistView>
            <CustomView Header="Response">
                <ViewTemplate>
                    <div class="view-container"><h5>Response view content</h5></div>
                </ViewTemplate>
            </CustomView>
        </AssistViews>
    </SfAIAssistView>
</div>

<style>
    .view-container {
        margin: 20px auto;
        width: 80%;
    }
</style>

```

![Blazor AI AssistView assist ViewTemplate](./images/ai-assistview-prompt-template.png)
![Blazor AI AssistView custom ViewTemplate](./images/ai-assistview-response-template.png)

#### Show or hide clear button

You can use the [ShowClearButton](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.AssistView.html#Syncfusion_Blazor_InteractiveChat_AssistView_ShowClearButton) property using the `AssistView` tag directive to show or hide the clear button. By default, its value is `false`, when the clear button is clicked, the prompt text entered will be cleared.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView Prompt="What tools or apps can help me prioritize tasks?" PromptRequested="@PromptRequest">
        <AssistViews>
            <AssistView ShowClearButton=true></AssistView>
        </AssistViews>
    </SfAIAssistView>
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

![Blazor AI AssistView ClearButton](./images/ai-assistview-clear-btn.png)

## Setting active view

You can use the [ActiveView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.InteractiveChat.SfAIAssistView.html#Syncfusion_Blazor_InteractiveChat_SfAIAssistView_ActiveView) property set the active view in the AI AssistView. By default, the value is `0`.

```cshtml

@using Syncfusion.Blazor.InteractiveChat

<div class="aiassist-container" style="height: 350px; width: 650px;">
    <SfAIAssistView PromptRequested="@PromptRequest" ActiveView="1">
        <AssistViews>
            <AssistView></AssistView>
            <CustomView Header="Response" IconCss="e-icons e-comment-show">
                <ViewTemplate>
                    <div class="view-container"><h5>Response view content</h5></div>
                </ViewTemplate>
            </CustomView>
        </AssistViews>
    </SfAIAssistView>
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
    .view-container {
        height: inherit;
        display: flex;
        align-items: center;
        justify-content: center;
    }
</style>

```

![Blazor AI AssistView ActiveView](./images/ai-assistview-activeview.png)