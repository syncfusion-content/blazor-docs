---
layout: post
title: Popup Setting in Blazor Mention | Syncfusion®
description: Configure the Blazor Mention popup rendering using the AppendTo property to control where the popup appears, ensuring proper display in custom containers.
platform: Blazor
control: Mention
documentation: ug
---

# Popup Setting in Blazor Mention

## Render popup in a custom container

Use the `AppendTo` property to render the Mention popup inside a specific container instead of the default `document.body`. This is useful when the component is placed inside dialogs, side panels, containers with overflow restrictions, or custom stacking contexts.

Specify a valid CSS selector in the `AppendTo` property. When the selector matches an element, the popup is appended to that element. If the selector is null, empty, or no matching element is found, the popup is rendered in the default location.

{% highlight cshtml %}

@using Syncfusion.Blazor.DropDowns

<div id="popupHost">
    <SfMention TItem="PersonData"
               DataSource="@Users"
               AppendTo="@AppendTarget">
        <TargetComponent>
            <div id="commentsMention" aria-label="Mention Target" role="textbox"></div>
        </TargetComponent>
        <ChildContent>
            <MentionFieldSettings Text="Name"></MentionFieldSettings>
        </ChildContent>
    </SfMention>
</div>

@code {
    private string AppendTarget = "#popupHost";

    public class PersonData
    {
        public string? Name { get; set; }
    }

    private List<PersonData> Users = new()
    {
        new() { Name = "Andrew" },
        new() { Name = "Robert" },
        new() { Name = "Laura" },
        new() { Name = "Richard" }
    };
}

{% endhighlight %}

> The `AppendTo` property accepts a CSS selector such as `#elementId` or `.container`. If the specified element is not found, the popup element will be appended to `document.body`.
