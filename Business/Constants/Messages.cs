using System;
using Core.Entities.Concrete;

namespace Business.Constants
{
	public static class Messages
	{
		public static readonly string ProductAdd = "Product is added";
		public static readonly string ProductDelete = "Product is deleted";
		public static readonly string ProductUpdate = "Product is updated";

		public static readonly string CategoryAdd = "Category is added";
		public static readonly string CategoryDelete = "Category is deleted";
		public static readonly string CategoryUpdate = "Category is updated";
		
		public static readonly string UserNotFound = "User was not found";
		public static readonly string PasswordError = "Password is not correct";
		public static readonly string SuccessfulLogin = "Login is successful";
		public static readonly string UserAlreadyExists = "This Email is used";
		public static readonly string UserRegistered = "User is registered successfully";
		public static readonly string AccessTokenCreated = "Access Token is generated";
	}
}

