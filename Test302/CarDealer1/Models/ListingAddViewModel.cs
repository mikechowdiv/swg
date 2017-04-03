using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Tables;

namespace CarDealer1.Models
{
    public class ListingAddViewModel : IValidatableObject
    {
        public IEnumerable<SelectListItem> States { get; set; }
        public IEnumerable<SelectListItem> MakesTypes { get; set; }
        public Listing Listing { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (Listing.Year <= 0)
            {
                errors.Add(new ValidationResult("Year is required"));
            }

            if (string.IsNullOrEmpty(Listing.City))
            {
                errors.Add(new ValidationResult("City is required"));
            }

            if (string.IsNullOrEmpty(Listing.ListingDescription))
            {
                errors.Add(new ValidationResult("Description is required"));
            }

            if (ImageUpload != null && ImageUpload.ContentLength > 0)
            {
                var extensions = new string[] { ".jpg", ".png", ".gif", ".jpeg" };

                var extension = Path.GetExtension(ImageUpload.FileName);

                if (!extensions.Contains(extension))
                {
                    errors.Add(new ValidationResult("Image file must be a jpg, png, gif, or jpeg."));
                }
            }
            else
            {
                errors.Add(new ValidationResult("Image file is required"));
            }

            if (Listing.Rate <= 0)
            {
                errors.Add(new ValidationResult("Rate must be greater than 0"));
            }

            if (Listing.Mileage <= 0)
            {
                errors.Add(new ValidationResult("Mileage must be greater than 0"));
            }

            return errors;
        }
    }
}