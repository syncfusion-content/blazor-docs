---
title: "Range in the Blazor Progress Bar component | Syncfusion"

component: "Progress Bar"

description: "Learn here all about the range of Syncfusion Progress Bar (SfProgressBar) component and more."
---

# Range in the Blazor Progress Bar (SfProgressBar)

The range represents the entire span of the Progress Bar and it can be defined using the [`Minimum`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Minimum) and the [`Maximum`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.ProgressBar.SfProgressBar.html#Syncfusion_Blazor_ProgressBar_SfProgressBar_Maximum) properties.

```csharp
@using Syncfusion.Blazor.ProgressBar

<SfProgressBar Type="ProgressType.Linear" Value="100" Height="60" Minimum="0" Maximum="100">
</SfProgressBar>
```

![Range in Progress Bar](images/determinate.png)
