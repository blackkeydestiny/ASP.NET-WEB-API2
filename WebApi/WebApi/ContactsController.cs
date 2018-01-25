using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebApi
{
    /*
    * 实例演示001 ： 第一个ASP.NET Web Api程序
    * 
    * 第二步
    * 
    * 这是—个空的类库项目,表现为HttpContro11er类型的Web API就定义在此项目中,它具有对Common的项目引用
    * 
    * WebApi项目对Controller的方法定义严格按照 REsTful Web API关 于 “使用标准的HTTP方法” 的指导方针,分别采用 GET、 POsT、 PUT和 DELETE
    * 作为获取、创建、修改和删除联系人的操作所支持的HTTP方法 
    * 
    * 但是IIS在默认情况下并不提供针对PUT和DELETE请求的支持, IIS拒绝PUT和DELETE请求是由默认注册的一个名为 “WebDAVModule” 的 自定义HttpModule导致的
    * 如果发生HTTP-PUT和HTTP-DELETE请求会报错 ： HTTP/1.1 405 Method Not Allowed
    * 所以从HttpModule中remove掉WebDAVModule即可
    * **/

    public class ContactsController : ApiController
    {
        static List<Contact> contacts;
        static int counter = 2;
        static ContactsController()
        {
            contacts = new List<Contact>();
            contacts.Add(new Contact { Id = "001", Name = "张三", PhoneNo = "0512-12345678", EmailAddress = "zhangsan@gmail.com", Address = "江苏省苏州市星湖街328号" });
            contacts.Add(new Contact { Id = "002", Name = "李四", PhoneNo = "0512-23456789", EmailAddress = "lisi@gmail.com", Address = "江苏省苏州市金鸡湖大道328号" });
        }
        public IEnumerable<Contact> Get(string id = null)
        {
            return from contact in contacts
                   where contact.Id == id || string.IsNullOrEmpty(id)
                   select contact;
        }
        public void Post(Contact contact)
        {
            Interlocked.Increment(ref counter);
            contact.Id = counter.ToString("D3");
            contacts.Add(contact);
        }

        public void Put(Contact contact)
        {
            contacts.Remove(contacts.First(c => c.Id == contact.Id));
            contacts.Add(contact);
        }

        public void Delete(string id)
        {
            contacts.Remove(contacts.First(c => c.Id == id));
        }
    }
}
