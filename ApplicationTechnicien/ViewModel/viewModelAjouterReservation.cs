using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Data;
using ModelLayer.Business;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ApplicationTechnicien.ViewModel
{
    class viewModelAjouterReservation : viewModelBase
    {

        private DaoClient vmDaoCLient;
        private DaoObstacle vmDaoObstacle;
        private DaoPlacement_Obst vmDaoPlacement_Obst;
        private DaoReservation vmDaoReservation;
        private DaoSalle vmDaoSalle;
        private DaoTheme vmDaoTheme;
        private DaoUtilisateur vmDaoUtilsateur;
        private DaoVille vmDaoVille;


        private Client afficherClients = new Client();

        private ICommand buttonSupprimerJoueur;
        private ICommand btnAjouterClientsDansJoueur;
        private ICommand btnRechercher;

        private string chercherClientsNom;
        private string chercherClientsPrenom;

        private string nomObstacle;

        private Client selectedJoueur = new Client();
        private Client selectedListClient = new Client();

        private ObservableCollection<Client> listClient;
        private ObservableCollection<Client> listJoueur;
        private ObservableCollection<Obstacle> listObstacle;
        private ObservableCollection<Placement_Obstacle> listPlacement_Obs;
        private ObservableCollection<Reservation> listReservation;
        private ObservableCollection<Salle> listSalle;
        private ObservableCollection<Theme> listTheme;
        private ObservableCollection<Utilisateur> listUtilisateur;
        private ObservableCollection<Ville> listVille;

        public ObservableCollection<Client> ListClient { get => listClient; set => listClient = value; }
        public ObservableCollection<Client> ListJoueur { get => listJoueur; set => listJoueur = value; }
        public ObservableCollection<Obstacle> ListObstacle { get => listObstacle; set => listObstacle = value; }
        public ObservableCollection<Placement_Obstacle> ListPlacement_Obs { get => listPlacement_Obs; set => listPlacement_Obs = value; }
        public ObservableCollection<Reservation> ListReservation { get => listReservation; set => listReservation = value; }
        public ObservableCollection<Salle> ListSalle { get => listSalle; set => listSalle = value; }
        public ObservableCollection<Theme> ListTheme { get => listTheme; set => listTheme = value; }
        public ObservableCollection<Utilisateur> ListUtilisateur { get => listUtilisateur; set => listUtilisateur = value; }
        public ObservableCollection<Ville> ListVille { get => listVille; set => listVille = value; }


        public ICommand BtnRechercher
        {
            get
            {
                if (this.btnRechercher == null)
                {
                    this.btnRechercher = new RelayCommand(() => Rechercher(), () => true);
                }
                return this.btnRechercher;
            }
        }

        public string ChercherClientsNom
        {
            get => chercherClientsNom;

            set
            {
                if (chercherClientsNom != value)
                {
                    chercherClientsNom = value;
                    OnPropertyChanged("ChercherClientsNom");
                }
            }
        }

        public string NomObstacle
        {
            get => nomObstacle;
            set
            {
                if (chercherClientsNom != value)
                {

                }
            }
        }

        public string ChercherClientsPrenom
        {
            get => chercherClientsPrenom;
            set
            {
                if (chercherClientsPrenom != value)
                {
                    chercherClientsPrenom = value;
                    OnPropertyChanged("ChercherClientsPrenom");
                }
            }
        }

        public void Rechercher()
        {
            if (this.ChercherClientsNom != "")
            {
                List<Client> listClientRefresh = vmDaoCLient.RechercherClient("Clients", ChercherClientsNom, ChercherClientsPrenom);
                listClient.Clear();
                foreach (Client r in listClientRefresh)
                {
                    listClient.Add(r);
                }
            }
            else ClientRefreshList();

        }

        public void ClientRefreshList()
        {
            ObservableCollection<Client> listClientRefreshAll = new ObservableCollection<Client>(vmDaoCLient.SelectAll());
            listClient.Clear();
            foreach (Client r in listClientRefreshAll)
            {
                listClient.Add(r);
            }
        }
        public ICommand BtnAjouterClientsDansJoueur
        {
            get
            {
                if (btnAjouterClientsDansJoueur == null)
                {
                    this.btnAjouterClientsDansJoueur = new RelayCommand(() => AjouterClientsDansJoueur(), () => true);
                }
                return this.btnAjouterClientsDansJoueur;
            }
        }
        public void AjouterClientsDansJoueur()
        {
            /*ObservableCollection<Client> NewClient = new ObservableCollection<Client>();
            if (listJoueur.Count() <= 6)
            {
                        listJoueur.Add(SelectedListClient); 
            }
            IEnumerable<Client> NewClients = listJoueur.Distinct();

            foreach (Client r in NewClients)
            {
                listJoueur.Add(r);
            }*/

            if (listJoueur.Count() <= 6)
            {
                listJoueur.Add(SelectedListClient);
            }
        }

        public ICommand ButtonSupprimerJoueur
        {
            get
            {
                if (buttonSupprimerJoueur == null)
                {
                    this.buttonSupprimerJoueur = new RelayCommand(() => SupprimerJoueur(), () => true);
                }
                return this.buttonSupprimerJoueur;
            }
        }

        public void SupprimerJoueur()
        {
            listJoueur.Remove(SelectedJoueur);
        }

        public Client SelectedJoueur
        {
            get => selectedJoueur;
            set
            {
                if (selectedJoueur != value)
                {
                    selectedJoueur = value;
                    OnPropertyChanged("SelectedJoueur");
                }
            }
        }

        public Client SelectedListClient
        {
            get => selectedListClient;
            set
            {
                if (selectedListClient != value)
                {
                    selectedListClient = value;
                    OnPropertyChanged("SelectedListClient");
                }
            }
        }

        public viewModelAjouterReservation(DaoClient theDaoClient, DaoObstacle theDaoObstacle, DaoPlacement_Obst theDaoPlacement_obs, DaoReservation theDaoReservation, DaoSalle theDaoSalle, DaoTheme theDaoTheme, DaoUtilisateur theDaoUtlisateur, DaoVille theDaoVille)
        {
            vmDaoCLient = theDaoClient;
            vmDaoObstacle = theDaoObstacle;
            vmDaoPlacement_Obst = theDaoPlacement_obs;
            vmDaoReservation = theDaoReservation;
            vmDaoSalle = theDaoSalle;
            vmDaoTheme = theDaoTheme;
            vmDaoUtilsateur = theDaoUtlisateur;
            vmDaoVille = theDaoVille;

            listJoueur = new ObservableCollection<Client>();
            listClient = new ObservableCollection<Client>(theDaoClient.SelectAll());
            listObstacle = new ObservableCollection<Obstacle>(theDaoObstacle.SelectAll());
            listPlacement_Obs = new ObservableCollection<Placement_Obstacle>(theDaoPlacement_obs.SelectAll());

            listSalle = new ObservableCollection<Salle>(theDaoSalle.SelectAll());
            listTheme = new ObservableCollection<Theme>(theDaoTheme.SelectAll());

            listVille = new ObservableCollection<Ville>(theDaoVille.SelectAll());
        }



    }
}
