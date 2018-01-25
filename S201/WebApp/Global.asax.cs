using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApp
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

            /*
             * 
             * 本地路由映射代码
             * 
             * System.Web.Routing.RouteTable的Routes属性得到了表示Route列表的system.Web.Routing.RouteCollection对象,
             * 并调用该列表对象的MapPageRoute方法将Default.aspx页面(-/Default aspx)与一个路由模板empIoyees/(name)/{idl)进行了映射
             * 
             * 
             * **/



            /*
             * RouteValueDictionary对象用于指定路由模板中路由变量{name}和{id}的默认值
             * 
             * 如果当前请求地址的后续部分缺失的话，它会采用提供的默认值对应该地址进行填充之后在进行模式匹配
             * 
             * **/

            var defaults = new RouteValueDictionary { { "name", "*" }, { "id", "*" } };

            /*
             * RouteCollection4个MapPageRoute的重载方法：
             * 
             * public Route MapPageRoute(string routeName, string routeUrl, string physicalFile, bool checkPhysicalUrlAccess, RouteValueDictionary defaults);
             * 
             * **/

            // 通过 URL路出实现 请求地址与Web页面的怏射
            // 请求 URL与 物理文件的分离

            RouteTable.Routes.MapPageRoute("", "employees/{name}/{id}", "~/default.aspx", true, defaults);
        }
    }
}