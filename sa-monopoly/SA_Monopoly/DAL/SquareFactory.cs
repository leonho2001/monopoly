using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SA_Monopoly.EL.Square;

namespace SA_Monopoly.DAL
{
    class SquareFactory
    {
        static string path = @"E:\Bin's doc\1- Tai lieu hoc tap Hoa Sen\!HK 10.2A\2. SA\Project Monopoly\Sources\sa-monopoly\SA_Monopoly\Data\Square_V2.1.xml";
        public List<clsSquare> LoadSquare()
        {
            XDocument SquareFile = XDocument.Load(path);
            var SquareList = from item in SquareFile.Descendants("Square")
                             select new clsSquare
                             {
                                 SquareID = int.Parse(item.Attribute("SquareID").Value),
                                 SquareName = item.Attribute("SquareName").Value
                             };
            return SquareList.ToList();
        } 
    }
}
