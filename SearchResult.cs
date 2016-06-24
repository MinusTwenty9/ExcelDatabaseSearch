using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PortaCellTec_Database
{
    public class SearchResult
    {
        public DataValueType data_value_type;
        public List<InfoTile> info_tiles = new List<InfoTile>();
        public string focus_name;
        public double score;

        public SearchResult(string focus_name, double score)
        {
            this.focus_name = focus_name;
            this.score = score;
            this.data_value_type = DataValueType.Double;
        }

        public void Add(InfoTile info_tile)
        {
            for (int i = 0; i < info_tile.values.Length; i++ )
                if (info_tile.values[i].data_value_type == DataValueType.Date )
                {
                    data_value_type = DataValueType.Date;
                    break;
                }
                else if (info_tile.values[i].data_value_type == DataValueType.String) data_value_type = DataValueType.String;

            info_tiles.Add(info_tile);
        }
    }
}
