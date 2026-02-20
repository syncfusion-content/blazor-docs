---
layout: post
title: Blazor Angular integration | Syncfusion
description: Learn how to integrate Blazor syncfusion components with angular.
platform: Blazor
component: Common
documentation: ug
---

# Integrating Syncfusion Blazor Components in Angular Using Blazor Custom Elements 

This guide demonstrates how to use **Syncfusion Blazor components** inside an **Angular** application. 

Blazor and Angular are two different web technologies. Blazor uses .NET and Razor components, while Angular uses TypeScript and HTML. Normally, these frameworks cannot share UI components. However, **Blazor Custom Elements** make this possible. A Custom Element turns a Blazor component into a normal HTML tag that Angular can recognize and display. 

## Prerequisite software

* .NET 10 SDK 
* Node.js 18+ 
* Angular CLI 18+ 

## Creating the Blazor Application 

### Create the project

If you already have a Blazor project, continue to package installation. Otherwise, create one using Syncfusion’s Blazor getting‑started guides  

[Web Assembly](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

[Server](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

### Install Custom Elements packages

To enable Custom Elements, install the required Microsoft packages:

```
dotnet add package Microsoft.AspNetCore.Components.Web --version 10.0.3 
dotnet add package Microsoft.AspNetCore.Components.CustomElements --version 10.0.3 
```

Alternatively, install them using the NuGet Package Manager:

```
Microsoft.AspNetCore.Components.Web 
Microsoft.AspNetCore.Components.CustomElements 
```

### Register it as a Custom Element 

Add the following line inside **Program.cs** to expose the component as a Custom Element:

```
builder.RootComponents.RegisterCustomElement<SfxGridWasm.Pages.OrdersGrid>("sf-orders-grid"); 
```

## Integrating the Custom Element in Angular 

### Create the Angular app 

If you already have an Angular project, move to the next step. Otherwise, create one using the Angular CLI. 

```
ng new AngularApp --standalone 
```

### Configure Angular proxy 

Blazor and Angular run on different local servers. To allow Angular to load Blazor files, you must create a proxy file. 

Create a new file named **proxy.conf.json** inside the Angular project’s src/ folder and add the following content:

```
{ 

  "/blazor": { 
    "target": "http://localhost:5021", //Here share the hosted url of blazor 
    "secure": false, 
    "changeOrigin": true, 
    "logLevel": "debug", 
    "pathRewrite": { "^/blazor": "" } 
  }, 
  "/_framework": { 
    "target": "http://localhost:5021", 
    "secure": false, 
    "changeOrigin": true, 
    "logLevel": "debug" 
  }, 
  "/_content": { 
    "target": "http://localhost:5021", 
    "secure": false, 
    "changeOrigin": true, 
    "logLevel": "debug" 
  } 
} 

```

Then update the start script in **package.json**: 

```
"start": "ng serve --proxy-config proxy.conf.json" 
```

### Load Syncfusion & Blazor runtime scripts

These scripts are required for loading both the Blazor runtime and Syncfusion components. Add them to Angular’s **index.html** file.

```
<link rel="stylesheet" href="/blazor/_content/Syncfusion.Blazor.Themes/bootstrap5.css" /> 
<script src="/blazor/_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js"></script> 
```
WebAssembly:

```
<script src="/blazor/_framework/blazor.webassembly.js"></script> 
```

Server:

```
<script src="/blazor/_framework/blazor.server.js"></script> 
```

###  Use the custom element in Angular

Now that everything is configured, you can display your Blazor component inside Angular. 

Here, define the schemas and custom element tag in the **app.ts** file. 

```
import { Component, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core'; 

@Component({ 
  selector: 'app-root', 
  template: `<sf-orders-grid></sf-orders-grid>`, 
  schemas: [CUSTOM_ELEMENTS_SCHEMA] 
}) 

export class AppComponent {} 

```

CUSTOM_ELEMENTS_SCHEMA allows Angular to accept unknown HTML tags like <sf-orders-grid>. 

## Running Both Applications 

You can run both apps separately or together. 

### Options 1: Run separately 

Blazor host:

```
dotnet run
```

Angular app:

```
npm start
```
Open the Angular development URL to see the Blazor Grid inside Angular. 

N> Start the Blazor application first so Angular can load its resources through the proxy.

### Options 2:  Run both with concurrently 

```
npm install --save-dev concurrently 
```

N> Install this package once

Add the following scripts to  **package.json**

```
"start:blazor": "dotnet watch run --project ../SfxGridWasm", //Here share the blazor project name 

"start:ng": "ng serve --proxy-config proxy.conf.json", 

"start:all": "concurrently -k -n BLAZOR,ANGULAR -c cyan,green \"npm:start:blazor\" \"npm:start:ng\"", 
```

Then, Run both with one command:  

```
 npm run start:all 
```

