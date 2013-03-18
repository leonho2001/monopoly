using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SA_Monopoly.EL.Property;
using System.Xml.Linq;

namespace SA_Monopoly.DAL
{
    class PropertyFactory
    {
        static string path = @"E:\Bin's doc\1- Tai lieu hoc tap Hoa Sen\!HK 10.2A\2. SA\Project Monopoly\Sources\sa-monopoly\SA_Monopoly\Data\Square_V2.1.xml";
        public List<clsLand> LoadLand()
        {
            XDocument SPropertyFile = XDocument.Load(path);
            var SPL = (from item in SPropertyFile.Descendants("Land")
                       from item2 in SPropertyFile.Descendants("Square")
                       where item.Ancestors("Square").Any(x => x.Attribute("SquareID").Value == item2.Attribute("SquareID").Value)
                      select new clsLand
                      {
                          PropertyID = item2.Attribute("SquareID").Value,
                          Price = long.Parse(item2.Element("ValueSquare").Attribute("Price").Value),
                          Mortgage = long.Parse(item2.Element("ValueSquare").Attribute("MortgageValue").Value),
                          PerHouseCost = long.Parse(item.Attribute("PerHouseCost").Value),
                          PerHotelCost = long.Parse(item.Attribute("PerHotelCost").Value),
                          Rent0 = long.Parse(item.Attribute("Rent0").Value),
                          Rent1 = long.Parse(item.Attribute("Rent1").Value),
                          Rent2 = long.Parse(item.Attribute("Rent2").Value),
                          Rent3 = long.Parse(item.Attribute("Rent3").Value),
                          Rent4 = long.Parse(item.Attribute("Rent4").Value),
                          RentHotel = long.Parse(item.Attribute("RentHotel").Value),
                      }).ToList(); ;
            return SPL;
        }

        public List<clsTrainStation> LoadTS()
        {
            XDocument SPropertyFile = XDocument.Load(path);
            var SPT = (from item in SPropertyFile.Descendants("TrainStation")
                       from item1 in SPropertyFile.Descendants("Square")
                       where item.Ancestors("Square").Any(x => x.Attribute("SquareID").Value == item1.Attribute("SquareID").Value)
                      select new clsTrainStation
                      {
                          PropertyID = item1.Attribute("SquareID").Value,
                          Price = long.Parse(item1.Element("ValueSquare").Attribute("Price").Value),
                          Mortgage = long.Parse(item1.Element("ValueSquare").Attribute("MortgageValue").Value),
                          Rent1 = long.Parse(item.Attribute("Rent1").Value),
                          Rent2 = long.Parse(item.Attribute("Rent2").Value),
                          Rent3 = long.Parse(item.Attribute("Rent3").Value),
                          Rent4 = long.Parse(item.Attribute("Rent4").Value),
                      }).ToList();
            return SPT;
        }

        public List<clsUltility> LoadU()
        {
            XDocument SPropertyFile = XDocument.Load(path);
            var SPU = (from item in SPropertyFile.Descendants("Utility")
                      from item1 in SPropertyFile.Descendants("Square")
                      where item.Ancestors("Square").Any(x => x.Attribute("SquareID").Value == item1.Attribute("SquareID").Value)
                      select new clsUltility
                      {
                          PropertyID = item1.Attribute("SquareID").Value,
                          Price = long.Parse(item1.Element("ValueSquare").Attribute("Price").Value),
                          Mortgage = long.Parse(item1.Element("ValueSquare").Attribute("MortgageValue").Value),
                          Multiplier1 = long.Parse(item.Attribute("Multiplier1").Value),
                          Multiplier2 = long.Parse(item.Attribute("Multiplier2").Value),
                      }).ToList();

            return SPU;
        }
    }
}
