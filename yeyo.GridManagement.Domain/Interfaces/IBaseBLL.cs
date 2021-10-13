using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using yeyo.GridManagement.Domain.Models;

namespace yeyo.GridManagement.Domain.Interfaces
{
    public interface IBaseBLL
    {
    }

    public interface IBaseBll<T> : IBaseBLL where T : EntityBaseModel, new()
    {

    }
}
