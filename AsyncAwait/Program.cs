namespace AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            ProgressBar progressBar = new ProgressBar();
            var progressbar = progressBar.ProgressBarProgress();
            var progressbarAdd = progressBar.AddProgress();
            //List<Task> tasks = new List<Task> { progressbar, progressbarAdd };

            await progressbarAdd;
            await progressbar;



            var readfiles = progressBar.Readfiles();
            await readfiles;




        }



    }


}
