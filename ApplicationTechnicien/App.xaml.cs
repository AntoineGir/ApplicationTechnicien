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
            theDaoTheme = new DaoTheme(mydbal);
            theDaoVille = new DaoVille(mydbal);
            theDaoClient = new DaoClient(mydbal);
            theDaoAvis = new DaoAvis(mydbal, theDaoClient, theDaoTheme);
            
            theDaoObstacle = new DaoObstacle(mydbal, theDaoTheme);
            
            
            theDaoUtilisateur = new DaoUtilisateur(mydbal, theDaoVille);
            theDaoSalle = new DaoSalle(mydbal, theDaoVille, theDaoTheme);
            theDaoReservation = new DaoReservation(mydbal, theDaoClient, theDaoSalle, theDaoUtilisateur, theDaoTheme);
            theDaoPlacement_Obst = new DaoPlacement_Obst(mydbal, theDaoReservation, theDaoObstacle);
            theDaoTransaction = new DaoTransaction(mydbal, theDaoClient, theDaoReservation);
            


            MainWindow wnd = new MainWindow(theDaoAvis, theDaoClient, theDaoObstacle, theDaoPlacement_Obst, theDaoReservation, theDaoSalle, theDaoTheme, theDaoTransaction, theDaoUtilisateur, theDaoVille);
            wnd.Show();
        }
    }


}
