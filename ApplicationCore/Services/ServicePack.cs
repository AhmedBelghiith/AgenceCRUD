using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServicePack : Service<Pack>, IServicePack
    {
        public ServicePack(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public float PourcentagePacksLongueDuree(Pack pack)
        {
            int nbtot = GetAll().Count();
            int nbLongueDuree = GetMany(p=>p.Duree > 7).Count();
            return ((nbLongueDuree / nbtot) * 100);
        }

        public double PrixTotPack(Pack pack)
        {
            return pack.Activites.Sum(a => a.Prix);
        }
    }
}
