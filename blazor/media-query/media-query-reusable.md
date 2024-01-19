---
layout: post
title: Reuse of Blazor Media Query component | Syncfusion
description: Checkout and learn here all about how to use the Media Query component at the global level reuse on all pages and much more.
platform: Blazor
control: Media Query
documentation: ug
---

# Global level reuse of Blazor Media Query component

You can reuse the `Media Query` component across different parts of your application to keep the design the consistent and adaptable.

1. Click on the **~/Shared** folder in Visual Studio and select **MainLayout.razor** to define the `Media Query` component globally.

2. Place the `Media Query` component within the `CascadingValue`, and create a public variable named `activeBreakPoint` as a parameter.

{% tabs %}
{% highlight razor %}

@inherits LayoutComponentBase

<PageTitle>BlazorValue</PageTitle>

<div class="page">
    <div class="sidebar">
        <NavMenu />
    </div>
    <main>
        <div class="top-row px-4">
            <a href="https://docs.microsoft.com/aspnet/" target="_blank">About</a>
        </div>
        <article class="content px-4">
            <CascadingValue Value="@this">
                <SfMediaQuery @bind-ActiveBreakPoint="activeBreakPoint"></SfMediaQuery>
                @Body
            </CascadingValue>
        </article>
    </main>
</div>

@code {
    [Parameter]
    public string activeBreakPoint { get; set; }
}

{% endhighlight %}
{% endtabs %}

3. Inherit the `MainLayout` component in the view page, such as **~/Pages/Home.razor or Index.razor**, and run the application.

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