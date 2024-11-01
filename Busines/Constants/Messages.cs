using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Constan
{
    public static class Messages
    {
        public static string AddedSuccesfully = "Başarıyla eklendi";
        public static string Error = "Hata";
        public static string UpdatedSuccessfully = "Başarıyla güncellendi";
        public static string DeletedSuccessfully = "Başarıyla silindi";
        public static string DataShownSuccessfully = "Başarıyla veriler listelendi";
        internal static string UserRegistered = "Kullanıcı başarıyla kayıt oldu";
        internal static string UserNotFound = "Kullanıcı bulunamadı.";
        internal static string PasswordError = "Hatalı şifre";
        internal static string SuccessfulLogin="Başarıyla giriş yapıldı";
        internal static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        internal static string AccessTokenCreated="Token yaratıldı";
    }
}
