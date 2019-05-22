using System;
using System.Collections.Generic;
using System.Text;
using PersistencyClassLibrary;

namespace ApplicationClassLibrary
{
    class UpdateFromDatabase
    {
        private static UpdateFromDatabase _instance;

        private IPersistable _persistable;
        public EventHandler ClientsUpdatedEventHandler;
        public EventHandler AppointmentsUpdatedEventHandler;

        private UpdateFromDatabase(IPersistable persistable)
        {
            _persistable = persistable;
        }

        public static UpdateFromDatabase GetInstance(IPersistable persistable)
        {
            return _instance ?? (_instance = new UpdateFromDatabase(persistable));
        }
    }
}
