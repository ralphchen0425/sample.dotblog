﻿using System;
using System.Web.Mvc;

namespace AspNet48.MVC
{
    public class InjectionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //初始化物件
            var member = new Member {Id = Guid.NewGuid(), Name =Faker.Name.FullName()};
            var key    = member.GetType().FullName;

            //注入到 HttpContextBase
            filterContext.RequestContext.HttpContext.Items[key] = member;
        }
    }
}