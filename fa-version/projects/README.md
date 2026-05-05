ترجمه با حفظ کامل ساختار:

---

# پروژه‌های پورتفولیو

راهنمای دقیق برای هر پروژه پورتفولیو از نقشه راه.

---

## پروژه ۱: TaskFlow API

**مرحله:** ۱-۳ | **سطح سختی:** مبتدی

یک API مدیریت task. شامل عملیات CRUD، پایگاه داده، اعتبارسنجی، مدیریت خطا و لاگ‌گیری.

### شروع کار

1. ایجاد یک پروژه ASP.NET Core Web API جدید
2. استفاده از قالب‌های داخل `/templates` به عنوان نقطه شروع
3. دنبال کردن مراحل ۱ تا ۳ در نقشه راه

### قابلیت‌های اصلی

* ایجاد، خواندن، ویرایش، حذف taskها
* دسته‌بندی و tagها
* تاریخ سررسید و وضعیت تکمیل
* لیست taskهای مخصوص هر کاربر (بعد از مرحله ۴)

### ایده‌های توسعه (سطح Senior)

* ثبت کامل تغییرات (audit trail) همراه با زمان و کاربر
* حذف نرم (soft delete) با قابلیت بازیابی
* اولویت‌بندی taskها با مرتب‌سازی drag-and-drop
* taskهای تکرارشونده با قوانین زمان‌بندی
* خروجی گرفتن به CSV/PDF

---

## پروژه ۲: AuthGuard

**مرحله:** ۴ | **سطح سختی:** مبتدی-متوسط

یک سرویس احراز هویت مستقل با JWT، refresh token و مدیریت نقش‌ها.

### قابلیت‌های اصلی

* ثبت‌نام کاربر با هش رمز عبور (BCrypt)
* ورود با تولید JWT
* چرخش refresh token
* نقش‌ها (Admin، User)

### ایده‌های توسعه (سطح Senior)

* احراز هویت دو مرحله‌ای (TOTP با QR code)
* قفل شدن حساب بعد از چند تلاش ناموفق
* اتصال OAuth2 (Google، GitHub)
* مدیریت API key برای سرویس‌ها
* فرایند بازیابی رمز عبور با ایمیل

---

## پروژه ۳: ShipReady

**مرحله:** ۵ | **سطح سختی:** متوسط

یک قالب API آماده production با تمام زیرساخت‌ها.

### قابلیت‌های اصلی

* Docker چندمرحله‌ای
* docker-compose با PostgreSQL، Redis، Seq
* health check
* مدیریت configuration
* CI/CD با GitHub Actions

### ایده‌های توسعه (سطح Senior)

* tracing با OpenTelemetry
* metrics با Prometheus
* استقرار با Terraform
* deployment چند محیطی (staging → production)
* اسکن امنیتی در CI (Trivy، dotnet-security)

---

## پروژه ۴: NotifyMe

**مرحله:** ۶ | **سطح سختی:** متوسط

سرویس ارسال اعلان (ایمیل/SMS) بر اساس event یا زمان‌بندی.

### قابلیت‌های اصلی

* background service برای پردازش اعلان‌ها
* jobهای زمان‌بندی شده با Hangfire
* ارسال ایمیل (SMTP یا SendGrid)
* مصرف پیام از RabbitMQ

### ایده‌های توسعه (سطح Senior)

* چند کانال ارسال (ایمیل، SMS، push)
* تنظیمات شخصی اعلان برای هر کاربر
* پیگیری وضعیت ارسال و read receipt
* سیستم template برای محتوا
* مدیریت dead-letter queue با داشبورد

---

## پروژه ۵: SpeedShop

**مرحله:** ۷ | **سطح سختی:** متوسط-پیشرفته

API فروشگاه آنلاین با تمرکز بر performance.

### قابلیت‌های اصلی

* مدیریت محصولات و دسته‌بندی
* جستجو و فیلتر
* سبد خرید
* caching با Redis
* pagination مبتنی بر cursor
* rate limiting

### ایده‌های توسعه (سطح Senior)

* جستجوی full-text در PostgreSQL
* مدیریت موجودی با optimistic concurrency
* سیستم webhook برای eventهای سفارش
* benchmark با BenchmarkDotNet
* نسخه‌بندی API با backward compatibility

---

## پروژه ۶: TestCraft

**مرحله:** ۸ | **سطح سختی:** متوسط

پروژه مخصوص نمایش مهارت تست‌نویسی کامل.

### قابلیت‌های اصلی

* تست واحد با xUnit
* تست یکپارچه با WebApplicationFactory
* تست دیتابیس با Testcontainers
* mock کردن سرویس‌های خارجی
* test data builder

### ایده‌های توسعه (سطح Senior)

* تست معماری با NetArchTest
* contract testing برای مصرف‌کننده‌ها
* mutation testing
* گزارش coverage در CI
* تست فشار با k6 یا NBomber

---

## پروژه ۷: ModularHub

**مرحله:** همه مراحل | **سطح سختی:** پیشرفته

یک monolith ماژولار شامل تمام مفاهیم یادگرفته شده (Users، Tasks، Notifications) با مرزهای مشخص.

### قابلیت‌های اصلی

* ساختار ماژولار
* هر ماژول DbContext مستقل
* ارتباط بین ماژول‌ها با event
* shared kernel برای موارد مشترک
* تمام مفاهیم مراحل ۱ تا ۸

### ایده‌های توسعه (سطح Senior)

* استخراج یک ماژول به microservice
* feature flag برای هر ماژول
* health check در سطح ماژول
* مستندسازی ADR
* API gateway برای routing ماژول‌ها

---

## نحوه ارائه در GitHub

1. **هر پروژه یک repository جدا داشته باشد**
2. **README واضح بنویسید شامل:**

   * توضیح پروژه
   * نحوه اجرا (`docker-compose up`)
   * لینک Swagger
   * دیاگرام ساده معماری
3. **حتماً تست داشته باشید** - مهم‌ترین معیار برای استخدام
4. **از conventional commits استفاده کنید**
5. **CI badge اضافه کنید** - نشان می‌دهد پروژه build می‌شود

---

### نمونه بخش badge در README

```markdown
![Build Status](https://github.com/yourusername/taskflow-api/actions/workflows/ci.yml/badge.svg)
![.NET](https://img.shields.io/badge/.NET-9.0-purple)
![License](https://img.shields.io/badge/license-MIT-blue)
```
