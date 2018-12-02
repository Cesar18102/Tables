using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tables
{
    public class Table
    {
        public int id;
        public int hall_id;
        public int chair_count;
        public int moveable;
        public int width;
        public int length;
        public int x;
        public int y;
        public int margin;
        public int padding;
        public int chair_per_width;
        public int chair_per_height;

        public Table() { }

        public Table(int id, int hall_id, int chair_count, int moveable, int width, int length, int x, int y, int margin, int padding, int chair_per_width, int chair_per_height)
        {
            this.id = id;
            this.hall_id = hall_id;
            this.chair_count = chair_count;
            this.moveable = moveable;
            this.width = width;
            this.length = length;
            this.x = x;
            this.y = y;
            this.margin = margin;
            this.padding = padding;
            this.chair_per_width = chair_per_width;
            this.chair_per_height = chair_per_height;
        }

        public static bool Intersects(Table T1, Table T2)
        {
            return T1.x + T1.width + T1.margin + T1.padding >= T2.x - T2.margin - T2.padding &&
                   T1.x - T1.margin - T1.padding <= T2.x + T2.width + T2.margin + T2.padding &&
                   T1.y + T1.length + T1.margin + T1.padding >= T2.y - T2.margin - T2.padding &&
                   T1.y - T1.margin - T1.padding <= T2.y + T2.length + T2.margin + T2.padding;
        }

        public static bool HardIntersects(Table T1, Table T2)
        {
            return T1.x + T1.width >= T2.x &&
                   T1.x <= T2.x + T2.width &&
                   T1.y + T1.length >= T2.y &&
                   T1.y <= T2.y + T2.length;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="T1"></param>
        /// <param name="T2"></param>
        /// <returns>2 - bottom, 8 - top, 4 - left, 6 right, 0 - nothing; From the point of view of T1</returns>
        public static int GetIntersectionSide(Table T1, Table T2) {

            int HB1 = T1.y + T1.length + T1.margin + T1.padding;
            int HT1 = T1.y - T1.margin - T1.padding;
            int VR1 = T1.x + T1.width + T1.margin + T1.padding;
            int VL1 = T1.x - T1.margin - T1.padding;

            int HB2 = T2.y + T2.length + T2.margin + T2.padding;
            int HT2 = T2.y - T2.margin - T2.padding;
            int VR2 = T2.x + T2.width + T2.margin + T2.padding;
            int VL2 = T2.x - T2.margin - T2.padding;

            int DH2 = Math.Abs(HT2 - HB1);
            int DH8 = Math.Abs(HT1 - HB2);

            int DV6 = Math.Abs(VL2 - VR1);
            int DV4 = Math.Abs(VL1 - VR2);

            int H = Math.Min(DH2, DH8);
            int V = Math.Min(DV6, DV4);

            return H < V ? (DH2 < DH8 ? 2 : 8) : (DV6 < DV4 ? 6 : 4);
        }
    }
}
