using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanAssistant
{
    public class Task
    {
        public DateTime DateTime { get; set; }
        public Frequency Frequency { get; set; }
        public object TaskType { get; set; }

        public void ChooseTaskType(string taskTypeName)
        {
            switch (taskTypeName)
            {
                case "email":
                    TaskType = TaskType as Email;
                    break;
                case "downloadFile":
                    TaskType = TaskType as FileDownloader;
                    break;
                case "moveCatalog":
                    TaskType = TaskType as CatalogMoving;
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
