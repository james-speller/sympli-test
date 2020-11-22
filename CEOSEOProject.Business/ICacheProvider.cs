namespace CEOSEOProject.Business
{
    using System.Threading.Tasks;

    public interface ICacheProvider
    {
        Task<int> GetValue(string key);

        Task SetValue(string key, int value);
    }
}
