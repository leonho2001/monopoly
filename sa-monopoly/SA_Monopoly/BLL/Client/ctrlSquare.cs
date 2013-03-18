using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SA_Monopoly.EL.Square;
using SA_Monopoly.DAL;
using SA_Monopoly.EL.Property;
using SA_Monopoly.EL.Game;

namespace SA_Monopoly.BLL.Client
{
    class ctrlSquare
    {
        SquareFactory SF = new SquareFactory();
        PropertyFactory PF = new PropertyFactory();
        static List<clsSquare> squareList = new List<clsSquare>();
        static List<clsValueSquare> vSquareList = new List<clsValueSquare>();
        static List<clsLand> LandList = new List<clsLand>();
        static List<clsTrainStation> TSList = new List<clsTrainStation>();
        static List<clsUltility> UList = new List<clsUltility>();
        static List<clsSpecialProperty> SPList = new List<clsSpecialProperty>();


        static public long gia = 0;
        static public string stt ="";

        public List<clsLand> getAllLand()
        {
            return PF.LoadLand();
        }

        public clsSquare getSquareById(string SquareID)
        {
            foreach (clsSquare item in squareList)
            {
                if (SquareID == (item.SquareID).ToString())
                {
                    return item;
                }
            }
            return null;
        }

        public clsValueSquare getValueSquareById(string SquareID)
        {
            foreach (clsValueSquare item in vSquareList)
            {
                if (SquareID == (item.SquareID).ToString())
                {
                    return item;
                }
            }
            return null;
        }
        public clsLand getLandByID(string LandID)
        {
            foreach (clsLand item in LandList)
            {
                if (LandID == item.PropertyID)
                {
                    return item;
                }
            }
            return null;
        }

        public clsTrainStation getTrainStationByID(string TrainID)
        {
            foreach (clsTrainStation item in TSList)
            {
                if (TrainID == item.PropertyID)
                {
                    return item;
                }
            }
            return null;
        }

        public clsUltility getUtilityByID(string UtilityID)
        {
            foreach (clsUltility item in UList)
            {
                if (UtilityID == item.PropertyID)
                {
                    return item;
                }
            }
            return null;
        }


        public List<clsTrainStation> getAllTrainStation()
        {
            return PF.LoadTS();
        }

        public List<clsUltility> getUltility()
        {
            return PF.LoadU();
        }

        public ctrlSquare()
        {
            getSPList();
            getAllSquare();
            getVSquare();
            
        }


        private void getAllSquare()
        {
            squareList =  SF.LoadSquare();
        }

        private void getSPList()
        {
            LandList.AddRange(PF.LoadLand());
            TSList.AddRange(PF.LoadTS());
            UList.AddRange(PF.LoadU());
            SPList.AddRange(LandList);
            SPList.AddRange(TSList);
            SPList.AddRange(UList);
        }

        private void getVSquare()
        {
            foreach (clsSpecialProperty item in SPList)
            {
                vSquareList.Add(new clsValueSquare(int.Parse(item.PropertyID), item, getSquareName(item)));      
            }
        }

        public string getSquareName(clsSpecialProperty sp)
        {
            foreach (clsSquare item in squareList)
            {
                if (sp.PropertyID == item.SquareID.ToString())
                {
                    return item.SquareName;
                }
            }
            return null;
        }
        public string getPropertyName(clsSpecialProperty sp)
        {
            foreach (clsValueSquare item in vSquareList)
            {
                if (sp.PropertyID == item.SquareID.ToString())
                {
                    return item.SquareName;
                }
            }
            return "";
        }

        public List<clsPlayer> ActivateSquare(List<clsPlayer> pll, int it, clsSquare sq)
        {
            List<clsPlayer> tempL = new List<clsPlayer>();
            tempL = sq.SquareActivate(pll, it);
            return tempL;
        }
    }
}
