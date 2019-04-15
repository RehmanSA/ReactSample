using SampleDAL.Model.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleDAL.Model.Repository
{
  public class CityRepository : Repository<TblCities>, ICity
    {
        #region Properties
        private bool _disposed;
        #endregion

        public CityRepository(ReactSampleContext context) : base(context)
        {

        }

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _context.Dispose();
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
