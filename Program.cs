using System;
using System.Text;

class Program
{
    static int[] KeyGen(int a)
    {
        int[] A = new int[a];
        int p = 13, q = 19, x = 3, m = q * p;
        for (int i = 0; i < a; i++)
        {
            x = (x * x) % m;
            A[i] = x;
        }
        return A;
    }
    static int[] RKLeft(int[] CD0)
    {
        int[] CD1 = new int[28];
        for (int i = 0; i < 27; i++)
        {
            CD1[i] = CD0[i + 1];
        }
        CD1[27] = CD0[0];
        return CD1;
    }
    static int[] RoundKeys(int[] KeyBit)
    {
        int[] key1 = new int[64];
        int a = 0, b=0;
        for(int i=0;i<key1.Length;i++)//Додавання перевірочних бітів
        {
            b++;
            if(KeyBit[b-1]==1)
            {
                a++;
                key1[i] = KeyBit[b-1];
            }
            else
            {
                key1[i] = KeyBit[b-1];
            }
            if(b%7==0)
            {
                if(a%2==0)
                {
                    i++;
                    key1[i] = 1;
                    a = 0;
                }
                else if(a%2!=0)
                {
                    i++;
                    key1[i] = 0;
                    a = 0;
                }
            }
        }
        int[] key16=new int[48*16], C0=new int[28], D0=new int[28];
        int[] E1 = new int[28] {57,49,41,33,25,17,9,1,58,50,42,34,26,18,10,2,59,51,43,35,27,19,11,3,60,52,44,36};
        for (int i = 0; i < C0.Length; i++)
        {
            C0[i] = key1[E1[i] - 1];
        }
        int[] E2 = new int[28] {63,55,47,39,31,23,15,7,62,54,46,38,30,22,14,6,61,53,45,37,29,21,13,5,28,20,12,4};
        for (int i = 0; i < D0.Length; i++)
        {
            D0[i] = key1[E2[i] - 1];
        }
        for (int i=0;i<key16.Length;i=i+48)
        {
            switch (i)
            {
                case 0:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 48:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 96:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 144:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 192:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 240:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 288:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 336:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 384:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 432:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 480:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 528:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 576:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 624:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 672:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
                case 720:
                    C0 = RKLeft(C0);
                    D0 = RKLeft(D0);
                    break;
            }
            int[] E3 = new int[48] {14,17,11,24,1,5,3,28,15,6,21,10,23,19,12,4,26,8,16,7,27,20,13,2, 13, 24, 3, 9, 19, 27, 2, 12, 23, 17, 5, 20, 16, 21, 11, 28, 6, 25, 18, 14, 22, 8, 1, 4 };
            for (int j = 0; j < E3.Length; j++)
            {
                if (i < 24)
                {
                    key16[i + j] = C0[E3[j] - 1];
                }
                else
                {
                    key16[i + j] = D0[E3[j] - 1];
                }
            }
        }
        return key16;
    }
    static int[] F(int[] R0, int[] RKB)
    {
        int[] E1 = new int[48] {32,1,2,3,4,5,4,5,6,7,8,9,8,9,10,11,12,13,12,13,14,15,16,17,16,17,18,19,20,21,20,21,22,23,24,25,24,25,26,27,28,29,28,29,30,31,32,1};
        int[] B6 = new int[48];
        for (int i = 0; i < 48; i++)
        {
            B6[i] = R0[E1[i] - 1];//розширення
            B6[i] = B6[i] ^ RKB[i];//складання з ключем оп модулю 2
        }
        int[,] S1 = new int[4,16] {{ 14  ,4  , 13,  1 ,  2 ,  15 , 11,  8 ,  3  , 10,  6 ,  12 , 5 ,  9 ,  0 ,  7 },{ 0 , 15 , 7 ,  4  , 14 , 2  , 13 , 1 ,  10  ,6  , 12 , 11 , 9 ,  5  , 3  , 8 }, { 4, 1  , 14 , 8 ,  13,  6 ,  2 ,  11 , 15,  12 , 9 ,  7 ,  3 ,  10,  5 ,  0 }, { 15  ,  12  ,8  , 2  , 4  , 9  , 1 ,  7   ,5  , 11 , 3 ,  14 , 10 , 0 ,  6  , 13 } },
        S2 = new int[4,16] { { 15 ,   1 ,  8 ,  14 , 6 ,  11  ,3 ,  4  , 9 ,  7 , 2   ,13,  12,  0 ,  5 ,  10 }, { 3, 13 , 4 ,  7  , 15 , 2 ,  8   ,14 , 12 , 0 ,  1 ,  10 , 6 ,  9  , 11 , 5 }, { 0, 14 , 7 ,  11 , 10,  4  , 13 , 1 ,  5 ,  8 ,  12,  6 ,  9 ,  3 ,  2 ,  15 }, { 13 ,  8  , 10 , 1 ,  3 ,  15 , 4 ,  2 ,  11 , 6  , 7 ,  12 , 0 ,  5 ,  14 , 9 } },
        S3 = new int[4,16] { { 10  ,  0  , 9,   14 , 6 ,  3  , 15 , 5,   1 ,  13 , 12 , 7,   11,  4 ,  2 ,  8 }, { 13  ,  7 ,  0 ,  9  , 3  , 4 ,  6  , 10 , 2 ,  8 ,  5  , 14 , 12 , 11 , 15 , 1 }, { 13 ,   6 ,  4  , 9  , 8  , 15  ,3 ,  0  , 11 , 1  , 2 ,  12 , 5  , 10 , 14 , 7 }, { 1, 10,  13 , 0 ,  6  , 9  , 8  , 7,   4  , 15 , 14 , 3 ,  11,  5 ,  2 , 12 } },
        S4 = new int[4,16] { { 7 ,13 , 14,  3 ,  0  , 6 ,  9  , 10 , 1 ,  2 , 8  , 5 ,  11 , 12,  4 ,  15 }, { 13  ,  8  , 11  ,5  , 6  , 15,  0 ,  3   ,4 ,  7 ,  2  , 12 , 1 ,  10 , 14 , 9 }, { 10  ,  6  , 9  , 0 ,  12 , 11 , 7 ,  13 , 15 , 1 ,  3 ,  14 , 5 ,  2,   8  , 4 }, { 3, 15 , 0  , 6  , 10  ,1  , 13 , 8 ,  9 ,  4  , 5 ,  11 , 12 , 7 ,  2 ,  14 } },
        S5 = new int[4,16] { { 2 ,12 , 4  , 1 ,  7  , 10 , 11 , 6 ,  8 ,  5 ,  3  , 15 , 13 , 0 ,  14 , 9 }, { 14 ,   11 , 2 ,  12 , 4  , 7 ,  13 , 1 ,  5  , 0  , 15 , 10 , 3  , 9  , 8  , 6 }, { 4, 2 ,  1 ,  11,  10  ,13  ,7  , 8  , 15 , 9 ,  12,  5  , 6 ,  3 ,  0 ,  14 }, { 11 ,  8  , 12 , 7  , 1 ,  14 , 2 ,  13 , 6  , 15 , 0 ,  9  , 10,  4 ,  5 ,  3 } },
        S6 = new int[4,16] { { 12  ,  1  , 10 , 15,  9 ,  2  , 6 ,  8,   0 ,  13 , 3 ,  4 ,  14 , 7,   5 ,  11 }, { 10 ,  15 , 4 ,  2  , 7  , 12 , 9 ,  5 ,  6 ,  1 ,  13 , 14 , 0 ,  11 , 3 ,  8 }, { 9 ,14 , 15 , 5 ,  2  , 8 ,  12 , 3  , 7 ,  0 ,  4 ,  10 , 1 ,  13,  11 , 6 }, { 4, 3 ,  2 ,  12 , 9 ,  5 ,  15 , 10 , 11,  14 , 1 ,  7,   6 ,  0 ,  8 ,  13 } },
        S7 = new int[4,16] { { 4, 11 , 2,   14 , 15 , 0  , 8  , 13,  3  , 12 , 9 ,  7 ,  5 ,  10 , 6  , 1 }, { 13  ,  0 ,  11,  7 ,  4 ,  9  , 1  , 10 , 14 , 3  , 5 ,  12,  2,   15 , 8 ,  6 }, { 1, 4 ,  11,  13  ,12 , 3 ,  7  , 14 , 10,  15,  6  , 8  , 0 ,  5 ,  9 ,  2 }, { 6, 11,  13,  8 ,  1 ,  4  , 10 , 7  , 9  , 5  , 0 ,  15 , 14,  2 ,  3,   12 } },
        S8 = new int[4,16] { { 13 ,   2 ,  8 ,  4 ,  6   ,15 , 11 , 1 ,  10  ,9  , 3 ,  14 , 5,   0 ,  12,  7 }, { 1 ,15 , 13,  8 ,  10 , 3 ,  7 ,  4 ,  12 , 5 , 6  , 11 , 0 ,  14 , 9 ,  2 }, { 7 , 11,  4 ,  1,   9 ,  12 , 14 , 2  , 0  , 6 ,  10 , 13,  15 , 3  , 5  , 8 }, { 2 ,1 ,  14,  7 ,  4 ,  10,  8,  13 , 15  ,12,  9 ,  0  , 3 ,  5  , 6 ,  11 } };
        int[] AB = new int[2], BB = new int[4], B4 = new int[32];
        int A, B, C, T=0;
        Console.WriteLine("\n");
        for(int i=0;i<B6.Length;i++)
        {
            Console.Write($"{B6[i]}");
        }
        Console.WriteLine("\n");
        for (int i=0;i<B6.Length;i=i+6)
        {
            A = 0;B = 0; C = 0;
            AB[0] = B6[i];
            AB[1] = B6[i+5];
            BB[0] = B6[i + 1];
            BB[1] = B6[i + 2];
            BB[2] = B6[i + 3];
            BB[3] = B6[i + 4];
            Console.Write($"BF(i-5): {B6[i]}{B6[i + 1]}{B6[i + 2]}{B6[i + 3]}{B6[i + 4]}{B6[i + 5]}, AB: {AB[0]}{AB[1]}, BB: {BB[0]}{BB[1]}{BB[2]}{BB[3]}\n");
            for (int j = 0; j < AB.Length; j++)
            {
                A += AB[AB.Length - 1 - j] * (int)Math.Pow(2, j);
            }
            for (int j = 0; j < BB.Length; j++)
            {
                B += BB[BB.Length - 1 - j] * (int)Math.Pow(2, j);
            }
            Console.Write($"A: {A}, B: {B}\n");
            switch (T)
            {
                case 0:
                    C = S1[A,B];
                    break;
                case 1:
                    C = S2[A, B];
                    break;
                case 2:
                    C = S3[A, B];
                    break;
                case 3:
                    C = S4[A, B];
                    break;
                case 4:
                    C = S5[A, B];
                    break;
                case 5:
                    C = S6[A, B];
                    break;
                case 6:
                    C = S7[A, B];
                    break;
                case 7:
                    C = S8[A, B];
                    break;
            }
            Console.Write($"C: {C}\n");
            string binaryC = Convert.ToString(C, 2).PadLeft(4, '0'); // перетворення у двійковий вигляд та додавання ведучих нулів
            Console.Write($"C: ");
            for (int j = 0; j < 4; j++)
            {
                B4[i-T*2+j] = binaryC[j] - '0';
                Console.Write($"{B4[i - T * 2 + j]}");
            }
            Console.Write($"\n");
            for (int j = 0; j < B4.Length; j++)
            {
                Console.Write($"{B4[j]}");
            }
            Console.Write($"\n");
            Console.Write($"\n");
            T++;
        }
        int[] E2 = new int[32] {16,7,20,21,29,12,28,17,1,15,23,26,5,18,31,10,2,8,24,14,32,27,3,9,19,13,30,6,22,11,4,25};
        for (int i = 0; i < 32; i++)
        {
            R0[i] = B4[E2[i] - 1];//Кінцева перестановка
        }
        return R0;
    }
    static string EncDec64(string buf1, int Process, int[] KeyBit)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        byte[] bufbytes = Encoding.GetEncoding(1251).GetBytes(buf1);
        int[] bufbits = bufbytes.SelectMany(b => Convert.ToString(b, 2).PadLeft(8, '0'))//Переведення тексту в біти згідно він1251
                             .Select(c => (int)Char.GetNumericValue(c)).ToArray();
        int[] RK = RoundKeys(KeyBit);
        int[] bufbits1 = new int[bufbits.Length], L0 = new int[32], R0 = new int[32], B0 = new int[32], RKB = new int[48], E1 = new int[64] {
        58,50,42,34,26,18,10,2,60,52,44,36,28,20,12,4,62,54,46,38,30,22,14,6,64,56,48,40,32,24,16,8,57,49,41,33,25,17,9,1,59,51,43,35,27,19,11,3,61,53,45,37,29,21,13,5,63,55,47,39,31,23,15,7};
        //початкова перетановка
        for (int i = 0; i < bufbits.Length; i++)
        {
            bufbits1[i] = bufbits[E1[i] - 1];
        }

        for (int i=0;i< bufbits1.Length;i++)
        {
            if(i<32)
            {
                L0[i] = bufbits1[i];
            }
            else
            {
                R0[i-32]= bufbits1[i];
            }
        }
        Console.Write($"\ni-1:\n");
        Console.Write($"\nL0: \n");
        for (int a = 0; a < L0.Length; a++)
        {
            Console.Write(L0[a]);
        }
        Console.Write($"\nR0: \n");
        for (int a = 0; a < R0.Length; a++)
        {
            Console.Write(R0[a]);
        }
        Console.Write("\n");
        for (int i=0;i<16;i++)
        {
            if (Process == 1)
            {
                for (int j = i * 48, a = 0; j < i * 48 + 48; j++, a++)
                {
                    RKB[a] = RK[j];
                }
                //B0 = L0;
                Array.Copy(L0, B0, L0.Length);
                //L0 = R0;
                Array.Copy(R0, L0, R0.Length);
                //R0 = F(R0, RKB);
                Array.Copy(F(R0,RKB), R0, F(R0,RKB).Length);
                for (int r = 0; r < 32; r++)
                {
                    R0[r] = B0[r] ^ R0[r];
                }
                Console.Write($"\ni: {i}\n");
                Console.Write($"\nL0: \n");
                for(int a=0;a<L0.Length;a++)
                {
                    Console.Write(L0[a]);
                }
                Console.Write($"\nR0: \n");
                for (int a = 0; a < R0.Length; a++)
                {
                    Console.Write(R0[a]);
                }
                Console.Write("\n");
            }
            else if(Process==2)
            {
                for (int j = 720 - i * 48, a = 0; j < 768 - i * 48; j++, a++)
                {
                    RKB[a] = RK[j];
                }
                //B0 = R0;
                Array.Copy(R0, B0, R0.Length);
                //R0 = L0;
                Array.Copy(L0, R0, L0.Length);
                //L0 = F(L0, RKB);
                Array.Copy(F(L0, RKB), L0, F(L0, RKB).Length);
                for (int r = 0; r < 32; r++)
                {
                    L0[r] = B0[r] ^ L0[r];
                }
            }
        }
        int[] E2 = new int[64] {40,8,48,16,56,24,64,32,39,7,47,15,55,23,63,31,38,6,46,14,54,22,62,30,37,5,45,13,53,21,61,29,36,4,44,12,52,20,60,28,35,3,43,11,51,19,59,27,34,2,42,10,50,18,58,26,33,1,41,9,49,17,57,25};
        //зворотня перестановка
        for (int i = 0; i < bufbits.Length; i++)
        {
            if (i < 32)
            {
                if (E2[i] > 32)
                {
                    bufbits[i] = L0[E2[i] - 1-32];
                }
                else
                {
                    bufbits[i] = L0[E2[i] - 1];
                }
            }
            else
            {
                if (E2[i] > 32)
                {
                    bufbits[i] = R0[E2[i] - 1 - 32];
                }
                else
                {
                    bufbits[i] = R0[E2[i] - 1];
                }
            }
        }
        string buf2 = "";
        for (int i = 0; i < bufbits.Length / 8; i++) // кожні 8 біт утворюють 1 байт
        {
            int value = 0;
            for (int j = 0; j < 8; j++)
            {
                value = value << 1;
                value |= bufbits[i * 8 + j];
            }
            buf2 += Encoding.GetEncoding(1251).GetString(BitConverter.GetBytes((byte)value))[0]; // перетворюємо байт у рядок та додаємо до buf1
        }
        Console.Write(buf2.Length);
        for (int i=0;i<buf2.Length;i++)
        {
            Console.Write($"-{buf2[i]}-");
        }
        Console.WriteLine(buf2.Length);
        return buf2;
    }
    static string EncDec128(ref string buf1, int Process, int[] KeyBit)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        byte[] bufbytes = Encoding.GetEncoding(1251).GetBytes(buf1);
        int[] bufbits = bufbytes.SelectMany(b => Convert.ToString(b, 2).PadLeft(8, '0'))
                             .Select(c => (int)Char.GetNumericValue(c)).ToArray();
        int[] RK = RoundKeys(KeyBit);
        return "A";
    }
    static void Main()
    {
        string FName="";
        Console.Write("A program for encrypting file content using the Feistel network\nCT::D:/УЧ/#3.2/Прикладна Криптологiя/LB7/\n\nEnter a file name: ");
        FName=Console.ReadLine();
        string FPath = @"D:\УЧ\#3.2\Прикладна Криптологія\LB7\"+FName+".txt";
        string buf;
        int Process, CBits;

        using (StreamReader reader = new StreamReader(FPath))
        {
            buf = reader.ReadToEnd();
        }

        Console.Write("Choose the encryption(1) or decryption(2): ");
        Process = Convert.ToInt32(Console.ReadLine());

        Console.Write("How many bits need to be encrypted?(64/128): ");
        CBits = Convert.ToInt32(Console.ReadLine());

        string buf1 = "";
        if (CBits==64)
        {
            for (int i = 0; i < CBits/8; i++)
            {
                buf1 = buf1 + buf[i];
            }
        }
        else if (CBits==128)
        {
            for (int i = 0; i < CBits/8; i++)
            {
                buf1 = buf1 + buf[i];
            }
        }

        int a = 7;
        int[] key = new int[a];
        if (Process == 1)
        {
            Console.Write("Enter a name for the file with a new generated key: ");
            FName = Console.ReadLine();
            FPath = @"D:\УЧ\#3.2\Прикладна Криптологія\LB7\" + FName + ".txt";
            key =KeyGen(a);
            using (StreamWriter writer = new StreamWriter(FPath))
            {
                for (int i = 0; i < key.Length; i++)
                {
                    writer.Write(key[i].ToString() + " ");
                }
            }
        }
        else if(Process==2)
        {
            Console.Write("Enter a name for the file with a generated key: ");
            FName = Console.ReadLine();
            FPath = @"D:\УЧ\#3.2\Прикладна Криптологія\LB7\" + FName + ".txt";
            using (StreamReader reader = new StreamReader(FPath))
            {
                string line = reader.ReadLine();
                
                string[] values = line.Split(' ');
                values = line.TrimEnd().Split(' ');//прибирання ' ' в кінці
                for (int i = 0; i < values.Length; i++)
                {
                    key[i] = Convert.ToInt32(values[i]);
                }
            }
        }

        int[] KeyBit = new int[a * 8];//Перетворення в двійковий вигляд
        for (int i = 0; i < key.Length; i++)
        {
            int n = key[i];
            int pos = i * 8;

            for (int j = 0; j < 8; j++)
            {
                KeyBit[pos + j] = (n >> (7 - j)) & 1;
            }
        }

        Console.Write("Enter a name for the new file: ");
        FName = Console.ReadLine();
        FPath = @"D:\УЧ\#3.2\Прикладна Криптологія\LB7\"+FName+".txt";
        using (StreamWriter writer = new StreamWriter(FPath))
        {
            if (CBits==64)
            {
                writer.Write(EncDec64(buf1, Process, KeyBit));
                for(int i=CBits/8;i<buf.Length;i++)
                {
                    writer.Write(buf[i]);
                }
            }
            else if(CBits==128)
            {
                writer.Write(EncDec128(ref buf1, Process, KeyBit));
            }
        }

    }
}