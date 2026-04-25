# 💄 BeautyTech Pro

**BeautyTech Pro** is a full-stack web application designed to manage professional makeup academies efficiently.
It centralizes academic processes such as student tracking, practical evaluations, modules, instructors, and schedules in a single system.

---

## 🚀 Features

* 👩‍🎓 Student management (Create, Read, Update, Delete)
* 🎓 Instructor management
* 📚 Module organization
* 🧪 Practice tracking with grades and observations
* 📅 Schedule management
* 🔗 Fully connected relational database
* 🌐 Interactive frontend (HTML, CSS, JavaScript)
* 📡 RESTful API built with ASP.NET Core

---

## 🧱 Architecture

The project follows a layered architecture:

```
API → Infrastructure → Domain
       ↘
        Application (DTOs)
```

* **Domain** → Entities
* **Application** → DTOs
* **Infrastructure** → Repositories & DbContext
* **API** → Controllers & configuration
* **Frontend** → Static files (HTML, CSS, JS)

---

## 🛠️ Technologies Used

### Backend

* ASP.NET Core (.NET 9)
* Entity Framework Core
* SQL Server / LocalDB
* Swagger (API Documentation)

### Frontend

* HTML5
* CSS3
* JavaScript (Vanilla)

---

## 📦 Project Structure

```
BeautyTechPro
│
├── BeautyTechPro.API
├── BeautyTechPro.Application
├── BeautyTechPro.Domain
├── BeautyTechPro.Infrastructure
└── wwwroot (Frontend)
```

---

## ⚙️ Setup & Run

### 1️⃣ Clone the repository

```
git clone https://github.com/your-username/BeautyTechPro.git
```

---

### 2️⃣ Configure database

Make sure your `appsettings.json` has:

```
Server=(localdb)\MSSQLLocalDB;
Database=BeautyTechProDB;
Trusted_Connection=True;
```

---

### 3️⃣ Run migrations

```
dotnet ef database update --project BeautyTechPro.Infrastructure --startup-project BeautyTechPro.API
```

---

### 4️⃣ Run the project

```
dotnet run --project BeautyTechPro.API
```

---

### 5️⃣ Open in browser

```
https://localhost:7298
```

* 🌐 Frontend loads automatically
* 📘 Swagger available at:

```
https://localhost:7298/swagger
```

---

## 🔮 Future Improvements

* Authentication (Login/Register)
* Role-based access (Admin / Instructor)
* Dashboard analytics
* Better UI/UX design
* Deploy to cloud (Azure / Render)

---

## 👩‍💻 Author

**Ivana Encarnación**

---

## ⭐ Notes

This project was built as a practical implementation of:

* REST API development
* Entity Framework Core
* Clean project structure
* Full CRUD operations
* Frontend-backend integration

---

## 💡 License

This project is for educational purposes.
