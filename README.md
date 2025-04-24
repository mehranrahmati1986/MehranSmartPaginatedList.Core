## MehranSmartMap
---

### 🌐 English

#### 📘 Features

This package allows you to easily and efficiently implement pagination in your .NET projects. It provides tools for managing paginated lists and helps you display your data in an optimized way using advanced sorting and filtering capabilities.

Features:
- **Pagination Implementation**: Simple and effective pagination based on page number and page size.
- **Complex Sorting**: Apply complex sorting operations with priority and multiple fields.
- **Async Support**: Asynchronous operations for improved performance.
- **Easy to Use**: Works seamlessly with .NET Core and Framework projects.

This package is ideal for developers who need dynamic and flexible pagination, especially designed for .NET projects.

#### 🔧 Installation & Configuration

##### 1. Install Package

```bash
dotnet add package MehranPagination.Core
```

##### 2. Use Pagination & Sorting

```csharp
var result = await db.Users.ToPaginatedListAsync(
    pageIndex: 1,
    pageSize: 10,
    sortOptions: new[] {
        new SortOption("Name", false, 1),
        new SortOption("Id", true, 2)
    });
```

##### 3. Access Result

```csharp
result.Items; // current page items
result.PaginationInfo.TotalPages;
result.PaginationInfo.HasNextPage;
```

#### 📘 Explanation

`ToPaginatedListAsync` and `ToPaginatedList` are extension methods to convert an `IQueryable<T>` into a paginated result with sorting support. 

- Supports both sync and async usage.
- Sort options can be passed as a list with priority.
- Sorting is applied using dynamic expression trees.
- Returns a `PaginatedList<T>` which contains both items and pagination metadata.

Use `SortOption` to define the sorting field, direction, and priority. Sorting is done in the order of priority.

---

### 🇹🇳 فارسی

#### 📘 ویژگی‌ها

این پکیج به شما این امکان را می‌دهد که فرآیند صفحه‌بندی (pagination) را به‌طور ساده و کارآمد در پروژه‌های دات‌نت خود پیاده‌سازی کنید. این پکیج ابزارهایی را برای مدیریت لیست‌های صفحه‌بندی‌شده ارائه می‌دهد و به شما کمک می‌کند که داده‌های خود را به‌طور بهینه و با استفاده از قابلیت‌های مرتب‌سازی پیچیده و پیشرفته نمایش دهید.

امکانات:
- **پیاده‌سازی صفحه‌بندی**: صفحه‌بندی ساده و کارآمد بر اساس شماره صفحه و اندازه صفحه.
- **مرتب‌سازی پیچیده**: اعمال مرتب‌سازی پیچیده با اولویت‌بندی و چندین ویژگی.
- **پشتیبانی از عملیات همزمان (Async)**: بهبود عملکرد با عملیات همزمان.
- **ابزارهای راحت برای استفاده در پروژه‌های دات‌نت Core و Framework**: استفاده آسان در پروژه‌های دات‌نت.

این پکیج برای توسعه‌دهندگانی که نیاز به پیاده‌سازی صفحه‌بندی پویا و انعطاف‌پذیر دارند، مناسب است و به‌طور خاص برای پروژه‌های دات‌نت طراحی شده است.

#### 📆 نصب و پیکربندی

##### 1. نصب پکیج:

```bash
dotnet add package MehranPagination.Core
```

##### 2. صفحه‌بندی و سورت

```csharp
var result = await db.Users.ToPaginatedListAsync(
    pageIndex: 1,
    pageSize: 10,
    sortOptions: new[] {
        new SortOption("Name", false, 1),
        new SortOption("Id", true, 2)
    });
```

##### 3. دسترسی به نتیجه:

```csharp
result.Items; // آیتم‌های صفحه جاری
result.PaginationInfo.TotalPages;
result.PaginationInfo.HasNextPage;
```

#### 📘 توضیح

با استفاده از `ToPaginatedListAsync` و `ToPaginatedList` می‌توانید `IQueryable<T>` را به صورت صفحه‌بندی‌شده و همراه با قابلیت مرتب‌سازی دریافت کنید.

- قابلیت همزمان و غیرهمزمان
- مرتب‌سازی بر اساس اولویت
- استفاده از Expression Tree برای مرتب‌سازی
- برگرداندن لیستی همراه با metadata

---

### 🇸🇦 العربية

#### 📘 الميزات

يسمح لك هذا الحزمة بتنفيذ التصفح (pagination) بسهولة وكفاءة في مشاريعك الخاصة بـ .NET. يقدم الأدوات لإدارة القوائم المقسمة ويساعدك على عرض بياناتك بطريقة محسنة باستخدام قدرات تصنيف وتصفية متقدمة.

الميزات:
- **تنفيذ التصفح**: التصفح البسيط والفعال استنادًا إلى رقم الصفحة وحجم الصفحة.
- **الترتيب المعقد**: تطبيق عمليات الترتيب المعقدة مع الأولوية والعديد من الحقول.
- **دعم العمليات غير المتزامنة (Async)**: تحسين الأداء من خلال العمليات غير المتزامنة.
- **سهل الاستخدام**: يعمل بسلاسة مع مشاريع .NET Core و Framework.

هذه الحزمة مثالية للمطورين الذين يحتاجون إلى تصفح ديناميكي ومرن، وهي مصممة خصيصًا لمشاريع .NET.

#### ⚙️ التثبيت والتكوين

##### 1. تثبيت الحزمة:

```bash
dotnet add package MehranPagination.Core
```

##### 2. التصفح والفرز

```csharp
var result = await db.Users.ToPaginatedListAsync(
    pageIndex: 1,
    pageSize: 10,
    sortOptions: new[] {
        new SortOption("Name", false, 1),
        new SortOption("Id", true, 2)
    });
```

##### 3. نتائج العرض:

```csharp
result.Items; // العناصر في الصفحة
result.PaginationInfo.TotalPages;
result.PaginationInfo.HasNextPage;
```

#### 📘 شرح

`ToPaginatedListAsync` و `ToPaginatedList` تحوّل `IQueryable<T>` إلى قائمة مجزأة تدعم الفرز:

- دعم مزامن وغير مزامن
- الفرز بحسب الأولوية
- يستخدم Expression Tree
- يعيد قائمة ومعلومات

---

## ✅ Features

- Smart sorting by priority
- Clean pagination metadata
- Flexible dynamic filtering
- Case-insensitive and type-safe comparisons
- Simple integration

---

Made with ❤️ by Mehran Ghaederahmat

