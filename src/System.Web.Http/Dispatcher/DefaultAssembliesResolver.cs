// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
/********环境描述、问题的发现
在项目运用中，我们大多数会把控制器部分从主程序抽离出来放置单独的项目中，这种情况下在使用ASP.NET MVC框架的项目环境中是不会有什么问题的，因为MVC框架在创建控制器的时候会加载当前主程序引用的所有程序集并且按照执行的搜索规则（公共类型、实现IController的）搜索出控制器类型并且缓存到xml文件中。而这种方式如果在使用了默认的ASP.NET Web API框架环境下就会有一点点的问题，这里就涉及到了Web API框架的控制器创建过程中的知识。来看一下简单的示例。*******/
namespace System.Web.Http.Dispatcher
{
    /// <summary>
    /// Provides an implementation of <see cref="IAssembliesResolver"/> with no external dependencies.
    /// </summary>
    public class DefaultAssembliesResolver : IAssembliesResolver
    {
        /// <summary>
        /// Returns a list of assemblies available for the application.
        /// http://www.cnblogs.com/jin-yuan/p/3898606.html 可能bug
        /// </summary>
        /// <returns>A <see cref="Collection{Assembly}"/> of assemblies.</returns>
        public virtual ICollection<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().ToList();
        }
    }
}
