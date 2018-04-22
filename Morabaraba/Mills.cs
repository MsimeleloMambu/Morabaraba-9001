using System;
using System.Collections.Generic;
using System.Text;

namespace Morabaraba
{
    public class Mills
    {
        public List<List<string>> MillList { get; private set; }

        public Mills()
        {
            this.MillList = MillList;
        }     

        public bool MillChecker(List<string> possiblemillformation)
        {

            if (possiblemillformation[0] == "a1" && possiblemillformation[1] == "a4" && possiblemillformation[2] == "a7") return true; 
            if (possiblemillformation[0] == "b2" && possiblemillformation[1] == "b4" && possiblemillformation[2] == "b6") return true;
            if (possiblemillformation[0] == "c3" && possiblemillformation[1] == "c4" && possiblemillformation[2] == "c5") return true;
            if (possiblemillformation[0] == "d1" && possiblemillformation[1] == "d2" && possiblemillformation[2] == "d3") return true;
            if (possiblemillformation[0] == "d5" && possiblemillformation[1] == "d6" && possiblemillformation[2] == "d7") return true;
            if (possiblemillformation[0] == "e3" && possiblemillformation[1] == "e4" && possiblemillformation[2] == "e5") return true;
            if (possiblemillformation[0] == "f2" && possiblemillformation[1] == "f4" && possiblemillformation[2] == "f6") return true;
            if (possiblemillformation[0] == "g1" && possiblemillformation[1] == "g4" && possiblemillformation[2] == "g7") return true;
            if (possiblemillformation[0] == "a1" && possiblemillformation[1] == "d1" && possiblemillformation[2] == "g1") return true;
            if (possiblemillformation[0] == "b2" && possiblemillformation[1] == "d2" && possiblemillformation[2] == "f2") return true;
            if (possiblemillformation[0] == "c3" && possiblemillformation[1] == "d3" && possiblemillformation[2] == "e3") return true;
            if (possiblemillformation[0] == "a4" && possiblemillformation[1] == "b4" && possiblemillformation[2] == "c4") return true;
            if (possiblemillformation[0] == "e4" && possiblemillformation[1] == "f4" && possiblemillformation[2] == "g4") return true;
            if (possiblemillformation[0] == "c5" && possiblemillformation[1] == "d5" && possiblemillformation[2] == "e5") return true;
            if (possiblemillformation[0] == "b6" && possiblemillformation[1] == "d6" && possiblemillformation[2] == "f6") return true;
            if (possiblemillformation[0] == "a7" && possiblemillformation[1] == "d7" && possiblemillformation[2] == "g7") return true;
            if (possiblemillformation[0] == "a1" && possiblemillformation[1] == "b2" && possiblemillformation[2] == "c3") return true;
            if (possiblemillformation[0] == "e3" && possiblemillformation[1] == "f2" && possiblemillformation[2] == "g1") return true;
            if (possiblemillformation[0] == "c5" && possiblemillformation[1] == "b6" && possiblemillformation[2] == "a7") return true;
            if (possiblemillformation[0] == "e5" && possiblemillformation[1] == "f6" && possiblemillformation[2] == "g7") return true;

            return false;
        }
       
        //disband mill formation
        //check valid Mill formation
    }
}
