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
- Profil güncelleme ve şifre yenileme
- Randevu geçmişi
  
## Gelecek Özellikler

- Randevu bildirimleri
- Şifre hatırlatma
- Reçete ekleme
- En yakın eczane bulma
- Hastane ekleme ve yönetimi

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

![chrome-capture-2025-3-9](https://github.com/user-attachments/assets/6e5bb381-2a88-4fd1-84a7-605e5f351e3a)
![chrome-capture-2025-3-9 (1)](https://github.com/user-attachments/assets/4d95738c-9720-4742-9b7d-65a5a0b067a9)
![chrome-capture-2025-3-9 (2)](https://github.com/user-attachments/assets/50030f99-d2b8-4cd5-a077-6dc4f76e12de)
![chrome-capture-2025-3-9 (3)](https://github.com/user-attachments/assets/76357e62-e012-485e-b321-2ba796e617ae)
![chrome-capture-2025-3-9 (4)](https://github.com/user-attachments/assets/3dfcdbaf-2b90-4514-8ac7-7133fc8714f8)
![chrome-capture-2025-3-9 (5)](https://github.com/user-attachments/assets/c6d27c38-fbc7-4845-afd9-c9954cc5aa74)
![chrome-capture-2025-3-9 (6)](https://github.com/user-attachments/assets/4983113f-63be-4cf2-8033-226d9ac24b9c)
![chrome-capture-2025-3-9 (7)](https://github.com/user-attachments/assets/4f788ea1-bd25-4283-ad41-a141f7136ed4)
