using System;

namespace GMS_System.Services
{
    public  class CommonServices  : IDisposable
    {
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                //if (db != null)
                //{
                //    db.Dispose();
                //    db = null;
                //}
            }
        }

    }
    
    
}
