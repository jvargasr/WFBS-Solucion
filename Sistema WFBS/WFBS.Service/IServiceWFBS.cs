using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WFBS.Business.Core;

namespace WFBS.Service
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceWFBS
    {
        [OperationContract]
        void log(string msg);

        [OperationContract]
        bool login(string userxml);

        [OperationContract]
        string obtenerArea(string id_area);

        [OperationContract]
        string obtenerCompetencia(string id_competencia);

        [OperationContract]
        string obtenerUsuario(string rut);

        [OperationContract]//p
        string obtenerComptenteciasArea(string id_area);

        [OperationContract]//p
        string obtenerHabilidadesCompetencia(string id_competencia);

        [OperationContract]
        bool InsertarEvaluacion(string evaluacionxml);

        [OperationContract]
        string obtenerFuncionariosPorJefe(string usuariojefexml);    

        [OperationContract]
        bool usuarioEvaluado(string evaluacionxml);

        [OperationContract]
        bool insertarAuditoria(string auditoriaxml);

    }
}
