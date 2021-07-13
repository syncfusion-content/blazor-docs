# Styling

To modify the Tree Grid appearance, you need to override the default CSS of Tree Grid. Please find the list of CSS classes and its corresponding section in Tree Grid.

Section|CSS class|Purpose of CSS class
-----|-----|-----
**Root**|e-treegrid|This classes are in this root element div of the Tree Grid control.
**Header**|e-gridheader|This class is added in the root element of header element. In this class, You can override thin line between header and content of the Tree Grid.
||e-table|This class is added at **table** of the Tree Grid header. This CSS class makes table width as 100 %.
||e-columnheader|This class is added at **tr** of the Tree Grid header.
||e-headercell|This class is added in **th** element of Tree Grid header. You can override background color of header and border color.
||e-headercelldiv|This class is add in div which present **th** element in the header. we recommend you to use the e-headercelldiv to override skeleton of header.
**Body**|e-gridcontent|This class is added at root of body content. This is to override background color of the body.
||e-table|This class is added to table of content. This CSS class makes table width as 100 %.
||e-altrow|This class is added to alternate rows of Tree Grid. This is to override alternate row color of the Tree Grid.
||e-rowcell|This class is added to all cells in the Tree Grid. This is to override cells appearance and styling.
||e-groupcaption|This class is added to the **td** of group caption which is to change the background color of caption cell.
||e-selectionbackground|This class is added to rowcell's of the Tree Grid. This is override selection.
||e-hover|This class adds to row of Tree Grid, while hovering the Tree Grid rows.
**Pager**|e-pager|This class is added to root element of the pager. This to change appearance of the background color and color of font.
||e-pagercontainer|This class is added to numeric items of the pager.
||e-parentmsgbar|This class is added to pager info of the pager.
**Summary**|e-gridfooter|This class is added to root of the summary div.
||e-summaryrow|This class is added to rows of Tree Grid summary.
||e-summarycell|This class is added to cells of summary row. This to override background color of summary.