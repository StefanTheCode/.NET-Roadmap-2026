# نقشه راه عملی دات نت در سال 2026

**تنها راهنمایی که برای تبدیل شدن از صفر به یک توسعه‌دهنده دات نت آماده بازار کار نیاز دارید.**

---

## مقدمه: چرا بیشتر توسعه‌دهندگان شکست می‌خورند

بیایید صادق باشیم. بیشتر توسعه‌دهندگان دات نت نه به این دلیل شکست می‌خورند که باهوش نیستند، بلکه به این دلیل که چیزهای اشتباه را به ترتیب اشتباه یاد می‌گیرند.

الگوی معمول این است:

1. دیدن یک دوره 40 ساعته C#
2. پرش به سمت میکروسرویس‌ها و Clean Architecture
3. تلاش برای یادگیری همزمان Docker، Kubernetes، RabbitMQ و gRPC
4. ساختن صفر پروژه واقعی
5. عدم توانایی در مصاحبه فنی

**مشکل کمبود تلاش نیست. مشکل نبود جهت است.**

ویدیوهای تصادفی یوتیوب و دوره‌های "کامل" به شما درباره تکنولوژی‌ها آموزش می‌دهند، اما به شما یاد نمی‌دهند چگونه چیزهایی بسازید که شرکت‌ها واقعاً به آن نیاز دارند.

### این نقشه راه چه تفاوتی دارد

این نقشه راه بر اساس یک ایده ساخته شده: **یادگیری با ساختن، در ترتیب درست.**

هر مرحله دقیقاً مشابه کاری است که توسعه‌دهندگان واقعی دات نت در شرکت‌های واقعی انجام می‌دهند. شما Redis را چون در یک دیاگرام جذاب است یاد نمی‌گیرید - زمانی یاد می‌گیرید که API شما کند شده و به کش نیاز دارید.

بدون حاشیه. بدون "همه چیز را یاد بگیر". فقط مسیری که شما را استخدام می‌کند.

---

## مسیر واقعی توسعه‌دهنده دات نت

این هسته اصلی نقشه راه است. این مراحل را **به ترتیب** دنبال کنید. جلوتر نروید.

---

### مرحله ۱: ساخت اولین API

**چیزی که می‌سازید:** یک API ساده REST برای مدیریت taskها. کاربران می‌توانند task ایجاد کنند، بخوانند، ویرایش و حذف کنند.

**چیزهایی که باید یاد بگیرید:**

* مبانی C# (کلاس‌ها، interfaceها، async/await، LINQ)
* ASP.NET Core Minimal API یا Controller
* متدهای HTTP (GET، POST، PUT، DELETE) و status codeها
* Routing و model binding
* JSON serialization
* استفاده از Swagger/OpenAPI برای تست

**چیزهایی که فعلاً باید نادیده بگیرید:**

* احراز هویت
* پایگاه داده (از لیست in-memory استفاده کنید)
* Docker
* هر نوع design pattern پیچیده
* frontend frameworkها

**مثال واقعی:** هر شرکت ابزارهای داخلی CRUD دارد. اولین شغل شما شامل ساخت یا نگهداری همین endpointها خواهد بود.

**اشتباهات رایج:**

* پیچیده کردن ساختار پروژه قبل از درک اصول
* تلاش برای پیاده‌سازی Clean Architecture از روز اول
* ندانستن صحیح status codeها (مثلاً همیشه 200 برگرداندن)
* حذف async/await چون "بدون آن هم کار می‌کند"

**وقتی آماده رفتن به مرحله بعد هستید:**

* می‌توانید یک CRUD کامل بدون آموزش بسازید
* چرخه request/response را درک می‌کنید
* می‌توانید middleware را توضیح دهید
* با dependency injection آشنا هستید

**دسته‌بندی:**

| موضوع                | اولویت     |
| -------------------- | ---------- |
| مبانی C#             | MUST LEARN |
| ASP.NET Core Web API | MUST LEARN |
| Minimal APIs         | MUST LEARN |
| Controllers          | MUST LEARN |
| Swagger/OpenAPI      | MUST LEARN |

---

### مرحله ۲: اضافه کردن پایگاه داده

**چیزی که می‌سازید:** API قبلی را به پایگاه داده واقعی وصل می‌کنید. از PostgreSQL (یا SQL Server) با migration استفاده می‌کنید.

**چیزهایی که باید یاد بگیرید:**

* Entity Framework Core (Code First)
* DbContext و پیکربندی entityها
* migrationها (ایجاد، اجرا، rollback)
* مفاهیم پایه SQL
* Repository pattern (نسخه ساده، نه بیش‌مهندسی شده)
* connection string و تنظیمات (appsettings.json)

**چیزهایی که فعلاً باید نادیده بگیرید:**

* پایگاه داده NoSQL
* Dapper (بعداً به عنوان جایگزین)
* sharding یا replication
* CQRS

**مثال واقعی:** تقریباً همه اپلیکیشن‌های production از پایگاه داده رابطه‌ای استفاده می‌کنند.

**اشتباهات رایج:**

* یاد نگرفتن SQL واقعی
* ساخت repository عمومی روی DbContext (بی‌فایده)
* فراموش کردن migration در تیم
* استفاده بی‌دلیل از Include()

**وقتی آماده هستید:**

* می‌توانید EF Core را از صفر راه‌اندازی کنید
* migration می‌سازید و اجرا می‌کنید
* lazy vs eager loading را می‌فهمید
* SQL تولید شده را می‌خوانید

**دسته‌بندی:**

| موضوع                   | اولویت                 |
| ----------------------- | ---------------------- |
| EF Core                 | MUST LEARN             |
| SQL basics              | MUST LEARN             |
| PostgreSQL / SQL Server | MUST LEARN             |
| Migrations              | MUST LEARN             |
| Dapper                  | USE WHEN NEEDED        |
| NoSQL                   | OPTIONAL / SPECIALIZED |

---

### مرحله ۳: اعتبارسنجی، خطا و لاگ‌گیری

**چیزی که می‌سازید:** API آماده production با validation، مدیریت خطا و logging.

**چیزهایی که باید یاد بگیرید:**

* FluentValidation
* ProblemDetails
* middleware مدیریت سراسری خطا
* Serilog / ILogger
* Result pattern

**چیزهایی که نادیده بگیرید:**

* tracing توزیع‌شده
* ELK stack
* تعداد زیاد exception سفارشی

**مثال واقعی:** بدون logging درست، debugging در production غیرممکن است.

**اشتباهات رایج:**

* استفاده از exception برای flow کنترل
* عدم validation در API boundary
* log کردن داده حساس
* برگرداندن exception خام به client

**وقتی آماده هستید:**

* خطاها ProblemDetails دارند
* logها قابل جستجو هستند
* validation واضح است
* exception handler دارید

**دسته‌بندی:**

| موضوع                     | اولویت     |
| ------------------------- | ---------- |
| FluentValidation          | MUST LEARN |
| ProblemDetails            | MUST LEARN |
| Logging                   | MUST LEARN |
| Global exception handling | MUST LEARN |

---

### مرحله ۴: احراز هویت و مجوزدهی

**چیزی که می‌سازید:** API امن با JWT و role-based access.

**چیزهایی که باید یاد بگیرید:**

* JWT
* ASP.NET Core Identity
* Authorization policies
* Claims

**چیزهایی که نادیده بگیرید:**

* ساخت identity server
* OpenID Connect عمیق
* multi-tenancy

**مثال واقعی:** تقریباً همه SaaSها authentication دارند.

**اشتباهات رایج:**

* ذخیره JWT در localStorage
* token طولانی‌مدت
* hardcode کردن secret
* نبود refresh token

**وقتی آماده هستید:**

* JWT را از صفر پیاده‌سازی می‌کنید
* تفاوت auth و authz را می‌دانید
* endpointها را محافظت می‌کنید

**دسته‌بندی:**

| موضوع          | اولویت     |
| -------------- | ---------- |
| JWT            | MUST LEARN |
| Identity       | MUST LEARN |
| Authorization  | MUST LEARN |
| Refresh tokens | MUST LEARN |

---

### مرحله ۵: آماده‌سازی برای Production

**چیزی که می‌سازید:** API قابل deploy با Docker و CI/CD.

**چیزهایی که باید یاد بگیرید:**

* health checks
* configuration per environment
* Options pattern
* Docker
* GitHub Actions
* CORS و HTTPS

**اشتباهات رایج:**

* hardcode config
* نداشتن environment جدا
* Docker image سنگین
* حذف HTTPS

**وقتی آماده هستید:**

* اپ در Docker اجرا می‌شود
* health check دارید
* CI دارید

**دسته‌بندی:**

| موضوع         | اولویت     |
| ------------- | ---------- |
| Docker        | MUST LEARN |
| Health checks | MUST LEARN |
| CI/CD         | MUST LEARN |

---

### مرحله ۶: کارهای پس‌زمینه و پیام‌رسانی

**چیزی که می‌سازید:** سیستم notification و background processing.

**چیزهایی که باید یاد بگیرید:**

* BackgroundService
* Hangfire
* RabbitMQ

**اشتباهات رایج:**

* Task.Run در controller
* نداشتن retry
* استفاده زودهنگام از RabbitMQ

**وقتی آماده هستید:**

* background job دارید
* messaging را درک می‌کنید

---

### مرحله ۷: مقیاس‌پذیری و بهینه‌سازی

**چیزی که می‌سازید:** API سریع با caching و optimization.

**چیزهایی که باید یاد بگیرید:**

* Redis
* rate limiting
* pagination
* Polly

**اشتباهات رایج:**

* cache بدون invalidation
* نبود pagination
* optimize بدون اندازه‌گیری

---

### مرحله ۸: تست

**چیزی که می‌سازید:** سیستم تست کامل.

**چیزهایی که باید یاد بگیرید:**

* xUnit
* integration test
* WebApplicationFactory
* mocking

**اشتباهات رایج:**

* تست implementation به جای behavior
* mocking بیش از حد
* تست دیرهنگام

---

## چیزی که نباید یاد بگیرید (خلاصه)

### MUST LEARN

C#, ASP.NET Core, EF Core, SQL, JWT, Docker, Testing

### USE WHEN NEEDED

Redis, RabbitMQ, Polly, Dapper

### OPTIONAL

Microservices, Kubernetes, Kafka, GraphQL

---

## اگر من در 2026 شروع می‌کردم

* ماه 1: C# + API
* ماه 2: Database + Auth
* ماه 3: Docker + Testing

نه دوره‌های طولانی. نه میکروسرویس. فقط ساختن.

