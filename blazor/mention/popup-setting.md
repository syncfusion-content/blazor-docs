---
layout: post
title: Popup Settings in Blazor Mention | Syncfusion®
description: Configure the Blazor Mention popup rendering using the AppendTo property to control where the popup appears, ensuring proper display in custom containers.
platform: Blazor
control: Mention
documentation: ug
---

# Popup Settings in Blazor Mention

## Render popup in a custom container

Use the `AppendTo` property to render the Mention popup inside a specific container instead of the default `document.body`. This is useful when the component is placed inside dialogs, side panels, containers with overflow restrictions, or custom stacking contexts.

Specify a valid CSS selector in the `AppendTo` property. When the selector matches an element, the popup is appended to that element. If the selector is null, empty, or no matching element is found, the popup is rendered in the default location.

{% highlight cshtml %}

@using Syncfusion.Blazor.DropDowns

<div id="popupHost">
    <SfMention TItem="PersonData" DataSource="@EmailData" AppendTo="@AppendTarget">
        <TargetComponent>
            <div id="commentsMention" placeholder="Type @@ to tag user">
            </div>
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
        public string Name { get; set; }
        public string EmailId { get; set; }
        public string EmployeeImage { get; set; }
    }
    List<PersonData> EmailData = new List<PersonData> {
        new PersonData() { Name="Selma Rose", EmployeeImage="7", EmailId="[EmailProtected]" },
        new PersonData() { Name="Russo Kay", EmployeeImage="8", EmailId="[EmailProtected]" },
        new PersonData() { Name="Camden Kate", EmployeeImage="9", EmailId="[EmailProtected]" }
    };
}
<style>
    #commentsMention {
        min-height: 100px;
        border: 1px solid #d7d7d7;
        border-radius: 4px;
        padding: 8px;
        font-size: 14px;
        width: 600px;
    }
    div#commentsMention[placeholder]:empty:before {
        content: attr(placeholder);
        color: #555;
    }
</style>

{% endhighlight %}

> The `AppendTo` property accepts a CSS selector such as `#elementId` or `.container`. If the specified element is not found, the popup element will be appended to `document.body`.
