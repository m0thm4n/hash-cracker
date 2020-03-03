using System;
using System.IO;
using System.Threading;

namespace HashCracker
{
    public class Wordlist
    { 
        public void GetFileAndReadIt(string passwordList, string hash)
        {
            //  Hash = "e10adc3949ba59abbe56e057f20f883e"; //123456
            string Pass = "";
            int counter = 0;
            bool closeLoop = true; //this ends the loop after a password is found



            //open this file that will be save in your bin directory
            using (StreamReader file = new StreamReader(passwordList))
            {

                //this will run untill closeloop = false or the end of the file 
                while (closeLoop == true && (Pass = file.ReadLine()) != null)
                {
                    //this compares the output md5hash to the hash entered above and closes while loop
                    if (Hasher.Md5Hash(Pass) == hash)
                    {

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(Pass);
                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.WriteLine("Cracked Hash = " + Pass + "\n\r" + Hasher.Md5Hash(Pass));

                        Console.ResetColor();
                        Console.ReadKey();
                        file.Close();
                        closeLoop = false;
                    }
                    else
                    {
                        //if no match just write out the password that was tried
                        Console.WriteLine(Pass);
                    }
                    counter++;
                    Console.Title = "Current Password Count: " + counter.ToString();
                    Thread.Sleep(10);
                }
                file.Close();
                Console.ReadKey();

            }
        }
    }
}
