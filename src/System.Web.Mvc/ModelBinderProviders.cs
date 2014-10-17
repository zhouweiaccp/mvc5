// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace System.Web.Mvc
{
    /// <summary>
    /// 元数据1 扩展类
    /// </summary>
    public static class ModelBinderProviders
    {
        private static readonly ModelBinderProviderCollection _binderProviders = new ModelBinderProviderCollection
        {
        };

        public static ModelBinderProviderCollection BinderProviders
        {
            get { return _binderProviders; }
        }
    }
}
