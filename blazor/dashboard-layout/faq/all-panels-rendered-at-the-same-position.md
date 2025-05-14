---
layout: post
title: Resolving Panel Positioning Issues in Blazor Dashboard Layout Component | Syncfusion
description: Check out and learn how to resolve panel positioning issues in the Syncfusion Blazor Dashboard Layout component.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Resolving Panel Positioning Issues in Blazor Dashboard Layout

When rendering panels dynamically in the Syncfusion Blazor Dashboard Layout component, all panels may appear in the same position (Row=0, Column=0). This issue occurs when each panel is assigned the same **Id**, causing the component to treat them as duplicates.

To avoid this issue, assign a unique [Id](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_Id) to each [DashboardLayoutPanel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html) when rendering them dynamically.

Here is an example of how to assign unique Ids to each panel:

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout CellSpacing="@(new double[]{20, 20})" Columns="4">
    <DashboardLayoutPanels>
        @foreach (var panel in PanelItems)
        {
            <DashboardLayoutPanel Id="@panel.Id" Row="@panel.Row" Column="@panel.Column">
                <ContentTemplate>
                    <div class="panel-content">@panel.Content</div>
                </ContentTemplate>
            </DashboardLayoutPanel>
        }
    </DashboardLayoutPanels>
</SfDashboardLayout>

@code {
    public class PanelModel
    {
        public string Id { get; set; }
        public int Row { get; set; } = 0;
        public int Column { get; set; } = 0;
        public string Content { get; set; }
    }

    private List<PanelModel> PanelItems = new List<PanelModel>
    {
        new PanelModel { Id = "panel1", Row = 0, Column = 0, Content = "Panel 1" },
        new PanelModel { Id = "panel2", Row = 0, Column = 1, Content = "Panel 2" },
        new PanelModel { Id = "panel3", Row = 0, Column = 2, Content = "Panel 3" },
        new PanelModel { Id = "panel4", Row = 1, Column = 0, Content = "Panel 4" },
        new PanelModel { Id = "panel5", Row = 1, Column = 1, Content = "Panel 5" },
        new PanelModel { Id = "panel6", Row = 1, Column = 2, Content = "Panel 6" }
    };
}

<style>
    .panel-content {
        text-align: center;
        margin-top: 10px;
        font-size: 18px;
        font-weight: 500;
    }
</style>

```

