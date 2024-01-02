---
layout: post
title: Reuse of Blazor Media Query component | Syncfusion
description: Checkout and learn here all about how to use the Media Query component at the global level reuse on all pages and much more.
platform: Blazor
control: Media Query
documentation: ug
---

# Global level reuse of Blazor Media Query component

You can reuse the `Media Query` component across various sections of your applications which maintain a consistent and adaptive design.

The Syncfusion Media Query component can be reused by creating a new Blazor component:

1. Right-click on the **~/Pages** folder in the Visual Studio and select **Add -> Razor Component** to create a new Razor component (ReusableMediaQuery.razor).

2. Add the Syncfusion Blazor Media Query component in the **~/Pages/ReusableMediaQuery.razor** file.

{% tabs %}
{% highlight razor %}

<SfMediaQuery @bind-ActiveBreakPoint="activeBreakpoint"></SfMediaQuery>
@if (activeBreakpoint == "Small")
{
    deviceSize = "small-device";
}
else if (activeBreakpoint == "Medium")
{
    deviceSize = "medium-device";
}
else
{
    deviceSize = "";
}

<div class="mediaquery-demo @deviceSize">
    <div class="main-container">
        <ul>
            <li>
                <div class="content e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <div class="title e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <p class="e-skeleton e-skeleton-text e-shimmer-pulse"></p>
            </li>
            <li>
                <div class="content e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <div class="title e-skeleton e-skeleton-text e-shimmer-pulse"></div>
                <p class="e-skeleton e-skeleton-text e-shimmer-pulse"></p>
            </li>
        </ul>
    </div>
</div>

@code {
    public string deviceSize { get; set; }    
    public string activeBreakpoint { get; set; }
}
<style>
    .mediaquery-demo {
        height: 715px;
    }

    .mediaquery-demo .e-skeleton {
        display: block;
    }

    .mediaquery-demo .main-container {
        margin: 0 8%;
        height: 35%;
    }

    .mediaquery-demo .main-container ul {
        list-style: none;
        display: flex;
        height: 100%;
        padding: 0;
        justify-content: space-between;
        padding-top: 20px;
    }

    .mediaquery-demo .main-container ul li {
        width: 49%;
    }

    .mediaquery-demo .main-container li .content {
        height: 60%;
    }

    .mediaquery-demo .main-container li .title,
    .mediaquery-demo .main-container li p {
        width: 50%;
        height: 7%;
        margin-top: 3%;
    }

    .mediaquery-demo .main-container li p {
        width: 80%;
    }

    .mediaquery-demo.medium-device .main-container {
        margin: 0px;
    }

    .mediaquery-demo.medium-device .main-container {
        height: 42%;
    }

    .mediaquery-demo.medium-device .main-container ul {
        flex-direction: column;
    }

    .mediaquery-demo.medium-device .main-container ul li {
        height: 50%;
        display: flex;
        margin-bottom: 2%;
        margin-left: 5%;
        width: 100%;
    }

    .mediaquery-demo.medium-device .main-container li .content {
        height: auto;
        width: 30%;
    }

    .mediaquery-demo.medium-device .main-container li .title,
    .mediaquery-demo.medium-device .main-container li p {
        height: 24%;
    }

    .mediaquery-demo.medium-device .main-container li .title {
        margin-left: 5%;
        width: 25%;
        margin-top: 0;
    }

    .mediaquery-demo.medium-device .main-container li p {
        margin-top: 8%;
        margin-left: -25%;
        width: 55%;
    }

   .mediaquery-demo.small-device .main-container {
        margin: 0px;
        height: 20%;
    }

    .mediaquery-demo.small-device .main-container {
        height: 48%;
    }

    .mediaquery-demo.small-device .main-container ul {
        display: block;
    }

    .mediaquery-demo.small-device .main-container ul li {
        height: 50%;
        display: block;
        width: 90%;
        margin: 0 auto;
    }

    .mediaquery-demo.small-device .main-container li .content {
        height: 40%;
        width: auto;
    }

    .mediaquery-demo.small-device .main-container li .title {
        width: 40%;
        height: 10%;
    }

    .mediaquery-demo.small-device .main-container li p {
        width: auto;
        height: 10%;
    }
</style>

{% endhighlight %}
{% endtabs %}

3. Render your new component in the view page **~/Pages/Home.razor or Index.razor** and run the application.

{% tabs %}
{% highlight razor %}

<ReusableMediaQuery></ReusableMediaQuery>

@code {
    protected override void OnInitialized()
    {
        SfMediaQuery.Small.MediaQuery = "(max-width: 500px)";
        SfMediaQuery.Medium.MediaQuery = "(min-width: 500px)";
        SfMediaQuery.Large.MediaQuery = "(min-width: 1600px)";
        base.OnInitialized();
    }    
}

{% endhighlight %}
{% endtabs %}

![Reusable Blazor Media Query Component](images/blazor-media-query-reusable.png)