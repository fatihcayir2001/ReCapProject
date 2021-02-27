﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concerete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptor;
using DataAccess.Abstract;
using DataAccess.Concerete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<CarImageManager>().As<ICarImageService>();
            builder.RegisterType<FileManager>().As<IFileProcess>();
            
            
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

    }
}
