using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Models.BookModels
{
    public class UpdateBookImage
    {
        public int book_id { get; set; }
        public IFormFile ImgFile { get; set; }
    }
}
