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

Define the Media Query component along with layout `Body` property within the `CascadingValue` component in **MainLayout.razor** page.

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
            <CascadingValue Value="@activeBreakPoint">
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

If you are using .NET 9 or .NET 8, configure the `@rendermode` in the `<body>` section of the **~/Components/App.razor** file, as shown below:

```html
<body>
    ....
    <Routes @rendermode="InteractiveServer" />
</body>
```

In the below example, the `activeBreakPoint` was accessed in the **Home.razor** and **Counter.razor** files.

{% tabs %}
{% highlight C# tabtitle="Home" hl_lines="3 10" %}

The active breakpoint is @activeBreakPoint
<br/><br/>
<h5>Home Page</h5>

@code {
    [CascadingParameter]
    public string activeBreakPoint { get; set; }
}
....

{% endhighlight %}
{% highlight C# tabtitle="Counter" hl_lines="3 11" %}

The active breakpoint is @activeBreakPoint
<br /><br />
<h5>Counter Page</h5>

@code {
    [CascadingParameter]
    public string activeBreakPoint { get; set; }
}
....

{% endhighlight %}
{% endtabs %}

![Reusable Blazor Media Query Component](images/blazor-media-query-reusable.gif)