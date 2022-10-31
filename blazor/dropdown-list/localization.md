---
layout: post
title: Localization in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Localization in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Localization

[Blazor DropDownList](https://www.syncfusion.com/blazor-components/blazor-dropdown-list) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

## Blazor Server Application

* For **.NET 6** app, specify the static culture in **~/Program.cs** file.
* For **.NET 5 and .NET 3.X** app, specify the static culture in **~/Startup.cs** file.

{% tabs %}

{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="3" %}

...
var app = builder.Build();
app.UseRequestLocalization("de");
...

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="4" %}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    ...
    app.UseRequestLocalization("de");
    ...
}

{% endhighlight %}

{% highlight c# tabtitle="Index.razor" hl_lines="4" %}

@using Syncfusion.Blazor.DropDowns;

<SfDropDownList TValue="string" TItem="Games" Placeholder="Select a game" Width="300px" DataSource="@LocalData" @bind-Value="GameValue" Locale="de">
  <DropDownListFieldSettings Value="ID" Text="Text"></DropDownListFieldSettings>
</SfDropDownList>

{% endhighlight %}

{% endtabs %}

### Blazor WASM Application

In Blazor WASM app, you can set culture statically in Blazor's start option or in C# code.

#### Setting the culture Blazor's start option

The app's culture can be set in JavaScript by setting `applicationCulture` in Blazor's start option by following the steps below,

* In `wwwroot/index.html`, prevent Blazor autostart by adding `autostart="false"` attribute to Blazor's `<script>` tag.

{% tabs %}

{% highlight cshtml tabtitle="wwwroot/index.html" %}

<body>
    ...
    <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    ...
</body>

{% endhighlight %}

{% endtabs %}

* Add the script block below Blazor's `<script>` tag and before the closing </body> tag to start blazor with specific culture. 

{% tabs %}

{% highlight cshtml tabtitle="wwwroot/index.html" hl_lines="4 5 6 7 8" %}

<body>
    ...
    <script src="_framework/blazor.webassembly.js" autostart="false"></script>
    <script>
        Blazor.start({
            applicationCulture: 'de'
        });
    </script>
    ...
</body>

{% endhighlight %}

{% highlight cshtml tabtitle="Index.razor"  %}

@using Syncfusion.Blazor.DropDowns;

<SfDropDownList TValue="string" TItem="Games" Placeholder="Select a game" Width="300px" DataSource="@LocalData" @bind-Value="GameValue" Locale="fr">
  <DropDownListFieldSettings Value="ID" Text="Text"></DropDownListFieldSettings>
</SfDropDownList>

{% endhighlight %}

{% endtabs %}

### Enable RTL mode

You can specifies [EnableRtl](Enable or disable rendering component in right to left direction.) as boolean value that indictes to Enable or disable rendering component in right to left direction.

{% highlight cshtml %}

{% include_relative code-snippet/localization/enableRtl.razor %}

{% endhighlight %}

![Blazor DropDownList with clear button](./images/localization/blazor_dropdown_enableRtl.png)

