# Types

The Chip control has the following types.

* Input Chip
* Choice Chip
* Filter Chip
* Action Chip

## Input Chip

Input Chip holds information in compact form. It converts user input into chips.

```csharp
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipItems>
        <ChipItem Text="Anne" LeadingIconUrl="./anne.png"></ChipItem>
        <ChipItem Text="Janet" LeadingIconUrl="./janet.png"></ChipItem>
        <ChipItem Text="Laura" LeadingIconUrl="./laura.png"></ChipItem>
        <ChipItem Text="Margaret" LeadingIconUrl="./margaret.png"></ChipItem>
    </ChipItems>
</SfChip>

```

Output be like the below.

![Chip inputs](./images/inputChips.png)

## Choice Chip

Choice Chip allows you to select a single chip from the set of Chip/ChipItems. It can be enabled by setting the `Selection` property to `Single`.

```csharp
@using Syncfusion.Blazor.Buttons
<SfChip Selection="SelectionType.Single">
    <ChipItems>
        <ChipItem Text="Small"></ChipItem>
        <ChipItem Text="Medium"></ChipItem>
        <ChipItem Text="Large"></ChipItem>
        <ChipItem Text="Extra Large"></ChipItem>
    </ChipItems>
</SfChip>

```

Output be like the below.

![Chip Choice](./images/choicechip.gif)

## Filter Chip

Filter Chip allows you to select a multiple chip from the set of Chip/ChipItems. It can be enabled by setting the `Selection` property to `Multiple`.

```csharp
@using Syncfusion.Blazor.Buttons
<SfChip Selection="SelectionType.Multiple">
    <ChipItems>
        <ChipItem Text="Chai"></ChipItem>
        <ChipItem Text="Chang"></ChipItem>
        <ChipItem Text="Aniseed Syrup"></ChipItem>
        <ChipItem Text="Ikura"></ChipItem>
    </ChipItems>
</SfChip>

```

Output be like the below.

![Chip Filter](./images/filterchip.gif)

## Action Chip

The Action Chip triggers the event like click or delete, which helps doing action based on the event.

```csharp
@using Syncfusion.Blazor.Buttons
<SfChip>
    <ChipEvents OnClick="@OnClick"></ChipEvents>
    <ChipItems>
        <ChipItem Text="Sent a text"></ChipItem>
        <ChipItem Text="Set a remainder"></ChipItem>
        <ChipItem Text="Read my emails"></ChipItem>
        <ChipItem Text="Set alarm"></ChipItem>
    </ChipItems>
</SfChip>

<div>@ChipText</div>

@code
{
    public string ChipText = "";
    private void OnClick(Syncfusion.Blazor.Buttons.ChipEventArgs args)
    {
        ChipText = args.Text;
        this.StateHasChanged();
    }
}

```

Output be like the below.

![Chip Action](./images/actionchip.gif)

### Deletable Chip

Deletable Chip allows you to delete a chip from Chip/ChipItems. It can be enabled by setting the `EnableDelete` property to `true`.

```csharp
@using Syncfusion.Blazor.Buttons
<SfChip EnableDelete="true">
    <ChipItems>
        <ChipItem Text="Sent a text"></ChipItem>
        <ChipItem Text="Set a remainder"></ChipItem>
        <ChipItem Text="Read my emails"></ChipItem>
        <ChipItem Text="Set alarm"></ChipItem>
    </ChipItems>
</SfChip>

```

Output be like the below.

![Chip Delete](./images/deletablechip.gif)