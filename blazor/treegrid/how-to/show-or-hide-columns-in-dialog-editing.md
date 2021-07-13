# Show or Hide columns in dialog editing

You can show hidden columns or hide visible column’s editor in the dialog while editing the Tree Grid record. This can be achieved by **Template**.
In the below example, we have rendered the Tree Grid columns `Progress` as hidden column and `Priority` as visible column. In the edit mode, we have changed the `Progress` column to visible state and `Priority` column to hidden state.

{% aspTab template="tree-grid/how-to/show-hide-column", sourceFiles="index.razor,treegriddata.cs" %}

{% endaspTab %}

Output be like the below.
![`Final output`](../images/showhidecolumn.PNG)