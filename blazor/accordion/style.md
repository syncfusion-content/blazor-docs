---
layout: post
title: Style and Appearance in Blazor Accordion Component | Syncfusion
description: Checkout and learn here all about Style and Appearance in Syncfusion Blazor Accordion component and more.
platform: Blazor
control: Accordion
documentation: ug
---

# Style and Appearance in Blazor Accordion Component

The following content provides the exact CSS structure that can be used to modify the control’s appearance based on the user preference.

## Customizing Accordion

Use the following CSS to customize the [Accordion](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfAccordion.html).

```CSS

.e-accordion {
    border: 5px solid rgb(173, 255, 47);
}

```

## Customizing the Accordion's items

Use the following CSS to customize the items of Accordion.

```CSS

.e-accordion .e-acrdn-item {
    text-align: center;
    color: pink;
    background-color: #2fa1ff;
}

```

## Customizing Accordion's header

Use the following CSS to customize the header of Accordion control.

```CSS

.e-accordion .e-acrdn-item.e-select > .e-acrdn-header {
    background: #2fa1ff !important;
    justify-content: center;
}

```

## Customizing Accordion's expand and collapse icons

Use the following CSS to customize the expand and collapse icons of the Accordion control.

```CSS

.e-accordion .e-acrdn-item .e-acrdn-header .e-toggle-icon .e-icons {
     color: pink;
}

```

## Customizing the hover state of Accordion control

Use the following CSS to customize the [accordion item](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionItem.html) when hovering.

```CSS

.e-accordion .e-acrdn-item .e-acrdn-header:hover {
    border: 2px solid gray;
}

```

## Customizing selected item of Accordion control

Use the following CSS to customize the selected accordion item.

```CSS

.e-accordion .e-acrdn-item.e-select.e-active>.e-acrdn-header,
.e-accordion .e-acrdn-item.e-select.e-item-focus>.e-acrdn-header {
    background-color: rgb(0, 15, 100) !important;
}

```

Use the following CSS to customize the selected accordion item text.

```CSS

.e-accordion .e-acrdn-item.e-select.e-active>.e-acrdn-header .e-acrdn-header-content,
.e-accordion .e-acrdn-item.e-select.e-item-focus>.e-acrdn-header .e-acrdn-header-content {
    color: #2fa1ff !important;
}

```