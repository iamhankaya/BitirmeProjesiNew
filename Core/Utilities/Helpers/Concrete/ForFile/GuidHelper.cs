﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.Concrete.ForFile
{
    public static class GuidHelper
    {
        public static string Create()
        {
            return Guid.NewGuid().ToString();
        }
    }
}
