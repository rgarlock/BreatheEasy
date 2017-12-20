using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
//using BreatheEasyApp.GenericHandler;
using BreatheEasyApp.Models;

namespace BreatheEasyApp.Controllers
{
    public class ImagesController : Controller
    {
        private BreatheEasyEntities db = new BreatheEasyEntities();

        // GET: Images
        public async Task<ActionResult> Index(int id)
        {
            var image = db.Images.Find(id);
            if (image == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
                
            }
            
            return new FileContentResult(image.Image1, image.ContentType);
        }

       
        


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
