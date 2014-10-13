// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Reflection;

namespace System.Web.Mvc
{
    internal static class ActionDescriptorHelper
    {
        public static ICollection<ActionSelector> GetSelectors(MethodInfo methodInfo)
        {
            ActionMethodSelectorAttribute[] attrs = (ActionMethodSelectorAttribute[])methodInfo.GetCustomAttributes(typeof(ActionMethodSelectorAttribute), inherit: true);
            ActionSelector[] selectors = Array.ConvertAll(attrs, attr => (ActionSelector)(controllerContext => attr.IsValidForRequest(controllerContext, methodInfo)));
            return selectors;
        }

        public static ICollection<ActionNameSelector> GetNameSelectors(MethodInfo methodInfo)
        {
            ActionNameSelectorAttribute[] attrs = (ActionNameSelectorAttribute[])methodInfo.GetCustomAttributes(typeof(ActionNameSelectorAttribute), inherit: true);
            ActionNameSelector[] selectors = Array.ConvertAll(attrs, attr => (ActionNameSelector)((controllerContext, actionName) => attr.IsValidName(controllerContext, actionName, methodInfo)));
            return selectors;
        }

        public static bool IsDefined(MemberInfo methodInfo, Type attributeType, bool inherit)
        {
            return methodInfo.IsDefined(attributeType, inherit);
        }

        public static object[] GetCustomAttributes(MemberInfo methodInfo, bool inherit)
        {
            return methodInfo.GetCustomAttributes(inherit);
        }

        public static object[] GetCustomAttributes(MemberInfo methodInfo, Type attributeType, bool inherit)
        {
            return methodInfo.GetCustomAttributes(attributeType, inherit);
        }

        public static ParameterDescriptor[] GetParameters(ActionDescriptor actionDescriptor, MethodInfo methodInfo, ref ParameterDescriptor[] parametersCache)
        {
            ParameterDescriptor[] parameters = LazilyFetchParametersCollection(actionDescriptor, methodInfo, ref parametersCache);

            // need to clone array so that user modifications aren't accidentally stored
            // 需要复制数组以防用户修改意外存储
            return (ParameterDescriptor[])parameters.Clone();
        }

        private static ParameterDescriptor[] LazilyFetchParametersCollection(ActionDescriptor actionDescriptor, MethodInfo methodInfo, ref ParameterDescriptor[] parametersCache)
        {
            // Frequently called, so ensure the delegates remain static
            // 频繁调用，因此请确保委托保持不变
            return DescriptorUtil.LazilyFetchOrCreateDescriptors(
                cacheLocation: ref parametersCache,
                initializer: (CreateDescriptorState state) => state.MethodInfo.GetParameters(),
                converter: (ParameterInfo parameterInfo, CreateDescriptorState state) => new ReflectedParameterDescriptor(parameterInfo, state.ActionDescriptor),
                state: new CreateDescriptorState() { ActionDescriptor = actionDescriptor, MethodInfo = methodInfo });
        }

        // Used to pass generic arguments to frequently called delegates, so keep as a struct to prevent heap allocation
        // 用来传递泛型参数经常被称为委托，所以要为结构类型，以防止堆分配
        private struct CreateDescriptorState
        {
            internal ActionDescriptor ActionDescriptor;
            internal MethodInfo MethodInfo;
        }
    }
}
