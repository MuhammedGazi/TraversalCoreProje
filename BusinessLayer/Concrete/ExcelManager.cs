﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using OfficeOpenXml;

namespace BusinessLayer.Concrete
{
    public class ExcelManager : IExcelService
    {
        public byte[] ExcelList<T>(List<T> t) where T : class
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
                workSheet.Cells["A1"].LoadFromCollection(t,true,OfficeOpenXml.Table.TableStyles.Light10);
                return excel.GetAsByteArray();
            }
        }
    }
}

