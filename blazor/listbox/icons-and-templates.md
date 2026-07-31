---
layout: post
title: Icons and Templates in Blazor ListBox Component | Syncfusion®
description: Checkout and learn here all about icons and templates in Blazor ListBox component and more.
platform: Blazor
control: List Box
documentation: ug
---

# Icons and Templates in Blazor ListBox Component

## Icons

The ListBox supports two icon sources: built-in Syncfusion icon classes, such as `e-list-settings`, and custom CSS classes defined in the application. The `e-icons` class is part of the Syncfusion Blazor icons library, which provides font icons used across Syncfusion Blazor components. Refer to the [Blazor icons library](https://blazor.syncfusion.com/documentation/appearance/icons) documentation for more details about available icons and usage.

To display an icon for each ListBox item, map the [IconCss field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ListBoxFieldSettings.html#Syncfusion_Blazor_DropDowns_ListBoxFieldSettings_IconCss) to the data source property that contains the icon CSS classes. The `IconCss` field accepts a CSS class name, or multiple class names separated by a space, to display an icon for each item. Icon glyphs are provided by the theme CSS, and custom icons can also be supplied using application-defined CSS classes. By default, the icon is positioned on the left side of the item text.

In the following example, icon classes are mapped to the `IconCss` field.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfListBox TValue="string[]" DataSource="@SettingsData" TItem="SettingItems">
    <ListBoxFieldSettings Text="Text" IconCss="IconCss" />
</SfListBox>

@code {
    public List<SettingItems> SettingsData = new List<SettingItems> {
        new SettingItems{ Text = "Settings", IconCss = "e-icons e-list-settings" },
        new SettingItems{ Text = "Save", IconCss = "e-icons e-list-save" },
        new SettingItems{ Text = "Save As", IconCss = "e-icons e-list-saveas" },
        new SettingItems{ Text = "Undo", IconCss = "e-icons e-list-undo" },
        new SettingItems{ Text = "Print", IconCss = "e-icons e-list-print" },
        new SettingItems{ Text = "Delete", IconCss = "e-icons e-list-delete" }
    };

    public class SettingItems {
        public string Text { get; set; }
        public string IconCss { get; set; }
    }

}
<style>
    .e-list-settings:before {
        content: "\e679";
    }

    .e-list-print:before {
        content: "\e743";
    }

    .e-list-save:before {
        content: "\e74d";
    }

    .e-list-saveas:before {
        content: "\e72b";
    }

    .e-list-delete:before {
        content: "\e773";
    }

    .e-list-undo:before {
        content: "\e752";
    }

</style>
```

![Blazor ListBox with item icons](./images/blazor-listbox-icons.webp)

## Templates

The [ListBoxTemplates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ListBoxTemplates-1.html) component provides template customization options for ListBox items. The [ItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.ListBoxTemplates-1.html#Syncfusion_Blazor_DropDowns_ListBoxTemplates_1_ItemTemplate) property customizes how each list item is rendered in the ListBox. It can be used to display rich content such as avatars, badges, descriptions, or any custom markup for each item.

```cshtml
@using Syncfusion.Blazor.DropDowns

<SfListBox TValue="string[]" DataSource="@Data" TItem="ListData">
    <ListBoxFieldSettings Text="Text"></ListBoxFieldSettings>
    <ListBoxTemplates TItem="ListData">
        <ItemTemplate>
            <div class="list-wrapper">
                <span class="@((context as ListData).Pic) e-avatar e-avatar-xlarge e-avatar-circle"></span>
                <span class="text">@((context as ListData).Text)</span>
                <span class="description">@((context as ListData).Description)</span>
            </div>
        </ItemTemplate>
    </ListBoxTemplates>
</SfListBox>

@code {
    public List<ListData> Data = new List<ListData>
    {
        new ListData { Text = "Javascript", Pic = "javascript", Description = "It is a lightweight interpreted or JIT-compiled programming language." },
        new ListData { Text = "Typescript", Pic = "typescript", Description = "It is a typed superset of Javascript that compiles to plain JavaScript." },
        new ListData { Text = "Angular", Pic = "angular", Description = "It is a TypeScript-based open-source web application framework." },
        new ListData { Text = "React", Pic = "react", Description = "A JavaScript library for building user interfaces. It can also render on the server using Node." },
        new ListData { Text = "Vue", Pic = "vue", Description = "A progressive framework for building user interfaces. It is incrementally adoptable." }
    };

    public class ListData
    {
        public string Text { get; set; }
        public string Pic { get; set; }
        public string Description { get; set; }
    }
}

<style>
    .e-listbox-container {
        margin: auto;
        max-width: 400px;
        box-sizing: border-box;
    }

    .list-wrapper {
        height: inherit;
        position: relative;
        padding: 14px 12px 14px 78px;
    }

    .list-wrapper .text,
    .list-wrapper .description {
        display: block;
        margin: 0;
        padding-bottom: 3px;
        white-space: normal;
    }

    .list-wrapper .description {
        font-size: 12px;
        font-weight: 500;
    }

    .e-listbox-container .list-wrapper .text {
        font-weight: bold;
        font-size: 13px;
    }

    .list-wrapper .e-avatar {
        position: absolute;
        left: 5px;
        background-color: transparent;
        font-size: 22px;
        top: calc(50% - 33px);
    }

    .e-listbox-container .e-list-item {
        height: auto !important;
    }

    .javascript {
        background-image: url('./images/javascript.svg');
    }

    .typescript {
        background-image: url('./images/typescript.svg');
    }

    .angular {
        background-image: url('./images/angular.svg');
    }

    .vue {
        background-image: url('./images/vue.svg');
    }

    .react {
        background-image: url('./images/react.svg');
    }
</style>

```

![Blazor ListBox with icon](./images/blazor-listbox-icon-template.webp)