using System;
using System.Collections.Generic;
using System.Text;

namespace Tablice.Logic
{
    interface IDataManipulator
    {
        int GetDoctorsVolume();
        int GetSaldo(int doctorId);
        int GetGlobalSaldo();
        string GetName(int doctorId);
        string GetMostHardworkingDoctor();
    }
}
