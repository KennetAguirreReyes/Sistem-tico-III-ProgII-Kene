using PepitoSchoolApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolApp.Applications.Interfaces
{
    public interface IEstudianteService : IService<Estudiante>
    {
        Estudiante FindByCarnet(string carnet);
        Estudiante FindByName(string name);
        //IEnumerable<Estudiante> FindByLastnames(string lastnames);
        double CalcularPromedio(int nota1, int nota2, int nota3, int nota4);
    }
}
