using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tablice.Models;

namespace Tablice.Logic
{
    class ObjectDataManipulator : IDataManipulator
    {
        private readonly List<Doctor> _doctors;


        public ObjectDataManipulator(List<Doctor> doctors)
        {
            _doctors = doctors;
        }


        public string GetName(int doctorId)
        {
            if (_doctors == null || _doctors.Count == 0 || doctorId < 0 || doctorId > _doctors.Count)
                throw new ArgumentException("There is no such doctor");

            return _doctors[doctorId].Name;
        }

        public int GetSaldo(int doctorId)
        {
            if (_doctors == null || _doctors.Count == 0 || doctorId < 0 || doctorId > _doctors.Count)
                throw new ArgumentException("There is no such doctor");

            var doctor = _doctors[doctorId];

            return doctor.AdmittedPatients - doctor.DischargedPatients;
        }


        public int GetGlobalSaldo()
        {
            var admittedSum = 0;
            var dischargedSum = 0;

            foreach (var doctor in _doctors)
            {
                admittedSum += doctor.AdmittedPatients;
                dischargedSum += doctor.DischargedPatients;
            }

            return admittedSum - dischargedSum;
        }


        public string GetMostHardworkingDoctor()
        {
            Doctor mostHardworkingDoctor = null;
            var maxDischargedPatients = 0;

            foreach(var doctor in _doctors)
            {
                if(doctor.DischargedPatients > maxDischargedPatients)
                {
                    mostHardworkingDoctor = doctor;
                    maxDischargedPatients = doctor.DischargedPatients;
                }
            }

            return mostHardworkingDoctor.Name;
        }

        public int GetDoctorsVolume()
        {
            return _doctors.Count;
        }
    }
}
