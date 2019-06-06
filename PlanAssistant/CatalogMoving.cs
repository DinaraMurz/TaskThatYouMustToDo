using System;
using System.IO;

namespace PlanAssistant
{
    public class CatalogMoving : Entity
    {
        public string Source { get; set; }
        public string Destination { get; set; }

        public void MoveCatalog()
        {
            try
            {
                Directory.Move(Source, Destination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
