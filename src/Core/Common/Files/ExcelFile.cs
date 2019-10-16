﻿using System.Collections.Generic;

namespace Optivem.Framework.Core.Common.Files
{
    public class ExcelFile
    {
        public ExcelFile(List<ExcelSheet> sheets)
        {
            Sheets = sheets;
        }

        public List<ExcelSheet> Sheets { get; }
    }
}