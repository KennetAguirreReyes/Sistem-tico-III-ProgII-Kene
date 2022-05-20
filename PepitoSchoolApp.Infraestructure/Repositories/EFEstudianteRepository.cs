using PepitoSchoolApp.Domain.Entities;
using PepitoSchoolApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepitoSchoolApp.Infraestructure.Repositories
{
    public class EFEstudianteRepository : IEstudianteRepository
    {
        private IPepitoSchoolDbContext pepitoschoolDbContext;

        public EFEstudianteRepository(IPepitoSchoolDbContext pepitoschoolDbContext)
        {
            this.pepitoschoolDbContext = pepitoschoolDbContext;
        }

        public double CalcularPromedio(int nota1, int nota2, int nota3, int nota4)
        {
            
            try
            {
       
                double promedio = 0;
                    
                return promedio =(nota1 + nota2 + nota3 + nota4)/ 4;

            }
            catch
            {
                throw;
            }
        }

        public void Create(Estudiante t)
        {
            try
            {
                ValidateEstudiante(t);
                pepitoschoolDbContext.Estudiantes.Add(t);
                pepitoschoolDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Employee no puede ser null.");
                }

                Estudiante estudiante = FindByCarnet(t.Carnet);
                if (estudiante == null)
                {
                    throw new Exception($"El objeto con Carnet {t.Carnet} no existe.");
                }

                pepitoschoolDbContext.Estudiantes.Remove(estudiante);
                int result = pepitoschoolDbContext.SaveChanges();

                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Estudiante FindByCarnet(string carnet)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(carnet))
                {

                    throw new ArgumentException($"El objeto Carnet no puede ser null o estar vacia");
                }

                return pepitoschoolDbContext.Estudiantes.FirstOrDefault(x => x.Carnet.Equals(carnet));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Estudiante FindByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {

                    throw new ArgumentException($"El objeto nombre no puede ser null o estar vacia");
                }

                return pepitoschoolDbContext.Estudiantes.FirstOrDefault(x => x.Carnet.Equals(name));
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public Estudiante FindByEmail(string email)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(email))
        //        {

        //            throw new ArgumentException($"El objeto email no puede ser null o estar vacio");
        //        }


        //        return pepitoschoolDbContext.Estudiantes.FirstOrDefault(x => x.Email.Equals(email));

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public IEnumerable<Estudiante> FindByLastnames(string lastnames)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(lastnames))
        //        {
        //            throw new ArgumentException("El objeto apellido no puede ser null o estar vacio");
        //        }

        //        return pepitoschoolDbContext.Estudiantes.Where(x => x.Lastnames.Equals(lastnames, StringComparison.CurrentCultureIgnoreCase))
        //                                .ToList();

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        public List<Estudiante> GetAll()
        {
            try
            {
                return pepitoschoolDbContext.Estudiantes.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Update(Estudiante t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto estudiante no puede ser null.");
                }

                Estudiante estudiante = FindByCarnet(t.Carnet);
                if (estudiante == null)
                {
                    throw new Exception($"El objeto empleado con esa dni no existe.");
                }

                estudiante.Nombres = t.Nombres;
                estudiante.Apellidos = t.Apellidos;
                estudiante.Direccion = t.Direccion;
                estudiante.Phone = t.Phone;
                estudiante.Correo = t.Correo;

                pepitoschoolDbContext.Estudiantes.Update(estudiante);
                return pepitoschoolDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        private void ValidateEstudiante(Estudiante estudiante)
        {
            if (estudiante == null)
            {
                throw new ArgumentNullException("El objeto estudiante no puede ser null.");
            }

            if (string.IsNullOrWhiteSpace(estudiante.Correo))
            {
                throw new Exception("El email no puede ser null o vacio.");
            }

            if (string.IsNullOrWhiteSpace(estudiante.Nombres))
            {
                throw new Exception("El nombre del estudiante no puede ser null o vacio.");
            }
        }
    }
}
