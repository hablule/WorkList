using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace dbConnection
{
    class businessRule
    {

        dataBuilder getDataFromDb = new dataBuilder();

        ctlNumberTextBox numberTextbox = new ctlNumberTextBox();


        public bool translateCharacterToBool(string _char)
        {
            if (_char == "Y")
                return true;
            else
                return false;
        }

        public string translateBoolToCharacter(bool _boolean)
        {
            if (_boolean)
                return "Y";
            else
                return "N";
        }
                
    }
}
