using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDAL.Model.Repository.Contracts
{
    public interface IEmployee:IDisposable,IRepository<TblEmployee>
    {
    }
}
