using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Task
{
    protected object data;
    protected object results;

    //Builder of the Task object
    public Task(object data)
    {
        this.data = data;
    }

    public abstract void execute();

    public object GetSetResult { get; set; }


}
