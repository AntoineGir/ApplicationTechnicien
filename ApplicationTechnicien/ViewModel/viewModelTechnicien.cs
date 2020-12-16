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

        private DateTime selectedDate = new DateTime();
        private Salle selectedSalle = new Salle();
        private Ville selectedVille = new Ville();
        private Reservation selectedReservation = new Reservation();

        private ObservableCollection<Avis> listAvis;
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



        /*
        public DateTime SelectedDate
        {
            get => selectedDate;
            set
            {
                if(selectedDate != value)
                {
                    selectedDate = value;
                    OnPropertyChanged("SelectedReservation");
                }
            }
        }*/


    }
}