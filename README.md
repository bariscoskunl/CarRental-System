# CarRentalSystem

ASP.NET Core MVC ve N-Tier Architecture (Çok Katmanlı Mimari) prensiplerine sadık kalınarak geliştirilmiş, kurumsal seviyede bir araç kiralama ve şube yönetim sistemi backend projesidir. 

Bu projede sürdürülebilir, gevşek bağlı (loosely coupled) ve tip güvenli (strongly typed) bir kod tabanı oluşturmak amacıyla hazır arayüz şablonları backend servisleriyle entegre edilmektedir.

---

## 🛠️ Kullanılan Teknolojiler & Kütüphaneler

* **Geliştirme Platformu:** .NET 8.0 / C#
* **Sunum Katmanı:** ASP.NET Core MVC (Model-View-Controller)
* **Veri Erişim & ORM:** Entity Framework Core & SQL Server
* **İş Mantığı & Haritalama:** AutoMapper (DTO ve Veri Transfer Güvenliği)
* **Altyapı Servisleri:** MailKit (Asenkron SMTP Email Yapısı), EPPlus (Excel Raporlama), iTextSharp (PDF Çıktı Yönetimi)
* **Kimlik Doğrulama:** ASP.NET Core Identity (Rol Tabanlı Yetkilendirme)

---

## 🏗️ Mimari Yapı (N-Tier Architecture)

Proje, sorumlulukların ayrılması (Separation of Concerns) ve SOLID prensipleri doğrultusunda 4 ana katmandan oluşmaktadır:

* **`CarRentalSystem.Entity`**: Veritabanı şemasına karşılık gelen domain modellerini (Varlıklar) ve sistem genelindeki seçenek listelerini (Enums) barındırır. Tamamen bağımsız ve hafiftir.
* **`CarRentalSystem.DataAccess`**: Veritabanı bağlamını (`CarRentalDbContext`), Fluent API model konfigürasyonlarını, migration dosyalarını ve Generic Repository kalıplarını içerir.
* **`CarRentalSystem.Business`**: Validasyonlar, iş kuralları, haritalama (Mapping) ve altyapı servislerinin (Email, Raporlama, SEO Friendly Slug) yönetildiği sistemin ana beynidir.
* **`CarRentalSystem.Web`**: Bağımlılıkların çözüldüğü (IoC Container), middleware hatlarının yönetildiği ve son kullanıcı arayüzünü besleyen ASP.NET Core MVC projesidir.

---

## 🗃️ Veritabanı İlişkileri & Tasarım Özellikleri

Veritabanı şeması oluşturulurken veri bütünlüğünü korumak ve SQL hatalarını önlemek amacıyla Fluent API konfigürasyonları uygulanmıştır:

* **Çoklu Şube Desteği:** Bir kiralama işleminin farklı lokasyonlarda başlayıp bitebilmesi için `Rental` tablosu, `Branch` tablosuna hem `PickupBranchId` hem de `ReturnBranchId` üzerinden çift yönlü bağlanmıştır.
* **Veri Güvenliği (Restrict Delete):** `Company` veya `Customer` silindiğinde finansal ve operasyonel kiralama geçmişinin kaybolmaması amacıyla ilişkisel yollarda `DeleteBehavior.Restrict` kuralları işletilmiş, SQL Server "Multiple Cascade Path" hataları engellenmiştir.
* **Performans & Benzersizlik:** Arama performansını artırmak ve mükerrer kayıtların önüne geçmek amacıyla `PlateNumber` (Plaka), `Email` ve `LicenseNumber` (Ehliyet No) gibi alanlar üzerinde benzersiz indeksler (`IsUnique`) tanımlanmıştır.

---

## 🚀 Geliştirme Yol Haritası

Proje, baştan sona planlı bir kronolojiyle şu fazlar halinde kodlanmaktadır:

1.  **Faz 1: Veri Tabanı ve Fluent API Konfigürasyonları** (✓ Tamamlandı)
2.  **Faz 2: ASP.NET Core Identity & Güvenlik Altyapısı** (Planlanan)
3.  **Faz 3: Generic Repository & Unit of Work Desenleri** (Planlanan)
4.  **Faz 4: Business Servisleri, DTO Tasarımları & AutoMapper Entegrasyonu** (Planlanan)
5.  **Faz 5: Infrastructure Servisleri (MailKit, Slug Extension, Raporlama)** (Planlanan)
6.  **Faz 6: MVC Controller ve View Modelleme Süreçleri** (Planlanan)