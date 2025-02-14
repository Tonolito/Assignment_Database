using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UpdateDtos;

public class StatusTypeUpdateDto
{
    public int Id { get; set; }
    public string StatusName { get; set; } = null!;
}
