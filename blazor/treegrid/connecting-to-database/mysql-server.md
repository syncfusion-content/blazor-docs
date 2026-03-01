---
layout: post
title: Blazor Tree Grid connected to MySQL via Entity Framework | Syncfusion
description: Bind MySQL data to Blazor Tree Grid using Entity Framework Core with complete CRUD, filtering, sorting, paging, and advanced data operations.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Connecting MySQL Server to Blazor Tree Grid Using Entity Framework

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) supports binding data from a MySQL Server database using Entity Framework Core (EF Core). This modern approach provides a more maintainable and type-safe alternative to raw SQL queries.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is a software tool that simplifies database operations in .NET applications. It serves as a bridge between C# code and databases like MySQL.

**Key Benefits of Entity Framework Core**

- **Automatic SQL Generation**: Entity Framework Core generates optimized SQL queries automatically, eliminating the need to write raw SQL code.
- **Type Safety**: Work with strongly-typed objects instead of raw SQL strings, reducing errors.
- **Built-in Security**: Automatic parameterization prevents SQL injection attacks.
- **Version Control for Databases**: Manage database schema changes version-by-version through migrations.
- **Familiar Syntax**: Use LINQ (Language Integrated Query) syntax, which is more intuitive than raw SQL strings.

**What is Pomelo MySQL?**

**Pomelo MySQL** is a software library that helps .NET applications work with a MySQL database using Entity Framework Core. It acts as a bridge between Entity Framework Core and MySQL, allowing applications to read, write, update, and delete data in a MySQL database.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| MySQL Server | 8.0.41 or later | Database server |
| Syncfusion.Blazor.Grids | {{site.blazorversion}} | DataGrid and UI components |
| Syncfusion.Blazor.TreeGrid | {{site.blazorversion}} | TreeGrid and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for TreeGrid component |
| Microsoft.EntityFrameworkCore | 9.0.0 or later | Core framework for database operations |
| Microsoft.EntityFrameworkCore.Tools | 9.0.0 or later | Tools for managing database migrations |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0 or later | MySQL provider for Entity Framework Core |

## Setting Up the MySQL Environment for Entity Framework Core

### Step 1: Create the database and Table in MySQL server

First, the **MySQL database** structure must be created to store transaction records.

**Instructions:**
1. Open MySQL Workbench or any MySQL client.
2. Create a new database named `transactiondb`.
3. Define a `transactions` table with the specified schema.
4. Insert sample data for testing.

Run the following SQL script:

```sql
-- Create table
CREATE TABLE IF NOT EXISTS support_tickets (
  TicketID INT AUTO_INCREMENT PRIMARY KEY,
  Title VARCHAR(255) NOT NULL,
  ParentTicketID INT NULL,
  Category VARCHAR(100),
  Priority VARCHAR(50),
  Status VARCHAR(50),
  AssignedAgent VARCHAR(100),
  CustomerName VARCHAR(200),
  CreatedDate DATETIME,
  DueDate DATETIME,
  EstimatedHours DECIMAL(6,2),
  Description TEXT,
  HasChildren BOOLEAN DEFAULT FALSE
);

-- Insert data (uses NOW() with DATE_ADD / DATE_SUB to mirror the C# DateTime offsets)
INSERT INTO support_tickets
  (TicketID, Title, ParentTicketID, Category, Priority, Status, AssignedAgent, CustomerName, CreatedDate, DueDate, EstimatedHours, Description, HasChildren)
VALUES
(57301, 'Server Infrastructure Issues', NULL, 'Technical', 'High', 'In Progress', 'Alex Rivera', 'Zorath Industries', DATE_SUB(NOW(), INTERVAL 15 DAY), DATE_ADD(NOW(), INTERVAL -1 HOUR), 16.00, 'Server Infrastructure Issues',true),
(57302, 'Email Service Down', 57301, 'Technical', 'Critical', 'Open', 'Alex Rivera', 'Zorath Industries', DATE_SUB(NOW(), INTERVAL 12 DAY), DATE_ADD(NOW(), INTERVAL 2 HOUR), 4.00, 'The email service has stopped functioning, impacting communication across the organization.', false),
(57303, 'Database Connection Issues', 57301, 'Technical', 'High', 'In Progress', 'Jordan Lee', 'Zorath Industries', DATE_SUB(NOW(), INTERVAL 11 DAY), DATE_ADD(NOW(), INTERVAL 6 HOUR), 8.00, 'Users experiencing intermittent errors when connecting to the primary database server.', false),
(57304, 'Load Balancer Configuration', 57301, 'Technical', 'Medium', 'Resolved', 'Alex Rivera', 'Zorath Industries', DATE_SUB(NOW(), INTERVAL 10 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 6.00, 'Misconfigured load balancer causing uneven distribution of incoming traffic.', false),
(57305, 'DNS Resolution Problems', 57301, 'Technical', 'High', 'Open', 'Casey Kim', 'Zorath Industries', DATE_SUB(NOW(), INTERVAL 9 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 5.00, 'DNS servers failing to resolve domain names, resulting in website access issues.', false),
(57306, 'CDN Performance Issues', 57301, 'Technical', 'Medium', 'In Progress', 'Taylor Morgan', 'Zorath Industries', DATE_SUB(NOW(), INTERVAL 8 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 10.00, 'Increased latency in the content delivery network, slowing down page load times.', false),
(57307, 'Application Bug Reports', NULL, 'Software', 'Medium', 'Open', 'Casey Kim', 'Keldrix Systems', DATE_SUB(NOW(), INTERVAL 14 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 12.00, 'Application Bug Reports',true),
(57308, 'Login Authentication Error', 57307, 'Software', 'High', 'Escalated', 'Casey Kim', 'Keldrix Systems', DATE_SUB(NOW(), INTERVAL 13 DAY), DATE_ADD(NOW(), INTERVAL 4 HOUR), 6.00, 'Users unable to authenticate due to token mismatch during login process.', false),
(57309, 'Data Export Functionality', 57307, 'Software', 'Low', 'Open', 'Taylor Morgan', 'Keldrix Systems', DATE_SUB(NOW(), INTERVAL 12 DAY), DATE_ADD(NOW(), INTERVAL 3 DAY), 4.00, 'Export feature failing to generate accurate CSV files with all data.', false),
(57310, 'UI Rendering Issues', 57307, 'Software', 'Medium', 'In Progress', 'Casey Kim', 'Keldrix Systems', DATE_SUB(NOW(), INTERVAL 11 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 8.00, 'UI elements not rendering correctly on the latest browser versions.', false),
(57311, 'API Integration Problems', 57307, 'Software', 'Critical', 'Open', 'Riley Patel', 'Keldrix Systems', DATE_SUB(NOW(), INTERVAL 10 DAY), DATE_ADD(NOW(), INTERVAL 12 HOUR), 15.00, 'External API calls returning internal server errors (500).', false),
(57312, 'File Upload Memory Leak', 57307, 'Software', 'High', 'In Progress', 'Jordan Lee', 'Keldrix Systems', DATE_SUB(NOW(), INTERVAL 9 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 12.00, 'Memory usage spikes after multiple file uploads, leading to crashes.', false),
(57313, 'Session Timeout Bug', 57307, 'Software', 'Medium', 'Resolved', 'Taylor Morgan', 'Keldrix Systems', DATE_SUB(NOW(), INTERVAL 8 DAY), DATE_ADD(NOW(), INTERVAL 3 DAY), 7.00, 'User sessions expiring too early, causing unexpected logouts.', false),
(57314, 'Network Connectivity Problems', NULL, 'Network', 'Medium', 'Open', 'Riley Patel', 'Quorvex Networks', DATE_SUB(NOW(), INTERVAL 13 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 8.00, 'Network Connectivity Problems',true),
(57315, 'VPN Connection Timeout', 57314, 'Network', 'Medium', 'In Progress', 'Riley Patel', 'Quorvex Networks', DATE_SUB(NOW(), INTERVAL 12 DAY), DATE_ADD(NOW(), INTERVAL 8 HOUR), 3.00, 'VPN sessions dropping after short periods of inactivity.', false),
(57316, 'Firewall Configuration', 57314, 'Network', 'Low', 'Resolved', 'Alex Rivera', 'Quorvex Networks', DATE_SUB(NOW(), INTERVAL 11 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 2.00, 'Firewall rules incorrectly blocking HTTPS traffic.', false),
(57317, 'WiFi Access Point Issues', 57314, 'Network', 'High', 'Open', 'Riley Patel', 'Quorvex Networks', DATE_SUB(NOW(), INTERVAL 10 DAY), DATE_ADD(NOW(), INTERVAL 12 HOUR), 4.00, 'Several WiFi access points in the office are offline.', false),
(57318, 'Router Configuration Error', 57314, 'Network', 'Critical', 'Escalated', 'Casey Kim', 'Quorvex Networks', DATE_SUB(NOW(), INTERVAL 9 DAY), DATE_ADD(NOW(), INTERVAL 6 HOUR), 8.00, 'Router setup error creating network loops and instability.', false),
(57319, 'Bandwidth Optimization', 57314, 'Network', 'Medium', 'In Progress', 'Jordan Lee', 'Quorvex Networks', DATE_SUB(NOW(), INTERVAL 8 DAY), DATE_ADD(NOW(), INTERVAL 4 DAY), 6.00, 'Adjust bandwidth allocation to prioritize VoIP and video calls.', false),
(57320, 'User Training Requests', NULL, 'Support', 'Low', 'Open', 'Jordan Lee', 'Mirath News', DATE_SUB(NOW(), INTERVAL 12 DAY), DATE_ADD(NOW(), INTERVAL 5 DAY), 20.00, 'User Training Requests', true),
(57321, 'Password Reset Issues', 57320, 'Support', 'Medium', 'Resolved', 'Jordan Lee', 'Mirath News', DATE_SUB(NOW(), INTERVAL 11 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 1.00, 'Password reset emails not arriving in user inboxes.', false),
(57322, 'Feature Request Training', 57320, 'Support', 'Low', 'Open', 'Taylor Morgan', 'Mirath News', DATE_SUB(NOW(), INTERVAL 10 DAY), DATE_ADD(NOW(), INTERVAL 7 DAY), 8.00, 'Schedule training for the new analytics reporting features.', false),
(57323, 'New Employee Onboarding', 57320, 'Support', 'Medium', 'In Progress', 'Jordan Lee', 'Mirath News', DATE_SUB(NOW(), INTERVAL 9 DAY), DATE_ADD(NOW(), INTERVAL 3 DAY), 12.00, 'Onboarding for new hires delayed by access provisioning problems.', false),
(57324, 'System Access Training', 57320, 'Support', 'Low', 'Open', 'Riley Patel', 'Mirath News', DATE_SUB(NOW(), INTERVAL 8 DAY), DATE_ADD(NOW(), INTERVAL 5 DAY), 4.00, 'Provide training on secure system access for remote employees.', false),
(57325, 'Advanced Features Workshop', 57320, 'Support', 'Medium', 'In Progress', 'Casey Kim', 'Mirath News', DATE_SUB(NOW(), INTERVAL 7 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 16.00, 'Conduct workshop on advanced customization of dashboards.', false),
(57326, 'Hardware Maintenance', NULL, 'Hardware', 'Medium', 'Open', 'Casey Kim', 'Fluxor Hardware', DATE_SUB(NOW(), INTERVAL 11 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 16.00, 'Hardware Maintenance',true),
(57327, 'Printer Configuration', 57326, 'Hardware', 'Low', 'Open', 'Riley Patel', 'Fluxor Hardware', DATE_SUB(NOW(), INTERVAL 10 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 2.00, 'Network printers failing to accept print jobs from workstations.', false),
(57328, 'Server Memory Upgrade', 57326, 'Hardware', 'High', 'In Progress', 'Casey Kim', 'Fluxor Hardware', DATE_SUB(NOW(), INTERVAL 9 DAY), DATE_ADD(NOW(), INTERVAL 12 HOUR), 8.00, 'Upgrade server RAM capacity from 64GB to 128GB for better performance.', false),
(57329, 'Workstation Replacement', 57326, 'Hardware', 'Medium', 'Closed', 'Taylor Morgan', 'Fluxor Hardware', DATE_SUB(NOW(), INTERVAL 8 DAY), DATE_ADD(NOW(), INTERVAL 4 DAY), 6.00, 'Replace aging workstations for the development team.', false),
(57330, 'UPS Battery Replacement', 57326, 'Hardware', 'High', 'Open', 'Alex Rivera', 'Fluxor Hardware', DATE_SUB(NOW(), INTERVAL 7 DAY), DATE_ADD(NOW(), INTERVAL 24 HOUR), 4.00, 'Replace aging batteries in UPS units to ensure power backup.', false),
(57331, 'Network Switch Upgrade', 57326, 'Hardware', 'Critical', 'In Progress', 'Jordan Lee', 'Fluxor Hardware', DATE_SUB(NOW(), INTERVAL 6 DAY), DATE_ADD(NOW(), INTERVAL 8 HOUR), 12.00, 'Upgrade to faster gigabit network switches.', false),
(57332, 'Monitor Calibration', 57326, 'Hardware', 'Low', 'Resolved', 'Riley Patel', 'Fluxor Hardware', DATE_SUB(NOW(), INTERVAL 5 DAY), DATE_ADD(NOW(), INTERVAL 3 DAY), 2.00, 'Calibrate monitors for accurate color representation in design work.', false),
(57333, 'Security Vulnerabilities', NULL, 'Security', 'Critical', 'Open', 'Alex Rivera', 'Lumithar Mobility', DATE_SUB(NOW(), INTERVAL 10 DAY), DATE_ADD(NOW(), INTERVAL 6 HOUR), 24.00, 'Security Vulnerabilities',true),
(57334, 'SSL Certificate Renewal', 57333, 'Security', 'High', 'In Progress', 'Jordan Lee', 'Lumithar Mobility', DATE_SUB(NOW(), INTERVAL 9 DAY), DATE_ADD(NOW(), INTERVAL 8 HOUR), 4.00, 'Renew expiring SSL certificates to maintain secure connections.', false),
(57335, 'Access Control Review', 57333, 'Security', 'Medium', 'Open', 'Casey Kim', 'Lumithar Mobility', DATE_SUB(NOW(), INTERVAL 8 DAY), DATE_ADD(NOW(), INTERVAL 5 DAY), 16.00, 'Conduct quarterly review of user access rights and permissions.', false),
(57336, 'Penetration Test Findings', 57333, 'Security', 'Critical', 'Escalated', 'Taylor Morgan', 'Lumithar Mobility', DATE_SUB(NOW(), INTERVAL 7 DAY), DATE_ADD(NOW(), INTERVAL 4 HOUR), 20.00, 'Remediate vulnerabilities discovered during penetration testing.', false),
(57337, 'Two-Factor Auth Setup', 57333, 'Security', 'High', 'In Progress', 'Riley Patel', 'Lumithar Mobility', DATE_SUB(NOW(), INTERVAL 6 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 8.00, 'Roll out two-factor authentication for administrative accounts.', false),
(57338, 'Compliance Audit Issues', 57333, 'Security', 'Medium', 'Open', 'Alex Rivera', 'Lumithar Mobility', DATE_SUB(NOW(), INTERVAL 5 DAY), DATE_ADD(NOW(), INTERVAL 7 DAY), 14.00, 'Address non-compliance items from the latest audit report.', false),
(57339, 'Performance Optimization', NULL, 'Performance', 'High', 'Open', 'Taylor Morgan', 'Thrylon Dynamics', DATE_SUB(NOW(), INTERVAL 9 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 20.00, 'Performance Optimization',true),
(57340, 'Query Optimization', 57339, 'Performance', 'High', 'In Progress', 'Riley Patel', 'Thrylon Dynamics', DATE_SUB(NOW(), INTERVAL 8 DAY), DATE_ADD(NOW(), INTERVAL 10 HOUR), 12.00, 'Identify and optimize slow-performing SQL queries in reports.', false),
(57341, 'Caching Implementation', 57339, 'Performance', 'Medium', 'Open', 'Taylor Morgan', 'Thrylon Dynamics', DATE_SUB(NOW(), INTERVAL 7 DAY), DATE_ADD(NOW(), INTERVAL 3 DAY), 8.00, 'Implement Redis-based caching for high-traffic data endpoints.', false),
(57342, 'Memory Usage Analysis', 57339, 'Performance', 'High', 'In Progress', 'Casey Kim', 'Thrylon Dynamics', DATE_SUB(NOW(), INTERVAL 6 DAY), DATE_ADD(NOW(), INTERVAL 16 HOUR), 15.00, 'Profile and reduce memory leaks in the Java application.', false),
(57343, 'Load Testing Setup', 57339, 'Performance', 'Medium', 'Open', 'Jordan Lee', 'Thrylon Dynamics', DATE_SUB(NOW(), INTERVAL 5 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 10.00, 'Configure JMeter environment for comprehensive load testing.', false),
(57344, 'CDN Configuration', 57339, 'Performance', 'Low', 'Resolved', 'Alex Rivera', 'Thrylon Dynamics', DATE_SUB(NOW(), INTERVAL 4 DAY), DATE_ADD(NOW(), INTERVAL 5 DAY), 6.00, 'Set up CDN for serving static assets to global users.', false),
(57345, 'Backup System Issues', NULL, 'Backup', 'High', 'Open', 'Alex Rivera', 'Resilvault Storage', DATE_SUB(NOW(), INTERVAL 8 DAY), DATE_ADD(NOW(), INTERVAL 4 HOUR), 14.00, 'Backup System Issues', true),
(57346, 'Daily Backup Failure', 57345, 'Backup', 'Critical', 'Escalated', 'Jordan Lee', 'Resilvault Storage', DATE_SUB(NOW(), INTERVAL 7 DAY), DATE_ADD(NOW(), INTERVAL 2 HOUR), 6.00, 'Automated daily backups failing due to insufficient disk space.', false),
(57347, 'Recovery Testing', 57345, 'Backup', 'Medium', 'Open', 'Casey Kim', 'Resilvault Storage', DATE_SUB(NOW(), INTERVAL 6 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 10.00, 'Perform quarterly testing of disaster recovery procedures.', false),
(57348, 'Backup Storage Expansion', 57345, 'Backup', 'High', 'In Progress', 'Taylor Morgan', 'Resilvault Storage', DATE_SUB(NOW(), INTERVAL 5 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 12.00, 'Increase backup storage capacity by an additional 50TB.', false),
(57349, 'Archive Policy Update', 57345, 'Backup', 'Medium', 'Open', 'Riley Patel', 'Resilvault Storage', DATE_SUB(NOW(), INTERVAL 4 DAY), DATE_ADD(NOW(), INTERVAL 3 DAY), 8.00, 'Revise data retention and archiving policies for compliance.', false),
(57350, 'Disaster Recovery Plan', 57345, 'Backup', 'Critical', 'In Progress', 'Alex Rivera', 'Resilvault Storage', DATE_SUB(NOW(), INTERVAL 3 DAY), DATE_ADD(NOW(), INTERVAL 12 HOUR), 20.00, 'Update the disaster recovery plan to include cloud migration steps.', false),
(57351, 'Mobile App Issues', NULL, 'Mobile', 'High', 'Open', 'Riley Patel', 'Vexarion Mobile', DATE_SUB(NOW(), INTERVAL 7 DAY), DATE_ADD(NOW(), INTERVAL 8 DAY), 16.00, 'Mobile App Issues', true),
(57352, 'iOS App Crashes', 57351, 'Mobile', 'Critical', 'Escalated', 'Jordan Lee', 'Vexarion Mobile', DATE_SUB(NOW(), INTERVAL 6 DAY), DATE_ADD(NOW(), INTERVAL 6 HOUR), 10.00, 'Frequent crashes on iOS 17 specifically at the login screen.', false),
(57353, 'Android Push Notifications', 57351, 'Mobile', 'Medium', 'In Progress', 'Casey Kim', 'Vexarion Mobile', DATE_SUB(NOW(), INTERVAL 5 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 8.00, 'Push notifications not being received on Android devices.', false),
(57354, 'App Store Deployment', 57351, 'Mobile', 'High', 'Open', 'Taylor Morgan', 'Vexarion Mobile', DATE_SUB(NOW(), INTERVAL 4 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 12.00, 'Prepare and deploy the latest app update to the App Store.', false),
(57355, 'Offline Sync Issues', 57351, 'Mobile', 'Medium', 'In Progress', 'Riley Patel', 'Vexarion Mobile', DATE_SUB(NOW(), INTERVAL 3 DAY), DATE_ADD(NOW(), INTERVAL 4 DAY), 14.00, 'Data synchronization failing when the app is offline.', false),
(57356, 'Mobile Performance Tuning', 57351, 'Mobile', 'Low', 'Open', 'Alex Rivera', 'Vexarion Mobile', DATE_SUB(NOW(), INTERVAL 2 DAY), DATE_ADD(NOW(), INTERVAL 6 DAY), 6.00, 'Tune app performance for better experience on budget Android devices.', false),
(57357, 'Cloud Infrastructure Issues', NULL, 'Cloud', 'High', 'Open', 'Jordan Lee', 'Elyndor Cloud', DATE_SUB(NOW(), INTERVAL 6 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 18.00, 'Cloud Infrastructure Issues', true),
(57358, 'AWS Lambda Timeouts', 57357, 'Cloud', 'Critical', 'In Progress', 'Casey Kim', 'Elyndor Cloud', DATE_SUB(NOW(), INTERVAL 5 DAY), DATE_ADD(NOW(), INTERVAL 8 HOUR), 10.00, 'Serverless functions in AWS Lambda exceeding timeout limits under load.', false),
(57359, 'S3 Bucket Configuration', 57357, 'Cloud', 'Medium', 'Open', 'Taylor Morgan', 'Elyndor Cloud', DATE_SUB(NOW(), INTERVAL 4 DAY), DATE_ADD(NOW(), INTERVAL 3 DAY), 6.00, 'S3 bucket permissions misconfigured, causing access denied errors.', false),
(57360, 'Auto-scaling Issues', 57357, 'Cloud', 'High', 'Escalated', 'Riley Patel', 'Elyndor Cloud', DATE_SUB(NOW(), INTERVAL 3 DAY), DATE_ADD(NOW(), INTERVAL 12 HOUR), 15.00, 'EC2 auto-scaling group not provisioning instances during peak times.', false),
(57361, 'Container Orchestration', 57357, 'Cloud', 'Medium', 'In Progress', 'Alex Rivera', 'Elyndor Cloud', DATE_SUB(NOW(), INTERVAL 2 DAY), DATE_ADD(NOW(), INTERVAL 5 DAY), 12.00, 'Debug Kubernetes pod evictions and resource limits.', false),
(57362, 'Kubernetes Deployment', 57357, 'Cloud', 'Low', 'Open', 'Jordan Lee', 'Elyndor Cloud', DATE_SUB(NOW(), INTERVAL 1 DAY), DATE_ADD(NOW(), INTERVAL 7 DAY), 8.00, 'Optimize deployment strategies for microservices in Kubernetes.', false),
(57363, 'Integration Problems', NULL, 'Integration', 'Medium', 'Open', 'Casey Kim', 'Alyndra Nexus', DATE_SUB(NOW(), INTERVAL 5 DAY), DATE_ADD(NOW(), INTERVAL 3 DAY), 14.00, 'Integration Problems', true),
(57364, 'Third-party API Failures', 57363, 'Integration', 'Critical', 'Escalated', 'Taylor Morgan', 'Alyndra Nexus', DATE_SUB(NOW(), INTERVAL 4 DAY), DATE_ADD(NOW(), INTERVAL 4 HOUR), 8.00, 'Payment gateway API (Stripe) hitting rate limits frequently.', false),
(57365, 'Webhook Configuration', 57363, 'Integration', 'High', 'In Progress', 'Riley Patel', 'Alyndra Nexus', DATE_SUB(NOW(), INTERVAL 3 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 10.00, 'Set up secure webhooks for GitHub repository events.', false),
(57366, 'Data Synchronization Issues', 57363, 'Integration', 'Medium', 'Open', 'Alex Rivera', 'Alyndra Nexus', DATE_SUB(NOW(), INTERVAL 2 DAY), DATE_ADD(NOW(), INTERVAL 4 DAY), 12.00, 'Nightly sync between CRM and ERP systems failing intermittently.', false),
(57367, 'OAuth Authentication Setup', 57363, 'Integration', 'Low', 'Resolved', 'Jordan Lee', 'Alyndra Nexus', DATE_SUB(NOW(), INTERVAL 1 DAY), DATE_ADD(NOW(), INTERVAL 6 DAY), 6.00, 'Configure OAuth 2.0 flow for seamless Google login integration.', false),
(57368, 'Database Management Issues', NULL, 'Database', 'High', 'Open', 'Alex Rivera', 'Vyrnax Data', DATE_SUB(NOW(), INTERVAL 4 DAY), DATE_ADD(NOW(), INTERVAL 1 DAY), 16.00, 'Database Management Issues', true),
(57369, 'Index Optimization', 57368, 'Database', 'Medium', 'In Progress', 'Jordan Lee', 'Vyrnax Data', DATE_SUB(NOW(), INTERVAL 3 DAY), DATE_ADD(NOW(), INTERVAL 2 DAY), 8.00, 'Rebuild fragmented indexes on the high-traffic customer table.', false),
(57370, 'Backup Corruption Recovery', 57368, 'Database', 'Critical', 'Escalated', 'Casey Kim', 'Vyrnax Data', DATE_SUB(NOW(), INTERVAL 2 DAY), DATE_ADD(NOW(), INTERVAL 6 HOUR), 20.00, 'Recover database from a corrupted backup file and restore integrity.', false);
```

After executing this script, the ticket records are stored in the `support_tickets` table within the `supportticketdb` database. The database is now ready for integration with the Blazor application.

---

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **TreeGrid_MySQL** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Entity Framework Core and MySQL integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2022.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 9.0.0
Install-Package Pomelo.EntityFrameworkCore.MySql -Version 9.0.0
Install-Package Syncfusion.Blazor.Grids -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.TreeGrid -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2022 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 9.0.0 or later)
   - **Microsoft.EntityFrameworkCore.Tools** (version 9.0.0 or later)
   - **Pomelo.EntityFrameworkCore.MySql** (version 9.0.0 or later)
   - **Syncfusion.Blazor.Grids** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.TreeGrid** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `support_tickets` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **SupportTicketModel.cs**.
3. Define the **SupportTicketModel** class with the following code:

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TreeGrid_MySQL.Data
{

	[Table("support_tickets")]
	public class SupportTicketModel
	{
		[Key]
		[Column("TicketID")]
		public int TicketID { get; set; }

		[Required]
		[MaxLength(255)]
		[Column("Title")]
		public string Title { get; set; } = string.Empty;

		[Column("ParentTicketID")]
		public int? ParentTicketID { get; set; }


		[MaxLength(100)]
		[Column("Category")]
		public string Category { get; set; } = string.Empty;

		[MaxLength(50)]
		[Column("Priority")]
		public string Priority { get; set; } = string.Empty;

		[MaxLength(50)]
		[Column("Status")]
		public string Status { get; set; } = string.Empty;

		[MaxLength(100)]
		[Column("AssignedAgent")]
		public string AssignedAgent { get; set; } = string.Empty;

		[MaxLength(200)]
		[Column("CustomerName")]
		public string CustomerName { get; set; } = string.Empty;

		[Column("CreatedDate", TypeName = "datetime")]
		public DateTime CreatedDate { get; set; }

		[Column("DueDate", TypeName = "datetime")]
		public DateTime DueDate { get; set; }

		[Column("EstimatedHours", TypeName = "decimal(6,2)")]
		public decimal EstimatedHours { get; set; }

		[Column("Description", TypeName = "text")]
		public string Description { get; set; } = string.Empty;

		[Column("HasChildren")]
		public bool HasChildren { get; set; } = false;



		public SupportTicketModel() { }

		public SupportTicketModel(int ticketID, string title, int? parentTicketID, string category,
			string priority, string status, string assignedAgent, string customerName,
			DateTime createdDate, DateTime dueDate, decimal estimatedHours, string description = "", bool hasChildren = false)
		{
			TicketID = ticketID;
			Title = title;
			ParentTicketID = parentTicketID;
			Category = category;
			Priority = priority;
			Status = status;
			AssignedAgent = assignedAgent;
			CustomerName = customerName;
			CreatedDate = createdDate;
			DueDate = dueDate;
			EstimatedHours = estimatedHours;
			Description = description;
			HasChildren = hasChildren;
		}
	}
}
```

**Explanation:**
- The `[Key]` attribute marks the `TicketID` property as the primary key (a unique identifier for each record).
- Each property represents a column in the database table.

The data model has been successfully created.

### Step 4: Configure the DbContext

A `DbContext` is a special class that manages the connection between the application and the MySQL database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **SupportTicketDbContext.cs**.
2. Define the `SupportTicketDbContext` class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace TreeGrid_MySQL.Data
{
	public class SupportTicketDbContext : DbContext
	{
		public SupportTicketDbContext(DbContextOptions<SupportTicketDbContext> options)
			: base(options)
		{
		}

		public DbSet<SupportTicketModel> SupportTickets { get; set; } = null!;

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var entity = modelBuilder.Entity<SupportTicketModel>();

			entity.ToTable("support_tickets");

			entity.HasKey(e => e.TicketID);
			// let the database generate the key by convention (auto-increment) unless your table uses explicit IDs
			entity.Property(e => e.TicketID).ValueGeneratedOnAdd();

			entity.Property(e => e.Title).HasMaxLength(255).IsRequired();
			entity.Property(e => e.Category).HasMaxLength(100);
			entity.Property(e => e.Priority).HasMaxLength(50);
			entity.Property(e => e.Status).HasMaxLength(50);
			entity.Property(e => e.AssignedAgent).HasMaxLength(100);
			entity.Property(e => e.CustomerName).HasMaxLength(200);
			entity.Property(e => e.CreatedDate).HasColumnType("datetime");
			entity.Property(e => e.DueDate).HasColumnType("datetime");
			entity.Property(e => e.EstimatedHours).HasPrecision(6, 2);
			entity.Property(e => e.Description).HasColumnType("text");
		}
	}
}
```

**Explanation:**
- The `DbContext` class inherits from Entity Framework's `DbContext` base class.
- The `SupportTickets` property represents the `support_tickets` table in the database.
- The `OnModelCreating` method configures how the database columns should behave (maximum length, required/optional, default values, etc.).

The **SupportTicketDbContext** class is required because:

- It **connects** the application to the database.
- It **manages** all database operations.
- It **maps** C# models to actual database tables.
- It **configures** how data should look inside the database.

Without this class, Entity Framework Core will not know where to save data or how to create the transactions table. The DbContext has been successfully configured.

### Step 5: Configure the Connection String

A connection string contains the information needed to connect the application to the MySQL database, including the server address, port, database name, and credentials.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Add or update the `ConnectionStrings` section with the MySQL connection details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database={DB_Name};Uid=root;Pwd={Password};SslMode=None;ConvertZeroDateTime=false;"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

**Connection String Components:**

| Component | Description |
|-----------|-------------|
| Server | The address of the MySQL server (use `localhost` for local development) |
| Port | The MySQL port number (default is `3306`) |
| Database | The database name (in this case, `transactiondb`) |
| Uid | The MySQL username (default is `root`) |
| Pwd | The MySQL password |
| SslMode | SSL encryption mode (set to `None` for local development) |
| ConvertZeroDateTime | Converts zero datetime values to NULL |

The database connection string has been configured successfully.

### Step 6: Create the Repository Class

A repository class is an intermediary layer that handles all database operations. This class uses Entity Framework Core to communicate with the database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **SupportTicketRepository.cs**.
2. Define the **SupportTicketRepository** class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeGrid_MySQL.Data
{
	/// <summary>
	/// Repository for support tickets (CRUD + helpers)
	/// Adjusted to work with SupportTicketData model (no navigation Children property).
	/// </summary>
	public class SupportTicketRepository
	{
		private readonly SupportTicketDbContext _context;

		public SupportTicketRepository(SupportTicketDbContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		/// <summary>
		/// Returns all tickets ordered by CreatedDate descending (flat list - TreeGrid will use ParentTicketID).
		/// </summary>
		public async Task<List<SupportTicketModel>> GetAllTicketsAsync()
		{
			return await _context.SupportTickets.ToListAsync();
		}

		/// <summary>
		/// Adds a new ticket.
		/// </summary>
		public async Task AddTicketAsync(SupportTicketModel ticket)
		{
			if (ticket == null) throw new ArgumentNullException(nameof(ticket));

			// ensure CreatedDate if not set
			if (ticket.CreatedDate == default) ticket.CreatedDate = DateTime.UtcNow;

			_context.SupportTickets.Add(ticket);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Updates an existing ticket.
		/// </summary>
		public async Task UpdateTicketAsync(SupportTicketModel ticket)
		{
			if (ticket == null) throw new ArgumentNullException(nameof(ticket));

			var existing = await _context.SupportTickets.FindAsync(ticket.TicketID);
			if (existing == null) throw new KeyNotFoundException($"Ticket {ticket.TicketID} not found.");

			// update mutable fields (preserve CreatedDate and TicketID)
			existing.Title = ticket.Title;
			existing.ParentTicketID = ticket.ParentTicketID;
			existing.Category = ticket.Category;
			existing.Priority = ticket.Priority;
			existing.Status = ticket.Status;
			existing.AssignedAgent = ticket.AssignedAgent;
			existing.CustomerName = ticket.CustomerName;
			existing.DueDate = ticket.DueDate;
			existing.EstimatedHours = ticket.EstimatedHours;
			existing.Description = ticket.Description;

			_context.SupportTickets.Update(existing);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Removes a ticket. Prevents deletion when children exist.
		/// </summary>
		public async Task RemoveTicketAsync(int id)
		{
			var ticket = await _context.SupportTickets.FindAsync(id);
			if (ticket == null) throw new KeyNotFoundException($"Ticket {id} not found.");

			var hasChildren = await _context.SupportTickets.AnyAsync(t => t.ParentTicketID == id);
			if (hasChildren)
				throw new InvalidOperationException("Cannot delete ticket that has child tickets. Delete or reassign children first.");

			_context.SupportTickets.Remove(ticket);
			await _context.SaveChangesAsync();
		}
	}
}
```

The repository class has been created.

### Step 7: Register Services in Program.cs

The `Program.cs` file is where application services are registered and configured. This file must be updated to enable Entity Framework Core and the repository pattern.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code after the line `var builder = WebApplication.CreateBuilder(args);`:

```csharp
using Microsoft.EntityFrameworkCore;
using TreeGrid_MySQL.Components;
using TreeGrid_MySQL.Data;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with MySQL database
builder.Services.AddDbContext<SupportTicketDbContext>(options =>
{
	options.UseMySql(
		connectionString,
		ServerVersion.AutoDetect(connectionString)
	);
});

// Register the repository for dependency injection
builder.Services.AddScoped<SupportTicketRepository>();

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

The service registration has been completed successfully.

---

## Integrating Syncfusion Blazor TreeGrid

### Step 1: Install and Configure Blazor TreeGrid Components

Syncfusion is a library that provides pre-built UI components like TreeGrid, which is used to display data in a table format.

**Instructions:**

1. The Syncfusion.Blazor.TreeGrid package was installed in **Step 2** of the previous heading.
2. Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Data
```

3. Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

Syncfusion components are now configured and ready to use. For additional guidance, refer to the TreeGrid component’s [getting‑started](https://sfblazor.azurewebsites.net/staging/documentation/treegrid/getting-started-webapp) documentation.

### Step 2: Update the Blazor TreeGrid in the Home Component

The Home component will display the transaction data in a Syncfusion Blazor TreeGrid with search, filter, sort, and pagination capabilities.

**Instructions:**

1. open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a basic TreeGrid:

```html
@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using System.Linq
@using TreeGrid_MySQL.Data
@inject SupportTicketRepository TicketService

 <!-- Syncfusion Blazor TreeGrid Component -->
 <SfTreeGrid TValue="SupportTicketModel"
             IdMapping="TicketID"
             ParentIdMapping="ParentTicketID"
             HasChildMapping="HasChildren"
             TreeColumnIndex="1">
     <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
        
        <TreeGridColumns>
           //columns configuration
        </TreeGridColumns>
</SfTreeGrid>

@code {
    // CustomAdaptor class will be added in the next step
}
```

**Component Explanation:**

- **`@rendermode InteractiveServer`**: Enables interactive server-side rendering for the component.
- **`@inject SupportTicketRepository`**: Injects the repository to access database methods.
- **`<SfTreeGrid>`**: The TreeGrid component that displays data in rows and columns.
- **`<TreeGridColumns>`**: Defines individual columns in the TreeGrid.

The Home component has been updated successfully with TreeGrid.

---

### Step 3: Implement the CustomAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid can bind data from a **MySQL Server** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to `CustomAdaptor` for scenarios that require full control over data operations.

The `CustomAdaptor` is a bridge between the TreeGrid and the database. It handles all data operations including reading, searching, filtering, sorting, paging, and CRUD operations. Each operation in the CustomAdaptor's `ReadAsync` method handles specific tree grid functionality. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid sends operation details to the API through a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. These details can be applied to the data source using methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the following `CustomAdaptor` class code inside the `@code` block:

```csharp
@code {
    /// <summary>
    /// Instance of the custom adaptor used by the TreeGrid.
    /// </summary>
    private CustomAdaptor? _customAdaptor;

    /// <summary>
    /// Initialize component and assign the ticket service to the custom adaptor.
    /// </summary>
    protected override void OnInitialized()
    {
        _customAdaptor = new CustomAdaptor { TicketService = TicketService };
    }

    /// <summary>
    /// Custom data adaptor for Syncfusion DataManager operations using SupportTicketRepository.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        /// <summary>
        /// Backing static field for the injected ticket repository.
        /// </summary>
        public static SupportTicketRepository? _ticketService { get; set; }

        /// <summary>
        /// Gets or sets the SupportTicketRepository used by this adaptor.
        /// </summary>
        public SupportTicketRepository? TicketService
        {
            get => _ticketService;
            set => _ticketService = value;
        }

        /// <summary>
        /// Reads data from the repository and applies DataManagerRequest operations such as
        /// searching, filtering, sorting, paging and returns the result or DataResult when counts are required.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
        {
            // Fetch all tickets from the database
            IEnumerable<SupportTicketModel> data = await _ticketService!.GetAllAsync();

            // Apply search operation if search criteria exists
            if (dm.Search != null && dm.Search.Count > 0)
                data = DataOperations.PerformSearching(data, dm.Search);

            // Apply filter operation if filter criteria exists
            if (dm.Where != null && dm.Where.Count > 0)
                data = DataOperations.PerformFiltering(data, dm.Where, dm.Where[0].Operator);

            // Apply sort operation if sort criteria exists
            if (dm.Sorted != null && dm.Sorted.Count > 0)
                data = DataOperations.PerformSorting(data, dm.Sorted);

            // Calculate total record count before paging for accurate pagination
            var count = data.Cast<SupportTicketModel>().Count();

            // Apply paging skip operation
            if (dm.Skip != 0)
                data = DataOperations.PerformSkip(data, dm.Skip);

            // Apply paging take operation to retrieve only the requested page size
            if (dm.Take != 0)
                data = DataOperations.PerformTake(data, dm.Take);

            // Return the result with total count for pagination metadata
            return dm.RequiresCounts ? new DataResult() { Result = data, Count = count } : (object)data;
        }       
    }
}
```

The `CustomAdaptor` class has been successfully implemented with all data operations.

**Common methods in data operations**

* [ReadAsync(DataManagerRequest)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) - Retrieve and process records (search, filter, sort, page, group)

* [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) - Applies search criteria to the collection.
* [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) - Filters data based on conditions.
* [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) - Sorts data by one or more fields.
* [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Linq_IQueryable___0__System_Int32_) - Skips a defined number of records for paging.
* [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Linq_IQueryable___0__System_Int32_) - Retrieves a specified number of records for paging.
* [PerformAggregation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html#Syncfusion_Blazor_Data_DataUtil_PerformAggregation_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_Aggregate__) – Calculates aggregate values such as Sum, Average, Min, and Max.

---

### Step 4: Add Toolbar with CRUD and search options

The toolbar provides buttons for adding, editing, deleting records, and searching the data.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Update the `<SfTreeGrid>` component to include the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Toolbar) property with CRUD and search options:

```html
 <!-- Syncfusion Blazor TreeGrid Component -->
 <SfTreeGrid TValue="SupportTicketModel"
             IdMapping="TicketID"
             ParentIdMapping="ParentTicketID"
             HasChildMapping="HasChildren"
             TreeColumnIndex="1"
             Toolbar="@ToolbarItems">
     <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
        
        <TreeGridColumns>
           //columns configuration
        </TreeGridColumns>
</SfTreeGrid>
```

3. Add the toolbar items list in the `@code` block:

```csharp
@code {
    private List<string> ToolbarItems { get; } = new() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" };

    // CustomAdaptor class code...
}
```

**Toolbar Items Explanation:**

| Item | Function |
|------|----------|
| `Add` | Opens a form to add a new transaction record. |
| `Edit` | Enables editing of the selected record. |
| `Delete` | Deletes the selected record from the database. |
| `Update` | Saves changes made to the selected record. |
| `Cancel` | Cancels the current edit or add operation. |
| `Search` | Displays a search box to find records. |

The toolbar has been successfully added.

---

### Step 5: Implement Paging Feature

Paging divides large datasets into smaller pages to improve performance and usability.

**Instructions:**

1. The paging feature is already partially enabled in the `<SfTreeGrid>` component with [AllowPaging="true"](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowPaging).
2. The page size is configured with [<TreeGridPageSettings>](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html).
3. No additional code changes are required from the previous steps.

```html
<!-- Syncfusion Blazor TreeGrid Component -->
 <SfTreeGrid TValue="SupportTicketModel"
             IdMapping="TicketID"
             ParentIdMapping="ParentTicketID"
             HasChildMapping="HasChildren"
             TreeColumnIndex="1"
             AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
       
    <!-- TreeGrid columns configuration -->

</SfTreeGrid>
```
4. Update the `ReadAsync` method in the `CustomAdaptor` class to handle paging:

```csharp
@code {
    /// <summary>
    /// Instance of the custom adaptor used by the TreeGrid.
    /// </summary>
    private CustomAdaptor? _customAdaptor;

    /// <summary>
    /// Initialize component and assign the ticket service to the custom adaptor.
    /// </summary>
    protected override void OnInitialized()
    {
        _customAdaptor = new CustomAdaptor { TicketService = TicketService };
    }

    /// <summary>
    /// Custom data adaptor for Syncfusion DataManager operations using SupportTicketRepository.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        /// <summary>
        /// Backing static field for the injected ticket repository.
        /// </summary>
        public static SupportTicketRepository? _ticketService { get; set; }

        /// <summary>
        /// Gets or sets the SupportTicketRepository used by this adaptor.
        /// </summary>
        public SupportTicketRepository? TicketService
        {
            get => _ticketService;
            set => _ticketService = value;
        }

        /// <summary>
        /// Reads data from the repository and applies DataManagerRequest operations such as
        /// searching, filtering, sorting, paging and returns the result or DataResult when counts are required.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
        {
            // Fetch all tickets from the database
            IEnumerable<SupportTicketModel> data = await _ticketService!.GetAllAsync();

            // Apply filter operation if filter criteria exists
            if (dm.Where != null && dm.Where.Count > 0)
                data = DataOperations.PerformFiltering(data, dm.Where, dm.Where[0].Operator);

            // Calculate total record count before paging for accurate pagination
            var count = data.Cast<SupportTicketModel>().Count();

            // Apply paging skip operation
            if (dm.Skip != 0)
                data = DataOperations.PerformSkip(data, dm.Skip);

            // Apply paging take operation to retrieve only the requested page size
            if (dm.Take != 0)
                data = DataOperations.PerformTake(data, dm.Take);

            // Return the result with total count for pagination metadata
            return dm.RequiresCounts ? new DataResult() { Result = data, Count = count } : (object)data;
        }       
    }
}
```

Fetches transaction data by calling the **GetAllTicketsAsync** method, which is implemented in the **SupportTicketRepository.cs** file.

```csharp
/// <summary>
/// Returns all tickets ordered by CreatedDate descending (flat list - TreeGrid will use ParentTicketID).
/// </summary>
public async Task<List<SupportTicketModel>> GetAllTicketsAsync()
{
	return await _context.SupportTickets.ToListAsync();
}
```

**How Paging Works:**

- The TreeGrid displays 5 parent records per page (as set in `TreeGridPageSettings`).
- Navigation buttons allow the user to move between pages.
- When a page is requested, the `ReadAsync` method receives skip and take values.
- The `DataOperations.PerformSkip()` and `DataOperations.PerformTake()` methods handle pagination.
- Only the requested page of records is transmitted from the server.

Paging feature is now active with 5 parent records per page.

---

### Step 6: Implement Searching feature

Searching allows the user to find records by entering keywords in the search box.

**Instructions:**

1. The search functionality is already enabled in the CustomAdaptor's `ReadAsync` method.
2. Ensure the toolbar includes the "Search" item.
3. No additional code changes are required.

```html
<!-- Syncfusion Blazor TreeGrid Component -->
 <SfTreeGrid TValue="SupportTicketModel"
             IdMapping="TicketID"
             ParentIdMapping="ParentTicketID"
             HasChildMapping="HasChildren"
             TreeColumnIndex="1"
             AllowPaging="true"
             Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
       
    <!-- TreeGrid columns configuration -->

</SfTreeGrid>
```
4. Update the `ReadAsync` method in the `CustomAdaptor` class to handle searching:

```csharp
@code {
    /// <summary>
    /// Instance of the custom adaptor used by the TreeGrid.
    /// </summary>
    private CustomAdaptor? _customAdaptor;

    private List<string> ToolbarItems { get; } = new() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" };

    /// <summary>
    /// Initialize component and assign the ticket service to the custom adaptor.
    /// </summary>
    protected override void OnInitialized()
    {
        _customAdaptor = new CustomAdaptor { TicketService = TicketService };
    }

    /// <summary>
    /// Custom data adaptor for Syncfusion DataManager operations using SupportTicketRepository.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        /// <summary>
        /// Backing static field for the injected ticket repository.
        /// </summary>
        public static SupportTicketRepository? _ticketService { get; set; }

        /// <summary>
        /// Gets or sets the SupportTicketRepository used by this adaptor.
        /// </summary>
        public SupportTicketRepository? TicketService
        {
            get => _ticketService;
            set => _ticketService = value;
        }

        /// <summary>
        /// Reads data from the repository and applies DataManagerRequest operations such as
        /// searching, filtering, sorting, paging and returns the result or DataResult when counts are required.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
        {
            // Fetch all tickets from the database
            IEnumerable<SupportTicketModel> data = await _ticketService!.GetAllAsync();

            // Apply search operation if search criteria exists
            if (dm.Search != null && dm.Search.Count > 0)
                data = DataOperations.PerformSearching(data, dm.Search);

            // Apply filter operation if filter criteria exists
            if (dm.Where != null && dm.Where.Count > 0)
                data = DataOperations.PerformFiltering(data, dm.Where, dm.Where[0].Operator);

            // Calculate total record count before paging for accurate pagination
            var count = data.Cast<SupportTicketModel>().Count();

            // Apply paging skip operation
            if (dm.Skip != 0)
                data = DataOperations.PerformSkip(data, dm.Skip);

            // Apply paging take operation to retrieve only the requested page size
            if (dm.Take != 0)
                data = DataOperations.PerformTake(data, dm.Take);

            // Return the result with total count for pagination metadata
            return dm.RequiresCounts ? new DataResult() { Result = data, Count = count } : (object)data;
        }       
    }
}
```

**How Searching Works:**

- When the user enters text in the search box and presses Enter, the TreeGrid sends a search request to the CustomAdaptor.
- The `ReadAsync` method receives the search criteria in `dataManagerRequest.Search`.
- The `DataOperations.PerformSearching()` method filters the data based on the search term.
- Results are returned and displayed in the TreeGrid.

Searching feature is now active.

---

### Step 7: Implement Filtering feature

Filtering allows the user to restrict data based on column values using a menu interface.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowFiltering]((https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowFiltering)) property and [TreeGridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridFilterSettings.html) to the `<SfTreeGrid>` component:

```html
<!-- Syncfusion Blazor TreeGrid Component -->
 <SfTreeGrid TValue="SupportTicketModel"
             IdMapping="TicketID"
             ParentIdMapping="ParentTicketID"
             HasChildMapping="HasChildren"
             TreeColumnIndex="1"
             AllowPaging="true"
             AllowFiltering="true"
             Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
       
    <!-- TreeGrid columns configuration -->

</SfTreeGrid>
```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle filtering:

```csharp
@code {
    /// <summary>
    /// Instance of the custom adaptor used by the TreeGrid.
    /// </summary>
    private CustomAdaptor? _customAdaptor;

    private List<string> ToolbarItems { get; } = new() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" };

    /// <summary>
    /// Initialize component and assign the ticket service to the custom adaptor.
    /// </summary>
    protected override void OnInitialized()
    {
        _customAdaptor = new CustomAdaptor { TicketService = TicketService };
    }

    /// <summary>
    /// Custom data adaptor for Syncfusion DataManager operations using SupportTicketRepository.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        /// <summary>
        /// Backing static field for the injected ticket repository.
        /// </summary>
        public static SupportTicketRepository? _ticketService { get; set; }

        /// <summary>
        /// Gets or sets the SupportTicketRepository used by this adaptor.
        /// </summary>
        public SupportTicketRepository? TicketService
        {
            get => _ticketService;
            set => _ticketService = value;
        }

        /// <summary>
        /// Reads data from the repository and applies DataManagerRequest operations such as
        /// searching, filtering, sorting, paging and returns the result or DataResult when counts are required.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
        {
            // Fetch all tickets from the database
            IEnumerable<SupportTicketModel> data = await _ticketService!.GetAllAsync();

            // Apply search operation if search criteria exists
            if (dm.Search != null && dm.Search.Count > 0)
                data = DataOperations.PerformSearching(data, dm.Search);

            // Apply filter operation if filter criteria exists
            if (dm.Where != null && dm.Where.Count > 0)
                data = DataOperations.PerformFiltering(data, dm.Where, dm.Where[0].Operator);

            // Calculate total record count before paging for accurate pagination
            var count = data.Cast<SupportTicketModel>().Count();

            // Apply paging skip operation
            if (dm.Skip != 0)
                data = DataOperations.PerformSkip(data, dm.Skip);

            // Apply paging take operation to retrieve only the requested page size
            if (dm.Take != 0)
                data = DataOperations.PerformTake(data, dm.Take);

            // Return the result with total count for pagination metadata
            return dm.RequiresCounts ? new DataResult() { Result = data, Count = count } : (object)data;
        }       
    }
}
```

**How Filtering Works:**

- Click on the dropdown arrow in any column header to open the filter menu.
- Select filtering criteria (equals, contains, greater than, less than, etc.).
- Click the "Filter" button to apply the filter.
- The `ReadAsync` method receives the filter criteria in `dataManagerRequest.Where`.
- Results are filtered accordingly and displayed in the TreeGrid.

Filtering feature is now active.

---

### Step 8: Implement Sorting feature

Sorting enables the user to arrange records in ascending or descending order based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowSorting) property to the `<SfTreeGrid>` component:

```html
<!-- Syncfusion Blazor TreeGrid Component -->
 <SfTreeGrid TValue="SupportTicketModel"
            IdMapping="TicketID"
            ParentIdMapping="ParentTicketID"
            HasChildMapping="HasChildren"
            TreeColumnIndex="1"
            AllowPaging="true"
            AllowSorting="true"
            AllowFiltering="true"
            Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
       
    <!-- TreeGrid columns configuration -->

</SfTreeGrid>
```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle sorting:

```csharp
@code {
    /// <summary>
    /// Instance of the custom adaptor used by the TreeGrid.
    /// </summary>
    private CustomAdaptor? _customAdaptor;

    private List<string> ToolbarItems { get; } = new() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" };

    /// <summary>
    /// Initialize component and assign the ticket service to the custom adaptor.
    /// </summary>
    protected override void OnInitialized()
    {
        _customAdaptor = new CustomAdaptor { TicketService = TicketService };
    }

    /// <summary>
    /// Custom data adaptor for Syncfusion DataManager operations using SupportTicketRepository.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        /// <summary>
        /// Backing static field for the injected ticket repository.
        /// </summary>
        public static SupportTicketRepository? _ticketService { get; set; }

        /// <summary>
        /// Gets or sets the SupportTicketRepository used by this adaptor.
        /// </summary>
        public SupportTicketRepository? TicketService
        {
            get => _ticketService;
            set => _ticketService = value;
        }

        /// <summary>
        /// Reads data from the repository and applies DataManagerRequest operations such as
        /// searching, filtering, sorting, paging and returns the result or DataResult when counts are required.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
        {
            // Fetch all tickets from the database
            IEnumerable<SupportTicketModel> data = await _ticketService!.GetAllAsync();

            // Apply search operation if search criteria exists
            if (dm.Search != null && dm.Search.Count > 0)
                data = DataOperations.PerformSearching(data, dm.Search);

            // Apply filter operation if filter criteria exists
            if (dm.Where != null && dm.Where.Count > 0)
                data = DataOperations.PerformFiltering(data, dm.Where, dm.Where[0].Operator);

            // Apply sort operation if sort criteria exists
            if (dm.Sorted != null && dm.Sorted.Count > 0)
                data = DataOperations.PerformSorting(data, dm.Sorted);

            // Calculate total record count before paging for accurate pagination
            var count = data.Cast<SupportTicketModel>().Count();

            // Apply paging skip operation
            if (dm.Skip != 0)
                data = DataOperations.PerformSkip(data, dm.Skip);

            // Apply paging take operation to retrieve only the requested page size
            if (dm.Take != 0)
                data = DataOperations.PerformTake(data, dm.Take);

            // Return the result with total count for pagination metadata
            return dm.RequiresCounts ? new DataResult() { Result = data, Count = count } : (object)data;
        }       
    }
}
```

**How Sorting Works:**

- Click on the column header to sort in ascending order.
- Click again to sort in descending order.
- The `ReadAsync` method receives the sort criteria in `dataManagerRequest.Sorted`.
- Records are sorted accordingly and displayed in the TreeGrid.

Sorting feature is now active.

---

### Step 10: Perform CRUD operations

CustomAdaptor methods enable users to create, read, update, and delete records directly from the TreeGrid. Each operation calls corresponding data layer methods in **TransactionRepository.cs** to execute MySQL commands.

Add the TreeGrid **EditSettings** and **Toolbar** configuration to enable create, read, update, and delete (CRUD) operations.

```html
<!-- Syncfusion Blazor TreeGrid Component -->
 <SfTreeGrid TValue="SupportTicketModel"
            IdMapping="TicketID"
            ParentIdMapping="ParentTicketID"
            HasChildMapping="HasChildren"
            TreeColumnIndex="1"
            AllowPaging="true"
            AllowSorting="true"
            AllowFiltering="true"
            Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
     <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
    <!-- TreeGrid columns configuration -->

</SfTreeGrid>
```
Add the toolbar items list in the `@code` block:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Add", "Edit", "Delete", "Update", "Cancel", "Search"};

    // CustomAdaptor class code...
}
```
**Insert**

Record insertion allows new transactions to be added directly through the TreeGrid component. The adaptor processes the insertion request, performs any required business‑logic validation, and saves the newly created record to the MySQL Server database.

In **Home.razor**, implement the `InsertAsync` method to handle record deletion within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
     public override async Task<object> InsertAsync(DataManager dataManager, object value, string key)
    {
        if (value is SupportTicketModel item)
        {
            if (item.CreatedDate == default) item.CreatedDate = DateTime.UtcNow;
            await _ticketService!.AddTicketAsync(item);
        }
        return value;
    }
}
```
In **Data/SupportTicketRepository.cs**, implement the insert method:

```csharp
public async Task AddTicketAsync(SupportTicketModel ticket)
{
	if (ticket == null) throw new ArgumentNullException(nameof(ticket));

	// ensure CreatedDate if not set
	if (ticket.CreatedDate == default) ticket.CreatedDate = DateTime.UtcNow;

	_context.SupportTickets.Add(ticket);
	await _context.SaveChangesAsync();
}
```

**What happens behind the scenes:**

1. The form data is collected and validated in the CustomAdaptor's `InsertAsync()` method.
2. The `SupportTicketRepository.AddTicketAsync()` method is called.
3. The new record is added to the `_context.SupportTickets` collection.
4. `SaveChangesAsync()` persists the record to the MySQL database.
5. The TreeGrid automatically refreshes to display the new record.

Now the new transaction is persisted to the database and reflected in the tree grid.

**Update**

Record modification allows transaction details to be updated directly within the TreeGrid. The adaptor processes the edited row, validates the updated values, and applies the changes to the **MySQL Server database** while ensuring data integrity is preserved.

In **Home.razor**, implement the `UpdateAsync` method to handle record deletion within the `CustomAdaptor` class:


```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> UpdateAsync(DataManager dataManager, object value, string keyField, string key)
    {
        if (value is SupportTicketModel item)
        {
            await _ticketService!.UpdateTicketAsync(item);
        }
        return value;
    }
}
```
In **Data/SupportTicketRepository.cs**, implement the update method:

```csharp
public async Task UpdateTicketAsync(SupportTicketModel ticket)
{
	if (ticket == null) throw new ArgumentNullException(nameof(ticket));

	var existing = await _context.SupportTickets.FindAsync(ticket.TicketID);
	if (existing == null) throw new KeyNotFoundException($"Ticket {ticket.TicketID} not found.");

	// update mutable fields (preserve CreatedDate and TicketID)
	existing.Title = ticket.Title;
	existing.ParentTicketID = ticket.ParentTicketID;
	existing.Category = ticket.Category;
	existing.Priority = ticket.Priority;
	existing.Status = ticket.Status;
	existing.AssignedAgent = ticket.AssignedAgent;
	existing.CustomerName = ticket.CustomerName;
	existing.DueDate = ticket.DueDate;
	existing.EstimatedHours = ticket.EstimatedHours;
	existing.Description = ticket.Description;

	_context.SupportTickets.Update(existing);
	await _context.SaveChangesAsync();
}
```

**What happens behind the scenes:**

1. The modified data is collected from the form.
2. The CustomAdaptor's `UpdateAsync()` method is called.
3. The `SupportTicketRepository.UpdateTicketAsync()` method is called.
4. The existing record is retrieved from the database by TicketID.
5. All properties are updated with the new values (except TicketID and CreatedAt).
6. `SaveChangesAsync()` persists the changes to the MySQL database.
7. The TreeGrid refreshes to display the updated record.

Now modifications are synchronized to the database and reflected in the tree grid UI.

**Delete**

Record deletion allows transactions to be removed directly from the TreeGrid. The adaptor captures the delete request, executes the corresponding **MySQL DELETE** operation, and updates both the database and the tree grid to reflect the removal.

In **Home.razor**, implement the `RemoveAsync` method to handle record deletion within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> RemoveAsync(DataManager dataManager, object value, string keyField, string key)
    {
        if (value is int id)
            await _ticketService!.RemoveTicketAsync(id);
        else if (value is SupportTicketModel item)
            await _ticketService!.RemoveTicketAsync(item.TicketID);

        return value;
    }
}
```
In **Data/SupportTicketRepository.cs**, implement the delete method:

```csharp
public async Task RemoveTicketAsync(int id)
{
	var ticket = await _context.SupportTickets.FindAsync(id);
	if (ticket == null) throw new KeyNotFoundException($"Ticket {id} not found.");

	var hasChildren = await _context.SupportTickets.AnyAsync(t => t.ParentTicketID == id);
	if (hasChildren)
		throw new InvalidOperationException("Cannot delete ticket that has child tickets. Delete or reassign children first.");

	_context.SupportTickets.Remove(ticket);
	await _context.SaveChangesAsync();
}
```
**What happens behind the scenes:**

1. The user selects a record and clicks "Delete".
2. A confirmation dialog appears (built into the TreeGrid).
3. If confirmed, the CustomAdaptor's `RemoveAsync()` method is called.
4. The `SupportTicketRepository.RemoveTicketAsync()` method is called.
5. The record is located in the database by its TicketID.
6. The record is removed from the `_context.SupportTickets` collection.
7. `SaveChangesAsync()` executes the DELETE statement in MySQL.
8. The TreeGrid refreshes to remove the deleted record from the UI.

Now transactions are removed from the database and the tree grid UI reflects the changes immediately.

**Batch update**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring transactional consistency by applying all changes atomically to the MySQL Server database.

In **Home.razor**, implement the `BatchUpdateAsync` method to handle multiple record updates in a single request within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string keyField, string key, int? dropIndex)
    {
        if (changed != null)
        {
            foreach (var rec in (IEnumerable<object>)changed)
                if (rec is SupportTicketModel it) await _ticketService!.UpdateTicketAsync(it);
        }
        if (added != null)
        {
            foreach (var rec in (IEnumerable<object>)added)
                if (rec is SupportTicketModel it)
                {
                    if (it.CreatedDate == default) it.CreatedDate = DateTime.UtcNow;
                    await _ticketService!.AddTicketAsync(it);
                }
        }
        if (deleted != null)
        {
            foreach (var rec in (IEnumerable<object>)deleted)
                if (rec is SupportTicketModel it) await _ticketService!.RemoveTicketAsync(it.TicketID);
        }

        var result = await _ticketService!.GetAllTicketsAsync();
        return result;
    }
}
```
> This method is triggered when the TreeGrid is operating in [Batch](https://sfblazor.azurewebsites.net/staging/documentation/treegrid/editing/batch-editing) Edit mode.

**What happens behind the scenes:**

- The TreeGrid collects all added, edited, and deleted records in Batch Edit mode.
- The combined batch request is passed to the CustomAdaptor’s `BatchUpdateAsync()` method.
- Each modified record is processed using `SupportTicketRepository.UpdateTicketAsync()`.
- Each newly added record is saved using `SupportTicketRepository.AddTicketAsync()`.
- Each deleted record is removed using `SupportTicketRepository.RemoveTicketAsync()`.
- All repository operations persist changes to the MySQL Server database.
- The TreeGrid refreshes to display the updated, added, and removed records in a single response.

Now the adaptor supports bulk modifications with atomic database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor TreeGrid.

**Reference links**
- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in MySQL Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in MySQL Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from MySQL Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

---

### Step 11: Complete code
Here is the complete and final `Home.razor` component with all features integrated:

```html
@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor
@using System.Linq
@using TreeGrid_MySQL.Data
@inject SupportTicketRepository TicketService

<PageTitle>Support Tickets (Custom Adaptor)</PageTitle>

<div class="container-fluid p-4">
    <h2 class="mb-3">Support Tickets (Custom Adaptor)</h2>

    <SfTreeGrid TValue="SupportTicketModel"
                IdMapping="TicketID"
                ParentIdMapping="ParentTicketID"
                HasChildMapping="HasChildren"
                TreeColumnIndex="1"
                AllowPaging="true"
                AllowSorting="true"
                AllowFiltering="true"
                Toolbar="@ToolbarItems">
        <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>

        <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
        <TreeGridColumns>
            <TreeGridColumn Field="TicketID" HeaderText="ID" Width="80" IsPrimaryKey="true" AllowAdding="false" AllowEditing="false" TextAlign="TextAlign.Center"></TreeGridColumn>
            <TreeGridColumn Field="Title" HeaderText="Title" Width="300"></TreeGridColumn>
            <TreeGridColumn Field="Category" HeaderText="Category" Width="150"></TreeGridColumn>
            <TreeGridColumn HeaderText="Priority" Width="120">
                <Template>
                    @{
                        var priority = (context as SupportTicketModel)?.Priority;
                        var badgeClass = priority?.ToLower() switch
                        {
                            "high" => "e-badge e-badge-danger",
                            "low" => "e-badge e-badge-info",
                            "medium" => "e-badge e-badge-warning",
                            _ => "e-badge"
                        };
                    }
                    <span class="@badgeClass">@priority</span>
                </Template>
            </TreeGridColumn>
            <TreeGridColumn Field="Status" HeaderText="Status" Width="120"></TreeGridColumn>
            <TreeGridColumn Field="AssignedAgent" HeaderText="Assigned Agent" Width="160"></TreeGridColumn>
            <TreeGridColumn Field="CustomerName" HeaderText="Customer" Width="160"></TreeGridColumn>
            <TreeGridColumn Field="CreatedDate" HeaderText="Created" Width="160" Type="ColumnType.Date" Format="g"></TreeGridColumn>
        </TreeGridColumns>

        <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
    </SfTreeGrid>
</div>
```
> * Set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_IsPrimaryKey) to **true** for a column that contains unique values.
> * If the database includes an **auto-generated column**, set [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_IsIdentity) for that column to disable editing during **add** or **update** operations.
> * The [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_EditType) property can be used to specify the desired editor for each column. [🔗](https://blazor.syncfusion.com/documentation/treegrid/editing/cell-edit-types)
> * The behavior of default editors can be customized using the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_EditorSettings) property of the `TreeGridColumn` component. [🔗](https://blazor.syncfusion.com/documentation/treegrid/editing/cell-edit-types)
> * [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Type) property of the `TreeGridColumn` component  specifies the data type of a tree grid column.
> * The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Template) property that allows rendering custom elements in a column instead of the default field value. [🔗](https://blazor.syncfusion.com/documentation/treegrid/columns/column-template)


```csharp
@code {
    private CustomAdaptor? _customAdaptor;
    private List<string> ToolbarItems { get; } = new() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" };

    protected override void OnInitialized()
    {
        _customAdaptor = new CustomAdaptor { TicketService = TicketService };
    }

    public class CustomAdaptor : DataAdaptor
    {
        public static SupportTicketRepository? _ticketService { get; set; }

        public SupportTicketRepository? TicketService
        {
            get => _ticketService;
            set => _ticketService = value;
        }


        public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)
        {
            IEnumerable<SupportTicketModel> data = await _ticketService!.GetAllTicketsAsync();

            if (dm.Search != null && dm.Search.Count > 0)
                data = DataOperations.PerformSearching(data, dm.Search);

            if (dm.Where != null && dm.Where.Count > 0)
                data = DataOperations.PerformFiltering(data, dm.Where, dm.Where[0].Operator);

            if (dm.Sorted != null && dm.Sorted.Count > 0)
                data = DataOperations.PerformSorting(data, dm.Sorted);

            var count = data.Cast<SupportTicketModel>().Count();

            if (dm.Skip != 0)
                data = DataOperations.PerformSkip(data, dm.Skip);

            if (dm.Take != 0)
                data = DataOperations.PerformTake(data, dm.Take);

            return dm.RequiresCounts ? new DataResult() { Result = data, Count = count } : (object)data;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object value, string key)
        {
            if (value is SupportTicketModel item)
            {
                if (item.CreatedDate == default) item.CreatedDate = DateTime.UtcNow;
                await _ticketService!.AddTicketAsync(item);
            }
            return value;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object value, string keyField, string key)
        {
            if (value is SupportTicketModel item)
            {
                await _ticketService!.UpdateTicketAsync(item);
            }
            return value;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object value, string keyField, string key)
        {
            if (value is int id)
                await _ticketService!.RemoveTicketAsync(id);
            else if (value is SupportTicketModel item)
                await _ticketService!.RemoveTicketAsync(item.TicketID);

            return value;
        }

        public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string keyField, string key, int? dropIndex)
        {
            if (changed != null)
            {
                foreach (var rec in (IEnumerable<object>)changed)
                    if (rec is SupportTicketModel it) await _ticketService!.UpdateTicketAsync(it);
            }
            if (added != null)
            {
                foreach (var rec in (IEnumerable<object>)added)
                    if (rec is SupportTicketModel it)
                    {
                        if (it.CreatedDate == default) it.CreatedDate = DateTime.UtcNow;
                        await _ticketService!.AddTicketAsync(it);
                    }
            }
            if (deleted != null)
            {
                foreach (var rec in (IEnumerable<object>)deleted)
                    if (rec is SupportTicketModel it) await _ticketService!.RemoveTicketAsync(it.TicketID);
            }

            var result = await _ticketService!.GetAllTicketsAsync();
            return result;
        }
    }
}
```

## Running the Application

**Step 1: Build the Application**

1. Open the terminal or Package Manager Console.
2. Navigate to the project directory.
3. Run the following command:

```powershell
dotnet build
```

**Step 2: Run the Application**

Execute the following command:

```powershell
dotnet run
```

**Step 3: Access the Application**

1. Open a web browser.
2. Navigate to `https://localhost:5001` (or the port shown in the terminal).
3. The transaction management application is now running and ready to use.

### Available Features

- **View Data**: All transactions from the MySQL database are displayed in the TreeGrid.
- **Search**: Use the search box to find transactions by any field.
- **Filter**: Click on column headers to apply filters.
- **Sort**: Click on column headers to sort data in ascending or descending order.
- **Pagination**: Navigate through records using page numbers.
- **Add**: Click the "Add" button to create a new transaction.
- **Edit**: Click the "Edit" button to modify existing transactions.
- **Delete**: Click the "Delete" button to remove transactions.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](#).

---

## Summary

This guide demonstrates how to:
1. Create a MySQL database with transaction records. [🔗](#step-1-create-the-database-and-table-in-mysql-server)
2. Install necessary NuGet packages for Entity Framework Core and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services. [🔗](#step-5-configure-the-connection-string)
5. Implement the repository pattern for data access. [🔗](#step-6-create-the-repository-class)
6. Create a Blazor component with a TreeGrid that supports searching, filtering, sorting, paging, and CRUD operations. [🔗](#step-1-install-and-configure-blazor-treegrid-components)
7. Handle bulk operations and batch updates. [🔗](#step-10-perform-crud-operations)

The application now provides a complete solution for managing transaction data with a modern, user-friendly interface.