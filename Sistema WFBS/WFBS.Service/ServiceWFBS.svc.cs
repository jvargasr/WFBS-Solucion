using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml.Serialization;
using WFBS.Business.Core;
using WFBS.Business.Log;

namespace WFBS.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceWFBS : IServiceWFBS
    {
        public void log(string msgxml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(string), new XmlRootAttribute("string"));
            StringReader stringReader = new StringReader(msgxml);
            string msg = (string)serializer.Deserialize(stringReader);
            Logger.log(msg);
        }
        public bool login(string userxml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Usuario), new XmlRootAttribute("Usuario"));
            StringReader stringReader = new StringReader(userxml);
            Usuario u = (Usuario)serializer.Deserialize(stringReader);
            return u.ValidarUsuario();
        }
        public string obtenerArea(string id_area)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Area), new XmlRootAttribute("Area"));
            StringReader stringReader = new StringReader(id_area);
            Area a = (Area)serializer.Deserialize(stringReader);
            a.Read();
            return a.Serializar();
        }
        public string obtenerCompetencia(string id_competencia)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Competencia), new XmlRootAttribute("Competencia"));
            StringReader stringReader = new StringReader(id_competencia);
            Competencia c = (Competencia)serializer.Deserialize(stringReader);
            c.Read();
            return c.Serializar();
        }
        public string obtenerUsuario(string rut)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Usuario), new XmlRootAttribute("Usuario"));
            StringReader stringReader = new StringReader(rut);
            Usuario u = (Usuario)serializer.Deserialize(stringReader);
            u.Read();
            return u.Serializar();
        }
        public bool InsertarEvaluacion(string evaluacionxml)
        {
            Evaluacion e = new Evaluacion(evaluacionxml);
            return e.Create();
        }
        public bool insertarAuditoria(string auditoriaxml)
        {
            Auditoria a = new Auditoria(auditoriaxml);
            return a.Create();
        }
        public string obtenerComptenteciasArea(string id_area)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Area), new XmlRootAttribute("Area"));
            StringReader stringReader = new StringReader(id_area);
            Area a = (Area)serializer.Deserialize(stringReader);

            ColeccionCompetencia cc = new ColeccionCompetencia();
            return cc.Serializar(cc.ReadAllCompetencias());
        }
        public string obtenerHabilidadesCompetencia(string id_competencia)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Competencia), new XmlRootAttribute("Competencia"));
            StringReader stringReader = new StringReader(id_competencia);
            Competencia c = (Competencia)serializer.Deserialize(stringReader);
            ColeccionHabilidad ch = new ColeccionHabilidad();
            return ch.Serializar(ch.ObtenerHabPorCom(c.Id_competencia));
        }
        public bool usuarioEvaluado(string evaluacionxml)
        {
            Evaluacion e = new Evaluacion(evaluacionxml);
            return e.usuarioEvaluado();
        }
        public string obtenerFuncionariosPorJefe(string usuariojefexml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Usuario), new XmlRootAttribute("Usuario"));
            StringReader stringReader = new StringReader(usuariojefexml);
            Usuario u = (Usuario)serializer.Deserialize(stringReader);

            ColeccionUsuario c = new ColeccionUsuario();
            return c.Serializar(c.ObtenerFuncionariosPorJefe(u.Rut));
        }
    }
}
