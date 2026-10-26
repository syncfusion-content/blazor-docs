---
layout: post
title: Enable or Disable item in Blazor Accordion Component | Syncfusion®
description: Checkout and learn here all features about Enable or Disable item in Blazor Accordion component and more.
platform: Blazor
control: Accordion
documentation: ug
---

# How to enable or disable an item in Blazor Accordion

Enable or disable a specific [Blazor Accordion](https://www.syncfusion.com/blazor-components/blazor-accordion) item by setting the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html#Syncfusion_Blazor_Navigations_AccordionItem_Disabled) parameter on each [`AccordionItem`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html). A disabled item renders its header in a non-interactive state — the user cannot click it to expand or collapse the item.

The following example toggles the first item's `Disabled` state when you click the **Enable/Disable First Item** button.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfButton IsPrimary="true" @onclick="EnableItemClick" Content="Enable/Disable First Item"></SfButton>
<br />
<br />
<SfAccordion>
    <AccordionItems>
        <AccordionItem Disabled=@IsEnable Expanded="true" Header="ASP.NET" Content="Microsoft ASP.NET is a set of technologies in the Microsoft .NET Framework for building Web applications and XML Web services. ASP.NET pages execute on the server and generate markup such as HTML, WML, or XML that is sent to a desktop or mobile browser. ASP.NET pages use a compiled,event-driven programming model that improves performance and enables the separation of application logic and user interface."></AccordionItem>
        <AccordionItem Header="ASP.NET MVC" Content="The Model-View-Controller (MVC) architectural pattern separates an application into three main components: the model, the view, and the controller. The ASP.NET MVC framework provides an alternative to the ASP.NET Web Forms pattern for creating Web applications. The ASP.NET MVC framework is a lightweight, highly testable presentation framework that (as with Web Forms-based applications) is integrated with existing ASP.NET features, such as master pages and membership-based authentication."></AccordionItem>
        <AccordionItem Header="JavaScript" Content="JavaScript (JS) is an interpreted computer programming language.It was originally implemented as part of web browsers so that client-side scripts could interact with the user, control the browser, communicate asynchronously, and alter the document content that was displayed.More recently, however, it has become common in both game development and the creation of desktop applications."></AccordionItem>
    </AccordionItems>
</SfAccordion>

@code {
    public bool IsEnable { get; set; } = false;
    public void EnableItemClick()
    {
        IsEnable = !IsEnable;
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLHjxMiCPEfbiEL?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Enabling or Disabling Item in Blazor Accordion](../images/blazor-accordion-enable-disable-item.webp)" %}

## See also

* [Create Wizard in Blazor Accordion](https://blazor.syncfusion.com/documentation/accordion/how-to/create-wizard-using-accordion)
* [Add/Remove Accordion Items](https://blazor.syncfusion.com/documentation/accordion/how-to/add-remove-accordion-items)
* [Accessibility in Blazor Accordion](https://blazor.syncfusion.com/documentation/accordion/accessibility)
* [AccordionItem API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html)
