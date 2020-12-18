using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

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

        private ICommand buttonTerminer;
        private ICommand buttonSupprimerJoueur;
        private ICommand btnAjouterClientsDansJoueur;
        private ICommand btnRechercher;
        private ICommand btnRechercherObstacle;
        private ICommand buttonSupprimerReservation;
        private ICommand buttonMiseAJourReservation;
        private ICommand buttonAjouterObstacle;
        private ICommand buttonSupprimerObstacle;
        private ICommand btnRechercheClientPourInformation;

        private string heureReservation;
        private string minuteReservation;
        private DateTime selectedDate = new DateTime();
        private Salle selectedSalle = new Salle();
        private Ville selectedVille = new Ville();
        private Utilisateur selectedTechnicien = new Utilisateur();
        private Reservation selectedReservation = new Reservation();
        private string chercherClientsNom;
        private string chercherClientsPrenom;
        private Client selectedJoueur = new Client();
        private Client selectedListClient = new Client();
        private Theme selectedTheme = new Theme();
        private Obstacle selectedObstacle = new Obstacle();
        private Obstacle selectedObstacleAjouter = new Obstacle();
        public string chercherObstacle;
        public string txtPrenomClientPourInformation;
        public string txtNomClientPourInformation;
        



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
        private ObservableCollection<Utilisateur> listTechnicien;
        private ObservableCollection<Obstacle> listObstacleAjouter = new ObservableCollection<Obstacle>();
        private ObservableCollection<Client> listClientPourInformation;

        public ObservableCollection<Client> ListClientPourInformation { get => listClientPourInformation; set => listClientPourInformation = value; }
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
        public ObservableCollection<Utilisateur> ListTechnicien { get => listTechnicien; set => listTechnicien = value; }
        public ObservableCollection<Obstacle> ListObstacleAjouter { get => listObstacleAjouter; set => listObstacleAjouter = value; }

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
            ListTechnicien = new ObservableCollection<Utilisateur>(thedaoutilisateur.SelectAll());
            ListClientPourInformation = new ObservableCollection<Client>(thedaoclient.SelectAll());
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
                    RefreshListeReservation();
                }
            }
        }

        public Reservation SelectedReservation
        {
            get => selectedReservation;
            set
            {
                if (selectedReservation != value)
                {
                    selectedReservation = value;
                    OnPropertyChanged("SelectedReservation");
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
                    listSalle.Clear();
                    uneListeSalle = vmDaoSalle.ListeDesSalle(SelectedVille);
                    foreach (Salle r in uneListeSalle)
                    {
                        listSalle.Add(r);
                    }


                    List<Utilisateur> uneListeutilisateur;

                    listTechnicien.Clear();
                    uneListeutilisateur = vmDaoUtilisateur.listeDesUtilsateurs(SelectedVille);
                    foreach (Utilisateur r in uneListeutilisateur)
                    {
                        listTechnicien.Add(r);
                    }


                    OnPropertyChanged("SelectedVille");
                    OnPropertyChanged("SelectedSalle");
                    OnPropertyChanged("SelectedTechnicien");
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
                    RefreshListeReservation();
                }
            }
        }

        public Utilisateur SelectedTechnicien
        {
            get => selectedTechnicien;
            set
            {
                if (selectedTechnicien != value)
                {
                    selectedTechnicien = value;
                    OnPropertyChanged("SelectedTechnicien");
                }
            }
        }

        public void RefreshListeReservation()
        {

            if (selectedSalle == null)
            {
                listSalle.Clear();
            }

            else
            {
                if (selectedSalle.IdLieu != null)
                {
                    List<Reservation> listReservationRefresh = vmDaoReservation.SelectBySalleEtDate(selectedSalle.Id, selectedDate.Date);
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

        public string TxtNomClientPourInformation
        {
            get => txtNomClientPourInformation;
            set
            {
                if(txtNomClientPourInformation != value)
                {
                    txtNomClientPourInformation = value;
                    OnPropertyChanged("TxtNomClientPourInformation");
                }
            }
        }

        public string TxtPrenomClientPourInformation
        {
            get => txtPrenomClientPourInformation;
            set
            {
                if(txtPrenomClientPourInformation != value)
                {
                    txtPrenomClientPourInformation = value;
                    OnPropertyChanged("TxtPrenomClientPourInformation");
                }
            }
        }

        public ICommand BtnRechercheClientPourInformation
        {
            get
            {
                if (this.btnRechercheClientPourInformation == null)
                {
                    this.btnRechercheClientPourInformation = new RelayCommand(() => RechercheClientPourInformation(), () => true);
                }
                return this.btnRechercheClientPourInformation;
            }
            
        }

        public void RechercheClientPourInformation()
        {
            if (this.chercherClientsNom != "")
            { 
            List<Client> listClientRefresh = vmDaoClient.RechercherClient("Clients", txtNomClientPourInformation, txtPrenomClientPourInformation);
            listClient.Clear();
            foreach (Client r in listClientRefresh)
            {
                listClient.Add(r);
            }
        }
            else ClientRefreshList();
    }

        public string ChercherObstacle
        {
            get => chercherObstacle;
            set
            {
                if (chercherObstacle != value)
                {
                    chercherObstacle = value;
                    OnPropertyChanged("ChercherObstacle");
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


        public ICommand ButtonMiseAJourReservation
        {
            get
            {
                if (this.buttonMiseAJourReservation == null)
                {
                    this.buttonMiseAJourReservation = new RelayCommand(() => MiseAjourReservation(), () => true);
                }
                return this.buttonMiseAJourReservation;
            }
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

        public ICommand ButtonSupprimerReservation
        {
            get
            {
                if (this.buttonSupprimerReservation == null)
                {
                    this.buttonSupprimerReservation = new RelayCommand(() => SupprimerReservation(), () => true);
                }
                return this.buttonSupprimerReservation;
            }   
        }

        public ICommand BtnRechercherObstacle
        {
            get
            {
                if (this.btnRechercherObstacle == null)
                {
                    this.btnRechercherObstacle = new RelayCommand(() => RechercherObstacle(), () => true);
                }
                return this.btnRechercherObstacle;
            }
        }

        public void RechercherObstacle()
        {
            if (this.ChercherObstacle != "")
            {
                List<Obstacle> LalistObstacle = vmDaoObstacle.RechercherObstacle(chercherObstacle);
                listObstacle.Clear();
                foreach (Obstacle r in LalistObstacle)
                {
                    listObstacle.Add(r);
                }
            }
            else ObstacleRefreshList();
        }

        public void ObstacleRefreshList()
        {
            ObservableCollection<Obstacle> listObstacleRefresh = new ObservableCollection<Obstacle>(vmDaoObstacle.SelectAll());
            listObstacle.Clear();
            foreach (Obstacle r in listObstacleRefresh)
            {
                listObstacle.Add(r);

            }
        }

        public void MiseAjourReservation()
        {
            List<Reservation> toutesLesReservation = new List<Reservation>();
            listReservation.Clear();

            toutesLesReservation = vmDaoReservation.SelectAll();

            foreach (Reservation r in toutesLesReservation)
            {
                listReservation.Add(r);
            }
        }



        public void SupprimerReservation()
        {
            if (selectedReservation != null)
            {
                Reservation uneReservation = new Reservation();
                List<Reservation> lesReservation = new List<Reservation>();

                vmDaoObstacle_Obst.DeleteAvecIdReservation(selectedReservation);
                vmDaoTransaction.DeleteAvecIdReservation(selectedReservation);

                uneReservation = selectedReservation;
                vmDaoReservation.Delete(uneReservation);
                lesReservation = vmDaoReservation.SelectAll();
                ListReservation.Clear();

                foreach (Reservation r in lesReservation)
                {
                    ListReservation.Add(r);
                }
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


        public void ClientRefreshListPourInformation()
        {
            ObservableCollection<Client> listClientRefreshAll = new ObservableCollection<Client>(vmDaoClient.SelectAll());
            listClientPourInformation.Clear();
            foreach (Client r in listClientRefreshAll)
            {
                listClientPourInformation.Add(r);
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
            bool naPasDeuxFoisUnClientDansLaListeDesJoueurs = false;
            if (listJoueur.Count() <= 6)
            {
                foreach (Client r in listJoueur)
                {
                    if (r == selectedListClient)
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

        public Theme SelectedTheme
        {
            get => selectedTheme;
            set
            {
                if (selectedTheme != value)
                {
                    selectedTheme = value;

                    List<Obstacle> uneListeObstacle;
                    listObstacle.Clear();
                    uneListeObstacle = vmDaoObstacle.listeDesObstacleParRapportauTheme(selectedTheme);

                    foreach(Obstacle r in uneListeObstacle)
                    {
                        listObstacle.Add(r);
                    }

                    OnPropertyChanged("SelectedTheme");
                }
            }
        }

        public ICommand ButtonTerminer
        {
            get
            {
                if (buttonTerminer == null)
                {
                    this.buttonTerminer = new RelayCommand(() => AjoutNouvelleReservation(), () => true);
                }
                return this.buttonTerminer;
            }
        }



        public ICommand ButtonAjouterObstacle
        {
            get
            {
                if (buttonAjouterObstacle == null)
                {
                    this.buttonAjouterObstacle = new RelayCommand(() => AjouterNouveauObstacle(), () => true);
                }
                return this.buttonAjouterObstacle;
            }
        }

        public Obstacle SelectedObstacle
        {
            get => selectedObstacle;
            set
            {
                if (selectedObstacle != value)
                {
                    selectedObstacle = value;
                    OnPropertyChanged("SelectedObstacle");
                }
            }
        }

        public Obstacle SelectedObstacleAjouter
        {
            get => selectedObstacleAjouter;
            set
            {
                if (selectedObstacleAjouter != value)
                {
                    selectedObstacleAjouter = value;
                    OnPropertyChanged("SelectedObstacleAjouter");
                }
            }
        }

        public void AjouterNouveauObstacle()
        {
            // SelectedObstacle
            //    SelectedObstacleAjouter
            //listTechnicien

            bool naPasDeuxFoisUnObstacleDansLaListeDesObstalceAjouter = false;
            if (listObstacleAjouter.Count() <= 12)
            {
                foreach (Obstacle r in listObstacleAjouter)
                {
                    if (r == selectedObstacle)
                    {
                        naPasDeuxFoisUnObstacleDansLaListeDesObstalceAjouter = true;
                    }
                }
                if (naPasDeuxFoisUnObstacleDansLaListeDesObstalceAjouter == false)
                {
                    listObstacleAjouter.Add(selectedObstacle);
                }
            }
        }

        public ICommand ButtonSupprimerObstacle
        {
            get
            {
                if (buttonSupprimerObstacle == null)
                {
                    this.buttonSupprimerObstacle = new RelayCommand(() => SupprimerObstacle(), () => true);

                }
                return this.buttonSupprimerObstacle;
            }
        }

        public void SupprimerObstacle()
        {
            listObstacleAjouter.Remove(SelectedObstacleAjouter);
        }

        public void AjoutNouvelleReservation()
        {
            Reservation LaFinalReservation = new Reservation();
            List<Reservation> laListDeToutesLesReservation = new List<Reservation>();
            laListDeToutesLesReservation = vmDaoReservation.SelectAll();

            if (selectedDate != null && selectedVille != null && selectedSalle != null && this.HeureReservation != "" && this.MinuteReservation != ""
                && selectedTheme != null && listJoueur != null && selectedTechnicien != null
                )
            {
                //recuperation date, heure, minute et convertisser en datetime
                int year = selectedDate.Year;
                int mouth = selectedDate.Month;
                int days = selectedDate.Day;

                int heure = int.Parse(heureReservation);
                int minute = int.Parse(MinuteReservation);

                DateTime dateRes = new DateTime(year, mouth, days, heure, minute, 0);
                LaFinalReservation.DateRes = dateRes;

                //recupere l'id Reservation

                //id salle
                LaFinalReservation.IdSalle = selectedSalle;

                //prix
                int total = 0;
                foreach (Obstacle r in listObstacleAjouter)
                {
                    total = r.Prix + total;
                }

                LaFinalReservation.Prix = total;

                //nb client
                LaFinalReservation.NbClient = listJoueur.Count();

                //id client
                LaFinalReservation.IdClient = selectedJoueur;

                //id technicien
                LaFinalReservation.IdTechnicien = selectedTechnicien;

                //ajouter un combobox pour le theme;
                LaFinalReservation.IdTheme = selectedTheme;

                foreach (Client r in ListJoueur)
                {
                    laListDeToutesLesReservation = vmDaoReservation.SelectAll();
                    LaFinalReservation.Id = vmDaoReservation.lePlusGrandIntDansLaTableReservation(vmDaoReservation.SelectAll());
                    LaFinalReservation.IdClient = r;
                    vmDaoReservation.Insert(LaFinalReservation);
                }

                int i = 1;
                foreach (Obstacle r in listObstacleAjouter)
                {

                    vmDaoObstacle_Obst.Insert(i, LaFinalReservation, r);
                    i++;
                }
                MessageBox.Show("Vous Avez Ajouter la Reservation");
            }
            else
            {
                MessageBox.Show("Vous Avez Oubliez de rentrer des informations");
            }
        }

    }
}