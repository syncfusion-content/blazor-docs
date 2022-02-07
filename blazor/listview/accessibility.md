---
layout: post
title: Accessibility in Blazor ListView Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor ListView component and much more.
platform: Blazor
control: Listview
documentation: ug
---

# Accessibility in Blazor ListView Component

## Keyboard interaction

The following key shortcuts are used to access the ListView control without any interruption.

| Keyboard shortcuts | Actions |
|------------|-------------------|
| <kbd>Arrow Up</kbd> | Move to the previous list item. |
| <kbd>Arrow Down</kbd> | Move to the next list item. |
| <kbd>Select</kbd> | Select the targeted list from the whole list. |
| <kbd>Back</kbd> | Get back to the previous lists if it is in nested list. |

```cshtml
@using Syncfusion.Blazor.Lists
@using Syncfusion.Blazor.Data

<SfListView DataSource="@ListData" ShowHeader="true" HeaderTitle="Continent">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text" Child="Child"></ListViewFieldSettings>
</SfListView>

@code {
    List<DataModel> ListData = new List<DataModel>();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        ListData.Add(new DataModel
        {
            Text = "Asia",
            Id = "01",
            Category = "Continent",
            Child = new List<DataModel>() {
                    new DataModel {
                        Text = "India",
                            Id = "1",
                            Category = "Asia",
                            Child = new List<DataModel> () {
                                new DataModel {
                                    Id = "1001",
                                        Text = "Delhi",
                                        Category = "India"
                                },
                                new DataModel {
                                    Text = "Kashmir",
                                        Id = "1002",
                                        Category = "India"
                                },
                                new DataModel {
                                    Text = "Goa",
                                        Id = "1003",
                                        Category = "India"
                                }
                            }
                    },
                    new DataModel {
                        Text = "China",
                            Id = "2",
                            Category = "Asia",
                            Child = new List<DataModel> () {
                                new DataModel {
                                    Text = "Zhejiang",
                                        Id = "2001",
                                        Category = "China"
                                },
                                new DataModel {
                                    Text = "Hunan",
                                        Id = "2002",
                                        Category = "China"
                                },
                                new DataModel {
                                    Text = "Shandong",
                                        Id = "2003",
                                        Category = "China"
                                }
                            }
                    }
                }
        });
        ListData.Add(new DataModel
        {
            Text = "North America",
            Id = "02",
            Category = "Continent",
            Child = new List<DataModel>() {
                    new DataModel {
                        Text = "USA",
                            Id = "3",
                            Category = "North America",
                            Child = new List<DataModel> () {
                                new DataModel {
                                    Text = "California",
                                        Id = "3001",
                                        Category = "USA"
                                },
                                new DataModel {
                                    Text = "New York",
                                        Id = "3002",
                                        Category = "USA"
                                },
                                new DataModel {
                                    Text = "Florida",
                                        Id = "3003",
                                        Category = "USA"
                                }
                            }
                    },
                    new DataModel {
                        Text = "Canada",
                            Id = "4",
                            Category = "North America",
                            Child = new List<DataModel> () {
                                new DataModel {
                                    Text = "Ontario",
                                        Id = "4001",
                                        Category = "Canada"
                                },
                                new DataModel {
                                    Text = "Alberta",
                                        Id = "4002",
                                        Category = "Canada"
                                },
                                new DataModel {
                                    Text = "Manitoba",
                                        Id = "4003",
                                        Category = "Canada"
                                }
                            }
                    }
                }
        });
        ListData.Add(new DataModel
        {
            Text = "Europe",
            Id = "03",
            Category = "Continent",
            Child = new List<DataModel>() {
                    new DataModel {
                        Text = "Germany",
                            Id = "5",
                            Category = "Europe",
                            Child = new List<DataModel> () {
                                new DataModel {
                                    Text = "Berlin",
                                        Id = "5001",
                                        Category = "Germany"
                                },
                                new DataModel {
                                    Text = "Bavaria",
                                        Id = "5002",
                                        Category = "Germany"
                                },
                                new DataModel {
                                    Text = "Hesse",
                                        Id = "5003",
                                        Category = "Germany"
                                }
                            }
                    },
                    new DataModel {
                        Text = "France",
                            Id = "6",
                            Category = "Europe",
                            Child = new List<DataModel> () {
                                new DataModel {
                                    Text = "Paris",
                                        Id = "6001",
                                        Category = "France"
                                },
                                new DataModel {
                                    Text = "Lyon",
                                        Id = "6002",
                                        Category = "France"
                                },
                                new DataModel {
                                    Text = "Marseille",
                                        Id = "6003",
                                        Category = "France"
                                }
                            }
                    }
                }
        });
    }

    public class DataModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public List<DataModel> Child { get; set; }
    }
}

```

## ARIA attributes

The following ARIA attributes are applicable for ListView control based on its state.

| Properties | Functionality |
| ------------ | ----------------------- |
| aria-selected | It indicates the selected list from the whole list. |
| aria-level | It defines the hierarchical structure of a list item. |