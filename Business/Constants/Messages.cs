using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araç başarıyla eklendi"; 
        public static string InvalidName = "Geçersiz isim";
        internal static string CarsListed = "Araçlar başarıyla listelendi.";
        internal static string CarUpdated = "Araç başarıyla güncellendi";
        internal static string CarDeleted = "Araç başarıyla silindi";

        internal static string MaintenanceTime = "Sistem Bakımda";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        internal static string UserUpdated = "Kullanıcı güncellendi";
        internal static string UserListed = "Kullanıcılar listelendi";

        internal static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        internal static string CustomerUpdated = "Müşteri güncellendi";
        internal static string CustomerListed = "Müşteriler listelendi";

        internal static string RentalAdded = "Araç başarıyla kiralandı";
        public static string RentalFailed = "Bu araç şu an kiradadır!";
        internal static string RentalDeleted = "Araç kiralama başarıyla silindi";
        internal static string RentalUpdated = "Araç kiralama başarıyla güncellendi";

        internal static string ColorAdded = "Renk başarıyla eklendi";
        internal static string ColorDeleted = "Renk başarıyla silindi";
        internal static string ColorUpdated = "Renk başarıyla güncellendi";
        internal static string ColorListed = "Renkler başarıyla listelendi";

        internal static string BrandAdded = "Marka başarıyla eklendi";
        internal static string BrandDeleted = "Marka başarıyla silindi";
        internal static string BrandUpdated = "Marka başarıyla güncellendi";
        internal static string BrandsListed = "Markalar başarıyla listelendi";
    }
}
