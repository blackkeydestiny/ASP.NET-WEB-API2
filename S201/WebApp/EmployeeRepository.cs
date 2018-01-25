using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    /* 实例演示:通过 URL路出实现请求地址与 Web页面的怏射 **/

    /*
     * 
     * 第二步：EmpIoyccRepository类型来维护员工列表的数据 
     * 
     * 
     * 
     * **/

    public class EmployeeRepository
    {
        private static IList<Employee> employees;
        static EmployeeRepository()
        {
            employees = new List<Employee>();
            employees.Add(new Employee(Guid.NewGuid().ToString(), "张三", "男", new DateTime(1981, 8, 24), "销售部"));
            employees.Add(new Employee(Guid.NewGuid().ToString(), "李四", "女", new DateTime(1982, 7, 10), "人事部"));
            employees.Add(new Employee(Guid.NewGuid().ToString(), "王五", "男", new DateTime(1981, 9, 21), "人事部"));
        }
        public IEnumerable<Employee> GetEmployees(string id = "")
        {
            /*
             * 根据指定的ID返回对应的员工对象，如果ID为"*"，则返回所有员工列表
             * 
             * **/
            return employees.Where(e => e.Id == id || string.IsNullOrEmpty(id) || id == "*");
        }
    }
}