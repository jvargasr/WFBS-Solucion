using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WFBS.Business.Core
{
    public class ColeccionEvaluacion:List<Evaluacion>
    {
        public ColeccionEvaluacion()
        {

        }

        public ColeccionEvaluacion(string xml)
        {
            XmlSerializer serializador = new XmlSerializer(typeof(List<Evaluacion>));
            StringReader read = new StringReader(xml);

            List<Evaluacion> lista = (List<Evaluacion>)serializador.Deserialize(read);
            this.AddRange(lista);
        }

        //public List<Evaluacion> usuario
    }
}
