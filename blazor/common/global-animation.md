---
layout: post
title: Global Animation in Blazor components | Syncfusion
description: Enable/Disable the Animation globally for Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Enable/Disable the Animation Globally

This section provides information about the animation process and how to enable/disable it globally for Syncfusion Blazor Components.

## Animation Property

Syncfusion Blazor Component's animation enable/disable globally by using `Animation` property. Below options are used to handle the animation of Syncfusion Blazor Components. 

* Enable
* Disable
* Default

### Enable

Enables the Animation for Syncfusion Blazor components in entire Application. It doesn’t consider individual component’s animation property value.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSyncfusionBlazor(options => { options.Animation = GlobalAnimationMode.Enable; });

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="12" %}

using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor(options => { options.Animation = GlobalAnimationMode.Enable; });
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

### Disable

Disables the Animation for all Syncfusion Blazor components in entire Application. It doesn’t consider individual component’s animation property value.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSyncfusionBlazor(options => { options.Animation = GlobalAnimationMode.Disable; });

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="12" %}

using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor(options => { options.Animation = GlobalAnimationMode.Disable; });
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

### Default

Enables/Disables the animation based on Syncfusion Blazor Component's default animation property value which is defined in component/sample level.

{% tabs %}
{% highlight c# tabtitle=".NET 6 (~/Program.cs)" hl_lines="10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSyncfusionBlazor(options => { options.Animation = GlobalAnimationMode.Default; });

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 and .NET 3.X (~/Startup.cs)" hl_lines="12" %}

using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ...
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSyncfusionBlazor(options => { options.Animation = GlobalAnimationMode.Default; });
        }
        ...
    }
}

{% endhighlight %}
{% endtabs %}

> Global animation support is only applicable for Animation Supported Syncfusion Blazor Components. Also, it doesn't applicable for direct CSS level animations which means animation defined from CSSs Classes/Properties.