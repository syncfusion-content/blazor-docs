---
layout: post
title: Authorization,Authentication in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Authorization and Authentication in Syncfusion Blazor TreeView component and much more details.
platform: Blazor
control: TreeView
documentation: ug
---

# Authorization and Authentication in Blazor TreeView Component

**Authentication** involves verifying the identity of a user or system. This typically occurs through methods such as usernames and passwords, biometrics, or security tokens.

**Authorization** determines whether an authenticated user or system possesses the necessary permissions to access a specific resource or perform a particular action. After a user's identity is authenticated, the system evaluates their credentials or permissions against a set of established rules or policies to grant or deny access.

This section provides an example of implementing authorization and authentication to restrict access to the Blazor TreeView component to authorized users. The provided blog post details the steps for creating a [Blazor Server App with Authentication](https://www.syncfusion.com/blogs/post/easy-steps-create-a-blazor-server-app-with-authentication.aspx), facilitating easy setup and configuration for this example.

The following example demonstrates a Blazor Server App configured with authentication, ensuring that the entire TreeView component is only accessible to authenticated users.

```cshtml
@using Syncfusion.Blazor.Navigations

<AuthorizeView>
    <Authorized>
        <a href="Identity/Account/Manage">Hello, @context.User.Identity?.Name!</a>

        <SfTreeView TValue="MailItem">
            <TreeViewFieldsSettings TValue="MailItem" Id="Id" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
        </SfTreeView>
        <form method="post" action="Identity/Account/LogOut">
            <button type="submit" class="nav-link btn btn-link">Log out</button>
        </form>
        @code {
        public class MailItem
        {
            public string? Id { get; set; }
            public string? ParentId { get; set; }
            public string? FolderName { get; set; }
            public bool Expanded { get; set; }
            public bool HasSubFolders { get; set; }
        }
        List<MailItem> MyFolder = new List<MailItem>();
        protected override void OnInitialized()
        {
            base.OnInitialized();
            MyFolder.Add(new MailItem
            {
                Id = "1",
                FolderName = "Inbox",
                HasSubFolders = true,
                Expanded = true
            });
            MyFolder.Add(new MailItem
            {
                Id = "2",
                ParentId = "1",
                FolderName = "Categories",
                Expanded = true,
                HasSubFolders = true
            });
            MyFolder.Add(new MailItem
            {
                Id = "3",
                ParentId = "2",
                FolderName = "Primary"
            });
            MyFolder.Add(new MailItem
            {
                Id = "4",
                ParentId = "2",
                FolderName = "Social"
            });
            MyFolder.Add(new MailItem
            {
                Id = "5",
                ParentId = "2",
                FolderName = "Promotions"
            });
        }
        }
    </Authorized>
    <NotAuthorized>
        <p>Please log in or Register to view the TreeView component.</p>
        <a href="Identity/Account/Register">Register</a>
        <a href="Identity/Account/Login">Log in</a>
    </NotAuthorized>
</AuthorizeView>

```

N> The fully working sample can be found [here](https://github.com/SyncfusionExamples/Blazor-TreeView-Authentication-Authorization).
