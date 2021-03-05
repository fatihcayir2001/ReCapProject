using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime = "Sistem Bakımda";
        public static string CarListed = "Arabalar listelendi";
        public static string CarModelInvalid = "Araba mdoeli yanlış";
        public static string BrandInvalid = "Marka adı 2 karakterden kısa olamaz";
        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorNameInvalid = "Renk adık 2 karaktedrden kısa olmamalı";
        public static string OperationFailed = "Üzgünüm, Operasyon başarısız";
        public static string OperationSuccessful = "Operasyon Başarılı";
        public static string ImagesLimitExceeded = "Maximum resim sayısı aşıldı";
        public static string ImageAdded = "Resim başarıyla eklendi";
        public static string AuthorizationDenied = "Erişim izniniz yoktur.";
        public static string UserRegistered = "Kullanıcı kayıt oldu.";
        public static string AccessTokenCreated ="Token oluşturuldu.";
        public static string UserAlreadyExists="Üye mevcut.";
        public static string SuccessfulLogin="Giriş başarılı";
        public static string PasswordError="Şifre hatalı";
        public static string UserNotFound="Üye bulunamadı";
    }
}
