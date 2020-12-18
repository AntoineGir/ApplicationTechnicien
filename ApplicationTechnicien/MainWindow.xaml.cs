using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ModelLayer.Business;
using ModelLayer.Data;

namespace ApplicationTechnicien
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(DaoAvis thedaoavis, DaoClient thedaoclient, DaoObstacle thedaoobstacle, DaoPlacement_Obst thedaoplacement_Obst, DaoReservation thedaoreservation, DaoSalle thedaosalle, DaoTheme thedaotheme, DaoTransaction thedaotransaction, DaoUtilisateur thedaoutilisateur, DaoVille thedaoville)
        {
            //https://www.youtube.com/watch?v=YoZcAx_0rNM

            InitializeComponent();
            fenetrePrincipal.DataContext = new ViewModel.viewModelTechnicien(thedaoavis, thedaoclient, thedaoobstacle, thedaoplacement_Obst, thedaoreservation, thedaosalle, thedaotheme, thedaotransaction, thedaoutilisateur, thedaoville);

            //AjouterReservation.DataContext = new ViewModel.viewModelAjouterReservation(thedaoclient, thedaoobstacle,thedaoplacement_Obst,thedaoreservation,thedaosalle,thedaotheme,thedaoutilisateur,thedaoville);
            AjouterReservation.DataContext = new ViewModel.viewModelTechnicien(thedaoavis, thedaoclient, thedaoobstacle, thedaoplacement_Obst, thedaoreservation, thedaosalle, thedaotheme, thedaotransaction, thedaoutilisateur, thedaoville);
        }

        private void BtnSuivantVersObstacle_Click(object sender, RoutedEventArgs e)
        {
            AjouterDateReservation.Visibility = Visibility.Hidden;
            DateAjoutReservation.Visibility = Visibility.Hidden;
            AjouterVilleReservation.Visibility = Visibility.Hidden;
            ListVille.Visibility = Visibility.Hidden;
            AjouterSalleReservation.Visibility = Visibility.Hidden;
            ListSalleReservation.Visibility = Visibility.Hidden;
            AjouterHeureReservation.Visibility = Visibility.Hidden;
            TxbMinuteReservation.Visibility = Visibility.Hidden;
            BtnSuivantVersObstacle.Visibility = Visibility.Hidden;

            LblListeObstacle.Visibility = Visibility.Visible;
            LtbListeObstacle.Visibility = Visibility.Visible;
            TxbObstacle.Visibility = Visibility.Visible;
            BtnObstacleAjouter.Visibility = Visibility.Visible;
            LblObstacleAjouter.Visibility = Visibility.Visible;
            LtbObstacleAjouter.Visibility = Visibility.Visible;
            BtnObstacleSupprimer.Visibility = Visibility.Visible;
            BtnObstacleSuivant.Visibility = Visibility.Visible;
            BtnRechercheObstacle.Visibility = Visibility.Visible;
            BtnRetourVersHorraire.Visibility = Visibility.Visible;
            TxbRechercheObstacle.Visibility = Visibility.Visible;
            LblObstacle.Visibility = Visibility.Visible;
            LblTheme.Visibility = Visibility.Visible;
            ListThemePourObstacle.Visibility = Visibility.Visible;
        }

        private void BtnObstacleSuivant_Click(object sender, RoutedEventArgs e)
        {
            LblListeObstacle.Visibility = Visibility.Hidden;
            LtbListeObstacle.Visibility = Visibility.Hidden;
            TxbObstacle.Visibility = Visibility.Hidden;
            BtnRechercheObstacle.Visibility = Visibility.Hidden;
            BtnObstacleAjouter.Visibility = Visibility.Hidden;
            LblObstacleAjouter.Visibility = Visibility.Hidden;
            LtbObstacleAjouter.Visibility = Visibility.Hidden;
            BtnObstacleSupprimer.Visibility = Visibility.Hidden;
            BtnObstacleSuivant.Visibility = Visibility.Hidden;
            BtnRetourVersHorraire.Visibility = Visibility.Hidden;
            TxbRechercheObstacle.Visibility = Visibility.Hidden;
            LblObstacle.Visibility = Visibility.Hidden;
            LblTheme.Visibility = Visibility.Hidden;
            ListThemePourObstacle.Visibility = Visibility.Hidden;


            LblListeClient.Visibility = Visibility.Visible;
            LtbClient.Visibility = Visibility.Visible;
            LblListeJoueur.Visibility = Visibility.Visible;
            TxBChercherNomClients.Visibility = Visibility.Visible;
            LblPrenom.Visibility = Visibility.Visible;
            TxBChercherPrenomClients.Visibility = Visibility.Visible;
            BtnRecherche.Visibility = Visibility.Visible;
            BtnAjouterClientsDansJoueur.Visibility = Visibility.Visible;
            BtnSupprimerJoueur.Visibility = Visibility.Visible;
            LblJoueur.Visibility = Visibility.Visible;
            LtBJoueur.Visibility = Visibility.Visible;
            BtnSuivant1.Visibility = Visibility.Visible;
            BtnRetourVersObstacle.Visibility = Visibility.Visible;
        }

        private void BtnRetourVersObstacle_Click(object sender, RoutedEventArgs e)
        {
            LblListeClient.Visibility = Visibility.Hidden;
            LtbClient.Visibility = Visibility.Hidden;
            LblListeJoueur.Visibility = Visibility.Hidden;
            TxBChercherNomClients.Visibility = Visibility.Hidden;
            LblPrenom.Visibility = Visibility.Hidden;
            TxBChercherPrenomClients.Visibility = Visibility.Hidden;
            BtnRecherche.Visibility = Visibility.Hidden;
            BtnAjouterClientsDansJoueur.Visibility = Visibility.Hidden;
            BtnSupprimerJoueur.Visibility = Visibility.Hidden;
            LblJoueur.Visibility = Visibility.Hidden;
            LtBJoueur.Visibility = Visibility.Hidden;
            BtnSuivant1.Visibility = Visibility.Hidden;
            BtnRetourVersObstacle.Visibility = Visibility.Hidden;


            LblListeObstacle.Visibility = Visibility.Visible;
            LtbListeObstacle.Visibility = Visibility.Visible;
            TxbObstacle.Visibility = Visibility.Visible;
            BtnObstacleAjouter.Visibility = Visibility.Visible;
            LblObstacleAjouter.Visibility = Visibility.Visible;
            LtbObstacleAjouter.Visibility = Visibility.Visible;
            BtnObstacleSupprimer.Visibility = Visibility.Visible;
            BtnObstacleSuivant.Visibility = Visibility.Visible;
            BtnRetourVersHorraire.Visibility = Visibility.Visible;
            LblObstacle.Visibility = Visibility.Visible;
            TxbRechercheObstacle.Visibility = Visibility.Visible;
            BtnRechercheObstacle.Visibility = Visibility.Visible;
            LblTheme.Visibility = Visibility.Visible;
            ListThemePourObstacle.Visibility = Visibility.Visible;
        }

        private void BtnRetourVersHorraire_Click(object sender, RoutedEventArgs e)
        {
            LblListeObstacle.Visibility = Visibility.Hidden;
            LtbListeObstacle.Visibility = Visibility.Hidden;
            TxbObstacle.Visibility = Visibility.Hidden;
            BtnObstacleAjouter.Visibility = Visibility.Hidden;
            LblObstacleAjouter.Visibility = Visibility.Hidden;
            LtbObstacleAjouter.Visibility = Visibility.Hidden;
            BtnObstacleSupprimer.Visibility = Visibility.Hidden;
            BtnObstacleSuivant.Visibility = Visibility.Hidden;
            BtnRetourVersHorraire.Visibility = Visibility.Hidden;
            LblObstacle.Visibility = Visibility.Hidden;
            TxbRechercheObstacle.Visibility = Visibility.Hidden;
            LblTheme.Visibility = Visibility.Hidden;
            ListThemePourObstacle.Visibility = Visibility.Hidden;


            AjouterDateReservation.Visibility = Visibility.Visible;
            DateAjoutReservation.Visibility = Visibility.Visible;
            AjouterVilleReservation.Visibility = Visibility.Visible;
            ListVille.Visibility = Visibility.Visible;
            AjouterSalleReservation.Visibility = Visibility.Visible;
            ListSalleReservation.Visibility = Visibility.Visible;
            AjouterHeureReservation.Visibility = Visibility.Visible;
            TxbMinuteReservation.Visibility = Visibility.Visible;
            BtnSuivantVersObstacle.Visibility = Visibility.Visible;
        }
    }
}
