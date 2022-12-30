namespace Sorter.Misc
{
    public class Printer
    {
        public Printer() { }
        public bool WriteToFile(string thingsToPrint, string FileName)
        {
            try
            {
                StreamWriter sr = new StreamWriter(FileName);
                sr.WriteLine(thingsToPrint);
                sr.Close();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
            
        }
        public bool AppendToFile(string thingsToPrint, string FileName)
        {
            StreamWriter sr = new StreamWriter(FileName, true);
            try
            {
                sr.WriteLine(thingsToPrint);
            }
            catch (Exception ex)
            {
                sr.Close();
                return false;
            }
            sr.Close();
            return true;
        }
        public string ReadLastSortedFile(string filename)
        {
            try
            {
                string[] allLines = File.ReadAllLines(filename);
                return string.Join("", allLines);
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
