using System;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramwork;
using Microsoft.Extensions.Configuration;

namespace Business.DependencyResolvers.Autofac
{
	public class AutofacBusinessModel : Module
	{

        protected override void Load(ContainerBuilder builder)
        {
            var config = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json")
                                        .Build();
            
            builder.RegisterInstance(config);
            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtTokenHelper>().As<ITokenHelper>();
            
        }
    }
}

