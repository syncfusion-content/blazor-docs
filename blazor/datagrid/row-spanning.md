---
layout: post
title: Row Spanning in Blazor DataGrid Component | Syncfusion
description: Learn here all about row spanning in Syncfusion Blazor DataGrid component of Syncfusion Essential Studio and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Row Spanning in Blazor DataGrid

Row spanning in the Syncfusion Blazor DataGrid merges adjacent cells with identical values horizontally across columns within the same row. This feature reduces visual repetition and presents grouped data in a compact, readable format. It is particularly effective in scenarios where multiple columns share the same value, such as repeated product details or status indicators.

The functionality is enabled by setting the `AutoSpan` property of the `SfGrid` component to **AutoSpanMode.Row**. When activated, the grid evaluates each row and merges neighboring cells containing identical values, resulting in a single, wider cell. The merging process is automatic and declarative, requiring no manual logic or data transformation.

Row spanning is part of the broader **AutoSpanMode** enumeration, which provides multiple options for customizing cell merging behavior in the Syncfusion Blazor DataGrid. The available modes include **None**, **Row**, **Column**, and **HorizontalAndVertical**. 

| Enum Value | Description |
|---------|-----|
| AutoSpanMode.None | Disables automatic cell spanning so every cell remains isolated (Default Mode). | 
| AutoSpanMode.Row | Enables horizontal merging across columns within the same row. | 
| AutoSpanMode.Column | Enables vertical merging of adjacent cells with identical values in the same column. | 
| AutoSpanMode.HorizontalAndVertical | Enables both horizontal and vertical merging. Executes row merging first, followed by column merging. |  

## Enable row spanning

Horizontal cell merging in the Syncfusion Blazor DataGrid is enabled by setting the `AutoSpan` property of the `SfGrid` component to **AutoSpanMode.Row**. In this mode, adjacent cells across columns within the same row are automatically merged when they contain identical values. This reduces redundancy and provides a cleaner, more compact presentation of repeated data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

<SfGrid DataSource="@TeleCastDataList" GridLines="GridLine.Both"
        AutoSpan="AutoSpanMode.Row" AllowSelection="false" EnableHover="false">
    <GridColumns>
        <GridColumn Field=@nameof(TelecastData.Channel) HeaderText="Channel" Width="200" TextAlign="TextAlign.Left" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Genre) HeaderText="Genre" Width="120" TextAlign="TextAlign.Left" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program12AM) HeaderText="12:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program1AM) HeaderText="1:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program2AM) HeaderText="2:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program3AM) HeaderText="3:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program4AM) HeaderText="4:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program5AM) HeaderText="5:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program6AM) HeaderText="6:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program7AM) HeaderText="7:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program8AM) HeaderText="8:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program9AM) HeaderText="9:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program10AM) HeaderText="10:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program11AM) HeaderText="11:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program12PM) HeaderText="12:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program1PM) HeaderText="1:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program2PM) HeaderText="2:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program3PM) HeaderText="3:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program4PM) HeaderText="4:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program5PM) HeaderText="5:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program6PM) HeaderText="6:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program7PM) HeaderText="7:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program8PM) HeaderText="8:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program9PM) HeaderText="9:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program10PM) HeaderText="10:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program11PM) HeaderText="11:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
    </GridColumns>
</SfGrid>

@code 
{
    public List<TelecastData>? TeleCastDataList { get; set; }

    protected override void OnInitialized()
    {
        TeleCastDataList = TelecastData.GetTelecastData();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="TelecastData.cs" %}

public class TelecastData
{
    public string Channel { get; set; }
    public string Genre { get; set; }
    public string Program12AM { get; set; }
    public string Program1AM { get; set; }
    public string Program2AM { get; set; }
    public string Program3AM { get; set; }
    public string Program4AM { get; set; }
    public string Program5AM { get; set; }
    public string Program6AM { get; set; }
    public string Program7AM { get; set; }
    public string Program8AM { get; set; }
    public string Program9AM { get; set; }
    public string Program10AM { get; set; }
    public string Program11AM { get; set; }
    public string Program12PM { get; set; }
    public string Program1PM { get; set; }
    public string Program2PM { get; set; }
    public string Program3PM { get; set; }
    public string Program4PM { get; set; }
    public string Program5PM { get; set; }
    public string Program6PM { get; set; }
    public string Program7PM { get; set; }
    public string Program8PM { get; set; }
    public string Program9PM { get; set; }
    public string Program10PM { get; set; }
    public string Program11PM { get; set; }

    public static List<TelecastData> GetTelecastData()
    {
        return new List<TelecastData>
        {
            new TelecastData
            {
                Channel = "USA News Network",
                Genre = "News",
                Program12AM = "Late Night News",
                Program1AM = "Overnight Brief",
                Program2AM = "Overnight Brief",
                Program3AM = "World Recap",
                Program4AM = "Early Report",
                Program5AM = "Morning Preview",
                Program6AM = "Morning Dispatch",
                Program7AM = "Daily Brief",
                Program8AM = "National Update",
                Program9AM = "National Update",
                Program10AM = "Midday Report",
                Program11AM = "Breaking Stories",
                Program12PM = "Global Roundup",
                Program1PM = "Current Affairs",
                Program2PM = "News Desk",
                Program3PM = "Afternoon Digest",
                Program4PM = "City Beat",
                Program5PM = "Evening News",
                Program6PM = "Evening News",
                Program7PM = "World Tonight",
                Program8PM = "Prime Report",
                Program9PM = "Nightly Brief",
                Program10PM = "Late Edition",
                Program11PM = "News Wrap"
            },
            new TelecastData
            {
                Channel = "American News Channel",
                Genre = "News",
                Program12AM = "Midnight Update",
                Program1AM = "Global Overnight",
                Program2AM = "Global Overnight",
                Program3AM = "News Replay",
                Program4AM = "Dawn Dispatch",
                Program5AM = "Business Early",
                Program6AM = "Early Edition",
                Program7AM = "Business Beat",
                Program8AM = "National Update",
                Program9AM = "National Update",
                Program10AM = "In Focus",
                Program11AM = "Market Pulse",
                Program12PM = "News Today",
                Program1PM = "World Matters",
                Program2PM = "Regional Review",
                Program3PM = "Evening Preview",
                Program4PM = "Local Stories",
                Program5PM = "Evening News",
                Program6PM = "Evening News",
                Program7PM = "Global Insight",
                Program8PM = "Prime Focus",
                Program9PM = "Night Desk",
                Program10PM = "Late News",
                Program11PM = "Final Report"
            },
            new TelecastData
            {
                Channel = "Science Frontier TV",
                Genre = "Science",
                Program12AM = "Tech Rewind",
                Program1AM = "Cosmic Replay",
                Program2AM = "Cosmic Replay",
                Program3AM = "Science Vault",
                Program4AM = "Tech Bits",
                Program5AM = "Nature Shorts",
                Program6AM = "How It's Built",
                Program7AM = "Nature Unveiled",
                Program8AM = "Tech Titans",
                Program9AM = "Future Innovators",
                Program10AM = "Unknown Worlds",
                Program11AM = "Planet Secrets",
                Program12PM = "Tomorrow's Tech",
                Program1PM = "Space Frontiers",
                Program2PM = "Myth Crackers",
                Program3PM = "Cosmic Discoveries",
                Program4PM = "Tech Lab",
                Program5PM = "Science Now",
                Program6PM = "Innovate Today",
                Program7PM = "Future Worlds",
                Program8PM = "Star Explorers",
                Program9PM = "Tech Deep Dive",
                Program10PM = "Science Spotlight",
                Program11PM = "Night Lab"
            },
            new TelecastData
            {
                Channel = "Explore America",
                Genre = "Science",
                Program12AM = "Wild Nights",
                Program1AM = "Explorer Vault",
                Program2AM = "Explorer Vault",
                Program3AM = "Hidden Gems",
                Program4AM = "Wild Shorts",
                Program5AM = "Nature Dawn",
                Program6AM = "Wild Expeditions",
                Program7AM = "American Wilderness",
                Program8AM = "Tech Titans",
                Program9AM = "Future Innovators",
                Program10AM = "Hidden Histories",
                Program11AM = "Mega Projects",
                Program12PM = "Great Minds",
                Program1PM = "Beyond Earth",
                Program2PM = "Star Journey",
                Program3PM = "Unique Planet",
                Program4PM = "Adventure Now",
                Program5PM = "Wild America",
                Program6PM = "Explorer's Log",
                Program7PM = "Nature Quest",
                Program8PM = "Epic Journeys",
                Program9PM = "Lost Worlds",
                Program10PM = "Planet Stories",
                Program11PM = "Night Trek"
            },
            new TelecastData
            {
                Channel = "Silver Screen Network",
                Genre = "Movies",
                Program12AM = "Movie",
                Program1AM = "Movie",
                Program2AM = "Movie",
                Program3AM = "Late Classic",
                Program4AM = "Late Classic",
                Program5AM = "Early Feature",
                Program6AM = "Shadow of Truth",
                Program7AM = "Shadow of Truth",
                Program8AM = "Shadow of Truth",
                Program9AM = "Power Play",
                Program10AM = "Power Play",
                Program11AM = "Power Play",
                Program12PM = "Power Play",
                Program1PM = "City Vigilante",
                Program2PM = "City Vigilante",
                Program3PM = "City Vigilante",
                Program4PM = "Hero Saga",
                Program5PM = "Hero Saga",
                Program6PM = "Prime Movie",
                Program7PM = "Prime Movie",
                Program8PM = "Blockbuster Night",
                Program9PM = "Blockbuster Night",
                Program10PM = "Late Show",
                Program11PM = "Late Show"
            },
            new TelecastData
            {
                Channel = "Sports USA",
                Genre = "Sports",
                Program12AM = "Sports Replay",
                Program1AM = "Game Highlights",
                Program2AM = "Game Highlights",
                Program3AM = "Sports Vault",
                Program4AM = "Early Recap",
                Program5AM = "Morning Warmup",
                Program6AM = "Morning Kickoff",
                Program7AM = "Football Classics",
                Program8AM = "Live Game Day",
                Program9AM = "Live Game Day",
                Program10AM = "Top Plays",
                Program11AM = "Sports Talk",
                Program12PM = "Hoops Highlights",
                Program1PM = "Game Plan",
                Program2PM = "Sports Roundup",
                Program3PM = "NFL Breakdown",
                Program4PM = "Sports Desk",
                Program5PM = "Live Coverage",
                Program6PM = "Game Night",
                Program7PM = "Prime Sports",
                Program8PM = "Big Match",
                Program9PM = "Sports Wrap",
                Program10PM = "Late Game",
                Program11PM = "Night Recap"
            },
            new TelecastData
            {
                Channel = "All Sports Network",
                Genre = "Sports",
                Program12AM = "Late Highlights",
                Program1AM = "Sports Classics",
                Program2AM = "Sports Classics",
                Program3AM = "Game Rewind",
                Program4AM = "Early Games",
                Program5AM = "Sports Warmup",
                Program6AM = "Morning Kickoff",
                Program7AM = "Classic Matchups",
                Program8AM = "Live Game Day",
                Program9AM = "Live Game Day",
                Program10AM = "Top Plays",
                Program11AM = "Sports Talk",
                Program12PM = "Baseball Recap",
                Program1PM = "Game Plan",
                Program2PM = "Sports Roundup",
                Program3PM = "Soccer Highlights",
                Program4PM = "Sports Central",
                Program5PM = "Live Action",
                Program6PM = "Prime Match",
                Program7PM = "Sports Night",
                Program8PM = "Big Game",
                Program9PM = "Game Recap",
                Program10PM = "Late Sports",
                Program11PM = "Final Score"
            },
            new TelecastData
            {
                Channel = "Kids Fun Zone",
                Genre = "Kids",
                Program12AM = "Cartoon Rewind",
                Program1AM = "Late Toons",
                Program2AM = "Late Toons",
                Program3AM = "Kid Classics",
                Program4AM = "Kid Classics",
                Program5AM = "Early Toons",
                Program6AM = "Adventure Pals",
                Program7AM = "Super Heroes",
                Program8AM = "Super Heroes",
                Program9AM = "Super Heroes",
                Program10AM = "Mystery Crew",
                Program11AM = "Funny Chase",
                Program12PM = "Cartoon Craze",
                Program1PM = "Quest Buddies",
                Program2PM = "Quest Buddies",
                Program3PM = "Team Turbo",
                Program4PM = "Fun Factory",
                Program5PM = "Kid Quest",
                Program6PM = "Toon Time",
                Program7PM = "Family Flicks",
                Program8PM = "Adventure Hour",
                Program9PM = "Night Toons",
                Program10PM = "Night Toons",
                Program11PM = "Sleepy Stories"
            },
            new TelecastData
            {
                Channel = "Family Playhouse",
                Genre = "Kids",
                Program12AM = "Late Kid Show",
                Program1AM = "Moonlit Tales",
                Program2AM = "Moonlit Tales",
                Program3AM = "Classic Cartoons",
                Program4AM = "Classic Cartoons",
                Program5AM = "Morning Pals",
                Program6AM = "Little Explorers",
                Program7AM = "Rescue Pals",
                Program8AM = "House of Laughs",
                Program9AM = "House of Laughs",
                Program10AM = "Mystery Crew",
                Program11AM = "Magic Wishes",
                Program12PM = "Teen Spotlight",
                Program1PM = "Ocean Adventures",
                Program2PM = "Ocean Adventures",
                Program3PM = "Rescue Pals",
                Program4PM = "Family Fun",
                Program5PM = "Kid Adventures",
                Program6PM = "Toon Party",
                Program7PM = "Family Time",
                Program8PM = "Magic Hour",
                Program9PM = "Evening Toons",
                Program10PM = "Evening Toons",
                Program11PM = "Bedtime Tales"
            },
            new TelecastData
            {
                Channel = "Magic Youth TV",
                Genre = "Kids",
                Program12AM = "Midnight Toons",
                Program1AM = "Starlight Stories",
                Program2AM = "Starlight Stories",
                Program3AM = "Toon Vault",
                Program4AM = "Toon Vault",
                Program5AM = "Early Adventures",
                Program6AM = "Mouse Playhouse",
                Program7AM = "City Kids",
                Program8AM = "Mystery Town",
                Program9AM = "Mystery Town",
                Program10AM = "Mystery Crew",
                Program11AM = "Witch Cottage",
                Program12PM = "Swamp Tales",
                Program1PM = "Stepbrothers",
                Program2PM = "Stepbrothers",
                Program3PM = "City Kids",
                Program4PM = "Youth Quest",
                Program5PM = "Fun Tales",
                Program6PM = "Cartoon Club",
                Program7PM = "Kid Heroes",
                Program8PM = "Magic Night",
                Program9PM = "Toon Dreams",
                Program10PM = "Toon Dreams",
                Program11PM = "Night Stories"
            },
            new TelecastData
            {
                Channel = "Wild America TV",
                Genre = "Wildlife",
                Program12AM = "Night Creatures",
                Program1AM = "Wild Rewind",
                Program2AM = "Wild Rewind",
                Program3AM = "Animal Vault",
                Program4AM = "Nature Clips",
                Program5AM = "Wild Dawn",
                Program6AM = "Nature Guide",
                Program7AM = "Wild Trails",
                Program8AM = "Predator Watch",
                Program9AM = "Predator Watch",
                Program10AM = "Ocean Titans",
                Program11AM = "Safari Quest",
                Program12PM = "Big Beasts",
                Program1PM = "Night Safari",
                Program2PM = "Night Safari",
                Program3PM = "Nature Guide",
                Program4PM = "Wild Tracks",
                Program5PM = "Animal Planet",
                Program6PM = "Safari Nights",
                Program7PM = "Wild World",
                Program8PM = "Beast Hunters",
                Program9PM = "Nature Nights",
                Program10PM = "Wild Chronicles",
                Program11PM = "Night Beasts"
            },
            new TelecastData
            {
                Channel = "Earth Discovery",
                Genre = "Nature",
                Program12AM = "Planet Replay",
                Program1AM = "Earth After Dark",
                Program2AM = "Earth After Dark",
                Program3AM = "Nature Classics",
                Program4AM = "Earth Early",
                Program5AM = "Dawn Planet",
                Program6AM = "Planet Wonders",
                Program7AM = "Frozen Lands",
                Program8AM = "Life on Earth",
                Program9AM = "Life on Earth",
                Program10AM = "Blue Seas",
                Program11AM = "Nature Marvels",
                Program12PM = "Earth Insights",
                Program1PM = "Night Safari",
                Program2PM = "Night Safari",
                Program3PM = "Planet Wonders",
                Program4PM = "Eco Quest",
                Program5PM = "Nature Now",
                Program6PM = "Planet Pulse",
                Program7PM = "Earth Stories",
                Program8PM = "Wild Horizons",
                Program9PM = "Nature Deep",
                Program10PM = "Earth Night",
                Program11PM = "Planet Recap"
            }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBoChWHeiPSwUHb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable spanning for specific column

Column spanning in Syncfusion Blazor DataGrid can be disabled for a specific column(s) by setting the `AutoSpan` property of the `GridColumn` component to **AutoSpanMode.None**. This configuration provides precise control, enabling automatic spanning across the grid while excluding column(s) where merging is not required.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

<SfGrid DataSource="@TeleCastDataList" GridLines="GridLine.Both"
        AutoSpan="AutoSpanMode.Row" AllowSelection="false" EnableHover="false">
    <GridColumns>
        <GridColumn Field=@nameof(TelecastData.Channel) HeaderText="Channel" Width="200" TextAlign="TextAlign.Left" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Genre) HeaderText="Genre" Width="120" TextAlign="TextAlign.Left" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program12AM) HeaderText="12:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program1AM) HeaderText="1:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program2AM) HeaderText="2:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program3AM) HeaderText="3:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program4AM) HeaderText="4:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program5AM) HeaderText="5:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program6AM) HeaderText="6:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program7AM) HeaderText="7:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program8AM) HeaderText="8:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program9AM) HeaderText="9:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program10AM) HeaderText="10:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program11AM) HeaderText="11:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program12PM) HeaderText="12:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program1PM) HeaderText="1:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program2PM) HeaderText="2:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program3PM) HeaderText="3:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program4PM) HeaderText="4:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program5PM) HeaderText="5:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program6PM) HeaderText="6:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program7PM) HeaderText="7:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>        
        <GridColumn Field=@nameof(TelecastData.Program8PM) HeaderText="8:00 PM" Width="150" TextAlign="TextAlign.Center" AutoSpan="AutoSpanMode.None"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program9PM) HeaderText="9:00 PM" Width="150" TextAlign="TextAlign.Center" AutoSpan="AutoSpanMode.None"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program10PM) HeaderText="10:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program11PM) HeaderText="11:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
    </GridColumns>
</SfGrid>

@code 
{
    public List<TelecastData>? TeleCastDataList { get; set; }

    protected override void OnInitialized()
    {
        TeleCastDataList = TelecastData.GetTelecastData();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="TelecastData.cs" %}

public class TelecastData
{
    public string Channel { get; set; }
    public string Genre { get; set; }
    public string Program12AM { get; set; }
    public string Program1AM { get; set; }
    public string Program2AM { get; set; }
    public string Program3AM { get; set; }
    public string Program4AM { get; set; }
    public string Program5AM { get; set; }
    public string Program6AM { get; set; }
    public string Program7AM { get; set; }
    public string Program8AM { get; set; }
    public string Program9AM { get; set; }
    public string Program10AM { get; set; }
    public string Program11AM { get; set; }
    public string Program12PM { get; set; }
    public string Program1PM { get; set; }
    public string Program2PM { get; set; }
    public string Program3PM { get; set; }
    public string Program4PM { get; set; }
    public string Program5PM { get; set; }
    public string Program6PM { get; set; }
    public string Program7PM { get; set; }
    public string Program8PM { get; set; }
    public string Program9PM { get; set; }
    public string Program10PM { get; set; }
    public string Program11PM { get; set; }

    public static List<TelecastData> GetTelecastData()
    {
        return new List<TelecastData>
        {
            new TelecastData
            {
                Channel = "USA News Network",
                Genre = "News",
                Program12AM = "Late Night News",
                Program1AM = "Overnight Brief",
                Program2AM = "Overnight Brief",
                Program3AM = "World Recap",
                Program4AM = "Early Report",
                Program5AM = "Morning Preview",
                Program6AM = "Morning Dispatch",
                Program7AM = "Daily Brief",
                Program8AM = "National Update",
                Program9AM = "National Update",
                Program10AM = "Midday Report",
                Program11AM = "Breaking Stories",
                Program12PM = "Global Roundup",
                Program1PM = "Current Affairs",
                Program2PM = "News Desk",
                Program3PM = "Afternoon Digest",
                Program4PM = "City Beat",
                Program5PM = "Evening News",
                Program6PM = "Evening News",
                Program7PM = "World Tonight",
                Program8PM = "Prime Report",
                Program9PM = "Nightly Brief",
                Program10PM = "Late Edition",
                Program11PM = "News Wrap"
            },
            new TelecastData
            {
                Channel = "American News Channel",
                Genre = "News",
                Program12AM = "Midnight Update",
                Program1AM = "Global Overnight",
                Program2AM = "Global Overnight",
                Program3AM = "News Replay",
                Program4AM = "Dawn Dispatch",
                Program5AM = "Business Early",
                Program6AM = "Early Edition",
                Program7AM = "Business Beat",
                Program8AM = "National Update",
                Program9AM = "National Update",
                Program10AM = "In Focus",
                Program11AM = "Market Pulse",
                Program12PM = "News Today",
                Program1PM = "World Matters",
                Program2PM = "Regional Review",
                Program3PM = "Evening Preview",
                Program4PM = "Local Stories",
                Program5PM = "Evening News",
                Program6PM = "Evening News",
                Program7PM = "Global Insight",
                Program8PM = "Prime Focus",
                Program9PM = "Night Desk",
                Program10PM = "Late News",
                Program11PM = "Final Report"
            },
            new TelecastData
            {
                Channel = "Science Frontier TV",
                Genre = "Science",
                Program12AM = "Tech Rewind",
                Program1AM = "Cosmic Replay",
                Program2AM = "Cosmic Replay",
                Program3AM = "Science Vault",
                Program4AM = "Tech Bits",
                Program5AM = "Nature Shorts",
                Program6AM = "How It's Built",
                Program7AM = "Nature Unveiled",
                Program8AM = "Tech Titans",
                Program9AM = "Future Innovators",
                Program10AM = "Unknown Worlds",
                Program11AM = "Planet Secrets",
                Program12PM = "Tomorrow's Tech",
                Program1PM = "Space Frontiers",
                Program2PM = "Myth Crackers",
                Program3PM = "Cosmic Discoveries",
                Program4PM = "Tech Lab",
                Program5PM = "Science Now",
                Program6PM = "Innovate Today",
                Program7PM = "Future Worlds",
                Program8PM = "Star Explorers",
                Program9PM = "Tech Deep Dive",
                Program10PM = "Science Spotlight",
                Program11PM = "Night Lab"
            },
            new TelecastData
            {
                Channel = "Explore America",
                Genre = "Science",
                Program12AM = "Wild Nights",
                Program1AM = "Explorer Vault",
                Program2AM = "Explorer Vault",
                Program3AM = "Hidden Gems",
                Program4AM = "Wild Shorts",
                Program5AM = "Nature Dawn",
                Program6AM = "Wild Expeditions",
                Program7AM = "American Wilderness",
                Program8AM = "Tech Titans",
                Program9AM = "Future Innovators",
                Program10AM = "Hidden Histories",
                Program11AM = "Mega Projects",
                Program12PM = "Great Minds",
                Program1PM = "Beyond Earth",
                Program2PM = "Star Journey",
                Program3PM = "Unique Planet",
                Program4PM = "Adventure Now",
                Program5PM = "Wild America",
                Program6PM = "Explorer's Log",
                Program7PM = "Nature Quest",
                Program8PM = "Epic Journeys",
                Program9PM = "Lost Worlds",
                Program10PM = "Planet Stories",
                Program11PM = "Night Trek"
            },
            new TelecastData
            {
                Channel = "Silver Screen Network",
                Genre = "Movies",
                Program12AM = "Movie",
                Program1AM = "Movie",
                Program2AM = "Movie",
                Program3AM = "Late Classic",
                Program4AM = "Late Classic",
                Program5AM = "Early Feature",
                Program6AM = "Shadow of Truth",
                Program7AM = "Shadow of Truth",
                Program8AM = "Shadow of Truth",
                Program9AM = "Power Play",
                Program10AM = "Power Play",
                Program11AM = "Power Play",
                Program12PM = "Power Play",
                Program1PM = "City Vigilante",
                Program2PM = "City Vigilante",
                Program3PM = "City Vigilante",
                Program4PM = "Hero Saga",
                Program5PM = "Hero Saga",
                Program6PM = "Prime Movie",
                Program7PM = "Prime Movie",
                Program8PM = "Blockbuster Night",
                Program9PM = "Blockbuster Night",
                Program10PM = "Late Show",
                Program11PM = "Late Show"
            },
            new TelecastData
            {
                Channel = "Sports USA",
                Genre = "Sports",
                Program12AM = "Sports Replay",
                Program1AM = "Game Highlights",
                Program2AM = "Game Highlights",
                Program3AM = "Sports Vault",
                Program4AM = "Early Recap",
                Program5AM = "Morning Warmup",
                Program6AM = "Morning Kickoff",
                Program7AM = "Football Classics",
                Program8AM = "Live Game Day",
                Program9AM = "Live Game Day",
                Program10AM = "Top Plays",
                Program11AM = "Sports Talk",
                Program12PM = "Hoops Highlights",
                Program1PM = "Game Plan",
                Program2PM = "Sports Roundup",
                Program3PM = "NFL Breakdown",
                Program4PM = "Sports Desk",
                Program5PM = "Live Coverage",
                Program6PM = "Game Night",
                Program7PM = "Prime Sports",
                Program8PM = "Big Match",
                Program9PM = "Sports Wrap",
                Program10PM = "Late Game",
                Program11PM = "Night Recap"
            },
            new TelecastData
            {
                Channel = "All Sports Network",
                Genre = "Sports",
                Program12AM = "Late Highlights",
                Program1AM = "Sports Classics",
                Program2AM = "Sports Classics",
                Program3AM = "Game Rewind",
                Program4AM = "Early Games",
                Program5AM = "Sports Warmup",
                Program6AM = "Morning Kickoff",
                Program7AM = "Classic Matchups",
                Program8AM = "Live Game Day",
                Program9AM = "Live Game Day",
                Program10AM = "Top Plays",
                Program11AM = "Sports Talk",
                Program12PM = "Baseball Recap",
                Program1PM = "Game Plan",
                Program2PM = "Sports Roundup",
                Program3PM = "Soccer Highlights",
                Program4PM = "Sports Central",
                Program5PM = "Live Action",
                Program6PM = "Prime Match",
                Program7PM = "Sports Night",
                Program8PM = "Big Game",
                Program9PM = "Game Recap",
                Program10PM = "Late Sports",
                Program11PM = "Final Score"
            },
            new TelecastData
            {
                Channel = "Kids Fun Zone",
                Genre = "Kids",
                Program12AM = "Cartoon Rewind",
                Program1AM = "Late Toons",
                Program2AM = "Late Toons",
                Program3AM = "Kid Classics",
                Program4AM = "Kid Classics",
                Program5AM = "Early Toons",
                Program6AM = "Adventure Pals",
                Program7AM = "Super Heroes",
                Program8AM = "Super Heroes",
                Program9AM = "Super Heroes",
                Program10AM = "Mystery Crew",
                Program11AM = "Funny Chase",
                Program12PM = "Cartoon Craze",
                Program1PM = "Quest Buddies",
                Program2PM = "Quest Buddies",
                Program3PM = "Team Turbo",
                Program4PM = "Fun Factory",
                Program5PM = "Kid Quest",
                Program6PM = "Toon Time",
                Program7PM = "Family Flicks",
                Program8PM = "Adventure Hour",
                Program9PM = "Night Toons",
                Program10PM = "Night Toons",
                Program11PM = "Sleepy Stories"
            },
            new TelecastData
            {
                Channel = "Family Playhouse",
                Genre = "Kids",
                Program12AM = "Late Kid Show",
                Program1AM = "Moonlit Tales",
                Program2AM = "Moonlit Tales",
                Program3AM = "Classic Cartoons",
                Program4AM = "Classic Cartoons",
                Program5AM = "Morning Pals",
                Program6AM = "Little Explorers",
                Program7AM = "Rescue Pals",
                Program8AM = "House of Laughs",
                Program9AM = "House of Laughs",
                Program10AM = "Mystery Crew",
                Program11AM = "Magic Wishes",
                Program12PM = "Teen Spotlight",
                Program1PM = "Ocean Adventures",
                Program2PM = "Ocean Adventures",
                Program3PM = "Rescue Pals",
                Program4PM = "Family Fun",
                Program5PM = "Kid Adventures",
                Program6PM = "Toon Party",
                Program7PM = "Family Time",
                Program8PM = "Magic Hour",
                Program9PM = "Evening Toons",
                Program10PM = "Evening Toons",
                Program11PM = "Bedtime Tales"
            },
            new TelecastData
            {
                Channel = "Magic Youth TV",
                Genre = "Kids",
                Program12AM = "Midnight Toons",
                Program1AM = "Starlight Stories",
                Program2AM = "Starlight Stories",
                Program3AM = "Toon Vault",
                Program4AM = "Toon Vault",
                Program5AM = "Early Adventures",
                Program6AM = "Mouse Playhouse",
                Program7AM = "City Kids",
                Program8AM = "Mystery Town",
                Program9AM = "Mystery Town",
                Program10AM = "Mystery Crew",
                Program11AM = "Witch Cottage",
                Program12PM = "Swamp Tales",
                Program1PM = "Stepbrothers",
                Program2PM = "Stepbrothers",
                Program3PM = "City Kids",
                Program4PM = "Youth Quest",
                Program5PM = "Fun Tales",
                Program6PM = "Cartoon Club",
                Program7PM = "Kid Heroes",
                Program8PM = "Magic Night",
                Program9PM = "Toon Dreams",
                Program10PM = "Toon Dreams",
                Program11PM = "Night Stories"
            },
            new TelecastData
            {
                Channel = "Wild America TV",
                Genre = "Wildlife",
                Program12AM = "Night Creatures",
                Program1AM = "Wild Rewind",
                Program2AM = "Wild Rewind",
                Program3AM = "Animal Vault",
                Program4AM = "Nature Clips",
                Program5AM = "Wild Dawn",
                Program6AM = "Nature Guide",
                Program7AM = "Wild Trails",
                Program8AM = "Predator Watch",
                Program9AM = "Predator Watch",
                Program10AM = "Ocean Titans",
                Program11AM = "Safari Quest",
                Program12PM = "Big Beasts",
                Program1PM = "Night Safari",
                Program2PM = "Night Safari",
                Program3PM = "Nature Guide",
                Program4PM = "Wild Tracks",
                Program5PM = "Animal Planet",
                Program6PM = "Safari Nights",
                Program7PM = "Wild World",
                Program8PM = "Beast Hunters",
                Program9PM = "Nature Nights",
                Program10PM = "Wild Chronicles",
                Program11PM = "Night Beasts"
            },
            new TelecastData
            {
                Channel = "Earth Discovery",
                Genre = "Nature",
                Program12AM = "Planet Replay",
                Program1AM = "Earth After Dark",
                Program2AM = "Earth After Dark",
                Program3AM = "Nature Classics",
                Program4AM = "Earth Early",
                Program5AM = "Dawn Planet",
                Program6AM = "Planet Wonders",
                Program7AM = "Frozen Lands",
                Program8AM = "Life on Earth",
                Program9AM = "Life on Earth",
                Program10AM = "Blue Seas",
                Program11AM = "Nature Marvels",
                Program12PM = "Earth Insights",
                Program1PM = "Night Safari",
                Program2PM = "Night Safari",
                Program3PM = "Planet Wonders",
                Program4PM = "Eco Quest",
                Program5PM = "Nature Now",
                Program6PM = "Planet Pulse",
                Program7PM = "Earth Stories",
                Program8PM = "Wild Horizons",
                Program9PM = "Nature Deep",
                Program10PM = "Earth Night",
                Program11PM = "Planet Recap"
            }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXByMVixeXvnPXRS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The effective spanning behavior in the Syncfusion Blazor DataGrid is determined by the intersection of grid-level and column-level `AutoSpan` modes. A column can only restrict the spanning directions permitted at the grid level and cannot enable a span direction that has been disabled globally. This ensures consistent behavior across the grid while allowing fine-grained control for individual columns.


**Combination Matrix**

| Grid AutoSpan | Column AutoSpan | Effective Behavior |
|---|---|---|
| None | None | No spanning. Both grid and column explicitly disable spanning. |
| None | Row | No spanning. Grid-level **None** overrides column-level **Row**. |
| None | Column | No spanning. Grid-level **None** overrides column-level **Column**. |
| None | HorizontalAndVertical | No spanning. Grid-level **None** overrides all spanning modes. |
| Row | None | No spanning. Column explicitly disables spanning. |
| Row | Row | Row spanning only. Both grid and column enable row spanning. |
| Row | Column | No spanning. Grid only allows row spanning; column cannot enable column spanning. |
| Row | HorizontalAndVertical | Row spanning only. Grid only allows row spanning. |
| Column | None | No spanning. Column explicitly disables spanning. |
| Column | Row | No spanning. Grid only allows column spanning; column cannot enable row spanning. |
| Column | Column | Column spanning only. Both grid and column enable column spanning. |
| Column | HorizontalAndVertical | Column spanning only. Grid only allows column spanning. |
| HorizontalAndVertical | None | No spanning. Column explicitly disables both directions. |
| HorizontalAndVertical | Row | Row spanning only. Grid allows both; column narrows to Row. |
| HorizontalAndVertical | Column | Column spanning only. Grid allows both; column narrows to Column. |
| HorizontalAndVertical | HorizontalAndVertical | Row and Column spanning. Both grid and column enable both directions. |

---

## Apply row spanning via programmatically

In addition to automatic cell merging, the Syncfusion Blazor DataGrid provides API support for manually merging cells when custom layout behavior is required. This functionality is available through the `MergeCellsAsync` method, which enables the definition of rectangular regions of cells to be merged programmatically.

Use `MergeCellsAsync` method to manually merge cells by defining rectangular regions. This method supports both single and batch merging, allowing precise control over layout customization when automatic spanning is insufficient.

The `MergeCellsAsync` method is overloaded, meaning multiple versions of the same method name exist, but each accepts different parameter types to handle different use cases. This approach provides flexibility while maintaining a consistent API design.

| Parameter | Type | Description |
|-----------|------|-------------|
| info | `MergeCellInfo` | Defines a single rectangular cell region to be merged. |
| infos | `IEnumerable<MergeCellInfo>` | Specifies multiple cell regions to be merged in a batch operation. Each region is defined by a `MergeCellInfo` instance. |

To define a merged region, use the following properties of the `MergeCellInfo` class,

| Property     | Type | Description                                                                 |
|--------------|------|-----------------------------------------------------------------------------|
| RowIndex     | int  | The zero-based index of the anchor row. |
| ColumnIndex  | int  | The zero-based index of the anchor column (**top-left cell of the merged region**). |
| RowSpan      | int (optional) | The number of rows to span, starting from the anchor cell. By default set to 1. |
| ColumnSpan   | int (optional) | The number of columns to span, starting from the anchor cell. By default set to 1. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

<button @onclick="MergeCellsAsync">Merge Cell</button>
<button @onclick="MergeMultipleCellsAsync">Merge Multiple Cells</button>

<SfGrid @ref="Grid" DataSource="@TeleCastDataList" GridLines="GridLine.Both"
        AllowSelection="false" EnableHover="false">
    <GridColumns>
        <GridColumn Field=@nameof(TelecastData.Channel) HeaderText="Channel" Width="200" TextAlign="TextAlign.Left" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Genre) HeaderText="Genre" Width="120" TextAlign="TextAlign.Left" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program12AM) HeaderText="12:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program1AM) HeaderText="1:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program2AM) HeaderText="2:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program3AM) HeaderText="3:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program4AM) HeaderText="4:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program5AM) HeaderText="5:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program6AM) HeaderText="6:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program7AM) HeaderText="7:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program8AM) HeaderText="8:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program9AM) HeaderText="9:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program10AM) HeaderText="10:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program11AM) HeaderText="11:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program12PM) HeaderText="12:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program1PM) HeaderText="1:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program2PM) HeaderText="2:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program3PM) HeaderText="3:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program4PM) HeaderText="4:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program5PM) HeaderText="5:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program6PM) HeaderText="6:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program7PM) HeaderText="7:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program8PM) HeaderText="8:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program9PM) HeaderText="9:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program10PM) HeaderText="10:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program11PM) HeaderText="11:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
    </GridColumns>
</SfGrid>

@code 
{
    public List<TelecastData>? TeleCastDataList { get; set; }
    public SfGrid<TelecastData>? Grid { get; set; }

    protected override void OnInitialized()
    {
        TeleCastDataList = TelecastData.GetTelecastData();
    }

    public async Task MergeCellsAsync()
    {
        await Grid.MergeCellsAsync(new MergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 4,
            RowSpan = 2,
        });
    }

    public async Task MergeMultipleCellsAsync()
    {
        await Grid.MergeCellsAsync(new[]
        {
            new MergeCellInfo { RowIndex = 0, ColumnIndex = 3, RowSpan = 2 },
            new MergeCellInfo { RowIndex = 5, ColumnIndex = 2, RowSpan = 3 },
            new MergeCellInfo { RowIndex = 7, ColumnIndex = 3, RowSpan = 2 }
        });
    }
}

{% endhighlight %}
{% highlight c# tabtitle="TelecastData.cs" %}

public class TelecastData
{
    public string Channel { get; set; }
    public string Genre { get; set; }
    public string Program12AM { get; set; }
    public string Program1AM { get; set; }
    public string Program2AM { get; set; }
    public string Program3AM { get; set; }
    public string Program4AM { get; set; }
    public string Program5AM { get; set; }
    public string Program6AM { get; set; }
    public string Program7AM { get; set; }
    public string Program8AM { get; set; }
    public string Program9AM { get; set; }
    public string Program10AM { get; set; }
    public string Program11AM { get; set; }
    public string Program12PM { get; set; }
    public string Program1PM { get; set; }
    public string Program2PM { get; set; }
    public string Program3PM { get; set; }
    public string Program4PM { get; set; }
    public string Program5PM { get; set; }
    public string Program6PM { get; set; }
    public string Program7PM { get; set; }
    public string Program8PM { get; set; }
    public string Program9PM { get; set; }
    public string Program10PM { get; set; }
    public string Program11PM { get; set; }

    public static List<TelecastData> GetTelecastData()
    {
        return new List<TelecastData>
        {
            new TelecastData
            {
                Channel = "USA News Network",
                Genre = "News",
                Program12AM = "Late Night News",
                Program1AM = "Overnight Brief",
                Program2AM = "Overnight Brief",
                Program3AM = "World Recap",
                Program4AM = "Early Report",
                Program5AM = "Morning Preview",
                Program6AM = "Morning Dispatch",
                Program7AM = "Daily Brief",
                Program8AM = "National Update",
                Program9AM = "National Update",
                Program10AM = "Midday Report",
                Program11AM = "Breaking Stories",
                Program12PM = "Global Roundup",
                Program1PM = "Current Affairs",
                Program2PM = "News Desk",
                Program3PM = "Afternoon Digest",
                Program4PM = "City Beat",
                Program5PM = "Evening News",
                Program6PM = "Evening News",
                Program7PM = "World Tonight",
                Program8PM = "Prime Report",
                Program9PM = "Nightly Brief",
                Program10PM = "Late Edition",
                Program11PM = "News Wrap"
            },
            new TelecastData
            {
                Channel = "American News Channel",
                Genre = "News",
                Program12AM = "Midnight Update",
                Program1AM = "Global Overnight",
                Program2AM = "Global Overnight",
                Program3AM = "News Replay",
                Program4AM = "Dawn Dispatch",
                Program5AM = "Business Early",
                Program6AM = "Early Edition",
                Program7AM = "Business Beat",
                Program8AM = "National Update",
                Program9AM = "National Update",
                Program10AM = "In Focus",
                Program11AM = "Market Pulse",
                Program12PM = "News Today",
                Program1PM = "World Matters",
                Program2PM = "Regional Review",
                Program3PM = "Evening Preview",
                Program4PM = "Local Stories",
                Program5PM = "Evening News",
                Program6PM = "Evening News",
                Program7PM = "Global Insight",
                Program8PM = "Prime Focus",
                Program9PM = "Night Desk",
                Program10PM = "Late News",
                Program11PM = "Final Report"
            },
            new TelecastData
            {
                Channel = "Science Frontier TV",
                Genre = "Science",
                Program12AM = "Tech Rewind",
                Program1AM = "Cosmic Replay",
                Program2AM = "Cosmic Replay",
                Program3AM = "Science Vault",
                Program4AM = "Tech Bits",
                Program5AM = "Nature Shorts",
                Program6AM = "How It's Built",
                Program7AM = "Nature Unveiled",
                Program8AM = "Tech Titans",
                Program9AM = "Future Innovators",
                Program10AM = "Unknown Worlds",
                Program11AM = "Planet Secrets",
                Program12PM = "Tomorrow's Tech",
                Program1PM = "Space Frontiers",
                Program2PM = "Myth Crackers",
                Program3PM = "Cosmic Discoveries",
                Program4PM = "Tech Lab",
                Program5PM = "Science Now",
                Program6PM = "Innovate Today",
                Program7PM = "Future Worlds",
                Program8PM = "Star Explorers",
                Program9PM = "Tech Deep Dive",
                Program10PM = "Science Spotlight",
                Program11PM = "Night Lab"
            },
            new TelecastData
            {
                Channel = "Explore America",
                Genre = "Science",
                Program12AM = "Wild Nights",
                Program1AM = "Explorer Vault",
                Program2AM = "Explorer Vault",
                Program3AM = "Hidden Gems",
                Program4AM = "Wild Shorts",
                Program5AM = "Nature Dawn",
                Program6AM = "Wild Expeditions",
                Program7AM = "American Wilderness",
                Program8AM = "Tech Titans",
                Program9AM = "Future Innovators",
                Program10AM = "Hidden Histories",
                Program11AM = "Mega Projects",
                Program12PM = "Great Minds",
                Program1PM = "Beyond Earth",
                Program2PM = "Star Journey",
                Program3PM = "Unique Planet",
                Program4PM = "Adventure Now",
                Program5PM = "Wild America",
                Program6PM = "Explorer's Log",
                Program7PM = "Nature Quest",
                Program8PM = "Epic Journeys",
                Program9PM = "Lost Worlds",
                Program10PM = "Planet Stories",
                Program11PM = "Night Trek"
            },
            new TelecastData
            {
                Channel = "Silver Screen Network",
                Genre = "Movies",
                Program12AM = "Movie",
                Program1AM = "Movie",
                Program2AM = "Movie",
                Program3AM = "Late Classic",
                Program4AM = "Late Classic",
                Program5AM = "Early Feature",
                Program6AM = "Shadow of Truth",
                Program7AM = "Shadow of Truth",
                Program8AM = "Shadow of Truth",
                Program9AM = "Power Play",
                Program10AM = "Power Play",
                Program11AM = "Power Play",
                Program12PM = "Power Play",
                Program1PM = "City Vigilante",
                Program2PM = "City Vigilante",
                Program3PM = "City Vigilante",
                Program4PM = "Hero Saga",
                Program5PM = "Hero Saga",
                Program6PM = "Prime Movie",
                Program7PM = "Prime Movie",
                Program8PM = "Blockbuster Night",
                Program9PM = "Blockbuster Night",
                Program10PM = "Late Show",
                Program11PM = "Late Show"
            },
            new TelecastData
            {
                Channel = "Sports USA",
                Genre = "Sports",
                Program12AM = "Sports Replay",
                Program1AM = "Game Highlights",
                Program2AM = "Game Highlights",
                Program3AM = "Sports Vault",
                Program4AM = "Early Recap",
                Program5AM = "Morning Warmup",
                Program6AM = "Morning Kickoff",
                Program7AM = "Football Classics",
                Program8AM = "Live Game Day",
                Program9AM = "Live Game Day",
                Program10AM = "Top Plays",
                Program11AM = "Sports Talk",
                Program12PM = "Hoops Highlights",
                Program1PM = "Game Plan",
                Program2PM = "Sports Roundup",
                Program3PM = "NFL Breakdown",
                Program4PM = "Sports Desk",
                Program5PM = "Live Coverage",
                Program6PM = "Game Night",
                Program7PM = "Prime Sports",
                Program8PM = "Big Match",
                Program9PM = "Sports Wrap",
                Program10PM = "Late Game",
                Program11PM = "Night Recap"
            },
            new TelecastData
            {
                Channel = "All Sports Network",
                Genre = "Sports",
                Program12AM = "Late Highlights",
                Program1AM = "Sports Classics",
                Program2AM = "Sports Classics",
                Program3AM = "Game Rewind",
                Program4AM = "Early Games",
                Program5AM = "Sports Warmup",
                Program6AM = "Morning Kickoff",
                Program7AM = "Classic Matchups",
                Program8AM = "Live Game Day",
                Program9AM = "Live Game Day",
                Program10AM = "Top Plays",
                Program11AM = "Sports Talk",
                Program12PM = "Baseball Recap",
                Program1PM = "Game Plan",
                Program2PM = "Sports Roundup",
                Program3PM = "Soccer Highlights",
                Program4PM = "Sports Central",
                Program5PM = "Live Action",
                Program6PM = "Prime Match",
                Program7PM = "Sports Night",
                Program8PM = "Big Game",
                Program9PM = "Game Recap",
                Program10PM = "Late Sports",
                Program11PM = "Final Score"
            },
            new TelecastData
            {
                Channel = "Kids Fun Zone",
                Genre = "Kids",
                Program12AM = "Cartoon Rewind",
                Program1AM = "Late Toons",
                Program2AM = "Late Toons",
                Program3AM = "Kid Classics",
                Program4AM = "Kid Classics",
                Program5AM = "Early Toons",
                Program6AM = "Adventure Pals",
                Program7AM = "Super Heroes",
                Program8AM = "Super Heroes",
                Program9AM = "Super Heroes",
                Program10AM = "Mystery Crew",
                Program11AM = "Funny Chase",
                Program12PM = "Cartoon Craze",
                Program1PM = "Quest Buddies",
                Program2PM = "Quest Buddies",
                Program3PM = "Team Turbo",
                Program4PM = "Fun Factory",
                Program5PM = "Kid Quest",
                Program6PM = "Toon Time",
                Program7PM = "Family Flicks",
                Program8PM = "Adventure Hour",
                Program9PM = "Night Toons",
                Program10PM = "Night Toons",
                Program11PM = "Sleepy Stories"
            },
            new TelecastData
            {
                Channel = "Family Playhouse",
                Genre = "Kids",
                Program12AM = "Late Kid Show",
                Program1AM = "Moonlit Tales",
                Program2AM = "Moonlit Tales",
                Program3AM = "Classic Cartoons",
                Program4AM = "Classic Cartoons",
                Program5AM = "Morning Pals",
                Program6AM = "Little Explorers",
                Program7AM = "Rescue Pals",
                Program8AM = "House of Laughs",
                Program9AM = "House of Laughs",
                Program10AM = "Mystery Crew",
                Program11AM = "Magic Wishes",
                Program12PM = "Teen Spotlight",
                Program1PM = "Ocean Adventures",
                Program2PM = "Ocean Adventures",
                Program3PM = "Rescue Pals",
                Program4PM = "Family Fun",
                Program5PM = "Kid Adventures",
                Program6PM = "Toon Party",
                Program7PM = "Family Time",
                Program8PM = "Magic Hour",
                Program9PM = "Evening Toons",
                Program10PM = "Evening Toons",
                Program11PM = "Bedtime Tales"
            },
            new TelecastData
            {
                Channel = "Magic Youth TV",
                Genre = "Kids",
                Program12AM = "Midnight Toons",
                Program1AM = "Starlight Stories",
                Program2AM = "Starlight Stories",
                Program3AM = "Toon Vault",
                Program4AM = "Toon Vault",
                Program5AM = "Early Adventures",
                Program6AM = "Mouse Playhouse",
                Program7AM = "City Kids",
                Program8AM = "Mystery Town",
                Program9AM = "Mystery Town",
                Program10AM = "Mystery Crew",
                Program11AM = "Witch Cottage",
                Program12PM = "Swamp Tales",
                Program1PM = "Stepbrothers",
                Program2PM = "Stepbrothers",
                Program3PM = "City Kids",
                Program4PM = "Youth Quest",
                Program5PM = "Fun Tales",
                Program6PM = "Cartoon Club",
                Program7PM = "Kid Heroes",
                Program8PM = "Magic Night",
                Program9PM = "Toon Dreams",
                Program10PM = "Toon Dreams",
                Program11PM = "Night Stories"
            },
            new TelecastData
            {
                Channel = "Wild America TV",
                Genre = "Wildlife",
                Program12AM = "Night Creatures",
                Program1AM = "Wild Rewind",
                Program2AM = "Wild Rewind",
                Program3AM = "Animal Vault",
                Program4AM = "Nature Clips",
                Program5AM = "Wild Dawn",
                Program6AM = "Nature Guide",
                Program7AM = "Wild Trails",
                Program8AM = "Predator Watch",
                Program9AM = "Predator Watch",
                Program10AM = "Ocean Titans",
                Program11AM = "Safari Quest",
                Program12PM = "Big Beasts",
                Program1PM = "Night Safari",
                Program2PM = "Night Safari",
                Program3PM = "Nature Guide",
                Program4PM = "Wild Tracks",
                Program5PM = "Animal Planet",
                Program6PM = "Safari Nights",
                Program7PM = "Wild World",
                Program8PM = "Beast Hunters",
                Program9PM = "Nature Nights",
                Program10PM = "Wild Chronicles",
                Program11PM = "Night Beasts"
            },
            new TelecastData
            {
                Channel = "Earth Discovery",
                Genre = "Nature",
                Program12AM = "Planet Replay",
                Program1AM = "Earth After Dark",
                Program2AM = "Earth After Dark",
                Program3AM = "Nature Classics",
                Program4AM = "Earth Early",
                Program5AM = "Dawn Planet",
                Program6AM = "Planet Wonders",
                Program7AM = "Frozen Lands",
                Program8AM = "Life on Earth",
                Program9AM = "Life on Earth",
                Program10AM = "Blue Seas",
                Program11AM = "Nature Marvels",
                Program12PM = "Earth Insights",
                Program1PM = "Night Safari",
                Program2PM = "Night Safari",
                Program3PM = "Planet Wonders",
                Program4PM = "Eco Quest",
                Program5PM = "Nature Now",
                Program6PM = "Planet Pulse",
                Program7PM = "Earth Stories",
                Program8PM = "Wild Horizons",
                Program9PM = "Nature Deep",
                Program10PM = "Earth Night",
                Program11PM = "Planet Recap"
            }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrIsLWHIWcXcUwy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Clear spanning via programmatically

The Syncfusion Blazor DataGrid provides API support to manually remove merged regions when restoration of individual cells is required. This functionality is achieved using the `UnmergeCellsAsync` methods, which allow specific merged areas to be unmerged programmatically. For scenarios where all merged regions in the current view need to be reset, the `UnmergeAllAsync` method can be used to restore every cell to its original state.

The `UnmergeCellsAsync` method is overloaded to provide flexibility for different scenarios. Both overloads share the same method name but accept different parameter types, allowing removal of either a single merged region or multiple merged regions in one operation.

| Method | Parameter | Type | Description |
|--------|-----------|------|-------------|
| `UnmergeCellsAsync` | info | `UnmergeCellInfo` | Removes a single merged area identified by its anchor cell (top‑left of the merged region). |
| `UnmergeCellsAsync` | infos | `IEnumerable<UnmergeCellInfo>` | Removes multiple merged areas in one combined operation, improving performance by reducing re‑renders. |
| `UnmergeAllAsync` | – | – | Removes all merged regions in the current view, restoring every cell to its original state. |

To identify a merged region, use the following properties of the `UnmergeCellInfo` class:

| Property     | Type | Description                                                                 |
|--------------|------|-----------------------------------------------------------------------------|
| RowIndex     | int  | The zero-based index of the anchor row. |
| ColumnIndex  | int  | The zero-based index of the anchor column (**top-left cell of the merged region**). |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="MergeCellsAsync">Merge Cell</SfButton>
<SfButton OnClick="UnMergeCell">UnMerge Cell</SfButton>

<SfButton OnClick="MergeMultipleCellsAsync">Merge Multiple Cells</SfButton>
<SfButton OnClick="UnMergeCells">UnMerge Multiple Cells</SfButton>

<SfButton OnClick="UnMergeAllCells">UnMerge All Cells</SfButton>

<SfGrid @ref="Grid" DataSource="@TeleCastDataList" AllowSorting="true" GridLines="GridLine.Both"
        AllowSelection="false" EnableHover="false">
    <GridColumns>
        <GridColumn Field=@nameof(TelecastData.Channel) HeaderText="Channel" Width="200" TextAlign="TextAlign.Left" IsPrimaryKey="true" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Genre) HeaderText="Genre" Width="120" TextAlign="TextAlign.Left" IsFrozen="true"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program12AM) HeaderText="12:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program1AM) HeaderText="1:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program2AM) HeaderText="2:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program3AM) HeaderText="3:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program4AM) HeaderText="4:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program5AM) HeaderText="5:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program6AM) HeaderText="6:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program7AM) HeaderText="7:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program8AM) HeaderText="8:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program9AM) HeaderText="9:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program10AM) HeaderText="10:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program11AM) HeaderText="11:00 AM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program12PM) HeaderText="12:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program1PM) HeaderText="1:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program2PM) HeaderText="2:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program3PM) HeaderText="3:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program4PM) HeaderText="4:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program5PM) HeaderText="5:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program6PM) HeaderText="6:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program7PM) HeaderText="7:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program8PM) HeaderText="8:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program9PM) HeaderText="9:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program10PM) HeaderText="10:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(TelecastData.Program11PM) HeaderText="11:00 PM" Width="150" TextAlign="TextAlign.Center"></GridColumn>
    </GridColumns>
</SfGrid>
@code 
{
    public List<TelecastData>? TeleCastDataList { get; set; }
    public SfGrid<TelecastData>? Grid { get; set; }

    protected override void OnInitialized()
    {
        TeleCastDataList = TelecastData.GetTelecastData();
    }

    public async Task MergeCellsAsync()
    {
        await Grid.MergeCellsAsync(new MergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 2,
            RowSpan = 2,
        });
    }

    public async Task UnMergeCell()
    {
        await Grid.UnmergeCellsAsync(new UnmergeCellInfo
        {
            RowIndex = 1,
            ColumnIndex = 2,
        });
    }

    public async Task MergeMultipleCellsAsync()
    {
        await Grid.MergeCellsAsync(new[]
        {
            new MergeCellInfo { RowIndex = 0, ColumnIndex = 0, RowSpan = 2 },
            new MergeCellInfo { RowIndex = 6, ColumnIndex = 2, RowSpan = 3 },
            new MergeCellInfo { RowIndex = 8, ColumnIndex = 1, RowSpan = 2 }
        });
    }

    public async Task UnMergeCells()
    {
        await Grid.UnmergeCellsAsync(new[]
        {
            new UnmergeCellInfo { RowIndex = 0, ColumnIndex = 0 },
            new UnmergeCellInfo { RowIndex = 6, ColumnIndex = 2 },
            new UnmergeCellInfo { RowIndex = 8, ColumnIndex = 1 }
        });
    }

    public async Task UnMergeAllCells()
    {
        await Grid.UnmergeAllAsync();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

public class TelecastData
{
    public string Channel { get; set; }
    public string Genre { get; set; }
    public string Program12AM { get; set; }
    public string Program1AM { get; set; }
    public string Program2AM { get; set; }
    public string Program3AM { get; set; }
    public string Program4AM { get; set; }
    public string Program5AM { get; set; }
    public string Program6AM { get; set; }
    public string Program7AM { get; set; }
    public string Program8AM { get; set; }
    public string Program9AM { get; set; }
    public string Program10AM { get; set; }
    public string Program11AM { get; set; }
    public string Program12PM { get; set; }
    public string Program1PM { get; set; }
    public string Program2PM { get; set; }
    public string Program3PM { get; set; }
    public string Program4PM { get; set; }
    public string Program5PM { get; set; }
    public string Program6PM { get; set; }
    public string Program7PM { get; set; }
    public string Program8PM { get; set; }
    public string Program9PM { get; set; }
    public string Program10PM { get; set; }
    public string Program11PM { get; set; }

    public static List<TelecastData> GetTelecastData()
    {
        return new List<TelecastData>
        {
            new TelecastData
            {
                Channel = "USA News Network",
                Genre = "News",
                Program12AM = "Late Night News",
                Program1AM = "Overnight Brief",
                Program2AM = "Overnight Brief",
                Program3AM = "World Recap",
                Program4AM = "Early Report",
                Program5AM = "Morning Preview",
                Program6AM = "Morning Dispatch",
                Program7AM = "Daily Brief",
                Program8AM = "National Update",
                Program9AM = "National Update",
                Program10AM = "Midday Report",
                Program11AM = "Breaking Stories",
                Program12PM = "Global Roundup",
                Program1PM = "Current Affairs",
                Program2PM = "News Desk",
                Program3PM = "Afternoon Digest",
                Program4PM = "City Beat",
                Program5PM = "Evening News",
                Program6PM = "Evening News",
                Program7PM = "World Tonight",
                Program8PM = "Prime Report",
                Program9PM = "Nightly Brief",
                Program10PM = "Late Edition",
                Program11PM = "News Wrap"
            },
            new TelecastData
            {
                Channel = "American News Channel",
                Genre = "News",
                Program12AM = "Midnight Update",
                Program1AM = "Global Overnight",
                Program2AM = "Global Overnight",
                Program3AM = "News Replay",
                Program4AM = "Dawn Dispatch",
                Program5AM = "Business Early",
                Program6AM = "Early Edition",
                Program7AM = "Business Beat",
                Program8AM = "National Update",
                Program9AM = "National Update",
                Program10AM = "In Focus",
                Program11AM = "Market Pulse",
                Program12PM = "News Today",
                Program1PM = "World Matters",
                Program2PM = "Regional Review",
                Program3PM = "Evening Preview",
                Program4PM = "Local Stories",
                Program5PM = "Evening News",
                Program6PM = "Evening News",
                Program7PM = "Global Insight",
                Program8PM = "Prime Focus",
                Program9PM = "Night Desk",
                Program10PM = "Late News",
                Program11PM = "Final Report"
            },
            new TelecastData
            {
                Channel = "Science Frontier TV",
                Genre = "Science",
                Program12AM = "Tech Rewind",
                Program1AM = "Cosmic Replay",
                Program2AM = "Cosmic Replay",
                Program3AM = "Science Vault",
                Program4AM = "Tech Bits",
                Program5AM = "Nature Shorts",
                Program6AM = "How It's Built",
                Program7AM = "Nature Unveiled",
                Program8AM = "Tech Titans",
                Program9AM = "Future Innovators",
                Program10AM = "Unknown Worlds",
                Program11AM = "Planet Secrets",
                Program12PM = "Tomorrow's Tech",
                Program1PM = "Space Frontiers",
                Program2PM = "Myth Crackers",
                Program3PM = "Cosmic Discoveries",
                Program4PM = "Tech Lab",
                Program5PM = "Science Now",
                Program6PM = "Innovate Today",
                Program7PM = "Future Worlds",
                Program8PM = "Star Explorers",
                Program9PM = "Tech Deep Dive",
                Program10PM = "Science Spotlight",
                Program11PM = "Night Lab"
            },
            new TelecastData
            {
                Channel = "Explore America",
                Genre = "Science",
                Program12AM = "Wild Nights",
                Program1AM = "Explorer Vault",
                Program2AM = "Explorer Vault",
                Program3AM = "Hidden Gems",
                Program4AM = "Wild Shorts",
                Program5AM = "Nature Dawn",
                Program6AM = "Wild Expeditions",
                Program7AM = "American Wilderness",
                Program8AM = "Tech Titans",
                Program9AM = "Future Innovators",
                Program10AM = "Hidden Histories",
                Program11AM = "Mega Projects",
                Program12PM = "Great Minds",
                Program1PM = "Beyond Earth",
                Program2PM = "Star Journey",
                Program3PM = "Unique Planet",
                Program4PM = "Adventure Now",
                Program5PM = "Wild America",
                Program6PM = "Explorer's Log",
                Program7PM = "Nature Quest",
                Program8PM = "Epic Journeys",
                Program9PM = "Lost Worlds",
                Program10PM = "Planet Stories",
                Program11PM = "Night Trek"
            },
            new TelecastData
            {
                Channel = "Silver Screen Network",
                Genre = "Movies",
                Program12AM = "Movie",
                Program1AM = "Movie",
                Program2AM = "Movie",
                Program3AM = "Late Classic",
                Program4AM = "Late Classic",
                Program5AM = "Early Feature",
                Program6AM = "Shadow of Truth",
                Program7AM = "Shadow of Truth",
                Program8AM = "Shadow of Truth",
                Program9AM = "Power Play",
                Program10AM = "Power Play",
                Program11AM = "Power Play",
                Program12PM = "Power Play",
                Program1PM = "City Vigilante",
                Program2PM = "City Vigilante",
                Program3PM = "City Vigilante",
                Program4PM = "Hero Saga",
                Program5PM = "Hero Saga",
                Program6PM = "Prime Movie",
                Program7PM = "Prime Movie",
                Program8PM = "Blockbuster Night",
                Program9PM = "Blockbuster Night",
                Program10PM = "Late Show",
                Program11PM = "Late Show"
            },
            new TelecastData
            {
                Channel = "Sports USA",
                Genre = "Sports",
                Program12AM = "Sports Replay",
                Program1AM = "Game Highlights",
                Program2AM = "Game Highlights",
                Program3AM = "Sports Vault",
                Program4AM = "Early Recap",
                Program5AM = "Morning Warmup",
                Program6AM = "Morning Kickoff",
                Program7AM = "Football Classics",
                Program8AM = "Live Game Day",
                Program9AM = "Live Game Day",
                Program10AM = "Top Plays",
                Program11AM = "Sports Talk",
                Program12PM = "Hoops Highlights",
                Program1PM = "Game Plan",
                Program2PM = "Sports Roundup",
                Program3PM = "NFL Breakdown",
                Program4PM = "Sports Desk",
                Program5PM = "Live Coverage",
                Program6PM = "Game Night",
                Program7PM = "Prime Sports",
                Program8PM = "Big Match",
                Program9PM = "Sports Wrap",
                Program10PM = "Late Game",
                Program11PM = "Night Recap"
            },
            new TelecastData
            {
                Channel = "All Sports Network",
                Genre = "Sports",
                Program12AM = "Late Highlights",
                Program1AM = "Sports Classics",
                Program2AM = "Sports Classics",
                Program3AM = "Game Rewind",
                Program4AM = "Early Games",
                Program5AM = "Sports Warmup",
                Program6AM = "Morning Kickoff",
                Program7AM = "Classic Matchups",
                Program8AM = "Live Game Day",
                Program9AM = "Live Game Day",
                Program10AM = "Top Plays",
                Program11AM = "Sports Talk",
                Program12PM = "Baseball Recap",
                Program1PM = "Game Plan",
                Program2PM = "Sports Roundup",
                Program3PM = "Soccer Highlights",
                Program4PM = "Sports Central",
                Program5PM = "Live Action",
                Program6PM = "Prime Match",
                Program7PM = "Sports Night",
                Program8PM = "Big Game",
                Program9PM = "Game Recap",
                Program10PM = "Late Sports",
                Program11PM = "Final Score"
            },
            new TelecastData
            {
                Channel = "Kids Fun Zone",
                Genre = "Kids",
                Program12AM = "Cartoon Rewind",
                Program1AM = "Late Toons",
                Program2AM = "Late Toons",
                Program3AM = "Kid Classics",
                Program4AM = "Kid Classics",
                Program5AM = "Early Toons",
                Program6AM = "Adventure Pals",
                Program7AM = "Super Heroes",
                Program8AM = "Super Heroes",
                Program9AM = "Super Heroes",
                Program10AM = "Mystery Crew",
                Program11AM = "Funny Chase",
                Program12PM = "Cartoon Craze",
                Program1PM = "Quest Buddies",
                Program2PM = "Quest Buddies",
                Program3PM = "Team Turbo",
                Program4PM = "Fun Factory",
                Program5PM = "Kid Quest",
                Program6PM = "Toon Time",
                Program7PM = "Family Flicks",
                Program8PM = "Adventure Hour",
                Program9PM = "Night Toons",
                Program10PM = "Night Toons",
                Program11PM = "Sleepy Stories"
            },
            new TelecastData
            {
                Channel = "Family Playhouse",
                Genre = "Kids",
                Program12AM = "Late Kid Show",
                Program1AM = "Moonlit Tales",
                Program2AM = "Moonlit Tales",
                Program3AM = "Classic Cartoons",
                Program4AM = "Classic Cartoons",
                Program5AM = "Morning Pals",
                Program6AM = "Little Explorers",
                Program7AM = "Rescue Pals",
                Program8AM = "House of Laughs",
                Program9AM = "House of Laughs",
                Program10AM = "Mystery Crew",
                Program11AM = "Magic Wishes",
                Program12PM = "Teen Spotlight",
                Program1PM = "Ocean Adventures",
                Program2PM = "Ocean Adventures",
                Program3PM = "Rescue Pals",
                Program4PM = "Family Fun",
                Program5PM = "Kid Adventures",
                Program6PM = "Toon Party",
                Program7PM = "Family Time",
                Program8PM = "Magic Hour",
                Program9PM = "Evening Toons",
                Program10PM = "Evening Toons",
                Program11PM = "Bedtime Tales"
            },
            new TelecastData
            {
                Channel = "Magic Youth TV",
                Genre = "Kids",
                Program12AM = "Midnight Toons",
                Program1AM = "Starlight Stories",
                Program2AM = "Starlight Stories",
                Program3AM = "Toon Vault",
                Program4AM = "Toon Vault",
                Program5AM = "Early Adventures",
                Program6AM = "Mouse Playhouse",
                Program7AM = "City Kids",
                Program8AM = "Mystery Town",
                Program9AM = "Mystery Town",
                Program10AM = "Mystery Crew",
                Program11AM = "Witch Cottage",
                Program12PM = "Swamp Tales",
                Program1PM = "Stepbrothers",
                Program2PM = "Stepbrothers",
                Program3PM = "City Kids",
                Program4PM = "Youth Quest",
                Program5PM = "Fun Tales",
                Program6PM = "Cartoon Club",
                Program7PM = "Kid Heroes",
                Program8PM = "Magic Night",
                Program9PM = "Toon Dreams",
                Program10PM = "Toon Dreams",
                Program11PM = "Night Stories"
            },
            new TelecastData
            {
                Channel = "Wild America TV",
                Genre = "Wildlife",
                Program12AM = "Night Creatures",
                Program1AM = "Wild Rewind",
                Program2AM = "Wild Rewind",
                Program3AM = "Animal Vault",
                Program4AM = "Nature Clips",
                Program5AM = "Wild Dawn",
                Program6AM = "Nature Guide",
                Program7AM = "Wild Trails",
                Program8AM = "Predator Watch",
                Program9AM = "Predator Watch",
                Program10AM = "Ocean Titans",
                Program11AM = "Safari Quest",
                Program12PM = "Big Beasts",
                Program1PM = "Night Safari",
                Program2PM = "Night Safari",
                Program3PM = "Nature Guide",
                Program4PM = "Wild Tracks",
                Program5PM = "Animal Planet",
                Program6PM = "Safari Nights",
                Program7PM = "Wild World",
                Program8PM = "Beast Hunters",
                Program9PM = "Nature Nights",
                Program10PM = "Wild Chronicles",
                Program11PM = "Night Beasts"
            },
            new TelecastData
            {
                Channel = "Earth Discovery",
                Genre = "Nature",
                Program12AM = "Planet Replay",
                Program1AM = "Earth After Dark",
                Program2AM = "Earth After Dark",
                Program3AM = "Nature Classics",
                Program4AM = "Earth Early",
                Program5AM = "Dawn Planet",
                Program6AM = "Planet Wonders",
                Program7AM = "Frozen Lands",
                Program8AM = "Life on Earth",
                Program9AM = "Life on Earth",
                Program10AM = "Blue Seas",
                Program11AM = "Nature Marvels",
                Program12PM = "Earth Insights",
                Program1PM = "Night Safari",
                Program2PM = "Night Safari",
                Program3PM = "Planet Wonders",
                Program4PM = "Eco Quest",
                Program5PM = "Nature Now",
                Program6PM = "Planet Pulse",
                Program7PM = "Earth Stories",
                Program8PM = "Wild Horizons",
                Program9PM = "Nature Deep",
                Program10PM = "Earth Night",
                Program11PM = "Planet Recap"
            }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZryMVWdoMJJubZh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Limitations

The row spanning is not compatible with the following features:

1. Autofill.
2. Grouping - Row and column spanning are supported only within the same caption row during grouping scenarios. This means cells can be merged horizontally or vertically only inside a single group header (caption row). Merging across different caption rows is not supported, since each caption row represents a distinct group context. Allowing spans between these rows would break the logical grouping structure and the visual hierarchy of the grid.
3. Frozen Grid - When the `Freeze` property is set to `FreezeDirection.Fixed`, the concerned column will not be included for row spanning.
