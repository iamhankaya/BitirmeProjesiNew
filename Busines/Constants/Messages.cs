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
        internal static string UserRegistered;
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
    }
}
