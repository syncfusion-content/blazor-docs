---
layout: post
title: Add Sidebar to MainLayout of the .NET 8 Blazor Web app | Syncfusion
description: Learn here all about how to render the Sidebar component in the MainLayout page of the .NET 8 Blazor Web application and more.
platform: Blazor
control: Sidebar
documentation: ug
---

<!-- markdownlint-disable MD009 -->

# Render the Sidebar within the MainLayout of the .NET 8 Blazor Web App

Integrate the Blazor Sidebar component into the `MainLayout.razor` page of the .NET 8 application. Next, include the `@rendermode InteractiveServer` directive in the `Routes.razor` page of the application. Specifying `InteractiveServer` as the render mode for the `Routes` component enables interactive server-side rendering (SSR) for the entire Blazor application.

```cshtml

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Inputs
<div class="page">
    <div id="wrapper">
        <div>
            @*Initialize the Toolbar component*@
            <SfToolbar>
                <ToolbarEvents Clicked="@Toggle"></ToolbarEvents>
                <ToolbarItems>
                    <ToolbarItem PrefixIcon="e-tbar-menu-icon tb-icons" TooltipText="Menu"></ToolbarItem>
                    <ToolbarItem>
                        <Template>
                            <div class="e-folder">
                                <div class="e-folder-name">Navigation Pane</div>
                            </div>
                        </Template>
                    </ToolbarItem>
                </ToolbarItems>
            </SfToolbar>
        </div>
        @*Initialize the Sidebar component*@
        <SfSidebar @attributes="@HtmlAttribute" Width="290px" Target=".e-main-content" MediaQuery="(min-width:600px)" @bind-IsOpen="SidebarToggle">
            <ChildContent>
                <div class="main-menu">
                    <div class="table-content">
                        <SfTextBox Placeholder="Search..."></SfTextBox>
                        <p class="main-menu-header">TABLE OF CONTENTS</p>
                    </div>
                    <div>
                        <SfTreeView CssClass="main-treeview" ExpandOn="@Expand" TValue="TreeData">
                            <TreeViewFieldsSettings Id="NodeId" NavigateUrl="NavigateUrl" Text="NodeText" IconCss="IconCss" DataSource="Treedata" HasChildren="HasChild" ParentID="Pid">
                            </TreeViewFieldsSettings>                            
                        </SfTreeView>
                    </div>
                </div>
            </ChildContent>
        </SfSidebar>
        @*main-content declaration*@
        <div class="main-content" id="main-text">
            <div class="sidebar-content">
                <div class="content px-4">
                    @Body
                </div>
            </div>
            <!--end of main content declaration -->
        </div>
    </div>
</div>
@code {
    // Specifies the value of TreeView component ExpanOn property.
    public ExpandAction Expand = ExpandAction.Click;
    // Specify the value of Sidebar component state. It indicates whether the Sidebar component is in an open/close state.
    public bool SidebarToggle = false;
    // Specifies the value of Sidebar HTMLAttribute property.
    Dictionary<string, object> HtmlAttribute = new Dictionary<string, object>()
    {
        {"class", "sidebar-treeview" }
    };
    // Specifies the event handler for Clicked event in Toolbar component.
    public void Toggle(ClickEventArgs args)
    {
        if (args.Item.TooltipText == "Menu")
        {
            SidebarToggle = !SidebarToggle;
        }
    }
    public class TreeData
    {
        public string NodeId { get; set; }
        public string NodeText { get; set; }
        public string IconCss { get; set; }
        public bool HasChild { get; set; }
        public string Pid { get; set; }
        public string NavigateUrl { get; set; }
    }
    private List<TreeData> Treedata = new List<TreeData>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Treedata.Add(new TreeData { NodeId = "01", NodeText = "Installation", IconCss = "icon-microchip icon", NavigateUrl = "/error" });
        Treedata.Add(new TreeData { NodeId = "02", NodeText = "Deployment", IconCss = "icon-annotation-edit icon", NavigateUrl = "/counter" });
        Treedata.Add(new TreeData { NodeId = "03", NodeText = "Quick Start", IconCss = "icon-docs icon", NavigateUrl = "/" });
    }
}
<style>
    .toolbar-menu-toggle {
        border-bottom: 1px solid #d6d5d5
    }
    #wrapper {
        width: 100%;
    }
    #main-text.main-content {
        overflow: hidden;
    }

    #wrapper .sidebar-treeview {
        z-index: 20 !important;
    }

    .sidebar-treeview .main-treeview .icon {
        font-family: 'e-icons';
        font-size: 16px;
        margin: -4px 0;
    }

    .sidebar-top-row {
        background-color: #f7f7f7;
        border-bottom: 1px solid #d6d5d5;
        justify-content: flex-end;
        height: 3.5rem;
        display: flex;
        align-items: center;
        padding-left: 10px;
    }

    .sidebar-top-button {
        padding: 8px 16px;
        font-size: 16px;
        color: white;
        border: none;
        border-radius: 4px;
    }

    .sidebar-treeview .main-treeview .icon {
        font-family: 'e-icons';
        font-size: 16px;
        margin-top: -4px;
    }

    .e-sidebar {
        top: 40px !important;
        position: fixed;
    }

    .sidebar-treeview .main-treeview .icon-microchip::before {
        content: '\e77c';
    }

    .sidebar-treeview .main-treeview .icon-annotation-edit::before {
        content: '\e82a';
    }

    .sidebar-treeview .main-treeview .icon-docs::before {
        content: '\e8f1';
    }
    #wrapper .e-tbar-menu-icon::before {
        content: '\e799';
        font-family: 'e-icons';
    }

</style>

```

```cshtml

<--Add it in Router.razor--->

@rendermode InteractiveServer

<!-- Other codes -->

```