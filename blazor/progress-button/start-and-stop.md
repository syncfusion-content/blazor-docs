# Start and Stop Methods

```csharp

@using Syncfusion.Blazor.SplitButtons

<SfProgressButton EnableProgress="true" CssClass="e-hide-spinner" Content="Download" Duration="4000" IconCss="e-btn-sb-icon e-download" OnClick="Clickeds" @ref="ProgressBtnObj">
    <ProgressButtonEvents OnEnd="Ends"></ProgressButtonEvents>
</SfProgressButton>

@code {
    SfProgressButton ProgressBtnObj;
    private void Clickeds()
    {
        if(ProgressBtnObj.Content == "Download")
        {
            ProgressBtnObj.Content = "Pause";
            ProgressBtnObj.IconCss = "e-btn-sb-icon e-pause";
            ProgressBtnObj.DataBind();
        }
        else if(ProgressBtnObj.Content == "Pause")
        {
            ProgressBtnObj.Content = "Resume";
            ProgressBtnObj.IconCss = "e-btn-sb-icon e-play";
            ProgressBtnObj.DataBind();
            ProgressBtnObj.Stop();
        }
        else if (ProgressBtnObj.Content == "Resume") {
            ProgressBtnObj.Content = "Pause";
            ProgressBtnObj.IconCss = "e-btn-sb-icon e-pause";
            ProgressBtnObj.DataBind();
            ProgressBtnObj.Start();
        }
    }
    private void Ends()
    {
        ProgressBtnObj.Content = "Download";
        ProgressBtnObj.IconCss = "e-btn-sb-icon e-download";
        ProgressBtnObj.DataBind();

    }
}

<style>

.e-download::before {
  content: '\e706';
}

.e-play::before {
  content: '\e700';
}

.e-pause::before {
  content: '\e701';
}

</style>

```