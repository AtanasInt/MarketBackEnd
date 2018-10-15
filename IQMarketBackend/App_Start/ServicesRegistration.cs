using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IQMarketBackend.DI;
using IQMarketBackend;
using IQMarketBackend.DI.impl;

namespace IQMarketBackend.App_Start
{
    public class ServicesRegistration : Module
    { 
        private string connStr;

    public ServicesRegistration(string connString)
    {
        this.connStr = connString;
    }
    protected override void Load(ContainerBuilder builder)
    {

        builder.RegisterType<ClientsService>().As<IClientsService>().InstancePerRequest();
        builder.RegisterType<CampaignService>().As<ICampaignService>().InstancePerRequest();
        builder.RegisterType<ApplicationService>().As<IApplicationService>().InstancePerRequest();
        builder.RegisterType<ProductService>().As<IProductService>().InstancePerRequest();
        builder.RegisterType<UnitTypeService>().As<IUnitTypeService>().InstancePerRequest();
        builder.RegisterType<ExchangeRateListService>().As<IExchangeRateListService>().InstancePerRequest();
        builder.RegisterType<AppMenuService>().As<IAppMenuService>().InstancePerRequest();


            base.Load(builder);


    }
}



}