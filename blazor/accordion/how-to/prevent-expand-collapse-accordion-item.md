---
layout: post
title: Prevent Expand or Collapse item in Blazor Accordion Component | Syncfusion
description: Learn here all about Prevent Expand or Collapse item in Syncfusion Blazor Accordion component and more.
platform: Blazor
control: Accordion
documentation: ug
---

# Prevent Expand or Collapse item in Blazor Accordion Component

We can prevent the expand and collapse of accordion item for specific condition, for example if we have a button in the accordion header, clicking on it we need to prevent expand and collapse. This can be achieved by checking the condition on Accordion `Expanding` and `Collapsing` events. You can refer the following code snippet in which prevention of collapse and expand action when clicking the Button and DropDownList.

* DropDownList - Prevented the expand and collapse of accordion item when open the DropDownList by using the `OnOpen` event of DropDownList. Also, prevented the expand or collapse of accordion item when close or select the DropDownList by using the `OnClose` and `ValueChange` event of DropDownList.
* Button - Prevented the expand or collapse of accordion item when clicking the button by using the `onclick` event of Button.

```cshtml
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfAccordion>
    <AccordionEvents Expanding="OnExpanding" Collapsing="OnCollapsing"></AccordionEvents>
    <AccordionItems>
        <AccordionItem Expanded="true">
            <HeaderTemplate>
                <SfDropDownList TValue="string" TItem="Countries" Placeholder="Select a country" DataSource="@Country" Width="120">
                    <DropDownListEvents TValue="string" TItem="Countries" OnOpen="OnOpen" OnClose="OnClose" ValueChange="OnChange"></DropDownListEvents>
                    <DropDownListFieldSettings Value="CountryName"></DropDownListFieldSettings>
                </SfDropDownList>
            </HeaderTemplate>
            <ContentTemplate>
                <div>Dropdown Content</div>
            </ContentTemplate>
        </AccordionItem>
        <AccordionItem>
            <HeaderTemplate>
                <SfButton Content="@ButtonText" @onclick="AddRemoveItem">
                </SfButton>
            </HeaderTemplate>
            <ContentTemplate>
                <div>Button Content</div>
            </ContentTemplate>
        </AccordionItem>
    </AccordionItems>
</SfAccordion>

@code
{
    public bool IsDropdown = false;
    public bool IsDropdownItemChanged = false;
    public bool IsButton = false;
    public string ButtonText = "OnClick";

    public List<Countries> Country = new List<Countries>() {
        new Countries(){ CountryName= "Australia", CountryId= "2" },
        new Countries(){ CountryName= "United States", CountryId= "1" },
    };
    public class Countries
    {
        public string CountryName { get; set; }
        public string CountryId { get; set; }
    }
    public void OnOpen()
    {
        IsDropdown = true;
    }
    public void OnClose()
    {
        IsDropdown = !IsDropdownItemChanged;
    }
    public void OnChange()
    {
        IsDropdownItemChanged = true;
    }
    public void AddRemoveItem()
    {
        IsButton = true;
    }
    public void OnExpanding(ExpandEventArgs args)
    {
        if (IsButton || IsDropdown)
        {
            args.Cancel = true;
            PreventItem();
        }
    }
    public void OnCollapsing(CollapseEventArgs args)
    {
        if (IsButton || IsDropdown)
        {
            args.Cancel = true;
            PreventItem();
        }
    }
    private void PreventItem()
    {
        if (IsButton)
        {
            IsButton = false;
        }
        else if (IsDropdown)
        {
            IsDropdown = false;
            IsDropdownItemChanged = false;
        }
    }
}
```

Output be like the below.

![Prevent Expand or Collapse the Accordion item](../images/preventExpandCollapseItem.png)pandCollapseItem.png)