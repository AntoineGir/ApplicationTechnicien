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
            mainGrid.DataContext = new ViewModel.viewModelTechnicien(thedaoavis,thedaoclient, thedaoobstacle, thedaoplacement_Obst, thedaoreservation, thedaosalle, thedaotheme, thedaotransaction, thedaoutilisateur, thedaoville);
            
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            AjouterReservation wnd = new AjouterReservation();
            wnd.Show();
        }
    }
}
