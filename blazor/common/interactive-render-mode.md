---
layout: post
title: Interactive Render Mode in Blazor Web App | Syncfusion
description: Check out the documentation for Interactive Render Mode in Syncfusion Blazor Components in Blazor Web App.
platform: Blazor
component: Common
documentation: ug
---

# Render Interactive Modes in Blazor Web App

This section explains the set of commands used to create a Blazor Web App with various Interactive Render Modes. These commands can be executed via the command prompt (Windows), terminal (macOS), or shell (Linux), allowing you to create Blazor applications using different rendering modes.

If you set the Authentication Type as `None` and Interactivity location as `Per page/component`, you need to use the following command.

<table style="width:100%">
<tr>
<th style="width:30%">Interactive Render Mode</th>
<th style="width:70%">Command</th>
</tr>
<tr>
<td>Server</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int Server
{% endhighlight %}
</td>
</tr>
<tr>
<td>WebAssembly</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int WebAssembly
{% endhighlight %}
</td>
</tr>
<tr>
<td>Auto</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int Auto
{% endhighlight %}
</td>
</tr>
<tr>
<td>None</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int None
{% endhighlight %}
</td>
</tr>
</table>

If you set the Authentication Type as `Individual Accounts` and Interactivity location as `Per page/component`, you need to use the following command.

<table style="width:100%">
<tr>
<th style="width:30%">Interactive Render Mode</th>
<th style="width:70%">Command</th>
</tr>
<tr>
<td>Server</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int Server
{% endhighlight %}
</td>
</tr>
<tr>
<td>WebAssembly</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int WebAssembly
{% endhighlight %}
</td>
</tr>
<tr>
<td>Auto</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int Auto
{% endhighlight %}
</td>
</tr>
<tr>
<td>None</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int None
{% endhighlight %}
</td>
</tr>
</table>

If you set the Authentication Type as `Individual Accounts` and Interactivity location as `Global`, you need to use the following command.

<table style="width:100%">
<tr>
<th style="width:30%">Interactive Render Mode</th>
<th style="width:70%">Command</th>
</tr>
<tr>
<td>Server</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int Server -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>WebAssembly</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int WebAssembly -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>Auto</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int Auto -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>None</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -au Individual -int None -ai
{% endhighlight %}
</td>
</tr>
</table>

If you set the Authentication Type as `None` and Interactivity location as `Global`, you need to use the following command.

<table style="width:100%">
<tr>
<th style="width:30%">Interactive Render Mode</th>
<th style="width:70%">Command</th>
</tr>
<tr>
<td>Server</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int Server-ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>WebAssembly</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp -int WebAssembly -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>Auto</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp8 -int Auto -ai
{% endhighlight %}
</td>
</tr>
<tr>
<td>None</td>
<td>
{% highlight c# %}
dotnet new blazor -o BlazorApp8 -int None -ai
{% endhighlight %}
</td>
</tr>
</table>

N> If you want to see more available templates, you need to run the `dotnet new blazor --help` or `dotnet new blazor -h` command.