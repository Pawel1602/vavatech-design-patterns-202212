using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    internal interface ITransferServiceAdapter
    {
        void AddTransfer(IEnumerable<Transfer> transfers);
    }

    public class TransferServiceA
    {
        public void Add(Transfer transfer) 
        {
            Console.WriteLine(transfer);
        }
    }

    public class ATransferServiceAdapter : ITransferServiceAdapter
    {
        private readonly TransferServiceA transferServiceA;

        public ATransferServiceAdapter()
        {
            transferServiceA = new TransferServiceA();  
        }

        public void AddTransfer(IEnumerable<Transfer> transfers)
        {
            foreach (var item in transfers)
            {
                transferServiceA.Add(item);
            }
            
        }
    }

    public class BTransferServiceAdapter : ITransferServiceAdapter
    {
        private readonly TransferServiceB transferServiceB;

        public BTransferServiceAdapter()
        {
            transferServiceB = new TransferServiceB();
        }

        public void AddTransfer(IEnumerable<Transfer> transfers)
        {
            transferServiceB.AddRange(transfers);
        }
    }

    public class TransferServiceB
    {
        public void AddRange(IEnumerable<Transfer> transfers)
        {
            foreach (var transfer in transfers)
            {
                Console.WriteLine(transfer);
            }
        }
    }

    public class TaxTransfer : Transfer
    {

    }

    public class StandardTransfer : Transfer
    {

    }

    public abstract class Transfer
    {
        public string From { get; set; }
        public string To { get; set; }
        public decimal Amount { get; set; }
    }
}
