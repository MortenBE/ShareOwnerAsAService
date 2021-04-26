using System;
using System.Collections.Generic;
using DelProjekt1_Disp_Backend.Models;

namespace DelProjekt1_Disp_Backend.Services
{
    public class HaandvaerkerService
    {
        private List<Haandvaerker> list;
        public HaandvaerkerService()
        {
            list = new List<Haandvaerker>(); 
            var haandvaerker = new Haandvaerker
            {
                HVAnsaettelsedato = DateTime.Today,
                HVEfternavn = "Testsen",
                HVFagomraade = "Tester",
                HVFornavn = "Test",
                HaandvaerkerId = 1
            };
            list.Add(haandvaerker);
        } 
        public List<Haandvaerker> GetAllHandvaekere()
        {
            return list;
        }

        public Haandvaerker AddHandvaeker(Haandvaerker Haandvaerker)
        {
            list.Add(Haandvaerker);
            return Haandvaerker;
        }
    }
}