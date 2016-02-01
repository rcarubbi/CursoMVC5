using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;

namespace AvaliadorGastronomico.Domain
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }
    }
}
