using System;
using System.Collections.Generic;

public class AverageCount : Task
{
    public AverageCount(int[][] mat) : base(mat)
    {
        this.results = 0.0;
    }

    public override void execute()
    {
        int[][] mat = (int[][])this.data;
        List<doublon> res = new List<doublon>();

        double row_avg = 0.0; // average of the row
        int sum_ite = 0; //number of element in the row 


        // We first count the iteration of the data attributes by using the iterationcount class
        // We do this in case of, we do not use the class IterationCount before using the AverageCount one in the main
        IterationCount ic = new IterationCount(mat);
        ic.execute();

        List<doublon> row = (List<doublon>) ic.GetSetResult;

        for(int j =0; j<row.Count;j++) // We browse the results of the iterationcount 
        {
            row_avg = row_avg + row[j].value * row[j].ite;
            sum_ite = sum_ite + row[j].ite;
        }
        this.GetSetResult = new double();
        this.GetSetResult = row_avg / sum_ite; // The results attributes become a double which is the average of the row
    }
}
