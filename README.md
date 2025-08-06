# 🚀 JobTracker - Hangfire Background Job System

**JobTracker** is a .NET-based background job processing system that leverages [Hangfire](https://www.hangfire.io/) and PostgreSQL to manage recurring and fire-and-forget jobs.

This project showcases how to integrate and manage background tasks such as logging, scheduling, retry handling, and dependency injection using a modular `Worker` class.

---

## 🔧 Technologies Used

- [.NET 8 / ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/)
- [Hangfire](https://www.hangfire.io/)
- [PostgreSQL](https://www.postgresql.org/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

---

## ⚙️ Setup Instructions

1. **Clone the repository**

   ```bash
   git clone https://github.com/your-org/jobtracker.git
   cd jobtracker

2. **Configure PostgreSQL**

    ```bash
   "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=jobtracker_db;Username=postgres;Password=yourpassword"
    }
   
2. **Access the Hangfire Dashboard**


    http://localhost:<port>/hangfire
