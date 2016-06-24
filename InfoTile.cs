using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortaCellTec_Database
{
    public class InfoTile
    {
        // "" if null
        public string t_name;
        public string s_name;

        public string t_class;
        public string s_class;
        
        // -1 if null
        public DataValue[] values;

        public int t_id;
        public int s_id;

        public InfoTile()
        {
            t_name = "";
            s_name = "";
            t_class = "";
            s_class = "";

            t_id = -1;
            s_id = -1;
        }

        public InfoTile(string t_name, string s_name, string t_class, string s_class,int t_id, int s_id, DataValue[] values)
        {
            this.t_name = t_name;
            this.s_name = s_name;
            this.t_class = t_class;
            this.s_class = s_class;
            this.t_id = t_id;
            this.s_id = s_id;
            
            this.values = values;

        }

        public string Get_Search_String(int index)
        {
            index %= 4;
            if (index == 0) return t_name;
            else if (index == 1) return s_name;
            else if (index == 2) return t_class;
            else if (index == 3) return s_class;
            else return t_name;
        }

    }
}
