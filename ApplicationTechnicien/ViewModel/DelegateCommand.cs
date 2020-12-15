using System;

namespace ApplicationTechnicien.ViewModel
{
    internal class DelegateCommand
    {
        private Action newFenetre;

        public DelegateCommand(Action newFenetre)
        {
            this.newFenetre = newFenetre;
        }
    }
}