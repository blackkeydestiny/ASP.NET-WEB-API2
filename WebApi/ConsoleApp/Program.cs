using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{


    /*
    * 
    * 
    * 实例演示001 ： 第一个ASP.NET Web Api程序
    * 
    * 第五步：
    *      利用HttpClient调用Web Api
    * 这是一个空的控制台应用 ,我们用它来模拟如何利用客户端代理来实现对Web API的远程调用,它具有针对Common的项目引用
    * 
    * 这里同样出现了步骤三的问题：
    * Syetem.IO.FileNotFoundException:
    * 
    * {"Could not load file or assembly 'Newtonsoft.Json, Version=4.5.0.0, Culture=neutral, PublicKeyToken=30ad4fe6b2a6aeed' 
    * or one of its dependencies. The system cannot find the file specified.":"Newtonsoft.Json, Version=4.5.0.0, Culture=neutral, 
    * PublicKeyToken=30ad4fe6b2a6aeed"}
    * 
    * **/
    class Program
    {
        static void Main(string[] args)
        {
            Process();
            Console.Read();
        }

        private async static void Process()
        {
            //获取当前联系人列表
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts");
            IEnumerable<Contact> contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            Console.WriteLine("当前联系人列表：");
            ListContacts(contacts);

            //添加新的联系人
            Contact contact = new Contact { Name = "王五", PhoneNo = "0512-34567890", EmailAddress = "wangwu@gmail.com" };
            await httpClient.PostAsJsonAsync<Contact>("http://localhost/selfhost/api/contacts", contact);
            Console.WriteLine("添加新联系人“王五”：");
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);

            //修改现有的某个联系人
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts/001");
            contact = (await response.Content.ReadAsAsync<IEnumerable<Contact>>()).First();
            contact.Name = "赵六";
            contact.EmailAddress = "zhaoliu@gmail.com";
            await httpClient.PutAsJsonAsync<Contact>("http://localhost/selfhost/api/contacts/001", contact);
            Console.WriteLine("修改联系人“001”信息：");
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);

            //删除现有的某个联系人
            await httpClient.DeleteAsync("http://localhost/selfhost/api/contacts/002");
            Console.WriteLine("删除联系人“002”：");
            response = await httpClient.GetAsync("http://localhost/selfhost/api/contacts");
            contacts = await response.Content.ReadAsAsync<IEnumerable<Contact>>();
            ListContacts(contacts);
        }

        private static void ListContacts(IEnumerable<Contact> contacts)
        {
            foreach (Contact contact in contacts)
            {
                Console.WriteLine("{0,-6}{1,-6}{2,-20}{3,-10}", contact.Id, contact.Name, contact.EmailAddress, contact.PhoneNo);
            }
            Console.WriteLine();
        }
    }
}
