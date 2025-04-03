---
layout: post
title: Add and Remove Items in Blazor SplitButton Component | Syncfusion
description: Checkout and learn here all about how to add and remove items in Syncfusion Blazor SplitButton component and more.
platform: Blazor
control: Split Button
documentation: ug
---

# Add and Remove Items in Blazor SplitButton Component

Split Button component can dynamically add or remove items using  [AddItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_AddItems_System_Collections_Generic_List_Syncfusion_Blazor_SplitButtons_DropDownMenuItem__System_String_System_Boolean_), [RemoveItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SplitButtons.SfSplitButton.html#Syncfusion_Blazor_SplitButtons_SfSplitButton_RemoveItems_System_Collections_Generic_List_System_String__System_Boolean_) method.

```cshtml
@using Syncfusion.Blazor.SplitButtons
@using Syncfusion.Blazor.Buttons

<SfSplitButton Content="Paste Items" @ref="SplitbuttonRef">
    <DropDownMenuItems>
        <DropDownMenuItem Text="Paste"></DropDownMenuItem>
    </DropDownMenuItems>
</SfSplitButton>
<div>
    <SfButton Content="Additem" IsPrimary="true" @onclick="addItem"></SfButton>

    <SfButton Content="Removeitem" IsPrimary="true" @onclick="removeItem"></SfButton>
</div>

@code {
    SfSplitButton SplitbuttonRef;

    private void addItem()
    {
        SplitbuttonRef.AddItems(SplitbtnItems);
    }

    private void removeItem()
    {
        SplitbuttonRef.RemoveItems(removeItems);
    }
    public List<DropDownMenuItem> SplitbtnItems = new List<DropDownMenuItem>
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

![Adding or Removing Blazor SplitButton Items](./../images/blazor-splitbutton-add-remove-items.png)