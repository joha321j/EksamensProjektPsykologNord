using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationClassLibrary
{
    class PractitionerRepo
    {
        private static PractitionerRepo _instance;

        private PractitionerRepo()
        {

        }
        public static PractitionerRepo GetInstance()
        {
            return _instance ?? (_instance = new PractitionerRepo());
        }
    }
}
