namespace MVC.Repository
{
    public interface IPeopleRepository
    {
        string getNameById(int id);
        
    }

    public class PeopleRepository : IPeopleRepository
    {
        public PeopleRepository(string conn)
        {

        }

        public string getNameById(int id)
        {
            return "Josef Silva";
        }
    }
}