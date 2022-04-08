---
layout: post
title: How to render Maps component inside other components | Syncfusion
description: How to render Maps component inside the other components.
platform: Blazor
control: Maps
documentation: ug
---

# Render Maps component inside other components

The Maps can be rendered within components such as the Dashboard Layout, Tabs, Dialog, and others. In general, the Maps component renders before other components, so a boolean variable ((i.e. boolean flag) is used to determine when to begin rendering the Maps component.

## Maps component inside Dashboard Layout

When the Maps component renders within a panel of the Dashboard Layout component, its rendering begins concurrently with the Dashboard Layout component's rendering. As a result, the size of the Maps component will not be proper. To properly render the Maps component, a boolean variable (i.e. **IsInitialRender**) must be created and it is used to determine the Maps component's rendering. The boolean variable is set to **false** by default, so the Maps component will not be rendered initially. When the Dashboard Layout component is rendered, its [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutEvents.html#Syncfusion_Blazor_Layouts_DashboardLayoutEvents_Created) event is fired, and the boolean variable (i.e. **IsInitialRender**) in this event must be changed to **true** to initiate the render of the Maps component.

When you drag and resize the Dashboard Layout's panel, the Maps component is not notified, so the Maps are not properly rendered within the panel. To avoid this scenario, the Maps component's [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Maps.SfMaps.html#Syncfusion_Blazor_Maps_SfMaps_Refresh) method must be called in the Dashboard Layout's [OnResizeStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutEvents.html#Syncfusion_Blazor_Layouts_DashboardLayoutEvents_OnResizeStop) and [OnWindowResize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutEvents.html#Syncfusion_Blazor_Layouts_DashboardLayoutEvents_OnWindowResize) events. Because the panel size of the Dashboard Layout is determined after a delay, a 1000 millisecond delay must be provided before refreshing the Maps component.

```cshtml
@using Syncfusion.Blazor.Maps

<SfDashboardLayout ID="Treemap" @ref="dashboardObject" AllowResizing="@AllowResizing"  AllowFloating="@AllowFloating" CellSpacing="@CellSpacing" Columns="@Columns">
<DashboardLayoutEvents OnResizeStop="ResizingHandler" OnWindowResize="ResizingHandler" Created="Created"></DashboardLayoutEvents>
    <DashboardLayoutPanels>
        <DashboardLayoutPanel Id="24" Row="0" Col="1" SizeX="@SizeX" SizeY="@SizeY">
            <HeaderTemplate><div> Maps </div></HeaderTemplate>
            <ContentTemplate>
                @if (IsInitialRender)
                {
                    <SfMaps ID="Maps" @ref="Maps" Width="100%">
                        <MapsLayers>
                            <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
                            </MapsLayer>
                        </MapsLayers>
                    </SfMaps>  
                }   
            </ContentTemplate>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

@code{
    SfDashboardLayout dashboardObject;
    public double[] CellSpacing = { 10, 10 };
    public int Columns = 20;
    public bool AllowFloating { get; set; } = true;
    public bool AllowResizing { get; set; } = true; 
    public int SizeX = 5;
    public int SizeY = 7;
    SfMaps Maps;

    public bool IsInitialRender { get; set; }

    public async void ResizingHandler(ResizeArgs args)
    {
        await Task.Delay(1000);
        Maps.Refresh();
    }
   
    public async void Created(Object args)
    {
        IsInitialRender = true;

    }
}

```
![Blazor Maps inside Dashboard Layout component](../images/maps-with-dashboard-layout.png)

## Maps component inside Tab

When the Maps component renders within the Tab component, its rendering begins concurrently with the Tab component's rendering. As a result, the size of the Maps component will not be proper. To properly render the Maps component, a boolean variable (i.e. **IsInitialRender**) must be created and it is used to determine the Maps component's rendering. The boolean variable is set to **false** by default, so the Maps component will not be rendered initially. When the Tab component is rendered, its [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TabEvents.html#Syncfusion_Blazor_Navigations_TabEvents_Created) event is fired, and the boolean variable (i.e. **IsInitialRender**) in this event must be changed to **true** to initiate the render of the Maps component.

```cshtml

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Maps


    <SfTab CssClass="default-tab">
        <TabEvents Created="Created"></TabEvents>
        <TabItems>
            <TabItem>
                <ChildContent>
                    <TabHeader Text="Maps"></TabHeader>
                </ChildContent>
                <ContentTemplate>
                 @if (IsInitialRender)
                 {
                    <SfMaps Width="100%">
                        <MapsLayers>
                            <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
                            </MapsLayer>
                        </MapsLayers>
                    </SfMaps>  
                 }   
                 </ContentTemplate>
            </TabItem>
            <TabItem>
                <ChildContent>
                    <TabHeader Text="OSM Maps"></TabHeader>
                </ChildContent>
                 <ContentTemplate>
                 @if (IsInitialRender)
                 {
                    <SfMaps ID="OSM" @ref="MapsOne" Width="100%">
                        <MapsLayers>
                            <MapsLayer UrlTemplate="https://tile.openstreetmap.org/level/tileX/tileY.png" TValue="string"></MapsLayer>
                        </MapsLayers>
                    </SfMaps>  
                 }   
                 </ContentTemplate>
            </TabItem>
            <TabItem>
                <ChildContent>
                    <TabHeader Text="SubLayer Maps"></TabHeader>
                </ChildContent>
                 <ContentTemplate>
                 @if (IsInitialRender)
                 {
                    <SfMaps ID="SubLayer">
                        <MapsLayers>
                            <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
                                <MapsShapeSettings Fill="#E5E5E5">
                                    <MapsShapeBorder Color="black" Width="0.1"></MapsShapeBorder>
                                </MapsShapeSettings>
                            </MapsLayer>
                            <MapsLayer ShapeData='new {dataOptions = "https://cdn.syncfusion.com/maps/map-data/usa.json"}'
	                    	        Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
                                <MapsShapeSettings Fill="rgba(141, 206, 255, 0.6)">
                                    <MapsShapeBorder Color="#1a9cff" Width="0.25"></MapsShapeBorder>
                                </MapsShapeSettings>
                            </MapsLayer>
                            <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/california.json"}'
	                    	        Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
                                <MapsShapeSettings Fill="rgba(141, 206, 255, 0.6)">
                                    <MapsShapeBorder Color="#1a9cff" Width="0.25"></MapsShapeBorder>
                                </MapsShapeSettings>
                            </MapsLayer>
                        </MapsLayers>
                    </SfMaps> 
                 }   
                 </ContentTemplate>
            </TabItem>
        </TabItems>
    </SfTab>

@code{
    public bool IsInitialRender { get; set; }
    public void Created()
    {
        IsInitialRender = true;
    }
}

```
![Blazor Maps inside Tab component](../images/maps-with-tab.png)


## Maps component inside Dialog

When the Maps component renders within the Dialog component, its rendering begins concurrently with the Dialog component's rendering. As a result, the size of the Maps component will not be proper. To properly render the Maps component, a boolean variable (i.e. **IsInitialRender**) must be created and it is used to determine the Maps component's rendering. The boolean variable is set to **false** by default, so the Maps component will not be rendered initially. When the Dialog component is being opened, its [OnOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_OnOpen) event is fired, and the boolean variable (i.e. **IsInitialRender**) in this event must be changed to **true** to initiate the render of the Maps component. When the Dialog component is closed, its [Closed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Popups.DialogEvents.html#Syncfusion_Blazor_Popups_DialogEvents_Closed) event is fired, and the boolean variable (i.e. **IsInitialRender**) in this event must be changed to **false**.

```cshtml

@using Syncfusion.Blazor.Popups
@using Syncfusion.Blazor.Maps

<div class="col-lg-12 control-section" id="target">
    <div>
        @if (this.ShowButton)
        {
            <button class="e-btn" @onclick="@OnClicked">Open</button>
        }
    </div>
    <SfDialog ResizeHandles="@dialogResizeDirections" AllowDragging="true" EnableResize="true" ShowCloseIcon="true" @bind-Visible="Visibility">
        <DialogTemplates>
            <Header>Maps</Header>
            <Content> 
                @if(IsInitialRender)
                {
                     <SfMaps ID="Maps" @ref="Maps" Width="100%">
                        <MapsLayers>
                            <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
                            </MapsLayer>
                        </MapsLayers>
                    </SfMaps>  
                }
            </Content>
        </DialogTemplates>
        <DialogEvents OnOpen="@DialogOpen" Closed="@DialogClose"></DialogEvents>
    </SfDialog>
</div>
<style>

</style>
@code {
    SfMaps Maps;
    public bool IsInitialRender { get; set; }
    private bool Visibility { get; set; } = true;
    private bool ShowButton { get; set; } = false;
    private ResizeDirection[] dialogResizeDirections { get; set; } = new ResizeDirection[] { ResizeDirection.All };
    private void DialogOpen(Object args)
    {
        this.ShowButton = false;
        IsInitialRender = true;
    }
    private void DialogClose(Object args)
    {
        this.ShowButton = true;
        IsInitialRender = false;
    }
    private void OnClicked()
    {
        this.Visibility = true;
    }
}

```
![Blazor Maps inside Dialog component](../images/maps-with-dialog.png)


## Maps component inside Accordion

When the Maps component renders within the Accordion component, its rendering begins concurrently with the Accordion component's rendering. As a result, the size of the Maps component will not be proper. To properly render the Maps component, a boolean variable (i.e. **IsInitialRender**) must be created and it is used to determine the Maps component's rendering. The boolean variable is set to **false** by default, so the Maps component will not be rendered initially. When the Accordion component is rendered, its [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.AccordionEvents.html#Syncfusion_Blazor_Navigations_AccordionEvents_Created) event is fired, and the boolean variable (i.e. **IsInitialRender**) in this event must be changed to **true** to initiate the render of the Maps component.

```cshtml
@using Syncfusion.Blazor.Maps

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Maps

<div class="control-section accordion-control-section">
    <SfAccordion>
        <AccordionEvents Created="Created"></AccordionEvents>
        <AccordionItems>
            <AccordionItem Expanded="true">
                <HeaderTemplate>Maps</HeaderTemplate>
                <ContentTemplate>
                 @if (IsInitialRender)
                 {
                    <SfMaps ID="Maps" Width="100%">
                        <MapsLayers>
                            <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
                            </MapsLayer>
                        </MapsLayers>
                    </SfMaps>  
                 }
                </ContentTemplate>
            </AccordionItem>
            <AccordionItem>
                <HeaderTemplate>OSM</HeaderTemplate>
                <ContentTemplate>
                    @if (IsInitialRender)
                    {
                       <SfMaps ID="OSM" Width="100%">
                           <MapsLayers>
                               <MapsLayer UrlTemplate="https://tile.openstreetmap.org/level/tileX/tileY.png" TValue="string"></MapsLayer>
                           </MapsLayers>
                       </SfMaps>  
                    }      
                </ContentTemplate>
            </AccordionItem>
            <AccordionItem>
                <HeaderTemplate>Maps SubLayer</HeaderTemplate>
                <ContentTemplate>
                     @if (IsInitialRender)
                     {
                        <SfMaps ID="SubLayer">
                            <MapsLayers>
                                <MapsLayer ShapeData='new {dataOptions ="https://cdn.syncfusion.com/maps/map-data/world-map.json"}' TValue="string">
                                    <MapsShapeSettings Fill="#E5E5E5">
                                        <MapsShapeBorder Color="black" Width="0.1"></MapsShapeBorder>
                                    </MapsShapeSettings>
                                </MapsLayer>
                                <MapsLayer ShapeData='new {dataOptions = "https://cdn.syncfusion.com/maps/map-data/usa.json"}'
	                        	        Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
                                    <MapsShapeSettings Fill="rgba(141, 206, 255, 0.6)">
                                        <MapsShapeBorder Color="#1a9cff" Width="0.25"></MapsShapeBorder>
                                    </MapsShapeSettings>
                                </MapsLayer>
                                <MapsLayer ShapeData='new {dataOptions= "https://cdn.syncfusion.com/maps/map-data/california.json"}'
	                        	        Type="Syncfusion.Blazor.Maps.Type.SubLayer" TValue="string">
                                    <MapsShapeSettings Fill="rgba(141, 206, 255, 0.6)">
                                        <MapsShapeBorder Color="#1a9cff" Width="0.25"></MapsShapeBorder>
                                    </MapsShapeSettings>
                                </MapsLayer>
                            </MapsLayers>
                        </SfMaps>   
                     }   
                </ContentTemplate>
            </AccordionItem>
        </AccordionItems>
    </SfAccordion>
</div>
<style>
    @@-moz-document url-prefix() {
        .e-accordion .e-content table {
            border-collapse: initial;
        }
    }
    .e-accordion table {
        width: 100%;
    }
    #nested-accordion.e-accordion {
        padding: 4px;
    }
    .e-accordion table th,
    .e-accordion table td {
        padding: 5px;
        border: 1px solid #ddd;
    }
    .accordion-control-section {
        margin: 0 10% 0 10%;
        padding-bottom: 25px;
    }
    .source-link {
        padding-bottom: 25px;
    }
</style>

@code{
    public bool IsInitialRender { get; set; }

    public void Created()
    {
        IsInitialRender = true;
    }

}

```
![Blazor Maps inside Accordion component](../images/maps-with-accordion.png)