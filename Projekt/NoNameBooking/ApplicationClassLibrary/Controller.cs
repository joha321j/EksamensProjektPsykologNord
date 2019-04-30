using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    public class Controller
    {
        private static Controller _instance;

        private Controller()
        {
        }

        public static Controller GetInstance()
        {
            return _instance ?? (_instance = new Controller());
        }

        public void CreateClient(string text, string s, string text1, string clientAddress, string s1, string text2)
        {
            throw new NotImplementedException();
        }
    }
}
