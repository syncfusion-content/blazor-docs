# Validate the text when renaming the tree node

You can validate the tree node text while editing using `NodeEdited` event of the TreeView. Following is an example that shows how to validate and prevent empty values in tree node.

```csharp
@using Syncfusion.Blazor.Navigations
    <SfTreeView TValue="MusicAlbum" AllowEditing="true" @ref="tree">
        <TreeViewEvents TValue="MusicAlbum" NodeEdited="AfterEdit"></TreeViewEvents>
        <TreeViewFieldsSettings TValue="MusicAlbum" Id="Id" DataSource="@Albums" Text="Name" ParentID="ParentId" HasChildren="HasChild" Expanded="Expanded" IsChecked="IsChecked"></TreeViewFieldsSettings>
    </SfTreeView>
    @if (EditedStatus != null)
    {
        @EditedStatus
    }
    @code{
        public class MusicAlbum
        {
            public int Id { get; set; }
            public int? ParentId { get; set; }
            public string Name { get; set; }
            public bool Expanded { get; set; }
            public bool? IsChecked { get; set; }
            public bool HasChild { get; set; }
        }
        SfTreeView<MusicAlbum> tree;

        string EditedStatus = null;

        List<MusicAlbum> Albums = new List<MusicAlbum>();

        void AfterEdit(NodeEditEventArgs args)
        {
            if (args.NewText.Trim() == "")
            {
                args.Cancel = true;
                EditedStatus = "TreeView item text should not be empty";
                StateHasChanged();
            }
            else if (args.NewText != args.OldText)
            {
                EditedStatus = "TreeView item text edited successfully";
                StateHasChanged();
            }
            else
            {
                EditedStatus = null;
            }
        }
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Albums.Add(new MusicAlbum
            {
                Id = 1,
                Name = "Discover Music",
                HasChild = true,
            });
            Albums.Add(new MusicAlbum
            {
                Id = 2,
                ParentId = 1,
                Name = "Hot Singles"
            });
            Albums.Add(new MusicAlbum
            {
                Id = 3,
                ParentId = 1,
                Name = "Rising Artists"
            });
            Albums.Add(new MusicAlbum
            {
                Id = 4,
                ParentId = 1,
                Name = "Live Music"
            });
            Albums.Add(new MusicAlbum
            {
                Id = 14,
                HasChild = true,
                Name = "MP3 Albums",
                Expanded = true,
                IsChecked = true
            });
            Albums.Add(new MusicAlbum
            {
                Id = 15,
                ParentId = 14,
                Name = "Rock"
            });
            Albums.Add(new MusicAlbum
            {
                Id = 16,
                Name = "Gospel",
                ParentId = 14,
            });
            Albums.Add(new MusicAlbum
            {
                Id = 17,
                ParentId = 14,
                Name = "Latin Music"
            });
            Albums.Add(new MusicAlbum
            {
                Id = 18,
                ParentId = 14,
                Name = "Jazz"
            });
        }
    }

```

Output be like the below.

![TreeView Sample](../images/validate-text.png)