﻿// Copyright (c) Microsoft Open Technologies, Inc. All rights reserved. See License.txt in the project root for license information.

namespace WebMatrix.Data
{
    internal interface IDbFileHandler
    {
        IConnectionConfiguration GetConnectionConfiguration(string fileName);
    }
}
