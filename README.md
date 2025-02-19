# Hastane Randevu Sistemi

Bu proje, .NET Core ile katmanlı mimari kullanılarak geliştirilen bir web uygulamasıdır. **Şuan hala geliştirilme aşamasındadır.**

## Proje Hakkında

Hastane randevu sistemi, hastaların doktorlarla randevu oluşturmasına ve yönetmesine olanak tanır. Kullanıcı dostu arayüzü ve güvenli veri işleme yapısıyla, hastaneler için etkili bir randevu yönetim çözümü sunar.

## Canlı Demo

Projeyi canlı olarak [buradan](http://hospital-appointment.runasp.net/) deneyebilirsiniz.


## Mevcut Özellikler

- Admin paneli ile sistem yönetimi
- Hastanenin branş ve doktor yönetimi
  
## Gelecek Özellikler

- Kullanıcı kayıt ve giriş sistemi
- Doktor ve hasta profilleri
- Randevu oluşturma ve yönetme
- Randevu geçmişi ve bildirimler
- Hastane ekleme

## Teknolojiler

- **.NET Core:**
- **Razor Pages:**
- **Entity Framework Core:**
- **MSSQL:**
- **Autofac:** Autofac ile IoC konteyner ve AOP(Aspect-Oriented Programming)
- **Fluent Validation:**
- **Auto Mapper:**

## Katmanlı Mimari

Proje, katmanlı mimari kullanılarak geliştirilmiştir. Bu sayede, kodun sürdürülebilirliği ve yönetilebilirliği artırılmıştır. Aşağıda, katmanların kısa bir açıklaması yer almaktadır:

- **Presentation Layer (Sunum Katmanı):** Kullanıcı arayüzünü ve kullanıcı etkileşimlerini içerir. (ASP.NET Core Razor Pages)
- **Business Logic Layer (İş Mantığı Katmanı):** İş kurallarının ve iş akışlarının yer aldığı katmandır.
- **Data Access Layer (Veri Erişim Katmanı):** Veritabanı işlemlerinin gerçekleştirildiği katmandır. (Entity Framework Core)
- **Entities (Varlıklar Katmanı):** Projeye özgü veri modellerinin tanımlandığı katmandır.
- **Core Layer (Çekirdek Katmanı):** Projenin temel yapı taşlarını ve genel işlevsellikleri içeren katmandır. Ortak arayüzler ve servisler burada yer alır.
- **DTO Layer (Veri Transfer Nesneleri Katmanı):** Veritabanı ile uygulama arasında veri taşımak için kullanılan DTO'ları içeren katmandır. 

## Ekran Görüntüleri

![chrome-capture-2025-2-17](https://github.com/user-attachments/assets/f55a9207-5745-4a25-ace2-aa917bc4e022)
![chrome-capture-2025-2-17 (1)](https://github.com/user-attachments/assets/83c05853-4ac0-433e-8b3c-0b3af05c4834)
![chrome-capture-2025-2-17 (2)](https://github.com/user-attachments/assets/6e8ef473-8298-48d2-a94f-30716bed485b)
![chrome-capture-2025-2-17 (3)](https://github.com/user-attachments/assets/290840b9-e5de-459e-963f-a7ede161fd0c)
