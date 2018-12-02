using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class TableSystem
    {
        public List<TableView> Tables = new List<TableView>();
        public int ChairCount {

            get
            {
                int sum = 0;
                for (int i = 0; i < Tables.Count; i++)
                    sum += Tables[i].GetChairsCounts().Sum();
                return sum;
            }
        }

        public TableSystem() { }

        public int Contains(TableView TW)
        {
            for(int i = 0; i < Tables.Count; i++)
                if (Tables[i].T.id == TW.T.id)
                    return i;

            return -1;
        }
    }
}
