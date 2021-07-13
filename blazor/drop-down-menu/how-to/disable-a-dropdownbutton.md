# Disable a Dropdown Menu

Dropdown Menu component can be enabled/disabled by giving [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfDropDownButton.html#Syncfusion_Blazor_SplitButtons_SfDropDownButton_Disabled) property.
To disable Dropdown Menu component, the disabled property can be set as `true`.

```csharp
@using Syncfusion.Blazor.SplitButtons

<SfDropDownButton Disabled="true" Content="Message">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Edit"></DropDownMenuItem>
        <DropDownMenuItem Text="Delete"></DropDownMenuItem>
        <DropDownMenuItem Text="Mark as Read"></DropDownMenuItem>
        <DropDownMenuItem Text="Like Message"></DropDownMenuItem>
    </DropDownMenuItems>
</SfDropDownButton>
```

Output be like

![Button Sample](./../images/ddb-disable.png)