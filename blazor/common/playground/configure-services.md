---
layout: post
title: Configuration and new services in Blazor Playground | Syncfusion
description: Blazor Playground supports configuration and new services, making it easier to develop and maintain complex Blazor components.
platform: Blazor
component: Common
documentation: ug
---
# Configuring Services in Blazor Playground

You can add or modify services in Blazor Playground using the `Services` button in the app bar.
* Access the ConfigureServices method in Program.cs for adding new injectable services or overriding existing service configurations.
* Register the created service class in the ConfigureServices method.
* Inject the service into components as needed using dependency injection.

For example 

* Add a class file by clicking '+' button and include the following code snippet.

```csharp
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
```
* Click the "Services" button to configure the created class in the Program.cs file. Then, register the services in `ConfigureServices` method.

```csharp
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
```

* Include the dependency injection in the **__Index.razor** file.

```csharp

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

```
![Syncfusion Blazor Playground with adding services](images/add_services.gif)