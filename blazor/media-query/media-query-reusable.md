---
layout: post
title: Reuse of Blazor Media Query component | Syncfusion
description: Checkout and learn here all about how to use the Media Query component at the global level reuse on all pages and much more.
platform: Blazor
control: Media Query
documentation: ug
---

# Global level reuse of Blazor Media Query component

You can globally reuse the Media Query component in any `razor` pages within web application to achieve a more flexible and responsive layout design. 

Refer the following steps to reuse the Media Query in any `razor` pages.

1. Define the Media Query component along with layout `Body` property within the `CascadingValue` component in **MainLayout.razor** page.

{% tabs %}
{% highlight razor %}

@inherits LayoutComponentBase

<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>
    <main>
        <div class="top-row px-4">
            <a href="https://docs.microsoft.com/aspnet/" target="_blank">About</a>
        </div>
        <article class="content px-4">
            <CascadingValue Value="@activeBreakpoint">
                <SfMediaQuery @bind-ActiveBreakPoint="activeBreakPoint"></SfMediaQuery>
                @Body
            </CascadingValue>
        </article>
    </main>
</div>

@code {
    private string activeBreakpoint { get; set; }
}

{% endhighlight %}
{% endtabs %}

2. Inherit the `MainLayout` component in your razor pages to access the `activeBreakPoint` and run the application.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor
@inherits MainLayout

The active breakpoint is @mainLayoutObj.activeBreakPoint

@code {
    [CascadingParameter]
    public MainLayout mainLayoutObj { get; set; }
}

{% endhighlight %}
{% endtabs %}

![Reusable Blazor Media Query Component](images/blazor-media-query-reusable.gif)