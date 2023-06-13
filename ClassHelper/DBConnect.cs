using CurcaNaCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurcaNaCore.ClassHelper
{
    internal class DBConnect
    {
        public static _130123_ChichikinContext userDataBase { get; set; } = new _130123_ChichikinContext();
    }
}
