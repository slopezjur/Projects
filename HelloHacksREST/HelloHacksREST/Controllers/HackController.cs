using HelloHacksREST.Models;
using HelloHacksREST.Repositories;
using HelloREST.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace HelloHacksREST.Controllers
{
    public class HackController : ApiController
    {
        private HackRepository _hackRepository;

        public HackController()
        {
            _hackRepository = new HackRepository(new HackDBContext(ConfigurationManager.ConnectionStrings["HelloHacksREST"].ConnectionString));
        }
        
        public HackController(HackRepository hackRepository)
        {
            _hackRepository = hackRepository;
        }

        // GET api/Hack/
        public Hack Get(int Id) 
        {
            return _hackRepository.Get(Id);
        }

        // GET api/Hack/
        public List<Hack> Get()
        {
            return _hackRepository.GetAll();
        }

        // POST api/Hack/
        public async Task<IHttpActionResult> Post(Hack hack)
        {
            bool result = _hackRepository.Add(hack);

            ResponseMessageResult response = null;
            
            // TODO: Create a CUSTOM HTTP ERROR CODES
            if (result)
            {
                response = new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateResponse((HttpStatusCode)209,
                        new HttpError("SupaHack created correctly + Extra Hidden Hacks!")
                    )
                );
            }
            else
            {
                response = new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateErrorResponse((HttpStatusCode)495,
                        new HttpError("Such a petition bro! It didn't work!")
                    )
                );
            }

            return response;
        }
        
        // PUT api/Hack/
        public async Task<IHttpActionResult> Put(Hack hack)
        {
            bool result = _hackRepository.Update(hack);

            ResponseMessageResult response = null;
            
            // TODO: Create a CUSTOM HTTP ERROR CODES
            if (result)
            {
                response = new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateResponse((HttpStatusCode)210,
                        new HttpError("SupaHack updated correctly. Well done!")
                    )
                );
            }
            else
            {
                response = new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateErrorResponse((HttpStatusCode)496,
                        new HttpError("Not this time...")
                    )
                );
            }

            return response;
        }

        // DELETE api/Hack/
        public async Task<IHttpActionResult> Delete(int Id)
        {
            bool result = _hackRepository.Delete(Id);

            ResponseMessageResult response = null;
            
            // TODO: Create a CUSTOM HTTP ERROR CODES
            if (result)
            {
                response = new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateResponse((HttpStatusCode)211,
                        new HttpError("SupaDeleted!")
                    )
                );
            }
            else
            {
                response = new System.Web.Http.Results.ResponseMessageResult(
                    Request.CreateErrorResponse((HttpStatusCode)497,
                        new HttpError("Not today. Try the DELETE later.")
                    )
                );
            }

            return response;
        }
    }
}
