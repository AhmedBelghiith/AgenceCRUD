using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IServicePack:IService<Pack>
    {
        public double PrixTotPack(Pack pack);
        public float PourcentagePacksLongueDuree(Pack pack);
    }
}
