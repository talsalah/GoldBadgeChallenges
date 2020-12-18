using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsRepository
{

    public enum ClaimType
    {
        Car = 1,
        Home,
        Theft,


    }
    public class FileClaims
    {
        public int ClaimID { get; set; }
        public ClaimType TypeofClaim { get; set; }
        public string Description { get; set; }
       
        public bool IsValid { get; set; }
        public double ClaimAmount { get; set; }
        public DateTime DateofClaim { get; set; }
        public DateTime DateofIncident { get; set; }

        public FileClaims() { }

        public FileClaims(int claimId, ClaimType claimType, string description, double claimAmount, DateTime claimDate, DateTime incidentDate, bool isValid)
        {
            ClaimID = claimId;
            TypeofClaim = claimType;
            Description = description;
            ClaimAmount = claimAmount;
            DateofClaim = claimDate;
            DateofIncident = incidentDate;
            IsValid = isValid;


        }

    }
}
