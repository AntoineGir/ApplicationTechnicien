using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Business
{
    public class Transaction
    {
        private int id;
        private char operation;
        private int montant;
        private Reservation reservation;
        private Client idClient;

        public Transaction(int id, char operation, int montant, Reservation reservation, Client idClient)
        {
            Id = id;
            Operation = operation;
            Montant = montant;
            Reservation = reservation;
            IdClient = idClient;
        }
        
        public Transaction(){}

        public int Id { get => id ; set => id = value; }
        public char Operation { get => operation; set => operation = value; }
        public int Montant { get => montant; set => montant= value; }
        public Reservation Reservation { get => reservation; set => reservation = value; }
        public Client IdClient { get => idClient; set => idClient = value; }
    }
}
