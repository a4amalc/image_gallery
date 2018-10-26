using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ImageGallery.Controllers
{
    [Route("api/[controller]")]
    public class GalleryController : Controller
    {
       
        /// <summary>
        /// API to get image details
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]")]
        public IEnumerable<ImageDetails> GetImageList()
        {

            return populateImageList();
        }

        /// <summary>
        /// Image details type
        /// </summary>
        public class ImageDetails
        {
            public Boolean hide { get; set; }
            public string image { get; set; }
            public string thumbnail { get; set; }
            public string description { get; set; }
            public string name { get; set; }
        }

        /// <summary>
        /// Method to populate imagelist
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ImageDetails> populateImageList()
        {
            List<ImageDetails> imageList =new List<ImageDetails>();

            ///Dynamically populating image details
            for (int i= 1;i<= 9;i++)
            {
                ImageDetails img = new ImageDetails();
                img.description = "This is image"+i;
                img.name = "Image - "+i;
                img.hide = true;
                img.thumbnail = "../../assets/images/thumbs/"+i+".jpg";
                imageList.Add(img);
            }
            return imageList;
        }
    }
}
