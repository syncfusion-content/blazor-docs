---
layout: post
title: Styles and Appearances in Blazor QueryBuilder Component | Syncfusion
description: Checkout and learn here all about Styles and Appearances in Syncfusion Blazor QueryBuilder component and more.
platform: Blazor
control: QueryBuilder
documentation: ug
---

# Styles and Appearances in Blazor QueryBuilder Component

Customize the appearance of the Query Builder by overriding the component’s default CSS. The following table lists commonly used CSS selectors and the corresponding UI areas they affect. For consistent theming across applications, consider generating a custom theme with [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
| ----- | ----- |
| .e-query-builder .e-btn-group input + label.e-btn | Customize the condition button in the Query Builder. | 
| .e-query-builder .e-btn-group input:checked + label.e-btn | Customize the selected condition button in the Query Builder. |
| .e-query-builder .e-group-body .e-rule-container | Customize the Query Builder rule container. |
| .e-query-builder .e-group-action .e-btn | Customize the Query Builder Add Group/Add Condition buttons. |
| .e-query-builder .e-removerule.e-btn.e-round | Customize the Query Builder delete button. |
| .e-query-builder .e-rule-list > ::after, .e-query-builder .e-rule-list > ::before | Customize the Query Builder group joining line. |
| .e-query-builder .e-rule-container.e-joined-rule | Customize the Query Builder condition joining line. |