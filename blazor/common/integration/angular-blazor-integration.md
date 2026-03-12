---
layout: post
title: Angular Blazor integration | Syncfusion
description: Learn how to host Syncfusion Angular components into an Blazor app by packaging them as Angular Custom Elements for seamless UI rendering.
platform: Blazor
control: Common
documentation: ug
---

# Integrating Syncfusion Angular Components in Blazor

This guide explains how to render **Syncfusion Angular components** inside a **Blazor application** by packaging the Angular component as a **Custom Element (Web Component)**. Blazor and Angular use different rendering engines, so Angular cannot run directly inside a Blazor page. However, **Angular Custom Elements** allow Angular components to be compiled into standard HTML tags, enabling seamless integration within Blazor.

## Prerequisites

* .NET 10 SDK 
* Node.js 18+ 
* Angular CLI 18+ 

## Creating the Angular Application 

### Create the project

If you already have an Angular project, proceed to custom elements package installation. Otherwise, create a new Angular project following Syncfusion’s documentation.

[Angular Getting Started](https://ej2.syncfusion.com/angular/documentation/getting-started/angular-standalone).

### Install Custom Elements package

To enable Angular Custom Elements, install the package below: 

{% tabs %}
{% highlight C# tabtitle="Package Manager" %} 

npm i @angular/elements

{% endhighlight %}
{% endtabs %}

This package enables exporting Angular components as Web Components. This allows Blazor to load Angular UI using a simple HTML tag. 

### Add Syncfusion component

Update your **src/app/app.ts** file to incorporate the Syncfusion® DataGrid component: 

{% tabs %}
{% highlight ts tabtitle="app.ts" %}

import { Component } from '@angular/core';
import { GridModule } from '@syncfusion/ej2-angular-grids';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [GridModule],
  template: `
    <ejs-grid [dataSource]="data" height="400">
      <e-columns>
        <e-column field="OrderID" headerText="Order ID" width="120"></e-column>
        <e-column field="CustomerID" headerText="Customer ID" width="150"></e-column>
        <e-column field="Freight" headerText="Freight" width="120" format="C2"></e-column>
      </e-columns>
    </ejs-grid>
  `
})
export class AppComponent {
  public data = [
    { OrderID: 10248, CustomerID: 'VINET', Freight: 32.38 },
    { OrderID: 10249, CustomerID: 'TOMSP', Freight: 11.61 },
    { OrderID: 10250, CustomerID: 'HANAR', Freight: 65.83 }
  ];
}

{% endhighlight %}
{% endtabs %}

### Register the Angular component as a Custom Element

The Angular component is converted into a Web Component by registering it with **customElements.define()**. After this registration, the component is available as a standalone HTML element such as `<sf-grid>` that Blazor can display. 

Add the following code inside **main.ts** to expose the component as a Custom Elements.

{% tabs %}
{% highlight ts tabtitle="main.ts" %}

import { AppComponent} from './app/app';
import { createApplication, provideHttpClient } from '@angular/platform-browser';
import { createCustomElement } from '@angular/elements';

(async () => {
  try {
    const app = await createApplication({
      providers: [ provideHttpClient() ]
    });
    const element = createCustomElement(AppComponent, { injector: app.injector });
    if (!customElements.get('sf-grid')) {
      customElements.define('sf-grid', element);
    }
  } catch (err) {
    console.error(err);
  }
})();

{% endhighlight %}
{% endtabs %}

**Build the angular application:**

The Angular production build generates JavaScript and CSS files that represent the Web Component.

```
ng build --configuration production --output-hashing=none
```

## Integrating the Custom Elements in Blazor 

### Create the Blazor app 

If you already have a Blazor project, move to the next step. Otherwise, create one using the following command. 

**Blazor WebAssembly:**

```
dotnet new blazorwasm -o BlazorHost
```

**Blazor Server:**

```
dotnet new blazorserver -o BlazorHost
```

### Add MSBuild automation to build & copy Angular output

An MSBuild script is added to the Blazor project, so Angular builds automatically whenever Blazor builds. This ensures that the Web Component files are always up to date and copied into Blazor’s **wwwroot** folder. 

Add this target block to your Blazor project’s **.csproj** file:

{% tabs %}
{% highlight c# tabtitle=".csproj" %}

 <Target Name="BuildAngularElement" BeforeTargets="Build">

    <!-- Path to your Angular project -->
    <PropertyGroup>
      <AngularProject>../syncfusion-angular-app</AngularProject>
      <AngularDist>$(AngularProject)/dist/syncfusion-angular-app</AngularDist>
      <BlazorLib>wwwroot/lib/sf-grid</BlazorLib>
    </PropertyGroup>

    <!-- Install & build Angular (skip if you prefer pnpm/yarn) -->
    <Exec WorkingDirectory="$(AngularProject)" Command="npm ci" />
    <Exec WorkingDirectory="$(AngularProject)" Command="npx ng build --configuration production --output-hashing=none" />

    <!-- Clean & copy -->
    <RemoveDir Directories="$(BlazorLib)" />
    <MakeDir Directories="$(BlazorLib)" />
    <ItemGroup>
      <AngularFiles Include="$(AngularDist)\**\*.*" />
    </ItemGroup>
    <Copy SourceFiles="@(AngularFiles)"
          DestinationFolder="$(BlazorLib)" />
  </Target>

{% endhighlight %}
{% endtabs %}

### Load Web Component scripts/ themes in Blazor

 The generated Angular files (main.js and styles.css) are referenced inside the Blazor host page. This is required for the Web Component to initialize and render correctly inside the Blazor layout. 

**Web Assembly:**

Reference the stylesheet and script in the `<head>` of the **~wwwroot/index.html** file.

**Server:**

Reference the stylesheet and script in the `<head>` of the **Pages/_Host.cshtml** file.

{% tabs %}
{% highlight html %}

<link rel="stylesheet" href="/lib/sf-grid/styles.css" />
<script src="/lib/sf-grid/main.js"></script>

{% endhighlight %}
{% endtabs %}

###  Use the Angular Custom Element in Blazor

You can place the <sf-grid> HTML tag directly inside any **.razor** (e.g Index.razor) component. 

{% tabs %}
{% highlight razor tabtitle=".razor" %}

<sf-grid></sf-grid> 

{% endhighlight %}
{% endtabs %}

N> `<sf-grid>` is the wrapper web component, not the Syncfusion grid tag itself.

## Running the Applications 

```
dotnet run
```

Once the compilation is complete, open your browser and navigate to the hosted link to view your application with the integrated Syncfusion® DataGrid component:

![Blazor DataGrid Component](../images/angular-blazor-integration.webp)
