using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        private EmployeeRepository repository;

        public EmployeeRepository Repository
        {
            get { return repository ?? (repository = new EmployeeRepository()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.IsPostBack)
            {
                return;
            }

            // 获取员工Id
            /*
             * 
             *  由于所有员工列表和单一员工的详细信息均体现在该页面中,所以需要根据其请求地址
             *  来判断应该呈现怎样的数据 ,而这是通过RouteData属性表示的路由数据来实现的。 Page具
             *  有—个类型为System.Web.Routing.RouteData的RouteData属性,表示通过URL路由系统对
             *  当前请求进行解析得到的路 =由数据 。 RouteData的Values属性是一个存储路由变量的字典 ,
             *  其Key为变量名称。在如下所示的代码片段中,我们得到表示员工ID的路由变量
             *  (RouteData.Values["id"]),如果它是默认值("*"),表 示当前请求是针对员工列表的,反之
             *  则是针对指定的某个具体员工的
             * 
             * **/
            string employeeId = this.RouteData.Values["id"] as string;


            if (employeeId == "*" || string.IsNullOrEmpty(employeeId))
            {
                /*
                 * 员工列表
                 * **/
                this.GridViewEmployees.DataSource = this.Repository.GetEmployees();
                this.GridViewEmployees.DataBind();

                // 某一个员工详情不现实(DeatilsView)
                this.DetailsViewEmployee.Visible = false;
            }
            else
            {
                // 某一个员工详细信息
                var employees = this.Repository.GetEmployees(employeeId);
                this.DetailsViewEmployee.DataSource = employees;
                this.DetailsViewEmployee.DataBind();

                // 员工列表不显示(GridView)
                this.GridViewEmployees.Visible = false;
            }
        } 
    }
}