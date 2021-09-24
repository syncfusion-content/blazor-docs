---
layout: post
title: Render Chip control inside Grid Column | Syncfusion
description: Learn here how to render the Syncfusion Blazor Chip component inside the Syncfusion DataGrid column using Column Template.
platform: Blazor
control: DataGrid
documentation: ug
---

# Render Chip component inside the Grid Column

Syncfusion Blazor Chip component can be rendered inside the Grid column using [`Column Template`](https://blazor.syncfusion.com/documentation/datagrid/columns#column-template) feature of the Grid. Chip component is used to display the multiple value separately.

This is demonstrated in the below sample code where Chip component is rendered inside Grid Column which has multiple values.

> Since Column Template needs to triggered for several times (i.e. for each cell), we have used @ref variable to SfChip component to indicate when to refresh the child components (ChipItem).

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="blogs" AllowTextWrap="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(Blog.BlogId)" HeaderText="Blog ID" TextAlign="TextAlign.Left" IsPrimaryKey="true" Width="110"></GridColumn>
        <GridColumn Field="@nameof(Blog.AuthorName)" HeaderText="Author Name" TextAlign="TextAlign.Left" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Blog.Status)" TextAlign="TextAlign.Center" Width="150" MaxWidth="170">
            <Template>
                @{
                    var Context = (context as Blog).Status;
                    <SfChip @key="@Context">
                        <ChipItems>
                            @if (Context == "Published")
                            {
                                <ChipItem Text="@Context" CssClass="title-published"></ChipItem>
                            }
                            else if (Context == "Draft")
                            {
                                <ChipItem Text="@Context" CssClass="title-draft"></ChipItem>
                            }
                            else
                            {
                                <ChipItem Text="@Context" CssClass="title-review"></ChipItem>
                            }
                        </ChipItems>
                    </SfChip>
                }
            </Template>
        </GridColumn>
        <GridColumn Field="@nameof(Blog.Tags)" HeaderText="Tags" TextAlign="TextAlign.Center" Width="170" MaxWidth="220">
            <Template>
                @{
                    var process = context as Blog;
                    <SfChip @key="@process">
                        <ChipItems>
                            @foreach (var tag in process.Tags)
                            {
                                <ChipItem Text="@tag" CssClass=@("e-"+tag)></ChipItem>
                            }
                        </ChipItems>
                    </SfChip>
                }
            </Template>

        </GridColumn>
        <GridColumn Field="@nameof(Blog.DraftingStartDate)" HeaderText="Drafting Duration" TextAlign="TextAlign.Left" Width="160" ClipMode="ClipMode.EllipsisWithTooltip">
            <Template>
                @{
                    var d = (context as Blog);
                    var days = d.DraftingEndDate - d.DraftingStartDate;
                    <span>@days.Days days</span>
                }
            </Template>
        </GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-chip.title-published {
        background: #90F0BD;
    }

    .e-chip.title-draft {
        background: #FFE87F;
    }

    .e-chip.title-review {
        background: #A8E9F7;
    }

    .e-chip.e-Blazor {
        background: #F35E3E;
    }

    .e-chip.e-JavaScript {
        background: #F4BD37;
    }

    .e-chip.e-ASPNETCORE {
        background: #CCF437;
    }

    .e-chip.e-Flutter {
        background: #37F4BF;
    }

    .e-chip.e-Xamarin {
        background: #C437F4;
    }
</style>

@code
{
    public List<Blog> blogs { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        blogs = Enumerable.Range(1, 50).Select((x) => new Blog()
        {
            AuthorName = (new string[] { "ALFKI", "ANTON", "BOLID", "BLONP", "ANATR" })[new Random().Next(5)],
            Status = (new string[] { "Published", "Draft" })[new Random().Next(2)],
            Tags = bloggerContents[new Random().Next(6)],
            BlogId = "BLOG-10" + x,
            DraftingStartDate = (new DateTime[] { DateTime.Now.AddDays(1), DateTime.Now.AddDays(2) })[new Random().Next(2)],
            DraftingEndDate = (new DateTime[] { DateTime.Now.AddDays(30), DateTime.Now.AddDays(31) })[new Random().Next(2)]

        }).ToList();
    }

    public List<string[]> bloggerContents = new List<string[]>
{
        new string[2] { "JavaScript", "Blazor"},
        new string[4] { "JavaScript", "Blazor","ASPNETCORE","Flutter"},
        new string[3] { "Xamarin", "Blazor", "JavaScript"},
        new string[2] { "Xamarin", "Flutter"},
        new string[1] { "Blazor"},
        new string[3] { "Xamarin", "ASPNETCORE", "Flutter"},
    }.ToList();

    public class Blog
    {
        public string BlogId { get; set; }
        public string AuthorName { get; set; }
        public string Status { get; set; }
        public string[] Tags { get; set; } = new string[] { };
        public DateTime DraftingStartDate { get; set; }
        public DateTime DraftingEndDate { get; set; }
    }
}
```
