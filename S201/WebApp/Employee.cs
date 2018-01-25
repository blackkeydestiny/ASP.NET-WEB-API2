using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    /* 实例演示:通过 URL路出实现请求地址与 Web页面的怏射 **/

    /*
     * 
     * 第一步：创建员工模型
     * 
     * 
     * 
     * **/

    public class Employee
    {
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Gender { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string Department { get; private set; }

        public Employee(string id, string name, string gender,DateTime birthDate, string department)
        {
            this.Id = id;
            this.Name = name;
            this.Gender = gender;
            this.BirthDate = birthDate;
            this.Department = department;
        }
    }
}