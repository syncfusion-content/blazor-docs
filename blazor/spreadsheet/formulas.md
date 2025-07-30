---
layout: post
title: Formulas in Blazor Spreadsheet Component | Syncfusion
description: Checkout and learn here all about formulas in Syncfusion Blazor Spreadsheet component and more | Syncfusion.
platform: Blazor
control: Spreadsheet
documentation: ug
---

# Formulas in Blazor Spreadsheet component

The Syncfusion Blazor Spreadsheet component offers robust formula support, enabling to perform complex calculations and data analysis with ease. These formulas operate on cell values by referencing data from the current sheet or across multiple sheets within the workbook.

## Formula bar

The formula bar is a key interface element in the Syncfusion Blazor Spreadsheet, designed to make it easier to view, edit, and enter cell data and formulas. Formula bar is positioned above the sheet grid, it provides a centralized space for working with formulas. Formula bar can also be expanded or collapsed to suit your needs. When expanded, it offers more vertical space, making it easier to read and edit long or complex formulas with greater accuracy.

Formula Bar can be enable/disable by using the [ShowFormulaBar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Spreadsheet.SfSpreadsheet.html#Syncfusion_Blazor_Spreadsheet_SfSpreadsheet_ShowFormulaBar) property, which is set to true by default.

![Formula bar](./images/formulabar.png)

## Working with formulas via UI

The Syncfusion Blazor Spreadsheet component provides multiple methods for inserting and editing formulas, accommodating different workflow preferences. Each method serves specific use cases and offers unique advantages for formula creation and manipulation.

### Insert function dialog

* Select **Insert Function** from the **Formulas** tab in the **Ribbon** toolbar. In the **Insert Function** dialog, choose a category, then select the desired formula to insert it into the selected cell and click **Ok** button.

![Insert Function Dialog](./images/insertfunction-ribbon.gif)

* Click the **Insert Function** button next to the **Formula Bar** to open the **Insert Function** dialog, which provides the same categorized formula list and insertion options as the **Ribbon** toolbar.

![Insert Function Button](./images/inserfunction-formulabar.gif)

### Direct Cell Entry

Formulas can be entered directly into cells or the **Formula Bar** by typing an equals sign **(=)** followed by the formula expression. This method initiates the formula intellisense feature, which displays a dropdown list of relevant formulas. The intellisense feature accelerates formula creation by reducing typing and helping avoid syntax errors.

![Formulas Intellisense](./images/formula-intellisence.gif)

## Calculation Mode

The Syncfusion Blazor Spreadsheet implements **Calculation Option**  that control when and how formulas are recalculated, allowing optimization for different performance scenarios. The available calculation modes mirror Microsoft Excel's functionality, providing familiar behavior. The available modes are:

* **Automatic**: Formulas recalculate instantly when any dependent cell changes.

* **Manual**: Formulas recalculate only when explicitly triggered using the **Calculate Sheet** or **Calculate Workbook** options.

### Automatic

In **Automatic** calculation mode, formulas are recalculated immediately upon any modification to dependent cell values. This functionality ensures that all computed results remain accurate and up to date without requiring manual recalculation. The automatic propagation of changes throughout the formula dependency chain preserves data consistency and enhances computational reliability. By default, **Automatic** calculation is enabled in spreadsheet.

**Example:**

If cell **C1** contains the formula **=A1+B1**, any changes to values in cells **A1** or **B1** will automatically update the result displayed in **C1**. This real-time calculation is ideal for scenarios requiring immediate feedback and continuous result validation.

![Automatic calculation mode](./images/automatic-calculation.gif)

### Manual

In **Manual** calculation mode, formulas remain static until explicitly recalculated by triggered manually. This mode prevents automatic recalculation, which can significantly improve performance when working with large datasets or complex formulas. Manual calculation mode is particularly useful when performing multiple changes that would otherwise trigger numerous intermediate recalculations.

**Example:**

If cell **C1** containing the formula **=A1+B1** in manual mode, changes to cells **A1** or **B1** will not update the result in **C1** until recalculation is manually triggered. The Spreadsheet provides two recalculation options:

**Calculate Sheet:** Recalculates only the formulas within the active sheet.

**Calculate Workbook:** Recalculates all formulas across all sheets in the workbook.

![Manual calculation mode](./images/manual-calculation.gif)

## Named Ranges

The **Named Range** feature in the Syncfusion Blazor Spreadsheet component allows you to assign a meaningful name to a specific cell or range of cells. This enhances the clarity and usability of spreadsheets, making them easier to navigate, maintain, and understand—especially when creating formulas or analyzing data.

**Named range usage in formulas**

Using named ranges in formulas enhances readability and maintainability. Instead of referencing a range like **A1:A12**, you can use a descriptive name such as "MonthlyTotals" directly in your formula. For instance, writing **=SUM(MonthlyTotals)** makes the formula more intuitive for anyone reviewing the spreadsheet. Named ranges are fully supported across all standard formula entry methods, including the formula bar and direct cell input.

**Accessing the Name Manager in dialog box and toolbar**

The Name Manager serves as a central interface for managing all name ranges across the workbook. The Name Manager dialog box can be accessed via two methods:

* The **Name Manager** button located in the **Formulas** tab on the Spreadsheet **Ribbon** toolbar.
* The **Name Manager** option can also be launched when creating or managing ranges from the **Name Box**.

N> Named Ranges can be defined only for cells or ranges that contain values.

### Creating named ranges via UI

**Creating using the name box**

Named ranges can be created using the following methods:

The Name box is positioned to the left of the formula bar, above the sheet grid. To create a Named Range using the name box:

* Select the desired cell or range of cells in the sheet.
* Click inside the name box, this will highlight the current cell reference.
* Enter a unique and descriptive name according to the naming rules (begin with a letter or underscore, no spaces, and avoid using cell reference format).
* Press the **Enter** key to finalize creation. The new Named Range will be immediately active and available for use in formulas.

![Named Range Name Box](./images/namedrange-namebox.gif)

**Creating using the dialog box**

To establish a Named Range through the Name Manager dialog:

* Navigate to the **Formulas** tab in the ribbon toolbar and select the **Name Manager** button to open the dialog.
* In the input field labeled "Range Name", enter a unique and descriptive name for the range.
* Specify the desired range in the "Range Value" field. This can be done by entering a cell/range reference manually, by default it shows currently select cell/range reference in the field.
* Set the appropriate scope (workbook or worksheet, as supported).
* Confirm by clicking the **Add Range** button. The created Named Range will now appear in the Name Manager list and click **OK** button.

![Named Range toolbar](./images/namedrange-ribbon.gif)

### Editing named ranges via UI

To modify an existing Named Range:

* Open the Name Manager dialog box from the **Formulas** tab by clicking the **Name Manager** button.
* In the Name Manager dialog, select the Named Range required for editing from the list.
* Click the **Edit** icon provided for the selected Named Range. An editing panel will appear.
* Update the "Range Name," "Range Value" or the scope as necessary, following the standard naming and reference rules.
* Confirm changes by clicking the **Update Range** button, then click the **OK** button to commit the edit. The modifications will become immediately effective throughout all associated formulas.

![Named Range Editing](./images/namedrange-editing.gif)

### Deleting Named Range via UI

To remove a Named Range using the UI:

* Open the Name Manager dialog box from the **Formulas** tab by selecting the **Name Manager** option.
* Select the Named Range targeted for deletion from the list.
* Click the **Delete** icon associated with the selected Named Range.
* Confirm the action by clicking the **OK** button in the Name Manager. The Named Range will be deleted from the workbook, and all formulas referencing the deleted name will return a `#NAME?` error until updated.

N> Deleting a Named Range used in formulas may cause formula errors. Ensure the Named Range is not referenced before deleting it. Deleting a worksheet also removes any Name Ranges that were created specifically within that worksheet.

![Named Range Deleting](./images/namedrange-delete.gif)
## Supported Formulas

The Spreadsheet component supports a wide range of built-in formulas, enabling powerful data analysis and manipulation. Below is the list of formulas supported in the Spreadsheet component:

<table>
<tr>
<th>
Functions<br/><br/></th><th>
Description<br/><br/></th></tr>
<tbody>
<tr>
<td>
ABS<br/><br/></td><td>
Returns the absolute value of a number<br/><br/></td></tr>
<tr>
<td>
ACOS<br/><br/></td><td>
Returns the arccosine of a number<br/><br/></td></tr>
<tr>
<td>
ACOSH<br/><br/></td><td>
Returns the inverse hyperbolic cosine of a number<br/><br/></td></tr>
<tr>
<td>
ADDRESS<br/><br/></td><td>
Returns a reference as text to a single cell in a worksheet<br/><br/></td></tr>
<tr>
<td>
AND<br/><br/></td><td>
Returns TRUE if all of its arguments are TRUE<br/><br/></td></tr>
<tr>
<td>
AREAS<br/><br/></td><td>
Returns the number of areas in a reference<br/><br/></td></tr>
<tr>
<td>
ARRAYTOTEXT<br/><br/></td><td>
Returns the text representation of an array, though calculation of this formula result is not supported in XlsIO<br/><br/></td></tr>
<tr>
<td>
ASC<br/><br/></td><td>
Changes full-width (double-byte) English letters or katakana within a character string to half-width (single-byte) characters<br/><br/></td></tr>
<tr>
<td>
ASIN<br/><br/></td><td>
Returns the arcsine of a number<br/><br/></td></tr>
<tr>
<td>
ASINH<br/><br/></td><td>
Returns the inverse hyperbolic sine of a number<br/><br/></td></tr>
<tr>
<td>
ATAN<br/><br/></td><td>
Returns the arctangent of a number<br/><br/></td></tr>
<tr>
<td>
ATAN2<br/><br/></td><td>
Returns the arctangent from x- and y-coordinates<br/><br/></td></tr>
<tr>
<td>
ATANH<br/><br/></td><td>
Returns the inverse hyperbolic tangent of a number<br/><br/></td></tr>
<tr>
<td>
AVEDEV<br/><br/></td><td>
Returns the average of the absolute deviations of data points from their mean<br/><br/></td></tr>
<tr>
<td>
AVERAGE<br/><br/></td><td>
Returns the average of its arguments<br/><br/></td></tr>
<tr>
<td>
AVERAGEA<br/><br/></td><td>
Returns the average of its arguments, including numbers, text, and logical values<br/><br/></td></tr>
<tr>
<td>
AVERAGEIF<br/><br/></td><td>
Returns the average (arithmetic mean) of all the cells in a range that meet a given criterion<br/><br/></td></tr>
<tr>
<td>
AVERAGEIFS<br/><br/></td><td>
Returns the average (arithmetic mean) of all cells that meet multiple criteria<br/><br/></td></tr>
<tr>
<td>
BESSELI<br/><br/></td><td>
Returns the modified Bessel function In(x)<br/><br/></td></tr>
<tr>
<td>
BESSELJ<br/><br/></td><td>
Returns the Bessel function Jn(x)<br/><br/></td></tr>
<tr>
<td>
BESSELK<br/><br/></td><td>
Returns the modified Bessel function Kn(x)<br/><br/></td></tr>
<tr>
<td>
BESSELY<br/><br/></td><td>
Returns the Bessel function Yn(x)<br/><br/></td></tr>
<tr>
<td>
BIN2DEC<br/><br/></td><td>
Converts a binary number to decimal<br/><br/></td></tr>
<tr>
<td>
BIN2HEX<br/><br/></td><td>
Converts a binary number to hexadecimal<br/><br/></td></tr>
<tr>
<td>
BIN2OCT<br/><br/></td><td>
Converts a binary number to octal<br/><br/></td></tr>
<tr>
<td>
BINOMDIST<br/><br/></td><td>
Returns the individual term binomial distribution probability<br/><br/></td></tr>
<tr>
<td>
BYCOL<br/><br/></td><td>
Applies a LAMBDA to each column and returns an array of the results<br/><br/></td></tr>
<tr>
<td>
BYROW<br/><br/></td><td>
Applies a LAMBDA to each row and returns an array of the results<br/><br/></td></tr>
<tr>
<td>
CEILING<br/><br/></td><td>
Rounds a number to the nearest integer or to the nearest multiple of significance<br/><br/></td></tr>
<tr>
<td>
CELL<br/><br/></td><td>
Returns information about the formatting, location, or contents of a cell<br/><br/></td></tr>
<tr>
<td>
CHAR<br/><br/></td><td>
Returns the character specified by the code number<br/><br/></td></tr>
<tr>
<td>
CHIDIST<br/><br/></td><td>
Returns the one-tailed probability of the chi-squared distribution<br/><br/></td></tr>
<tr>
<td>
CHIINV<br/><br/></td><td>
Returns the inverse of the one-tailed probability of the chi-squared distribution<br/><br/></td></tr>
<tr>
<td>
CHITEST<br/><br/></td><td>
Returns the test for independence<br/><br/></td></tr>
<tr>
<td>
CHOOSE<br/><br/></td><td>
Chooses a value from a list of values<br/><br/></td></tr>
<tr>
<td>
CHOOSECOLS<br/><br/></td><td>
Returns specified columns from an array<br/><br/></td></tr>
<tr>
<td>
CHOOSEROWS<br/><br/></td><td>
Returns specified rows from an array<br/><br/></td></tr>
<tr>
<td>
CLEAN<br/><br/></td><td>
Removes all non-printable characters from text<br/><br/></td></tr>
<tr>
<td>
CODE<br/><br/></td><td>
Returns a numeric code for the first character in a text string<br/><br/></td></tr>
<tr>
<td>
COLUMN<br/><br/></td><td>
Returns the column number of a reference<br/><br/></td></tr>
<tr>
<td>
COLUMNS<br/><br/></td><td>
Returns the number of columns in a reference<br/><br/></td></tr>
<tr>
<td>
COMBIN<br/><br/></td><td>
Returns the number of combinations for a given number of objects<br/><br/></td></tr>
<tr>
<td>
COMPLEX<br/><br/></td><td>
Converts real and imaginary coefficients into a complex number<br/><br/></td></tr>
<tr>
<td>
CONCAT<br/><br/></td><td>
Combines the text from multiple ranges and/or strings<br/><br/></td></tr>
<tr>
<td>
CONCATENATE<br/><br/></td><td>
Joins several text items into one text item<br/><br/></td></tr>
<tr>
<td>
CONFIDENCE<br/><br/></td><td>
Returns the confidence interval for a population mean<br/><br/></td></tr>
<tr>
<td>
CONVERT<br/><br/></td><td>
Converts a number from one measurement system to another<br/><br/></td></tr>
<tr>
<td>
CORREL<br/><br/></td><td>
Returns the correlation coefficient between two data sets<br/><br/></td></tr>
<tr>
<td>
COS<br/><br/></td><td>
Returns the cosine of a number<br/><br/></td></tr>
<tr>
<td>
COSH<br/><br/></td><td>
Returns the hyperbolic cosine of a number<br/><br/></td></tr>
<tr>
<td>
COUNT<br/><br/></td><td>
Counts how many numbers are in the list of arguments<br/><br/></td></tr>
<tr>
<td>
COUNTA<br/><br/></td><td>
Counts how many values are in the list of arguments<br/><br/></td></tr>
<tr>
<td>
COUNTBLANK<br/><br/></td><td>
Counts the number of blank cells within a range<br/><br/></td></tr>
<tr>
<td>
COUNTIF<br/><br/></td><td>
Counts the number of non-blank cells within a range that meet the given criteria<br/><br/></td></tr>
<tr>
<td>
COVAR<br/><br/></td><td>
Returns covariance, the average of the products of paired deviations<br/><br/></td></tr>
<tr>
<td>
CRITBINOM<br/><br/></td><td>
Returns the smallest value for which the cumulative binomial distribution is less than or equal to a criterion value<br/><br/></td></tr>
<tr>
<td>
CUMIPMT<br/><br/></td><td>
Returns the cumulative interest paid between two periods<br/><br/></td></tr>
<tr>
<td>
CUMPRINC<br/><br/></td><td>
Returns the cumulative principal paid on a loan between two periods<br/><br/></td></tr>
<tr>
<td>
DATE<br/><br/></td><td>
Returns the serial number of a particular date<br/><br/></td></tr>
<tr>
<td>
DATEVALUE<br/><br/></td><td>
Converts a date in the form of text to a serial number<br/><br/></td></tr>
<tr>
<td>
DAY<br/><br/></td><td>
Converts a serial number to a day of the month<br/><br/></td></tr>
<tr>
<td>
DAYS360<br/><br/></td><td>
Calculates the number of days between two dates based on a 360-day year<br/><br/></td></tr>
<tr>
<td>
DB<br/><br/></td><td>
Returns the depreciation of an asset for a specified period by using the fixed-declining balance method<br/><br/></td></tr>
<tr>
<td>
DDB<br/><br/></td><td>
Returns the depreciation of an asset for a specified period by using the double-declining balance method or some other method that you specify<br/><br/></td></tr>
<tr>
<td>
DEC2BIN<br/><br/></td><td>
Converts a decimal number to binary<br/><br/></td></tr>
<tr>
<td>
DECHEX<br/><br/></td><td>
Converts a decimal number to hexadecimal<br/><br/></td></tr>
<tr>
<td>
DEC2OCT<br/><br/></td><td>
Converts a decimal number to octal<br/><br/></td></tr>
<tr>
<td>
DEGREES<br/><br/></td><td>
Converts radians to degrees<br/><br/></td></tr>
<tr>
<td>
DELTA<br/><br/></td><td>
Tests whether two values are equal<br/><br/></td></tr>
<tr>
<td>
DEVSQ<br/><br/></td><td>
Returns the sum of squares of deviations<br/><br/></td></tr>
<tr>
<td>
DISC<br/><br/></td><td>
Returns the discount rate for a security<br/><br/></td></tr>
<tr>
<td>
DOLLAR<br/><br/></td><td>
Converts a number to text, using the $ (dollar) currency format<br/><br/></td></tr>
<tr>
<td>
DOLLARDE<br/><br/></td><td>
Converts a dollar price, expressed as a fraction, into a dollar price, expressed as a decimal number<br/><br/></td></tr>
<tr>
<td>
DOLLARFR<br/><br/></td><td>
Converts a dollar price, expressed as a decimal number, into a dollar price, expressed as a fraction<br/><br/></td></tr>
<tr>
<td>
DURATION<br/><br/></td><td>
Returns the annual duration of a security with periodic interest payments<br/><br/></td></tr>
<tr>
<td>
EDATE<br/><br/></td><td>
Returns the serial number of the date that is the indicated number of months before or after the start date<br/><br/></td></tr>
<tr>
<td>
EFFECT<br/><br/></td><td>
Returns the effective annual interest rate<br/><br/></td></tr>
<tr>
<td>
EOMONTH<br/><br/></td><td>
Returns the serial number of the last day of the month before or after a specified number of months<br/><br/></td></tr>
<tr>
<td>
ERF<br/><br/></td><td>
Returns the error function<br/><br/></td></tr>
<tr>
<td>
ERFC<br/><br/></td><td>
Returns the complementary error function<br/><br/></td></tr>
<tr>
<td>
ERROR.TYPE<br/><br/></td><td>
Returns a number corresponding to an error type<br/><br/></td></tr>
<tr>
<td>
EVEN<br/><br/></td><td>
Rounds a number up to the nearest even integer<br/><br/></td></tr>
<tr>
<td>
EXACT<br/><br/></td><td>
Checks to see if two text values are identical<br/><br/></td></tr>
<tr>
<td>
EXP<br/><br/></td><td>
Returns {{'__e__ '| markdownify }}raised to the power of a given number<br/><br/></td></tr>
<tr>
<td>
EXPONDIST<br/><br/></td><td>
Returns the exponential distribution<br/><br/></td></tr>
<tr>
<td>
FACT<br/><br/></td><td>
Returns the factorial of a number<br/><br/></td></tr>
<tr>
<td>
FACTDOUBLE<br/><br/></td><td>
Returns the double factorial of a number<br/><br/></td></tr>
<tr>
<td>
FDIST<br/><br/></td><td>
Returns the F probability distribution<br/><br/></td></tr>
<tr>
<td>
FIND, FINDB<br/><br/></td><td>
Finds one text value within another (case-sensitive)<br/><br/></td></tr>
<tr>
<td>
FINV<br/><br/></td><td>
Returns the inverse of the F probability distribution<br/><br/></td></tr>
<tr>
<td>
FISHER<br/><br/></td><td>
Returns the Fisher transformation<br/><br/></td></tr>
<tr>
<td>
FISHER<br/><br/></td><td>
Returns the inverse of the Fisher transformation<br/><br/></td></tr>
<tr>
<td>
FIXED<br/><br/></td><td>
Formats a number as text with a fixed number of decimals<br/><br/></td></tr>
<tr>
<td>
FLOOR<br/><br/></td><td>
Rounds a number down, toward zero<br/><br/></td></tr>
<tr>
<td>
FORECAST<br/><br/></td><td>
Returns a value along a linear trend<br/><br/></td></tr>
<tr>
<td>
FV<br/><br/></td><td>
Returns the future value of an investment<br/><br/></td></tr>
<tr>
<td>
FVSCHEDULE<br/><br/></td><td>
Returns the future value of an initial principal after applying a series of compound interest rates<br/><br/></td></tr>
<tr>
<td>
GAMMADIST<br/><br/></td><td>
Returns the gamma distribution<br/><br/></td></tr>
<tr>
<td>
GAMMAINV<br/><br/></td><td>
Returns the inverse of the gamma cumulative distribution<br/><br/></td></tr>
<tr>
<td>
GAMMALIN<br/><br/></td><td>
Returns the natural logarithm of the gamma function, Γ(x)<br/><br/></td></tr>
<tr>
<td>
GCD<br/><br/></td><td>
Returns the greatest common divisor<br/><br/></td></tr>
<tr>
<td>
GEOMEAN<br/><br/></td><td>
Returns the geometric mean<br/><br/></td></tr>
<tr>
<td>
GESTEP<br/><br/></td><td>
Tests whether a number is greater than a threshold value<br/><br/></td></tr>
<tr>
<td>
GROWTH<br/><br/></td><td>
Returns values along an exponential trend<br/><br/></td></tr>
<tr>
<td>
HARMEAN<br/><br/></td><td>
Returns the harmonic mean<br/><br/></td></tr>
<tr>
<td>
HEX2BIN<br/><br/></td><td>
Converts a hexadecimal number to binary<br/><br/></td></tr>
<tr>
<td>
HEX2DEC<br/><br/></td><td>
Converts a hexadecimal number to decimal<br/><br/></td></tr>
<tr>
<td>
HEX2OCT<br/><br/></td><td>
Converts a hexadecimal number to octal<br/><br/></td></tr>
<tr>
<td>
HLOOKUP<br/><br/></td><td>
Looks in the top row of an array and returns the value of the indicated cell<br/><br/></td></tr>
<tr>
<td>
HOUR<br/><br/></td><td>
Converts a serial number to an hour<br/><br/></td></tr>
<tr>
<td>
HYPERLINK<br/><br/></td><td>
Creates a shortcut or jump that opens a document stored on a network server, an intranet, or the Internet<br/><br/></td></tr>
<tr>
<td>
HYPGEOMDIST<br/><br/></td><td>
Returns the hypergeometric distribution<br/><br/></td></tr>
<tr>
<td>
IF<br/><br/></td><td>
Specifies a logical test to perform<br/><br/></td></tr>
<tr>
<td>
IFERROR<br/><br/></td><td>
Returns a specified value if a formula evaluates to an error.<br/><br/></td></tr>
<tr>
<td>
IFS<br/><br/></td><td>
Checks whether one or more conditions are met and returns a value that corresponds to the first TRUE condition<br/><br/></td></tr>
<tr>
<td>
IMABS<br/><br/></td><td>
Returns the absolute value (modulus) of a complex number<br/><br/></td></tr>
<tr>
<td>
IMAGINARY<br/><br/></td><td>
Returns the imaginary coefficient of a complex number<br/><br/></td></tr>
<tr>
<td>
IMARGUMENT<br/><br/></td><td>
Returns the argument theta, an angle expressed in radians<br/><br/></td></tr>
<tr>
<td>
IMCONJUGATE<br/><br/></td><td>
Returns the complex conjugate of a complex number<br/><br/></td></tr>
<tr>
<td>
IMCOS<br/><br/></td><td>
Returns the cosine of a complex number<br/><br/></td></tr>
<tr>
<td>
IMDIV<br/><br/></td><td>
Returns the quotient of two complex numbers<br/><br/></td></tr>
<tr>
<td>
IMEXP<br/><br/></td><td>
Returns the exponential of a complex number<br/><br/></td></tr>
<tr>
<td>
IMLN<br/><br/></td><td>
Returns the natural logarithm of a complex number<br/><br/></td></tr>
<tr>
<td>
IMLOG10<br/><br/></td><td>
Returns the base-10 logarithm of a complex number<br/><br/></td></tr>
<tr>
<td>
IMLOG2<br/><br/></td><td>
Returns the base-2 logarithm of a complex number<br/><br/></td></tr>
<tr>
<td>
IMPOWER<br/><br/></td><td>
Returns a complex number raised to an integer power<br/><br/></td></tr>
<tr>
<td>
IMPRODUCT<br/><br/></td><td>
Returns the product of from 2 to 29 complex numbers<br/><br/></td></tr>
<tr>
<td>
IMREAL<br/><br/></td><td>
Returns the real coefficient of a complex number<br/><br/></td></tr>
<tr>
<td>
IMSIN<br/><br/></td><td>
Returns the sine of a complex number<br/><br/></td></tr>
<tr>
<td>
IMSQRT<br/><br/></td><td>
Returns the square root of a complex number<br/><br/></td></tr>
<tr>
<td>
IMSUB<br/><br/></td><td>
Returns the difference between two complex numbers<br/><br/></td></tr>
<tr>
<td>
IMSUM<br/><br/></td><td>
Returns the sum of complex numbers<br/><br/></td></tr>
<tr>
<td>
INDEX<br/><br/></td><td>
Uses an index to choose a value from a reference or array<br/><br/></td></tr>
<tr>
<td>
INDIRECT<br/><br/></td><td>
Returns a reference indicated by a text value<br/><br/></td></tr>
<tr>
<td>
INFO<br/><br/></td><td>
Returns information about the current operating environment<br/><br/></td></tr>
<tr>
<td>
INT<br/><br/></td><td>
Rounds a number down to the nearest integer<br/><br/></td></tr>
<tr>
<td>
INTERCEPT<br/><br/></td><td>
Returns the intercept of the linear regression line<br/><br/></td></tr>
<tr>
<td>
INTRATE<br/><br/></td><td>
Returns the interest rate for a fully invested security<br/><br/></td></tr>
<tr>
<td>
IPMT<br/><br/></td><td>
Returns the interest payment for an investment for a given period<br/><br/></td></tr>
<tr>
<td>
IRR<br/><br/></td><td>
Returns the internal rate of return for a series of cash flows<br/><br/></td></tr>
<tr>
<td>
ISBLANK<br/><br/></td><td>
Returns TRUE if the value is blank<br/><br/></td></tr>
<tr>
<td>
ISERR<br/><br/></td><td>
Returns TRUE if the value is any error value except #N/A<br/><br/></td></tr>
<tr>
<td>
ISERROR<br/><br/></td><td>
Returns TRUE if the value is any error value<br/><br/></td></tr>
<tr>
<td>
ISEVEN<br/><br/></td><td>
Returns TRUE if the number is even<br/><br/></td></tr>
<tr>
<td>
ISLOGICAL<br/><br/></td><td>
Returns TRUE if the value is a logical value<br/><br/></td></tr>
<tr>
<td>
ISAN<br/><br/></td><td>
Returns TRUE if the value is the #N/A error value<br/><br/></td></tr>
<tr>
<td>
ISNONTEXT<br/><br/></td><td>
Returns TRUE if the value is not text<br/><br/></td></tr>
<tr>
<td>
ISNUMBER<br/><br/></td><td>
Returns TRUE if the value is a number<br/><br/></td></tr>
<tr>
<td>
ISODD<br/><br/></td><td>
Returns TRUE if the number is odd<br/><br/></td></tr>
<tr>
<td>
ISMPT<br/><br/></td><td>
Calculates the interest paid during a specific period of an investment<br/><br/></td></tr>
<tr>
<td>
ISREF<br/><br/></td><td>
Returns TRUE if the value is a reference<br/><br/></td></tr>
<tr>
<td>
ISTEXT<br/><br/></td><td>
Returns TRUE if the value is text<br/><br/></td></tr>
<tr>
<td>
KURT<br/><br/></td><td>
Returns the kurtosis of a data set<br/><br/></td></tr>
<tr>
<td>
LAMBDA <br/><br/></td><td>
Allows to use own formula parameters and logic<br/><br/></td></tr>
<tr>
<td>
LARGE<br/><br/></td><td>
Returns the k-th largest value in a data set<br/><br/></td></tr>
<tr>
<td>
LCM<br/><br/></td><td>
Returns the least common multiple<br/><br/></td></tr>
<tr>
<td>
LEFT, LEFTB<br/><br/></td><td>
Returns the leftmost characters from a text value<br/><br/></td></tr>
<tr>
<td>
LEN, LENB<br/><br/></td><td>
Returns the number of characters in a text string<br/><br/></td></tr>
<tr>
<td>
LET<br/><br/></td><td>
Returns the result of a formula that can use variables. Calculating this formula result is not supported in XlsIO<br/><br/></td></tr>
<tr>
<td>
LN<br/><br/></td><td>
Returns the natural logarithm of a number<br/><br/></td></tr>
<tr>
<td>
LOG<br/><br/></td><td>
Returns the logarithm of a number to a specified base<br/><br/></td></tr>
<tr>
<td>
LOG10<br/><br/></td><td>
Returns the base-10 logarithm of a number<br/><br/></td></tr>
<tr>
<td>
LOGEST<br/><br/></td><td>
Returns the parameters of an exponential trend<br/><br/></td></tr>
<tr>
<td>
LOGINV<br/><br/></td><td>
Returns the inverse of the log-normal distribution<br/><br/></td></tr>
<tr>
<td>
LOGNORMDIST<br/><br/></td><td>
Returns the cumulative log-normal distribution<br/><br/></td></tr>
<tr>
<td>
LOOKUP<br/><br/></td><td>
Looks up values in a vector or array<br/><br/></td></tr>
<tr>
<td>
LOWER<br/><br/></td><td>
Converts text to lowercase<br/><br/></td></tr>
<tr>
<td>
MATCH<br/><br/></td><td>
Looks up values in a reference or array<br/><br/></td></tr>
<tr>
<td>
MAX<br/><br/></td><td>
Returns the maximum value in a list of arguments<br/><br/></td></tr>
<tr>
<td>
MAXA<br/><br/></td><td>
Returns the maximum value in a list of arguments, including numbers, text, and logical values<br/><br/></td></tr>
<tr>
<td>
MAXIFS<br/><br/></td><td>
Returns the maximum value among cells specified by a given set of conditions or criteria<br/><br/></td></tr>
<tr>
<td>
MDETERM<br/><br/></td><td>
Returns the matrix determinant of an array<br/><br/></td></tr>
<tr>
<td>
MEDIAN<br/><br/></td><td>
Returns the median of the given numbers<br/><br/></td></tr>
<tr>
<td>
MID, MIDB<br/><br/></td><td>
Returns a specific number of characters from a text string starting at the position you specify<br/><br/></td></tr>
<tr>
<td>
MIN<br/><br/></td><td>
Returns the minimum value in a list of arguments<br/><br/></td></tr>
<tr>
<td>
MINA<br/><br/></td><td>
Returns the smallest value in a list of arguments, including numbers, text, and logical values<br/><br/></td></tr>
<tr>
<td>
MINIFS<br/><br/></td><td>
Returns the minimum value among cells specified by a given set of conditions or criteria<br/><br/></td></tr>
<tr>
<td>
MINUTE<br/><br/></td><td>
Converts a serial number to a minute<br/><br/></td></tr>
<tr>
<td>
MINVERSE<br/><br/></td><td>
Returns the matrix inverse of an array<br/><br/></td></tr>
<tr>
<td>
MIRR<br/><br/></td><td>
Returns the internal rate of return where positive and negative cash flows are financed at different rates<br/><br/></td></tr>
<tr>
<td>
MMULT<br/><br/></td><td>
Returns the matrix product of two arrays<br/><br/></td></tr>
<tr>
<td>
MOD<br/><br/></td><td>
Returns the remainder from division<br/><br/></td></tr>
<tr>
<td>
MODE<br/><br/></td><td>
Returns the most common value in a data set<br/><br/></td></tr>
<tr>
<td>
MMONTH<br/><br/></td><td>
Converts a serial number to a month<br/><br/></td></tr>
<tr>
<td>
MROUND<br/><br/></td><td>
Returns a number rounded to the desired multiple<br/><br/></td></tr>
<tr>
<td>
MULTINOMINAL<br/><br/></td><td>
Returns the multinomial of a set of numbers<br/><br/></td></tr>
<tr>
<td>
N<br/><br/></td><td>
Returns a value converted to a number<br/><br/></td></tr>
<tr>
<td>
NA<br/><br/></td><td>
Returns the error value #N/A<br/><br/></td></tr>
<tr>
<td>
NEGBINOMDIST<br/><br/></td><td>
Returns the negative binomial distribution<br/><br/></td></tr>
<tr>
<td>
NETWORKDAYS<br/><br/></td><td>
Returns the number of whole workdays between two dates<br/><br/></td></tr>
<tr>
<td>
NORMDIST<br/><br/></td><td>
Returns the normal cumulative distribution<br/><br/></td></tr>
<tr>
<td>
NORMINV<br/><br/></td><td>
Returns the inverse of the normal cumulative distribution<br/><br/></td></tr>
<tr>
<td>
NORMSDIST<br/><br/></td><td>
Returns the standard normal cumulative distribution<br/><br/></td></tr>
<tr>
<td>
NORMSINV<br/><br/></td><td>
Returns the inverse of the standard normal cumulative distribution<br/><br/></td></tr>
<tr>
<td>
NOT<br/><br/></td><td>
Reverses the logic of its argument<br/><br/></td></tr>
<tr>
<td>
NOW<br/><br/></td><td>
Returns the serial number of the current date and time<br/><br/></td></tr>
<tr>
<td>
NPER<br/><br/></td><td>
Returns the number of periods for an investment<br/><br/></td></tr>
<tr>
<td>
NPV<br/><br/></td><td>
Returns the net present value of an investment based on a series of periodic cash flows and a discount rate<br/><br/></td></tr>
<tr>
<td>
OCT2BIN<br/><br/></td><td>
Converts an octal number to binary<br/><br/></td></tr>
<tr>
<td>
OCT2DEC<br/><br/></td><td>
Converts an octal number to decimal<br/><br/></td></tr>
<tr>
<td>
OCT2HEX<br/><br/></td><td>
Converts an octal number to hexadecimal<br/><br/></td></tr>
<tr>
<td>
ODD<br/><br/></td><td>
Rounds a number up to the nearest odd integer<br/><br/></td></tr>
<tr>
<td>
OFFSET<br/><br/></td><td>
Returns a reference offset from a given reference<br/><br/></td></tr>
<tr>
<td>
OR<br/><br/></td><td>
Returns TRUE if any argument is TRUE<br/><br/></td></tr>
<tr>
<td>
PEARSON<br/><br/></td><td>
Returns the Pearson product moment correlation coefficient<br/><br/></td></tr>
<tr>
<td>
PERCENTILE<br/><br/></td><td>
Returns the k-th percentile of values in a range<br/><br/></td></tr>
<tr>
<td>
PERCENTRANK<br/><br/></td><td>
Returns the percentage rank of a value in a data set<br/><br/></td></tr>
<tr>
<td>
PERMUT<br/><br/></td><td>
Returns the number of permutations for a given number of objects<br/><br/></td></tr>
<tr>
<td>
PI<br/><br/></td><td>
Returns the value of pi<br/><br/></td></tr>
<tr>
<td>
PMT<br/><br/></td><td>
Returns the periodic payment for an annuity<br/><br/></td></tr>
<tr>
<td>
POISSON<br/><br/></td><td>
Returns the Poisson distribution<br/><br/></td></tr>
<tr>
<td>
POWER<br/><br/></td><td>
Returns the result of a number raised to a power<br/><br/></td></tr>
<tr>
<td>
PPMT<br/><br/></td><td>
Returns the payment on the principal for an investment for a given period<br/><br/></td></tr>
<tr>
<td>
PROB<br/><br/></td><td>
Returns the probability that values in a range are between two limits<br/><br/></td></tr>
<tr>
<td>
PRODUCT<br/><br/></td><td>
Multiplies its arguments<br/><br/></td></tr>
<tr>
<td>
PROPER<br/><br/></td><td>
Capitalizes the first letter in each word of a text value<br/><br/></td></tr>
<tr>
<td>
PV<br/><br/></td><td>
Returns the present value of an investment<br/><br/></td></tr>
<tr>
<td>
QUARTILE<br/><br/></td><td>
Returns the quartile of a data set<br/><br/></td></tr>
<tr>
<td>
QUOTIENT<br/><br/></td><td>
Returns the integer portion of a division<br/><br/></td></tr>
<tr>
<td>
RADIANS<br/><br/></td><td>
Converts degrees to radians<br/><br/></td></tr>
<tr>
<td>
RAND<br/><br/></td><td>
Returns a random number between 0 and 1<br/><br/></td></tr>
<tr>
<td>
RANDBETWEEN<br/><br/></td><td>
Returns a random number between the numbers you specify<br/><br/></td></tr>
<tr>
<td>
RANK<br/><br/></td><td>
Returns the rank of a number in a list of numbers<br/><br/></td></tr>
<tr>
<td>
RATE<br/><br/></td><td>
Returns the interest rate per period of an annuity<br/><br/></td></tr>
<tr>
<td>
RECEIVED<br/><br/></td><td>
Returns the amount received at maturity for a fully invested security<br/><br/></td></tr>
<tr>
<td>
REPLACE, REPLACEB<br/><br/></td><td>
Replaces characters within text<br/><br/></td></tr>
<tr>
<td>
REPT<br/><br/></td><td>
Repeats text a given number of times<br/><br/></td></tr>
<tr>
<td>
RIGHT, RIGHTB<br/><br/></td><td>
Returns the rightmost characters from a text value<br/><br/></td></tr>
<tr>
<td>
ROMAN<br/><br/></td><td>
Converts an Arabic numeral to roman, as text<br/><br/></td></tr>
<tr>
<td>
ROUND<br/><br/></td><td>
Rounds a number to a specified number of digits<br/><br/></td></tr>
<tr>
<td>
ROUNDDOWN<br/><br/></td><td>
Rounds a number down, toward zero<br/><br/></td></tr>
<tr>
<td>
ROUNDUP<br/><br/></td><td>
Rounds a number up, away from zero<br/><br/></td></tr>
<tr>
<td>
ROW<br/><br/></td><td>
Returns the row number of a reference<br/><br/></td></tr>
<tr>
<td>
ROWS<br/><br/></td><td>
Returns the number of rows in a reference<br/><br/></td></tr>
<tr>
<td>
RSQ<br/><br/></td><td>
Returns the square of the Pearson product moment correlation coefficient<br/><br/></td></tr>
<tr>
<td>
SEARCH, SEARCHB<br/><br/></td><td>
Finds one text value within another (not case-sensitive)<br/><br/></td></tr>
<tr>
<td>
SECOND<br/><br/></td><td>
Converts a serial number to a second<br/><br/></td></tr>
<tr>
<td>
SERIESSUM<br/><br/></td><td>
Returns the sum of a power series based on the formula<br/><br/></td></tr>
<tr>
<td>
SIGN<br/><br/></td><td>
Returns the sign of a number<br/><br/></td></tr>
<tr>
<td>
SIN<br/><br/></td><td>
Returns the sine of the given angle<br/><br/></td></tr>
<tr>
<td>
SINH<br/><br/></td><td>
Returns the hyperbolic sine of a number<br/><br/></td></tr>
<tr>
<td>
SKEW<br/><br/></td><td>
Returns the skewness of a distribution<br/><br/></td></tr>
<tr>
<td>
SLN<br/><br/></td><td>
Returns the straight-line depreciation of an asset for one period<br/><br/></td></tr>
<tr>
<td>
SLOPE<br/><br/></td><td>
Returns the slope of the linear regression line<br/><br/></td></tr>
<tr>
<td>
SORT<br/><br/></td><td>
Returns the cell range values in ascending or descending order<br/><br/></td></tr>
<tr>
<td>
SMALL<br/><br/></td><td>
Returns the k-th smallest value in a data set<br/><br/></td></tr>
<tr>
<td>
SQRT<br/><br/></td><td>
Returns a positive square root<br/><br/></td></tr>
<tr>
<td>
SQRTPI<br/><br/></td><td>
Returns the square root of (number * pi)<br/><br/></td></tr>
<tr>
<td>
STANDARDIZE<br/><br/></td><td>
Returns a normalized value<br/><br/></td></tr>
<tr>
<td>
STDEV<br/><br/></td><td>
Estimates standard deviation based on a sample<br/><br/></td></tr>
<tr>
<td>
STDEVA<br/><br/></td><td>
Estimates standard deviation based on a sample, including numbers, text, and logical values<br/><br/></td></tr>
<tr>
<td>
STDEVP<br/><br/></td><td>
Calculates standard deviation based on the entire population<br/><br/></td></tr>
<tr>
<td>
STDEVPA<br/><br/></td><td>
Calculates standard deviation based on the entire population, including numbers, text, and logical values<br/><br/></td></tr>
<tr>
<td>
STEYX<br/><br/></td><td>
Returns the standard error of the predicted y-value for each x in the regression<br/><br/></td></tr>
<tr>
<td>
SUBSTITUTE<br/><br/></td><td>
Substitutes new text for old text in a text string<br/><br/></td></tr>
<tr>
<td>
SUBTOTAL<br/><br/></td><td>
Returns a subtotal in a list or database<br/><br/></td></tr>
<tr>
<td>
SUM<br/><br/></td><td>
Adds its arguments<br/><br/></td></tr>
<tr>
<td>
SUMIF<br/><br/></td><td>
Adds the cells specified by a given criteria<br/><br/></td></tr>
<tr>
<td>
SUMPRODUCT<br/><br/></td><td>
Returns the sum of the products of corresponding array components<br/><br/></td></tr>
<tr>
<td>
SUMSQ<br/><br/></td><td>
Returns the sum of the squares of the arguments<br/><br/></td></tr>
<tr>
<td>
SUMX2MY2<br/><br/></td><td>
Returns the sum of the difference of squares of corresponding values in two arrays<br/><br/></td></tr>
<tr>
<td>
SUMX2PY2<br/><br/></td><td>
Returns the sum of the sum of squares of corresponding values in two arrays<br/><br/></td></tr>
<tr>
<td>
SUMXMY2<br/><br/></td><td>
Returns the sum of squares of differences of corresponding values in two arrays<br/><br/></td></tr>
<tr>
<td>
SWITCH<br/><br/></td><td>
Evaluates an expression against a list of values and returns the result corresponding to the first matching value. If there is no match, an optional default value may be returned.<br/><br/></td></tr>
<tr>
<td>
SYD<br/><br/></td><td>
Returns the sum-of-years'digits depreciation of an asset for a specified period<br/><br/></td></tr>
<tr>
<td>
T<br/><br/></td><td>
Converts its arguments to text<br/><br/></td></tr>
<tr>
<td>
TAN<br/><br/></td><td>
Returns the tangent of a number<br/><br/></td></tr>
<tr>
<td>
TANH<br/><br/></td><td>
Returns the hyperbolic tangent of a number<br/><br/></td></tr>
<tr>
<td>
TEXT<br/><br/></td><td>
Formats a number and converts it to text<br/><br/></td></tr>
<tr>
<td>
TEXTBEFORE<br/><br/></td><td>
Returns text that occurs before a given character<br/><br/></td></tr>
<tr>
<td>
TEXTJOIN<br/><br/></td><td>
Combines the text from multiple ranges and/or strings with a delimiter you specify between each text value that will be combined<br/><br/></td></tr>
<tr>
<td>
TEXTSPLIT<br/><br/></td><td>
Splits the cell text across rows or columns<br/><br/></td></tr>
<tr>
<td>
TIME<br/><br/></td><td>
Returns the serial number of a particular time<br/><br/></td></tr>
<tr>
<td>
TIMEVALUE<br/><br/></td><td>
Converts a time in the form of text to a serial number<br/><br/></td></tr>
<tr>
<td>
TOCOL<br/><br/></td><td>
Transforms an array into a single column<br/><br/></td></tr>
<tr>
<td>
TODAY<br/><br/></td><td>
Returns the serial number of today's date<br/><br/></td></tr>
<tr>
<td>
TOROW<br/><br/></td><td>
Transforms an array into a single row<br/><br/></td></tr>
<tr>
<td>
TRANSPORSE<br/><br/></td><td>
Returns the transpose of an array<br/><br/></td></tr>
<tr>
<td>
TRIM<br/><br/></td><td>
Removes spaces from text<br/><br/></td></tr>
<tr>
<td>
TRIMMEAN<br/><br/></td><td>
Returns the mean of the interior of a data set<br/><br/></td></tr>
<tr>
<td>
TRUNC<br/><br/></td><td>
Truncates a number to an integer<br/><br/></td></tr>
<tr>
<td>
TYPE<br/><br/></td><td>
Returns a number indicating the data type of a value<br/><br/></td></tr>
<tr>
<td>
UNIQUE<br/><br/></td><td>
Returns the list of unique values present inside a list or range. Calculating the formula result in XlsIO is not supported. <br/><br/></td></tr>
<tr>
<td>
UPPER<br/><br/></td><td>
Converts text to uppercase<br/><br/></td></tr>
<tr>
<td>
VALUE<br/><br/></td><td>
Converts a text argument to a number<br/><br/></td></tr>
<tr>
<td>
VALUETOTEXT<br/><br/></td><td>
Returns the text from any specified value. Calculating this formula result is not supported in XlsIO.<br/><br/></td></tr>
<tr>
<td>
VAR<br/><br/></td><td>
Estimates variance based on a sample<br/><br/></td></tr>
<tr>
<td>
VARA<br/><br/></td><td>
Estimates variance based on a sample, including numbers, text, and logical values<br/><br/></td></tr>
<tr>
<td>
VARP<br/><br/></td><td>
Calculates variance based on the entire population<br/><br/></td></tr>
<tr>
<td>
VARPA<br/><br/></td><td>
Calculates variance based on the entire population, including numbers, text, and logical values<br/><br/></td></tr>
<tr>
<td>
VDB<br/><br/></td><td>
Returns the depreciation of an asset for a specified or partial period by using a declining balance method<br/><br/></td></tr>
<tr>
<td>
VLOOKUP<br/><br/></td><td>
Looks in the first column of an array and moves across the row to return the value of a cell<br/><br/></td></tr>
<tr>
<td>
WEEKDAY<br/><br/></td><td>
Converts a serial number to a day of the week<br/><br/></td></tr>
<tr>
<td>
WEEKNUM<br/><br/></td><td>
Converts a serial number to a number representing where the week falls numerically with a year<br/><br/></td></tr>
<tr>
<td>
WEIBULL<br/><br/></td><td>
Returns the Weibull distribution<br/><br/></td></tr>
<tr>
<td>
WORKDAY<br/><br/></td><td>
Returns the serial number of the date before or after a specified number of workdays<br/><br/></td></tr>
<tr>
<td>
XIRR<br/><br/></td><td>
Returns the internal rate of return for a schedule of cash flows that is not necessarily periodic<br/><br/></td></tr>
<tr>
<td>
XLOOKUP<br/><br/></td><td>
Returns the value corresponding to the first match it finds else returns the next approximate match. Calculating this formula result is not supported in XlsIO.<br/><br/></td></tr>
<tr>
<td>
XMATCH<br/><br/></td><td>
Returns the position of a value in a list, table or cell range. Calculating this formula result is not supported in XlsIO.<br/><br/></td></tr>
<tr>
<td>
YEAR<br/><br/></td><td>
Converts a serial number to a year<br/><br/></td></tr>
<tr>
<td>
YEARFRAC<br/><br/></td><td>
Returns the year fraction representing the number of whole days between start_date and end_date<br/><br/></td></tr>
<tr>
<td>
ZTEST<br/><br/></td><td>
Returns the one-tailed probability-value of a z-test<br/><br/></td></tr>
<tr>
<td>
FALSE<br/><br/></td><td>
Returns the logical value FALSE<br/><br/></td></tr>
<tr>
<td>
TRUE<br/><br/></td><td>
Returns the logical value TRUE<br/><br/></td></tr>
</tbody>
</table>
