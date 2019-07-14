using System;

namespace FinalADS.Application.Accounts.Dtos
{
    public class NewAccountDto
    {
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public bool Locked { get; set; }
        public long Customerid { get; set; }

        public NewAccountDto()
        {
            Locked = false;
        }
    }
}
