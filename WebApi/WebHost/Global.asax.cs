using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.SessionState;

namespace WebHost
{

    /*
     * 实例演示001 ： 第一个ASP.NET Web Api程序
     * 
     * 第三步:
     * 
     * 这是—个空的AsPNET Web应用,它实现了针对AsPNET Web API的Web Host寄 宿,该项目具有针对WebApi的项目引用 。
     * 
     * 注意：这各项目会出现两个问题
     *      1、Could not load file or assembly 'Newtonsoft.Json, Version=4.5.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed'
     *         原因，为项目添加Newtonsoft.Json.dll
     *      2、一定要对WebApi的项目进行引用，否则通过url访问时，报出没有匹配的controller
     * 
     * WebHost项目主要演示：以Web Host方法寄宿Web Api
     *      测试方法：http://localhost/webhost/api/contacts
     *               http://localhost/webhost/api/contacts/001
     *               http://localhost/webhost/api/contacts/002
     *      
     *      测试工具：Fidder
     * **/
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );

        }



        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}