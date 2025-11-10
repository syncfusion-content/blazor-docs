---
layout: post
title: Stop Progress Indicator in Blazor ProgressButton | Syncfusion
description: Learn here all about how to stop progress indicator in Syncfusion Blazor ProgressButton component and more.
platform: Blazor
control: Progress Button
documentation: ug
---

# Stop Progress Indicator in Blazor ProgressButton Component

You can stop the progress indicator using [EndProgressAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfProgressButton.html#Syncfusion_Blazor_SplitButtons_SfProgressButton_EndProgressAsync) method. In the following sample, the progress is stopped by clicking the `STOP` button.

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