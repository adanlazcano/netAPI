using Microsoft.AspNetCore.Mvc;
using netCoreWebApi.Models;

namespace netCoreWebApi.Controllers
{
    [ApiController]
    [Route("Client")]
    public class ClientController : ControllerBase
    {

        #region list
        [HttpGet]
        [Route("list")]
        public dynamic List()
        {
            try
            {


                List<Client> clients = new List<Client>
           {
               new Client
               {
                   id="1",
                   name="Adan",
                   mail="a@gmail.com"

               },
               new Client
               {
                   id="2",
                   name="Antonelita",
                   mail="anto@gmail.com"

               }

           };

                return Ok(clients);
            }
            catch (Exception err)
            {
                string errMsg = err.Message + Environment.NewLine + err.InnerException;
                return StatusCode(500, errMsg);
            }

        }
        #endregion

        #region save
        [HttpPost]
        [Route("save")]
        public dynamic Save(Client client)
        {
            try
            {

                client.id = "3";

                return new
                {
                    success = true,
                    message = "client registered",
                    client

                };
            }
            catch (Exception err)
            {
                string errMsg = err.Message + Environment.NewLine + err.InnerException;
                return StatusCode(500, errMsg);
            }
        }
        #endregion

        #region getClient
        [HttpGet]
        [Route("client/{id}")]
        public dynamic Client(string id)
        {
            try
            {



                Client client = new Client
                {
                    id = id,
                    name = "Adan",
                    mail = "a@gmail.com"

                };

                return Ok(client);
            }
            catch (Exception err)
            {
                string errMsg = err.Message + Environment.NewLine + err.InnerException;
                return StatusCode(500, errMsg);
            }

        }
        #endregion

        #region delete
        [HttpDelete]
        [Route("delete/{id}")]
        public dynamic Delete(string id,Client client)
        {
            try
            {

                string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;

                if (token != "adan123")
                {
                    return StatusCode(401, "Unauthorized client error");
                }

                client.id = id;

                return new
                {
                    success = true,
                    message = "client deleted",
                    client

                };
            }
            catch (Exception err)
            {
                string errMsg = err.Message + Environment.NewLine + err.InnerException;
                return StatusCode(500, errMsg);
            }
        }
        #endregion
    }
}
