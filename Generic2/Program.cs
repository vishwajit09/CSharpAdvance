using LearningGeneric;

namespace Generic2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //  Task1();

            // Task2();
            //Task3();

            Task4();

        }

        static void Task1()
        {

            var v1 = new Accept2GenericParm<int, string>();
            v1.T11 = 10;
            v1.T12 = "new";

            v1.PrintFirstGeneric();
            v1.PrintSecondGeneric();

        }
        static void Task2()
        {

            var generator = new Generator<string>();
            generator.show();

        }

        static void Task3()
        {

            var v1 = new TypeClass<int, string>();
            v1.GetType(10);
            v1.GetType("Test");
            v1.GetType('c');

        }

        static void Task4()
        {
            BasketBall basketBall = new BasketBall("Test1", "Basketball");
            Football football = new Football("Test2", "Football");

            SportLeague<BasketBall> basketballLegaue = new SportLeague<BasketBall>();
            basketballLegaue.AddTeam(basketBall);
            //basketballLegaue.AddTeam(football);





        }
    }
}
