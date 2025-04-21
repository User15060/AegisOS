using System;

namespace AegisOS._02_Modele._01_NetworkToolsModele
{
    public abstract class VpnInformation
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public bool IsSelected { get; set; }

        protected VpnInformation(string name, string location)
        {
            Name = name;
            Location = location;
            IsSelected = false;
        }
    }
} 