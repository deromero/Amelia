using System;
using Amelia.Data.Contexts;
using Amelia.Data.Initializer.Auth;

namespace Amelia.Data.Initializer
{
    public static class DbInitializer
    {
        private static AmeliaContext _context;
        
        public static void Initialize(IServiceProvider serviceProvider){
            _context = (AmeliaContext)serviceProvider.GetService(typeof(AmeliaContext));
            
            AuthInitializer.UserAndRoles(_context);
        }

        
    }
}