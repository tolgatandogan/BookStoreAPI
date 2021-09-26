using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Core.Constans
{
    public static class Messages
    {
        public const string Unsuccessful = "Başarısız";
        public const string Successful = "Başarılı";
        public const string Inserted = "Kayıt eklendi.";
        public const string InsertedFail = "Veritabanına kayıt eklenirken hata oluştu.";
        public const string NotInserted = "Veritabanına kayıt eklenmedi.";
        public const string Modified = "Kayıt güncellendi.";
        public const string ModifiedFail = "Veritabanında kayıt güncellenirken hata oluştu.";
        public const string NotModified = "Veritabanında kayıt güncellenmedi.";
        public const string DataAlreadyExistsInTheSystem = "Kayıt zaten sistemde mevcuttur.";
        public const string DatabaseQueryError = "veritabanı sorgulama hatası";
        public const string HttpRequestError = "Http istek hatası";
        public const string FieldError = "Boş veya geçersiz değer gönderilemez.";

        public const string UserNotFound = "Kullanıcı bulunamadı";
        public const string PasswordError = "Şifre hatalı";
        public const string SuccessfulLogin = "Sisteme giriş başarılı";
        public const string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public const string UserRegistered = "Kullanıcı başarıyla kaydedildi";
    }
}