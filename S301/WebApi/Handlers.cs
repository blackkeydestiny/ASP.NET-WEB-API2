using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace WebApi
{
    /*
     * 自定义的HttpMessageHandler类，继承DelegatingHandler：用于整个消息处理管道的中间(委托链)
     * 
     * **/
    public class FooHandler : DelegatingHandler{}

    public class BarHandler : DelegatingHandler{}

    public class BazHandler : DelegatingHandler{}
}