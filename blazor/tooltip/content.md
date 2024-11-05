---
layout: post
title: Content in Blazor Tooltip Component | Syncfusion
description: Checkout and learn here all about content in Syncfusion Blazor Tooltip component and much more details.
platform: Blazor
control: Tooltip
documentation: ug
---

# Content in Blazor Tooltip Component

A text or a piece of information assigned to the Tooltip's `Content` property will be displayed as the main text stream of the Tooltip. It can be a string or a template content. If the `Content` property is not provided with any specific value, then it takes the value assigned to the attribute of the target element on which the Tooltip was initialized. The content can also dynamically be assigned to the Tooltip via AJAX.

##  Displaying dynamic HTML Content

Any type of formatted content can be displayed within the Tooltip by default. To enhance the Tooltip layout or create a custom visualized element, use the `<ContentTemplate>` tag to define the structure.

Refer to the following code example to add dynamic HTML content to the Tooltip. Use @(MarkupString) to render HTML content dynamically.

```cshtml
@using Syncfusion.Blazor.Popups

<SfTooltip ID="tooltip" Target="#target">
    <ContentTemplate>
        <div>
            @((MarkupString)Content)
        </div>
    </ContentTemplate>
    <ChildContent>
        <div id='container'>
            <p>
                A green home is a type of house designed to be
                <a id="target">
                    <u>environmentally friendly</u>
                </a> and sustainable. And also focuses on the efficient use of "energy, water, and building materials." As green homes
                have become more prevalent we have also seen the emergence of green affordable housing.
            </p>
        </div>
    </ChildContent>
</SfTooltip>
@code
{
    string Content = "<div><b>Environmentally friendly</b> or environment-friendly, (also referred to as eco-friendly, nature-friendly, and green) are marketing and sustainability terms referring to goods and services, laws, guidelines and policies that inflict reduced, minimal, or no harm upon ecosystems or the environment.</div>";
}
```

![Blazor Tooltip with Content](images/blazor-tooltip-with-content.gif)


## Template in Blazor Tooltip Component

The Tooltip's Template property allows you to fully customize the layout or add any custom elements within the Tooltip. You can include any content or HTML elements as Tooltip content by defining them in the `<ContentTemplate>` tag of the Tooltip component.

Refer to the following code example to embed an HTML template within the Tooltip.

```cshtml
@using Syncfusion.Blazor.Buttons;
@using Syncfusion.Blazor.Popups;

<SfTooltip CssClass="e-tooltip-css" OpensOn="Click" Target="#btn">
    <ContentTemplate>
        <div id='democontent' class='democontent'>
            <div class='info'>
                <h3 style='margin-top:10px'>Eastern Bluebird <hr style='margin-top:10px'></h3>
                <div style='margin-top: -10px'>
                    <div style='float:left;width:57%'>
                        The<a href='https://en.wikipedia.org/wiki/Eastern_bluebird' target='blank'> Eastern Bluebird</a>
                        is easily found in open fields and sparse woodland areas, including along woodland edges.These are<i>cavity-nesting birds</i>and a pair of eastern bluebirds will raise 2-3 broods annually, with 2-8 light blue or whitish eggs per brood.
                    </div>
                    <div id='bird' style='float:right;width:42%'><img src='https://blazor.syncfusion.com/demos/_content/blazor_webapp_common_net8/images/tooltip/bird.png' width='125' height='125' /></div>
                </div>
                <div style='margin-top:160px'>
                    <hr><p style='margin-top:-11px'> Eastern bluebirds can be very vocal in flocks.Their calls include a rapid, mid-tone chatter and several long dropping pitch calls.</p>
                </div><p>Source:<br /><a href='https://en.wikipedia.org/wiki/Eastern_bluebird' target='_blank'>https://en.wikipedia.org/wiki/Eastern_bluebird</a></p>
            </div>
        </div>
    </ContentTemplate>
    <ChildContent>
        <SfButton ID="btn" CssClass="e-outline text" IsPrimary="true" Content="HTML Template"></SfButton>
    </ChildContent>
</SfTooltip>

<style>
    .e-tooltip-css {
        filter: drop-shadow(2px 5px 5px rgba(0, 0, 0, 0.25));
    }

    .text {
        text-transform: capitalize;
        width: 155px;
    }

    .democontent {
        border: 0.5px solid grey;
    }

    #bird {
        padding-top: 4px;
    }

    .info a {
        color: #2FA1E3;
    }

    .info {
        padding-left: 12px;
        padding-right: 5px;
    }
</style>
```

![Blazor Tooltip with Template](images/blazor-tooltip-template.gif)
