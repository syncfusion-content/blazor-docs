---
layout: post
title: Prevent the Expand or Collapse item in Blazor Accordion | Syncfusion
description: Learn here all about how to prevent Expand or Collapse item in Syncfusion Blazor Accordion component and more.
platform: Blazor
control: Accordion
documentation: ug
---

# Prevent Expand or Collapse Actions in Blazor Accordion Items

The Syncfusion Blazor Accordion component allows you to control the expand and collapse behavior of its items under specific conditions. This functionality is crucial when you have interactive elements within the Accordion item headers, such as buttons or dropdowns, and you want their interaction to prevent the Accordion item itself from changing its expanded state. 

This controlled behavior is achieved by utilizing the Accordion component's [Expanding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionEvents.html#Syncfusion_Blazor_Navigations_AccordionEvents_Expanding) and [Collapsing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionEvents.html#Syncfusion_Blazor_Navigations_AccordionEvents_Collapsing) events. These events provide an `EventArgs` object with a `Cancel` property. Setting `args.Cancel = true;` within these event handlers will effectively stop the Accordion item from expanding or collapsing.

The following code example demonstrates how to prevent expand and collapse actions when interacting with controls embedded directly inside the Accordion item headers:

*   **DropDownList**: The Accordion item's expand/collapse is prevented when:
    *   The dropdown is opened using the [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnOpen) event.
    *   The dropdown is closed using the [OnClose](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_OnClose) event.
    *   An item is selected using the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event.

*   **Button**: The Accordion item's expand/collapse is prevented when clicking the button using its `onclick` event.


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
