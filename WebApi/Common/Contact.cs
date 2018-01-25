using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{

    /*
     * 实例演示001 ： 第一个ASP.NET Web Api程序
     *          
     * 第一步 ： 
     * Common是—个空的类库项目,仅仅定义了表示联系人的数据类型而己。之所以将数据类型定义在独立的项目中,主要是考虑到它会被多个项目(WebApi和ConsoleApp)所使用
     * 
     * **/

    public class Contact
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }
    }
}
