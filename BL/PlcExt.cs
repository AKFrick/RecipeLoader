using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using S7.Net;

namespace RecipeLoader
{
    static public class PlcExt
    {
        public static void WriteDouble(this Plc plc, int db, int offset, double value)
        {
            plc.WriteBytes(DataType.DataBlock, db, offset, S7.Net.Types.Double.ToByteArray(value));
        }
        public static void WriteString(this Plc plc, int db, int offset, int maxStringLen, string value)
        {
            string str;
            if(value.Length > maxStringLen - 2)
                str = value.Substring(0, maxStringLen - 2);
            else
                str = value;
                    
            plc.WriteBytes(DataType.DataBlock, db, offset + 2, S7.Net.Types.String.ToByteArray(str));            
            //Запишем длину строки 
            byte[] strLen = new byte[2];
            strLen[0] = BitConverter.GetBytes(maxStringLen)[0];
            strLen[1] = BitConverter.GetBytes(str.Length)[0];                       
            plc.WriteBytes(DataType.DataBlock, db, offset, strLen);            
        }
    }
}
