using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_exo1
{
    public class Task_List
    {
        private List<Task> list_tasks = new List<Task>();
        private List<object> list_results;

        public Task_List()
        { }
        
        //Builder
        public Task_List(List<Task> lt)
        {
            list_tasks = lt;
        }

        //Function to add the results of each task int the list_results attribute
        public List<object> GetResults
        {
            get
            {
                list_results = new List<object>();
                foreach(Task t in list_tasks)
                {
                    list_results.Add(t.GetSetResult);
                }
                return list_results;
            }

        }

        // Function which execute each task
        public void execute()
        {
            foreach(Task t in list_tasks)
            {
                t.execute();
            }
        }

        public void add(Task t)
        {
            list_tasks.Add(t);
        }

    }
}
