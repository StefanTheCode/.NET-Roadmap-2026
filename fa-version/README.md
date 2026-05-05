# نقشه راه عملی دات نت در سال 2026

**تنها راهنمایی که برای تبدیل شدن از صفر به یک توسعه‌دهنده دات نت آماده بازار کار نیاز دارید.**

بدون حاشیه. بدون لیست‌های تصادفی از تکنولوژی‌ها. فقط یک مسیر شفاف که دقیقاً بازتاب‌دهنده نحوه ساخت اپلیکیشن‌های واقعی توسط توسعه‌دهندگان واقعی است.

---

## داخل این مخزن چه چیزهایی هست

### [نقشه راه کامل](docs/roadmap.md)

یک راهنمای گام‌به‌گام کامل شامل:

* ۸ مرحله پیوسته از اولین API تا استقرار در محیط production
* دسته‌بندی MUST و OPTIONAL برای هر تکنولوژی
* طرز فکر معماری در دنیای واقعی
* ۷ پروژه پورتفولیو به همراه ایده‌های توسعه
* یک برنامه یادگیری ۱۲ هفته‌ای
* چه چیزهایی را یاد نگیرید (که ماه‌ها در زمان شما صرفه‌جویی می‌کند)
* توصیه‌های صادقانه برای گرفتن اولین شغل دات نت

### [تمپلیت‌های کد همراه](templates/)

کدهای شروع آماده برای production:

* [Program.cs](templates/Program.cs) - تنظیمات حداقلی آماده برای production
* [Endpoints](templates/Endpoints/TaskEndpoints.cs) - API کامل CRUD با Minimal APIs
* [DbContext](templates/Data/AppDbContext.cs) - EF Core با پیکربندی صحیح entityها
* [DI Registration](templates/DependencyInjection.cs) - رجیستر کردن تمیز سرویس‌ها
* [Dockerfile](templates/Dockerfile) - چندمرحله‌ای، مبتنی بر Alpine، بدون دسترسی root
* [docker-compose.yml](templates/docker-compose.yml) - استک کامل توسعه لوکال
* [CI/CD Pipeline](templates/.github/workflows/ci.yml) - GitHub Actions
* [appsettings.json](templates/appsettings.json) - تنظیمات ساختاریافته با Serilog

**نمونه کدها:**

* [Logging](templates/Examples/LoggingExample.cs) - الگوهای لاگ‌گیری ساختاریافته
* [Validation](templates/Examples/ValidationExample.cs) - راه‌اندازی FluentValidation
* [Error Handling](templates/Examples/ErrorHandlingExample.cs) - ProblemDetails + مدیریت سراسری خطا

### [چک‌لیست‌ها](checklists/)

پیگیری پیشرفت شما:

* [چک‌لیست گام‌به‌گام](checklists/step-by-step-checklist.md) - دقیقاً بدانید چه زمانی آماده رفتن به مرحله بعد هستید
* [آمادگی برای Production](checklists/production-readiness.md) - بررسی قبل از استقرار
* [پیگیری پیشرفت ۱۲ هفته‌ای](checklists/weekly-progress.md) - در مسیر بمانید

---

## ساختار مخزن

```id="r8a2m1"
Roadmap 2026/
│
├── README.md                          ← شما اینجا هستید
│
├── docs/
│   └── roadmap.md                     ← راهنمای کامل نقشه راه
│
├── templates/                         ← کدهای آماده برای production
│   ├── Program.cs                     ← نقطه ورود اپلیکیشن با پایپ‌لاین کامل
│   ├── DependencyInjection.cs         ← الگوهای رجیستر کردن سرویس‌ها
│   ├── appsettings.json               ← قالب تنظیمات
│   ├── appsettings.Development.json   ← تنظیمات مخصوص محیط توسعه
│   ├── Dockerfile                     ← بیلد چندمرحله‌ای Docker
│   ├── docker-compose.yml             ← استک توسعه لوکال (DB، Redis، Seq)
│   ├── .gitignore                     ← gitignore استاندارد دات نت
│   │
│   ├── Endpoints/
│   │   └── TaskEndpoints.cs           ← نمونه CRUD با Minimal API
│   │
│   ├── Data/
│   │   └── AppDbContext.cs            ← کانتکست EF Core + entityها
│   │
│   ├── Examples/
│   │   ├── LoggingExample.cs          ← لاگ‌گیری ساختاریافته با Serilog
│   │   ├── ValidationExample.cs       ← الگوهای FluentValidation
│   │   └── ErrorHandlingExample.cs    ← ProblemDetails + مدیریت خطا
│   │
│   └── .github/
│       └── workflows/
│           └── ci.yml                 ← پایپ‌لاین CI/CD با GitHub Actions
│
├── checklists/                        ← پیگیری پیشرفت
│   ├── step-by-step-checklist.md      ← چک‌لیست تکمیل هر مرحله
│   ├── production-readiness.md        ← چک‌لیست قبل از استقرار
│   └── weekly-progress.md             ← پیگیری پیشرفت ۱۲ هفته‌ای
│
└── projects/                          ← راهنمای پروژه‌های پورتفولیو
    └── README.md                      ← توضیحات پروژه‌ها و نحوه راه‌اندازی
```

### هر بخش برای چه کاری است

| Folder        | Purpose                                     |
| ------------- | ------------------------------------------- |
| `docs/`       | مستند نقشه راه و راهنماهای تکمیلی           |
| `templates/`  | کدهای آماده برای استفاده در پروژه‌های واقعی |
| `checklists/` | پیگیری پیشرفت یادگیری و آمادگی برای استقرار |
| `projects/`   | راهنماهای کامل برای هر پروژه پورتفولیو      |

---

## شروع سریع

1. **بخوانید** [نقشه راه](docs/roadmap.md) - درک مسیر کامل
2. **بررسی کنید** [چک‌لیست مرحله ۱](checklists/step-by-step-checklist.md) - نقطه شروع خود را بدانید
3. **کپی کنید** [تمپلیت‌ها](templates/) را در اولین پروژه خود
4. **بسازید** - برنامه ۱۲ هفته‌ای را دنبال کنید
5. **پیگیری کنید** پیشرفت خود را با [پیگیری هفتگی](checklists/weekly-progress.md)

---

## مسیر

```id="y7f4k2"
مرحله ۱: ساخت اولین API              → هفته ۱-۲
مرحله ۲: اضافه کردن پایگاه داده      → هفته ۳-۴
مرحله ۳: اعتبارسنجی، خطا و لاگ‌گیری → هفته ۵-۶
مرحله ۴: احراز هویت                  → هفته ۷-۸
مرحله ۵: آمادگی برای Production      → هفته ۹-۱۰
مرحله ۶: کارهای پس‌زمینه             → هفته ۱۱
مرحله ۷: مقیاس‌پذیری و بهینه‌سازی   → هفته ۱۱-۱۲
مرحله ۸: تست‌نویسی                  → هفته ۱۲
```

هر مرحله بر اساس مرحله قبلی ساخته می‌شود. جلوتر نپرید.

---

## این برای چه کسانی است

* **مبتدی‌ها** که می‌خواهند مسیر واضحی برای ورود به توسعه بک‌اند دات نت داشته باشند
* **توسعه‌دهندگان خودآموخته** که از آموزش‌های پراکنده خسته شده‌اند
* **تغییر مسیر شغلی‌دهندگان** که می‌خواهند سریع وارد بازار کار شوند
* **توسعه‌دهندگان جونیور** که می‌خواهند خلأهای خود را پر کنند و رشد کنند

## این برای چه کسانی نیست

* توسعه‌دهندگانی که دنبال مرجع کامل همه تکنولوژی‌های دات نت هستند
* توسعه‌دهندگان فرانت‌اند (این مسیر متمرکز بر بک‌اند/API است)
* افرادی که تئوری بدون عمل می‌خواهند

---

## استک تکنولوژی (در بستر نیاز، نه تصادفی)

این تکنولوژی‌ها **در زمانی که به آن‌ها نیاز دارید** معرفی می‌شوند، نه به‌صورت یک لیست خرید:

| چه زمانی         | چه چیزی استفاده می‌کنید        |
| ---------------- | ------------------------------ |
| ساخت API         | ASP.NET Core، Minimal APIs     |
| اضافه کردن داده  | EF Core، PostgreSQL            |
| اعتبارسنجی ورودی | FluentValidation               |
| مدیریت خطا       | ProblemDetails                 |
| لاگ‌گیری         | Serilog                        |
| احراز هویت       | JWT، ASP.NET Core Identity     |
| استقرار          | Docker، GitHub Actions         |
| کشینگ            | Redis، Output Caching          |
| پردازش پس‌زمینه  | BackgroundService، MassTransit |
| تست              | xUnit، WebApplicationFactory   |
| تاب‌آوری         | Polly                          |

---

## مشارکت

اگر موردی اشتباه است یا پیشنهادی دارید، یک Issue باز کنید یا PR ارسال کنید.

---

## لایسنس

این نقشه راه رایگان است و می‌توانید از آن استفاده، آن را به اشتراک بگذارید و تغییر دهید. اگر برایتان مفید بود، آن را با کسی که به آن نیاز دارد به اشتراک بگذارید.

---

*ساخته شده توسط توسعه‌دهندگانی که این مسیر را طی کرده‌اند و می‌خواهند آن را برای نسل بعدی ساده‌تر کنند.*
