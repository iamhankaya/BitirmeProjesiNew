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
        public static string UserRegistered = "Kullanıcı başarıyla kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Hatalı şifre";
        public static string SuccessfulLogin="Başarıyla giriş yapıldı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string AccessTokenCreated="Token yaratıldı";
        public static string ProductSuccessfullyAddedToCart = "Ürün başarıyla sepete eklendi";
        internal static string ProductAlreadyInCart;
        internal static string ProductSuccessfullyRemovedFromCart;
    }
}
