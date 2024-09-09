using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyPortfolio.Models
{
    public class ProfileImage
    {
        public Guid ProfileImageId { get; set; }

        public Guid PortfolioUserId { get; set; }

        public string ImageName { get; set; }

        public string ContentType { get; set; }

        public byte[] ImageData { get; set; }

        // Property to get the image in base64 format for display in the view.
        [NotMapped]  // This ensures the property will not affect your database schema. 

        public string ImageBase64
        {
            get
            {
                if (ImageData != null && ImageData.Length > 0)
                {
                    return Convert.ToBase64String(ImageData);
                }
                return null;
            }
        }
    }
}