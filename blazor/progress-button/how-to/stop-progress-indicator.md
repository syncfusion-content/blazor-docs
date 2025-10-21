---
layout: post
title: Stop Progress Indicator in Blazor ProgressButton | Syncfusion
description: Learn here all about how to stop progress indicator in Syncfusion Blazor ProgressButton component and more.
platform: Blazor
control: Progress Button
documentation: ug
---

# Stop Progress Indicator in Blazor ProgressButton Component

Stop the active progress programmatically by calling the [EndProgressAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_EndProgressAsync) method on the ProgressButton instance obtained via @ref. In the following example, clicking the Stop button invokes the handler that awaits EndProgressAsync to halt the current progress.

```cshtml
@using Syncfusion.Blazor.SplitButtons
@using Syncfusion.Blazor.Buttons

<SfProgressButton Content="Spin Left" IsPrimary="true" @ref="ProgressBtnObj"></SfProgressButton>
<SfButton Content="Stop" OnClick="clicked"></SfButton>

@code {
    SfProgressButton ProgressBtnObj;
    private async Task clicked()
    {
      await ProgressBtnObj.EndProgressAsync();
    }
}
```

![Stop Progress Indicator in ProgressButton](./../images/blazor-progressbutton-stop-indicator.png)