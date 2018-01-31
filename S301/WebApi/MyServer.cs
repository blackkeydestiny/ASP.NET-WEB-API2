using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebApi
{
    /*
     * 自定义HttpServer：用于整个消息处理管道的龙头
     * 
     * **/
    public class MyHttpServer : HttpServer
    {
        /*
         * 一个参数的构造器：HttpConfiguration
         * 另一个默认为HttpRoutingDispatcher的HttpMessageHandler
         * **/
        public MyHttpServer(HttpConfiguration configuration)
            : base(configuration)
        { }

        public new void Initialize()
        {
            base.Initialize();
        }
    }
}