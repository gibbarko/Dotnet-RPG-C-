using System.Threading.Tasks;

namespace _NET_RPG.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;

    }
}
