﻿using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IServiceClient: IService<Client>
    {
        public double MontantTot(Client c);
        public int NbReserv(Client c);
    }
}