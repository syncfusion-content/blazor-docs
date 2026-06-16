---
layout: post
title: Configure Services in Blazor Playground | Syncfusion®
description: Learn how to configure services and dependency injection in Blazor Playground by registering services in Program.cs and injecting them into Blazor components.
platform: Blazor
control: Common
documentation: ug
---

# Configure Services in Blazor Playground

You can add or modify services in [Blazor Playground](https://blazorplayground.syncfusion.com) using the **Services** button in the app bar.

The following example creates a `CounterService` class, registers it in `Program.cs`, and injects it into `_Index.razor` to manage a counter with increment and decrement actions.

1\. Click the **+** button to add a new file and include the `CounterService` code.

{% tabs %}
{% highlight c# tabtitle="CounterService.cs"  %}

using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Playground.User
{
    public class CounterService
    {
        private int _count = 0;

        public int Count => _count;

        public void Increment()
        {
            _count++;
        }

        public void Decrement()
        {
            _count--;
        }
    }
}

{% endhighlight %}
{% endtabs %}

2\. Click the **Services** button to open `Program.cs` and register the service in `ConfigureServices`.

{% tabs %}
{% highlight csharp tabtitle="Program.cs" %}

using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Playground.User
{
    public class Program
    {
        /// <summary>
        /// Configure Services method to add and configure the <see href="https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection">service collection</see>.
        /// </summary>
        /// <param name="WebAssemblyHostBuilder">A builder for configuring services and creating a WebAssemblyHost.</param>
        /// <returns>The collection of services.</returns>
        public static void ConfigureServices(WebAssemblyHostBuilder builder)
        {
            builder.Services.AddScoped<CounterService>();
            // Configure your service here.
            // For e.g., builder.Services.AddSingleton(new CustomClass());
        }
    }
}

{% endhighlight %}
{% endtabs %}

3\. Inject the service into `_Index.razor` file.

{% tabs %}
{% highlight razor tabtitle="_Index.razor" %}

<h3>Counter</h3>

<p>Current Count: @counterService.Count</p>

<button @onclick="Increment">Increment</button>
<button @onclick="Decrement">Decrement</button>

@code {
    [Inject]
    private CounterService counterService { get; set; }

    private void Increment()
    {
        counterService.Increment();
    }

    private void Decrement()
    {
        counterService.Decrement();
    }
}

{% endhighlight %}
{% endtabs %}

4\. Press the **Run** button or <kbd>Ctrl</kbd>+<kbd>R</kbd> to execute the code. The output appears in the result view.

![Blazor Playground with adding services](images/add_services.webp)

## See also

* [Getting Started with Blazor Playground](./getting-started)
* [Working with components in Blazor Playground](./working-with-components)
* [Manage NuGet packages in Blazor Playground](./managing-nuget-packages)
* [Features and capabilities of Blazor Playground](./end-user-capabilities)

