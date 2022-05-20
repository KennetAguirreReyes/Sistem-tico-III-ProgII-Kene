using PepitoSchoolApp.Applications.Interfaces;
using PepitoSchoolApp.Domain.Entities;
using PepitoSchoolApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolApp.Applications.Services
{
    public class EstudianteService : IEstudianteService
    {
        private IEstudianteRepository estudianteRepository;

        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }
        public double CalcularPromedio(int nota1, int nota2, int nota3, int nota4)
        {
            return estudianteRepository.CalcularPromedio(nota1, nota2, nota3, nota4);
        }

        public void Create(Estudiante t)
        {
            estudianteRepository.Create(t);
        }

        public bool Delete(Estudiante t)
        {
            return estudianteRepository.Delete(t);
        }

        public Estudiante FindByCarnet(string carnet)
        {
            return estudianteRepository.FindByCarnet(carnet);
        }

        public Estudiante FindByName(string name)
        {
            return estudianteRepository.FindByCarnet(name);
        }

        public List<Estudiante> GetAll()
        {
            return estudianteRepository.GetAll();
        }

        public int Update(Estudiante t)
        {
            return estudianteRepository.Update(t);
        }
    }
}
