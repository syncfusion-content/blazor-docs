---
layout: post
title: Localization in Blazor DataForm Component | Syncfusion
description: Checkout and learn here about how to localize the label text and error messages in Blazor DataForm component.
platform: Blazor
control: DataForm
documentation: ug
---

# Localization in Blazor DataForm component

DataForm component can be localized to any particular culture. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

## Configuring localization for label text and error messages

Follow the below steps to configure localization for label text and error messages in Blazor DataForm component.

1.After integrating the localization files in your application as mentioned in the [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) section ,Open the required culture file in the Visual Studio.

![Localization step-1](./images/blazor_dataform_localization_step.png)


2.In the opened file click on `Add Resource` button and include the suitable key with the corresponding localized text as like below.


![Localization step-1](./images/blazor_dataform_localization_step1.png)

3.Then, include the [ResourceType](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute.resourcetype?view=net-8.0#system-componentmodel-dataannotations-displayattribute-resourcetype) which we have formed under `Resources` folder and key for the localized text within the [Display](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.displayattribute?view=net-8.0) attribute of the corresponding property in the model class.Similarly you can localize the error messages in the DataForm component by including the [ErrorMessageResourceType](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute.errormessageresourcetype?view=net-8.0#system-componentmodel-dataannotations-validationattribute-errormessageresourcetype) and [ErrorMessageResourceName](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.validationattribute.errormessageresourcename?view=net-8.0#system-componentmodel-dataannotations-validationattribute-errormessageresourcename) properties within the [Required](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations.requiredattribute?view=net-8.0) attribute of the corresponding property in the model class as mentioned in the below code snippet.

| ![Localization step 3](./images/blazor_dataform_localization_step3.png) | ![Localization step 3](./images/blazor_dataform_localization_step3_2.png) |

{% tabs %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/localization/localization.razor %}

{% endhighlight %}
{% highlight razor tabtitle="Razor"  %}

{% include_relative code-snippet/localization/localization.razor %}

{% endhighlight %}
{% endtabs %}

4.Finally, run the application to view the localized DataForm component.

![Localization in DataForm component](./images/blazor_dataform_localization.png)
