using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç başarıyla eklendi"; 
        public static string InvalidName = "Geçersiz isim";
        public static string CarsListed = "Araçlar başarıyla listelendi.";
        public static string CarUpdated = "Araç başarıyla güncellendi";
        public static string CarDeleted = "Araç başarıyla silindi";

        public static string MaintenanceTime = "Sistem Bakımda";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string UserUpdated = "Kullanıcı güncellendi";
        public static string UserListed = "Kullanıcılar listelendi";

        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomerListed = "Müşteriler listelendi";

        public static string RentalAdded = "Araç başarıyla kiralandı";
        public static string RentalFailed = "Bu araç şu an kiradadır!";
        public static string RentalDeleted = "Araç kiralama başarıyla silindi";
        public static string RentalUpdated = "Araç kiralama başarıyla güncellendi";

        public static string ColorAdded = "Renk başarıyla eklendi";
        public static string ColorDeleted = "Renk başarıyla silindi";
        public static string ColorUpdated = "Renk başarıyla güncellendi";
        public static string ColorListed = "Renkler başarıyla listelendi";

        public static string BrandAdded = "Marka başarıyla eklendi";
        public static string BrandDeleted = "Marka başarıyla silindi";
        public static string BrandUpdated = "Marka başarıyla güncellendi";
        public static string BrandsListed = "Markalar başarıyla listelendi";

        public static string CarImageAdded = "Araç resmi başarıyla eklendi";
        public static string CarImageDeleted = "Araç resmi başarıyla silindi";
        public static string CarImageUpdated = "Araç resmi başarıyla güncellendi";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PasswordError = "Şifre hatalı";

        public static string SuccessfulLogin = "Sisteme giriş başarılı";

        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";

        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string BrandLimitExceded = "Marka sayı limiti aşıldı";

        public static string CarCountOfBrandError = "Bu markada en fazla 5 araç ekleyebilirsiniz";

        public static string CarNameAlreadyExists = "Bu isimde araç zaten var";

        
    }
}
