---
layout: post
title: Authorization,Authentication in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Authorization and Authentication in Syncfusion Blazor TreeView component and much more details.
platform: Blazor
control: TreeView
documentation: ug
---

# Authorization and Authentication in Blazor TreeView Component

**Authentication** is the process of verifying the identity of a user or system. This is typically done by requiring a username and password, but can also include other forms of verification such as biometric data or security tokens.

**Authorization**, on the other hand, is the process of determining whether a user or system has access to a particular resource or action. Once a user's identity has been authenticated, the system can then determine whether they are authorized to perform a specific action or access a specific resource. This is often done by comparing the user's credentials or permissions against a set of rules or policies.

Provides a sample of Authorization and Authentication that explains how authorized users can access the TreeView. The below blog also includes steps to create a [Blazor Server App with Authentication](https://www.syncfusion.com/blogs/post/easy-steps-create-a-blazor-server-app-with-authentication.aspx), ensuring easy setup and configuration.

In the below example, the Blazor Server App is equipped with authentication, which ensures that only authorized users can access the TreeView.

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
