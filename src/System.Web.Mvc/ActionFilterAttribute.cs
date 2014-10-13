// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Web.Mvc
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public abstract class ActionFilterAttribute : FilterAttribute, IActionFilter, IResultFilter
    {
        // The OnXxx() methods are virtual rather than abstract so that a developer need override
        // only the ones that interest him.
        //这些onXXX（）方法是虚方法而不是抽象的，这样开发者需要重写只有那些他们关心的。

        public virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {
        }

        public virtual void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public virtual void OnResultExecuting(ResultExecutingContext filterContext)
        {
        }

        public virtual void OnResultExecuted(ResultExecutedContext filterContext)
        {
        }
    }
}
