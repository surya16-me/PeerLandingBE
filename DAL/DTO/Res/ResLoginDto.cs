using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DTO.Res
{
    public class ResLoginDto
    {
        public string? token {  get; set; }
        public int? expiresIn { get; set; }
    }
}
