using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Data;
using Data.Interfaces;
using Data.Repo;
using Models.Tables;

namespace Dvd1.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdsController : ApiController
    {
        //public IDvdsRepo GetMode()
        //{
        //    string mode = ConfigurationManager.AppSettings["Mode"].ToString();

        //    if (mode == "ADO")
        //    {
        //        ADORepo repo = new ADORepo();
        //        return repo;
        //    }
        //    else if (mode == "DAP")
        //    {
        //        DapperRepo repo = new DapperRepo();
        //        return repo;
        //    }
        //    else
        //    {
        //        MockRepo repo = new MockRepo();
        //        return repo;
        //    }
        //}

        private IDvdsRepo repo = Factory.GetMode();

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvds()
        {

            //IDvdsRepo repo = GetMode();

            List<Dvds> List = repo.GetDvds();

            return Ok(List);

        }

        [Route("dvds/title/{title}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdTitle(string title)
        {

           // IDvdsRepo repo = GetMode();

            List<Dvds> List = repo.GetsDvdsTitle(title);

            return Ok(List);
        }
        [Route("dvds/year/{Year}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdsearchYear(string Year)
        {
           // IDvdsRepo repo = GetMode();

            List<Dvds> List = repo.GetDvdsYear(Year);

            return Ok(List);
        }

        [Route("dvds/director/{Director}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdDirector(string Director)
        {
           // IDvdsRepo repo = GetMode();

            List<Dvds> List = repo.GetDvdsDirector(Director);

            return Ok(List);
        }

        [Route("dvds/rating/{Rating}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetDvdRating(string Rating)
        {
           // IDvdsRepo repo = GetMode();

            List<Dvds> List = repo.GetDvdsRating(Rating);

            return Ok(List);
        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult deleteDVD(int dvdId)
        {
          //  IDvdsRepo repo = GetMode(); ;

            repo.DeleteDvdId(dvdId);

            return Ok();

        }

        [Route("dvd/{dvdId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult displayDVD(int dvdId)
        {
           // IDvdsRepo repo = GetMode();

            Dvds dvd = repo.GetDvdId(dvdId);

            return Ok(dvd);

        }

        [Route("dvd/{dvd}")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult editDVDId(Dvds dvd)
        {
          //  IDvdsRepo repo = GetMode();

            repo.UpdateDvdId(dvd);

            Dvds newdvd = repo.GetDvdId(dvd.dvdId);

            return Ok(newdvd);

        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult insertDVD(Dvds dvd)
        {
           // IDvdsRepo repo = GetMode();

            repo.PostDvd(dvd);

            Dvds newdvd = repo.GetDvdId(dvd.dvdId);

            return Ok(newdvd);
        }

    }
}
