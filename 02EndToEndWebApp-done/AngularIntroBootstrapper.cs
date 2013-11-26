using _02EndToEndWebApp_done.Model;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _02EndToEndWebApp_done
{
    public class AngularIntroBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(Nancy.TinyIoc.TinyIoCContainer container)
        {
            //base.ConfigureApplicationContainer(container);
            container.Register<ICustomerRepository, RavenCustomerRepository>().AsSingleton();
        }

    }
}