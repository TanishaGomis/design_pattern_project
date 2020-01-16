using System;
using System.Collections.Generic;

public class IterationCount : Task
{
    
    //Builder
    public IterationCount(int[][] mat) : base(mat)
    {
        this.results = new List<doublon>();
    }

    public override void execute()
    {
        int[][] mat = (int[][]) this.data;
        List<doublon> res = (List<doublon>) this.results;

        //We first browse the matrix
        for(int i=0;i<mat.Length;i++)
        {
            for(int j=0;j<mat[0].Length;j++)
            {
               
                bool est_present = false; // we verify if the value is already present in the result

                for(int k=0;k<res.Count;k++) // We browse the result list to verify if the value is already present in it
                {
                    if (res[k].value == mat[i][j]) //if the value is already present we just increment of 1 the ite attribute of the doublon
                    {
                        doublon resk = res[k];
                        resk.ite = res[k].ite + 1;
                        res[k] = resk;
                        est_present = true;
                    }
                }
                if (est_present == false) // in the other case we create a new doublon we add to the result list
                {
                    doublon doub = new doublon();
                    doub.value = mat[i][j];
                    doub.ite = 1;
                    res.Add(doub);
                }
            }
        }
        this.GetSetResult = res;
    }
}

