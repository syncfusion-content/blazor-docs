---
layout: post
title: Filtering in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about Filtering in Syncfusion Blazor Mention component and more.
platform: Blazor
control: Mention
documentation: ug
---

# Filtering data in Mention

The Mention component has built-in support to filter data items. The filter operation starts as soon as you start typing characters in the mention element.

## Limit the minimum filter character

You can control the minimum length of user input to initiate the search action using the `MinLength` property. This can be useful if you have a very large list of data. The default value is `0`, where the suggestion list opens as soon as the user inputs the mention character.

The remote request does not fetch the search data until the search key contains three characters as shown in the following example.

{% highlight razor %}

{% include_relative code-snippet/minimum-filter-char.razor %}

{% endhighlight %}

## Change the filter type

While filtering, you can change the filter type to Contains, StartsWith, or EndsWith in the `FilterType` property. The default filter operator is Contains.

* StartsWith - Filter the items that begin with the specified text value.
* Contains - Filter the items that contain the specified text value.
* EndsWith - Filter the items that end with the specified text value.

{% highlight razor %}

{% include_relative code-snippet/filter-type.razor %}

{% endhighlight %}

## Allow spacing between search

While filtering the data in the data source, you can allow the space in the middle of the mention using the `AllowSpaces` property. If the data source does not match with the mentioned element data, the popup will be hidden on the space key press. The default value of the `AllowSpaces` is `false`.

> By default, the `AllowSpaces` property is disabled, and the space ends the mention component search.

{% highlight razor %}

{% include_relative code-snippet/allow-space.razor %}

{% endhighlight %}

![Blazor Mention with allow space between search](./images/blazor-mention-allow-space.png)

## Customize the suggestion item count

While filtering, you can customize the number of list items to be displayed in the suggestion list using the `SuggestionCount` property.

{% highlight razor %}

{% include_relative code-snippet/suggestion-list-count.razor %}

{% endhighlight %}

![Blazor Mention with suggestion item count](./images/blazor-mention-allow-space.png)

## See also

* [Templates](./templates)