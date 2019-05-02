﻿using System;
using System.Collections.Generic;
using ModelClassLibrary;

namespace ViewModelClassLibrary
{
    public class ClientRepoViewModel
    {
        private ClientView _currentClientView;
        private readonly ClientRepo _clientRepo = ClientRepo.GetInstance();
        private readonly List<ClientView> _clientViews = new List<ClientView>();
        public string ClientName => _currentClientView.Name;

        public event EventHandler ClientAddedEvent;

        public void CreateClient(string clientName, string clientEmail, string clientPhoneNumber, string clientAddress, string clientSsn, string clientNote)
        {
            _clientRepo.CreateClient(clientName, clientEmail,
                                     clientPhoneNumber, clientAddress,
                                     clientSsn, clientNote);

            _currentClientView = new ClientView(clientName, clientPhoneNumber, clientAddress, clientEmail, clientSsn, clientNote);

            _clientViews.Add(_currentClientView);

            ClientAddedEvent?.Invoke(this, EventArgs.Empty);
        }


        public List<ClientView> GetClientViews()
        {
            return _clientViews;
        }
    }
}