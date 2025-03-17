---
layout: post
title: Events in Blazor SpeechToText Component | Syncfusion
description: Checkout and learn about Events in Blazor SpeechToText component in Blazor Server App and Blazor WebAssembly App.
platform: Blazor
control: SpeechToText
documentation: ug
---

# Events in Blazor SpeechToText component

This section describes the SpeechToText events that will be triggered when appropriate actions are performed. The following events are available in the SpeechToText component.

|Name|Args|Description|
|---|---|---|
|Created|EventCallback|Triggers when the SpeechToText component's rendering is fully completed|
|SpeechRecognitionStarted|SpeechRecognitionStartedEventArgs|Triggers when start listening speech recognition|
|SpeechRecognitionStopped|SpeechRecognitionStoppedEventArgs|Triggers when stop listening the speech recognition|
|SpeechRecognitionError|SpeechRecognitionErrorEventArgs|Triggers when an error occurs during speech recognition or listening|
|TranscriptChanging|TranscriptChangeEventArgs|Triggers when an transcription change occurs during the speech recognition.|