---
layout: post
title: Prevent the Expand or Collapse item in Blazor Accordion | Syncfusion
description: Learn here all about how to prevent Expand or Collapse item in Syncfusion Blazor Accordion component and more.
platform: Blazor
control: Accordion
documentation: ug
---

# Prevent the Expand or Collapse Item in Blazor Accordion Component

The expand and collapse of an accordion item can be prevented for a specific condition. For example, if there is a button in the accordion header, clicking on it must prevent the expanding and collapsing. This can be achieved by checking the condition on Accordion [Expanding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionEvents.html#Syncfusion_Blazor_Navigations_AccordionEvents_Expanding) and [Collapsing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionEvents.html#Syncfusion_Blazor_Navigations_AccordionEvents_Collapsing) events. Refer the following code snippet in which the prevention of collapse and expand action occurs while clicking the Button and DropDownList.

* DropDownList - Prevents the expand and collapse of an accordion item while opening the DropDownList using the [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnOpen) event of the DropDownList. It also prevents the expand or collapse of an accordion item while closing or selecting the DropDownList by using the [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnClose) and [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event of the DropDownList.
* Button - Prevents the expand or collapse of an accordion item while clicking the button by using the `onclick` event of the Button.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VthAChWqgyaWwIZu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Expanding or Collapsing Item in Blazor Accordion](../images/blazor-accordion-prevent-expand-collapse.gif)
