using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Threading;
using static HashCracker.Hasher;
using static HashCracker.Wordlist;

namespace HashCracker
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Hasher hasher = new Hasher();
            Wordlist wordList = new Wordlist();

            Here: // return point

            bool hashingFile = true;

            while (hashingFile)
            {
                string hash = "";
                Console.WriteLine("Enter Your MD5 hash : ");
                hash = Console.ReadLine().ToUpper();

                if (!string.IsNullOrEmpty(hash))
                {
                    Console.WriteLine("Valid MD5 Hash Value Ok");
                }
                else
                {
                    Console.WriteLine("Not a Valid MD5 Hash Value!!!");
                    goto Here;
                }

                string passwordList = "";
                Console.WriteLine("Enter the Password List file Name :: Ex. (Rockyou.txt)");
                passwordList = Console.ReadLine();

                if (File.Exists(passwordList))
                {
                    Console.WriteLine("Password List Found Ok");
                }
                else
                {
                    Console.WriteLine("Could Not Find the Password List");
                    goto Here;
                }

                wordList.GetHashWordlistFileAndReadIt(passwordList, hash);

                hashingFile = false;    
            }

            Console.WriteLine("Please hit enter to enter new file");
            Console.ReadLine();
            goto Here;
        }
    }
}
