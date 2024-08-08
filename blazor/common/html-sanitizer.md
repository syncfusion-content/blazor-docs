---
layout: post
title: HTML Santizer in Blazor - Syncfusion
description: Check out the documentation for HTML sanitizer uses and supported Blazor components with equivalent properties
platform: Blazor
component: Common
documentation: ug
---

# HTML Sanitizer

An HTML sanitizer is a tool or program that helps remove potentially malicious or harmful code from HTML documents. This type of sanitizer is commonly used in web applications to prevent cross-site scripting (XSS) attacks, which can inject malicious code into a website and compromise user data. HTML sanitizers typically work by analyzing HTML code and removing any potentially dangerous or unwanted elements, such as script tags, inline styles, or event handlers. Other aspects of the HTML may also be modified or cleaned up, such as removing extra whitespace or fixing malformed code.

Our Syncfusion input components are sanitized using the htmlSanitizer helper method to reduce the possibility of code injection. This ensures that HTML strings submitted by users are sanitized, enhancing security measures against potential threats.

 If we provide the html string in syncfusion input component, the HTML string undergoes a thorough sanitization process before being rendered in the component. This approach ensures that user inputs containing potential security threats are meticulously filtered, addressing the risk of XSS and contributing to the overall security robustness of our components in the face of potential attacks.

 ## Content may not be preserved

 Even if no elements or attributes were removed, you cannot expect the text content to preserved exactly as it was input because the supplied input value has been parsed by the Syncfusion HTML Santizer parser and then rendered back out.

 - 1 > 3 becomes 4 &gt; 5
 - 5 > 9 becomes 5 &gt; 9
 - <IMG SRC=javascript:alert('XSS')> becomes <img>
 - <SPAN>test</p> becomes <span>test</span>
 - <span title='test'>test</span> becomes <span title="test">test</span>
 
