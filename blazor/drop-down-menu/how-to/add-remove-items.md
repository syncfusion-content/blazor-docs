# Add and Remove Items

Dropdown Menu component can be dynamically add or remove items using  `AddItems`, `RemoveItems` method.

The following example illustrates how to add and remove items in Dropdown Menu component.

```csharp
@using Syncfusion.Blazor.SplitButtons
@using Syncfusion.Blazor.Buttons

<SfDropDownButton Content="Paste Items" @ref="DropDownbuttonRef">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfDropDownButton>
<div>
    <SfButton Content="Additem" IsPrimary="true" @onclick="addItem"></SfButton>

    <SfButton Content="Removeitem" IsPrimary="true" @onclick="removeItem"></SfButton>
</div>

@code {
    SfDropDownButton DropDownbuttonRef;

    private void addItem()
    {
        DropDownbuttonRef.AddItems(dropdownbtnItems);
    }

    private void removeItem()
    {
        DropDownbuttonRef.RemoveItems(removeItems);
    }
    public List<DropDownMenuItem> dropdownbtnItems = new List<DropDownMenuItem>
{
        new DropDownMenuItem{ Text="Paste Special" },
        new DropDownMenuItem{ Text="Paste as Formula" },
        new DropDownMenuItem{ Text="Paste as Hyperlink" }
    };

    public List<string> removeItems = new List<string>()
{
       "Paste"
    };
}

  
```

Output be like

![Split Button Sample](./../images/add-remove-items.png)