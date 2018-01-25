using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace SelfHost
{
    /*
     * 
     * 
     * 实例演示001 ： 第一个ASP.NET Web Api程序
     * 
     * 第四步：
     *      以Self host方法寄宿Web Api
     * 这是—个空的控制台应用,旨在模拟AsPNET Web API的self Host寄宿模式,它同样具有针对 WebApi的项目引用
     * 
     * 
     * **/

    class Program
    {
        static void Main(string[] args)
        {
            // 手动加载WebApi项目
            Assembly.Load("WebApi, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");


            /*
             * 这里又出现了步骤三的问题：
             * Syetem.IO.FileNotFoundException:
             * 
             * {"Could not load file or assembly 'Newtonsoft.Json, Version=4.5.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed' 
             * or one of its dependencies. The system cannot find the file specified.":"Newtonsoft.Json, Version=4.5.0.0, Culture=neutral, 
             * PublicKeyToken=30ad4fe6b2a6aeed"}
             * 
             * **/
            HttpSelfHostConfiguration configuration = new HttpSelfHostConfiguration("http://localhost/selfhost");
            using (HttpSelfHostServer httpServer = new HttpSelfHostServer(configuration))
            {
                httpServer.Configuration.Routes.MapHttpRoute(
                        name:"DefaultApi",
                        routeTemplate:"api/{controller}/{id}",
                        defaults: new { id = RouteParameter.Optional }
                    );

                httpServer.OpenAsync();
                Console.ReadKey();
            }
        }
    }
}
