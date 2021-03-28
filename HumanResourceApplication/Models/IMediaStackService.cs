using System.Collections.Generic;
using System.Threading.Tasks;

namespace HumanResourceApplication.Models
{
    public interface IMediaStackService
    {
       Task<IList<MediaData>> GetData();
    }
}