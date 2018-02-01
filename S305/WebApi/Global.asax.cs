using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApi
{
public class WebApiApplication : System.Web.HttpApplication
{
    protected void Application_Start()
    {
        // 1、添加自定义的HttpMessageHandler到消息处理管道
        GlobalConfiguration.Configuration.MessageHandlers.Add(new HttpMethodOverrideHandler());

        // 2、注册路由
        AreaRegistration.RegisterAllAreas();
        GlobalConfiguration.Configure(WebApiConfig.Register);
    }
}
}
