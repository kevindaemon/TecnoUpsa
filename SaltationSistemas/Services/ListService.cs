using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaltationSistemas.Services
{
    public class ListService
    {
        public Areas.Estudiante.Services.EstudianteList EstudianteList
        {
            get
            {
                return Areas.Estudiante.Services.EstudianteList.GetInstance();
            }
        }
        public Areas.Docente.Services.DocenteList DocenteList
        {
            get
            {
                return Areas.Docente.Services.DocenteList.GetInstance();
            }
        }
        public void SaveChanges()
        {
            /* completo */
            /*Areas.Estudiante.Services.EstudianteList.GetInstance().SaveChanges();*/
            /*resumido ^_^ */
            EstudianteList.SaveChanges();
            DocenteList.SaveChanges();
        }
    }
}