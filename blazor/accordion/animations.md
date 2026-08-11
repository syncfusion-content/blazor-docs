---
layout: post
title: Animations in Blazor Accordion | Syncfusion®
description: Apply custom expand and collapse animations to Blazor Accordion panels using the Animation library, with configurable Easing, Duration, and effects.
platform: Blazor
control: Accordion
documentation: ug
---

# Animations in Blazor Accordion

The [Blazor Accordion](https://www.syncfusion.com/blazor-components/blazor-accordion) component supports custom animations for both expand and collapse actions using the options provided by the `AccordionAnimationSettings` component. The animation properties allow you to customize aspects such as [Effect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionAnimationExpand.html#Syncfusion_Blazor_Navigations_AccordionAnimationExpand_Effect), [Duration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionAnimationExpand.html#Syncfusion_Blazor_Navigations_AccordionAnimationExpand_Duration), and [Easing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionAnimationExpand.html#Syncfusion_Blazor_Navigations_AccordionAnimationExpand_Easing) according to your preference.

By default, the Accordion uses `SlideDown` animation for expanding panels (set through the [Expand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionAnimationSettings.html#Syncfusion_Blazor_Navigations_AccordionAnimationSettings_Expand) property) and `SlideUp` animation for collapsing panels (set through the [Collapse](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionAnimationSettings.html#Syncfusion_Blazor_Navigations_AccordionAnimationSettings_Collapse) property). You can disable animations completely by setting [Effect](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionAnimationCollapse.html#Syncfusion_Blazor_Navigations_AccordionAnimationCollapse_Effect) to `None`.

## Available animation properties

| Property | Type | Default | Description |
| -- | -- | -- | -- |
| `Effect` | `AnimationEffect` | `SlideDown` (Expand) / `SlideUp` (Collapse) | Specifies the type of animation effect. Use `None` to disable animation. |
| `Duration` | `int` | `400` | Duration of the animation in milliseconds. |
| `Easing` | `string` | `linear` | CSS `animation-timing-function` value (e.g., `ease`, `ease-in`, `ease-out`, `ease-in-out`, `cubic-bezier(…)`). |

## Supported `AnimationEffect` values

| Value | Applies To | Description |
| -- | -- | -- |
| `SlideDown` | Expand | Slides the panel downward. |
| `SlideUp` | Collapse | Slides the panel upward. |
| `SlideLeft` | Expand / Collapse | Slides the panel to the left. |
| `SlideRight` | Expand / Collapse | Slides the panel to the right. |
| `SlideLeftIn` | Expand | Slides the panel in from the left. |
| `SlideRightIn` | Expand | Slides the panel in from the right. |
| `SlideLeftOut` | Collapse | Slides the panel out to the left. |
| `SlideRightOut` | Collapse | Slides the panel out to the right. |
| `SlideTopIn` | Expand | Slides the panel in from the top. |
| `SlideBottomIn` | Expand | Slides the panel in from the bottom. |
| `SlideTopOut` | Collapse | Slides the panel out to the top. |
| `SlideBottomOut` | Collapse | Slides the panel out to the bottom. |
| `FadeIn` | Expand / Collapse | Fades the panel in. |
| `FadeOut` | Expand / Collapse | Fades the panel out. |
| `FadeZoomIn` | Expand / Collapse | Combined fade and zoom-in. |
| `FadeZoomOut` | Expand / Collapse | Combined fade and zoom-out. |
| `ZoomIn` | Expand / Collapse | Scales the panel up from small. |
| `ZoomOut` | Expand / Collapse | Scales the panel down to small. |
| `FlipXDownIn` | Expand | Flips the panel in from the top. |
| `FlipXDownOut` | Collapse | Flips the panel out to the top. |
| `FlipXUpIn` | Expand | Flips the panel in from the bottom. |
| `FlipXUpOut` | Collapse | Flips the panel out to the bottom. |
| `FlipYLeftIn` | Expand | Flips the panel in from the right. |
| `FlipYLeftOut` | Collapse | Flips the panel out to the right. |
| `FlipYRightIn` | Expand | Flips the panel in from the left. |
| `FlipYRightOut` | Collapse | Flips the panel out to the left. |
| `FlipLeftDownIn` | Expand | Flip on left axis, slide in from top. |
| `FlipLeftDownOut` | Collapse | Flip on left axis, slide out to top. |
| `FlipLeftUpIn` | Expand | Flip on left axis, slide in from bottom. |
| `FlipLeftUpOut` | Collapse | Flip on left axis, slide out to bottom. |
| `FlipRightDownIn` | Expand | Flip on right axis, slide in from top. |
| `FlipRightDownOut` | Collapse | Flip on right axis, slide out to top. |
| `FlipRightUpIn` | Expand | Flip on right axis, slide in from bottom. |
| `FlipRightUpOut` | Collapse | Flip on right axis, slide out to bottom. |
| `None` | Expand / Collapse | Disables the animation. |

## Customizing duration and easing

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations

<SfAccordion>
    <AccordionAnimationSettings>
        <AccordionAnimationCollapse Effect="AnimationEffect.FadeOut"
                                    Duration="600"
                                    Easing="ease-in-out">
        </AccordionAnimationCollapse>
        <AccordionAnimationExpand Effect="AnimationEffect.FadeZoomIn"
                                  Duration="600"
                                  Easing="ease-in-out">
        </AccordionAnimationExpand>
    </AccordionAnimationSettings>
    <AccordionItems>
        <AccordionItem Header="ASP.NET" Content="Microsoft ASP.NET is a set of technologies in the Microsoft .NET Framework for building Web applications and XML Web services."></AccordionItem>
        <AccordionItem Header="ASP.NET MVC" Content="The Model-View-Controller (MVC) architectural pattern separates an application into three main components: the model, the view, and the controller."></AccordionItem>
    </AccordionItems>
</SfAccordion>
```

## How to disable animations

Set `Effect` to `None` on both the `AccordionAnimationExpand` and `AccordionAnimationCollapse` elements:

```cshtml
<AccordionAnimationSettings>
    <AccordionAnimationExpand Effect="AnimationEffect.None"></AccordionAnimationExpand>
    <AccordionAnimationCollapse Effect="AnimationEffect.None"></AccordionAnimationCollapse>
</AccordionAnimationSettings>
```

## Example: selecting an animation from a DropDownList

The following example demonstrates how to bind a DropDownList so a user can choose the Expand and Collapse animation at runtime.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<div id="container">
    <div id="default" style="padding-bottom:75px;">
        <div class="row">
            <div class="col-xs-6 col-sm-6 col-lg-6 col-md-6">
                <label> Expand Animation </label>
            </div>
            <div class="col-xs-6 col-sm-6 col-lg-6 col-md-6">
                <SfDropDownList TValue="AnimationEffect" DataSource="@AnimationData" TItem="Effect" PopupHeight="200px" Placeholder="Select an animation" @bind-Value="ExpandEffect">
                    <DropDownListFieldSettings Value="ID" Text="Text"></DropDownListFieldSettings>
                </SfDropDownList>
            </div>
        </div>
        <div class="row">
            <div class="col-xs-6 col-sm-6 col-lg-6 col-md-6">
                <label> Collapse Animation </label>
            </div>
            <div class="col-xs-6 col-sm-6 col-lg-6 col-md-6">
                <SfDropDownList TValue="AnimationEffect" DataSource="@AnimationData" TItem="Effect" PopupHeight="200px" Placeholder="Select an animation" @bind-Value="CollapseEffect">
                    <DropDownListFieldSettings Value="ID" Text="Text"></DropDownListFieldSettings>
                </SfDropDownList>
            </div>
        </div>
    </div>
    <SfAccordion>
        <AccordionAnimationSettings>
            <AccordionAnimationCollapse Effect=@CollapseEffect></AccordionAnimationCollapse>
            <AccordionAnimationExpand Effect=@ExpandEffect></AccordionAnimationExpand>
        </AccordionAnimationSettings>
        <AccordionItems>
            <AccordionItem Header="ASP.NET" Content="Microsoft ASP.NET is a set of technologies in the Microsoft .NET Framework for building Web applications and XML Web services. ASP.NET pages execute on the server and generate markup such as HTML, WML, or XML that is sent to a desktop or mobile browser. ASP.NET pages use a compiled,event-driven programming model that improves performance and enables the separation of application logic and user interface.">
            </AccordionItem>
            <AccordionItem Header="ASP.NET MVC" Content="The Model-View-Controller (MVC) architectural pattern separates an application into three main components: the model, the view, and the controller. The ASP.NET MVC framework provides an alternative to the ASP.NET Web Forms pattern for creating Web applications. The ASP.NET MVC framework is a lightweight, highly testable presentation framework that (as with Web Forms-based applications) is integrated with existing ASP.NET features, such as master pages and membership-based authentication.">
            </AccordionItem>
            <AccordionItem Header="JavaScript" Content="JavaScript (JS) is an interpreted computer programming language. It was originally implemented as part of web browsers so that client-side scripts could interact with the user, control the browser, communicate asynchronously, and alter the document content that was displayed. More recently, however, it has become common in both server-side development and the creation of desktop applications.">
            </AccordionItem>
        </AccordionItems>
    </SfAccordion>
</div>

@code {
    public AnimationEffect ExpandEffect = AnimationEffect.SlideDown;
    public AnimationEffect CollapseEffect = AnimationEffect.SlideUp;

    public class Effect
    {
        public AnimationEffect ID { get; set; }
        public string Text { get; set; }
    }

    private List<Effect> AnimationData = new()
    {
        new Effect { ID = AnimationEffect.SlideDown,        Text = "SlideDown" },
        new Effect { ID = AnimationEffect.SlideUp,          Text = "SlideUp" },
        new Effect { ID = AnimationEffect.SlideLeft,        Text = "SlideLeft" },
        new Effect { ID = AnimationEffect.SlideRight,       Text = "SlideRight" },
        new Effect { ID = AnimationEffect.SlideLeftIn,      Text = "SlideLeftIn" },
        new Effect { ID = AnimationEffect.SlideRightIn,     Text = "SlideRightIn" },
        new Effect { ID = AnimationEffect.SlideLeftOut,     Text = "SlideLeftOut" },
        new Effect { ID = AnimationEffect.SlideRightOut,    Text = "SlideRightOut" },
        new Effect { ID = AnimationEffect.SlideTopIn,       Text = "SlideTopIn" },
        new Effect { ID = AnimationEffect.SlideBottomIn,    Text = "SlideBottomIn" },
        new Effect { ID = AnimationEffect.SlideTopOut,      Text = "SlideTopOut" },
        new Effect { ID = AnimationEffect.SlideBottomOut,   Text = "SlideBottomOut" },
        new Effect { ID = AnimationEffect.FadeIn,           Text = "FadeIn" },
        new Effect { ID = AnimationEffect.FadeOut,          Text = "FadeOut" },
        new Effect { ID = AnimationEffect.FadeZoomIn,       Text = "FadeZoomIn" },
        new Effect { ID = AnimationEffect.FadeZoomOut,      Text = "FadeZoomOut" },
        new Effect { ID = AnimationEffect.ZoomIn,           Text = "ZoomIn" },
        new Effect { ID = AnimationEffect.ZoomOut,          Text = "ZoomOut" },
        new Effect { ID = AnimationEffect.FlipXDownIn,      Text = "FlipXDownIn" },
        new Effect { ID = AnimationEffect.FlipXDownOut,     Text = "FlipXDownOut" },
        new Effect { ID = AnimationEffect.FlipXUpIn,        Text = "FlipXUpIn" },
        new Effect { ID = AnimationEffect.FlipXUpOut,       Text = "FlipXUpOut" },
        new Effect { ID = AnimationEffect.FlipYLeftIn,      Text = "FlipYLeftIn" },
        new Effect { ID = AnimationEffect.FlipYLeftOut,     Text = "FlipYLeftOut" },
        new Effect { ID = AnimationEffect.FlipYRightIn,     Text = "FlipYRightIn" },
        new Effect { ID = AnimationEffect.FlipYRightOut,    Text = "FlipYRightOut" },
        new Effect { ID = AnimationEffect.FlipLeftDownIn,   Text = "FlipLeftDownIn" },
        new Effect { ID = AnimationEffect.FlipLeftDownOut,  Text = "FlipLeftDownOut" },
        new Effect { ID = AnimationEffect.FlipLeftUpIn,     Text = "FlipLeftUpIn" },
        new Effect { ID = AnimationEffect.FlipLeftUpOut,    Text = "FlipLeftUpOut" },
        new Effect { ID = AnimationEffect.FlipRightDownIn,  Text = "FlipRightDownIn" },
        new Effect { ID = AnimationEffect.FlipRightDownOut, Text = "FlipRightDownOut" },
        new Effect { ID = AnimationEffect.FlipRightUpIn,    Text = "FlipRightUpIn" },
        new Effect { ID = AnimationEffect.FlipRightUpOut,   Text = "FlipRightUpOut" },
        new Effect { ID = AnimationEffect.None,             Text = "None" }
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLRDdiWilSZPJDq?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customize Accordion expand or collapse animation behavior](./images/blazor-accordion-animation.webp)" %}

## See also

* [Getting Started with Blazor Accordion](https://blazor.syncfusion.com/documentation/accordion/getting-started)
* [Accessibility in Blazor Accordion](https://blazor.syncfusion.com/documentation/accordion/accessibility)
* [AccordionAnimationExpand API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionAnimationExpand.html)
* [AccordionAnimationCollapse API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionAnimationCollapse.html)
* [AnimationEffect Enumeration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.AnimationEffect.html)
