# Right-To-Left

Button component has RTL support. This can be achieved by setting [`EnableRtl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfButton.html#Syncfusion_Blazor_Buttons_SfButton_EnableRtl) as true.

The following example illustrates how to enable right-to-left support in Button component.

```csharp
@using Syncfusion.Blazor.Buttons

<SfButton IconCss="e-icons e-setting-icon" EnableRtl="true">Settings</SfButton>

<style>
    .e-setting-icon::before {
        content: '\e679';
    }
</style>
```

Output be like

![Button Sample](./../images/button-rtl.png)