using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepository
{
    public class FileClaimsRepo
    {

        private Queue<FileClaims> _queueofClaims = new Queue<FileClaims>();

        //Create
        public void AddClaimToList(FileClaims claim)
        {
            _queueofClaims.Enqueue(claim);

        }

        //Read

        public Queue<FileClaims> GetClaimList()
        {
            return _queueofClaims;
        }

       
    }
}
