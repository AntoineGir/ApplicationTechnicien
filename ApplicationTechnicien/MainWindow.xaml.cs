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
            AjouterReservation.DataContext = new ViewModel.viewModelAjouterReservation(thedaoclient, thedaoobstacle,thedaoplacement_Obst,thedaoreservation,thedaosalle,thedaotheme,thedaoutilisateur,thedaoville);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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

            LblListeObstacle.Visibility = Visibility.Visible;
            LtbListeObstacle.Visibility = Visibility.Visible;
            TxbObstacle.Visibility = Visibility.Visible; 
            BtnObstacleRecherche.Visibility = Visibility.Visible;
            BtnObstacleAjouter.Visibility = Visibility.Visible;
            LblObstacleAjouter.Visibility = Visibility.Visible;
            LtbObstacleAjouter.Visibility = Visibility.Visible;
            BtnObstacleSupprimer.Visibility = Visibility.Visible;
            BtnObstacleSuivant.Visibility = Visibility.Visible;


        }
    }
}
