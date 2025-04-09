---
layout: post
title: Speech recognition in Blazor SpeechToText Component | Syncfusion
description: Checkout and learn about Speech recognition in Blazor SpeechToText component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeechToText
documentation: ug
---

# Speech recognition in Blazor SpeechToText component

## Retrieving transcripts

You can use the [Transcript](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_Transcript) property to retrieve the transcribed text from the spoken text. This property allows to display the transcribed text once the speech recognition process is started.

{% tabs %}
{% highlight razor %}

<div class="speechtext-container">
    <SfSpeechToText @bind-Transcript="@transcript"></SfSpeechToText>
    <SfTextArea RowCount="5" ColumnCount="50" @bind-Value="@transcript" ResizeMode="Resize.None" Placeholder="Transcribed text will be shown here..."></SfTextArea>
</div>

<style>
    .speechtext-container {
        margin: 50px auto;
        gap: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
</style>

@code {
    string transcript = "";
}

{% endhighlight %}
{% endtabs %}

![Blazor SpeechToText Component Transcript](images/getting-started.png)

## Setting language

You can use the [Language](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_Language) property to specify the language for speech recognition. Setting this property ensures that the recognition engine interprets the spoken words correctly based on the specified locale such as `en-US` for American `English`, `fr-FR` for `French`, and more.

{% tabs %}
{% highlight razor %}

<div class="speechtext-container">
    <SfSpeechToText Language="fr-FR" @bind-Transcript="@transcript"></SfSpeechToText>
    <SfTextArea RowCount="5" ColumnCount="50" @bind-Value="@transcript" ResizeMode="Resize.None" Placeholder="Transcribed text will be shown here..."></SfTextArea>
</div>

<style>
    .speechtext-container {
        margin: 50px auto;
        gap: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
</style>

@code {
    string transcript = "";
}

{% endhighlight %}
{% endtabs %}

![Blazor SpeechToText Component Language](images/speechtotext-language.png)

## Allowing interim results

You can use the [AllowInterimResults](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_AllowInterimResults) property to enable or disable interim results. When set to `true`, the recognized speech will be displayed in real time as words are spoken. When set to `false`, only final results will be displayed after recognition is complete. By default, the value is `true`.

{% tabs %}
{% highlight razor %}

<div class="speechtext-container">
    <SfSpeechToText AllowInterimResults="false" @bind-Transcript="@transcript"></SfSpeechToText>
    <SfTextArea RowCount="5" ColumnCount="50" @bind-Value="@transcript" ResizeMode="Resize.None" Placeholder="Transcript will be displayed here once speech recognition is complete."></SfTextArea>
</div>

<style>
    .speechtext-container {
        margin: 50px auto;
        gap: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
</style>

@code {
    string transcript = "";
}

{% endhighlight %}
{% endtabs %}

![Blazor SpeechToText Component AllowInterimResults](images/speechtotext-allowinterim.png)

## Managing listening state

You can use the [ListeningState](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_ListeningState) property to manage the listening state of the component. The possible values are `Inactive`, `Listening` and `Stopped`. By default, the value is `Inactive`.

### Inactive

The component is in idle state with no active speech recognition.

### Listening

It is actively listening which captures and transcribes speech with a stop icon and blinking animation.

### Stopped

Denotes the speech recognition has ended, and no further speech is being processed.

Below sample demonstrates the usage of [ListeningState](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_ListeningState) property.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs

<div class="speech-container">
    <div class="status-box @GetStatusClass()">
        <span>Status: <strong>@listeningState</strong></span>
    </div>

    <SfSpeechToText ListeningState="listeningState" SpeechRecognitionStopped="(args) => UpdateListeningState(args.State)" SpeechRecognitionStarted="(args) => UpdateListeningState(args.State)"></SfSpeechToText>

    <div class="waveform-container">
        @if (listeningState == SpeechToTextState.Listening)
        {
            <div class="waveform">
                <span></span><span></span><span></span><span></span><span></span>
            </div>
            <p>Listening... Speak now!</p>
        }
        else
        {
            <p>Click the button to start listening.</p>
        }
    </div>
</div>

@code {
    private SpeechToTextState listeningState = SpeechToTextState.Inactive;

    private void UpdateListeningState(SpeechToTextState state) {
        listeningState = state;
    }

    private string GetStatusClass()
    {
        return listeningState switch
        {
            SpeechToTextState.Listening => "listening",
            SpeechToTextState.Stopped => "stopped",
            _ => "inactive"
        };
    }
}

<style>
    .waveform-container {
        margin-top: 20px;
        font-weight: bold;
    }

    .waveform {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 40px;
        gap: 5px;
    }

    .waveform span {
        display: block;
        width: 6px;
        height: 20px;
        background: #28a745;
        animation: wave-animation 1.2s infinite ease-in-out;
    }

    .waveform span:nth-child(1) { animation-delay: 0s; }
    .waveform span:nth-child(2) { animation-delay: 0.2s; }
    .waveform span:nth-child(3) { animation-delay: 0.4s; }
    .waveform span:nth-child(4) { animation-delay: 0.6s; }
    .waveform span:nth-child(5) { animation-delay: 0.8s; }

    .waveform span:nth-child(5) {
        animation-delay: 0.8s;
    }

    @@keyframes wave-animation {
        0%, 100% {
            height: 10px;
        }

        50% {
            height: 30px;
        }
    }

    .speech-container {
        text-align: center;
        margin: 20px auto;
        max-width: 400px;
        padding: 20px;
        border-radius: 10px;
        box-shadow: 0px 4px 10px rgba(0, 0, 0, 0.1);
        background: #fff;
    }

    .status-box {
        padding: 10px;
        border-radius: 5px;
        margin-bottom: 40px;
        font-weight: bold;
    }

    .status-box.listening {
        background-color: #d1e7dd;
        color: #0f5132;
    }

    .status-box.stopped {
        background-color: #f8d7da;
        color: #842029;
    }

    .status-box.inactive {
        background-color: #e2e3e5;
        color: #6c757d;
    }

    .visual-indicator {
        margin-top: 20px;
    }
</style>

{% endhighlight %}
{% endtabs %}

![Blazor SpeechToText Listening State](images/speechtotext-listeningstate.png)

## Show or hide tooltip

You can use the [ShowTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_ShowTooltip) property to specify the tooltip text to be displayed on hovering the SpeechToText button. By default, the value is `true`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs

<div class="speechtext-container">
    <SfSpeechToText ShowTooltip="false" @bind-Transcript="@transcript"></SfSpeechToText>
    <SfTextArea RowCount="5" ColumnCount="50" @bind-Value="@transcript" ResizeMode="Resize.None" Placeholder="Transcribed text will be shown here..."></SfTextArea>
</div>

<style>
    .speechtext-container {
        margin: 50px auto;
        gap: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
</style>

@code {
    string transcript = "";
}

{% endhighlight %}
{% endtabs %}

![Blazor SpeechToText Component ShowTooltip](images/speechtotext-showtooltip.png)

## Setting disabled

You can use the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_Disabled) property to disable the SpeechToText component, preventing user interaction when set to `true`. By default, the value is `false`.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs

<div class="speechtext-container">
    <SfSpeechToText Disabled="true" @bind-Transcript="@transcript"></SfSpeechToText>
    <SfTextArea RowCount="5" ColumnCount="50" @bind-Value="@transcript" ResizeMode="Resize.None" Placeholder="Transcribed text will be shown here..."></SfTextArea>
</div>

<style>
    .speechtext-container {
        margin: 50px auto;
        gap: 20px;
        display: flex;
        flex-direction: column;
        align-items: center;
    }
</style>

@code {
    string transcript = "";
}

{% endhighlight %}
{% endtabs %}

![Blazor SpeechToText Component Disabled](images/speechtotext-disabled.png)

## Setting html attributes

You can use the [HtmlAttributes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfSpeechToText.html#Syncfusion_Blazor_Inputs_SfSpeechToText_HtmlAttributes) property to assign custom attributes to the SpeechToText component for the button element.

## Error handling

The SpeechToText component handles various errors that may occur during speech recognition. The following table lists the possible errors and their causes:

| Error                | Cause                                                                                        |
|----------------------|----------------------------------------------------------------------------------------------|
| `no-speech`            | The microphone did not detect any speech input.                                              |
| `aborted`              | The speech recognition process was intentionally terminated.                                 |
| `audio-capture`        | The system was unable to detect a microphone device.                                         |
| `not-allowed`          | Access to the microphone was denied by the user or browser settings.                         |
| `service-not-allowed`  | The current context does not permit the use of the speech recognition service.               |
| `network`              | A network issue is preventing the speech recognition service from functioning.               |
| `unsupported-browser`  | The browser being used does not support the SpeechRecognition API.                           |
| `default`              | An unidentified error occurred during the speech recognition process.                        |

## Browser support

The SpeechToText component relies on the [Speech Recognition API](https://developer.mozilla.org/en-US/docs/Web/API/SpeechRecognition) for processing the speech input. Ensure that the browser supports this API before implementation.

|    Browser    |    Supported versions    |
|--------------|---------------|
|    Chrome     |    25+    |
|    Edge     |    79+    |
|    Firefox     |    Not Supported    |
|    Safari     |    12+    |
|    Opera     |    30+    |