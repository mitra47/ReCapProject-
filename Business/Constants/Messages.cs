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
        //Crud
        public static string Added = "Ekleme işlemi başarıyla gerçekleştirildi.";
        public static string Updated = "Güncelleme işlemi başarıyla gerçekleştirildi.";
        public static string Delete = "Silme işlemi başarıyla gerçekleştirildi.";
        public static string Listed = "Listeleme işlemi başarıyla gerçekleştirildi";

        //Check
        public static string NameInvalid = "Girilen isim geçersiz.";
        //General
        public static string Undelivered = "Teslim edilmemis arac.";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarCountOfCategoryError= "En Fazla 10 Araç Ekleyebilirsiniz";
        public static string CarImageLimitExceeded = "More than 5 images cannot be added";
        public static string AuthorizationDenied = "Yetkiniz Yok.";
        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Sisteme giriş başarılı";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
    }
}
