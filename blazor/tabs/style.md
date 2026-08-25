---
layout: post
title: Style and Appearance in Blazor Tabs | Syncfusion
description: Customize Blazor Tabs appearance using CSS selectors for headers, content, and active indicators for branding.
platform: Blazor
control: Tabs
documentation: ug
---

# Style and Appearance in Blazor Tabs

The following CSS classes can be used to customize the appearance of the Tab control.

## Customizing the Tab

Use the following CSS to customize the Tab.

```CSS

.e-tab {
    border: 5px solid rgb(173, 255, 47);
}

```

![Customized Tab border](./images/blazor-tabs-customize.webp)

## Customizing the Tab header items

Use the following CSS to customize the header items of the Tab.

```CSS

.e-tab .e-tab-header .e-toolbar-items {
    background: #9faed8;
    border: 2px solid blue;
}

```

![Customized Tab header items](./images/blazor-tabs-customize-items.webp)

Use the following CSS to customize the content items of the Tab.

```CSS

.e-tab .e-content .e-item {
    color: #a78515;
    font-size: 14px;
}

```

![Customized Tab content items](./images/blazor-tabs-customize-content.webp)

## Customizing the Tab header

Use the following CSS to customize the header of the Tab control.

```CSS

.e-tab .e-tab-header {
    background: #badfba !important;
}

```

![Customized Tab header background](./images/blazor-tabs-header-customization.webp)

## Customizing the Tab header icon

Use the following CSS to customize the header item icon of the Tab control.

```CSS

.e-tab .e-tab-header .e-toolbar-item .e-tab-icon {
    color: #badfba !important;
}

```

![Customized Tab header icon](./images/blazor-tabs-header-icon-customization.webp)

## Customizing the Tab content

Use the following CSS to customize the content of the Tab control.

```CSS

.e-tab .e-content {
    background: #d1f6d1 !important;
}

```

![Customized Tab content background](./images/blazor-tabs-customize-content-background.webp)

## Customizing the hover state of the Tab

### Hover state of Tab items

Use the following CSS to customize a tab item when hovering.

```CSS

.e-tab .e-tab-header .e-toolbar-item .e-tab-wrap:hover {
    background: #d1f6d1 !important;
}

```

![Customized hover state of tab items](./images/blazor-tabs-hover-customization.webp)

### Hover state of the popup icon

Use the following CSS to customize the popup icon when hovering.

```CSS

.e-tab .e-tab-header .e-hor-nav .e-popup-up-icon:hover,
.e-tab .e-tab-header .e-hor-nav .e-popup-down-icon:hover {
    background: #d1f6d1 !important;
}

```

## Customizing the selected item of the Tab

Use the following CSS to customize the selected tab item.

```CSS

.e-tab .e-tab-header .e-toolbar-item.e-active {
    background: #d1f4d1;
}

```

![Customize Tab](./images/blazor-tabs-hover-customization.webp)

Use the following CSS to customize the selected tab item text and icon.

```CSS

.e-tab .e-tab-header .e-toolbar-item.e-active .e-tab-text,
.e-tab .e-tab-header .e-toolbar-item.e-active .e-tab-icon {
    color: green !important;
}

```

![Customized active Tab text and icon](./images/blazor-active-tabs-textIcon-customize.webp)