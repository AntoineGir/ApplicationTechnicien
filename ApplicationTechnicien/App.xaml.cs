using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ModelLayer.Business;
using ModelLayer.Data;

namespace ApplicationTechnicien
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Dbal mydbal;
        private DaoAvis theDaoAvis;
        private DaoClient theDaoClient;
        private DaoObstacle theDaoObstacle;
        private DaoPlacement_Obst theDaoPlacement_Obst;
        private DaoReservation theDaoReservation;
        private DaoSalle theDaoSalle;
        private DaoTheme theDaoTheme;
        private DaoTransaction theDaoTransaction;
        private DaoUtilisateur theDaoUtilisateur;
        private DaoVille theDaoVille;
    
        
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            mydbal = new Dbal("Escp_Game");
            theDaoAvis = new DaoAvis(mydbal, theDaoClient, theDaoTheme);
            theDaoClient = new DaoClient(mydbal);
            theDaoObstacle = new DaoObstacle(mydbal, theDaoTheme);
            theDaoPlacement_Obst = new DaoPlacement_Obst(mydbal, theDaoReservation, theDaoObstacle);
            theDaoReservation = new DaoReservation(mydbal, theDaoClient, theDaoSalle, theDaoUtilisateur, theDaoTheme);
            theDaoSalle = new DaoSalle(mydbal, theDaoVille, theDaoTheme);
            theDaoTheme = new DaoTheme(mydbal);
            theDaoTransaction = new DaoTransaction(mydbal, theDaoClient, theDaoReservation);
            theDaoUtilisateur = new DaoUtilisateur(mydbal, theDaoVille);
            theDaoVille = new DaoVille(mydbal);
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }


}
