using System;

namespace GSTHMS
{
    internal class YourDbContext : IDisposable
    {
        public object Events { get; internal set; }

        public YourDbContext()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("Error initializing YourDbContext.", ex);
            }
        }

        public void Dispose()
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw new Exception("Error disposing YourDbContext.", ex);
            }
        }
    }
}