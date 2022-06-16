---
layout: post
title: Customization in Blazor Pager Component | Syncfusion
description: Checkout and learn here all about Customization in the Syncfusion Blazor Pager component and much more.
platform: Blazor
control: Pager
documentation: ug
---

# Customization in Pager Component

## Custom text

The `CustomText` property of a pager allows you to add custom text along with numeric values in the pager numeric elements that are used for navigation in the pager control.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager ID="Pager" TotalItemsCount="75" CustomText="PageNo" PageSizes="true" PageSize="5" PageCount="5">
</SfPager>

```

## External message

The pager control also allows to define a external message using `ExternalMessage` API to display an additional information. To use external message, we need to enable it using `EnableExternalMessage` API. In the sample below, the `ExternalMessage` of pager is used to show the current active page of the pager control. Whenever the current page value of the pager changes, the `ExternalMessage` will be updated with the current page value.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager PageCount="5" PageSize="5" TotalItemsCount=50 EnableExternalMessage=true ExternalMessage="@Externalmessage">
    <PagerEvents PageChanging="Click" ></PagerEvents>
</SfPager>

@code{
    public string Externalmessage { get; set; } = "You are in Page 1 now";

    public void Click(PageChangingEventArgs args)
    {
        var pageNumber = args.CurrentPage.ToString();
        this.Externalmessage = "You are in Page " + pageNumber + " now";
    }
}

```

## Custom CSS

Pager control allows you to customize the appearance using user defined CSS and custom skin options such as colors and backgrounds. To apply custom themes, we can make use of `CssClass` property. Using `CssClass` property, we can override the existing theme styles. In the following sample, the value for `CssClass` property is set as customCss and this root class is used to customize the pager control theme.

```csharp
@using Syncfusion.Blazor.Navigations

<SfPager PageCount="5" PageSize="5" TotalItemsCount=50 CssClass=customCss>
</SfPager>

<style>

    .e-pager.customCss .e-currentitem.e-numericitem.e-focused, .e-pager.customCss .e-currentitem{
        background: #2bbbad;
        color: #f6f3f1;
        border-bottom: 0px;
        border-radius: 0.125rem;
        outline-style: auto;
    }
        
</style>
```