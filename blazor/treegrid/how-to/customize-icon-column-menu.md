# Customize column menu icon

You can customize the column menu icon by overriding the default icon class `.e-icons.e-columnmenu` with the `content` property.

```css
.e-grid .e-columnheader .e-icons.e-columnmenu::before {
    content: "\e705";
}
```

This is demonstrated in the below sample code,

{% aspTab template="tree-grid/how-to/customize-icon", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

The following image represents Tree Grid with customized column menu icon
![Customize column menu icon](../images/customize-column-menu-icon.png)