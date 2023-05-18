using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceClient : Service<Client>, IServiceClient
    {
        public ServiceClient(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double MontantTot(Client c)
        {
            double prixtotal = 0;
            foreach (var activities in c.Reservations.Select(r=>r.Pack.Activites))
            {
                foreach (var item in activities)
                {
                    prixtotal = prixtotal + item.Prix;
                }
            }return prixtotal;
        }

        public int NbReserv(Client c)
        {
            return c.Reservations.Where(r=>r.DateReservation.Equals(DateTime.Now.Year)).Count();
        }
    }
}
