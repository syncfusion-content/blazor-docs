# Set disabled state

Toggle Switch Button can be disabled by setting the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) property to true.

The following example illustrates how to disable support in Toggle Switch Button component.

```csharp
@using Syncfusion.Blazor.Buttons

<SfSwitch Disabled="true" @bind-Checked="isChecked"></SfSwitch>

@code {
    private bool isChecked = false;
}

```

Output be like

![Switch Sample](./../images/switch-disabled.png)