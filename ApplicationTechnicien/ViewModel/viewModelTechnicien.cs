using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using ModelLayer.Business;
using ModelLayer.Data;

namespace ApplicationTechnicien.ViewModel
{
    class viewModelTechnicien : viewModelBase
    {
        private DaoAvis vmDaoAvis;
        private DaoClient vmDaoClient;
        private DaoObstacle vmDaoObstacle;
        private DaoPlacement_Obst vmDaoObstacle_Obst;
        private DaoReservation vmDaoReservation;
        private DaoSalle vmDaoSalle;
        private DaoTheme vmDaoTheme;
        private DaoTransaction vmDaoTransaction;
        private DaoUtilisateur vmDaoUtilisateur;
        private DaoVille vmDaoVille;

        //private ICommand ;
        //private IComman ;
        //private IComman ;
        //private IComman ;

        private ICommand buttonSupprimerJoueur;
        private ICommand btnAjouterClientsDansJoueur;
        private ICommand btnRechercher;

        private string heureReservation;
        private string minuteReservation;
        private DateTime selectedDate = new DateTime();
        private Salle selectedSalle = new Salle();
        private Ville selectedVille = new Ville();
        private Reservation selectedReservation = new Reservation();
        private string chercherClientsNom;
        private string chercherClientsPrenom;
        private Client selectedJoueur = new Client();
        private Client selectedListClient = new Client();

        

        private ObservableCollection<Avis> listAvis;
        private ObservableCollection<Client> listJoueur = new ObservableCollection<Client>();
        private ObservableCollection<Client> listClient;
        private ObservableCollection<Obstacle> listObstacle;
        private ObservableCollection<Placement_Obstacle> listPlacement_Obstacle;
        private ObservableCollection<Reservation> listReservation;
        private ObservableCollection<Salle> listSalle;
        private ObservableCollection<Theme> listTheme;
        private ObservableCollection<Transaction> listTransaction;
        private ObservableCollection<Utilisateur> listUtilisateur;
        private ObservableCollection<Ville> listVille;

        public ObservableCollection<Reservation> ListReservation { get => listReservation; set => listReservation = value; }
        public ObservableCollection<Client> ListJoueur { get => listJoueur; set => listJoueur = value; }
        public ObservableCollection<Salle> ListSalle { get => listSalle; set => listSalle = value; }
        public ObservableCollection<Avis> ListAvis { get => listAvis; set => listAvis = value; }
        public ObservableCollection<Client> ListClient { get => listClient; set => listClient = value; }
        public ObservableCollection<Obstacle> ListObstacle { get => listObstacle; set => listObstacle = value; }
        public ObservableCollection<Placement_Obstacle> ListPlacement_Obstacle { get => listPlacement_Obstacle; set => listPlacement_Obstacle = value; }
        public ObservableCollection<Theme> ListTheme { get => listTheme; set => listTheme = value; }
        public ObservableCollection<Transaction> ListTransaction { get => listTransaction; set => listTransaction = value; }
        public ObservableCollection<Utilisateur> ListUtilisateur { get => listUtilisateur; set => listUtilisateur = value; }
        public ObservableCollection<Ville> ListVille { get => listVille; set => listVille = value; }
        public viewModelTechnicien(DaoAvis thedaoavis, DaoClient thedaoclient, DaoObstacle thedaoobstacle, DaoPlacement_Obst thedaoplacement_obst, DaoReservation thedaoreservation, DaoSalle thedaosalle, DaoTheme thedaotheme, DaoTransaction thedaotransaction, DaoUtilisateur thedaoutilisateur, DaoVille thedaoville)
        {
            vmDaoAvis = thedaoavis;
            vmDaoClient = thedaoclient;
            vmDaoObstacle = thedaoobstacle;
            vmDaoObstacle_Obst = thedaoplacement_obst;
            vmDaoReservation = thedaoreservation;
            vmDaoSalle = thedaosalle;
            vmDaoTheme = thedaotheme;
            vmDaoTransaction = thedaotransaction;
            vmDaoUtilisateur = thedaoutilisateur;
            vmDaoVille = thedaoville;

            ListObstacle = new ObservableCollection<Obstacle>(thedaoobstacle.SelectAll());
            ListPlacement_Obstacle = new ObservableCollection<Placement_Obstacle>(thedaoplacement_obst.SelectAll());
            listSalle = new ObservableCollection<Salle>(thedaosalle.SelectAll());
            listReservation = new ObservableCollection<Reservation>(thedaoreservation.SelectAll());
            ListTheme = new ObservableCollection<Theme>(thedaotheme.SelectAll());
            ListTransaction = new ObservableCollection<Transaction>(thedaotransaction.SelectAll());
            ListUtilisateur = new ObservableCollection<Utilisateur>(thedaoutilisateur.SelectAll());
            ListVille = new ObservableCollection<Ville>(thedaoville.SelectAll());
            ListClient = new ObservableCollection<Client>(thedaoclient.SelectAll());
            ListAvis = new ObservableCollection<Avis>(thedaoavis.SelectAll());
        }

        public Salle SelectedSalle
        {
            get => selectedSalle;
            set
            {
                if (selectedSalle != value)
                {
                    selectedSalle = value;
                    OnPropertyChanged("SelectedSalle");
                    OnPropertyChanged("ListReservation");
                    RefreshListeReservation(SelectedDate);
                }
            }
        }

        public Ville SelectedVille
        {
            get => selectedVille;
            set
            {
                if (selectedVille != value)
                {
                    selectedVille = value;

                    List<Salle> uneListeSalle;
                    ListSalle.Clear();

                    uneListeSalle = vmDaoSalle.ListeDesSalle(SelectedVille);

                    foreach (Salle r in uneListeSalle)
                    {
                        ListSalle.Add(r);
                    }
                    OnPropertyChanged("SelectedVille");
                    OnPropertyChanged("SelectedSalle");
                }
            }
        }

        public DateTime SelectedDate
        {
            get => selectedDate;
            set
            {
                if (selectedDate != value)
                {

                    selectedDate = value;
                    OnPropertyChanged("SelectedDate");
                    RefreshListeReservation(SelectedDate);
                }
            }
        }

        public void RefreshListeReservation(DateTime uneDate)
        {

            if (selectedSalle == null)
            {
                listSalle.Clear();
            }

            else
            {
                if (selectedSalle.IdLieu != null)
                {
                    List<Reservation> listReservationRefresh = vmDaoReservation.SelectBySalleEtDate(selectedSalle.Id, uneDate.Date);
                    //ObservableCollection <Reservation> lalistReservation = new ObservableCollection<Reservation>(vmDaoReservation.SelectBySalleEtDate(ReserSalle, ReserDate));
                    listReservation.Clear();
                    foreach (Reservation r in listReservationRefresh)
                    {
                        listReservation.Add(r);
                    }
                }
            }

        }

        public string HeureReservation
        {
            get => heureReservation;

            set
            {
                if (heureReservation != value)
                {
                    heureReservation = value;
                    OnPropertyChanged("HeureReservation");
                }
            }
        }

        public string MinuteReservation
        {
            get => minuteReservation;

            set
            {
                if (minuteReservation != value)
                {
                    minuteReservation = value;
                    OnPropertyChanged("MinuteReservation");
                }
            }
        }

        public Reservation RecupererHoraireReservation()
        {
            Reservation uneReservation = new Reservation();
            if (selectedDate != null && selectedVille != null && selectedSalle != null && this.HeureReservation != "" && this.MinuteReservation != "")
            {


                int year = selectedDate.Year;
                int mouth = selectedDate.Month;
                int days = selectedDate.Day;

                int heure = int.Parse(heureReservation);
                int minute = int.Parse(MinuteReservation);

                DateTime dateRes = new DateTime(year, mouth, days, heure, minute, 0);

                List<Reservation> AllReservation = new List<Reservation>();
                int total = AllReservation.Count() + 1;

                //uneReservation = Reservation(dateRes, total+1, null, SelectedSalle, 0, null, 0, null);


                uneReservation.DateRes = dateRes;
                uneReservation.Id = total;
                uneReservation.IdSalle = selectedSalle;

            }

            return uneReservation;
        }

        // suite
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
            //get => nomObstacle;
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
                List<Client> listClientRefresh = vmDaoClient.RechercherClient("Clients", ChercherClientsNom, ChercherClientsPrenom);
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
            ObservableCollection<Client> listClientRefreshAll = new ObservableCollection<Client>(vmDaoClient.SelectAll());
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

            /*if (listJoueur.Count() <= 6 && listJoueur !=null)
            {
                        listJoueur.Add(SelectedListClient); 
            }
            IEnumerable<Client> NewClients = listJoueur.Distinct();

            foreach (Client r in NewClients)
            {
                listJoueur.Add(r);
            }*/
            bool naPasDeuxFoisUnClientDansLaListeDesJoueurs = false;
            if (listJoueur.Count() <= 6)
            {
                foreach (Client r in listJoueur)
                {
                    if(r == selectedListClient)
                    {
                        naPasDeuxFoisUnClientDansLaListeDesJoueurs = true;
                    }
                }
                if (naPasDeuxFoisUnClientDansLaListeDesJoueurs == false)
                {
                    listJoueur.Add(selectedListClient);
                }
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
    }
}