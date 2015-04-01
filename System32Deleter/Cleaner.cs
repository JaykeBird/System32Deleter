using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Numerics;

namespace System32Deleter
{
    internal class Cleaner
    {
        string sys32dir;
        List<long> lengths = new List<long>();
        long largest = 0;
        string lname = "";
        long smallest = long.MaxValue;
        string sname = "";

        /// <summary>
        /// Initializes a new Cleaner, using the standard location for the System32 directory.
        /// </summary>
        public Cleaner()
        {
            sys32dir = "C:\\WINDOWS\\System32";
        }

        /// <summary>
        /// Initializes a new Cleaner with a custom-set System32 directory.
        /// </summary>
        /// <param name="dir">The directory path to System32.</param>
        public Cleaner(string dir)
        {
            sys32dir = dir;
        }

        /// <summary>
        /// Initializes a new Cleaner by taking information from an existing Cleaner.
        /// </summary>
        /// <param name="cleaner">The existing Cleaner to take information from.</param>
        public Cleaner(Cleaner cleaner)
        {
            // wait... Cleaner doesn't have any public properties.

            // Ummm... let's do this:
            sys32dir = "C:\\WINDOWS\\System32";
        }

        public void Start()
        {
            DirectoryInfo di = new DirectoryInfo(sys32dir);

            CleanDirectory(di);

            Console.WriteLine();

            // Now some nifty post-cleaning data
            long avg = CalculateAverage();
            Console.WriteLine("Files deleted: " + lengths.Count.ToString());
            Console.WriteLine("Average file size: " + avg.ToString());
            Console.WriteLine("Biggest file: " + lname + " (" + largest.ToString() + " bytes, " + (largest / 4096 / 1000).ToString() + " seconds)");
            Console.WriteLine("Smallest file: " + sname + " (" + smallest.ToString() + " bytes, " + (smallest / 4096 / 1000).ToString() + " seconds)");
        }

        /// <summary>
        /// Pauses the System32 Cleaner.
        /// </summary>
        public void Pause()
        {
            Thread.Sleep(1000);
            // yeah, that's enough time for a valid pause, right?
        }

        /// <summary>
        /// Stops the System32 Cleaner.
        /// </summary>
        public void Stop()
        {
            Console.WriteLine("YOU CAN NEVER STOP ME!!!!!");
            Console.WriteLine("MY SYSTEM32 DELETING HAS ONLY JUST BEGUN!!!!!");
            // Whoops, how did this code get in here?
        }

        /// <summary>
        /// Clean a specified directory.
        /// </summary>
        /// <param name="dir"></param>
        private void CleanDirectory(DirectoryInfo dir)
        {
            try
            {
                FileInfo[] files = dir.GetFiles();

                foreach (FileInfo item in files)
                {
                    DeleteFile(item);
                }

                // Let's clean all the subdirectories too
                // (You never know what crap is laying in there)
                DirectoryInfo[] dirs = dir.GetDirectories();

                foreach (DirectoryInfo subdir in dirs)
                {
                    CleanDirectory(subdir);
                    DeleteDirectory(subdir);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // TODO: Get authorized access
            }
        }

        /// <summary>
        /// Calculates the average file size of all the files deleted
        /// 
        /// (Isn't that some nifty information to have?)
        /// </summary>
        /// <returns>The average file size.</returns>
        private long CalculateAverage()
        {
            int lgnth = lengths.Count;

            // There's gonna be some big numbers up in here
            BigInteger bint = new BigInteger(0);
            foreach (long item in lengths)
            {
                bint += item;
            }

            return (long) (lgnth / bint);
        }

        /// <summary>
        /// Permanently deletes a directory from the hard drive.
        /// </summary>
        /// <param name="dir">The directory to delete.</param>
        private void DeleteDirectory(DirectoryInfo dir)
        {
            // We want to make sure no traces are left behind of System32
            // Even one small part of System32 may cause computer problems
            // So let's even go as far as deleting the directories too!

            //dir.DoTheDeletingThing();

            // (You can never be too safe.)
        }

        /// <summary>
        /// Permanently delete a file from the hard drive.
        /// </summary>
        /// <param name="file">The file to delete.</param>
        private void DeleteFile(FileInfo file)
        {
            // big hack
            int lgth = (int) (file.Length / ((2 * 2 * 2 * 2 * 2) * (2 * 2 * 2 * 2 * 2) * 2 * 2));
            // (2 is such an important number in computing. Why wouldn't we use it here?)
            // (Also, "2 * 2 * 2 * 2 * 2" is "32". This is an important number to use while deleting System32.)
            // (We put two of those in there because 2 is still a really important number in computing.)
            // (We then added 2 more 2s for good measure.

            // more hackiness
            // with the file size
            // (an important metric to consider while deleting your System32)
            long l = file.Length;
            
            lengths.Add(l);
            if (l > largest)
            {
                largest = l;
                lname = file.FullName.Substring(sys32dir.Length + 1);
            }
            if (l < smallest)
            {
                smallest = l;
                sname = file.FullName.Substring(sys32dir.Length + 1);
            }
            
            Console.WriteLine(file.FullName.Substring(sys32dir.Length + 1) + " (" + file.Length.ToString() + " bytes)");

            // don't try this at home, kids
            //file.DoTheDeletingThing();
            Thread.Sleep(lgth);
        }

    }
}
