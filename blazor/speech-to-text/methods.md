---
layout: post
title: Methods in Blazor SpeechToText Component | Syncfusion
description: Checkout and learn about Methods in Blazor SpeechToText component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeechToText
documentation: ug
---

# Methods in Blazor SpeechToText component

## Start listening

You can use the [StartListeningAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_StartListeningAsync) public method to initiate the speech recognition and begins the conversion of the speech to text.

## Stop listening

You can use the [StopListeningAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_StopListeningAsync) public method to stop capturing your speech and ends the speech recognition.

Below sample demonstrates the SpeechToText component configured with above methods.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div class="speechtext-container">
    <div class="actions">
        <SfButton Content="Start Listening" OnClick="TriggerStartListening"></SfButton>
        <SfButton Content="Stop Listening" OnClick="TriggerStopListening"></SfButton>
    </div>
    <SfSpeechToText @ref="@speechToText" @bind-Transcript="@transcript"> </SfSpeechToText>
    <SfTextArea RowCount="5" ColumnCount="50" @bind-Value="@transcript" ResizeMode="Resize.None" Placeholder="Transcribed text will be shown here..."></SfTextArea>
</div>

@code {
    SfSpeechToText speechToText;
    string transcript = "";

    private async Task TriggerStartListening()
    {
        await speechToText.StartListeningAsync();
    }

    private async Task TriggerStopListening()
    {
        await speechToText.StopListeningAsync();
    }

}

<style>
    .speechtext-container {
        margin: 50px auto;
        gap: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor SpeechToText with Start and Stop Listening Methods](images/methods.png)