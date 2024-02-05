using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GesVehicules.Entities;


namespace GesVehicules
{
    public class StateContainer
    {


        #region Vehicule
        private List<Vehicule> vehicules = new();
        private Vehicule? selectedVehicule = null;

        public List<Vehicule> Vehicules
        {
            get => vehicules;
            set
            {
                vehicules = value;
                NotifyVehiculesUpdated();
            }
        }

        public Vehicule? SelectedVehicule
        {
            get => selectedVehicule;
            set
            {
                selectedVehicule = value;
                OnVehiculeSelected?.Invoke();
            }
        }

        public event Action? OnVehiculeUpdated;
        public event Action? OnVehiculeSelected;

        public void NotifyVehiculesUpdated() => OnVehiculeUpdated?.Invoke();
        #endregion
    }
}