internal class Program
{
    enum Kelurahan
    {
        Batununggal,
        Kujangsari,
        Mengger,
        Wates,
        Cijaura,
        Jatisari,
        Margasari,
        Sekejati,
        Kebonwaru,
        Maleer,
        Samoja
    }

    public enum Status
    {
        terkunci,
        terbuka
    }

    public enum Trigger
    {
        bukaPintu,
        kunciPintu
    }

    public status pintu = status.terkunci;

    private static int KodePos(Kelurahan K)
    {
        int[] L =
        {
            40266,
            40287,
            40267,
            40256,
            40287,
            40286,
            40286,
            40286,
            40272,
            40274,
            40273

        };
        return L[(int)K];
    }

    class DoorMachine
    {
        public class transisi
        {
            public status awal;
            public status akhir;
            public trigger P;
            public transisi(status awal, status akhir, trigger R)
            {
                this.awal = awal;
                this.akhir = akhir;
                this.P = R;

            }
        }
        transisi[] Q =
        {
            new transisi (status.terbuka,status.terkunci,trigger.kunciPintu),
            new transisi (status.terkunci,status.terbuka,trigger.bukaPintu),
            new transisi (status.terbuka,status.terbuka,trigger.bukaPintu),
            new transisi (status.terkunci,status.terkunci,trigger.kunciPintu)

        };

        private status pintu;
        private status petunjuk(status awal, trigger R)
        {
            status petunjuk2 = awal;
            for (int i = 0; i < Q.Length; i++)
            {
                transisi ganti = Q[i];
                if (awal == ganti.awal && R == ganti.P)
                {
                    petunjuk2 = ganti.akhir;
                }
            }
            return petunjuk2;
        }

        public void X(trigger Y)
        {
            pintu = petunjuk(pintu, Y);
            if (pintu == status.terkunci)
            {
                Console.WriteLine("Pintu Terkunci");
            }
            else if (pintu == status.terbuka)
            {
                Console.WriteLine("Pintu Tidak Terkunci");
            }
        }

    }
    private static void Main(string[] args)
    {
        kelurahan M = kelurahan.Batununggal;
        int N = kodepos(M);
        Console.WriteLine("Kelurahan :" + M + " " + "KodePos :" + N);

        DoorMachine T = new DoorMachine();
        T.X(trigger.kunciPintu);
        T.X(trigger.bukaPintu);
    }
}