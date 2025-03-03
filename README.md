# Hastane Randevu Sistemi

Bu proje, .NET Core MVC ile katmanlı mimari kullanılarak geliştirilen bir web uygulamasıdır. **Şuan hala geliştirilme aşamasındadır.**

## Proje Hakkında

Hastane randevu sistemi, hastaların doktorlarla randevu oluşturmasına ve yönetmesine olanak tanır. Kullanıcı dostu arayüzü ve güvenli veri işleme yapısıyla, hastaneler için etkili bir randevu yönetim çözümü sunar.

## Canlı Demo

Projeyi canlı olarak [buradan](http://hospital-appointment.runasp.net/) deneyebilirsiniz.


## Mevcut Özellikler

- Admin paneli ile sistem yönetimi
- Hastanenin branş ve doktor yönetimi
- Doktor randevu açma işlevi
- Hasta kayıt ve giriş sistemi
- Randevu alma ve yönetme
  
## Gelecek Özellikler

- Profil güncelleme ve şifre yenileme
- Randevu geçmişi ve bildirimler
- Hastane ekleme

## Teknolojiler

- **.NET Core MVC**
- **Entity Framework Core**
- **MSSQL**
- **Autofac:** Autofac ile IoC konteyner ve AOP(Aspect-Oriented Programming)
- **Fluent Validation**
- **Auto Mapper**
- **Bootstrap**
- **JQuery**

## Katmanlı Mimari

Proje, katmanlı mimari kullanılarak geliştirilmiştir. Bu sayede, kodun sürdürülebilirliği ve yönetilebilirliği artırılmıştır. Aşağıda, katmanların kısa bir açıklaması yer almaktadır:

- **Presentation Layer (Sunum Katmanı):** Kullanıcı arayüzünü ve kullanıcı etkileşimlerini içerir. (ASP.NET Core Razor Pages)
- **Business Logic Layer (İş Mantığı Katmanı):** İş kurallarının ve iş akışlarının yer aldığı katmandır.
- **Data Access Layer (Veri Erişim Katmanı):** Veritabanı işlemlerinin gerçekleştirildiği katmandır. (Entity Framework Core)
- **Entities (Varlıklar Katmanı):** Projeye özgü veri modellerinin tanımlandığı katmandır.
- **Core Layer (Çekirdek Katmanı):** Projenin temel yapı taşlarını ve genel işlevsellikleri içeren katmandır. Ortak arayüzler ve servisler burada yer alır.
- **DTO Layer (Veri Transfer Nesneleri Katmanı):** Veritabanı ile uygulama arasında veri taşımak için kullanılan DTO'ları içeren katmandır. 

## Ekran Görüntüleri

![chrome-capture-2025-3-4 (2)](https://github.com/user-attachments/assets/65cabcab-7c4d-47f1-8418-51eea9fbcdbe)
![chrome-capture-2025-3-4 (3)](https://github.com/user-attachments/assets/9120aecd-2fe4-4049-a08f-dd19c0bedb22)
![chrome-capture-2025-3-4 (7)](https://github.com/user-attachments/assets/70328db0-261f-4867-bd53-6359e31718da)
![chrome-capture-2025-3-4 (5)](https://github.com/user-attachments/assets/1281443c-a35b-4644-89fe-24fa3033237c)
![chrome-capture-2025-3-4 (6)](https://github.com/user-attachments/assets/7be93752-c807-4567-bf23-85a74e5e65df)
![chrome-capture-2025-3-4](https://github.com/user-attachments/assets/aff30dea-82fa-4db3-a271-bf736e65c255)
![chrome-capture-2025-3-4 (1)](https://github.com/user-attachments/assets/75415993-1acd-4a5f-afc1-1b1fcf48d7e2)

