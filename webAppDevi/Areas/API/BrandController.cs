using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAppDevi.Common;
using webAppDevi.Models;

namespace webAppDevi.Areas.API
{
    public class BrandController : ApiController
    {
        Services s = new Services();
        #region "Bike Brand"
        /// <summary>
        /// Get all bike brand
        /// </summary>                
       
        [CustomAuthorize]
        [Route("api/brand/view")]
        [HttpGet]
        public List<BikeBrand> view()
        {
            return s.GetAllBikeBrand();
        }
        #endregion
    }
}
