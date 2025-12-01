---
layout: post
title: Collaborative editing in Blazor Diagram Component | Syncfusion
description: Checkout and Learn all about collaborative editing in Syncfusion Blazor Diagram component and many more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Collaborative Editing in Blazor Diagram

Collaborative editing enables multiple users to work on the same diagram at the same time. Changes are reflected in real-time, allowing all participants to instantly see updates as they happen. This feature promotes seamless teamwork by eliminating the need to wait for others to finish their edits. As a result, teams can boost productivity, streamline workflows, and ensure everyone stays aligned throughout the design process.

## Prerequisites

- *Real-time Transport Protocol*: Enables instant communication between clients and the server, ensuring that updates during collaborative editing are transmitted and reflected immediately.
- *Distributed Cache or Database*: Serves as temporary storage for the queue of editing operations, helping maintain synchronization and consistency across multiple users.

### Real time transport protocol

- *Managing Connections*: Maintains active connections between clients and the server to enable uninterrupted real-time collaboration. This ensures smooth and consistent communication throughout the editing session.
- *Broadcasting Changes*: Instantly propagates any edits made by one user to all other collaborators. This guarantees that everyone is always working on the most up-to-date version of the diagram, fostering accuracy and teamwork.

### Distributed cache or database

Collaborative editing requires a reliable backing system to temporarily store and manage editing operations from all active users. This ensures real-time synchronization and conflict resolution across multiple clients. There are two primary options:

- *Distributed Cache*: 
    * Designed for high throughput and low latency.
    * Handles significantly more HTTP requests per second compared to a database.
    * Example: A server with 2 vCPUs and 8 GB RAM can process up to 125 requests per second using a distributed cache.

- *Database*: 
    * Suitable for smaller-scale collaboration scenarios.
    * With the same server configuration, a database can handle approximately 50 requests per second.

> *Recommendation*:
    * If your application expects 50 or fewer requests per second, a database provides a reliable solution for managing the operation queue.
    * If your application expects more than 50 requests per second, a distributed cache is highly recommended for optimal performance.

> Tips to calculate the average requests per second of your application:
Assume the editor in your live application is actively used by 1000 users and each user's edit can trigger 2 to 5 requests per second. The total requests per second of your applications will be around 2000 to 5000. In this case, you can finalize a configuration to support around 5000 average requests per second.

> Note: The metrics provided are for illustration purposes only. Actual throughput may vary based on additional server-side operations. It is strongly recommended to monitor your application’s traffic and performance and select a configuration that best meets your real-world requirements.
