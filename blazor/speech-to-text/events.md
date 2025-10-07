---
layout: post
title: Events in Blazor SpeechToText Component | Syncfusion
description: Checkout and learn about Events in Blazor SpeechToText component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeechToText
documentation: ug
---

# Events in Blazor SpeechToText Component

The Blazor SpeechToText component provides a set of events that are triggered when specific actions occur during its lifecycle and operation. The following events are available:

|Name|Args|Description|
|---|---|---|
|Created|EventCallback|Triggers when the SpeechToText component's rendering is fully completed.|
|SpeechRecognitionStarted|SpeechRecognitionStartedEventArgs|Triggers when speech recognition begins.|
|SpeechRecognitionStopped|SpeechRecognitionStoppedEventArgs|Triggers when speech recognition stops.|
|SpeechRecognitionError|SpeechRecognitionErrorEventArgs|Triggers when an error occurs during speech recognition or while listening. For a list of possible errors, refer to the [Error handling](./speech-recognition#error-handling) section.|
|TranscriptChanging|TranscriptChangeEventArgs|Triggers when a transcription change occurs during speech recognition.|

The following example demonstrates how to configure the Blazor SpeechToText events.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Inputs

<div class="speechtext-container">
    <SfSpeechToText SpeechRecognitionStarted="@HandleStartRecognition"
                    SpeechRecognitionStopped="@HandleStopRecognition"
                    SpeechRecognitionError="@HandleSpeechRecognitionError"
                    TranscriptChanging="@HandleTranscriptChange">
    </SfSpeechToText>
</div>

@code {

    private void HandleStartRecognition(SpeechRecognitionStartedEventArgs args) { /* Required action here */ }
    private void HandleStopRecognition(SpeechRecognitionStoppedEventArgs args) { /* Required action here */ }
    private void HandleSpeechRecognitionError(SpeechRecognitionErrorEventArgs args) { /* Required action here */ }
    private void HandleTranscriptChange(TranscriptChangeEventArgs args) { /* Required action here */ }

}

{% endhighlight %}
{% endtabs %}