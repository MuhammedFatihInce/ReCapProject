using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
	public static class Messages
	{
		public static string ProductAdded = "Ürün eklendi";
		public static string ProductModified = "Ürün güncellendi";
		public static string ProductDeleted = "Ürün silindi";
		public static string ProductNameInvalid = "Ürün ismi geçersiz";
		public static string MaintenanceTime = "Sistem bakımda";
		public static string ProductsListed = "Ürünler listelendi";
		public static string DeliveryStatus = "Araba müşteride";
		public static string UserRegistered = "Kayıt oldu.";
		public static string UserNotFound = "Kullanıcı bulunamadı";
		public static string PasswordError = "Kullanıcı hatası";
		public static string SuccessfulLogin = "Başarılı giriş.";
		public static string UserAlreadyExists = "Kullanıcı mevcut";
		public static string AccessTokenCreated = "Token oluşturuldu.";
		public static string AuthorizationDenied = "Yetkiniz yok.";
	}
}
