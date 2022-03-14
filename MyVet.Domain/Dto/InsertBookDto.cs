using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto.Library
{
    public class InsertBookDto
    {
        public string Name { get; set; }

        public DateTime? DateRelease { get; set; }

        public string Description { get; set; }

        public int IdEditorial { get; set; }

        public int IdAuthor { get; set; }

        public int IdTypeBook { get; set; }

        public int IdState { get; set; }
    }
}
