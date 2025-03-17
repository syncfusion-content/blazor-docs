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

You can use the `Transcript` property to retrieve the transcribed text from the spoken text. This property allows to display the transcribed text once the speech recognition process is started.

## Setting language

You can use the `Language` property to specify the language for speech recognition. Setting this property ensures that the recognition engine interprets the spoken words correctly based on the specified locale such as `en-US` for American `English`, `fr-FR` for `French`, and more.

## Allowing interim results

You can use the `AllowInterimResults` property to enable or disable interim results. When set to `true`, the recognized speech will be displayed in real time as words are spoken. When set to `false`, only final results will be displayed after recognition is complete. By default, the value is `true`.

## Managing listening state

You can use the `ListeningState` property to manage the listening state of the component. The possible values are `Inactive`, `Listening` and `Stopped`. By default, the value is `Inactive`.

### Inactive

The component is in idle state with no active speech recognition.

### Listening

It is actively listening which captures and transcribes speech with a stop icon and blinking animation.

### Stopped

Denotes the speech recognition has ended, and no further speech is being processed.

## Show or hide tooltip

You can use the `ShowTooltip` property to specify the tooltip text to be displayed on hovering the SpeechToText button. By default, the value is `true`.

## Setting disabled

You can use the `Disabled` property to disable the SpeechToText, preventing user interaction when set to `true`. By default, the value is `false`.

## Setting html attributes

You can use the `HtmlAttributes` property to assign custom attributes to the SpeechToText component for the button element.

## Browser support

The SpeechToText component relies on the `Speech Recognition API` for processing the speech input. Ensure that the browser supports this API before implementation.

|    Browser    |    Supported versions    |
|--------------|---------------|
|    Chrome     |    25+    |
|    Edge     |    79+    |
|    Firefox     |    Not Supported    |
|    Safari     |    12+    |
|    Opera     |    30+    |