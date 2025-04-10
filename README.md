# Practical 13: Employee Database Application

This document provides setup instructions for Practical 13, focusing on database configuration and initialization.

## Prerequisites

### Database Setup

```sql
CREATE DATABASE Practical13
USE Practical13
```

### Connection String Configuration

Add the following connection string to your `web.config` file:

```xml
<connectionStrings>
    <add name="EmployeeDbContext"
         connectionString="Server=.\SQLEXPRESS;Database=Practical13;Trusted_Connection=True;"
         providerName="System.Data.SqlClient" />
</connectionStrings>
```

> **Note:** Modify the connection string according to your SQL Server configuration if needed.

## Database Migration

For each project, you need to apply the migrations to create the database schema:

1. Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console)
2. Select the appropriate project in the "Default project" dropdown
3. Run the following command:
   ```
   Update-Database
   ```

This command will apply all pending migrations and create the necessary tables in your Practical13 database.

## Troubleshooting

If you encounter any issues during migration:

- Verify your SQL Server is running
- Ensure the connection string points to the correct SQL Server instance
- Make sure all required NuGet packages are installed
