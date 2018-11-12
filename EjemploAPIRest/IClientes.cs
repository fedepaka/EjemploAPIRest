using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace EjemploAPIRest
{
    [DataContract]
    public class Cliente
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public string Telefono { get; set; }
        [DataMember]
        public string Mail { get; set; }
    }

    [ServiceContract]
    public interface IClientes
    {
        [OperationContract]
        [WebGet(UriTemplate = "/getAll"
            , ResponseFormat = WebMessageFormat.Json
            , BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Cliente> GetAll();

        [OperationContract]
        [WebGet(UriTemplate = "/get/{idCliente}"
            , ResponseFormat = WebMessageFormat.Json
            , BodyStyle = WebMessageBodyStyle.Wrapped)]
        Cliente Get(string idCliente);

        [OperationContract]
        [WebInvoke(UriTemplate = "/create"
            , RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json
            , Method = "POST"
            , BodyStyle = WebMessageBodyStyle.Wrapped)]
        Cliente Create(Cliente cliente);

        [OperationContract]
        [WebInvoke(UriTemplate = "/update"
            , RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json
            , Method = "POST"
            , BodyStyle = WebMessageBodyStyle.Wrapped)]
        Cliente Update(Cliente cliente);

        [OperationContract]
        [WebInvoke(UriTemplate = "/delete"
            , RequestFormat = WebMessageFormat.Json
            , ResponseFormat = WebMessageFormat.Json
            , BodyStyle = WebMessageBodyStyle.Wrapped
            , Method = "POST")]
        void Delete(int idCliente);
    }
}
