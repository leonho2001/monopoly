using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SA_Monopoly.EL.Property
{
    class clsLand : clsSpecialProperty
    {
        private long perHouseCost;

        public long PerHouseCost
        {
            get { return perHouseCost; }
            set { perHouseCost = value; }
        }

        private long perHotelCost;

        public long PerHotelCost
        {
            get { return perHotelCost; }
            set { perHotelCost = value; }
        }

        private long rent0;

        public long Rent0
        {
            get { return rent0; }
            set { rent0 = value; }
        }

        private long rent1;

        public long Rent1
        {
            get { return rent1; }
            set { rent1 = value; }
        }

        private long rent2;

        public long Rent2
        {
            get { return rent2; }
            set { rent2 = value; }
        }

        private long rent3;

        public long Rent3
        {
            get { return rent3; }
            set { rent3 = value; }
        }

        private long rent4;

        public long Rent4
        {
            get { return rent4; }
            set { rent4 = value; }
        }

        private long rentHotel;

        public long RentHotel
        {
            get { return rentHotel; }
            set { rentHotel = value; }
        }

        private clsHouseHotel house;

        internal clsHouseHotel House
        {
            get { return house; }
            set { house = value; }
        }

    }
}
