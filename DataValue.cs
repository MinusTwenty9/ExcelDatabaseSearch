using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortaCellTec_Database
{
    public class DataValue
    {
        public DataValueType data_value_type;
        public string str_value;
        public double d_value;

        public DataValue(string value)
        {
            this.str_value = value;
            this.d_value = double.MinValue;
            data_value_type = DataValueType.String;
        }

        public DataValue(double value, bool is_date = false)
        {
            this.d_value = value;
            if (value == double.MinValue)
            {
                str_value = "";
                return;
            }

            if (is_date == false)
            {
                this.str_value = value.ToString();
                data_value_type = DataValueType.Double;
            }
            else
            {
                this.str_value = DateTime.FromOADate(value).ToShortDateString();
                data_value_type = DataValueType.Date;
            }
        }
                
        public void Set_Value(string value)
        {
            this.str_value = value;
            this.d_value = double.MinValue;
            data_value_type = DataValueType.String;
        }

        public void Set_Value(double value)
        {
            this.d_value = value;
            this.str_value = value.ToString();
            data_value_type = DataValueType.Double;
        }

        public void Set_Date(double value)
        {
            this.d_value = value;
            this.str_value = DateTime.FromOADate(value).ToShortDateString();
            data_value_type = DataValueType.Date;
        }

    }
    public enum DataValueType
    {
        Double,
        String,
        Date
    }
}
