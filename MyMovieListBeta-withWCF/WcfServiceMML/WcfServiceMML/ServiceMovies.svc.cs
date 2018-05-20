using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceMML
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceMovies" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceMovies.svc or ServiceMovies.svc.cs at the Solution Explorer and start debugging.
    public class ServiceMovies : IServiceMovies
    {

        private MyMovieListDBEntities db = new MyMovieListDBEntities();

        public List<Movies> MyList()
        {
            return db.Movies.ToList(); 
        }
    }
}
