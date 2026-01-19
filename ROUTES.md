# 🌐 Application Routes - WebApplication1

## Authentication Routes (ASP.NET Core Identity)

| Route                                     | HTTP Method | Description       | Access        | Page/Controller                                           |
| ----------------------------------------- | ----------- | ----------------- | ------------- | --------------------------------------------------------- |
| `/Identity/Account/Register`              | GET, POST   | User registration | Public        | Areas/Identity/Pages/Account/Register.cshtml              |
| `/Identity/Account/Login`                 | GET, POST   | User login        | Public        | Areas/Identity/Pages/Account/Login.cshtml                 |
| `/Identity/Account/Logout`                | GET, POST   | User logout       | Authenticated | Areas/Identity/Pages/Account/Logout.cshtml                |
| `/Identity/Account/Manage/Index`          | GET         | Manage account    | Authenticated | Areas/Identity/Pages/Account/Manage/Index.cshtml          |
| `/Identity/Account/Manage/ChangePassword` | GET, POST   | Change password   | Authenticated | Areas/Identity/Pages/Account/Manage/ChangePassword.cshtml |

---

## Question 1 - User Management Routes

| Route                     | HTTP Method | Description    | Access        | Controller/Action                  |
| ------------------------- | ----------- | -------------- | ------------- | ---------------------------------- |
| `/Account/UserManagement` | GET         | List all users | Authenticated | AccountController.UserManagement() |

---

## Question 3 - Shopping Cart Routes

| Route                   | HTTP Method | Description               | Access        | Controller/Action                |
| ----------------------- | ----------- | ------------------------- | ------------- | -------------------------------- |
| `/Panier/PanierParUser` | GET         | View user's shopping cart | Authenticated | PanierController.PanierParUser() |
| `/Panier/SeedPanier`    | GET         | Add test products to cart | Authenticated | PanierController.SeedPanier()    |

---

## Movie Management Routes

| Route                            | HTTP Method | Description            | Access        | Controller/Action                      |
| -------------------------------- | ----------- | ---------------------- | ------------- | -------------------------------------- |
| `/Movie/Index` or `/`            | GET         | List all movies        | Public        | MovieController.Index()                |
| `/Movie/Details/{id}`            | GET         | Movie details          | Public        | MovieController.Details(id)            |
| `/Movie/Create`                  | GET, POST   | Create new movie       | Authenticated | MovieController.Create()               |
| `/Movie/Edit/{id}`               | GET, POST   | Edit movie             | Authenticated | MovieController.Edit(id)               |
| `/Movie/Delete/{id}`             | GET, POST   | Delete movie           | Authenticated | MovieController.Delete(id)             |
| `/Movie/released/{year}/{month}` | GET         | Movies by release date | Public        | MovieController.ByRelease(year, month) |

---

## Customer Management Routes

| Route                    | HTTP Method | Description         | Access        | Controller/Action              |
| ------------------------ | ----------- | ------------------- | ------------- | ------------------------------ |
| `/Customer/Index`        | GET         | List all customers  | Public        | CustomerController.Index()     |
| `/Customer/Details/{id}` | GET         | Customer details    | Public        | CustomerController.Details(id) |
| `/Customer/Create`       | GET, POST   | Create new customer | Authenticated | CustomerController.Create()    |
| `/Customer/Edit/{id}`    | GET, POST   | Edit customer       | Authenticated | CustomerController.Edit(id)    |
| `/Customer/Delete/{id}`  | GET, POST   | Delete customer     | Authenticated | CustomerController.Delete(id)  |

---

## Genre Management Routes

| Route                  | HTTP Method | Description      | Access        | Controller/Action           |
| ---------------------- | ----------- | ---------------- | ------------- | --------------------------- |
| `/Genres/Index`        | GET         | List all genres  | Public        | GenreController.Index()     |
| `/Genres/Details/{id}` | GET         | Genre details    | Public        | GenreController.Details(id) |
| `/Genres/Create`       | GET, POST   | Create new genre | Authenticated | GenreController.Create()    |
| `/Genres/Edit/{id}`    | GET, POST   | Edit genre       | Authenticated | GenreController.Edit(id)    |
| `/Genres/Delete/{id}`  | GET, POST   | Delete genre     | Authenticated | GenreController.Delete(id)  |

---

## Main Page Routes

| Route                | HTTP Method | Description  | Access | Controller/Action        |
| -------------------- | ----------- | ------------ | ------ | ------------------------ |
| `/` or `/Home/Index` | GET         | Home page    | Public | HomeController.Index()   |
| `/Home/Privacy`      | GET         | Privacy page | Public | HomeController.Privacy() |
| `/Home/Audit`        | GET         | Audit logs   | Public | HomeController.Audit()   |
| `/Home/Error`        | GET         | Error page   | Public | HomeController.Error()   |

---

## Audit Log Routes

| Route                 | HTTP Method | Description       | Access | Controller/Action           |
| --------------------- | ----------- | ----------------- | ------ | --------------------------- |
| `/Audit/Index`        | GET         | View audit logs   | Public | AuditController.Index()     |
| `/Audit/Details/{id}` | GET         | Audit log details | Public | AuditController.Details(id) |

---

## Quick Access Links

### For New Users

```
1. Register: https://localhost:5001/Identity/Account/Register
2. Login: https://localhost:5001/Identity/Account/Login
3. Home: https://localhost:5001/
```

### For Authenticated Users

```
1. My Account: https://localhost:5001/Identity/Account/Manage/Index
2. User Management: https://localhost:5001/Account/UserManagement
3. My Cart: https://localhost:5001/Panier/PanierParUser
4. Add Test Products: https://localhost:5001/Panier/SeedPanier
```

### For Management

```
1. Movies: https://localhost:5001/Movie/Index
2. Customers: https://localhost:5001/Customer/Index
3. Genres: https://localhost:5001/Genres/Index
4. Audit Logs: https://localhost:5001/Audit/Index
```

---

## Route Attributes & Configuration

### Program.cs Routes

```csharp
// Default MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Special movie route
app.MapControllerRoute(
    name: "moviesByRelease",
    pattern: "Movie/released/{year}/{month}",
    defaults: new { controller = "Movie", action = "ByRelease" }
);

// Razor Pages for Identity
app.MapRazorPages();
```

---

## Access Control Summary

### Public Routes (No Authentication Required)

- Home page `/`
- Movie listing `/Movie/Index`
- Movie details `/Movie/Details/{id}`
- Customer listing `/Customer/Index`
- Genre listing `/Genres/Index`
- Register `/Identity/Account/Register`
- Login `/Identity/Account/Login`
- Privacy `/Home/Privacy`
- Audit `/Home/Audit`

### Authenticated Routes (Login Required)

- User Management `/Account/UserManagement`
- My Cart `/Panier/PanierParUser`
- Add Test Products `/Panier/SeedPanier`
- Create/Edit/Delete Movie
- Create/Edit/Delete Customer
- Create/Edit/Delete Genre
- Account Management `/Identity/Account/Manage/Index`
- Change Password `/Identity/Account/Manage/ChangePassword`

---

## Base URL

**Development**: `https://localhost:5001`
**Production**: (configured in appsettings.json)

---

## Notes

- All routes are case-insensitive in ASP.NET Core
- `{id}` is an optional route parameter (integer or GUID)
- Areas like `/Identity/` are handled separately via Razor Pages
- Authentication is enforced via `[Authorize]` attributes on controllers/actions
- Some pages use forms with POST method for data submission

---

**Route Documentation - Updated January 2026**
